' Name: clsDILLInRequest
' Purpose: ILL out request purpose
' Creator: Sondp
' Created Date: 25/11/2004
' Modification History:

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.ILL
    Public Class clsDILLOutRequest
        Inherits clsDBase

        ' ***********************************************************************************************
        ' Declare Private variables
        ' ***********************************************************************************************
        '  ILL_OUTGOING_REQUESTS
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
        Private strNote As String
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
        Private strTitle As String
        Private strPatronName As String
        Private strPatronCode As String
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
        Private strAuthor As String
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
        Private intAPDUType As Integer

        ' OUTGOING_ILL_REQUEST_LOG
        Private intIllID As Integer
        ' Private intResponderID As Integer
        Private strTransactionDate As String
        ' Private strNote As String
        ' Private intAPDUType As Integer
        Private intReasonID As Integer
        Private strProvidedDate As String
        Private strResponderSpecReason As String
        Private intSendShipped As Integer
        Private intSendCheckedIn As Integer
        Private intSendReceived As Integer
        Private intSendReturned As Integer
        Private intTRE As Integer
        ' Private intMedium As String
        Private intAnswer As Integer
        Private intRenewable As Integer
        Private intLogID As Integer
        ' Private intServiceType As Integer
        Private strLocation As String
        ' Private intCopyrightCompliance As Integer
        Private strReturnedVia As String
        Private dbReturnInsuranceCost As Double
        Private strCurrencyCode3 As String
        Private strTransportationMode As String
        Private strSubSQL As String

        ' ***********************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' ***********************************************************************************************
        ' Location property
        Public Property Location() As String
            Get
                Return (strLocation)
            End Get
            Set(ByVal Value As String)
                strLocation = Value
            End Set
        End Property

        ' TransportationMode property
        Public Property TransportationMode() As String
            Get
                Return (strTransportationMode)
            End Get
            Set(ByVal Value As String)
                strTransportationMode = Value
            End Set
        End Property

        ' ReturnedVia property
        Public Property ReturnedVia() As String
            Get
                Return (strReturnedVia)
            End Get
            Set(ByVal Value As String)
                strReturnedVia = Value
            End Set
        End Property

        ' Answer property
        Public Property Answer() As Integer
            Get
                Return (intAnswer)
            End Get
            Set(ByVal Value As Integer)
                intAnswer = Value
            End Set
        End Property

        ' ReturnInsuranceCost property
        ' InsuredForCost property
        Public Property InsuredForCost() As Double
            Get
                Return (dbInsuredForCost)
            End Get
            Set(ByVal Value As Double)
                dbInsuredForCost = Value
            End Set
        End Property

        ' ResponderSpecReason property
        Public Property ResponderSpecReason() As String
            Get
                Return (strResponderSpecReason)
            End Get
            Set(ByVal Value As String)
                strResponderSpecReason = Value
            End Set
        End Property

        ' ProvidedDate property
        Public Property ProvidedDate() As String
            Get
                Return (strProvidedDate)
            End Get
            Set(ByVal Value As String)
                strProvidedDate = Value
            End Set
        End Property

        ' TransactionDate property
        Public Property TransactionDate() As String
            Get
                Return (strTransactionDate)
            End Get
            Set(ByVal Value As String)
                strTransactionDate = Value
            End Set
        End Property

        ' LogID property
        Public Property LogID() As Integer
            Get
                Return (intLogID)
            End Get
            Set(ByVal Value As Integer)
                intLogID = Value
            End Set
        End Property

        ' TRE property
        Public Property TRE() As Integer
            Get
                Return (intTRE)
            End Get
            Set(ByVal Value As Integer)
                intTRE = Value
            End Set
        End Property

        ' SendShipped property
        Public Property SendShipped() As Integer
            Get
                Return (intSendShipped)
            End Get
            Set(ByVal Value As Integer)
                intSendShipped = Value
            End Set
        End Property

        ' IllID property
        Public Property IllID() As Integer
            Get
                Return (intIllID)
            End Get
            Set(ByVal Value As Integer)
                intIllID = Value
            End Set
        End Property

        ' SendReceived property
        Public Property SendReceived() As Integer
            Get
                Return (intSendReceived)
            End Get
            Set(ByVal Value As Integer)
                intSendReceived = Value
            End Set
        End Property

        ' SendCheckedIn property
        Public Property SendCheckedIn() As Integer
            Get
                Return (intSendCheckedIn)
            End Get
            Set(ByVal Value As Integer)
                intSendCheckedIn = Value
            End Set
        End Property

        ' SendReturned property
        Public Property SendReturned() As Integer
            Get
                Return (intSendReturned)
            End Get
            Set(ByVal Value As Integer)
                intSendReturned = Value
            End Set
        End Property

        ' ReasonID property
        Public Property ReasonID() As Integer
            Get
                Return (intReasonID)
            End Get
            Set(ByVal Value As Integer)
                intReasonID = Value
            End Set
        End Property

        ' Status property
        Public Property Status() As Integer
            Get
                Return (intStatus)
            End Get
            Set(ByVal Value As Integer)
                intStatus = Value
            End Set
        End Property

        ' APDUType
        Public Property APDUType() As Integer
            Get
                Return (intAPDUType)
            End Get
            Set(ByVal Value As Integer)
                intAPDUType = Value
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
        ' ResponederID property
        Public Property ResponderID() As Integer
            Get
                Return (intResponderID)
            End Get
            Set(ByVal Value As Integer)
                intResponderID = Value
            End Set
        End Property
        ' Created Date property
        Public Property CreatedDate() As String
            Get
                Return (strCreatedDate)
            End Get
            Set(ByVal Value As String)
                strCreatedDate = Value
            End Set
        End Property
        ' RequestDate Date property
        Public Property RequestDate() As String
            Get
                Return (strRequestDate)
            End Get
            Set(ByVal Value As String)
                strRequestDate = Value
            End Set
        End Property
        ' Need Before Date property
        Public Property NeedBeforeDate() As String
            Get
                Return (strNeedBeforeDate)
            End Get
            Set(ByVal Value As String)
                strNeedBeforeDate = Value
            End Set
        End Property
        ' Expired Date property
        Public Property ExpiredDate() As String
            Get
                Return (strExpiredDate)
            End Get
            Set(ByVal Value As String)
                strExpiredDate = Value
            End Set
        End Property
        '  RespondDate  property
        Public Property RespondDate() As String
            Get
                Return (strRespondDate)
            End Get
            Set(ByVal Value As String)
                strRespondDate = Value
            End Set
        End Property
        '  CancelledDate  property
        Public Property CancelledDate() As String
            Get
                Return (strCancelledDate)
            End Get
            Set(ByVal Value As String)
                strCancelledDate = Value
            End Set
        End Property
        '  ShippedDate property
        Public Property ShippedDate() As String
            Get
                Return (strShippedDate)
            End Get
            Set(ByVal Value As String)
                strShippedDate = Value
            End Set
        End Property
        '  ReceivedDate property
        Public Property ReceivedDate() As String
            Get
                Return (strReceivedDate)
            End Get
            Set(ByVal Value As String)
                strReceivedDate = Value
            End Set
        End Property
        '  ReturnedDate property
        Public Property ReturnedDate() As String
            Get
                Return (strReturnedDate)
            End Get
            Set(ByVal Value As String)
                strReturnedDate = Value
            End Set
        End Property
        '  CheckedInDate property
        Public Property CheckedInDate() As String
            Get
                Return (strCheckedInDate)
            End Get
            Set(ByVal Value As String)
                strCheckedInDate = Value
            End Set
        End Property
        '  DueDate property
        Public Property DueDate() As String
            Get
                Return (strDueDate)
            End Get
            Set(ByVal Value As String)
                strDueDate = Value
            End Set
        End Property
        '  LocalDueDate property
        Public Property LocalDueDate() As String
            Get
                Return (strLocalDueDate)
            End Get
            Set(ByVal Value As String)
                strLocalDueDate = Value
            End Set
        End Property
        '  LocalCheckedInDate property
        Public Property LocalCheckedInDate() As String
            Get
                Return (strLocalCheckedInDate)
            End Get
            Set(ByVal Value As String)
                strLocalCheckedInDate = Value
            End Set
        End Property
        '  LocalCheckedOutDate property
        Public Property LocalCheckedOutDate() As String
            Get
                Return (strLocalCheckedOutDate)
            End Get
            Set(ByVal Value As String)
                strLocalCheckedOutDate = Value
            End Set
        End Property
        '  Renewals property
        Public Property Renewals() As Integer
            Get
                Return (intRenewals)
            End Get
            Set(ByVal Value As Integer)
                intRenewals = Value
            End Set
        End Property
        '  Renewable property
        Public Property Renewable() As Integer
            Get
                Return (intRenewable)
            End Get
            Set(ByVal Value As Integer)
                intRenewable = Value
            End Set
        End Property
        '  LoanTypeID property
        Public Property LoanTypeID() As Integer
            Get
                Return (intLoanTypeID)
            End Get
            Set(ByVal Value As Integer)
                intLoanTypeID = Value
            End Set
        End Property
        '  Barcode property
        Public Property Barcode() As String
            Get
                Return (strBarcode)
            End Get
            Set(ByVal Value As String)
                strBarcode = Value
            End Set
        End Property
        '  Notice Patron property
        Public Property NoticePatron() As Integer
            Get
                Return (intNoticePatron)
            End Get
            Set(ByVal Value As Integer)
                intNoticePatron = Value
            End Set
        End Property
        '  Cost property
        Public Property Cost() As Double
            Get
                Return (dbCost)
            End Get
            Set(ByVal Value As Double)
                dbCost = Value
            End Set
        End Property
        '  CurrencyCode1 property
        Public Property CurrencyCode1() As String
            Get
                Return (strCurrencyCode1)
            End Get
            Set(ByVal Value As String)
                strCurrencyCode1 = Value
            End Set
        End Property
        '  InsuredForCost property
        Public Property InisuredForCost() As Double
            Get
                Return (dbInsuredForCost)
            End Get
            Set(ByVal Value As Double)
                dbInsuredForCost = Value
            End Set
        End Property
        '  CurrencyCode2 property
        Public Property CurrencyCode2() As String
            Get
                Return (strCurrencyCode2)
            End Get
            Set(ByVal Value As String)
                strCurrencyCode2 = Value
            End Set
        End Property
        '  ReturnInsuranceCost property
        Public Property ReturnInsuranceCost() As Integer
            Get
                Return (intReturnInsuranceCost)
            End Get
            Set(ByVal Value As Integer)
                intReturnInsuranceCost = Value
            End Set
        End Property
        '  CurrencyCode3 property
        Public Property CurrencyCode3() As String
            Get
                Return (strCurrencyCode3)
            End Get
            Set(ByVal Value As String)
                strCurrencyCode3 = Value
            End Set
        End Property
        '  ChageableUnits property
        Public Property ChageableUnits() As Integer
            Get
                Return (intChageableUnits)
            End Get
            Set(ByVal Value As Integer)
                intChageableUnits = Value
            End Set
        End Property
        '  MaxCost property
        Public Property MaxCost() As Double
            Get
                Return (dbMaxCost)
            End Get
            Set(ByVal Value As Double)
                dbMaxCost = Value
            End Set
        End Property
        ' Currency Code property
        Public Property CurrencyCode() As String
            Get
                Return (strCurrencyCode)
            End Get
            Set(ByVal Value As String)
                strCurrencyCode = Value
            End Set
        End Property
        ' Status property
        Public Property Statust() As Integer
            Get
                Return (intStatus)
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
                Return (intDeliveryLocID)
            End Get
            Set(ByVal Value As Integer)
                intDeliveryLocID = Value
            End Set
        End Property
        ' BillingLocID property
        Public Property BillingLocID() As Integer
            Get
                Return (intBillingLocID)
            End Get
            Set(ByVal Value As Integer)
                intBillingLocID = Value
            End Set
        End Property
        ' ReciprocalAgreement property
        Public Property ReciprocalAgreement() As Integer
            Get
                Return (intReciprocalAgreement)
            End Get
            Set(ByVal Value As Integer)
                intReciprocalAgreement = Value
            End Set
        End Property
        ' WilPayFee property
        Public Property WillPayFee() As Integer
            Get
                Return (intWillPayFee)
            End Get
            Set(ByVal Value As Integer)
                intWillPayFee = Value
            End Set
        End Property
        ' PaymentProvided
        Public Property PaymentProvided() As Integer
            Get
                Return (intPaymentProvided)
            End Get
            Set(ByVal Value As Integer)
                intPaymentProvided = Value
            End Set
        End Property
        ' ServiceType property
        Public Property ServiceType() As Integer
            Get
                Return (intServiceType)
            End Get
            Set(ByVal Value As Integer)
                intServiceType = Value
            End Set
        End Property
        ' Copyright Compliance property
        Public Property CopyrightCompliance() As Integer
            Get
                Return (intCopyrightCompliance)
            End Get
            Set(ByVal Value As Integer)
                intCopyrightCompliance = Value
            End Set
        End Property
        ' Priority property 
        Public Property Priority() As Integer
            Get
                Return (intPriority)
            End Get
            Set(ByVal Value As Integer)
                intPriority = Value
            End Set
        End Property
        ' PaymentType property
        Public Property PaymentType() As Integer
            Get
                Return (intPaymentType)
            End Get
            Set(ByVal Value As Integer)
                intPaymentType = Value
            End Set
        End Property
        ' ItemType property
        Public Property ItemType() As Integer
            Get
                Return (intItemType)
            End Get
            Set(ByVal Value As Integer)
                intItemType = Value
            End Set
        End Property
        ' Medium property 
        Public Property Medium() As Integer
            Get
                Return (intMedium)
            End Get
            Set(ByVal Value As Integer)
                intMedium = Value
            End Set
        End Property
        ' DelivMode property
        Public Property DelivMode() As Integer
            Get
                Return (intDelivMode)
            End Get
            Set(ByVal Value As Integer)
                intDelivMode = Value
            End Set
        End Property
        ' EDeliveryModeID property
        Public Property EDelivModeID() As Integer
            Get
                Return (intEDelivModeID)
            End Get
            Set(ByVal Value As Integer)
                intEDelivModeID = Value
            End Set
        End Property
        '  Alert property
        Public Property Alert() As Integer
            Get
                Return (intAlert)
            End Get
            Set(ByVal Value As Integer)
                intAlert = Value
            End Set
        End Property
        ' Title property
        Public Property Title() As String
            Get
                Return (strTitle)
            End Get
            Set(ByVal Value As String)
                strTitle = Value
            End Set
        End Property
        ' PatronName property
        Public Property PatronName() As String
            Get
                Return (strPatronName)
            End Get
            Set(ByVal Value As String)
                strPatronName = Value
            End Set
        End Property
        ' PatronCode property
        Public Property PatronCode() As String
            Get
                Return (strPatronCode)
            End Get
            Set(ByVal Value As String)
                strPatronCode = Value
            End Set
        End Property
        '  PatronGroupID
        Public Property PatronGroupID() As Integer
            Get
                Return (intPatronGroupID)
            End Get
            Set(ByVal Value As Integer)
                intPatronGroupID = Value
            End Set
        End Property

        '  Properties for ILL_LIBRARIES
        '  AccountNumber
        Public Property AccountNumber() As String
            Get
                Return (strAccountNumber)
            End Get
            Set(ByVal Value As String)
                strAccountNumber = Value
            End Set
        End Property

        '  PostDelivName 
        Public Property PostDelivName() As String
            Get
                Return (strPostDelivName)
            End Get
            Set(ByVal Value As String)
                strPostDelivName = Value
            End Set
        End Property
        '  PostDelivXAddress
        Public Property PostDelivXAddr() As String
            Get
                Return (strPostDelivXAddr)
            End Get
            Set(ByVal Value As String)
                strPostDelivXAddr = Value
            End Set
        End Property
        '  PostDelivStreet
        Public Property PostDelivStreet() As String
            Get
                Return (strPostDelivStreet)
            End Get
            Set(ByVal Value As String)
                strPostDelivStreet = Value
            End Set
        End Property
        '  PostDelivBox
        Public Property PostDelivBox() As String
            Get
                Return (strPostDelivBox)
            End Get
            Set(ByVal Value As String)
                strPostDelivBox = Value
            End Set
        End Property
        '  PostDelivCity
        Public Property PostDelivCity() As String
            Get
                Return (strPostDelivCity)
            End Get
            Set(ByVal Value As String)
                strPostDelivCity = Value
            End Set
        End Property
        '  PostDelivRegion
        Public Property PostDelivRegion() As String
            Get
                Return (strPostDelivRegion)
            End Get
            Set(ByVal Value As String)
                strPostDelivRegion = Value
            End Set
        End Property
        '  PostDelivCountry
        Public Property PostDelivCountry() As Integer
            Get
                Return (intPostDelivCountry)
            End Get
            Set(ByVal Value As Integer)
                intPostDelivCountry = Value
            End Set
        End Property
        '  PostDelivCode
        Public Property PostDelivCode() As String
            Get
                Return (strPostDelivCode)
            End Get
            Set(ByVal Value As String)
                strPostDelivCode = Value
            End Set
        End Property
        '  BillDelivName 
        Public Property BillDelivName() As String
            Get
                Return (strBillDelivName)
            End Get
            Set(ByVal Value As String)
                strBillDelivName = Value
            End Set
        End Property
        '  BillDelivXAddreass
        Public Property BillDelivXAddr() As String
            Get
                Return (strBillDelivXAddr)
            End Get
            Set(ByVal Value As String)
                strBillDelivXAddr = Value
            End Set
        End Property
        '  BillDelivStreet
        Public Property BillDelivStreet() As String
            Get
                Return (strBillDelivStreet)
            End Get
            Set(ByVal Value As String)
                strBillDelivStreet = Value
            End Set
        End Property
        '  BillDelivBox
        Public Property BillDelivBox() As String
            Get
                Return (strBillDelivBox)
            End Get
            Set(ByVal Value As String)
                strBillDelivBox = Value
            End Set
        End Property
        '  BillDelivCity
        Public Property BillDelivCity() As String
            Get
                Return (strBillDelivCity)
            End Get
            Set(ByVal Value As String)
                strBillDelivCity = Value
            End Set
        End Property
        '  BillDelivRegion
        Public Property BillDelivRegion() As String
            Get
                Return (strBillDelivRegion)
            End Get
            Set(ByVal Value As String)
                strBillDelivRegion = Value
            End Set
        End Property
        '  BillDelivCountry
        Public Property BillDelivCountry() As Integer
            Get
                Return (intBillDelivCountry)
            End Get
            Set(ByVal Value As Integer)
                intBillDelivCountry = Value
            End Set
        End Property
        '  BillDelivCode
        Public Property BillDelivCode() As String
            Get
                Return (strBillDelivCode)
            End Get
            Set(ByVal Value As String)
                strBillDelivCode = Value
            End Set
        End Property

        '  Properites for ILL_ITEMS
        '  CallNumber property
        Public Property CallNumber() As String
            Get
                Return (strCallNumber)
            End Get
            Set(ByVal Value As String)
                strCallNumber = Value
            End Set
        End Property
        '  Author property
        Public Property Author() As String
            Get
                Return (strAuthor)
            End Get
            Set(ByVal Value As String)
                strAuthor = Value
            End Set
        End Property
        ' PlaceOfPub property
        Public Property PlaceOfPub() As String
            Get
                Return (strPlaceOfPub)
            End Get
            Set(ByVal Value As String)
                strPlaceOfPub = Value
            End Set
        End Property
        ' Publisher property
        Public Property Publisher() As String
            Get
                Return (strPublisher)
            End Get
            Set(ByVal Value As String)
                strPublisher = Value
            End Set
        End Property
        ' SeriesTitleNumber property
        Public Property SeriesTitleNumber() As String
            Get
                Return (strSeriesTitleNumber)
            End Get
            Set(ByVal Value As String)
                strSeriesTitleNumber = Value
            End Set
        End Property
        ' VolumeIssue property
        Public Property VolumeIssue() As String
            Get
                Return (strVolumeIssue)
            End Get
            Set(ByVal Value As String)
                strVolumeIssue = Value
            End Set
        End Property
        ' Edition property
        Public Property Edition() As String
            Get
                Return (strEdition)
            End Get
            Set(ByVal Value As String)
                strEdition = Value
            End Set
        End Property
        ' PubDate property 
        Public Property PubDate() As String
            Get
                Return (strPubDate)
            End Get
            Set(ByVal Value As String)
                strPubDate = Value
            End Set
        End Property
        ' ComponentPubDate property
        Public Property ComponentPubDate() As String
            Get
                Return (strComponentPubDate)
            End Get
            Set(ByVal Value As String)
                strComponentPubDate = Value
            End Set
        End Property
        ' Article Title property
        Public Property ArticleTitle() As String
            Get
                Return (strArticleTitle)
            End Get
            Set(ByVal Value As String)
                strArticleTitle = Value
            End Set
        End Property
        ' Article Author property
        Public Property ArticleAuthor() As String
            Get
                Return (strArticleAuthor)
            End Get
            Set(ByVal Value As String)
                strArticleAuthor = Value
            End Set
        End Property
        ' Pagination property
        Public Property Pagination() As String
            Get
                Return (strPagination)
            End Get
            Set(ByVal Value As String)
                strPagination = Value
            End Set
        End Property
        ' NationalBibNumber
        Public Property NationalBibNumber() As String
            Get
                Return (strNationalBibNumber)
            End Get
            Set(ByVal Value As String)
                strNationalBibNumber = Value
            End Set
        End Property
        ' ISBN property
        Public Property ISBN() As String
            Get
                Return (strISBN)
            End Get
            Set(ByVal Value As String)
                strISBN = Value
            End Set
        End Property
        ' ISSN property
        Public Property ISSN() As String
            Get
                Return (strISSN)
            End Get
            Set(ByVal Value As String)
                strISSN = Value
            End Set
        End Property
        ' SystemNumber property
        Public Property SystemNumber() As String
            Get
                Return (strSystemNumber)
            End Get
            Set(ByVal Value As String)
                strSystemNumber = Value
            End Set
        End Property
        ' Othernumbers property
        Public Property OtherNumbers() As String
            Get
                Return (strOtherNumbers)
            End Get
            Set(ByVal Value As String)
                strOtherNumbers = Value
            End Set
        End Property
        ' Verification property
        Public Property Verification() As String
            Get
                Return (strVerification)
            End Get
            Set(ByVal Value As String)
                strVerification = Value
            End Set
        End Property
        ' LocalNote property
        Public Property LocalNote() As String
            Get
                Return (strLocalNote)
            End Get
            Set(ByVal Value As String)
                strLocalNote = Value
            End Set
        End Property
        ' RequestType property
        Public Property RequestType() As Integer
            Get
                Return (intRequestType)
            End Get
            Set(ByVal Value As Integer)
                intRequestType = Value
            End Set
        End Property
        ' SponsoringBody property
        Public Property SponsoringBody() As String
            Get
                Return (strSponsoringBody)
            End Get
            Set(ByVal Value As String)
                strSponsoringBody = Value
            End Set
        End Property
        ' SubSQL property
        Public Property SubSQL() As String
            Get
                Return (strSubSQL)
            End Get
            Set(ByVal Value As String)
                strSubSQL = Value
            End Set
        End Property

        ' ***********************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' ***********************************************************************************************

        '  InitValuesLog method
        '  Pupose: Init variables insert into table ILL_OUTGOING_REQUESTS_LOG
        '  Creater: Tuanhv
        '  Date: 23/12/2004
        Public Sub InitValuesLog()
            intIllID = 0
            intResponderID = 0
            strTransactionDate = ""
            strNote = ""
            intAPDUType = 0
            intReasonID = -1
            strProvidedDate = ""
            strResponderSpecReason = ""
            intSendShipped = 0
            intSendCheckedIn = 0
            intSendReceived = 0
            intSendReturned = 0
            intTRE = -1
            intMedium = -1
            dbCost = -1
            strCurrencyCode1 = ""
            intAnswer = 0
            strDueDate = ""
            intRenewable = -1
            intAlert = 0
            intLogID = 0
            intServiceType = -1
            strLocation = ""
            intCopyrightCompliance = -1
            strReturnedVia = ""
            dbInsuredForCost = -1
            strCurrencyCode2 = ""
            dbReturnInsuranceCost = -1
            strCurrencyCode3 = ""
            strTransportationMode = ""
        End Sub

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

        ' Purpose: Create new out request
        ' Input: Some informations
        ' Output: Integer
        ' Creator: Sondp
        Public Function CreateOR() As Integer
            Dim intRetVal As Integer = 0
            Dim strOutSQL As String
            Call OpenConnection()
            strNote = strNote.Replace("'", "''")
            strTitle = strTitle.Replace("'", "''")
            strAuthor = strAuthor.Replace("'", "''")
            strArticleAuthor = strArticleAuthor.Replace("'", "''")
            strArticleTitle = strArticleTitle.Replace("'", "''")
            strPatronName = strPatronName.Replace("'", "''")
            strPublisher = strPublisher.Replace("'", "''")
            strEdition = strEdition.Replace("'", "''")
            strLocalNote = strLocalNote.Replace("'", "''")
            strPlaceOfPub = strPlaceOfPub.Replace("'", "''")

            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spOutgoingRequest_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                ' ILL_OUTGOING_REQUESTS
                                .Add(New SqlParameter("@intResponderID", SqlDbType.Int, 4)).Value = intResponderID
                                .Add(New SqlParameter("@strCreateDate", SqlDbType.VarChar, 20)).Value = strCreatedDate
                                .Add(New SqlParameter("@strNeedBeforeDate", SqlDbType.VarChar, 20)).Value = strNeedBeforeDate
                                .Add(New SqlParameter("@strExpiredDate", SqlDbType.VarChar, 20)).Value = strExpiredDate
                                .Add(New SqlParameter("@monyMaxCost", SqlDbType.Float)).Value = dbMaxCost
                                .Add(New SqlParameter("@strCurrencyCode", SqlDbType.VarChar, 8)).Value = strCurrencyCode
                                .Add(New SqlParameter("@intStatus", SqlDbType.Int, 4)).Value = intStatus
                                .Add(New SqlParameter("@strNote", SqlDbType.NVarChar, 200)).Value = strNote
                                .Add(New SqlParameter("@intDeliveryLocID", SqlDbType.Int, 4)).Value = intDeliveryLocID
                                .Add(New SqlParameter("@intBillingLocID", SqlDbType.Int, 4)).Value = intBillingLocID
                                .Add(New SqlParameter("@bitReciprocalAgreement", SqlDbType.Bit, 1)).Value = intReciprocalAgreement
                                .Add(New SqlParameter("@bitWillPayFee", SqlDbType.Bit, 1)).Value = intWillPayFee
                                .Add(New SqlParameter("@bitPaymentProvided", SqlDbType.Bit, 1)).Value = intPaymentProvided
                                .Add(New SqlParameter("@intServiceType", SqlDbType.Int, 4)).Value = intServiceType
                                .Add(New SqlParameter("@intCopyrightCompliance", SqlDbType.Int, 4)).Value = intCopyrightCompliance
                                .Add(New SqlParameter("@intPriority", SqlDbType.Int, 4)).Value = intPriority
                                .Add(New SqlParameter("@intPaymentType", SqlDbType.Int, 4)).Value = intPaymentType
                                .Add(New SqlParameter("@intItemType", SqlDbType.Int, 4)).Value = intItemType
                                .Add(New SqlParameter("@intMedium", SqlDbType.Int, 4)).Value = intMedium
                                .Add(New SqlParameter("@intDelivMode", SqlDbType.Int, 4)).Value = intDelivMode
                                .Add(New SqlParameter("@intEdelivModeID", SqlDbType.Int, 4)).Value = intEDelivModeID
                                .Add(New SqlParameter("@strTitle", SqlDbType.NVarChar, 200)).Value = strTitle
                                .Add(New SqlParameter("@strPatronName", SqlDbType.NVarChar, 50)).Value = strPatronName
                                .Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 50)).Value = strPatronCode
                                .Add(New SqlParameter("@intPatronGroupID", SqlDbType.Int, 4)).Value = intPatronGroupID
                                ' ILL_REQUEST_ITEMS
                                .Add(New SqlParameter("@strCallNumber", SqlDbType.NVarChar, 50)).Value = strCallNumber
                                .Add(New SqlParameter("@strAuthor", SqlDbType.NVarChar, 100)).Value = strAuthor
                                .Add(New SqlParameter("@strPlaceOfPub", SqlDbType.NVarChar, 50)).Value = strPlaceOfPub
                                .Add(New SqlParameter("@strPublisher", SqlDbType.NVarChar, 100)).Value = strPublisher
                                .Add(New SqlParameter("@strSeriesTitleNumber", SqlDbType.NVarChar, 120)).Value = strSeriesTitleNumber
                                .Add(New SqlParameter("@strVolumeIssue", SqlDbType.NVarChar, 40)).Value = strVolumeIssue
                                .Add(New SqlParameter("@strEdition", SqlDbType.NVarChar, 50)).Value = strEdition
                                .Add(New SqlParameter("@strPubDate", SqlDbType.VarChar, 20)).Value = strPubDate
                                .Add(New SqlParameter("@strComponentPubDate", SqlDbType.VarChar, 20)).Value = strComponentPubDate
                                .Add(New SqlParameter("@strArticleAuthor", SqlDbType.NVarChar, 64)).Value = strArticleAuthor
                                .Add(New SqlParameter("@strArticleTitle", SqlDbType.NVarChar, 200)).Value = strArticleTitle
                                .Add(New SqlParameter("@strPagination", SqlDbType.NVarChar, 50)).Value = strPagination
                                .Add(New SqlParameter("@strNationalBibNumber", SqlDbType.NVarChar, 50)).Value = strNationalBibNumber
                                .Add(New SqlParameter("@strISBN", SqlDbType.VarChar, 16)).Value = strISBN
                                .Add(New SqlParameter("@strISSN", SqlDbType.VarChar, 16)).Value = strISSN
                                .Add(New SqlParameter("@strSystemNumber", SqlDbType.NVarChar, 50)).Value = strSystemNumber
                                .Add(New SqlParameter("@strOtherNumbers", SqlDbType.NVarChar, 50)).Value = strOtherNumbers
                                .Add(New SqlParameter("@strVerification", SqlDbType.NVarChar, 50)).Value = strVerification
                                .Add(New SqlParameter("@strLocalNote", SqlDbType.NVarChar, 100)).Value = strLocalNote
                                .Add(New SqlParameter("@strSponsoringBody", SqlDbType.NVarChar, 100)).Value = strSponsoringBody
                                .Add(New SqlParameter("@intRetval", SqlDbType.Int, 4)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("@intRetval").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_CREATE_OUTGOINGREQUEST"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intResponderID", OracleType.Number, 4)).Value = intResponderID
                                .Add(New OracleParameter("strCreateDate", OracleType.VarChar, 20)).Value = strCreatedDate
                                .Add(New OracleParameter("strNeedBeforeDate", OracleType.VarChar, 20)).Value = strNeedBeforeDate
                                .Add(New OracleParameter("strExpiredDate", OracleType.VarChar, 20)).Value = strExpiredDate
                                .Add(New OracleParameter("monyMaxCost", OracleType.Float)).Value = dbMaxCost
                                .Add(New OracleParameter("strCurrencyCode", OracleType.VarChar, 8)).Value = strCurrencyCode
                                .Add(New OracleParameter("intStatus", OracleType.Number, 4)).Value = intStatus
                                .Add(New OracleParameter("strNote", OracleType.VarChar, 200)).Value = strNote
                                .Add(New OracleParameter("intDeliveryLocID", OracleType.Number, 4)).Value = intDeliveryLocID
                                .Add(New OracleParameter("intBillingLocID", OracleType.Number, 4)).Value = intBillingLocID
                                .Add(New OracleParameter("intReciprocalAgreement", OracleType.Number, 1)).Value = intReciprocalAgreement
                                .Add(New OracleParameter("intWillPayFee", OracleType.Number, 1)).Value = intWillPayFee
                                .Add(New OracleParameter("intPaymentProvided", OracleType.Number, 1)).Value = intPaymentProvided
                                .Add(New OracleParameter("intServiceType", OracleType.Number, 4)).Value = intServiceType
                                .Add(New OracleParameter("intCopyrightCompliance", OracleType.Number, 4)).Value = intCopyrightCompliance
                                .Add(New OracleParameter("intPriority", OracleType.Number, 4)).Value = intPriority
                                .Add(New OracleParameter("intPaymentType", OracleType.Number, 4)).Value = intPaymentType
                                .Add(New OracleParameter("intItemType", OracleType.Number, 4)).Value = intItemType
                                .Add(New OracleParameter("intMedium", OracleType.Number, 4)).Value = intMedium
                                .Add(New OracleParameter("intDelivMode", OracleType.Number, 4)).Value = intDelivMode
                                .Add(New OracleParameter("intEdelivModeID", OracleType.Number, 4)).Value = intEDelivModeID
                                .Add(New OracleParameter("strTitle", OracleType.VarChar, 200)).Value = strTitle
                                .Add(New OracleParameter("strPatronName", OracleType.VarChar, 50)).Value = strPatronName
                                .Add(New OracleParameter("strPatronCode", OracleType.VarChar, 50)).Value = strPatronCode
                                .Add(New OracleParameter("intPatronGroupID", OracleType.Number, 4)).Value = intPatronGroupID
                                .Add(New OracleParameter("strCallNumber", OracleType.VarChar, 24)).Value = strCallNumber
                                .Add(New OracleParameter("strAuthor", OracleType.VarChar, 100)).Value = strAuthor
                                .Add(New OracleParameter("strPlaceOfPub", OracleType.VarChar, 30)).Value = strPlaceOfPub
                                .Add(New OracleParameter("strPublisher", OracleType.VarChar, 100)).Value = strPublisher
                                .Add(New OracleParameter("strSeriesTitleNumber", OracleType.VarChar, 120)).Value = strSeriesTitleNumber
                                .Add(New OracleParameter("strVolumeIssue", OracleType.VarChar, 40)).Value = strVolumeIssue
                                .Add(New OracleParameter("strEdition", OracleType.VarChar, 40)).Value = strEdition
                                .Add(New OracleParameter("strPubDate", OracleType.VarChar, 20)).Value = strPubDate
                                .Add(New OracleParameter("strComponentPubDate", OracleType.VarChar, 20)).Value = strComponentPubDate
                                .Add(New OracleParameter("strArticleAuthor", OracleType.VarChar, 64)).Value = strArticleAuthor
                                .Add(New OracleParameter("strArticleTitle", OracleType.VarChar, 200)).Value = strArticleTitle
                                .Add(New OracleParameter("strPagination", OracleType.VarChar, 50)).Value = strPagination
                                .Add(New OracleParameter("strNationalBibNumber", OracleType.VarChar, 25)).Value = strNationalBibNumber
                                .Add(New OracleParameter("strISBN", OracleType.VarChar, 16)).Value = strISBN
                                .Add(New OracleParameter("strISSN", OracleType.VarChar, 16)).Value = strISSN
                                .Add(New OracleParameter("strSystemNumber", OracleType.VarChar, 20)).Value = strSystemNumber
                                .Add(New OracleParameter("strOtherNumbers", OracleType.VarChar, 50)).Value = strOtherNumbers
                                .Add(New OracleParameter("strVerification", OracleType.VarChar, 16)).Value = strVerification
                                .Add(New OracleParameter("strLocalNote", OracleType.VarChar, 100)).Value = strLocalNote
                                .Add(New OracleParameter("strSponsoringBody", OracleType.VarChar, 100)).Value = strSponsoringBody
                                .Add(New OracleParameter("intRetval", OracleType.Number, 4)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("intRetval").Value
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            CreateOR = intRetVal
        End Function

        ' GetORInfor method
        ' Purpose: Get Information about selected request
        ' Input: RequestID
        ' Output: datatable result
        ' Creator: Oanhtn
        Public Function GetORInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_GET_OR_DETAIL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngRequestID", OracleType.Number)).Value = intIllID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetORInfor = dsData.Tables("tblResult")
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
                        .CommandText = "Ill_spSelDetail"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngRequestID", SqlDbType.Int)).Value = intIllID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetORInfor = dsData.Tables("tblResult")
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

        Public Function GetORItem() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_GET_REQITEM_INFOR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngID", OracleType.Number)).Value = intIllID
                            .Parameters.Add(New OracleParameter("intType", OracleType.Number)).Value = 0
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetORItem = dsData.Tables("tblResult")
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
                        .CommandText = "Ill_spRequestItem_SelByIdAndRequestType"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngID", SqlDbType.Int)).Value = intIllID
                            .Parameters.Add(New SqlParameter("@intType", SqlDbType.Int)).Value = 0
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetORItem = dsData.Tables("tblResult")
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

        Public Function GetORHistoryInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_GET_ILL_OUT_HISTORY"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngRequestID", OracleType.Number)).Value = intIllID
                            .Parameters.Add(New OracleParameter("bitAlert", OracleType.Number)).Value = intAlert
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetORHistoryInfor = dsData.Tables("tblResult")
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
                        .CommandText = "Ill_spOutgoingRequestLog_SelHistory"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngRequestID", SqlDbType.Int)).Value = intIllID
                            .Parameters.Add(New SqlParameter("@bitAlert", SqlDbType.Int)).Value = intAlert
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetORHistoryInfor = dsData.Tables("tblResult")
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

        Public Function GetILLOutRequestNum(ByVal lngTopNum As Long, ByRef lngTotalRec As Long, ByRef lngCurrentPos As Long) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_GET_ILLOUTREQUEST_BY_TOPNUM"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("lngRequestID", OracleType.Number)).Value = intIllID
                            .Parameters.Add(New OracleParameter("lngTopNum", OracleType.Number)).Value = lngTopNum
                            .Parameters.Add(New OracleParameter("lngTotalRec", OracleType.Number)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("lngCurrentPos", OracleType.Number)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            lngCurrentPos = .Parameters("lngCurrentPos").Value
                            lngTotalRec = .Parameters("lngTotalRec").Value
                            GetILLOutRequestNum = dsData.Tables("tblResult")
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
                        .CommandText = "Ill_spOutgoingRequest_SelByTopNum"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngRequestID", SqlDbType.Int)).Value = intIllID
                            .Parameters.Add(New SqlParameter("@lngTopNum", SqlDbType.Int)).Value = lngTopNum
                            .Parameters.Add(New SqlParameter("@lngTotalRec", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@lngCurrentPos", SqlDbType.Int)).Direction = ParameterDirection.Output
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            lngTotalRec = .Parameters("@lngTotalRec").Value
                            lngCurrentPos = .Parameters("@lngCurrentPos").Value
                            GetILLOutRequestNum = dsData.Tables("tblResult")
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

        Public Sub CancelOR()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_OUT_CANCEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngID", OracleType.Number)).Value = intIllID
                            .Parameters.Add(New OracleParameter("strNote", OracleType.VarChar, 200)).Value = strNote
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
                        .CommandText = "Ill_spOutgoingRequest_UpdStatusCancel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngID", SqlDbType.Int)).Value = intIllID
                            .Parameters.Add(New SqlParameter("@strNote", SqlDbType.NVarChar)).Value = strNote
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

        ' InsertORequestLog function
        ' Input: Information fot outgoing log
        ' Output: 1 if insert succes else return 0
        ' Creator: Tuanhv
        ' Date: 24/12/2004
        Function InsertORequestLog() As Integer
            Call OpenConnection()
            Dim intRetval As Integer = 0
            strNote = strNote.Replace("'", "''")

            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_INSERT_OR_LOG"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIllID", OracleType.Number)).Value = intIllID
                            .Parameters.Add(New OracleParameter("intResponderID", OracleType.Number)).Value = intResponderID
                            .Parameters.Add(New OracleParameter("strTransactionDate", OracleType.VarChar, 30)).Value = strTransactionDate
                            .Parameters.Add(New OracleParameter("strNote", OracleType.VarChar, 200)).Value = strNote
                            .Parameters.Add(New OracleParameter("intAPDUType", OracleType.Number)).Value = intAPDUType
                            .Parameters.Add(New OracleParameter("intReasonID", OracleType.Number)).Value = intReasonID
                            .Parameters.Add(New OracleParameter("strProvidedDate", OracleType.VarChar, 30)).Value = strProvidedDate
                            .Parameters.Add(New OracleParameter("strResponderSpecReason", OracleType.VarChar, 100)).Value = strResponderSpecReason
                            .Parameters.Add(New OracleParameter("intSendShipped", OracleType.Number)).Value = intSendShipped
                            .Parameters.Add(New OracleParameter("intSendCheckedIn", OracleType.Number)).Value = intSendCheckedIn
                            .Parameters.Add(New OracleParameter("intSendReceived", OracleType.Number)).Value = intSendReceived
                            .Parameters.Add(New OracleParameter("intSendReturned", OracleType.Number)).Value = intSendReturned
                            .Parameters.Add(New OracleParameter("intTRE", OracleType.Number)).Value = intTRE
                            .Parameters.Add(New OracleParameter("intMedium", OracleType.Number)).Value = intMedium
                            .Parameters.Add(New OracleParameter("dbCost", OracleType.Double)).Value = dbCost
                            .Parameters.Add(New OracleParameter("strCurrencyCode1", OracleType.VarChar, 4)).Value = strCurrencyCode1
                            .Parameters.Add(New OracleParameter("intAnswer", OracleType.Number)).Value = intAnswer
                            .Parameters.Add(New OracleParameter("strDueDate", OracleType.VarChar, 30)).Value = strDueDate
                            .Parameters.Add(New OracleParameter("intRenewable", OracleType.Number)).Value = intRenewable
                            .Parameters.Add(New OracleParameter("intAlert", OracleType.Number)).Value = intAlert
                            .Parameters.Add(New OracleParameter("intServiceType", OracleType.Number)).Value = intServiceType
                            .Parameters.Add(New OracleParameter("strLocation", OracleType.VarChar, 100)).Value = strLocation
                            .Parameters.Add(New OracleParameter("intCopyrightCompliance", OracleType.Number)).Value = intCopyrightCompliance
                            .Parameters.Add(New OracleParameter("strReturnedVia", OracleType.VarChar, 100)).Value = strReturnedVia
                            .Parameters.Add(New OracleParameter("dbInsuredForCost", OracleType.Double)).Value = dbInsuredForCost
                            .Parameters.Add(New OracleParameter("strCurrencyCode2", OracleType.VarChar, 4)).Value = strCurrencyCode2
                            .Parameters.Add(New OracleParameter("dbReturnInsuranceCost", OracleType.Double)).Value = dbReturnInsuranceCost
                            .Parameters.Add(New OracleParameter("strCurrencyCode3", OracleType.VarChar, 4)).Value = strCurrencyCode3
                            .Parameters.Add(New OracleParameter("strTransportationMode", OracleType.VarChar, 50)).Value = strTransportationMode
                            .ExecuteNonQuery()
                            intRetval = 1
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spOutgoingRequestLog_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIllID", SqlDbType.Int)).Value = intIllID
                            .Parameters.Add(New SqlParameter("@intResponderID", SqlDbType.Int)).Value = intResponderID
                            .Parameters.Add(New SqlParameter("@strTransactionDate", SqlDbType.VarChar)).Value = strTransactionDate
                            .Parameters.Add(New SqlParameter("@strNote", SqlDbType.NVarChar, 200)).Value = strNote
                            .Parameters.Add(New SqlParameter("@intAPDUType", SqlDbType.Int)).Value = intAPDUType
                            .Parameters.Add(New SqlParameter("@intReasonID", SqlDbType.Int)).Value = intReasonID
                            .Parameters.Add(New SqlParameter("@strProvidedDate", SqlDbType.VarChar, 30)).Value = strProvidedDate
                            .Parameters.Add(New SqlParameter("@strResponderSpecReason", SqlDbType.NVarChar, 100)).Value = strResponderSpecReason
                            .Parameters.Add(New SqlParameter("@intSendShipped", SqlDbType.Int)).Value = intSendShipped
                            .Parameters.Add(New SqlParameter("@intSendCheckedIn", SqlDbType.Int)).Value = intSendCheckedIn
                            .Parameters.Add(New SqlParameter("@intSendReceived", SqlDbType.Int)).Value = intSendReceived
                            .Parameters.Add(New SqlParameter("@intSendReturned", SqlDbType.Int)).Value = intSendReturned
                            .Parameters.Add(New SqlParameter("@intTRE", SqlDbType.Int)).Value = intTRE
                            .Parameters.Add(New SqlParameter("@intMedium", SqlDbType.Int)).Value = intMedium
                            .Parameters.Add(New SqlParameter("@dbCost", SqlDbType.Float)).Value = dbCost
                            .Parameters.Add(New SqlParameter("@strCurrencyCode1", SqlDbType.Char, 3)).Value = strCurrencyCode1
                            .Parameters.Add(New SqlParameter("@intAnswer", SqlDbType.Bit)).Value = intAnswer
                            .Parameters.Add(New SqlParameter("@strDueDate", SqlDbType.VarChar, 30)).Value = strDueDate
                            If intRenewable < 0 Then
                                intRenewable = 0
                            End If
                            .Parameters.Add(New SqlParameter("@intRenewable", SqlDbType.Bit)).Value = intRenewable
                            .Parameters.Add(New SqlParameter("@intAlert", SqlDbType.Bit)).Value = intAlert
                            .Parameters.Add(New SqlParameter("@intServiceType", SqlDbType.Int)).Value = intServiceType
                            .Parameters.Add(New SqlParameter("@strLocation", SqlDbType.NVarChar, 300)).Value = strLocation
                            .Parameters.Add(New SqlParameter("@intCopyrightCompliance", SqlDbType.Int)).Value = intCopyrightCompliance
                            .Parameters.Add(New SqlParameter("@strReturnedVia", SqlDbType.NVarChar, 100)).Value = strReturnedVia
                            .Parameters.Add(New SqlParameter("@dbInsuredForCost", SqlDbType.Float)).Value = dbInsuredForCost
                            .Parameters.Add(New SqlParameter("@strCurrencyCode2", SqlDbType.Char, 3)).Value = strCurrencyCode2
                            .Parameters.Add(New SqlParameter("@dbReturnInsuranceCost", SqlDbType.Float)).Value = dbReturnInsuranceCost
                            .Parameters.Add(New SqlParameter("@strCurrencyCode3", SqlDbType.Char, 3)).Value = strCurrencyCode3
                            .Parameters.Add(New SqlParameter("@strTransportationMode", SqlDbType.NVarChar)).Value = strTransportationMode
                            ' .Parameters.Add(New SqlParameter("@strTest", SqlDbType.NVarChar, 2000)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intRetval = 1
                            'Dim str As String
                            ' str = .Parameters("@strTest").Value()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            InsertORequestLog = intRetval
        End Function

        ' Purpose: Deny out request
        ' Input: tblPatronInfor, and tblResponseInfor content information of patron and response
        ' Output: Datable content information of patron as Fullname, Mail, Mobile... 
        ' Creator: Tuanhv
        ' Date: 21/12/2004
        Public Function DenyOR(ByRef tblPatronInfor As DataTable, ByRef tblResponseInfor As DataTable)
            ' Get information of patron
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_RESPONSES_GET_DENIED"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intRequestID", OracleType.Number)).Value = intIllID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            tblPatronInfor = dsdata.Tables("tblResult")
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
                        .CommandText = "Ill_spOutgoingRequest_SelDenied"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intRequestID", SqlDbType.Int)).Value = intIllID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            tblPatronInfor = dsdata.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select

            ' Get all information of request(response) 
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_RESPONSES_GET_GENDENIED"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intRequestID", OracleType.Number)).Value = intIllID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            tblResponseInfor = dsdata.Tables("tblResult")
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
                        .CommandText = "Ill_spRequestItem_SelgenDenied"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intRequestID", SqlDbType.Int)).Value = intIllID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            tblResponseInfor = dsdata.Tables("tblResult")
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

        '  Purpose: Update outgoing requests
        '  Input: Some informations
        '  Output: Integer
        '  Creator: Sondp
        '  Notice: Variables input type
        '  Stt   |    Type in database     |     InputType     |  Description
        '  1.    |          BIT            |      INTEGER      |  -1: not update, -2: update=NULL, else: get this  
        '  2.    |         MONEY           |      DOUBLE       |  -1: not update, -2: update=NULL, else: get this  
        '  3.    |  VARCHAR(NVARCHAR...)   |      STRING       |' ' : not update, NULL: update=NULL, else: get this
        Public Function UpdateOR() As Integer
            Dim intRetVal As Integer = 0
            Call OpenConnection()
            strNote = strNote.Replace("'", "''")
            strTitle = strTitle.Replace("'", "''")
            strAuthor = strAuthor.Replace("'", "''")
            strArticleAuthor = strArticleAuthor.Replace("'", "''")
            strArticleTitle = strArticleTitle.Replace("'", "''")
            strPatronName = strPatronName.Replace("'", "''")
            strPublisher = strPublisher.Replace("'", "''")
            strEdition = strEdition.Replace("'", "''")
            strLocalNote = strLocalNote.Replace("'", "''")
            strPlaceOfPub = strPlaceOfPub.Replace("'", "''")

            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spOutgoingRequest_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                ' ILL_OUTGOING_REQUESTS
                                .Add(New SqlParameter("@intID", SqlDbType.Int, 4)).Value = intIllID
                                .Add(New SqlParameter("@strRequestID", SqlDbType.VarChar, 14)).Value = strRequestID
                                .Add(New SqlParameter("@intResponderID", SqlDbType.Int, 4)).Value = intResponderID
                                .Add(New SqlParameter("@strCreatedDate", SqlDbType.VarChar, 20)).Value = strCreatedDate
                                .Add(New SqlParameter("@strRequestDate", SqlDbType.VarChar, 20)).Value = strRequestDate
                                .Add(New SqlParameter("@strNeedBeforeDate", SqlDbType.VarChar, 20)).Value = strNeedBeforeDate
                                .Add(New SqlParameter("@strExpiredDate", SqlDbType.VarChar, 20)).Value = strExpiredDate
                                .Add(New SqlParameter("@strRespondDate", SqlDbType.VarChar, 20)).Value = strRespondDate
                                .Add(New SqlParameter("@strCancelledDate", SqlDbType.VarChar, 20)).Value = strCancelledDate
                                .Add(New SqlParameter("@strShippedDate", SqlDbType.VarChar, 20)).Value = strShippedDate
                                .Add(New SqlParameter("@strReceivedDate", SqlDbType.VarChar, 20)).Value = strReceivedDate
                                .Add(New SqlParameter("@strReturnedDate", SqlDbType.VarChar, 20)).Value = strReturnedDate
                                .Add(New SqlParameter("@strCheckedInDate", SqlDbType.VarChar, 20)).Value = strCheckedInDate
                                .Add(New SqlParameter("@strDueDate", SqlDbType.VarChar, 20)).Value = strDueDate
                                .Add(New SqlParameter("@strLocalDueDate", SqlDbType.VarChar, 20)).Value = strLocalDueDate
                                .Add(New SqlParameter("@strLocalCheckedInDate", SqlDbType.VarChar, 20)).Value = strLocalCheckedInDate
                                .Add(New SqlParameter("@strLocalCheckedOutDate", SqlDbType.VarChar, 20)).Value = strLocalCheckedOutDate
                                .Add(New SqlParameter("@intRenewals", SqlDbType.Int, 4)).Value = intRenewals
                                .Add(New SqlParameter("@intRenewable", SqlDbType.Int, 4)).Value = intRenewable
                                .Add(New SqlParameter("@intLoanTypeID", SqlDbType.Int, 4)).Value = intLoanTypeID
                                .Add(New SqlParameter("@strBarcode", SqlDbType.VarChar, 24)).Value = strBarcode
                                .Add(New SqlParameter("@bitNoticePatron", SqlDbType.Int, 4)).Value = intNoticePatron
                                .Add(New SqlParameter("@monyCost", SqlDbType.Float)).Value = dbCost

                                .Add(New SqlParameter("@strCurrencyCode1", SqlDbType.VarChar, 8)).Value = strCurrencyCode1
                                .Add(New SqlParameter("@monyInsuredForCost", SqlDbType.Float)).Value = dbInsuredForCost
                                .Add(New SqlParameter("@strCurrencyCode2", SqlDbType.VarChar, 8)).Value = strCurrencyCode2
                                .Add(New SqlParameter("@intReturnInsuranceCost", SqlDbType.Int, 4)).Value = intReturnInsuranceCost
                                .Add(New SqlParameter("@strCurrencyCode3", SqlDbType.VarChar, 8)).Value = strCurrencyCode3
                                .Add(New SqlParameter("@intChageableUnits", SqlDbType.Int, 4)).Value = intChageableUnits
                                .Add(New SqlParameter("@monyMaxCost", SqlDbType.Float)).Value = dbMaxCost
                                .Add(New SqlParameter("@strCurrencyCode", SqlDbType.VarChar, 8)).Value = strCurrencyCode
                                .Add(New SqlParameter("@intStatus", SqlDbType.Int, 4)).Value = intStatus
                                .Add(New SqlParameter("@strNote", SqlDbType.NVarChar, 200)).Value = strNote
                                .Add(New SqlParameter("@intDeliveryLocID", SqlDbType.Int, 4)).Value = intDeliveryLocID
                                .Add(New SqlParameter("@intBillingLocID", SqlDbType.Int, 4)).Value = intBillingLocID
                                .Add(New SqlParameter("@bitReciprocalAgreement", SqlDbType.Int, 4)).Value = intReciprocalAgreement
                                .Add(New SqlParameter("@bitWillPayFee", SqlDbType.Int, 4)).Value = intWillPayFee
                                .Add(New SqlParameter("@bitPaymentProvided", SqlDbType.Int, 4)).Value = intPaymentProvided
                                .Add(New SqlParameter("@intServiceType", SqlDbType.Int, 4)).Value = intServiceType
                                .Add(New SqlParameter("@intCopyrightCompliance", SqlDbType.Int, 4)).Value = intCopyrightCompliance
                                .Add(New SqlParameter("@intPriority", SqlDbType.Int, 4)).Value = intPriority
                                .Add(New SqlParameter("@intPaymentType", SqlDbType.Int, 4)).Value = intPaymentType
                                .Add(New SqlParameter("@intItemType", SqlDbType.Int, 4)).Value = intItemType
                                .Add(New SqlParameter("@intMedium", SqlDbType.Int, 4)).Value = intMedium
                                .Add(New SqlParameter("@intDelivMode", SqlDbType.Int, 4)).Value = intDelivMode
                                .Add(New SqlParameter("@intEdelivModeID", SqlDbType.Int, 4)).Value = intEDelivModeID
                                .Add(New SqlParameter("@bitAlert", SqlDbType.Int, 4)).Value = intAlert
                                .Add(New SqlParameter("@strTitle", SqlDbType.NVarChar, 200)).Value = strTitle
                                .Add(New SqlParameter("@strPatronName", SqlDbType.NVarChar, 50)).Value = strPatronName
                                .Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 50)).Value = strPatronCode
                                .Add(New SqlParameter("@intPatronGroupID", SqlDbType.Int, 4)).Value = intPatronGroupID
                                ' ILL_LIBRARIES
                                .Add(New SqlParameter("@strAccountNumber", SqlDbType.NVarChar, 50)).Value = strAccountNumber
                                .Add(New SqlParameter("@strPostDelivName", SqlDbType.NVarChar, 50)).Value = strPostDelivName
                                .Add(New SqlParameter("@strPostDelivXAddr", SqlDbType.NVarChar, 50)).Value = strPostDelivXAddr
                                .Add(New SqlParameter("@strPostDelivStreet", SqlDbType.NVarChar, 50)).Value = strPostDelivStreet
                                .Add(New SqlParameter("@strPostDelivBox", SqlDbType.VarChar, 50)).Value = strPostDelivBox
                                .Add(New SqlParameter("@strPostDelivCity", SqlDbType.NVarChar, 50)).Value = strPostDelivCity
                                .Add(New SqlParameter("@strPostDelivRegion", SqlDbType.NVarChar, 50)).Value = strPostDelivRegion
                                .Add(New SqlParameter("@intPostDelivCountry", SqlDbType.Int, 4)).Value = intPostDelivCountry
                                .Add(New SqlParameter("@strPostDelivCode", SqlDbType.VarChar, 10)).Value = strPostDelivCode
                                .Add(New SqlParameter("@strBillDelivName", SqlDbType.NVarChar, 50)).Value = strBillDelivName
                                .Add(New SqlParameter("@strBillDelivXAddr", SqlDbType.NVarChar, 50)).Value = strBillDelivXAddr
                                .Add(New SqlParameter("@strBillDelivStreet", SqlDbType.NVarChar, 50)).Value = strBillDelivStreet
                                .Add(New SqlParameter("@strBillDelivBox", SqlDbType.NVarChar, 50)).Value = strBillDelivBox
                                .Add(New SqlParameter("@strBillDelivCity", SqlDbType.NVarChar, 50)).Value = strBillDelivCity
                                .Add(New SqlParameter("@strBillDelivRegion", SqlDbType.NVarChar, 50)).Value = strBillDelivRegion
                                .Add(New SqlParameter("@intBillDelivCountry", SqlDbType.Int, 4)).Value = intBillDelivCountry
                                .Add(New SqlParameter("@strBillDelivCode", SqlDbType.VarChar, 50)).Value = strBillDelivCode
                                ' ILL_REQUEST_ITEMS
                                .Add(New SqlParameter("@strCallNumber", SqlDbType.NVarChar, 50)).Value = strCallNumber
                                .Add(New SqlParameter("@strAuthor", SqlDbType.NVarChar, 100)).Value = strAuthor
                                .Add(New SqlParameter("@strPlaceOfPub", SqlDbType.NVarChar, 30)).Value = strPlaceOfPub
                                .Add(New SqlParameter("@strPublisher", SqlDbType.NVarChar, 100)).Value = strPublisher
                                .Add(New SqlParameter("@strSeriesTitleNumber", SqlDbType.NVarChar, 120)).Value = strSeriesTitleNumber
                                .Add(New SqlParameter("@strVolumeIssue", SqlDbType.NVarChar, 40)).Value = strVolumeIssue
                                .Add(New SqlParameter("@strEdition", SqlDbType.NVarChar, 50)).Value = strEdition
                                .Add(New SqlParameter("@strPubDate", SqlDbType.VarChar, 20)).Value = strPubDate
                                .Add(New SqlParameter("@strComponentPubDate", SqlDbType.VarChar, 20)).Value = strComponentPubDate
                                .Add(New SqlParameter("@strArticleAuthor", SqlDbType.NVarChar, 64)).Value = strArticleAuthor
                                .Add(New SqlParameter("@strArticleTitle", SqlDbType.NVarChar, 200)).Value = strArticleTitle
                                .Add(New SqlParameter("@strPagination", SqlDbType.NVarChar, 50)).Value = strPagination
                                .Add(New SqlParameter("@strNationalBibNumber", SqlDbType.NVarChar, 50)).Value = strNationalBibNumber
                                .Add(New SqlParameter("@strISBN", SqlDbType.NVarChar, 16)).Value = strISBN
                                .Add(New SqlParameter("@strISSN", SqlDbType.NVarChar, 16)).Value = strISSN
                                .Add(New SqlParameter("@strSystemNumber", SqlDbType.NVarChar, 50)).Value = strSystemNumber
                                .Add(New SqlParameter("@strOtherNumbers", SqlDbType.NVarChar, 50)).Value = strOtherNumbers
                                .Add(New SqlParameter("@strVerification", SqlDbType.NVarChar, 50)).Value = strVerification
                                .Add(New SqlParameter("@strLocalNote", SqlDbType.NVarChar, 100)).Value = strLocalNote
                                .Add(New SqlParameter("@strSponsoringBody", SqlDbType.NVarChar, 100)).Value = strSponsoringBody
                                .Add(New SqlParameter("@strSubSQL", SqlDbType.NVarChar, 50)).Value = strSubSQL
                                .Add(New SqlParameter("@intRetval", SqlDbType.Int, 4)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("@intRetval").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_UPDATE_OUTGOINGREQUEST"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                '  ILL_OUTGOING_REQUESTS
                                .Add(New OracleParameter("intID", OracleType.Number, 4)).Value = intIllID
                                .Add(New OracleParameter("strRequestID", OracleType.VarChar, 14)).Value = strRequestID
                                .Add(New OracleParameter("intResponderID", OracleType.Number, 4)).Value = intResponderID
                                .Add(New OracleParameter("strCreatedDate", OracleType.VarChar, 20)).Value = strCreatedDate
                                .Add(New OracleParameter("strRequestDate", OracleType.VarChar, 20)).Value = strRequestDate
                                .Add(New OracleParameter("strNeedBeforeDate", OracleType.VarChar, 20)).Value = strNeedBeforeDate
                                .Add(New OracleParameter("strExpiredDate", OracleType.VarChar, 20)).Value = strExpiredDate
                                .Add(New OracleParameter("strRespondDate", OracleType.VarChar, 20)).Value = strRespondDate
                                .Add(New OracleParameter("strCancelledDate", OracleType.VarChar, 20)).Value = strCancelledDate
                                .Add(New OracleParameter("strShippedDate", OracleType.VarChar, 20)).Value = strShippedDate
                                .Add(New OracleParameter("strReceivedDate", OracleType.VarChar, 20)).Value = strReceivedDate
                                .Add(New OracleParameter("strReturnedDate", OracleType.VarChar, 20)).Value = strReturnedDate
                                .Add(New OracleParameter("strCheckedInDate", OracleType.VarChar, 20)).Value = strCheckedInDate
                                .Add(New OracleParameter("strDueDate", OracleType.VarChar, 20)).Value = strDueDate
                                .Add(New OracleParameter("strLocalDueDate", OracleType.VarChar, 20)).Value = strLocalDueDate
                                .Add(New OracleParameter("strLocalCheckedInDate", OracleType.VarChar, 20)).Value = strLocalCheckedInDate
                                .Add(New OracleParameter("strLocalCheckedOutDate", OracleType.VarChar, 20)).Value = strLocalCheckedOutDate
                                .Add(New OracleParameter("intRenewals", OracleType.Number, 4)).Value = intRenewals
                                .Add(New OracleParameter("intRenewable", OracleType.Number)).Value = intRenewable
                                .Add(New OracleParameter("intLoanTypeID", OracleType.Number, 4)).Value = intLoanTypeID
                                .Add(New OracleParameter("strBarcode", OracleType.VarChar, 24)).Value = strBarcode

                                .Add(New OracleParameter("intNoticePatron", OracleType.Number, 2)).Value = intNoticePatron
                                .Add(New OracleParameter("monyCost", OracleType.Float)).Value = dbCost
                                .Add(New OracleParameter("strCurrencyCode1", OracleType.VarChar, 8)).Value = strCurrencyCode1
                                .Add(New OracleParameter("monyInsuredForCost", OracleType.Float)).Value = dbCost
                                .Add(New OracleParameter("strCurrencyCode2", OracleType.VarChar, 8)).Value = strCurrencyCode2
                                .Add(New OracleParameter("intReturnInsuranceCost", OracleType.Number, 4)).Value = intReturnInsuranceCost
                                .Add(New OracleParameter("strCurrencyCode3", OracleType.VarChar, 8)).Value = strCurrencyCode3
                                .Add(New OracleParameter("intChageableUnits", OracleType.Number, 2)).Value = intChageableUnits
                                .Add(New OracleParameter("monyMaxCost", OracleType.Float)).Value = dbMaxCost
                                .Add(New OracleParameter("strCurrencyCode", OracleType.VarChar, 8)).Value = strCurrencyCode
                                .Add(New OracleParameter("intStatus", OracleType.Number, 4)).Value = intStatus
                                .Add(New OracleParameter("strNote", OracleType.VarChar, 200)).Value = strNote
                                .Add(New OracleParameter("intDeliveryLocID", OracleType.Number, 4)).Value = intDeliveryLocID
                                .Add(New OracleParameter("intBillingLocID", OracleType.Number, 4)).Value = intBillingLocID
                                .Add(New OracleParameter("intReciprocalAgreement", OracleType.Number, 1)).Value = intReciprocalAgreement
                                .Add(New OracleParameter("intWillPayFee", OracleType.Number, 1)).Value = intWillPayFee
                                .Add(New OracleParameter("intPaymentProvided", OracleType.Number, 1)).Value = intPaymentProvided
                                .Add(New OracleParameter("intServiceType", OracleType.Number, 4)).Value = intServiceType
                                .Add(New OracleParameter("intCopyrightCompliance", OracleType.Number, 4)).Value = intCopyrightCompliance
                                .Add(New OracleParameter("intPriority", OracleType.Number, 4)).Value = intPriority
                                .Add(New OracleParameter("intPaymentType", OracleType.Number, 4)).Value = intPaymentType
                                .Add(New OracleParameter("intItemType", OracleType.Number, 4)).Value = intItemType
                                .Add(New OracleParameter("intMedium", OracleType.Number, 4)).Value = intMedium
                                .Add(New OracleParameter("intDelivMode", OracleType.Number, 4)).Value = intDelivMode
                                .Add(New OracleParameter("intEdelivModeID", OracleType.Number, 4)).Value = intEDelivModeID
                                .Add(New OracleParameter("intAlert", OracleType.Number, 2)).Value = intAlert
                                .Add(New OracleParameter("strTitle", OracleType.VarChar, 200)).Value = strTitle
                                .Add(New OracleParameter("strPatronName", OracleType.VarChar, 50)).Value = strPatronName
                                .Add(New OracleParameter("strPatronCode", OracleType.VarChar, 50)).Value = strPatronCode
                                .Add(New OracleParameter("intPatronGroupID", OracleType.Number, 4)).Value = intPatronGroupID

                                .Add(New OracleParameter("strCallNumber", OracleType.VarChar, 24)).Value = strCallNumber
                                .Add(New OracleParameter("strAuthor", OracleType.VarChar, 100)).Value = strAuthor
                                .Add(New OracleParameter("strPlaceOfPub", OracleType.VarChar, 30)).Value = strPlaceOfPub
                                .Add(New OracleParameter("strPublisher", OracleType.VarChar, 100)).Value = strPublisher
                                .Add(New OracleParameter("strSeriesTitleNumber", OracleType.VarChar, 120)).Value = strSeriesTitleNumber
                                .Add(New OracleParameter("strVolumeIssue", OracleType.VarChar, 40)).Value = strVolumeIssue
                                .Add(New OracleParameter("strEdition", OracleType.VarChar, 40)).Value = strEdition
                                .Add(New OracleParameter("strPubDate", OracleType.VarChar, 20)).Value = strPubDate
                                .Add(New OracleParameter("strComponentPubDate", OracleType.VarChar, 20)).Value = strComponentPubDate
                                .Add(New OracleParameter("strArticleAuthor", OracleType.VarChar, 64)).Value = strArticleAuthor
                                .Add(New OracleParameter("strArticleTitle", OracleType.VarChar, 200)).Value = strArticleTitle

                                .Add(New OracleParameter("strPagination", OracleType.VarChar, 50)).Value = strPagination
                                .Add(New OracleParameter("strNationalBibNumber", OracleType.VarChar, 25)).Value = strNationalBibNumber
                                .Add(New OracleParameter("strISBN", OracleType.VarChar, 16)).Value = strISBN
                                .Add(New OracleParameter("strISSN", OracleType.VarChar, 16)).Value = strISSN
                                .Add(New OracleParameter("strSystemNumber", OracleType.VarChar, 20)).Value = strSystemNumber
                                .Add(New OracleParameter("strOtherNumbers", OracleType.VarChar, 50)).Value = strOtherNumbers
                                .Add(New OracleParameter("strVerification", OracleType.VarChar, 16)).Value = strVerification
                                .Add(New OracleParameter("strLocalNote", OracleType.VarChar, 100)).Value = strLocalNote
                                .Add(New OracleParameter("strSponsoringBody", OracleType.VarChar, 100)).Value = strSponsoringBody
                                .Add(New OracleParameter("strAccountNumber", OracleType.VarChar, 50)).Value = strAccountNumber

                                .Add(New OracleParameter("strPostDelivName", OracleType.VarChar, 50)).Value = strPostDelivName
                                .Add(New OracleParameter("strPostDelivXAddr", OracleType.VarChar, 50)).Value = strPostDelivXAddr
                                .Add(New OracleParameter("strPostDelivStreet", OracleType.VarChar, 50)).Value = strPostDelivStreet
                                .Add(New OracleParameter("strPostDelivBox", OracleType.VarChar, 50)).Value = strPostDelivBox
                                .Add(New OracleParameter("strPostDelivCity", OracleType.VarChar, 50)).Value = strPostDelivCity
                                .Add(New OracleParameter("strPostDelivRegion", OracleType.VarChar, 50)).Value = strPostDelivRegion
                                .Add(New OracleParameter("intPostDelivCountry", OracleType.Number, 4)).Value = intPostDelivCountry
                                .Add(New OracleParameter("strPostDelivCode", OracleType.VarChar, 10)).Value = strPostDelivCode
                                .Add(New OracleParameter("strBillDelivName", OracleType.VarChar, 50)).Value = strBillDelivName
                                .Add(New OracleParameter("strBillDelivXAddr", OracleType.VarChar, 50)).Value = strBillDelivXAddr
                                .Add(New OracleParameter("strBillDelivStreet", OracleType.VarChar, 50)).Value = strBillDelivStreet
                                .Add(New OracleParameter("strBillDelivBox", OracleType.VarChar, 50)).Value = strBillDelivBox
                                .Add(New OracleParameter("strBillDelivCity", OracleType.VarChar, 50)).Value = strBillDelivCity
                                .Add(New OracleParameter("strBillDelivRegion", OracleType.VarChar, 50)).Value = strBillDelivRegion
                                .Add(New OracleParameter("intBillDelivCountry", OracleType.Number, 4)).Value = intBillDelivCountry
                                .Add(New OracleParameter("strBillDelivCode", OracleType.VarChar, 50)).Value = strBillDelivCode
                                .Add(New OracleParameter("strSubSQL", OracleType.VarChar, 50)).Value = strSubSQL
                                .Add(New OracleParameter("intRetval", OracleType.Number, 4)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("intRetval").Value
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            UpdateOR = intRetVal
        End Function

        Public Sub ChangeORStatus(ByVal intType As Int16)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_OR_CHANGE_STATUS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngID", OracleType.Number)).Value = intIllID
                            .Parameters.Add(New OracleParameter("strNote", OracleType.VarChar, 200)).Value = strNote
                            .Parameters.Add(New OracleParameter("intType", OracleType.Number)).Value = intType
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
                        .CommandText = "Ill_spOutgoingRequest_UpdChangeStatus"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngID", SqlDbType.Int)).Value = intIllID
                            .Parameters.Add(New SqlParameter("@strNote", SqlDbType.NVarChar)).Value = strNote
                            .Parameters.Add(New SqlParameter("@intType", SqlDbType.Int)).Value = intType
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

        Public Sub Renew(ByVal strDesiredDueDate As String, ByVal strNote As String, Optional ByVal lngLogID As Long = 0)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_OR_RENEW"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngILLID", OracleType.Number)).Value = intIllID
                            .Parameters.Add(New OracleParameter("lngLogID", OracleType.Number)).Value = lngLogID
                            .Parameters.Add(New OracleParameter("strDesiredDueDate", OracleType.VarChar, 20)).Value = strDesiredDueDate
                            .Parameters.Add(New OracleParameter("strNote", OracleType.VarChar)).Value = strNote
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
                        .CommandText = "Ill_spOutgoingRequest_InsRenew"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngILLID", SqlDbType.Int)).Value = intIllID
                            .Parameters.Add(New SqlParameter("@lngLogID", SqlDbType.Int)).Value = lngLogID
                            .Parameters.Add(New SqlParameter("@strDesiredDueDate", SqlDbType.VarChar)).Value = strDesiredDueDate
                            .Parameters.Add(New SqlParameter("@strNote", SqlDbType.NVarChar)).Value = strNote
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


        ' Purpose: Send notice patron
        ' Input: tblPatronInfor, and tblResponseInfor content information of patron and response
        ' Output: Datable content information of patron as Fullname, Mail, Mobile... 
        ' Creator: Tuanhv
        ' Date: 27/12/2004
        Public Function SendNoticePatron(ByRef tblPatronInfor As DataTable, ByRef tblResponseInfor As DataTable)
            ' Get information of patron
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_RESPONSES_GET_GENDENIED "
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intRequestID", OracleType.Number)).Value = intIllID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            tblPatronInfor = dsdata.Tables("tblResult")
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
                        .CommandText = "Ill_spRequestItem_SelgenDenied"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intRequestID", SqlDbType.Int)).Value = intIllID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            tblPatronInfor = dsdata.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select

            ' Get all information of request(response) 
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_GET_OUTOVERDUE_INFOR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIllID", OracleType.Number)).Value = intIllID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            tblResponseInfor = dsdata.Tables("tblResult")
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
                        .CommandText = "Ill_spSelOutOverDueInfor"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIllID", SqlDbType.Int)).Value = intIllID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            tblResponseInfor = dsdata.Tables("tblResult")
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

        Public Sub AnswerCondition(ByVal intAnser As Int16)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_OUT_ANSWERCONDITION"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intAnswer", OracleType.Number)).Value = intAnser
                            .Parameters.Add(New OracleParameter("lngID", OracleType.Number)).Value = intIllID
                            .Parameters.Add(New OracleParameter("strNote", OracleType.VarChar, 200)).Value = strNote
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
                        .CommandText = "Ill_spOutgoingRequest_UpdAnswerCondition"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intAnswer", SqlDbType.Int)).Value = intAnser
                            .Parameters.Add(New SqlParameter("@lngID", SqlDbType.Int)).Value = intIllID
                            .Parameters.Add(New SqlParameter("@strNote", SqlDbType.NVarChar)).Value = strNote
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

        ' Purpose: Delete out request
        ' Input: IllID
        ' Output: 1 if delete succes else return 0
        ' Creator: Tuanhv
        ' Date: 25/12/2004
        Public Function DeleteOR() As Integer
            Call OpenConnection()
            DeleteOR = 1
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_OR_LOG_DEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIllID", OracleType.Number)).Value = intIllID
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            DeleteOR = 0
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spOutgoingRequestLog_Del"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIllID", SqlDbType.Int)).Value = intIllID
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            DeleteOR = 0
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Sub ChangeFolder()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spIncomingRequest_UpdChangeFolder"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intType", SqlDbType.Int)).Value = 2
                                .Add(New SqlParameter("@lngILLID", SqlDbType.Int)).Value = intIllID
                            End With
                            .ExecuteNonQuery()
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_CHANGE_FOLDER"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intType", OracleType.Number)).Value = 2
                            .Add(New OracleParameter("lngILLID", OracleType.Number)).Value = intIllID
                        End With
                        Try
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        Public Sub SendRequest()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spOutgoingRequest_InsStatusAndRequestDate"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@lngILLID", SqlDbType.Int)).Value = intIllID
                            End With
                            .ExecuteNonQuery()
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_OR_SEND_REG"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("lngILLID", OracleType.Number)).Value = intIllID
                        End With
                        Try
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' Purpose: SendOverDueMess out request
        ' Input: tblPatronInfor, and tblResponseInfor content information of patron and response
        ' Output: Datable content information of patron as Fullname, Mail, Mobile... 
        ' Creator: Tuanhv
        ' Date: 27/12/2004
        Public Function SendOverDueMess() As DataTable
            ' Get information of patron
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_GET_OUTOVERDUE_INFOR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intILLID", OracleType.Number)).Value = intIllID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            SendOverDueMess = dsdata.Tables("tblResult")
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
                        .CommandText = "Ill_spSelOutOverDueInfor"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intILLID", SqlDbType.Int)).Value = intIllID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            SendOverDueMess = dsdata.Tables("tblResult")
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


        ' GetRequestIDByIndex method
        ' Purpose: Get requestID by index of request
        ' Input: RequestID
        ' Output: long value of requestID
        ' Creator: Oanhtn
        Public Function GetRequestIDByIndex(ByVal lngIndex As Long) As Long
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_GET_REQUESTID_BY_INDEX"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intMode", OracleType.Number)).Value = 0
                            .Parameters.Add(New OracleParameter("lngIndex", OracleType.Number)).Value = lngIndex
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetRequestIDByIndex = dsData.Tables("tblResult").Rows(0).Item("RequestID")
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
                        .CommandText = "Ill_spRequest_SelByIndex"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intMode", SqlDbType.Int)).Value = 0
                            .Parameters.Add(New SqlParameter("@lngRequestID", SqlDbType.Int)).Value = intIllID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetRequestIDByIndex = dsData.Tables("tblResult").Rows(0).Item("RequestID")
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

        Public Function GetOutRequestResponseInfor(ByVal lngID As Long) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.ILL_GET_OUT_RESPONSE_INFOR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngid", OracleType.Number)).Value = lngID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetOutRequestResponseInfor = dsData.Tables("tblResult")
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
                        .CommandText = "Ill_spOutgoingRequestLog_SelInfor"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngid", SqlDbType.Int)).Value = lngID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetOutRequestResponseInfor = dsData.Tables("tblResult")
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

        ' Purpose: Get Patron groupt method
        ' Input: ID
        ' Output: DataTable
        ' Creator: Sondp
        Public Function GetPatronGroup(ByVal intID As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_GET_PATRON_GROUP"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intID", OracleType.Number)).Value = intID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetPatronGroup = dsData.Tables("tblResult")
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
                        .CommandText = "Cir_spPatronGroup_SelAllOrById"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetPatronGroup = dsData.Tables("tblResult")
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

        ' Purpose: Get Item Type
        ' Input: strID
        ' Output: DataTable
        ' Creator: Sondp
        Public Function GetItemType(ByVal strTypeID As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_CAT_DIC_ITEM_TYPE_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strTypeID", OracleType.VarChar, 1000)).Value = strTypeID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetItemType = dsData.Tables("tblResult")
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
                        .CommandText = "SP_CAT_DIC_ITEM_TYPE_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strTypeID", SqlDbType.VarChar, 1000)).Value = strTypeID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemType = dsData.Tables("tblResult")
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

        ' Purpose: Get ILL  Medium Types
        ' Input: intID
        ' Output: DataTable
        ' Creator: Sondp
        Public Function GetILLMediumTypes(ByVal intID As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_GET_MEDIUM_TYPES"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intid", OracleType.Number, 4)).Value = intID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetILLMediumTypes = dsData.Tables("tblResult")
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
                        .CommandText = "Ill_spMediumType_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int, 4)).Value = intID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetILLMediumTypes = dsData.Tables("tblResult")
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

        Public Sub AddORLog(ByVal intAPDU As Integer)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_OR_LOG_INS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngID", OracleType.Number)).Value = intIllID
                            .Parameters.Add(New OracleParameter("strNote", OracleType.VarChar, 2000)).Value = strNote
                            .Parameters.Add(New OracleParameter("intAPDUType", OracleType.Number)).Value = intAPDU
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
                        .CommandText = "Ill_spOutgoingRequestLog_InsLog"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngID", SqlDbType.Int)).Value = intIllID
                            .Parameters.Add(New SqlParameter("@strNote", SqlDbType.NVarChar, 2000)).Value = strNote
                            .Parameters.Add(New SqlParameter("@intAPDUType", SqlDbType.Int)).Value = intAPDU
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

        '  Purpose: Search Patron
        '  In: strPatronName, strPatronCode
        '  Out: Datatable
        '  Creator: Sondp
        '  CreatedDate: 21/12/2004
        Public Function SearchPatron(ByVal strPatronName As String, ByVal strPatronCode As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_SEARCH_PATRON"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strPatronName", OracleType.VarChar, 150)).Value = strPatronName
                            .Parameters.Add(New OracleParameter("strPatronCode", OracleType.VarChar, 50)).Value = strPatronCode
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            SearchPatron = dsData.Tables("tblResult")
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
                        .CommandText = "Cir_spPatron_SelToSearchForIll"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strPatronName", SqlDbType.NVarChar, 150)).Value = strPatronName
                            .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 50)).Value = strPatronCode
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            SearchPatron = dsData.Tables("tblResult")
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

        'Purpose: Get ILL unresponse
        'Output: Datatable content list reason 
        'Creator: Tuanhv
        'Date: 21/12/2004
        Public Function GetILLResponse() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_RESPONSES_GET_PATDENIED"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetILLResponse = dsdata.Tables("tblResult")
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
                        .CommandText = "Ill_spRespond_SelPatDenied"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetILLResponse = dsdata.Tables("tblResult")
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

        '  Purpose: Get Out Request and ILL items 
        '  In: intID
        '  Out: Datatable
        '  Creator: Sondp
        '  CreatedDate: 22/12/2004
        Public Function GetORequestItems(ByVal intExpandInfor As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_GET_OREQUEST_ITEMS"
                        .CommandType = CommandType.StoredProcedure
                        Try

                            .Parameters.Add(New OracleParameter("intID", OracleType.Number, 4)).Value = intIllID
                            .Parameters.Add(New OracleParameter("intExpandInfor", OracleType.Number, 4)).Value = intExpandInfor
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetORequestItems = dsData.Tables("tblResult")
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
                        .CommandText = "Ill_spOutgoingRequest_SelById"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int, 4)).Value = intIllID
                            .Parameters.Add(New SqlParameter("@intExpandInfor", SqlDbType.Int, 4)).Value = intExpandInfor
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetORequestItems = dsData.Tables("tblResult")
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

        Public Function Get_ILL_OR_Renew_Log() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spOutgoingRequestLog_SelById"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@lngILLID", SqlDbType.Int)).Value = intIllID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            Get_ILL_OR_Renew_Log = dsData.Tables("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_GET_OR_RENEW_LOG"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("lngILLID", OracleType.Number)).Value = intIllID
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            Get_ILL_OR_Renew_Log = dsData.Tables("tblResult")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Sub InsertORequestDenied()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spOutgoingRequestDenied_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intILLID", SqlDbType.Int)).Value = intIllID
                                .Add(New SqlParameter("@strRequestDate", SqlDbType.VarChar, 100)).Value = strRequestDate
                                .Add(New SqlParameter("@intResponderID", SqlDbType.Int)).Value = intResponderID
                                .Add(New SqlParameter("@intReasonID", SqlDbType.Int)).Value = intReasonID
                                .Add(New SqlParameter("@strRespondDate", SqlDbType.VarChar, 100)).Value = strRespondDate
                                .Add(New SqlParameter("@strNote", SqlDbType.NVarChar, 200)).Value = strNote
                            End With
                            .ExecuteNonQuery()
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_INSERT_OR_DENIED"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intILLID", OracleType.Number)).Value = intIllID
                                .Add(New OracleParameter("strRequestDate", OracleType.VarChar, 100)).Value = strRequestDate
                                .Add(New OracleParameter("intResponderID", OracleType.Number)).Value = intResponderID
                                .Add(New OracleParameter("intReasonID", OracleType.Number)).Value = intReasonID
                                .Add(New OracleParameter("strRespondDate", OracleType.VarChar, 100)).Value = strRespondDate
                                .Add(New OracleParameter("strNote", OracleType.VarChar, 200)).Value = strNote
                            End With
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' Purpose: GetLocal Library
        ' In: intID
        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                Call MyBase.Dispose(isDisposing)
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace