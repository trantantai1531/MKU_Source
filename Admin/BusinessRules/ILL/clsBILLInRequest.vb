Imports System
Imports System.IO
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.ILL

Namespace eMicLibAdmin.BusinessRules.ILL
    Public Class clsBILLInRequest
        Inherits clsBBase

        ' ***********************************************************************************************
        ' Declare Private variables
        ' ***********************************************************************************************

        Protected intILLID As Integer = 0
        Private intTemplateID As Integer
        Private strRequesterSymbol As String
        Private strRequesterName As String
        Private strResponderSymbol As String
        Private strResponderName As String
        Private strServiceDate As String
        Private strServiceTime As String
        Private strSubTransactQualifier As String
        Private strProtocolVerNum As String
        Private strTransactGroupQualifier As String
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objDILLInRequest As New clsDILLInRequest
        Private objBCTemplate As New clsBCommonTemplate
        Private objBILLLib As New clsBILLLibrary

        Private objPara() As String = {"SMTP_SERVER", "SMTP_PORT", "ADMIN_EMAIL_ADDRESS", "DATE_FORMAT", "ILL_ENCODE"}
        Private objSysPara() As String
        'add by lent
        Private intRequesterID As Integer
        Private strTransactionDate As String
        Private strNote As String
        Private intAPDUType As Integer
        Private intReasonID As Integer
        Private strProvidedDate As String
        Private strResponderSpecReason As String
        Private intSendShipped As Integer
        Private intSendCheckedIn As Integer
        Private intSendReceived As Integer
        Private intSendReturned As Integer
        Private intTRE As Integer
        Private intMedium As Integer
        Private dbCost As Double
        Private strCurrencyCode1 As String
        Private bitAnswer As Integer
        Private strDueDate As String
        Private bitRenewable As Integer
        Private bitAlert As Integer
        Private intLogID As Integer
        Private intServiceType As Integer
        Private strLocation As String
        Private intCopyrightCompliance As Integer
        Private strReturnedVia As String
        Private dbInsuredForCost As Double
        Private strCurrencyCode2 As String
        Private dbReturnInsuranceCost As Double
        Private strCurrencyCode3 As String

        Private strBarcode As String
        Private strCancelledDate As String
        Private intChargeableUnits As Integer
        Private strCheckedInDate As String
        Private strCheckedOutDate As String
        Private strCurrencyCode As String
        Private intDelivConditionID As Integer
        Private bitDelivMode As Integer
        Private strEDelivMode As String
        Private strEDelivTSAddr As String
        Private strEmailReplyAddress As String
        Private strExpiryDate As String
        Private strInternalRefNumber As String
        Private intItemType As Integer
        Private intLoanTypeID As Integer
        Private dbMaxCost As Double
        Private strNeedBeforeDate As String
        Private strPatronID As String
        Private strPatronName As String
        Private strPatronStatus As String
        Private bitPaymentProvided As Integer
        Private intPaymentType As Integer
        Private intPriority As Integer
        Private strReceivedDate As String
        Private bitReciprocalAgreement As Integer
        Private intRenewals As Integer
        Private strRequestDate As String
        Private strRequestID As String
        Private strRespondDate As String
        Private strReturnedDate As String
        Private intReturnLocID As Integer
        Private strShippedDate As String
        Private strIssueID As String
        Private intStatus As Integer
        Private intItemID As Integer
        Private strTitle As String
        Private intTransportationModeID As Integer
        Private bitWillPayFee As Integer
        Private strBoolSQL As String
        Private strIDs As String
        Private blnEncodeOk As Boolean

        ' ***********************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' ***********************************************************************************************
#Region "Declare public properties"
        ' Template ID
        Public Property TemplateID() As Integer
            Get
                Return (intTemplateID)
            End Get
            Set(ByVal Value As Integer)
                intTemplateID = Value
            End Set
        End Property
        ' ILL  property
        Public Property ILLID() As Integer
            Get
                Return (intILLID)
            End Get
            Set(ByVal Value As Integer)
                intILLID = Value
            End Set
        End Property
        'LibraryID
        Public Property RequesterID() As Integer
            Get
                Return intRequesterID
            End Get
            Set(ByVal Value As Integer)
                intRequesterID = Value
            End Set
        End Property
        Public Property TransactionDate() As String
            Get
                Return strTransactionDate
            End Get
            Set(ByVal Value As String)
                strTransactionDate = Value
            End Set
        End Property
        Public Property Note() As String
            Get
                Return strNote
            End Get
            Set(ByVal Value As String)
                strNote = Value
            End Set
        End Property
        Public Property APDUType() As Integer
            Get
                Return intAPDUType
            End Get
            Set(ByVal Value As Integer)
                intAPDUType = Value
            End Set
        End Property
        Public Property ReasonID() As Integer
            Get
                Return intReasonID
            End Get
            Set(ByVal Value As Integer)
                intReasonID = Value
            End Set
        End Property
        Public Property ProvidedDate() As String
            Get
                Return strProvidedDate
            End Get
            Set(ByVal Value As String)
                strProvidedDate = Value
            End Set
        End Property
        Public Property ResponderSpecReason() As String
            Get
                Return strResponderSpecReason
            End Get
            Set(ByVal Value As String)
                strResponderSpecReason = Value
            End Set
        End Property
        Public Property SendShipped() As Integer
            Get
                Return intSendShipped
            End Get
            Set(ByVal Value As Integer)
                intSendShipped = Value
            End Set
        End Property
        Public Property SendCheckedIn() As Integer
            Get
                Return intSendCheckedIn
            End Get
            Set(ByVal Value As Integer)
                intSendCheckedIn = Value
            End Set
        End Property
        Public Property SendReceived() As Integer
            Get
                Return intSendReceived
            End Get
            Set(ByVal Value As Integer)
                intSendReceived = Value
            End Set
        End Property
        Public Property SendReturned() As Integer
            Get
                Return intSendReturned
            End Get
            Set(ByVal Value As Integer)
                intSendReturned = Value
            End Set
        End Property
        Public Property TRE() As Integer
            Get
                Return intTRE
            End Get
            Set(ByVal Value As Integer)
                intTRE = Value
            End Set
        End Property
        Public Property Medium() As Integer
            Get
                Return intMedium
            End Get
            Set(ByVal Value As Integer)
                intMedium = Value
            End Set
        End Property
        Public Property Cost() As Double
            Get
                Return dbCost
            End Get
            Set(ByVal Value As Double)
                dbCost = Value
            End Set
        End Property
        Public Property CurrencyCode1() As String
            Get
                Return strCurrencyCode1
            End Get
            Set(ByVal Value As String)
                strCurrencyCode1 = Value
            End Set
        End Property
        Public Property Answer() As Integer
            Get
                Return bitAnswer
            End Get
            Set(ByVal Value As Integer)
                bitAnswer = Value
            End Set
        End Property
        Public Property DueDate() As String
            Get
                Return strDueDate
            End Get
            Set(ByVal Value As String)
                strDueDate = Value
            End Set
        End Property
        Public Property Renewable() As Integer
            Get
                Return bitRenewable
            End Get
            Set(ByVal Value As Integer)
                bitRenewable = Value
            End Set
        End Property
        Public Property Alert() As Integer
            Get
                Return bitAlert
            End Get
            Set(ByVal Value As Integer)
                bitAlert = Value
            End Set
        End Property
        Public Property LogID() As Integer
            Get
                Return intLogID
            End Get
            Set(ByVal Value As Integer)
                intLogID = Value
            End Set
        End Property

        Public Property ServiceType() As Integer
            Get
                Return intServiceType
            End Get
            Set(ByVal Value As Integer)
                intServiceType = Value
            End Set
        End Property
        Public Property Location() As String
            Get
                Return strLocation
            End Get
            Set(ByVal Value As String)
                strLocation = Value
            End Set
        End Property
        Public Property CopyrightCompliance() As Integer
            Get
                Return intCopyrightCompliance
            End Get
            Set(ByVal Value As Integer)
                intCopyrightCompliance = Value
            End Set
        End Property
        Public Property ReturnedVia() As String
            Get
                Return strReturnedVia
            End Get
            Set(ByVal Value As String)
                strReturnedVia = Value
            End Set
        End Property
        Public Property InsuredForCost() As Double
            Get
                Return dbInsuredForCost
            End Get
            Set(ByVal Value As Double)
                dbInsuredForCost = Value
            End Set
        End Property
        Public Property CurrencyCode2() As String
            Get
                Return strCurrencyCode2
            End Get
            Set(ByVal Value As String)
                strCurrencyCode2 = Value
            End Set
        End Property
        Public Property ReturnInsuranceCost() As Double
            Get
                Return dbReturnInsuranceCost
            End Get
            Set(ByVal Value As Double)
                dbReturnInsuranceCost = Value
            End Set
        End Property
        Public Property CurrencyCode3() As String
            Get
                Return strCurrencyCode3
            End Get
            Set(ByVal Value As String)
                strCurrencyCode3 = Value
            End Set
        End Property
        Public Property Barcode() As String
            Get
                Return strBarcode
            End Get
            Set(ByVal Value As String)
                strBarcode = Value
            End Set
        End Property
        Public Property CancelledDate() As String
            Get
                Return strCancelledDate
            End Get
            Set(ByVal Value As String)
                strCancelledDate = Value
            End Set
        End Property
        Public Property ChargeableUnits() As Integer
            Get
                Return intChargeableUnits
            End Get
            Set(ByVal Value As Integer)
                intChargeableUnits = Value
            End Set
        End Property
        Public Property CheckedInDate() As String
            Get
                Return strCheckedInDate
            End Get
            Set(ByVal Value As String)
                strCheckedInDate = Value
            End Set
        End Property
        Public Property CheckedOutDate() As String
            Get
                Return strCheckedOutDate
            End Get
            Set(ByVal Value As String)
                strCheckedOutDate = Value
            End Set
        End Property
        Public Property CurrencyCode() As String
            Get
                Return strCurrencyCode
            End Get
            Set(ByVal Value As String)
                strCurrencyCode = Value
            End Set
        End Property
        Public Property DelivConditionID() As Integer
            Get
                Return intDelivConditionID
            End Get
            Set(ByVal Value As Integer)
                intDelivConditionID = Value
            End Set
        End Property
        Public Property DelivMode() As Integer
            Get
                Return bitDelivMode
            End Get
            Set(ByVal Value As Integer)
                bitDelivMode = Value
            End Set
        End Property
        Public Property EDelivMode() As String
            Get
                Return strEDelivMode
            End Get
            Set(ByVal Value As String)
                strEDelivMode = Value
            End Set
        End Property
        Public Property EDelivTSAddr() As String
            Get
                Return strEDelivTSAddr
            End Get
            Set(ByVal Value As String)
                strEDelivTSAddr = Value
            End Set
        End Property
        Public Property EmailReplyAddress() As String
            Get
                Return strEmailReplyAddress
            End Get
            Set(ByVal Value As String)
                strEmailReplyAddress = Value
            End Set
        End Property
        Public Property ExpiryDate() As String
            Get
                Return strExpiryDate
            End Get
            Set(ByVal Value As String)
                strExpiryDate = Value
            End Set
        End Property
        Public Property InternalRefNumber() As String
            Get
                Return strInternalRefNumber
            End Get
            Set(ByVal Value As String)
                strInternalRefNumber = Value
            End Set
        End Property
        Public Property ItemType() As Integer
            Get
                Return intItemType
            End Get
            Set(ByVal Value As Integer)
                intItemType = Value
            End Set
        End Property
        Public Property LoanTypeID() As Integer
            Get
                Return intLoanTypeID
            End Get
            Set(ByVal Value As Integer)
                intLoanTypeID = Value
            End Set
        End Property
        Public Property MaxCost() As Double
            Get
                Return dbMaxCost
            End Get
            Set(ByVal Value As Double)
                dbMaxCost = Value
            End Set
        End Property
        Public Property NeedBeforeDate() As String
            Get
                Return strNeedBeforeDate
            End Get
            Set(ByVal Value As String)
                strNeedBeforeDate = Value
            End Set
        End Property
        Public Property PatronID() As String
            Get
                Return strPatronID
            End Get
            Set(ByVal Value As String)
                strPatronID = Value
            End Set
        End Property
        Public Property PatronName() As String
            Get
                Return strPatronName
            End Get
            Set(ByVal Value As String)
                strPatronName = Value
            End Set
        End Property
        Public Property PatronStatus() As String
            Get
                Return strPatronStatus
            End Get
            Set(ByVal Value As String)
                strPatronStatus = Value
            End Set
        End Property
        Public Property PaymentProvided() As Integer
            Get
                Return bitPaymentProvided
            End Get
            Set(ByVal Value As Integer)
                bitPaymentProvided = Value
            End Set
        End Property
        Public Property PaymentType() As Integer
            Get
                Return intPaymentType
            End Get
            Set(ByVal Value As Integer)
                intPaymentType = Value
            End Set
        End Property
        Public Property Priority() As Integer
            Get
                Return intPriority
            End Get
            Set(ByVal Value As Integer)
                intPriority = Value
            End Set
        End Property
        Public Property ReceivedDate() As String
            Get
                Return strReceivedDate
            End Get
            Set(ByVal Value As String)
                strReceivedDate = Value
            End Set
        End Property
        Public Property ReciprocalAgreement() As Integer
            Get
                Return bitReciprocalAgreement
            End Get
            Set(ByVal Value As Integer)
                bitReciprocalAgreement = Value
            End Set
        End Property
        Public Property Renewals() As Integer
            Get
                Return intRenewals
            End Get
            Set(ByVal Value As Integer)
                intRenewals = Value
            End Set
        End Property
        Public Property RequestDate() As String
            Get
                Return strRequestDate
            End Get
            Set(ByVal Value As String)
                strRequestDate = Value
            End Set
        End Property
        Public Property RequestIDCode() As String
            Get
                Return strRequestID
            End Get
            Set(ByVal Value As String)
                strRequestID = Value
            End Set
        End Property
        Public Property RespondDate() As String
            Get
                Return strRespondDate
            End Get
            Set(ByVal Value As String)
                strRespondDate = Value
            End Set
        End Property
        Public Property ReturnedDate() As String
            Get
                Return strReturnedDate
            End Get
            Set(ByVal Value As String)
                strReturnedDate = Value
            End Set
        End Property
        Public Property ReturnLocID() As Integer
            Get
                Return intReturnLocID
            End Get
            Set(ByVal Value As Integer)
                intReturnLocID = Value
            End Set
        End Property
        Public Property ShippedDate() As String
            Get
                Return strShippedDate
            End Get
            Set(ByVal Value As String)
                strShippedDate = Value
            End Set
        End Property
        Public Property IssueID() As String
            Get
                Return strIssueID
            End Get
            Set(ByVal Value As String)
                strIssueID = Value
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
        Public Property ItemID() As Integer
            Get
                Return intItemID
            End Get
            Set(ByVal Value As Integer)
                intItemID = Value
            End Set
        End Property
        Public Property Title() As String
            Get
                Return strTitle
            End Get
            Set(ByVal Value As String)
                strTitle = Value
            End Set
        End Property
        Public Property TransportationModeID() As Integer
            Get
                Return intTransportationModeID
            End Get
            Set(ByVal Value As Integer)
                intTransportationModeID = Value
            End Set
        End Property
        Public Property WillPayFee() As Integer
            Get
                Return bitWillPayFee
            End Get
            Set(ByVal Value As Integer)
                bitWillPayFee = Value
            End Set
        End Property
        Public Property BoolSQL() As String
            Get
                Return strBoolSQL
            End Get
            Set(ByVal Value As String)
                strBoolSQL = Value
            End Set
        End Property
        Public Property IDs() As String
            Get
                Return strIDs
            End Get
            Set(ByVal Value As String)
                strIDs = Value
            End Set
        End Property
        ' Return value property
        Public ReadOnly Property EncodeOk() As Boolean
            Get
                Return blnEncodeOk
            End Get
        End Property
#End Region

        ' ***********************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' ***********************************************************************************************

        ' Initialize method
        ' Purpose: Init all neccessary objects
        Public Sub Initialize()
            Try

                ' Init objBCSP object
                objBCSP.DBServer = strDBServer
                objBCSP.InterfaceLanguage = strInterfaceLanguage
                objBCSP.ConnectionString = strConnectionString
                Call objBCSP.Initialize()

                ' Init objBCDBS object
                objBCDBS.DBServer = strDBServer
                objBCDBS.InterfaceLanguage = strInterfaceLanguage
                objBCDBS.ConnectionString = strConnectionString
                Call objBCDBS.Initialize()

                ' Init objDILLInRequest object
                objDILLInRequest.DBServer = strDBServer
                objDILLInRequest.ConnectionString = strConnectionString
                Call objDILLInRequest.Initialize()

                ' Init objBCTemplate object
                objBCTemplate.DBServer = strDBServer
                objBCTemplate.ConnectionString = strConnectionString
                objBCTemplate.InterfaceLanguage = strInterfaceLanguage
                Call objBCTemplate.Initialize()

                ' Init objBILLLib object
                objBILLLib.DBServer = strDBServer
                objBILLLib.ConnectionString = strConnectionString
                objBILLLib.InterfaceLanguage = strInterfaceLanguage
                Call objBILLLib.Initialize()

                ' Init objBCSP object
                objBCSP.DBServer = strDBServer
                objBCSP.InterfaceLanguage = strInterfaceLanguage
                objBCSP.ConnectionString = strConnectionString
                Call objBCSP.Initialize()

                Call GetSysPara()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Sub InitVariables()
            ' Note :     bit format: -1 : no update, >=0 : >=0
            '      Money,int format: -2 : null, -1 : no update, >=0 : >=0
            '     String format: "": no update, "NULL" : NULL, <>NULL : <>NULL

            intRequesterID = -1
            strTransactionDate = ""
            strNote = ""
            intAPDUType = -1
            intReasonID = -1
            strProvidedDate = ""
            strResponderSpecReason = ""
            intSendShipped = -1
            intSendCheckedIn = -1
            intSendReceived = -1
            intSendReturned = -1
            intTRE = -1
            intMedium = -1
            dbCost = -1
            strCurrencyCode1 = ""
            bitAnswer = -1
            strDueDate = ""
            bitRenewable = -1
            bitAlert = -1
            intServiceType = -1
            strLocation = ""
            intCopyrightCompliance = -1
            strReturnedVia = ""
            dbInsuredForCost = -1
            strCurrencyCode2 = ""
            dbReturnInsuranceCost = -1
            strCurrencyCode3 = ""

            strBarcode = ""
            strCancelledDate = ""
            intChargeableUnits = -1
            strCheckedInDate = ""
            strCheckedOutDate = ""
            strCurrencyCode = ""
            intDelivConditionID = -1
            bitDelivMode = -1
            strEDelivMode = ""
            strEDelivTSAddr = ""
            strEmailReplyAddress = ""
            strExpiryDate = ""
            strInternalRefNumber = ""
            intItemType = -1
            intLoanTypeID = -1
            dbMaxCost = -1
            strNeedBeforeDate = ""
            strPatronID = ""
            strPatronName = ""
            strPatronStatus = ""
            bitPaymentProvided = -1
            intPaymentType = -1
            intPriority = -1
            strReceivedDate = ""
            bitReciprocalAgreement = -1
            intRenewals = -1
            strRequestDate = ""
            strRequestID = ""
            strRespondDate = ""
            strReturnedDate = ""
            intReturnLocID = -1
            strShippedDate = ""
            strIssueID = ""
            intStatus = -1
            intItemID = -1
            strTitle = ""
            intTransportationModeID = -1
            bitWillPayFee = -1
            strBoolSQL = "1=1"
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

        ' SetValueVariablesB2D method
        Private Sub SetValueVariablesB2D()
            objDILLInRequest.ILLID = intILLID
            objDILLInRequest.RequesterID = intRequesterID
            objDILLInRequest.TransactionDate = objBCDBS.ConvertDateBack(strTransactionDate)
            objDILLInRequest.Note = objBCSP.ConvertItBack(strNote)
            objDILLInRequest.APDUType = intAPDUType
            objDILLInRequest.ReasonID = intReasonID
            objDILLInRequest.ProvidedDate = objBCDBS.ConvertDateBack(strProvidedDate)
            objDILLInRequest.ResponderSpecReason = objBCSP.ConvertItBack(strResponderSpecReason)
            objDILLInRequest.SendShipped = intSendShipped
            objDILLInRequest.SendCheckedIn = intSendCheckedIn
            objDILLInRequest.SendReceived = intSendReceived
            objDILLInRequest.SendReturned = intSendReturned
            objDILLInRequest.TRE = intTRE
            objDILLInRequest.Medium = intMedium
            objDILLInRequest.Cost = dbCost
            objDILLInRequest.CurrencyCode1 = objBCSP.ConvertItBack(strCurrencyCode1)
            objDILLInRequest.Answer = bitAnswer
            objDILLInRequest.DueDate = objBCDBS.ConvertDateBack(strDueDate)
            objDILLInRequest.Renewable = bitRenewable
            objDILLInRequest.Alert = bitAlert
            objDILLInRequest.ServiceType = intServiceType
            objDILLInRequest.Location = objBCSP.ConvertItBack(strLocation)
            objDILLInRequest.CopyrightCompliance = intCopyrightCompliance
            objDILLInRequest.ReturnedVia = objBCSP.ConvertItBack(strReturnedVia)
            objDILLInRequest.InsuredForCost = dbInsuredForCost
            objDILLInRequest.CurrencyCode2 = objBCSP.ConvertItBack(strCurrencyCode2)
            objDILLInRequest.ReturnInsuranceCost = dbReturnInsuranceCost
            objDILLInRequest.CurrencyCode3 = objBCSP.ConvertItBack(strCurrencyCode3)

            objDILLInRequest.Barcode = objBCSP.ConvertItBack(strBarcode)
            objDILLInRequest.CancelledDate = objBCDBS.ConvertDateBack(strCancelledDate)
            objDILLInRequest.ChargeableUnits = intChargeableUnits
            objDILLInRequest.CheckedInDate = objBCDBS.ConvertDateBack(strCheckedInDate)
            objDILLInRequest.CheckedOutDate = objBCDBS.ConvertDateBack(strCheckedOutDate)
            objDILLInRequest.CurrencyCode = objBCSP.ConvertItBack(strCurrencyCode)
            objDILLInRequest.DelivConditionID = intDelivConditionID
            objDILLInRequest.DelivMode = bitDelivMode
            objDILLInRequest.EDelivMode = objBCSP.ConvertItBack(strEDelivMode)
            objDILLInRequest.EDelivTSAddr = objBCSP.ConvertItBack(strEDelivTSAddr)
            objDILLInRequest.EmailReplyAddress = objBCSP.ConvertItBack(strEmailReplyAddress)
            objDILLInRequest.ExpiryDate = objBCDBS.ConvertDateBack(strExpiryDate)
            objDILLInRequest.InternalRefNumber = objBCSP.ConvertItBack(strInternalRefNumber)
            objDILLInRequest.ItemType = intItemType
            objDILLInRequest.LoanTypeID = intLoanTypeID
            objDILLInRequest.MaxCost = dbMaxCost
            objDILLInRequest.NeedBeforeDate = objBCDBS.ConvertDateBack(strNeedBeforeDate)
            objDILLInRequest.PatronID = strPatronID
            objDILLInRequest.PatronName = objBCSP.ConvertItBack(strPatronName)
            objDILLInRequest.PatronStatus = objBCSP.ConvertItBack(strPatronStatus)
            objDILLInRequest.PaymentProvided = bitPaymentProvided
            objDILLInRequest.PaymentType = intPaymentType
            objDILLInRequest.Priority = intPriority
            objDILLInRequest.ReceivedDate = objBCDBS.ConvertDateBack(strReceivedDate)
            objDILLInRequest.ReciprocalAgreement = bitReciprocalAgreement
            objDILLInRequest.Renewals = intRenewals
            objDILLInRequest.RequestDate = objBCDBS.ConvertDateBack(strRequestDate)
            objDILLInRequest.RequestIDCode = strRequestID
            objDILLInRequest.RespondDate = objBCDBS.ConvertDateBack(strRespondDate)
            objDILLInRequest.ReturnedDate = objBCDBS.ConvertDateBack(strReturnedDate)
            objDILLInRequest.ReturnLocID = intReturnLocID
            objDILLInRequest.ShippedDate = objBCDBS.ConvertDateBack(strShippedDate)
            objDILLInRequest.IssueID = strIssueID
            objDILLInRequest.Status = intStatus
            objDILLInRequest.ItemID = intItemID
            objDILLInRequest.Title = objBCSP.ConvertItBack(strTitle)
            objDILLInRequest.TransportationModeID = intTransportationModeID
            objDILLInRequest.WillPayFee = bitWillPayFee
            objDILLInRequest.BoolSQL = strBoolSQL
        End Sub

        Public Function GetILLInRequestNum(ByVal lngTopNum As Long, ByRef lngTotalRec As Long, ByRef lngCurrentPos As Long) As DataTable
            Try
                objDILLInRequest.ILLID = intILLID
                GetILLInRequestNum = objBCDBS.ConvertTable(objDILLInRequest.GetILLInRequestNum(lngTopNum, lngTotalRec, lngCurrentPos))
                intErrorCode = objDILLInRequest.ErrorCode
                strErrorMsg = objDILLInRequest.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetIRInfor() As DataTable
            Try
                objDILLInRequest.ILLID = intILLID
                GetIRInfor = objBCDBS.ConvertTable(objDILLInRequest.GetIRInfor)
                intErrorCode = objDILLInRequest.ErrorCode
                strErrorMsg = objDILLInRequest.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetIllResponse() As DataTable
            Try
                objDILLInRequest.IDs = strIDs
                GetIllResponse = objBCDBS.ConvertTable(objDILLInRequest.GetIllResponse)
                intErrorCode = objDILLInRequest.ErrorCode
                strErrorMsg = objDILLInRequest.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetIRCancelReq() As DataTable
            Try
                objDILLInRequest.ILLID = intILLID
                objDILLInRequest.APDUType = intAPDUType
                GetIRCancelReq = objBCDBS.ConvertTable(objDILLInRequest.GetIRCancelReq)
                intErrorCode = objDILLInRequest.ErrorCode
                strErrorMsg = objDILLInRequest.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try

        End Function

        Public Function InsertIRequestLog() As Integer
            Try
                Call SetValueVariablesB2D()
                InsertIRequestLog = objDILLInRequest.InsertIRequestLog()
                intErrorCode = objDILLInRequest.ErrorCode
                strErrorMsg = objDILLInRequest.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Sub InsertIRequestDenied()
            Try
                objDILLInRequest.ILLID = intILLID
                objDILLInRequest.RequestDate = objBCDBS.ConvertDateBack(strRequestDate)
                objDILLInRequest.RequesterID = intRequesterID
                objDILLInRequest.ReasonID = intReasonID
                objDILLInRequest.RespondDate = objBCDBS.ConvertDateBack(strRespondDate)
                objDILLInRequest.Note = objBCSP.ConvertItBack(strNote)
                Call objDILLInRequest.InsertIRequestDenied()
                intErrorCode = objDILLInRequest.ErrorCode
                strErrorMsg = objDILLInRequest.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try

        End Sub

        Public Function GetIRHistoryInfor(Optional ByVal blHasMail As Boolean = False) As DataTable
            Try

                objDILLInRequest.ILLID = intILLID
                objDILLInRequest.Alert = -1
                If blHasMail Then
                    objDILLInRequest.Alert = 1
                End If
                GetIRHistoryInfor = objBCDBS.ConvertTable(objDILLInRequest.GetIRHistoryInfor)
                intErrorCode = objDILLInRequest.ErrorCode
                strErrorMsg = objDILLInRequest.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function UpdateIR() As Integer
            Try
                Call SetValueVariablesB2D()
                UpdateIR = objDILLInRequest.UpdateIR
                intErrorCode = objDILLInRequest.ErrorCode
                strErrorMsg = objDILLInRequest.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function CreateIR() As Integer
            Try
                Call SetValueVariablesB2D()
                CreateIR = objDILLInRequest.CreateIR
                intErrorCode = objDILLInRequest.ErrorCode
                strErrorMsg = objDILLInRequest.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function DeleteIR() As Integer
            Try
                objDILLInRequest.ILLID = intILLID
                DeleteIR = objDILLInRequest.DeleteIR()
            Catch ex As Exception
                strerrormsg = ex.Message
            End Try
        End Function

        Public Sub ChangeFolder()
            Try
                objDILLInRequest.ILLID = intILLID
                objDILLInRequest.ChangeFolder()
                strErrorMsg = objDILLInRequest.ErrorMsg
                intErrorCode = objDILLInRequest.ErrorCode
            Catch ex As Exception
                strerrormsg = ex.Message
            End Try
        End Sub

        Public Function PackageIR(ByVal intID As Integer) As String
            Dim tblDoc As New DataTable, tblRequest As New DataTable, tblRequester As New DataTable, tblTemplate As New DataTable
            'Dim objTemplate As New TVCOMLib.LibolTemplate
            Dim objFields As Object, objData As Object
            Dim strOutMsg As Object
            Dim inti As Integer
            Dim strContentTemp As String = ""
            Try
                ' Get Template 
                objBCTemplate.TemplateID = intTemplateID
                objBCTemplate.TemplateType = 12
                tblTemplate = objBCTemplate.GetTemplate
                If Not tblTemplate Is Nothing Then
                    If tblTemplate.Rows.Count > 0 Then
                        'objTemplate.Template = objBCSP.ToUTF8(tblTemplate.Rows(0).Item("Content"))
                        'objFields = objTemplate.Fields
                        strContentTemp = objBCSP.ToUTF8(tblTemplate.Rows(0).Item("Content"))
                        objFields = objBCTemplate.getArrayFromTemplate(strContentTemp)
                    End If
                End If
                ' Item information
                tblDoc = objDILLInRequest.PackageIR(intID, "DOC")
                ' Request information
                tblRequest = objDILLInRequest.PackageIR(intID, "REQUEST")
                ' Requester information
                tblRequester = objDILLInRequest.PackageIR(intID, "REQUESTER")
                If Not tblDoc Is Nothing And Not tblRequest Is Nothing And Not tblRequester Is Nothing Then
                    If tblDoc.Rows.Count > 0 And tblRequest.Rows.Count > 0 And tblRequester.Rows.Count > 0 Then
                        If Not IsNothing(objFields) AndAlso IsArray(objFields) Then
                            ReDim objData(UBound(objFields))
                            For inti = LBound(objFields) To UBound(objFields)
                                objData(inti) = " "
                                Select Case objFields(inti)
                                    Case "CALLNUMBER"
                                        If Not IsDBNull(tblDoc.Rows(0).Item("CallNumber")) Then
                                            objData(inti) = tblDoc.Rows(0).Item("CallNumber") & Chr(9)
                                        End If
                                    Case "TITLE"
                                        If Not IsDBNull(tblDoc.Rows(0).Item("Title")) Then
                                            objData(inti) = tblDoc.Rows(0).Item("Title") & Chr(9)
                                        End If
                                    Case "AUTHOR"
                                        If Not IsDBNull(tblDoc.Rows(0).Item("Author")) Then
                                            objData(inti) = tblDoc.Rows(0).Item("Author") & Chr(9)
                                        End If
                                    Case "ADDRESSOFPUBLISHER"
                                        If Not IsDBNull(tblDoc.Rows(0).Item("PlaceOfPub")) Then
                                            objData(inti) = tblDoc.Rows(0).Item("PlaceOfPub") & Chr(9)
                                        End If
                                    Case "PUBLISHER"
                                        If Not IsDBNull(tblDoc.Rows(0).Item("Publisher")) Then
                                            objData(inti) = tblDoc.Rows(0).Item("Publisher") & Chr(9)
                                        End If
                                    Case "SERIESTITLENUMBER"
                                        If Not IsDBNull(tblDoc.Rows(0).Item("SeriesTitleNumber")) Then
                                            objData(inti) = tblDoc.Rows(0).Item("SeriesTitleNumber") & Chr(9)
                                        End If
                                    Case "VOLUMEISSUE"
                                        If Not IsDBNull(tblDoc.Rows(0).Item("VolumeIssue")) Then
                                            objData(inti) = tblDoc.Rows(0).Item("VolumeIssue") & Chr(9)
                                        End If
                                    Case "PUBLISHEDDATE"
                                        If Not IsDBNull(tblDoc.Rows(0).Item("PubDate")) Then
                                            objData(inti) = tblDoc.Rows(0).Item("PubDate") & Chr(9)
                                        End If
                                    Case "EDITION"
                                        If Not IsDBNull(tblDoc.Rows(0).Item("Edition")) Then
                                            objData(inti) = tblDoc.Rows(0).Item("Edition") & Chr(9)
                                        End If
                                    Case "COMPONENTPUBDATE"
                                        If Not IsDBNull(tblDoc.Rows(0).Item("ComponentPubDate")) Then
                                            objData(inti) = tblDoc.Rows(0).Item("ComponentPubDate") & Chr(9)
                                        End If
                                    Case "PUBLISHEDYEAR"
                                        If Not IsDBNull(tblDoc.Rows(0).Item("PubDate")) Then
                                            objData(inti) = tblDoc.Rows(0).Item("PubDate") & Chr(9)
                                        End If
                                    Case "ARTICLEAUTHOR"
                                        If Not IsDBNull(tblDoc.Rows(0).Item("ArticleAuthor")) Then
                                            objData(inti) = tblDoc.Rows(0).Item("ArticleAuthor") & Chr(9)
                                        End If
                                    Case "ARTICLETITLE"
                                        If Not IsDBNull(tblDoc.Rows(0).Item("ArticleTitle")) Then
                                            objData(inti) = tblDoc.Rows(0).Item("ArticleTitle") & Chr(9)
                                        End If
                                    Case "PAGINATION"
                                        If Not IsDBNull(tblDoc.Rows(0).Item("Pagination")) Then
                                            objData(inti) = tblDoc.Rows(0).Item("Pagination") & Chr(9)
                                        End If
                                    Case "NATIONALBIBNUMBER"
                                        If Not IsDBNull(tblDoc.Rows(0).Item("NationalBibNumber")) Then
                                            objData(inti) = tblDoc.Rows(0).Item("NationalBibNumber") & Chr(9)
                                        End If
                                    Case "ISBN"
                                        If Not IsDBNull(tblDoc.Rows(0).Item("ISBN")) Then
                                            objData(inti) = tblDoc.Rows(0).Item("ISBN") & Chr(9)
                                        End If
                                    Case "ISSN"
                                        If Not IsDBNull(tblDoc.Rows(0).Item("ISSN")) Then
                                            objData(inti) = tblDoc.Rows(0).Item("ISSN") & Chr(9)
                                        End If
                                    Case "SYSTEMNUMBER"
                                        If Not IsDBNull(tblDoc.Rows(0).Item("SystemNumber")) Then
                                            objData(inti) = tblDoc.Rows(0).Item("SystemNumber") & Chr(9)
                                        End If
                                    Case "SPONSORINGBODY"
                                        If Not IsDBNull(tblDoc.Rows(0).Item("SponsoringBody")) Then
                                            objData(inti) = tblDoc.Rows(0).Item("SponsoringBody") & Chr(9)
                                        End If
                                    Case "DELIVNAME"
                                        If Not IsDBNull(tblRequester.Rows(0).Item("PostDelivName")) Then
                                            objData(inti) = tblRequester.Rows(0).Item("PostDelivName") & Chr(9)
                                        End If
                                    Case "DELIVADDRESS2"
                                        If Not IsDBNull(tblRequester.Rows(0).Item("PostDelivXAddress")) Then
                                            objData(inti) = tblRequester.Rows(0).Item("PostDelivXAddress") & Chr(9)
                                        End If
                                    Case "DELIVADDRESS1"
                                        If Not IsDBNull(tblRequester.Rows(0).Item("PostDelivName")) Then
                                            objData(inti) = tblRequester.Rows(0).Item("PostDelivName") & Chr(9)
                                        End If
                                    Case "DELIVSTREET"
                                        If Not IsDBNull(tblRequester.Rows(0).Item("PostDelivStreet")) Then
                                            objData(inti) = tblRequester.Rows(0).Item("PostDelivStreet") & Chr(9)
                                        End If
                                    Case "DELIVBOX"
                                        If Not IsDBNull(tblRequester.Rows(0).Item("PostDelivBox")) Then
                                            objData(inti) = tblRequester.Rows(0).Item("PostDelivBox") & Chr(9)
                                        End If
                                    Case "DELIVCITY"
                                        If Not IsDBNull(tblRequester.Rows(0).Item("PostDelivCity")) Then
                                            objData(inti) = tblRequester.Rows(0).Item("PostDelivCity") & Chr(9)
                                        End If
                                    Case "DELIVREGION"
                                        If Not IsDBNull(tblRequester.Rows(0).Item("PostDelivRegion")) Then
                                            objData(inti) = tblRequester.Rows(0).Item("PostDelivRegion") & Chr(9)
                                        End If
                                    Case "DELIVCOUNTRY"
                                        If Not IsDBNull(tblRequester.Rows(0).Item("DisplayEntry")) Then
                                            objData(inti) = tblRequester.Rows(0).Item("DisplayEntry") & Chr(9)
                                        End If
                                    Case "DELIVCODE"
                                        If Not IsDBNull(tblRequester.Rows(0).Item("PostDelivCode")) Then
                                            objData(inti) = tblRequester.Rows(0).Item("PostDelivCode") & Chr(9)
                                        End If
                                    Case "SHIPPEDDATE"
                                        If Not IsDBNull(tblRequest.Rows(0).Item("ShippedDate")) Then
                                            objData(inti) = tblRequest.Rows(0).Item("ShippedDate") & Chr(9)
                                        End If
                                    Case "DUEDATE"
                                        If Not IsDBNull(tblRequest.Rows(0).Item("DueDate")) Then
                                            objData(inti) = tblRequest.Rows(0).Item("DueDate") & Chr(9)
                                        End If
                                    Case "DELIVCONDITION"
                                        If Not IsDBNull(tblRequest.Rows(0).Item("Reason_Viet")) Then
                                            objData(inti) = tblRequest.Rows(0).Item("Reason_Viet") & Chr(9)
                                        End If
                                    Case "PATRONNAME"
                                        If Not IsDBNull(tblRequest.Rows(0).Item("PatronName")) Then
                                            objData(inti) = tblRequest.Rows(0).Item("PatronName") & Chr(9)
                                        End If
                                    Case "PATRONCODE"
                                        If Not IsDBNull(tblRequest.Rows(0).Item("PatronID")) Then
                                            objData(inti) = tblRequest.Rows(0).Item("PatronID") & Chr(9)
                                        End If
                                    Case "REQUESTCODE"
                                        If Not IsDBNull(tblRequest.Rows(0).Item("RequestID")) Then
                                            objData(inti) = tblRequest.Rows(0).Item("RequestID") & Chr(9)
                                        End If
                                    Case "ITEMCODE"
                                        If Not IsDBNull(tblDoc.Rows(0).Item("SystemNumber")) Then
                                            objData(inti) = tblDoc.Rows(0).Item("SystemNumber") & Chr(9)
                                        End If
                                    Case "DD"
                                        objData(inti) = Day(Now) & Chr(9)
                                    Case "MM"
                                        objData(inti) = Month(Now) & Chr(9)
                                    Case "YYYY"
                                        objData(inti) = Year(Now) & Chr(9)
                                    Case Else
                                        objData(inti) = " " & Chr(9)
                                End Select
                                objData(inti) = objBCSP.ToUTF8(objData(inti))
                                strContentTemp = Replace(strContentTemp, "<$" & objFields(inti) & "$>", objData(inti))
                            Next
                        End If
                        
                        'strOutMsg = objTemplate.Generate(objData)
                        strOutMsg = strContentTemp
                    End If
                End If
                PackageIR = objBCSP.ToUTF8Back(strOutMsg)
            Catch ex As Exception
                strerrormsg = ex.Message
            Finally
                'objTemplate = Nothing
            End Try
        End Function

        ' GetILLRequestItems method
        Public Function GetILLRequestItems(ByVal intID As Integer, ByVal intRequestType As Integer) As DataTable
            Try
                GetILLRequestItems = objBCDBS.ConvertTable(objDILLInRequest.GetILLRequestItems(intID, intRequestType))
                intErrorCode = objDILLInRequest.ErrorCode
                strErrorMsg = objDILLInRequest.ErrorMsg
            Catch ex As Exception
                strerrormsg = ex.Message
            End Try
        End Function

        Public Function GetEmailInfor(ByVal strServerPath As String, ByVal RecipientID As Integer, ByVal strContent As String, ByRef strMailFrom As String, ByRef strMailTo As String, ByRef strContentOut As String) As Boolean
            Dim tblILLLib As New DataTable
            Dim tblMail As DataTable
            Dim strFileName As String
            Dim intEnCode As Integer
            Dim strOut As String = ""

            Try
                blnEncodeOk = True

                ' Get Source Email Address
                objBILLLib.LibID = 0
                tblILLLib = objBILLLib.GetLib(1)

                If Not tblILLLib Is Nothing Then
                    If tblILLLib.Rows.Count > 0 Then
                        strMailFrom = tblILLLib.Rows(0).Item("EmailReplyAddress").ToString.Trim
                    End If
                End If

                ' Get Destination Email Address
                objBILLLib.LibID = RecipientID
                tblMail = objBILLLib.GetLib(-1)
                If Not tblMail Is Nothing AndAlso tblMail.Rows.Count > 0 Then

                    If tblMail.Rows(0).Item("EncodingScheme").ToString.Trim = "" Then
                        intEnCode = 0
                    Else
                        intEnCode = tblMail.Rows(0).Item("EncodingScheme").ToString.Trim
                    End If
                    strMailTo = tblMail.Rows(0).Item("EmailReplyAddress").ToString.Trim

                    ' EnCode to BASE 64 or not
                    If intEnCode = 1 Then
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

                    If Not Trim(strContent) = "" Then
                        strContentOut = strContent
                        Return True ' ok
                    Else
                        strerrormsg = "The body is incorrect"
                        Return False ' not ok
                    End If
                End If
            Catch ex As Exception
                strerrormsg = ex.Message
                Return False ' not ok
            End Try
        End Function

        ' StatusXmlRecord method
        Function StatusXmlRecord(ByVal Note As String) As String
            Dim Str As String
            Call GeneralParams()
            Str = CreateHeader("STATUS")
            Str = Str & "<note>" & objBCSP.ConvertItBack(Note) & "</note>" & vbCrLf
            Str = Str & "</illapdu>" & vbCrLf
            StatusXmlRecord = Str
        End Function

        ' RecallXmlRecord method
        Function RecallXmlRecord(ByVal Note As String) As String
            Dim Str
            Call GeneralParams()
            Str = CreateHeader("RECALL")
            Str = Str & "<responder-note>" & objBCSP.ConvertItBack(Note) & "</responder-note>" & vbCrLf
            Str = Str & "</illapdu>" & vbCrLf
            RecallXmlRecord = Str
        End Function

        ' ChkdinXmlRecord method
        Function ChkdinXmlRecord(ByVal CheckedInDate As String, ByVal Note As String) As String
            Dim Str As String
            CheckedInDate = ToISODate(CheckedInDate)
            Call GeneralParams()
            Str = CreateHeader("CHKDIN")
            Str = Str & "<date-checked-in>" & CheckedInDate & "</date-checked-in>" & vbCrLf
            Str = Str & "<responder-note>" & objBCSP.ConvertItBack(Note) & "</responder-note>" & vbCrLf
            Str = Str & "</illapdu>" & vbCrLf
            ChkdinXmlRecord = Str
        End Function

        ' LostitXmlRecord method
        Function LostitXmlRecord(ByVal Note As String) As String
            Dim Str As String
            Call GeneralParams()
            Str = CreateHeader("LOSTIT")
            Str = Str & "<note>" & objBCSP.ConvertItBack(Note) & "</note>" & vbCrLf
            Str = Str & "</illapdu>" & vbCrLf
            LostitXmlRecord = Str
        End Function

        ' MessagXmlRecord method
        Function MessagXmlRecord(ByVal Note As String) As String
            Dim Str As String
            Call GeneralParams()
            Str = CreateHeader("MESSAG")
            Str = Str & "<note>" & objBCSP.ConvertItBack(Note) & "</note>" & vbCrLf
            Str = Str & "</illapdu>" & vbCrLf
            MessagXmlRecord = Str
        End Function

        Function ToISODate(ByVal strInDate As String) As String
            Dim strRet As String
            Dim strTime As String
            Dim strDate As String
            Dim strTypeShow As String

            If strInDate = "NULL" Then
                strInDate = ""
            End If

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

        ' Generate ServiceDate and ServiceTime
        Sub GeneralParams()
            Dim tblTemp As DataTable

            strProtocolVerNum = 1
            strSubTransactQualifier = "LIBOLILL"
            strTransactGroupQualifier = ""
            objBCDBS.SQLStatement = "Select LibrarySymbol,LibraryName FROM ILL_LIBRARIES WHERE LocalLib=1"
            tblTemp = objBCDBS.RetrieveItemInfor
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                strResponderSymbol = tblTemp.Rows(0).Item("LibrarySymbol")
                strResponderName = tblTemp.Rows(0).Item("LibraryName")
            End If
            tblTemp = Nothing
            objBCDBS.SQLStatement = "Select B.LibrarySymbol,B.LibraryName,A.RequestID FROM ILL_INCOMING_REQUESTS A JOIN ILL_LIBRARIES B ON B.ID = A.RequesterID WHERE A.ID=" & intILLID
            tblTemp = objBCDBS.RetrieveItemInfor
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                strRequestID = tblTemp.Rows(0).Item("RequestID")
                strRequesterSymbol = tblTemp.Rows(0).Item("LibrarySymbol")
                strRequesterName = tblTemp.Rows(0).Item("LibraryName")
            End If
            strServiceDate = CStr(Year(Now)) & CStr(Month(Now)).PadLeft(2, "0") & CStr(Day(Now)).PadLeft(2, "0")
            strServiceTime = CStr(Hour(Now)).PadLeft(2, "0") & CStr(Minute(Now)).PadLeft(2, "0") & CStr(Second(Now)).PadLeft(2, "0")
        End Sub

        ' Generate XML Header method
        Public Function CreateHeader(ByVal APDU) As String
            Dim strTemp As String
            'Str = "<?xml version=""1.0"" encoding=""utf-8""?>" & vbCrLf
            strTemp = "<?xml version=""1.0""?>" & vbCrLf
            strTemp = strTemp & "<illapdu type=""" & APDU & """ xmlns=""www.GREENHOUSE.com.vn/libol"">" & vbCrLf
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

        ' Overdue XML Record method
        Function OverduXmlRecord(ByVal Renewable As String, ByVal DueDate As String, ByVal Note As String) As String
            Dim Str As String
            DueDate = ToISODate(DueDate)
            Call GeneralParams()
            Str = CreateHeader("OVERDU")
            Str = Str & "<date-due>" & vbCrLf
            Str = Str & "<date-due-field>" & DueDate & "</date-due-field>" & vbCrLf
            Str = Str & "<renewable>" & Renewable & "</renewable>" & vbCrLf
            Str = Str & "</date-due>" & vbCrLf
            Str = Str & "<responder-note>" & objBCSP.ConvertItBack(Note) & "</responder-note>" & vbCrLf
            Str = Str & "</illapdu>" & vbCrLf
            OverduXmlRecord = Str
        End Function

        ' XML record
        Function CondiXmlRecord(ByVal Condition As String, ByVal ProvidedDate As String, ByVal Note As String) As String
            Dim Str As String
            ProvidedDate = ToISODate(ProvidedDate)
            Call GeneralParams()
            Str = CreateHeader("ILLANS")
            Str = Str & "<transaction-results>1</transaction-results>" & vbCrLf
            Str = Str & "<conditional-results>" & vbCrLf
            Str = Str & "<conditions>" & Condition & "</conditions>" & vbCrLf
            Str = Str & "<date-for-reply>" & ProvidedDate & "</date-for-reply>" & vbCrLf
            Str = Str & "</conditional-results>" & vbCrLf
            Str = Str & "<responder-optional-messages>" & vbCrLf
            Str = Str & "<responder-received>2</responder-received>" & vbCrLf
            Str = Str & "<responder-returned>2</responder-returned>" & vbCrLf
            Str = Str & "<can-send-shipped>1</can-send-shipped>" & vbCrLf
            Str = Str & "<can-send-checked-in>1</can-send-checked-in>" & vbCrLf
            Str = Str & "</responder-optional-messages>" & vbCrLf
            Str = Str & "<responder-note>" & objBCSP.ConvertItBack(Note) & "</responder-note>" & vbCrLf
            Str = Str & "</illapdu>" & vbCrLf
            CondiXmlRecord = Str
        End Function

        ' FillXmlRecord method
        Function FillXmlRecord(ByVal Condition As String, ByVal ProvidedDate As String, ByVal Note As String) As String
            Dim Str As String
            ProvidedDate = ToISODate(ProvidedDate)
            Call GeneralParams()
            Str = CreateHeader("ILLANS")
            Str = Str & "<transaction-results>5</transaction-results>" & vbCrLf
            Str = Str & "<will-supply-results>" & vbCrLf
            Str = Str & "<reason-will-supply>" & Condition & "</reason-will-supply>" & vbCrLf
            Str = Str & "<supply-date>" & ProvidedDate & "</supply-date>" & vbCrLf
            Str = Str & "</will-supply-results>" & vbCrLf
            Str = Str & "<responder-optional-messages>" & vbCrLf
            Str = Str & "<responder-received>2</responder-received>" & vbCrLf
            Str = Str & "<responder-returned>2</responder-returned>" & vbCrLf
            Str = Str & "<can-send-shipped>1</can-send-shipped>" & vbCrLf
            Str = Str & "<can-send-checked-in>1</can-send-checked-in>" & vbCrLf
            Str = Str & "</responder-optional-messages>" & vbCrLf
            Str = Str & "<responder-note>" & objBCSP.ConvertItBack(Note) & "</responder-note>" & vbCrLf
            Str = Str & "</illapdu>" & vbCrLf
            FillXmlRecord = Str
        End Function

        ' UnFillXmlRecord method
        Function UnFillXmlRecord(ByVal Condition As String, ByVal Note As String) As String
            Dim Str As String
            Call GeneralParams()
            Str = CreateHeader("ILLANS")
            Str = Str & "<transaction-results>3</transaction-results>" & vbCrLf
            Str = Str & "<unfilled-results>" & vbCrLf
            Str = Str & "<reason-unfilled>" & Condition & "</reason-unfilled>" & vbCrLf
            Str = Str & "</unfilled-results>" & vbCrLf
            Str = Str & "<responder-optional-messages>" & vbCrLf
            Str = Str & "<responder-received>2</responder-received>" & vbCrLf
            Str = Str & "<responder-returned>2</responder-returned>" & vbCrLf
            Str = Str & "<can-send-shipped>1</can-send-shipped>" & vbCrLf
            Str = Str & "<can-send-checked-in>1</can-send-checked-in>" & vbCrLf
            Str = Str & "</responder-optional-messages>" & vbCrLf
            Str = Str & "<responder-note>" & objBCSP.ConvertItBack(Note) & "</responder-note>" & vbCrLf
            Str = Str & "</illapdu>" & vbCrLf
            UnFillXmlRecord = Str
        End Function

        ' RetryXmlRecord method
        Function RetryXmlRecord(ByVal Condition As String, ByVal ProvidedDate As String, ByVal Note As String) As String
            Dim Str As String
            ProvidedDate = ToISODate(ProvidedDate)
            Call GeneralParams()
            Str = CreateHeader("ILLANS")
            Str = Str & "<transaction-results>2</transaction-results>" & vbCrLf
            Str = Str & "<retry-results>" & vbCrLf
            Str = Str & "<reason-not-available>" & Condition & "</reason-not-available>" & vbCrLf
            Str = Str & "<retry-date>" & ProvidedDate & "</retry-date>" & vbCrLf
            Str = Str & "</retry-results>" & vbCrLf
            Str = Str & "<responder-optional-messages>" & vbCrLf
            Str = Str & "<responder-received>2</responder-received>" & vbCrLf
            Str = Str & "<responder-returned>2</responder-returned>" & vbCrLf
            Str = Str & "<can-send-shipped>1</can-send-shipped>" & vbCrLf
            Str = Str & "<can-send-checked-in>1</can-send-checked-in>" & vbCrLf
            Str = Str & "</responder-optional-messages>" & vbCrLf
            Str = Str & "<responder-note>" & objBCSP.ConvertItBack(Note) & "</responder-note>" & vbCrLf
            Str = Str & "</illapdu>" & vbCrLf
            RetryXmlRecord = Str
        End Function

        ' RenansXmlRecord method
        Function RenansXmlRecord(ByVal Answer As String, ByVal Renewable As String, ByVal DueDate As String, ByVal Note As String) As String
            Dim Str As String
            DueDate = ToISODate(DueDate)
            Call GeneralParams()
            Str = CreateHeader("RENANS")
            Str = Str & "<answer>" & Answer & "</answer>" & vbCrLf
            Str = Str & "<date-due>" & vbCrLf
            Str = Str & "<date-due-field>" & DueDate & "</date-due-field>" & vbCrLf
            Str = Str & "<renewable>" & Renewable & "</renewable>" & vbCrLf
            Str = Str & "</date-due>" & vbCrLf
            Str = Str & "<responder-note>" & objBCSP.ConvertItBack(Note) & "</responder-note>" & vbCrLf
            Str = Str & "</illapdu>" & vbCrLf
            RenansXmlRecord = Str
        End Function

        ' ShipedXmlRecord method
        Public Function ShipedXmlRecord(ByVal strNote As String) As String
            Dim tblAPDU As DataTable
            Dim tblAPDU2 As DataTable
            objDILLInRequest.ILLID = intILLID
            tblAPDU = objBCDBS.ConvertTable(objDILLInRequest.GetInforOfShipMessage)
            tblAPDU2 = objBCDBS.ConvertTable(objDILLInRequest.GetInfoOfLibCountryForShip)
            Dim Str As String
            Dim strDueDate As String = ""
            Dim strShippedDate As String = ""
            If Not IsDBNull(tblAPDU.Rows(0).Item("DD")) Then
                strDueDate = ToISODate(tblAPDU.Rows(0).Item("DD"))
            End If
            If Not IsDBNull(tblAPDU.Rows(0).Item("SD")) Then
                strShippedDate = ToISODate(tblAPDU.Rows(0).Item("SD"))
            End If
            Call GeneralParams()
            Str = CreateHeader("SHIPED")
            'thieu cac the co muc dich bieu thi:
            ''''''''''''''''''''''''''''''''''''''
            'dia chi giao hang
            'Str = Str & "<responder-address>" & vbCrLf
            'PostalAddress dia chi giao nhan / thanh toan
            'Str = Str & "</responder-address>" & vbCrLf
            '''''''''''''''''''''''''''''''''''''''
            'He thong nha cung cap trung gian
            'Str = Str & "<intermediary-id>" & vbCrLf
            'ILL_System_Id
            'Str = Str & "</intermediary-id>" & vbCrLf
            '''''''''''''''''''''''''''''''''''''''
            'He thong nha cung cap
            'Str = Str & "<supplier-id>" & vbCrLf
            'ILL_System_Id
            'Str = Str & "</supplier-id>" & vbCrLf
            '''''''''''''''''''''''''''''''''''''''
            Str = Str & "<client-id>" & vbCrLf
            Str = Str & "<client-name>"
            If Not IsDBNull(tblAPDU.Rows(0).Item("PatronName")) Then
                Str = Str & tblAPDU.Rows(0).Item("PatronName")
            End If
            Str = Str & "</client-name>" & vbCrLf
            Str = Str & "<client-identifier>"
            If Not IsDBNull(tblAPDU.Rows(0).Item("PatronID")) Then
                Str = Str & tblAPDU.Rows(0).Item("PatronID")
            End If
            Str = Str & "</client-identifier>" & vbCrLf
            Str = Str & "<client-status>"
            If Not IsDBNull(tblAPDU.Rows(0).Item("PatronStatus")) Then
                Str = Str & tblAPDU.Rows(0).Item("PatronStatus")
            End If
            Str = Str & "</client-status>" & vbCrLf
            Str = Str & "</client-id>" & vbCrLf
            Str = Str & "<transaction-type>1</transaction-type>" & vbCrLf
            Str = Str & "<shipped-service-type>" & tblAPDU.Rows(0).Item("servicetype") & "</shipped-service-type>" & vbCrLf
            Str = Str & "<responder-optional-messages>" & vbCrLf
            Str = Str & "<responder-received>2</responder-received>" & vbCrLf
            Str = Str & "<responder-returned>2</responder-returned>" & vbCrLf
            Str = Str & "<can-send-shipped>1</can-send-shipped>" & vbCrLf
            Str = Str & "<can-send-checked-in>1</can-send-checked-in>" & vbCrLf
            Str = Str & "</responder-optional-messages>" & vbCrLf
            Str = Str & "<supply-details>" & vbCrLf
            Str = Str & "<date-shipped>" & strShippedDate & "</date-shipped>" & vbCrLf
            Str = Str & "<date-due>" & vbCrLf
            Str = Str & "<date-due-field>" & strDueDate & "</date-due-field>" & vbCrLf
            Str = Str & "<renewable>" & Math.Abs(CInt(tblAPDU.Rows(0).Item("Renewable"))) & "</renewable>" & vbCrLf
            Str = Str & "</date-due>" & vbCrLf
            Str = Str & "<chargeable-units>" & tblAPDU.Rows(0).Item("ChargeableUnits") & "</chargeable-units>" & vbCrLf
            Str = Str & "<cost>" & vbCrLf
            Str = Str & "<currency-code>" & tblAPDU.Rows(0).Item("Currencycode1") & "</currency-code>" & vbCrLf
            Str = Str & "<monetary-value>" & tblAPDU.Rows(0).Item("Cost") & "</monetary-value>" & vbCrLf
            Str = Str & "</cost>" & vbCrLf
            Str = Str & "<shipped-conditions>" & tblAPDU.Rows(0).Item("DelivConditionID") & "</shipped-conditions>" & vbCrLf
            Str = Str & "<physical-delivery>" & tblAPDU.Rows(0).Item("PhysDelivMode") & "</physical-delivery>" & vbCrLf
            Str = Str & "<insured-for>" & vbCrLf
            Str = Str & "<currency-code>" & tblAPDU.Rows(0).Item("CurrencyCode2") & "</currency-code>" & vbCrLf
            Str = Str & "<monetary-value>" & tblAPDU.Rows(0).Item("InsuredForCost") & "</monetary-value>" & vbCrLf
            Str = Str & "</insured-for>" & vbCrLf
            Str = Str & "<return-insurance-require>" & vbCrLf
            Str = Str & "<currency-code>" & tblAPDU.Rows(0).Item("Currencycode3") & "</currency-code>" & vbCrLf
            Str = Str & "<monetary-value>" & tblAPDU.Rows(0).Item("Returninsurancecost") & "</monetary-value>" & vbCrLf
            Str = Str & "</return-insurance-require>" & vbCrLf
            Str = Str & "</supply-details>" & vbCrLf
            Str = Str & "<return-to-address>" & vbCrLf
            If Not IsDBNull(tblAPDU.Rows(0).Item("ReturnLocID")) Then
                tblAPDU2.DefaultView.RowFilter = "ID = " & tblAPDU.Rows(0).Item("ReturnLocID")
                If tblAPDU2.DefaultView.Count > 0 Then
                    Str = Str & "<name-of-person-or-institution>" & vbCrLf
                    If Not IsDBNull(tblAPDU2.DefaultView(0).Item("Address")) Then
                        Str = Str & "<name-of-institution>" & tblAPDU2.DefaultView(0).Item("Address") & "</name-of-institution>" & vbCrLf
                    Else
                        Str = Str & "<name-of-institution>Unknown</name-of-institution>" & vbCrLf
                    End If
                    Str = Str & "</name-of-person-or-institution>" & vbCrLf
                    Str = Str & "<extended-postal-delivery-address>"
                    If Not IsDBNull(tblAPDU2.DefaultView(0).Item("XAddress")) Then
                        Str = Str & tblAPDU2.DefaultView(0).Item("XAddress")
                    End If
                    Str = Str & "</extended-postal-delivery-address>" & vbCrLf
                    Str = Str & "<street-and-number>"
                    If Not IsDBNull(tblAPDU2.DefaultView(0).Item("Street")) Then
                        Str = Str & tblAPDU2.DefaultView(0).Item("Street")
                    End If
                    Str = Str & "</street-and-number>" & vbCrLf
                    Str = Str & "<post-office-box>"
                    If Not IsDBNull(tblAPDU2.DefaultView(0).Item("POBox")) Then
                        Str = Str & tblAPDU2.DefaultView(0).Item("POBox")
                    End If
                    Str = Str & "</post-office-box>" & vbCrLf
                    Str = Str & "<city>"
                    If Not IsDBNull(tblAPDU2.DefaultView(0).Item("City")) Then
                        Str = Str & tblAPDU2.DefaultView(0).Item("City")
                    End If
                    Str = Str & "</city>" & vbCrLf
                    Str = Str & "<region>"
                    If Not IsDBNull(tblAPDU2.DefaultView(0).Item("Region")) Then
                        Str = Str & tblAPDU2.DefaultView(0).Item("Region")
                    End If
                    Str = Str & "</region>" & vbCrLf
                    Str = Str & "<country>"
                    If Not IsDBNull(tblAPDU2.DefaultView(0).Item("DisplayEntry")) Then
                        Str = Str & tblAPDU2.DefaultView(0).Item("DisplayEntry")
                    End If
                    Str = Str & "</country>" & vbCrLf
                    Str = Str & "<postal-code>"
                    If Not IsDBNull(tblAPDU2.DefaultView(0).Item("PostCode")) Then
                        Str = Str & tblAPDU2.DefaultView(0).Item("PostCode")
                    End If
                    Str = Str & "</postal-code>" & vbCrLf
                End If
            End If
            Str = Str & "</return-to-address>" & vbCrLf
            Str = Str & "<responder-note>" & objBCSP.ConvertItBack(strNote) & "</responder-note>" & vbCrLf
            Str = Str & "</illapdu>" & vbCrLf
            tblAPDU = Nothing
            tblAPDU2 = Nothing
            ShipedXmlRecord = Str
        End Function

        ' CnlrepXmlRecord method
        Function CnlrepXmlRecord(ByVal Answer As String, ByVal Note As String)
            Dim Str As String
            Call GeneralParams()
            Str = CreateHeader("CNLREP")
            Str = Str & "<answer>" & Answer & "</answer>" & vbCrLf
            Str = Str & "<responder-note>" & objBCSP.ConvertItBack(Note) & "</responder-note>" & vbCrLf
            Str = Str & "</illapdu>" & vbCrLf
            CnlrepXmlRecord = Str
        End Function

        Public Function GetIRItem() As DataTable
            Try
                objDILLInRequest.ILLID = intILLID
                GetIRItem = objBCDBS.ConvertTable(objDILLInRequest.GetIRItem)
                intErrorCode = objDILLInRequest.ErrorCode
                strErrorMsg = objDILLInRequest.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Sub UpdateIRequestLogCancel()
            Try
                objDILLInRequest.LogID = intLogID
                Call objDILLInRequest.UpdateIRequestLogCancel()
                intErrorCode = objDILLInRequest.ErrorCode
                strErrorMsg = objDILLInRequest.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Sub SetIRItem(ByVal lngItemID As Long, Optional ByVal strIssueID As String = "")
            Try
                objDILLInRequest.ILLID = intILLID
                objDILLInRequest.SetIRItem(lngItemID, strIssueID)
                strErrorMsg = objDILLInRequest.ErrorMsg
                intErrorCode = objDILLInRequest.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Sub CreateIRItem(ByVal intILLID As Integer, ByVal strCallNumber As String, ByVal strTilte As String, ByVal strAuthor As String, ByVal strPlaceOfPub As String, ByVal strPublisher As String, ByVal strSeriesTitleNumber As String, ByVal strVolumeIssue As String, ByVal strEdition As String, ByVal strPubDate As String, ByVal strComponentPubDate As String, ByVal strArticleAuthor As String, ByVal strArticleTitle As String, ByVal strPagination As String, ByVal strNationalBibNumber As String, ByVal strISBN As String, ByVal strISSN As String, ByVal intItemType As Integer, ByVal strSystemNumber As String, ByVal strOtherNumbers As String, ByVal strVerification As String, ByVal strLocalNote As String, ByVal strSponsoringBody As String, ByVal intRequestType As Integer)
            Try
                objDILLInRequest.CreateIRItem(CInt(intILLID), objBCSP.ConvertItBack(strCallNumber), objBCSP.ConvertItBack(strTitle), objBCSP.ConvertItBack(strAuthor), objBCSP.ConvertItBack(strPlaceOfPub), objBCSP.ConvertItBack(strPublisher), objBCSP.ConvertItBack(strSeriesTitleNumber), objBCSP.ConvertItBack(strVolumeIssue), objBCSP.ConvertItBack(strEdition), objBCDBS.ConvertDateBack(strPubDate), objBCDBS.ConvertDateBack(strComponentPubDate), objBCSP.ConvertItBack(strArticleAuthor), objBCSP.ConvertItBack(strArticleTitle), objBCSP.ConvertItBack(strPagination), objBCSP.ConvertItBack(strNationalBibNumber), objBCSP.ConvertItBack(strISBN), objBCSP.ConvertItBack(strISSN), CInt(intItemType), objBCSP.ConvertItBack(strSystemNumber), objBCSP.ConvertItBack(strOtherNumbers), objBCSP.ConvertItBack(strVerification), objBCSP.ConvertItBack(strLocalNote), objBCSP.ConvertItBack(strSponsoringBody), CInt(intRequestType))
                strErrorMsg = objDILLInRequest.ErrorMsg
                intErrorCode = objDILLInRequest.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Sub CreateInRequestPostInfor(ByVal intILLID As Integer, ByVal strPostDelivName As String, ByVal strPostDelivXAddress As String, ByVal strPostDelivStreet As String, ByVal strPostDelivBox As String, ByVal strPostDelivCity As String, ByVal strPostDelivRegion As String, ByVal intPostDelivCountry As Integer, ByVal strPostDelivCode As String)
            Try
                objDILLInRequest.CreateInRequestPostInfor(CInt(intILLID), objBCSP.ConvertItBack(strPostDelivName), objBCSP.ConvertItBack(strPostDelivXAddress), objBCSP.ConvertItBack(strPostDelivStreet), objBCSP.ConvertItBack(strPostDelivBox), objBCSP.ConvertItBack(strPostDelivCity), objBCSP.ConvertItBack(strPostDelivRegion), objBCSP.ConvertItBack(intPostDelivCountry), objBCSP.ConvertItBack(strPostDelivCode))
                strErrorMsg = objDILLInRequest.ErrorMsg
                intErrorCode = objDILLInRequest.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Sub CreateInRequestBillInfor(ByVal intILLID As Integer, ByVal strBillDelivName As String, ByVal strBillDelivXAddress As String, ByVal strBillDelivStreet As String, ByVal strBillDelivBox As String, ByVal strBillDelivCity As String, ByVal strBillDelivRegion As String, ByVal intBillDelivCountry As Integer, ByVal strBillDelivCode As String)
            Try
                objDILLInRequest.CreateInRequestBillInfor(CInt(intILLID), objBCSP.ConvertItBack(strBillDelivName), objBCSP.ConvertItBack(strBillDelivXAddress), objBCSP.ConvertItBack(strBillDelivStreet), objBCSP.ConvertItBack(strBillDelivBox), objBCSP.ConvertItBack(strBillDelivCity), objBCSP.ConvertItBack(strBillDelivRegion), CInt(intBillDelivCountry), objBCSP.ConvertItBack(strBillDelivCode))
                strErrorMsg = objDILLInRequest.ErrorMsg
                intErrorCode = objDILLInRequest.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub
        '********************************************************************************************************
        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objBCTemplate Is Nothing Then
                        objBCTemplate.Dispose(True)
                        objBCTemplate = Nothing
                    End If
                    If Not objBILLLib Is Nothing Then
                        objBILLLib.Dispose(True)
                        objBILLLib = Nothing
                    End If
                    If Not objBCSP Is Nothing Then
                        objBCSP.Dispose(True)
                        objBCSP = Nothing
                    End If
                    If Not objDILLInRequest Is Nothing Then
                        objDILLInRequest.Dispose(True)
                        objDILLInRequest = Nothing
                    End If
                    If Not objBCDBS Is Nothing Then
                        objBCDBS.Dispose(True)
                        objBCDBS = Nothing
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

