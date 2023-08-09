Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Acquisition
    Public Class clsDItemOrder
        Inherits clsDBase

        ' *****************************************************************************************************
        ' Declare Private variables
        ' *****************************************************************************************************

        Private intRequestID As Integer
        Private chrRegularityCode As String
        Private intTypeID As Integer
        Private decUnitPrice As Decimal
        Private strCurrency As String
        Private strCreatedDate As String
        Private bytAccepted As Byte
        Private strNote As String
        Private bytRenewed As Byte
        Private decIssuePrice As Decimal
        Private strISBN As String
        Private strISSN As String
        Private strEdition As String
        Private intUrgency As Integer
        Private strSerialCode As String
        Private strPubYear As String
        Private strValidSubscribedDate As String
        Private strExpiredSubscribedDate As String
        Private intLanguageID As Integer
        Private strRequester As String
        Private bytAcquired As Byte
        Private intCountryID As Integer
        Private strPublisher As String
        Private intIssues As Integer
        Private intAcceptedCopies As Integer
        Private intReceivedCopies As Integer
        Private intRequestedCopies As Integer
        Private strAuthor As String
        Private intItemID As Integer
        Private strTitle As String
        Private intMediumID As Integer
        Private strFromDate As String
        Private strToDate As String
        Private strHaveFields As String
        Private intPOID As Integer
        Private intStatusID As Integer
        Private strSetDate As String
        Private intItemTypeID As Integer
        Private strAdditionalBy As String
        Private intAcqSourceID As Integer
        Private intLoanTypeID As Integer
        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' POID property
        Public Property POID() As Integer
            Get
                Return (intPOID)
            End Get
            Set(ByVal Value As Integer)
                intPOID = Value
            End Set
        End Property

        ' StatusID property
        Public Property StatusID() As Integer
            Get
                Return (intStatusID)
            End Get
            Set(ByVal Value As Integer)
                intStatusID = Value
            End Set
        End Property

        ' SetDate property 
        Public Property SetDate() As String
            Get
                Return (strSetDate)
            End Get
            Set(ByVal Value As String)
                strSetDate = Value
            End Set
        End Property

        ' ItemTypeID property
        Public Property ItemTypeID() As Integer
            Get
                Return intItemTypeID
            End Get
            Set(ByVal Value As Integer)
                intItemTypeID = Value
            End Set
        End Property

        ' FromDate property
        Public Property FromDate() As String
            Get
                Return (strFromDate)
            End Get
            Set(ByVal Value As String)
                strFromDate = Value
            End Set
        End Property

        ' ToDate property
        Public Property ToDate() As String
            Get
                Return (strToDate)
            End Get
            Set(ByVal Value As String)
                strToDate = Value
            End Set
        End Property

        ' HaveFields property
        Public Property HaveFields() As String
            Get
                Return (strHaveFields)
            End Get
            Set(ByVal Value As String)
                strHaveFields = Value
            End Set
        End Property

        ' RequestID property
        Public Property RequestID() As Integer
            Get
                Return intRequestID
            End Get
            Set(ByVal Value As Integer)
                intRequestID = Value
            End Set
        End Property

        ' RegularityCode property
        Public Property RegularityCode() As String
            Get
                Return chrRegularityCode
            End Get
            Set(ByVal Value As String)
                chrRegularityCode = Value
            End Set
        End Property

        ' TypeID property
        Public Property TypeID() As Integer
            Get
                Return intTypeID
            End Get
            Set(ByVal Value As Integer)
                intTypeID = Value
            End Set
        End Property

        ' UnitPrice property
        Public Property UnitPrice() As Decimal
            Get
                Return decUnitPrice
            End Get
            Set(ByVal Value As Decimal)
                decUnitPrice = Value
            End Set
        End Property

        ' Currency property
        Public Property Currency() As String
            Get
                Return strCurrency
            End Get
            Set(ByVal Value As String)
                strCurrency = Value
            End Set
        End Property

        ' CreatedDate property
        Public Property CreatedDate() As String
            Get
                Return strCreatedDate
            End Get
            Set(ByVal Value As String)
                strCreatedDate = Value
            End Set
        End Property

        ' Accepted property
        Public Property Accepted() As Byte
            Get
                Return bytAccepted
            End Get
            Set(ByVal Value As Byte)
                bytAccepted = Value
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

        ' Renewed property
        Public Property Renewed() As Byte
            Get
                Return bytRenewed
            End Get
            Set(ByVal Value As Byte)
                bytRenewed = Value
            End Set
        End Property

        ' decIssuePrice property
        Public Property IssuePrice() As Decimal
            Get
                Return decIssuePrice
            End Get
            Set(ByVal Value As Decimal)
                decIssuePrice = Value
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

        ' Edition property
        Public Property Edition() As String
            Get
                Return strEdition
            End Get
            Set(ByVal Value As String)
                strEdition = Value
            End Set
        End Property

        ' Urgency property
        Public Property Urgency() As Integer
            Get
                Return intUrgency
            End Get
            Set(ByVal Value As Integer)
                intUrgency = Value
            End Set
        End Property

        ' SerialCode property
        Public Property SerialCode() As String
            Get
                Return strSerialCode
            End Get
            Set(ByVal Value As String)
                strSerialCode = Value
            End Set
        End Property

        ' PubYear property
        Public Property PubYear() As String
            Get
                Return strPubYear
            End Get
            Set(ByVal Value As String)
                strPubYear = Value
            End Set
        End Property

        ' ValidSubscribedDate property
        Public Property ValidSubscribedDate() As String
            Get
                Return strValidSubscribedDate
            End Get
            Set(ByVal Value As String)
                strValidSubscribedDate = Value
            End Set
        End Property

        ' ExpiredSubscribedDate property
        Public Property ExpiredSubscribedDate() As String
            Get
                Return strExpiredSubscribedDate
            End Get
            Set(ByVal Value As String)
                strExpiredSubscribedDate = Value
            End Set
        End Property

        ' LanguageID property
        Public Property LanguageID() As Integer
            Get
                Return intLanguageID
            End Get
            Set(ByVal Value As Integer)
                intLanguageID = Value
            End Set
        End Property

        ' Requester property
        Public Property Requester() As String
            Get
                Return strRequester
            End Get
            Set(ByVal Value As String)
                strRequester = Value
            End Set
        End Property

        ' Acquired property
        Public Property Acquired() As Byte
            Get
                Return bytAcquired
            End Get
            Set(ByVal Value As Byte)
                bytAcquired = Value
            End Set
        End Property

        ' CountryID property
        Public Property CountryID() As Integer
            Get
                Return intCountryID
            End Get
            Set(ByVal Value As Integer)
                intCountryID = Value
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

        ' Issues property
        Public Property Issues() As Integer
            Get
                Return intIssues
            End Get
            Set(ByVal Value As Integer)
                intIssues = Value
            End Set
        End Property

        ' AcceptedCopies property
        Public Property AcceptedCopies() As Integer
            Get
                Return intAcceptedCopies
            End Get
            Set(ByVal Value As Integer)
                intAcceptedCopies = Value
            End Set
        End Property

        ' ReceivedCopies property
        Public Property ReceivedCopies() As Integer
            Get
                Return intReceivedCopies
            End Get
            Set(ByVal Value As Integer)
                intReceivedCopies = Value
            End Set
        End Property

        ' RequestedCopies property
        Public Property RequestedCopies() As Integer
            Get
                Return intRequestedCopies
            End Get
            Set(ByVal Value As Integer)
                intRequestedCopies = Value
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

        ' ItemID property
        Public Property ItemID() As Integer
            Get
                Return intItemID
            End Get
            Set(ByVal Value As Integer)
                intItemID = Value
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

        ' MediumID property
        Public Property MediumID() As Integer
            Get
                Return intMediumID
            End Get
            Set(ByVal Value As Integer)
                intMediumID = Value
            End Set
        End Property
        ' AcqSourceID property
        Public Property AcqSourceID() As Integer
            Get
                Return intAcqSourceID
            End Get
            Set(ByVal Value As Integer)
                intAcqSourceID = Value
            End Set
        End Property
        ' LoanTypeID property
        Public Property LoanTypeID() As Integer
            Get
                Return intLoanTypeID
            End Get
            Set(ByVal Value As Integer)
                intLoanTypeID = Value
            End Set
        End Property

        ' AdditionalBy property
        Public Property AdditionalBy() As String
            Get
                Return strAdditionalBy
            End Get
            Set(value As String)
                strAdditionalBy = value
            End Set
        End Property

        Public Function Create() As Long
            Dim intRetVal As Long = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spItem_InsRequest"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@chrRegularityCode", SqlDbType.VarChar)).Value = chrRegularityCode
                                .Add(New SqlParameter("@intTypeID", SqlDbType.Int)).Value = intTypeID
                                .Add(New SqlParameter("@decUnitPrice", SqlDbType.Decimal)).Value = decUnitPrice
                                .Add(New SqlParameter("@strCurrency", SqlDbType.VarChar)).Value = strCurrency
                                .Add(New SqlParameter("@bytAccepted", SqlDbType.Bit)).Value = bytAccepted
                                .Add(New SqlParameter("@strNote", SqlDbType.NVarChar)).Value = strNote
                                .Add(New SqlParameter("@bytRenewed", SqlDbType.Bit)).Value = bytRenewed
                                .Add(New SqlParameter("@decIssuePrice", SqlDbType.Decimal)).Value = decIssuePrice
                                .Add(New SqlParameter("@strISBN", SqlDbType.VarChar)).Value = strISBN
                                .Add(New SqlParameter("@strISSN", SqlDbType.VarChar)).Value = strISSN
                                .Add(New SqlParameter("@strEdition", SqlDbType.NVarChar)).Value = strEdition
                                .Add(New SqlParameter("@intUrgency", SqlDbType.Int)).Value = intUrgency
                                .Add(New SqlParameter("@strSerialCode", SqlDbType.VarChar)).Value = strSerialCode
                                .Add(New SqlParameter("@strPubYear", SqlDbType.VarChar)).Value = strPubYear
                                .Add(New SqlParameter("@strValidSubscribedDate", SqlDbType.VarChar)).Value = strValidSubscribedDate
                                .Add(New SqlParameter("@strExpiredSubscribedDate", SqlDbType.VarChar)).Value = strExpiredSubscribedDate
                                .Add(New SqlParameter("@intLanguageID", SqlDbType.Int)).Value = intLanguageID
                                .Add(New SqlParameter("@strRequester", SqlDbType.NVarChar)).Value = strRequester
                                .Add(New SqlParameter("@bytAcquired", SqlDbType.Bit)).Value = bytAcquired
                                .Add(New SqlParameter("@intCountryID", SqlDbType.Int)).Value = intCountryID
                                .Add(New SqlParameter("@strPublisher", SqlDbType.NVarChar)).Value = strPublisher
                                .Add(New SqlParameter("@intIssues", SqlDbType.Int)).Value = intIssues
                                .Add(New SqlParameter("@intAcceptedCopies", SqlDbType.Int)).Value = intAcceptedCopies
                                .Add(New SqlParameter("@intReceivedCopies", SqlDbType.Int)).Value = intReceivedCopies
                                .Add(New SqlParameter("@intRequestedCopies", SqlDbType.Int)).Value = intRequestedCopies
                                .Add(New SqlParameter("@strAuthor", SqlDbType.NVarChar)).Value = strAuthor
                                .Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                                .Add(New SqlParameter("@strTitle", SqlDbType.NVarChar)).Value = strTitle
                                .Add(New SqlParameter("@intMediumID", SqlDbType.Int)).Value = intMediumID
                                .Add(New SqlParameter("@intItemTypeID", SqlDbType.Int)).Value = intItemTypeID
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@strAdditionalBy", SqlDbType.NVarChar)).Value = strAdditionalBy
                                .Add(New SqlParameter("@intAcqSourceID", SqlDbType.Int)).Value = intAcqSourceID
                                .Add(New SqlParameter("@intLoanTypeID", SqlDbType.Int)).Value = intLoanTypeID
                                .Add(New SqlParameter("@intRetval", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("@intRetval").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_CREATE_REQUEST"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("chrRegularityCode", OracleType.Char, 1)).Value = chrRegularityCode
                                .Add(New OracleParameter("intTypeID", OracleType.Number)).Value = intTypeID
                                .Add(New OracleParameter("decUnitPrice", OracleType.Float)).Value = decUnitPrice
                                .Add(New OracleParameter("strCurrency", OracleType.VarChar, 5)).Value = strCurrency
                                .Add(New OracleParameter("bytAccepted", OracleType.Number, 1)).Value = bytAccepted
                                .Add(New OracleParameter("strNote", OracleType.VarChar, 200)).Value = strNote
                                .Add(New OracleParameter("bytRenewed", OracleType.Number, 1)).Value = bytRenewed
                                .Add(New OracleParameter("decIssuePrice", OracleType.Float)).Value = decIssuePrice
                                .Add(New OracleParameter("strISBN", OracleType.VarChar, 64)).Value = strISBN
                                .Add(New OracleParameter("strISSN", OracleType.VarChar, 64)).Value = strISSN
                                .Add(New OracleParameter("strEdition", OracleType.VarChar, 50)).Value = strEdition
                                .Add(New OracleParameter("intUrgency", OracleType.Number)).Value = intUrgency
                                .Add(New OracleParameter("strSerialCode", OracleType.VarChar, 10)).Value = strSerialCode
                                .Add(New OracleParameter("strPubYear", OracleType.VarChar, 30)).Value = strPubYear
                                .Add(New OracleParameter("strValidSubscribedDate", OracleType.VarChar, 30)).Value = strValidSubscribedDate
                                .Add(New OracleParameter("strExpiredSubscribedDate", OracleType.VarChar, 30)).Value = strExpiredSubscribedDate
                                .Add(New OracleParameter("intLanguageID", OracleType.Number)).Value = intLanguageID
                                .Add(New OracleParameter("strRequester", OracleType.VarChar, 50)).Value = strRequester
                                .Add(New OracleParameter("bytAcquired", OracleType.Number, 1)).Value = bytAcquired
                                .Add(New OracleParameter("intCountryID", OracleType.Number)).Value = intCountryID
                                .Add(New OracleParameter("strPublisher", OracleType.VarChar, 100)).Value = strPublisher
                                .Add(New OracleParameter("intIssues", OracleType.Number)).Value = intIssues
                                .Add(New OracleParameter("intAcceptedCopies", OracleType.Number)).Value = intAcceptedCopies
                                .Add(New OracleParameter("intReceivedCopies", OracleType.Number)).Value = intReceivedCopies
                                .Add(New OracleParameter("intRequestedCopies", OracleType.Number)).Value = intRequestedCopies
                                .Add(New OracleParameter("strAuthor", OracleType.VarChar, 50)).Value = strAuthor
                                .Add(New OracleParameter("intItemID", OracleType.Number)).Value = intItemID
                                .Add(New OracleParameter("strTitle", OracleType.VarChar, 200)).Value = strTitle
                                .Add(New OracleParameter("intMediumID", OracleType.Number)).Value = intMediumID
                                .Add(New OracleParameter("intItemTypeID", OracleType.Number)).Value = intItemTypeID
                                .Add(New OracleParameter("intRetval", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("intRetval").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()

            Create = intRetVal
        End Function

        ' Method: Update
        ' Purpose: Pick items for the selected contract
        ' In: ContractID, ItemIDs
        ' Creator:  Sondp
        Public Sub Update(ByVal intContractID As Integer, ByVal strItemIDs As String)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spItem_UpdItemsForContract"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intContractID", SqlDbType.Int)).Value = intContractID
                            .Parameters.Add(New SqlParameter("@strItemIDs", SqlDbType.VarChar, 1000)).Value = strItemIDs
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_PICK_ITEMS_FOR_CONTRACT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intContractID", OracleType.Number)).Value = intContractID
                            .Parameters.Add(New OracleParameter("strItemIDs", OracleType.VarChar, 1000)).Value = strItemIDs
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        Public Function Update() As Integer
            Dim intRetVal As Integer = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spItem_UpdRequest"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intRequestID", SqlDbType.Int)).Value = intRequestID
                                .Add(New SqlParameter("@chrRegularityCode", SqlDbType.VarChar)).Value = chrRegularityCode
                                .Add(New SqlParameter("@intTypeID", SqlDbType.Int)).Value = intTypeID
                                .Add(New SqlParameter("@decUnitPrice", SqlDbType.Decimal)).Value = decUnitPrice
                                .Add(New SqlParameter("@strCurrency", SqlDbType.VarChar)).Value = strCurrency
                                .Add(New SqlParameter("@bytAccepted", SqlDbType.Bit)).Value = bytAccepted
                                .Add(New SqlParameter("@strNote", SqlDbType.NVarChar)).Value = strNote
                                .Add(New SqlParameter("@bytRenewed", SqlDbType.Bit)).Value = bytRenewed
                                .Add(New SqlParameter("@decIssuePrice", SqlDbType.Decimal)).Value = decIssuePrice
                                .Add(New SqlParameter("@strISBN", SqlDbType.VarChar)).Value = strISBN
                                .Add(New SqlParameter("@strISSN", SqlDbType.VarChar)).Value = strISSN
                                .Add(New SqlParameter("@strEdition", SqlDbType.NVarChar)).Value = strEdition
                                .Add(New SqlParameter("@intUrgency", SqlDbType.Int)).Value = intUrgency
                                .Add(New SqlParameter("@strSerialCode", SqlDbType.VarChar)).Value = strSerialCode
                                .Add(New SqlParameter("@strPubYear", SqlDbType.VarChar)).Value = strPubYear
                                .Add(New SqlParameter("@strValidSubscribedDate", SqlDbType.VarChar)).Value = strValidSubscribedDate
                                .Add(New SqlParameter("@strExpiredSubscribedDate", SqlDbType.VarChar)).Value = strExpiredSubscribedDate
                                .Add(New SqlParameter("@intLanguageID", SqlDbType.Int)).Value = intLanguageID
                                .Add(New SqlParameter("@strRequester", SqlDbType.NVarChar)).Value = strRequester
                                .Add(New SqlParameter("@bytAcquired", SqlDbType.Bit)).Value = bytAcquired
                                .Add(New SqlParameter("@intCountryID", SqlDbType.Int)).Value = intCountryID
                                .Add(New SqlParameter("@strPublisher", SqlDbType.NVarChar)).Value = strPublisher
                                .Add(New SqlParameter("@intIssues", SqlDbType.Int)).Value = intIssues
                                .Add(New SqlParameter("@intAcceptedCopies", SqlDbType.Int)).Value = intAcceptedCopies
                                .Add(New SqlParameter("@intReceivedCopies", SqlDbType.Int)).Value = intReceivedCopies
                                .Add(New SqlParameter("@intRequestedCopies", SqlDbType.Int)).Value = intRequestedCopies
                                .Add(New SqlParameter("@strAuthor", SqlDbType.NVarChar)).Value = strAuthor
                                .Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                                .Add(New SqlParameter("@strTitle", SqlDbType.NVarChar)).Value = strTitle
                                .Add(New SqlParameter("@intMediumID", SqlDbType.Int)).Value = intMediumID
                                .Add(New SqlParameter("@intItemTypeID", SqlDbType.Int)).Value = intItemTypeID
                                .Add(New SqlParameter("@strAdditionalBy", SqlDbType.NVarChar)).Value = strAdditionalBy
                                .Add(New SqlParameter("@intAcqSourceID", SqlDbType.Int)).Value = intAcqSourceID
                                .Add(New SqlParameter("@intLoanTypeID", SqlDbType.Int)).Value = intLoanTypeID
                                .Add(New SqlParameter("@intRetval", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("@intRetval").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_UPDATE_REQUEST"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intRequestID", OracleType.Number)).Value = intRequestID
                                .Add(New OracleParameter("chrRegularityCode", OracleType.Char, 1)).Value = chrRegularityCode
                                .Add(New OracleParameter("intTypeID", OracleType.Number)).Value = intTypeID
                                .Add(New OracleParameter("decUnitPrice", OracleType.Float)).Value = decUnitPrice
                                .Add(New OracleParameter("strCurrency", OracleType.VarChar)).Value = strCurrency
                                .Add(New OracleParameter("bytAccepted", OracleType.Char, 1)).Value = bytAccepted
                                .Add(New OracleParameter("strNote", OracleType.VarChar, 300)).Value = strNote
                                .Add(New OracleParameter("bytRenewed", OracleType.Char, 1)).Value = bytRenewed
                                .Add(New OracleParameter("decIssuePrice", OracleType.Float)).Value = decIssuePrice
                                .Add(New OracleParameter("strISBN", OracleType.VarChar, 50)).Value = strISBN
                                .Add(New OracleParameter("strISSN", OracleType.VarChar, 50)).Value = strISSN
                                .Add(New OracleParameter("strEdition", OracleType.VarChar, 150)).Value = strEdition
                                .Add(New OracleParameter("intUrgency", OracleType.Number)).Value = intUrgency
                                .Add(New OracleParameter("strSerialCode", OracleType.VarChar, 30)).Value = strSerialCode
                                .Add(New OracleParameter("strPubYear", OracleType.VarChar, 11)).Value = strPubYear
                                .Add(New OracleParameter("strValidSubscribedDate", OracleType.VarChar, 11)).Value = strValidSubscribedDate
                                .Add(New OracleParameter("strExpiredSubscribedDate", OracleType.VarChar, 11)).Value = strExpiredSubscribedDate
                                .Add(New OracleParameter("intLanguageID", OracleType.Number)).Value = intLanguageID
                                .Add(New OracleParameter("strRequester", OracleType.VarChar, 150)).Value = strRequester
                                .Add(New OracleParameter("bytAcquired", OracleType.Char, 1)).Value = bytAcquired
                                .Add(New OracleParameter("intCountryID", OracleType.Number)).Value = intCountryID
                                .Add(New OracleParameter("strPublisher", OracleType.VarChar, 300)).Value = strPublisher
                                .Add(New OracleParameter("intIssues", OracleType.Number)).Value = intIssues
                                .Add(New OracleParameter("intAcceptedCopies", OracleType.Number)).Value = intAcceptedCopies
                                .Add(New OracleParameter("intReceivedCopies", OracleType.Number)).Value = intReceivedCopies
                                .Add(New OracleParameter("intRequestedCopies", OracleType.Number)).Value = intRequestedCopies
                                .Add(New OracleParameter("strAuthor", OracleType.VarChar, 300)).Value = strAuthor
                                .Add(New OracleParameter("intItemID", OracleType.Number)).Value = intItemID
                                .Add(New OracleParameter("strTitle", OracleType.VarChar, 150)).Value = strTitle
                                .Add(New OracleParameter("intMediumID", OracleType.Number)).Value = intMediumID
                                .Add(New OracleParameter("intItemTypeID", OracleType.Number)).Value = intItemTypeID
                                .Add(New OracleParameter("intRetval", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("intRetval").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()

            Update = intRetVal
        End Function

        Public Function Delete() As Integer
            Call OpenConnection()
            Dim intRetval As Integer = 0 ' Integer Return value 
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        ' this store is not exist
                        .CommandText = "SP_ACQ_REQUEST_DEL"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intRequestID", SqlDbType.Int)).Value = intRequestID
                            .Add(New SqlParameter("@intRetval", SqlDbType.Int)).Direction = ParameterDirection.Output
                        End With
                        Try
                            .ExecuteNonQuery()
                            intRetval = .Parameters("@intRetval").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_REQUEST_DEL"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intRequestID", OracleType.Number)).Value = intRequestID
                        End With
                        Try
                            .ExecuteNonQuery()
                            intRetval = .Parameters("intRetval").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Delete = intRetval
        End Function

        ' Method: GetOrderItemsList
        ' Purpose: Get list of ordered items
        ' Output: datatable result
        ' Creator: Sondp
        'Public Function GetOrderItemsList() As DataTable
        '    Call OpenConnection()

        '    Select Case UCase(strDBServer)
        '        Case "SQLSERVER"
        '            With SqlCommand
        '                .CommandText = "SP_ACQ_GET_ORDER_ITEMS_LIST"
        '                .CommandType = CommandType.StoredProcedure
        '                Try
        '                    SqlDataAdapter.SelectCommand = SqlCommand
        '                    SqlDataAdapter.Fill(dsData, "tblResult")
        '                    GetOrderItemsList = dsData.Tables("tblResult")
        '                Catch sqlClientEx As SqlException
        '                    strErrorMsg = sqlClientEx.Message.ToString
        '                    intErrorCode = sqlClientEx.Number
        '                Finally
        '                    .Parameters.Clear()
        '                    dsData.Tables.Remove("tblResult")
        '                End Try
        '            End With
        '        Case "ORACLE"
        '            With OraCommand
        '                ' .CommandText = "ACQUISITION.SP_ACQ_PO_SEL_BOOKORDER"
        '                .CommandText = "ACQUISITION.SP_ACQ_GET_ORDER_ITEMS_LIST"
        '                .CommandType = CommandType.StoredProcedure
        '                Try
        '                    .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
        '                    oraDataAdapter.SelectCommand = oraCommand
        '                    oraDataAdapter.Fill(dsData, "tblResult")
        '                    GetOrderItemsList = dsData.Tables("tblResult")
        '                Catch OraEx As OracleException
        '                    strErrorMsg = OraEx.Message.ToString
        '                    intErrorCode = OraEx.Code
        '                Finally
        '                    .Parameters.Clear()
        '                    dsData.Tables.Remove("tblResult")
        '                End Try
        '            End With
        '    End Select
        '    Call CloseConnection()
        'End Function

        ' Purpose: Accepted Lib_tblItem(s)
        ' In: strIDs, strAccepted
        ' Output: Datatable
        ' Creator:  Sondp
        Public Sub AcceptedItemOrder(ByVal strIDs As String, ByVal strAccepted As String)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spItem_UpdBookOrder"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strIDs", SqlDbType.VarChar, 4000)).Value = strIDs
                                .Add(New SqlParameter("@strAccepted", SqlDbType.VarChar, 1)).Value = strAccepted
                            End With
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_PO_UPD_BOOKORDER"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strIDs", OracleType.VarChar, 4000)).Value = strIDs
                                .Add(New OracleParameter("strAccepted", OracleType.VarChar, 1)).Value = strAccepted
                            End With
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' Purpose: Get Acq_tblItem dependon POID
        ' In: strPOIDs
        ' Output: Datatable
        ' Creator:  Sondp
        Public Sub GetACQITEMbyPOID(ByVal strIDs As String, ByVal strAccepted As String)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "SP_ACQ_PO_UPD_BOOKORDER"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strIDs", SqlDbType.VarChar, 4000)).Value = strIDs
                                .Add(New SqlParameter("@strAccepted", SqlDbType.VarChar, 1)).Value = strAccepted
                            End With
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_PO_UPD_BOOKORDER"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strIDs", OracleType.VarChar, 4000)).Value = strIDs
                                .Add(New OracleParameter("strAccepted", OracleType.VarChar, 1)).Value = strAccepted
                            End With
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' Purpose: Delete Lib_tblItem(s) oder
        ' In: strIDs
        ' Output: 
        ' Creator:  Sondp
        Public Sub DeleteItemOrder(ByVal strIDs As String)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spPO_Item_DelBookOrder"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strIDs", SqlDbType.VarChar, 4000)).Value = strIDs
                            End With
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_PO_DEL_BOOKORDER"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strIDs", OracleType.VarChar, 4000)).Value = strIDs
                            End With
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' Method: GetOrderItems
        ' Purpose: get list of items order
        ' Input: TypeID, RequestID
        ' Output: Datatable result
        ' Creator:  Oanhtn
        Public Function GetOrderItems() As DataTable
            Call OpenConnection()

            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spItem_SelOrderItems"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intRequestID", SqlDbType.Int)).Value = intRequestID
                            .Parameters.Add(New SqlParameter("@intTypeID", SqlDbType.Int)).Value = intTypeID
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            SqlDataAdapter = New SqlDataAdapter(SqlCommand)
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetOrderItems = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_GET_ORDER_ITEMS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intRequestID", OracleType.Number)).Value = intRequestID
                            .Parameters.Add(New OracleParameter("intTypeID", OracleType.Number)).Value = intTypeID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter = New OracleDataAdapter(oraCommand)
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetOrderItems = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose: Get all publisher from Acq_tblItem
        ' In: 
        ' Output: Datatable
        ' Creator:  Sondp
        Public Function GetAcqPublisher() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spItem_SelPublisher"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetAcqPublisher = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_ITEM_GET_PUBLISHER"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetAcqPublisher = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose: Get print Acqusition report
        ' In: Some informations
        ' Output: Datatable
        ' Creator:  Sondp
        Public Function GetAcqItems() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spPO_SelPOItems"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intAccepted", SqlDbType.Int, 4)).Value = CInt(bytAccepted)
                                .Add(New SqlParameter("@strPublisher", SqlDbType.NVarChar, 250)).Value = strPublisher
                                .Add(New SqlParameter("@intItemTypeID", SqlDbType.Int, 4)).Value = intTypeID
                                .Add(New SqlParameter("@intMediumID", SqlDbType.Int, 4)).Value = intMediumID
                                .Add(New SqlParameter("@intUrgency", SqlDbType.Int, 4)).Value = intUrgency
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@strFromDate", SqlDbType.VarChar, 14)).Value = strFromDate
                                .Add(New SqlParameter("@strToDate", SqlDbType.VarChar, 14)).Value = strToDate
                                .Add(New SqlParameter("@strCurrency", SqlDbType.VarChar, 10)).Value = strCurrency
                                .Add(New SqlParameter("@strHaveFields", SqlDbType.VarChar, 2000)).Value = strHaveFields
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetAcqItems = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_PO_GET_ACQITEMS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intAccepted", OracleType.Number, 4)).Value = CInt(bytAccepted)
                                .Add(New OracleParameter("strPublisher", OracleType.VarChar, 250)).Value = strPublisher
                                .Add(New OracleParameter("intItemTypeID", OracleType.Number, 4)).Value = intTypeID
                                .Add(New OracleParameter("intMediumID", OracleType.Number, 4)).Value = intMediumID
                                .Add(New OracleParameter("intUrgency", OracleType.Number, 4)).Value = intUrgency
                                .Add(New OracleParameter("strFromDate", OracleType.VarChar, 14)).Value = strFromDate
                                .Add(New OracleParameter("strToDate", OracleType.VarChar, 14)).Value = strToDate
                                .Add(New OracleParameter("strCurrency", OracleType.VarChar, 10)).Value = strCurrency
                                .Add(New OracleParameter("strHaveFields", OracleType.VarChar, 2000)).Value = strHaveFields
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetAcqItems = dsData.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose: Get list of waitting PO
        ' Output: Datatable result
        ' Creator:  Sondp
        Public Function GetWaittingPO() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spPO_SelWaitingPO"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetWaittingPO = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_GET_WAITING_PO"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetWaittingPO = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose: Get Acq_tblItem by PO 
        ' In: strPOIDs
        ' Output: Datatable
        ' Creator:  Sondp
        Public Function GetACQITEMbyPOID(ByVal strPOIDs As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spItem_SelByPO"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strPOIDs", SqlDbType.VarChar, 1000)).Value = strPOIDs
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetACQITEMbyPOID = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_GET_ACQITEM_BY_PO"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strPOIDs", OracleType.VarChar, 1000)).Value = strPOIDs
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetACQITEMbyPOID = dsData.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose: Get PO and Vendor infor
        ' In: intPOID, strHaveFields
        ' Output: Datatable
        ' Creator:  Sondp
        Public Function GetPOandVendorInfor(ByVal intPOID As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spVendor_SelInfor"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intPOID", SqlDbType.Int, 4)).Value = intPOID
                            .Parameters.Add(New SqlParameter("@strHaveFields", SqlDbType.VarChar, 4000)).Value = strHaveFields
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetPOandVendorInfor = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_GET_PO_VENDOR_INF"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intPOID", OracleType.Number, 4)).Value = intPOID
                            .Parameters.Add(New OracleParameter("strHaveFields", OracleType.VarChar, 4000)).Value = strHaveFields
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetPOandVendorInfor = dsData.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose: Get seperated store items
        ' In: itnTop, intPOID, strHaveFields
        ' Output: Datatable
        ' Creator:  Sondp
        Public Function GetSeperatedStoreItems(ByVal intTop As Integer, ByVal intPOID As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spItem_SelLocItems"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intTop", SqlDbType.Int, 4)).Value = intTop
                                .Add(New SqlParameter("@intPOID", SqlDbType.Int, 4)).Value = intPOID
                                .Add(New SqlParameter("@strHaveFields", SqlDbType.VarChar, 4000)).Value = strHaveFields
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetSeperatedStoreItems = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_GET_SEPLOC_ITEMS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intTop", OracleType.Number, 4)).Value = intTop
                                .Add(New OracleParameter("intPOID", OracleType.Number, 4)).Value = intPOID
                                .Add(New OracleParameter("strHaveFields", OracleType.VarChar, 4000)).Value = strHaveFields
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetSeperatedStoreItems = dsData.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose: Get Holding Library and Location data
        ' In: intFalge, intPOID
        ' Output: Datatable
        ' Creator:  Sondp
        Public Function GetHolLibLoc(ByVal intFlage As Integer, ByVal intPOID As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHolding_SelLocLibHol"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intFlage", SqlDbType.Int, 4)).Value = intFlage
                                .Add(New SqlParameter("@intPOID", SqlDbType.Int, 4)).Value = intPOID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetHolLibLoc = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_GET_SEPLOC_LIBHOL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intFlage", OracleType.Number, 4)).Value = intFlage
                                .Add(New OracleParameter("intPOID", OracleType.Number, 4)).Value = intPOID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetHolLibLoc = dsData.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose: Get Acq_tblPo
        ' In: intID
        ' Output: Datatable
        ' Creator:  Sondp
        Public Function GetAcqPO(ByVal intPOID As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spPO_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intID", SqlDbType.Int, 4)).Value = intPOID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetAcqPO = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_GET_ACQ_PO"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intID", OracleType.Number, 4)).Value = intPOID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetAcqPO = dsData.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose: Get Acq status
        ' In: 
        ' Output: Datatable
        ' Creator:  Sonnt
        Public Function GetAcqStatus() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spStatus_SelAllOrderById"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetAcqStatus = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_STATUS_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetAcqStatus = dsData.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose: Insert one record into Acq_tblPo_Status table
        ' In: Some infor
        ' Creator:  Sonnt
        ' CreatedDate: 07/04/2005
        Public Sub InsertAcqPoStatus()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_PO_STATUS_INS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intPoID", OracleType.Number)).Value = intPOID
                                .Add(New OracleParameter("intStatusID", OracleType.Number)).Value = intStatusID
                                .Add(New OracleParameter("strSetDate", OracleType.VarChar)).Value = strSetDate
                                .Add(New OracleParameter("strNote", OracleType.VarChar)).Value = strNote
                                .Add(New OracleParameter("strSQL", OracleType.VarChar, 500)).Direction = ParameterDirection.Output
                            End With
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
                        .CommandText = "Acq_spPO_Status_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intPoID", SqlDbType.Int)).Value = intPOID
                                .Add(New SqlParameter("@intStatusID", SqlDbType.Int)).Value = intStatusID
                                .Add(New SqlParameter("@strSetDate", SqlDbType.VarChar)).Value = strSetDate
                                .Add(New SqlParameter("@strNote", SqlDbType.VarChar)).Value = strNote
                                .Add(New SqlParameter("@strSQL", SqlDbType.NVarChar, 500)).Direction = ParameterDirection.Output
                            End With
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

        Public Sub SetItemID4AcqItem(ByVal intItemID As Integer, ByVal intACQID As Integer)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_SET_ITEMID_FOR_ACQITEM"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intItemID", OracleType.Number)).Value = intItemID
                                .Add(New OracleParameter("intACQItemID", OracleType.Number)).Value = intACQID
                            End With
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
                        .CommandText = "Ser_spItem_UpdItemIdForAqcItem"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                                .Add(New SqlParameter("@intACQItemID", SqlDbType.Int)).Value = intACQID
                            End With
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

        ' ****************************************************************************
        ' Serial
        ' ****************************************************************************

        ' Method: GetSerialRequestList
        ' Purpose: get list of acquired serial requests
        ' Output: datatable result
        Public Function GetSerialRequestList(ByVal intType As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_SER_GET_REQUEST_LIST"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intType", OracleType.Number)).Value = intType
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsdata, "tblResult")
                            GetSerialRequestList = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ser_spGetRequestList"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intType", SqlDbType.Int)).Value = intType
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsdata, "tblResult")
                            GetSerialRequestList = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
        End Function

        ' Method: Dispose
        ' Purpose: Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                Call MyBase.Dispose(isDisposing)
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace