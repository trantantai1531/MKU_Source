' Name: clsDILLInRequest
' Purpose: ILL in request purpose
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
    Public Class clsDILLInRequest
        Inherits clsDBase

        ' ***********************************************************************************************
        ' Declare Private variables
        ' ***********************************************************************************************
        Private intIllID As Long

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


        ' ***********************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' ***********************************************************************************************
#Region "Declare public properties"

        ' ILLID property
        Public Property ILLID() As Long
            Get
                Return intIllID
            End Get
            Set(ByVal Value As Long)
                intIllID = Value
            End Set
        End Property

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

#End Region
        ' ***********************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' ***********************************************************************************************

        Public Function GetILLInRequestNum(ByVal lngTopNum As Long, ByRef lngTotalRec As Long, ByRef lngCurrentPos As Long) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_GET_ILLINREQUEST_BY_TOPNUM"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngRequestID", OracleType.Number)).Value = intIllID
                            .Parameters.Add(New OracleParameter("lngTopNum", OracleType.Number)).Value = lngTopNum
                            .Parameters.Add(New OracleParameter("lngTotalRec", OracleType.Number)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("lngCurrentPos", OracleType.Number)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output

                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            lngTotalRec = .Parameters("lngTotalRec").Value
                            lngCurrentPos = .Parameters("lngCurrentPos").Value
                            GetILLInRequestNum = dsData.Tables("tblResult")
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
                        .CommandText = "Ill_spInComingRequests_SelByTopNum"
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
                            GetILLInRequestNum = dsData.Tables("tblResult")
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

        Public Function GetIRInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_GET_IR_DETAIL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngRequestID", OracleType.Number)).Value = intIllID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetIRInfor = dsData.Tables("tblResult")
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
                        .CommandText = "Ill_spInComingRequests_SelDetail"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngRequestID", SqlDbType.Int)).Value = intIllID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetIRInfor = dsData.Tables("tblResult")
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

        Public Function GetIRCancelReq() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_GET_IR_LOG_CANCEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intILLID", OracleType.Number)).Value = intIllID
                            .Parameters.Add(New OracleParameter("intAPDUType", OracleType.Number)).Value = intAPDUType
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetIRCancelReq = dsData.Tables("tblResult")
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
                        .CommandText = "Ill_spIncomingRequestLog_SelLogCancel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIllID", SqlDbType.Int)).Value = intIllID
                            .Parameters.Add(New SqlParameter("@intAPDUType", SqlDbType.Int)).Value = intAPDUType
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetIRCancelReq = dsData.Tables("tblResult")
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

        Public Function GetIRItem() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_GET_REQITEM_INFOR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngID", OracleType.Number)).Value = intIllID
                            .Parameters.Add(New OracleParameter("intType", OracleType.Number)).Value = 1
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetIRItem = dsData.Tables("tblResult")
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
                            .Parameters.Add(New SqlParameter("@intType", SqlDbType.Int)).Value = 1
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetIRItem = dsData.Tables("tblResult")
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

        Public Function GetIRHistoryInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_GET_ILL_IN_HISTORY"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngRequestID", OracleType.Number)).Value = intIllID
                            .Parameters.Add(New OracleParameter("bitAlert", OracleType.Number)).Value = bitAlert
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetIRHistoryInfor = dsData.Tables("tblResult")
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
                        .CommandText = "Ill_spSelHistory"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngRequestID", SqlDbType.Int)).Value = intIllID
                            .Parameters.Add(New SqlParameter("@bitAlert", SqlDbType.Int)).Value = bitAlert
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetIRHistoryInfor = dsData.Tables("tblResult")
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

        Public Function GetIllResponse() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_GET_IR_RESPONSE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("strIDs", OracleType.VarChar, 200)).Value = strIDs
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetIllResponse = dsData.Tables("tblResult")
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
                        .CommandText = "Ill_spRespond_SelByIds"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strIDs", SqlDbType.VarChar, 200)).Value = strIDs
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetIllResponse = dsData.Tables("tblResult")
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

        Public Function GetInfoOfLibCountryForShip() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_GET_IR_LIBADD_COUNTRY"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetInfoOfLibCountryForShip = dsData.Tables("tblResult")
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
                        .CommandText = "Ill_spLocalLibraryAddress_SelForShipXml"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetInfoOfLibCountryForShip = dsData.Tables("tblResult")
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

        Public Function GetInforOfShipMessage() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_GET_IR_SHIPMESS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("intILLID", OracleType.Number)).Value = intIllID
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetInforOfShipMessage = dsData.Tables("tblResult")
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
                        .CommandText = "Ill_spInComingRequests_SelById"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intILLID", SqlDbType.Int)).Value = intIllID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetInforOfShipMessage = dsData.Tables("tblResult")
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

        Public Function InsertIRequestLog() As Integer
            Dim intSuccess As Integer = 0
            Call OpenConnection()
            strNote = strNote.Replace("'", "''")
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spIncomingRequestLog_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intILLID", SqlDbType.Int)).Value = intIllID
                                .Add(New SqlParameter("@intRequesterID", SqlDbType.Int)).Value = intRequesterID
                                .Add(New SqlParameter("@strNote", SqlDbType.NVarChar, 200)).Value = strNote
                                .Add(New SqlParameter("@intAPDUType", SqlDbType.Int)).Value = intAPDUType
                                .Add(New SqlParameter("@intReasonID", SqlDbType.Int)).Value = intReasonID
                                .Add(New SqlParameter("@strProvidedDate", SqlDbType.VarChar, 100)).Value = strProvidedDate
                                .Add(New SqlParameter("@strResponderSpecReason", SqlDbType.NVarChar, 100)).Value = strResponderSpecReason
                                .Add(New SqlParameter("@intSendShipped", SqlDbType.Int)).Value = intSendShipped
                                .Add(New SqlParameter("@intSendCheckedIn", SqlDbType.Int)).Value = intSendCheckedIn
                                .Add(New SqlParameter("@intSendReceived", SqlDbType.Int)).Value = intSendReceived
                                .Add(New SqlParameter("@intSendReturned", SqlDbType.Int)).Value = intSendReturned
                                .Add(New SqlParameter("@intTRE", SqlDbType.Int)).Value = intTRE
                                .Add(New SqlParameter("@intMedium", SqlDbType.Int)).Value = intMedium
                                .Add(New SqlParameter("@dbCost", SqlDbType.Money)).Value = dbCost
                                .Add(New SqlParameter("@strCurrencyCode1", SqlDbType.Char, 3)).Value = strCurrencyCode1
                                .Add(New SqlParameter("@bitAnswer", SqlDbType.Int, 1)).Value = bitAnswer
                                .Add(New SqlParameter("@strDueDate", SqlDbType.VarChar, 100)).Value = strDueDate
                                .Add(New SqlParameter("@bitRenewable", SqlDbType.Int, 1)).Value = bitRenewable
                                .Add(New SqlParameter("@bitAlert", SqlDbType.Int, 1)).Value = bitAlert
                                .Add(New SqlParameter("@intServiceType", SqlDbType.Int)).Value = intServiceType
                                .Add(New SqlParameter("@strLocation", SqlDbType.NVarChar, 300)).Value = strLocation
                                .Add(New SqlParameter("@intCopyrightCompliance", SqlDbType.Int)).Value = intCopyrightCompliance
                                .Add(New SqlParameter("@strReturnedVia", SqlDbType.NVarChar, 100)).Value = strReturnedVia
                                .Add(New SqlParameter("@dbInsuredForCost", SqlDbType.Money)).Value = dbInsuredForCost
                                .Add(New SqlParameter("@strCurrencyCode2", SqlDbType.Char, 3)).Value = strCurrencyCode2
                                .Add(New SqlParameter("@dbReturnInsuranceCost", SqlDbType.Money)).Value = dbReturnInsuranceCost
                                .Add(New SqlParameter("@strCurrencyCode3", SqlDbType.Char, 3)).Value = strCurrencyCode3
                            End With
                            .ExecuteNonQuery()
                            intSuccess = 1
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_INSERT_INCOMREQUEST_LOG"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intILLID", OracleType.Number)).Value = intIllID
                                .Add(New OracleParameter("intRequesterID", OracleType.Number)).Value = intRequesterID
                                .Add(New OracleParameter("strNote", OracleType.NVarChar, 200)).Value = strNote
                                .Add(New OracleParameter("intAPDUType", OracleType.Number)).Value = intAPDUType
                                .Add(New OracleParameter("intReasonID", OracleType.Number)).Value = intReasonID
                                .Add(New OracleParameter("strProvidedDate", OracleType.VarChar, 100)).Value = strProvidedDate
                                .Add(New OracleParameter("strResponderSpecReason", OracleType.VarChar, 100)).Value = strResponderSpecReason
                                .Add(New OracleParameter("intSendShipped", OracleType.Number)).Value = intSendShipped
                                .Add(New OracleParameter("intSendCheckedIn", OracleType.Number)).Value = intSendCheckedIn
                                .Add(New OracleParameter("intSendReceived", OracleType.Number)).Value = intSendReceived
                                .Add(New OracleParameter("intSendReturned", OracleType.Number)).Value = intSendReturned
                                .Add(New OracleParameter("intTRE", OracleType.Number)).Value = intTRE
                                .Add(New OracleParameter("intMedium", OracleType.Number)).Value = intMedium
                                .Add(New OracleParameter("dbCost", OracleType.Float)).Value = dbCost
                                .Add(New OracleParameter("strCurrencyCode1", OracleType.Char, 3)).Value = strCurrencyCode1
                                .Add(New OracleParameter("bitAnswer", OracleType.Number, 1)).Value = bitAnswer
                                .Add(New OracleParameter("strDueDate", OracleType.VarChar, 100)).Value = strDueDate
                                .Add(New OracleParameter("bitRenewable", OracleType.Number, 1)).Value = bitRenewable
                                .Add(New OracleParameter("bitAlert", OracleType.Number, 1)).Value = bitAlert
                                .Add(New OracleParameter("intServiceType", OracleType.Number)).Value = intServiceType
                                .Add(New OracleParameter("strLocation", OracleType.VarChar, 300)).Value = strLocation
                                .Add(New OracleParameter("intCopyrightCompliance", OracleType.Number)).Value = intCopyrightCompliance
                                .Add(New OracleParameter("strReturnedVia", OracleType.VarChar, 100)).Value = strReturnedVia
                                .Add(New OracleParameter("dbInsuredForCost", OracleType.Float)).Value = dbInsuredForCost
                                .Add(New OracleParameter("strCurrencyCode2", OracleType.Char, 3)).Value = strCurrencyCode2
                                .Add(New OracleParameter("dbReturnInsuranceCost", OracleType.Float)).Value = dbReturnInsuranceCost
                                .Add(New OracleParameter("strCurrencyCode3", OracleType.Char, 3)).Value = strCurrencyCode3
                                .Add(New OracleParameter("intSuccess", OracleType.Number, 4)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intSuccess = .Parameters("intSuccess").Value
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            InsertIRequestLog = intSuccess
        End Function

        Public Sub InsertIRequestDenied()
            Call OpenConnection()
            strNote = strNote.Replace("'", "''")
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spIncomingRequestDenied_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intILLID", SqlDbType.Int)).Value = intIllID
                                .Add(New SqlParameter("@strRequestDate", SqlDbType.VarChar, 100)).Value = strRequestDate
                                .Add(New SqlParameter("@intRequesterID", SqlDbType.Int)).Value = intRequesterID
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
                        .CommandText = "ILL.SP_ILL_INSERT_IR_DENIED"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intILLID", OracleType.Number)).Value = intIllID
                                .Add(New OracleParameter("strRequestDate", OracleType.VarChar, 100)).Value = strRequestDate
                                .Add(New OracleParameter("intRequesterID", OracleType.Number)).Value = intRequesterID
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

        Public Function UpdateIR() As Integer
            Call OpenConnection()
            Dim intSuccess As Integer = 0
            strTitle = strTitle.Replace("'", "''")
            strNote = strNote.Replace("'", "''")
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spInComingRequests_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intILLID", SqlDbType.Int)).Value = intIllID
                                .Add(New SqlParameter("@bitAlert", SqlDbType.Int)).Value = bitAlert
                                .Add(New SqlParameter("@strBarcode", SqlDbType.VarChar, 30)).Value = strBarcode
                                .Add(New SqlParameter("@strCancelledDate", SqlDbType.VarChar, 30)).Value = strCancelledDate
                                .Add(New SqlParameter("@intChargeableUnits", SqlDbType.Int)).Value = intChargeableUnits
                                .Add(New SqlParameter("@strCheckedInDate", SqlDbType.VarChar, 30)).Value = strCheckedInDate
                                .Add(New SqlParameter("@strCheckedOutDate", SqlDbType.VarChar, 30)).Value = strCheckedOutDate
                                .Add(New SqlParameter("@intCopyrightCompliance", SqlDbType.Int)).Value = intCopyrightCompliance
                                .Add(New SqlParameter("@dbCost", SqlDbType.Money)).Value = dbCost
                                .Add(New SqlParameter("@strCurrencyCode", SqlDbType.VarChar, 8)).Value = strCurrencyCode
                                .Add(New SqlParameter("@strCurrencyCode1", SqlDbType.VarChar, 8)).Value = strCurrencyCode1
                                .Add(New SqlParameter("@strCurrencyCode2", SqlDbType.VarChar, 8)).Value = strCurrencyCode2
                                .Add(New SqlParameter("@strCurrencyCode3", SqlDbType.VarChar, 8)).Value = strCurrencyCode3
                                .Add(New SqlParameter("@intDelivConditionID", SqlDbType.Int)).Value = intDelivConditionID
                                .Add(New SqlParameter("@bitDelivMode", SqlDbType.Int)).Value = bitDelivMode
                                .Add(New SqlParameter("@strDueDate", SqlDbType.VarChar, 30)).Value = strDueDate
                                .Add(New SqlParameter("@strEDelivMode", SqlDbType.VarChar, 20)).Value = strEDelivMode
                                .Add(New SqlParameter("@strEDelivTSAddr", SqlDbType.NVarChar, 50)).Value = strEDelivTSAddr
                                .Add(New SqlParameter("@strEmailReplyAddress", SqlDbType.VarChar, 30)).Value = strEmailReplyAddress
                                .Add(New SqlParameter("@strExpiryDate", SqlDbType.VarChar, 30)).Value = strExpiryDate
                                .Add(New SqlParameter("@dbInsuredForCost", SqlDbType.Money)).Value = dbInsuredForCost
                                .Add(New SqlParameter("@strInternalRefNumber", SqlDbType.NVarChar, 60)).Value = strInternalRefNumber
                                .Add(New SqlParameter("@intItemType", SqlDbType.Int)).Value = intItemType
                                .Add(New SqlParameter("@intLoanTypeID", SqlDbType.Int)).Value = intLoanTypeID
                                .Add(New SqlParameter("@dbMaxCost", SqlDbType.Money)).Value = dbMaxCost
                                .Add(New SqlParameter("@intMedium", SqlDbType.Int)).Value = intMedium
                                .Add(New SqlParameter("@strNeedBeforeDate", SqlDbType.VarChar, 30)).Value = strNeedBeforeDate
                                .Add(New SqlParameter("@strNote", SqlDbType.NVarChar, 200)).Value = strNote
                                .Add(New SqlParameter("@strPatronID", SqlDbType.VarChar, 24)).Value = strPatronID
                                .Add(New SqlParameter("@strPatronName", SqlDbType.NVarChar, 50)).Value = strPatronName
                                .Add(New SqlParameter("@strPatronStatus", SqlDbType.NVarChar, 50)).Value = strPatronStatus
                                .Add(New SqlParameter("@bitPaymentProvided", SqlDbType.Int)).Value = bitPaymentProvided
                                .Add(New SqlParameter("@intPaymentType", SqlDbType.Int)).Value = intPaymentType
                                .Add(New SqlParameter("@intPriority", SqlDbType.Int)).Value = intPriority
                                .Add(New SqlParameter("@strReceivedDate", SqlDbType.VarChar, 30)).Value = strReceivedDate
                                .Add(New SqlParameter("@bitReciprocalAgreement", SqlDbType.Int)).Value = bitReciprocalAgreement
                                .Add(New SqlParameter("@bitRenewable", SqlDbType.Int)).Value = bitRenewable
                                .Add(New SqlParameter("@intRenewals", SqlDbType.Int)).Value = intRenewals
                                .Add(New SqlParameter("@strRequestDate", SqlDbType.VarChar, 30)).Value = strRequestDate
                                .Add(New SqlParameter("@intRequesterID", SqlDbType.Int)).Value = intRequesterID
                                .Add(New SqlParameter("@strRequestID", SqlDbType.VarChar, 16)).Value = strRequestID
                                .Add(New SqlParameter("@strRespondDate", SqlDbType.VarChar, 30)).Value = strRespondDate
                                .Add(New SqlParameter("@strReturnedDate", SqlDbType.VarChar, 30)).Value = strReturnedDate
                                .Add(New SqlParameter("@dbReturnInsuranceCost", SqlDbType.Money)).Value = dbReturnInsuranceCost
                                .Add(New SqlParameter("@intReturnLocID", SqlDbType.Int)).Value = intReturnLocID
                                .Add(New SqlParameter("@intServiceType", SqlDbType.Int)).Value = intServiceType
                                .Add(New SqlParameter("@strShippedDate", SqlDbType.VarChar, 30)).Value = strShippedDate
                                .Add(New SqlParameter("@strIssueID", SqlDbType.VarChar, 50)).Value = strIssueID
                                .Add(New SqlParameter("@intStatus", SqlDbType.Int)).Value = intStatus
                                .Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                                .Add(New SqlParameter("@strTitle", SqlDbType.NVarChar, 200)).Value = strTitle
                                .Add(New SqlParameter("@intTransportationModeID", SqlDbType.Int)).Value = intTransportationModeID
                                .Add(New SqlParameter("@bitWillPayFee", SqlDbType.Int)).Value = bitWillPayFee
                                .Add(New SqlParameter("@strBoolSQL", SqlDbType.VarChar, 100)).Value = strBoolSQL
                            End With
                            .ExecuteNonQuery()
                            intSuccess = 1
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_UPDATE_INCOMING_REQUEST"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intILLID", OracleType.Number)).Value = intIllID
                                .Add(New OracleParameter("bitAlert", OracleType.Number)).Value = bitAlert
                                .Add(New OracleParameter("strBarcode", OracleType.VarChar, 30)).Value = strBarcode
                                .Add(New OracleParameter("strCancelledDate", OracleType.VarChar, 30)).Value = strCancelledDate
                                .Add(New OracleParameter("intChargeableUnits", OracleType.Number)).Value = intChargeableUnits
                                .Add(New OracleParameter("strCheckedInDate", OracleType.VarChar, 30)).Value = strCheckedInDate
                                .Add(New OracleParameter("strCheckedOutDate", OracleType.VarChar, 30)).Value = strCheckedOutDate
                                .Add(New OracleParameter("intCopyrightCompliance", OracleType.Number)).Value = intCopyrightCompliance
                                .Add(New OracleParameter("dbCost", OracleType.Float)).Value = dbCost
                                .Add(New OracleParameter("strCurrencyCode", OracleType.VarChar, 3)).Value = strCurrencyCode
                                .Add(New OracleParameter("strCurrencyCode1", OracleType.VarChar, 3)).Value = strCurrencyCode1
                                .Add(New OracleParameter("strCurrencyCode2", OracleType.VarChar, 3)).Value = strCurrencyCode2
                                .Add(New OracleParameter("strCurrencyCode3", OracleType.VarChar, 3)).Value = strCurrencyCode3
                                .Add(New OracleParameter("intDelivConditionID", OracleType.Number)).Value = intDelivConditionID
                                .Add(New OracleParameter("bitDelivMode", OracleType.Number)).Value = bitDelivMode
                                .Add(New OracleParameter("strDueDate", OracleType.VarChar, 30)).Value = strDueDate
                                .Add(New OracleParameter("strEDelivMode", OracleType.VarChar, 20)).Value = strEDelivMode
                                .Add(New OracleParameter("strEDelivTSAddr", OracleType.VarChar, 50)).Value = strEDelivTSAddr
                                .Add(New OracleParameter("strEmailReplyAddress", OracleType.VarChar, 30)).Value = strEmailReplyAddress
                                .Add(New OracleParameter("strExpiryDate", OracleType.VarChar, 30)).Value = strExpiryDate
                                .Add(New OracleParameter("dbInsuredForCost", OracleType.Float)).Value = dbInsuredForCost
                                .Add(New OracleParameter("strInternalRefNumber", OracleType.VarChar, 60)).Value = strInternalRefNumber
                                .Add(New OracleParameter("intItemType", OracleType.Number)).Value = intItemType
                                .Add(New OracleParameter("intLoanTypeID", OracleType.Number)).Value = intLoanTypeID
                                .Add(New OracleParameter("dbMaxCost", OracleType.Float)).Value = dbMaxCost
                                .Add(New OracleParameter("intMedium", OracleType.Number)).Value = intMedium
                                .Add(New OracleParameter("strNeedBeforeDate", OracleType.VarChar, 30)).Value = strNeedBeforeDate
                                .Add(New OracleParameter("strNote", OracleType.VarChar, 200)).Value = strNote
                                .Add(New OracleParameter("strPatronID", OracleType.VarChar, 24)).Value = strPatronID
                                .Add(New OracleParameter("strPatronName", OracleType.VarChar, 50)).Value = strPatronName
                                .Add(New OracleParameter("strPatronStatus", OracleType.VarChar, 24)).Value = strPatronStatus
                                .Add(New OracleParameter("bitPaymentProvided", OracleType.Number)).Value = bitPaymentProvided
                                .Add(New OracleParameter("intPaymentType", OracleType.Number)).Value = intPaymentType
                                .Add(New OracleParameter("intPriority", OracleType.Number)).Value = intPriority
                                .Add(New OracleParameter("strReceivedDate", OracleType.VarChar, 30)).Value = strReceivedDate
                                .Add(New OracleParameter("bitReciprocalAgreement", OracleType.Number)).Value = bitReciprocalAgreement
                                .Add(New OracleParameter("bitRenewable", OracleType.Number)).Value = bitRenewable
                                .Add(New OracleParameter("intRenewals", OracleType.Number)).Value = intRenewals
                                .Add(New OracleParameter("strRequestDate", OracleType.VarChar, 30)).Value = strRequestDate
                                .Add(New OracleParameter("intRequesterID", OracleType.Number)).Value = intRequesterID
                                .Add(New OracleParameter("strRequestID", OracleType.VarChar, 16)).Value = strRequestID
                                .Add(New OracleParameter("strRespondDate", OracleType.VarChar, 30)).Value = strRespondDate
                                .Add(New OracleParameter("strReturnedDate", OracleType.VarChar, 30)).Value = strReturnedDate
                                .Add(New OracleParameter("dbReturnInsuranceCost", OracleType.Float)).Value = dbReturnInsuranceCost
                                .Add(New OracleParameter("intReturnLocID", OracleType.Number)).Value = intReturnLocID
                                .Add(New OracleParameter("intServiceType", OracleType.Number)).Value = intServiceType
                                .Add(New OracleParameter("strShippedDate", OracleType.VarChar, 30)).Value = strShippedDate
                                .Add(New OracleParameter("strIssueID", OracleType.VarChar, 50)).Value = strIssueID
                                .Add(New OracleParameter("intStatus", OracleType.Number)).Value = intStatus
                                .Add(New OracleParameter("intItemID", OracleType.Number)).Value = intItemID
                                .Add(New OracleParameter("strTitle", OracleType.VarChar, 200)).Value = strTitle
                                .Add(New OracleParameter("intTransportationModeID", OracleType.Number)).Value = intTransportationModeID
                                .Add(New OracleParameter("bitWillPayFee", OracleType.Number)).Value = bitWillPayFee
                                .Add(New OracleParameter("strBoolSQL", OracleType.VarChar, 100)).Value = strBoolSQL
                                .Add(New OracleParameter("intSuccess", OracleType.Number, 4)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intSuccess = .Parameters("intSuccess").Value
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            UpdateIR = intSuccess
        End Function

        Public Function CreateIR() As Integer
            Call OpenConnection()
            Dim intSuccess As Integer = 0
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "SP_ILL_INSERT_INCOMING_REQUEST"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@bitAlert", SqlDbType.Int)).Value = bitAlert
                                .Add(New SqlParameter("@strBarcode", SqlDbType.NVarChar, 30)).Value = strBarcode
                                .Add(New SqlParameter("@strCancelledDate", SqlDbType.VarChar, 30)).Value = strCancelledDate
                                .Add(New SqlParameter("@intChargeableUnits", SqlDbType.Int)).Value = intChargeableUnits
                                .Add(New SqlParameter("@strCheckedInDate", SqlDbType.VarChar, 30)).Value = strCheckedInDate
                                .Add(New SqlParameter("@strCheckedOutDate", SqlDbType.VarChar, 30)).Value = strCheckedOutDate
                                .Add(New SqlParameter("@intCopyrightCompliance", SqlDbType.Int)).Value = intCopyrightCompliance
                                .Add(New SqlParameter("@dbCost", SqlDbType.Money)).Value = dbCost
                                .Add(New SqlParameter("@strCurrencyCode", SqlDbType.VarChar, 8)).Value = strCurrencyCode
                                .Add(New SqlParameter("@strCurrencyCode1", SqlDbType.VarChar, 8)).Value = strCurrencyCode1
                                .Add(New SqlParameter("@strCurrencyCode2", SqlDbType.VarChar, 8)).Value = strCurrencyCode2
                                .Add(New SqlParameter("@strCurrencyCode3", SqlDbType.VarChar, 8)).Value = strCurrencyCode3
                                .Add(New SqlParameter("@intDelivConditionID", SqlDbType.Int)).Value = intDelivConditionID
                                .Add(New SqlParameter("@bitDelivMode", SqlDbType.Int)).Value = bitDelivMode
                                .Add(New SqlParameter("@strDueDate", SqlDbType.VarChar, 30)).Value = strDueDate
                                .Add(New SqlParameter("@strEDelivMode", SqlDbType.NVarChar, 20)).Value = strEDelivMode
                                .Add(New SqlParameter("@strEDelivTSAddr", SqlDbType.NVarChar, 50)).Value = strEDelivTSAddr
                                .Add(New SqlParameter("@strEmailReplyAddress", SqlDbType.NVarChar, 50)).Value = strEmailReplyAddress
                                .Add(New SqlParameter("@strExpiryDate", SqlDbType.VarChar, 30)).Value = strExpiryDate
                                .Add(New SqlParameter("@dbInsuredForCost", SqlDbType.Money)).Value = dbInsuredForCost
                                .Add(New SqlParameter("@strInternalRefNumber", SqlDbType.NVarChar, 60)).Value = strInternalRefNumber
                                .Add(New SqlParameter("@intItemType", SqlDbType.Int)).Value = intItemType
                                .Add(New SqlParameter("@intLoanTypeID", SqlDbType.Int)).Value = intLoanTypeID
                                .Add(New SqlParameter("@dbMaxCost", SqlDbType.Money)).Value = dbMaxCost
                                .Add(New SqlParameter("@intMedium", SqlDbType.Int)).Value = intMedium
                                .Add(New SqlParameter("@strNeedBeforeDate", SqlDbType.VarChar, 30)).Value = strNeedBeforeDate
                                .Add(New SqlParameter("@strNote", SqlDbType.NVarChar, 200)).Value = strNote
                                .Add(New SqlParameter("@strPatronID", SqlDbType.VarChar, 24)).Value = strPatronID
                                .Add(New SqlParameter("@strPatronName", SqlDbType.NVarChar, 50)).Value = strPatronName
                                .Add(New SqlParameter("@strPatronStatus", SqlDbType.NVarChar, 50)).Value = strPatronStatus
                                .Add(New SqlParameter("@bitPaymentProvided", SqlDbType.Int)).Value = bitPaymentProvided
                                .Add(New SqlParameter("@intPaymentType", SqlDbType.Int)).Value = intPaymentType
                                .Add(New SqlParameter("@intPriority", SqlDbType.Int)).Value = intPriority
                                .Add(New SqlParameter("@strReceivedDate", SqlDbType.VarChar, 30)).Value = strReceivedDate
                                .Add(New SqlParameter("@bitReciprocalAgreement", SqlDbType.Int)).Value = bitReciprocalAgreement
                                .Add(New SqlParameter("@bitRenewable", SqlDbType.Int)).Value = bitRenewable
                                .Add(New SqlParameter("@intRenewals", SqlDbType.Int)).Value = intRenewals
                                .Add(New SqlParameter("@strRequestDate", SqlDbType.VarChar, 30)).Value = strRequestDate
                                .Add(New SqlParameter("@intRequesterID", SqlDbType.Int)).Value = intRequesterID
                                .Add(New SqlParameter("@strRequestID", SqlDbType.VarChar, 16)).Value = strRequestID
                                .Add(New SqlParameter("@strRespondDate", SqlDbType.VarChar, 30)).Value = strRespondDate
                                .Add(New SqlParameter("@strReturnedDate", SqlDbType.VarChar, 30)).Value = strReturnedDate
                                .Add(New SqlParameter("@dbReturnInsuranceCost", SqlDbType.Money)).Value = dbReturnInsuranceCost
                                .Add(New SqlParameter("@intReturnLocID", SqlDbType.Int)).Value = intReturnLocID
                                .Add(New SqlParameter("@intServiceType", SqlDbType.Int)).Value = intServiceType
                                .Add(New SqlParameter("@strShippedDate", SqlDbType.VarChar, 0)).Value = strShippedDate
                                .Add(New SqlParameter("@strIssueID", SqlDbType.VarChar, 50)).Value = strIssueID
                                .Add(New SqlParameter("@intStatus", SqlDbType.Int)).Value = intStatus
                                .Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                                .Add(New SqlParameter("@strTitle", SqlDbType.NVarChar, 200)).Value = strTitle
                                .Add(New SqlParameter("@intTransportationModeID", SqlDbType.Int)).Value = intTransportationModeID
                                .Add(New SqlParameter("@bitWillPayFee", SqlDbType.Int)).Value = bitWillPayFee
                                .Add(New SqlParameter("@intID", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intSuccess = .Parameters("@intID").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_INSERT_INCOMING_REQUEST"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("bitAlert", OracleType.Number)).Value = bitAlert
                                .Add(New OracleParameter("strBarcode", OracleType.VarChar, 30)).Value = strBarcode
                                .Add(New OracleParameter("strCancelledDate", OracleType.VarChar, 30)).Value = strCancelledDate
                                .Add(New OracleParameter("intChargeableUnits", OracleType.Number)).Value = intChargeableUnits
                                .Add(New OracleParameter("strCheckedInDate", OracleType.VarChar, 30)).Value = strCheckedInDate
                                .Add(New OracleParameter("strCheckedOutDate", OracleType.VarChar, 30)).Value = strCheckedOutDate
                                .Add(New OracleParameter("intCopyrightCompliance", OracleType.Number)).Value = intCopyrightCompliance
                                .Add(New OracleParameter("dbCost", OracleType.Float)).Value = dbCost
                                .Add(New OracleParameter("strCurrencyCode", OracleType.VarChar, 3)).Value = strCurrencyCode
                                .Add(New OracleParameter("strCurrencyCode1", OracleType.VarChar, 3)).Value = strCurrencyCode1
                                .Add(New OracleParameter("strCurrencyCode2", OracleType.VarChar, 3)).Value = strCurrencyCode2
                                .Add(New OracleParameter("strCurrencyCode3", OracleType.VarChar, 3)).Value = strCurrencyCode3
                                .Add(New OracleParameter("intDelivConditionID", OracleType.Number)).Value = intDelivConditionID
                                .Add(New OracleParameter("bitDelivMode", OracleType.Number)).Value = bitDelivMode
                                .Add(New OracleParameter("strDueDate", OracleType.VarChar, 30)).Value = strDueDate
                                .Add(New OracleParameter("strEDelivMode", OracleType.VarChar, 20)).Value = strEDelivMode
                                .Add(New OracleParameter("strEDelivTSAddr", OracleType.VarChar, 50)).Value = strEDelivTSAddr
                                .Add(New OracleParameter("strEmailReplyAddress", OracleType.VarChar, 30)).Value = strEmailReplyAddress
                                .Add(New OracleParameter("strExpiryDate", OracleType.VarChar, 30)).Value = strExpiryDate
                                .Add(New OracleParameter("dbInsuredForCost", OracleType.Float)).Value = dbInsuredForCost
                                .Add(New OracleParameter("strInternalRefNumber", OracleType.VarChar, 60)).Value = strInternalRefNumber
                                .Add(New OracleParameter("intItemType", OracleType.Number)).Value = intItemType
                                .Add(New OracleParameter("intLoanTypeID", OracleType.Number)).Value = intLoanTypeID
                                .Add(New OracleParameter("dbMaxCost", OracleType.Float)).Value = dbMaxCost
                                .Add(New OracleParameter("intMedium", OracleType.Number)).Value = intMedium
                                .Add(New OracleParameter("strNeedBeforeDate", OracleType.VarChar, 30)).Value = strNeedBeforeDate
                                .Add(New OracleParameter("strNote", OracleType.VarChar, 200)).Value = strNote
                                .Add(New OracleParameter("strPatronID", OracleType.VarChar, 24)).Value = strPatronID
                                .Add(New OracleParameter("strPatronName", OracleType.VarChar, 50)).Value = strPatronName
                                .Add(New OracleParameter("strPatronStatus", OracleType.VarChar, 24)).Value = strPatronStatus
                                .Add(New OracleParameter("bitPaymentProvided", OracleType.Number)).Value = bitPaymentProvided
                                .Add(New OracleParameter("intPaymentType", OracleType.Number)).Value = intPaymentType
                                .Add(New OracleParameter("intPriority", OracleType.Number)).Value = intPriority
                                .Add(New OracleParameter("strReceivedDate", OracleType.VarChar, 30)).Value = strReceivedDate
                                .Add(New OracleParameter("bitReciprocalAgreement", OracleType.Number)).Value = bitReciprocalAgreement
                                .Add(New OracleParameter("bitRenewable", OracleType.Number)).Value = bitRenewable
                                .Add(New OracleParameter("intRenewals", OracleType.Number)).Value = intRenewals
                                .Add(New OracleParameter("strRequestDate", OracleType.VarChar, 30)).Value = strRequestDate
                                .Add(New OracleParameter("intRequesterID", OracleType.Number)).Value = intRequesterID
                                .Add(New OracleParameter("strRequestID", OracleType.VarChar, 16)).Value = strRequestID
                                .Add(New OracleParameter("strRespondDate", OracleType.VarChar, 30)).Value = strRespondDate
                                .Add(New OracleParameter("strReturnedDate", OracleType.VarChar, 30)).Value = strReturnedDate
                                .Add(New OracleParameter("dbReturnInsuranceCost", OracleType.Float)).Value = dbReturnInsuranceCost
                                .Add(New OracleParameter("intReturnLocID", OracleType.Number)).Value = intReturnLocID
                                .Add(New OracleParameter("intServiceType", OracleType.Number)).Value = intServiceType
                                .Add(New OracleParameter("strShippedDate", OracleType.VarChar, 30)).Value = strShippedDate
                                .Add(New OracleParameter("strIssueID", OracleType.VarChar, 50)).Value = strIssueID
                                .Add(New OracleParameter("intStatus", OracleType.Number)).Value = intStatus
                                .Add(New OracleParameter("intItemID", OracleType.Number)).Value = intItemID
                                .Add(New OracleParameter("strTitle", OracleType.VarChar, 200)).Value = strTitle
                                .Add(New OracleParameter("intTransportationModeID", OracleType.Number)).Value = intTransportationModeID
                                .Add(New OracleParameter("bitWillPayFee", OracleType.Number)).Value = bitWillPayFee
                                .Add(New OracleParameter("intID", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intSuccess = .Parameters("intID").Value
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            CreateIR = intSuccess
        End Function

        Public Function DeleteIR() As Integer
            Dim intSuccess As Integer = 0
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spIncomingRequest_Del"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intILLID", SqlDbType.Int, 4)).Value = intIllID
                            End With
                            .ExecuteNonQuery()
                            intSuccess = 1
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_DEL_INREQUEST"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intILLID", OracleType.Number, 4)).Value = intIllID
                        End With
                        Try
                            .ExecuteNonQuery()
                            intSuccess = 1
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            DeleteIR = intSuccess
        End Function

        Public Sub SetIRItem(ByVal lngItemID As Long, Optional ByVal strIssueID As String = "")
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spRequestItem_UpdSetInItem"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@lngILLID", SqlDbType.Int)).Value = intIllID
                                .Add(New SqlParameter("@lngItemID", SqlDbType.Int)).Value = lngItemID
                                .Add(New SqlParameter("@strIssueID", SqlDbType.VarChar, 50)).Value = strIssueID
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
                        .CommandText = "ILL.SP_ILL_SET_IN_ITEM"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("lngILLID", OracleType.Number)).Value = intIllID
                            .Add(New OracleParameter("lngItemID", OracleType.Number)).Value = lngItemID
                            .Add(New OracleParameter("strIssueID", OracleType.VarChar, 50)).Value = strIssueID
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

        Public Sub ChangeFolder()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spIncomingRequest_UpdChangeFolder"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intType", SqlDbType.Int)).Value = 1
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
                            .Add(New OracleParameter("intType", OracleType.Number)).Value = 1
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

        Public Function PackageIR(ByVal intID As Integer, ByVal strSelectMode As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spRequestItem_SelPackage"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intID", SqlDbType.Int, 4)).Value = intID
                                .Add(New SqlParameter("@strSelectMode", SqlDbType.VarChar, 10)).Value = strSelectMode
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            PackageIR = dsData.Tables("tblResult")
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
                        .CommandText = "ILL.SP_ILL_GET_PACKAGE"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("strSelectMode", OracleType.VarChar, 10)).Value = strSelectMode
                            .Add(New OracleParameter("intID", OracleType.Number, 4)).Value = intID
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            PackageIR = dsData.Tables("tblResult")
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

        Public Sub UpdateIRequestLogCancel()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spIncomingRequestLog_UpdCancel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLogID", SqlDbType.Int)).Value = intLogID
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
                        .CommandText = "ILL.SP_ILL_UPDATE_IR_LOGID_CANCEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intLogID", OracleType.Number)).Value = intLogID
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

        Public Sub RecallIt(ByVal intILLID As Integer, ByVal intRequesterID As Integer, ByVal strNote As String)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spInComingRequests_UpdChangeStatus"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intILLID", SqlDbType.Int, 4)).Value = intILLID
                                .Add(New SqlParameter("@intRequesterID", SqlDbType.Int, 4)).Value = intRequesterID
                                .Add(New SqlParameter("@strNote", SqlDbType.NVarChar)).Value = strNote
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
                        .CommandText = "ILL.SP_ILL_RECALLIT"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intILLID", OracleType.Number, 4)).Value = intILLID
                            .Add(New OracleParameter("intRequesterID", OracleType.Number, 4)).Value = intRequesterID
                            .Add(New OracleParameter("strNote", OracleType.NVarChar, 100)).Value = strNote
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

        Public Function GetILLRequestItems(ByVal intID As Integer, ByVal intRequestType As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spInComingRequests_UpdChangeStatus"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intID", SqlDbType.Int, 4)).Value = intID
                                .Add(New SqlParameter("@intRequestType", SqlDbType.Int, 4)).Value = intRequestType
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetILLRequestItems = dsData.Tables("tblResult")
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
                        .CommandText = "ILL.SP_ILL_RECALLIT"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intID", OracleType.Number, 4)).Value = intID
                            .Add(New OracleParameter("intRequestType", OracleType.Number, 4)).Value = intRequestType
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetILLRequestItems = dsData.Tables("tblResult")
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

        Public Sub CreateIRItem(ByVal intILLID As Integer, ByVal strCallNumber As String, ByVal strTilte As String, ByVal strAuthor As String, ByVal strPlaceOfPub As String, ByVal strPublisher As String, ByVal strSeriesTitleNumber As String, ByVal strVolumeIssue As String, ByVal strEdition As String, ByVal strPubDate As String, ByVal strComponentPubDate As String, ByVal strArticleAuthor As String, ByVal strArticleTitle As String, ByVal strPagination As String, ByVal strNationalBibNumber As String, ByVal strISBN As String, ByVal strISSN As String, ByVal intItemType As Integer, ByVal strSystemNumber As String, ByVal strOtherNumbers As String, ByVal strVerification As String, ByVal strLocalNote As String, ByVal strSponsoringBody As String, ByVal intRequestType As Integer)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spRequestItem_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intID", SqlDbType.Int, 4)).Value = intILLID
                                .Add(New SqlParameter("@strCallNumber", SqlDbType.NVarChar)).Value = strCallNumber
                                .Add(New SqlParameter("@strTitle", SqlDbType.NVarChar, 200)).Value = strTitle
                                .Add(New SqlParameter("@strAuthor", SqlDbType.NVarChar)).Value = strAuthor
                                .Add(New SqlParameter("@strPlaceOfPub", SqlDbType.NVarChar)).Value = strPlaceOfPub
                                .Add(New SqlParameter("@strPublisher", SqlDbType.NVarChar)).Value = strPublisher
                                .Add(New SqlParameter("@strSeriesTitleNumber", SqlDbType.NVarChar)).Value = strSeriesTitleNumber
                                .Add(New SqlParameter("@strVolumeIssue", SqlDbType.NVarChar)).Value = strVolumeIssue
                                .Add(New SqlParameter("@strEdition", SqlDbType.NVarChar)).Value = strEdition
                                .Add(New SqlParameter("@strPubDate", SqlDbType.VarChar)).Value = strPubDate
                                .Add(New SqlParameter("@strComponentPubDate", SqlDbType.VarChar)).Value = strComponentPubDate
                                .Add(New SqlParameter("@strArticleAuthor", SqlDbType.NVarChar)).Value = strArticleAuthor
                                .Add(New SqlParameter("@strArticleTitle", SqlDbType.NVarChar)).Value = strArticleTitle
                                .Add(New SqlParameter("@strPagination", SqlDbType.NVarChar)).Value = strPagination
                                .Add(New SqlParameter("@strNationalBibNumber", SqlDbType.NVarChar)).Value = strNationalBibNumber
                                .Add(New SqlParameter("@strISBN", SqlDbType.NVarChar)).Value = strISBN
                                .Add(New SqlParameter("@strISSN", SqlDbType.NVarChar)).Value = strISSN
                                .Add(New SqlParameter("@intItemType", SqlDbType.Int)).Value = intItemType
                                .Add(New SqlParameter("@strSystemNumber", SqlDbType.NVarChar)).Value = strSystemNumber
                                .Add(New SqlParameter("@strOtherNumbers", SqlDbType.NVarChar)).Value = strOtherNumbers
                                .Add(New SqlParameter("@strVerification", SqlDbType.NVarChar)).Value = strVerification
                                .Add(New SqlParameter("@strLocalNote", SqlDbType.NVarChar)).Value = strLocalNote
                                .Add(New SqlParameter("@strSponsoringBody", SqlDbType.NVarChar)).Value = strSponsoringBody
                                .Add(New SqlParameter("@intRequestType", SqlDbType.Int)).Value = intRequestType
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
                        .CommandText = "ILL.SP_ILL_INSERT_IN_REQUEST_ITEM"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intID", OracleType.Number)).Value = intILLID
                            .Add(New OracleParameter("strCallNumber", OracleType.VarChar, 24)).Value = strCallNumber
                            .Add(New OracleParameter("strTitle", OracleType.VarChar, 200)).Value = strTitle
                            .Add(New OracleParameter("strAuthor", OracleType.VarChar, 100)).Value = strAuthor
                            .Add(New OracleParameter("strPlaceOfPub", OracleType.VarChar, 30)).Value = strPlaceOfPub
                            .Add(New OracleParameter("strPublisher", OracleType.VarChar, 100)).Value = strPublisher
                            .Add(New OracleParameter("strSeriesTitleNumber", OracleType.VarChar, 120)).Value = strSeriesTitleNumber
                            .Add(New OracleParameter("strVolumeIssue", OracleType.VarChar, 40)).Value = strVolumeIssue
                            .Add(New OracleParameter("strEdition", OracleType.VarChar, 50)).Value = strEdition
                            .Add(New OracleParameter("strPubDate", OracleType.VarChar, 20)).Value = strPubDate
                            .Add(New OracleParameter("strComponentPubDate", OracleType.VarChar, 20)).Value = strComponentPubDate
                            .Add(New OracleParameter("strArticleAuthor", OracleType.VarChar, 64)).Value = strArticleAuthor
                            .Add(New OracleParameter("strArticleTitle", OracleType.VarChar, 200)).Value = strArticleTitle
                            .Add(New OracleParameter("strPagination", OracleType.VarChar, 50)).Value = strPagination
                            .Add(New OracleParameter("strNationalBibNumber", OracleType.VarChar, 25)).Value = strNationalBibNumber
                            .Add(New OracleParameter("strISBN", OracleType.VarChar, 16)).Value = strISBN
                            .Add(New OracleParameter("strISSN", OracleType.VarChar, 16)).Value = strISSN
                            .Add(New OracleParameter("intItemType", OracleType.Number)).Value = intItemType
                            .Add(New OracleParameter("strSystemNumber", OracleType.VarChar, 20)).Value = strSystemNumber
                            .Add(New OracleParameter("strOtherNumbers", OracleType.VarChar, 50)).Value = strOtherNumbers
                            .Add(New OracleParameter("strVerification", OracleType.VarChar, 16)).Value = strVerification
                            .Add(New OracleParameter("strLocalNote", OracleType.VarChar, 100)).Value = strLocalNote
                            .Add(New OracleParameter("strSponsoringBody", OracleType.VarChar, 100)).Value = strSponsoringBody
                            .Add(New OracleParameter("intRequestType", OracleType.Number)).Value = intRequestType

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

        Public Sub CreateInRequestPostInfor(ByVal intILLID As Integer, ByVal strPostDelivName As String, ByVal strPostDelivXAddress As String, ByVal strPostDelivStreet As String, ByVal strPostDelivBox As String, ByVal strPostDelivCity As String, ByVal strPostDelivRegion As String, ByVal intPostDelivCountry As Integer, ByVal strPostDelivCode As String)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "ILL_spIncomingRequestDelinf_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intID", SqlDbType.Int, 4)).Value = intILLID
                                .Add(New SqlParameter("@strPostDelivName", SqlDbType.NVarChar)).Value = strPostDelivName
                                .Add(New SqlParameter("@strBillDelivXAddress", SqlDbType.NVarChar)).Value = strPostDelivXAddress
                                .Add(New SqlParameter("@strPostDelivStreet", SqlDbType.NVarChar)).Value = strPostDelivStreet
                                .Add(New SqlParameter("@strPostDelivBox", SqlDbType.NVarChar)).Value = strPostDelivBox
                                .Add(New SqlParameter("@strPostDelivCity", SqlDbType.NVarChar)).Value = strPostDelivCity
                                .Add(New SqlParameter("@strPostDelivRegion", SqlDbType.NVarChar)).Value = strPostDelivRegion
                                .Add(New SqlParameter("@intPostDelivCountry", SqlDbType.Int)).Value = intPostDelivCountry
                                .Add(New SqlParameter("@strPostDelivCode", SqlDbType.NVarChar)).Value = strPostDelivCode
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
                        .CommandText = "ILL.SP_ILL_INS_IN_REQUESTS_DELINF"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intID", OracleType.Number)).Value = intILLID
                            .Add(New OracleParameter("strPostDelivName", OracleType.VarChar, 100)).Value = strPostDelivName
                            .Add(New OracleParameter("strPostDelivXAddr", OracleType.VarChar, 100)).Value = strPostDelivXAddress
                            .Add(New OracleParameter("strPostDelivStreet", OracleType.VarChar, 50)).Value = strPostDelivStreet
                            .Add(New OracleParameter("strPostDelivBox", OracleType.VarChar, 50)).Value = strPostDelivBox
                            .Add(New OracleParameter("strPostDelivCity", OracleType.VarChar, 50)).Value = strPostDelivCity
                            .Add(New OracleParameter("strPostDelivRegion", OracleType.VarChar, 50)).Value = strPostDelivRegion
                            .Add(New OracleParameter("intPostDelivCountry", OracleType.Number)).Value = intPostDelivCountry
                            .Add(New OracleParameter("strPostDelivCode", OracleType.VarChar, 10)).Value = strPostDelivCode
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

        Public Sub CreateInRequestBillInfor(ByVal intILLID As Integer, ByVal strBillDelivName As String, ByVal strBillDelivXAddress As String, ByVal strBillDelivStreet As String, ByVal strBillDelivBox As String, ByVal strBillDelivCity As String, ByVal strBillDelivRegion As String, ByVal intBillDelivCountry As Integer, ByVal strBillDelivCode As String)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spIncomingRequestBilinf_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intID", SqlDbType.Int, 4)).Value = intILLID
                                .Add(New SqlParameter("@strBillDelivName", SqlDbType.NVarChar)).Value = strBillDelivName
                                .Add(New SqlParameter("@strBillDelivXAddress", SqlDbType.NVarChar)).Value = strBillDelivXAddress
                                .Add(New SqlParameter("@strBillDelivStreet", SqlDbType.NVarChar)).Value = strBillDelivStreet
                                .Add(New SqlParameter("@strBillDelivBox", SqlDbType.NVarChar)).Value = strBillDelivBox
                                .Add(New SqlParameter("@strBillDelivCity", SqlDbType.NVarChar)).Value = strBillDelivCity
                                .Add(New SqlParameter("@strBillDelivRegion", SqlDbType.NVarChar)).Value = strBillDelivRegion
                                .Add(New SqlParameter("@intBillDelivCountry", SqlDbType.Int)).Value = intBillDelivCountry
                                .Add(New SqlParameter("@strBillDelivCode", SqlDbType.NVarChar)).Value = strBillDelivCode
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
                        .CommandText = "ILL.SP_ILL_INS_IN_REQUESTS_BILINF"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intID", OracleType.Number, 4)).Value = intILLID
                            .Add(New OracleParameter("strBillDelivName", OracleType.VarChar, 100)).Value = strBillDelivName
                            .Add(New OracleParameter("strBillDelivXAddr", OracleType.VarChar, 100)).Value = strBillDelivXAddress
                            .Add(New OracleParameter("strBillDelivStreet", OracleType.VarChar, 50)).Value = strBillDelivStreet
                            .Add(New OracleParameter("strBillDelivBox", OracleType.VarChar, 50)).Value = strBillDelivBox
                            .Add(New OracleParameter("strBillDelivCity", OracleType.VarChar, 50)).Value = strBillDelivCity
                            .Add(New OracleParameter("strBillDelivRegion", OracleType.VarChar, 50)).Value = strBillDelivRegion
                            .Add(New OracleParameter("intBillDelivCountry", OracleType.Number)).Value = intBillDelivCountry
                            .Add(New OracleParameter("strBillDelivCode", OracleType.VarChar, 10)).Value = strBillDelivCode
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

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                Call MyBase.Dispose(isDisposing)
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace