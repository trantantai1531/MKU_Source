
Imports eMicLibOPAC.DataAccess.OPAC
Imports eMicLibOPAC.BusinessRules.Common

Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBOPACILLInComingReq
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private objBSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objDILLIn As New clsDOPACILLInComingReq
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
        Private strCode As String
        Private strCodeLib As String
        Private strEmail As String
        Private strCardNo As String
        Private strValidDate As String
        Private bytPriority As Byte
        Private intStatus As Integer
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
        Private intPostDelivCountry As String
        Private strPostDelivName As String
        Private strPostDelivRegion As String
        Private strPostDelivStreet As String
        Private strPostDelivXAddr As String
        Private strTelephone As String
        ' IllReqItems variables
        Private blnRequestType As Boolean
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
        ' ILLInComingReqBi variables
        ' ILLInComingReqDe variables        
        ' ILLInComingReqLog variables
        Private blnServiceType As Boolean
        Private intEncodingScheme As Integer

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
        ' AccountNumber property
        Public Property AccountNumber() As String
            Get
                Return strAccountNumber
            End Get
            Set(ByVal Value As String)
                strAccountNumber = Value
            End Set
        End Property
        ' BillDelivXAddr property
        Public Property BillDelivXAddr() As String
            Get
                Return strBillDelivXAddr
            End Get
            Set(ByVal Value As String)
                strBillDelivXAddr = Value
            End Set
        End Property
        ' Code property
        Public Property LibID() As Integer
            Get
                Return intLibID
            End Get
            Set(ByVal Value As Integer)
                intLibID = Value
            End Set
        End Property
        ' Code property
        Public Property Code() As String
            Get
                Return strCode
            End Get
            Set(ByVal Value As String)
                strCode = Value
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
                strEmailReplyAddress = Value
            End Set
        End Property
        ' LibraryName property
        Public Property LibraryName() As String
            Get
                Return strLibraryName
            End Get
            Set(ByVal Value As String)
                strLibraryName = Value
            End Set
        End Property
        ' LibrarySymbol property
        Public Property LibrarySymbol() As String
            Get
                Return strLibrarySymbol
            End Get
            Set(ByVal Value As String)
                strLibrarySymbol = Value
            End Set
        End Property
        ' PostDelivXAddr property
        Public Property PostDelivXAddr() As String
            Get
                Return strPostDelivXAddr
            End Get
            Set(ByVal Value As String)
                strPostDelivXAddr = Value
            End Set
        End Property
        ' Telephone property
        Public Property Telephone() As String
            Get
                Return strTelephone
            End Get
            Set(ByVal Value As String)
                strTelephone = Value
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
                strCallNumber = Value
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
                strBillDelivName = Value
            End Set
        End Property
        ' BillDelivBox property
        Public Property BillDelivBox() As String
            Get
                Return strBillDelivBox
            End Get
            Set(ByVal Value As String)
                strBillDelivBox = Value
            End Set
        End Property
        ' BillDelivStreet property
        Public Property BillDelivStreet() As String
            Get
                Return strBillDelivStreet
            End Get
            Set(ByVal Value As String)
                strBillDelivStreet = Value
            End Set
        End Property
        ' BillDelivCity property
        Public Property BillDelivCity() As String
            Get
                Return strBillDelivCity
            End Get
            Set(ByVal Value As String)
                strBillDelivCity = Value
            End Set
        End Property
        ' BillDelivRegion property
        Public Property BillDelivRegion() As String
            Get
                Return strBillDelivRegion
            End Get
            Set(ByVal Value As String)
                strBillDelivRegion = Value
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
                strBillDelivCode = Value
            End Set
        End Property

        ' ILLInComingReqDe properties        
        ' PostDelivName property
        Public Property PostDelivName() As String
            Get
                Return strPostDelivName
            End Get
            Set(ByVal Value As String)
                strPostDelivName = Value
            End Set
        End Property
        ' PostDelivStreet property
        Public Property PostDelivStreet() As String
            Get
                Return strPostDelivStreet
            End Get
            Set(ByVal Value As String)
                strPostDelivStreet = Value
            End Set
        End Property
        ' PostDelivBox property
        Public Property PostDelivBox() As String
            Get
                Return strPostDelivBox
            End Get
            Set(ByVal Value As String)
                strPostDelivBox = Value
            End Set
        End Property
        ' PostDelivCity property
        Public Property PostDelivCity() As String
            Get
                Return strPostDelivCity
            End Get
            Set(ByVal Value As String)
                strPostDelivCity = Value
            End Set
        End Property
        ' PostDelivRegion property
        Public Property PostDelivRegion() As String
            Get
                Return strPostDelivRegion
            End Get
            Set(ByVal Value As String)
                strPostDelivRegion = Value
            End Set
        End Property
        ' PostDelivCountry property
        Public Property PostDelivCountry() As String
            Get
                Return intPostDelivCountry
            End Get
            Set(ByVal Value As String)
                intPostDelivCountry = Value
            End Set
        End Property
        ' PostDelivCode property
        Public Property PostDelivCode() As String
            Get
                Return strPostDelivCode
            End Get
            Set(ByVal Value As String)
                strPostDelivCode = Value
            End Set
        End Property
        ' ILLInComingReqLog properties        
        ' Note property
        Public Property Note() As String
            Get
                Return strNote
            End Get
            Set(ByVal Value As String)
                strNote = Value
            End Set
        End Property
        ' ServiceType property
        Public Property ServiceType() As Boolean
            Get
                Return blnServiceType
            End Get
            Set(ByVal Value As Boolean)
                blnServiceType = Value
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

        ' *************************************************************************************************
        ' End declare properties
        ' Implement method here
        ' *************************************************************************************************

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
            objDILLIn.DBServer = strDBServer
            objDILLIn.ConnectionString = strConnectionString
            objDILLIn.Initialize()

        End Sub

        ' purpose : Create one ILLImComing Request
        ' Created by: dgsoft2016
        Public Function CreateRequest() As Integer
            Try
                objDILLIn.RequestID = strRequestID
                objDILLIn.NeedBeforeDate = objBCDBS.ConvertDateBack(strNeedBeforeDate)
                objDILLIn.ExpiryDate = objBCDBS.ConvertDateBack(strExpiryDate)
                objDILLIn.ServiceType = blnServiceType
                objDILLIn.CopyrightCompliance = intCopyrightCompliance
                objDILLIn.Priority = intPriority
                objDILLIn.MaxCost = dblMaxCost
                objDILLIn.CurrencyCode = strCurrencyCode
                objDILLIn.PaymentType = intPaymentType
                objDILLIn.ItemType = intItemType
                objDILLIn.ReciprocalAgreement = blnReciprocalAgreement
                objDILLIn.WillPayFee = blnWillPayFee
                objDILLIn.PaymentProvided = blnPaymentProvided
                objDILLIn.Medium = intMedium
                objDILLIn.DelivMode = blnDelivMode
                objDILLIn.EDelivMode = strEdelivMode
                objDILLIn.EDelivTSAddr = objBSP.ConvertItBack(strEDelivTSAddr)
                objDILLIn.EmailReplyAddress = strEmailReplyAddress
                objDILLIn.Note = strNote
                objDILLIn.PatronName = objBSP.ConvertItBack(strPatronName)
                objDILLIn.PatronID = strPatronID
                objDILLIn.PatronStatus = objBSP.ConvertItBack(strPatronStatus)
                objDILLIn.Status = intStatus
                objDILLIn.Title = objBSP.ConvertItBack(strTitle)
                '	ILLLibrary 
                objDILLIn.LibID = intLibID
                objDILLIn.AccountNumber = objBSP.ConvertItBack(strAccountNumber)
                objDILLIn.LibraryName = objBSP.ConvertItBack(strLibraryName)
                objDILLIn.LibrarySymbol = objBSP.ConvertItBack(strLibrarySymbol)
                objDILLIn.BillDelivBox = objBSP.ConvertItBack(strBillDelivBox)
                objDILLIn.BillDelivCity = objBSP.ConvertItBack(strBillDelivCity)
                objDILLIn.BillDelivCode = objBSP.ConvertItBack(strBillDelivCode)
                objDILLIn.BillDelivCountry = intBillDelivCountry
                objDILLIn.BillDelivName = objBSP.ConvertItBack(strBillDelivName)
                objDILLIn.BillDelivRegion = objBSP.ConvertItBack(strBillDelivRegion)
                objDILLIn.BillDelivStreet = objBSP.ConvertItBack(strBillDelivStreet)
                objDILLIn.BillDelivXAddr = objBSP.ConvertItBack(strBillDelivXAddr)
                objDILLIn.Code = objBSP.ConvertItBack(strCode)
                objDILLIn.Dublicate = blnDublicate
                objDILLIn.PostDelivBox = objBSP.ConvertItBack(strPostDelivBox)
                objDILLIn.PostDelivCity = objBSP.ConvertItBack(strPostDelivCity)
                objDILLIn.PostDelivCode = objBSP.ConvertItBack(strPostDelivCode)
                objDILLIn.PostDelivCountry = intPostDelivCountry
                objDILLIn.PostDelivName = objBSP.ConvertItBack(strPostDelivName)
                objDILLIn.PostDelivRegion = objBSP.ConvertItBack(strPostDelivRegion)
                objDILLIn.PostDelivStreet = objBSP.ConvertItBack(strPostDelivStreet)
                objDILLIn.PostDelivXAddr = objBSP.ConvertItBack(strPostDelivXAddr)
                objDILLIn.Telephone = strTelephone
                '	ILLRequestItems
                objDILLIn.RequestType = blnRequestType
                objDILLIn.CallNumber = objBSP.ConvertItBack(strCallNumber)
                objDILLIn.Author = objBSP.ConvertItBack(strAuthor)
                objDILLIn.PlaceOfPub = objBSP.ConvertItBack(strPlaceOfPub)
                objDILLIn.SeriesTitleNumber = objBSP.ConvertItBack(strSeriesTitleNumber)
                objDILLIn.VolumeIssue = objBSP.ConvertItBack(strVolumeIssue)
                objDILLIn.Edition = objBSP.ConvertItBack(strEdition)
                objDILLIn.PubDate = objBCDBS.ConvertDateBack(strPubDate)
                objDILLIn.ComponentPubDate = objBCDBS.ConvertDateBack(strComponentPubDate)
                objDILLIn.ArticleAuthor = objBSP.ConvertItBack(strArticleAuthor)
                objDILLIn.ArticleTitle = objBSP.ConvertItBack(strArticleTitle)
                objDILLIn.Pagination = objBSP.ConvertItBack(strPagination)
                objDILLIn.NationalBibNumber = objBSP.ConvertItBack(strNationalBibNumber)
                objDILLIn.ISBN = objBSP.ConvertItBack(strISBN)
                objDILLIn.ISSN = objBSP.ConvertItBack(strISSN)
                objDILLIn.SystemNumber = objBSP.ConvertItBack(strSystemNumber)
                objDILLIn.OtherNumbers = objBSP.ConvertItBack(strOtherNumbers)
                objDILLIn.Verification = objBSP.ConvertItBack(strVerification)
                objDILLIn.EncodingScheme = intEncodingScheme
                CreateRequest = objDILLIn.CreateRequest()
            Catch ex As Exception
                strErrorMsg = ex.Message
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
                If Not objDILLIn Is Nothing Then
                    objDILLIn.Dispose(True)
                    objDILLIn = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class

End Namespace