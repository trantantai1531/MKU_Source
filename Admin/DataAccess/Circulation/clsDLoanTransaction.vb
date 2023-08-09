Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Circulation
    Public Class clsDLoanTransaction
        Inherits clsDBaseTransaction

        ' *****************************************************************************************************
        ' Declare member variables
        ' *****************************************************************************************************

        Private strCheckOutDate As String
        Private strCheckInDate As String
        Private strDueDate As String
        Private strTimeOutDate As String
        Private strRenewDate As String
        Private strRecallDate As String
        Private intLoanTypeID As Integer
        Private intLibID As Int16

        Private intLoanMode As Int16
        Private intStatus As Int16
        Private strStatisticType As String
        Private strMonth As String
        Private strYear As String
        Private strDay As String
        Private intOptItemID As Int16
        Private intHistory As Integer
        Private intSimple As Integer

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************
        ' History property
        Public Property History() As Integer
            Get
                Return intHistory
            End Get
            Set(ByVal Value As Integer)
                intHistory = Value
            End Set
        End Property

        Public Property Simple() As Integer
            Get
                Return intSimple
            End Get
            Set(ByVal Value As Integer)
                intSimple = Value
            End Set
        End Property

        ' LoanTypeID property
        Public Property OptItemID() As Int16
            Get
                Return intOptItemID
            End Get
            Set(ByVal Value As Int16)
                intOptItemID = Value
            End Set
        End Property
        ' CheckOutDate property
        Public Property CheckOutDate() As String
            Get
                Return strCheckOutDate
            End Get
            Set(ByVal Value As String)
                strCheckOutDate = Value
            End Set
        End Property

        ' CheckInDate property
        Public Property CheckInDate() As String
            Get
                Return strCheckInDate
            End Get
            Set(ByVal Value As String)
                strCheckInDate = Value
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

        ' TimeOutDate property
        Public Property TimeOutDate() As String
            Get
                Return strTimeOutDate
            End Get
            Set(ByVal Value As String)
                strTimeOutDate = Value
            End Set
        End Property

        ' RenewDate property
        Public Property RenewDate() As String
            Get
                Return strRenewDate
            End Get
            Set(ByVal Value As String)
                strRenewDate = Value
            End Set
        End Property

        ' RecallDate property
        Public Property RecallDate() As String
            Get
                Return strRecallDate
            End Get
            Set(ByVal Value As String)
                strRecallDate = Value
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

        ' LoanMode property
        Public Property LoanMode() As Int16
            Get
                Return intLoanMode
            End Get
            Set(ByVal Value As Int16)
                intLoanMode = Value
            End Set
        End Property

        ' Status property
        Property Status() As Integer
            Get
                Return intStatus
            End Get
            Set(ByVal Value As Integer)
                intStatus = Value
            End Set
        End Property

        ' StatisticType property
        Property StatisticType() As String
            Get
                Return strStatisticType
            End Get
            Set(ByVal Value As String)
                strStatisticType = Value
            End Set
        End Property

        ' GetYear property
        Property GetYear() As String
            Get
                Return strYear
            End Get
            Set(ByVal Value As String)
                strYear = Value
            End Set
        End Property

        ' GetMonth property
        Property GetMonth() As String
            Get
                Return strMonth
            End Get
            Set(ByVal Value As String)
                strMonth = Value
            End Set
        End Property

        ' GetDay property
        Property GetDay() As String
            Get
                Return strDay
            End Get
            Set(ByVal Value As String)
                strDay = Value
            End Set
        End Property

        ' LibID property
        Public Property LibID() As Int16
            Get
                Return intLibID
            End Get
            Set(ByVal Value As Int16)
                intLibID = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' GetLoanInfor function 
        ' Purpose: Get loan infor of the selected Patron
        ' Input: strPatronCode
        ' Output: datatable result
        Public Function GetLoanInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_GET_PATRON_LOAN_INFOR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strPatronCode", OracleType.VarChar, 30)).Value = strPatronCode
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetLoanInfor = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatron_SelLoanInfor"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar)).Value = strPatronCode
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetLoanInfor = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' GetLoanDetailInfor function
        ' Purpose: Get loan information in detail of the selected patron
        ' Input: PatronCode, LoanMode, Mode
        ' Output: datatable result
        Public Function GetLoanDetailInfor(ByVal intMode As Int16) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_GET_PATRON_LOAN_DETAILINFOR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strPatronCode", OracleType.VarChar, 30)).Value = strPatronCode
                            .Parameters.Add(New OracleParameter("intLoanMode", OracleType.Number)).Value = intLoanMode
                            .Parameters.Add(New OracleParameter("intMode", OracleType.Number)).Value = intMode
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetLoanDetailInfor = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatron_SelLoanDetailInfor"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar)).Value = strPatronCode
                            .Parameters.Add(New SqlParameter("@intLoanMode", SqlDbType.Int)).Value = intLoanMode
                            .Parameters.Add(New SqlParameter("@intMode", SqlDbType.Int)).Value = intMode
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetLoanDetailInfor = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function GetLoanDetailInforFull(ByVal intMode As Int16) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    'With oraCommand
                    '    .CommandText = "CIRCULATION.SP_GET_PATRON_LOAN_DETAILINFORFULL"
                    '    .CommandType = CommandType.StoredProcedure
                    '    Try
                    '        .Parameters.Add(New OracleParameter("strPatronCode", OracleType.VarChar, 30)).Value = strPatronCode
                    '        .Parameters.Add(New OracleParameter("intLoanMode", OracleType.Number)).Value = intLoanMode
                    '        .Parameters.Add(New OracleParameter("intMode", OracleType.Number)).Value = intMode
                    '        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                    '        oraDataAdapter.SelectCommand = oraCommand
                    '        oraDataAdapter.Fill(dsData, "tblResult")
                    '        GetLoanDetailInforFull = dsData.Tables("tblResult")
                    '        dsData.Tables.Remove("tblResult")
                    '    Catch OraEx As OracleException
                    '        strErrorMsg = OraEx.Message
                    '        intErrorCode = OraEx.Code
                    '    Finally
                    '        .Parameters.Clear()
                    '    End Try
                    'End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spPatron_SelLoanDetailInforFull"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar)).Value = strPatronCode
                            .Parameters.Add(New SqlParameter("@intMode", SqlDbType.Int)).Value = intMode
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetLoanDetailInforFull = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function


        ' CheckIn method
        ' Purpose: CheckIn selected onloan copies
        ' Input: some informations for checkin
        ' Output: intvalue (0 if success)
        Public Function CheckIn(ByVal strCopyNumbers As String, ByVal intAutoPaidFees As Int16) As Int16
            Dim intError As Int16 = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_CHECKIN"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intAutoPaid", OracleType.Number)).Value = intAutoPaidFees
                            .Parameters.Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                            .Parameters.Add(New OracleParameter("strCopyNumbers", OracleType.VarChar, 300)).Value = strCopyNumbers
                            .Parameters.Add(New OracleParameter("strCheckInDate", OracleType.VarChar, 30)).Value = strCheckInDate
                            .Parameters.Add(New OracleParameter("strPatronCode", OracleType.VarChar, 30)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("strTransIDs", OracleType.VarChar, 300)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("intError", OracleType.VarChar, Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intError = .Parameters("intError").Value
                            If Not IsDBNull(.Parameters("strPatronCode").Value) Then
                                strPatronCode = .Parameters("strPatronCode").Value
                            Else
                                strPatronCode = ""
                            End If
                            If Not IsDBNull(.Parameters("strTransIDs").Value) Then
                                strTransactionIDs = .Parameters("strTransIDs").Value
                            Else
                                strTransactionIDs = ""
                            End If
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spHolding_CheckIn"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intAutoPaid", SqlDbType.Int)).Value = intAutoPaidFees
                            .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                            .Parameters.Add(New SqlParameter("@strCopyNumbers", SqlDbType.VarChar, 300)).Value = strCopyNumbers
                            .Parameters.Add(New SqlParameter("@strCheckInDate", SqlDbType.VarChar, 30)).Value = strCheckInDate
                            .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 30)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@strTransIDs", SqlDbType.VarChar, 300)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@intError", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intError = .Parameters("@intError").Value
                            strPatronCode = .Parameters("@strPatronCode").Value
                            strTransactionIDs = .Parameters("@strTransIDs").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            CheckIn = intError
            Call CloseConnection()
        End Function

        Public Function CheckIn(ByVal strCopyNumbers As String, ByVal intAutoPaidFees As Int16, ByVal strCataloguerName As String) As Int16
            Dim intError As Int16 = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spHolding_CheckIn_CataloguerName"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intAutoPaid", SqlDbType.Int)).Value = intAutoPaidFees
                            .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                            .Parameters.Add(New SqlParameter("@strCopyNumbers", SqlDbType.VarChar, 300)).Value = strCopyNumbers
                            .Parameters.Add(New SqlParameter("@strCheckInDate", SqlDbType.VarChar, 30)).Value = strCheckInDate
                            .Parameters.Add(New SqlParameter("@strCataloguerName", SqlDbType.NVarChar, 100)).Value = strCataloguerName
                            .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 30)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@strTransIDs", SqlDbType.VarChar, 300)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@intError", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intError = .Parameters("@intError").Value
                            strPatronCode = .Parameters("@strPatronCode").Value
                            strTransactionIDs = .Parameters("@strTransIDs").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            CheckIn = intError
            Call CloseConnection()
        End Function

        Public Function UpdateLoanModePatron(ByVal intPatronID As Integer) As Integer
            Dim intResult As Integer = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    'With oraCommand
                    '    .CommandText = "CIRCULATION.SP_CHECKIN"
                    '    .CommandType = CommandType.StoredProcedure
                    '    Try
                    '        .Parameters.Add(New OracleParameter("intAutoPaid", OracleType.Number)).Value = intAutoPaidFees
                    '        .ExecuteNonQuery()
                    '        intError = .Parameters("intError").Value
                    '        If Not IsDBNull(.Parameters("strPatronCode").Value) Then
                    '            strPatronCode = .Parameters("strPatronCode").Value
                    '        Else
                    '            strPatronCode = ""
                    '        End If
                    '        If Not IsDBNull(.Parameters("strTransIDs").Value) Then
                    '            strTransactionIDs = .Parameters("strTransIDs").Value
                    '        Else
                    '            strTransactionIDs = ""
                    '        End If
                    '    Catch OraEx As OracleException
                    '        strErrorMsg = OraEx.Message
                    '        intErrorCode = OraEx.Code
                    '    Finally
                    '        .Parameters.Clear()
                    '    End Try
                    'End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spLoan_UpdateLoanMode_ByPatronId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intPatronID", SqlDbType.Int)).Value = intPatronID
                            .ExecuteNonQuery()
                            intResult = 1
                        Catch sqlClientEx As SqlException
                            intResult = 0
                            strErrorMsg = sqlClientEx.Message
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            UpdateLoanModePatron = intResult
            Call CloseConnection()
        End Function

        ' RecallCopies method
        ' Purpose: If items are returned right after being checked out, they will be removed from the receipt. These cancelled checkouts are not recorded in loan history.
        ' Input: lngTransactionID
        Public Sub RecallCopies()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_RECALLCOPIES"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngTransactionID", OracleType.Number)).Value = lngTransactionID
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ser_spRecallCopies"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngTransactionID", SqlDbType.Int)).Value = lngTransactionID
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub


        ' CheckOut method
        ' Purpose: Checkout CopyNumber
        ' Input: some main information for transaction
        Public Function CheckOut(ByVal intHoldIgnore As Integer) As Integer
            Dim intOutValue As Integer = 0
            Dim intOutID As Integer = 0

            Call BeginTrans()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_CHECKOUT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            '.Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = lngItemID
                            '.Parameters.Add(New OracleParameter("intLocationID", OracleType.Number)).Value = lngLocationID
                            .Parameters.Add(New OracleParameter("strPatronCode", SqlDbType.VarChar, 30)).Value = strPatronCode
                            .Parameters.Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                            .Parameters.Add(New OracleParameter("intLoanMode", OracleType.Number)).Value = intLoanMode
                            .Parameters.Add(New OracleParameter("strCopyNumber", OracleType.VarChar, 30)).Value = strCopyNumber
                            .Parameters.Add(New OracleParameter("strDueDate", OracleType.VarChar, 30)).Value = strDueDate
                            .Parameters.Add(New OracleParameter("strCheckOutDate", OracleType.VarChar, 30)).Value = strCheckOutDate
                            .Parameters.Add(New OracleParameter("intHoldIgnore", OracleType.Number)).Value = intHoldIgnore
                            .Parameters.Add(New OracleParameter("intOutValue", OracleType.Number)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("intOutID", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intOutValue = .Parameters("intOutValue").Value
                            intOutID = .Parameters("intOutID").Value
                            CheckOut = intOutValue
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spHolding_CheckOut"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            '.Parameters.Add(New SqlParameter("@lngItemID", SqlDbType.Int)).Value = lngItemID
                            '.Parameters.Add(New SqlParameter("@lngLocationID", SqlDbType.Int)).Value = lngLocationID
                            .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar)).Value = strPatronCode
                            .Parameters.Add(New SqlParameter("@intLoanMode", SqlDbType.Int)).Value = intLoanMode
                            .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                            .Parameters.Add(New SqlParameter("@strCopyNumber", SqlDbType.VarChar)).Value = strCopyNumber
                            .Parameters.Add(New SqlParameter("@strDueDate", SqlDbType.VarChar)).Value = strDueDate
                            .Parameters.Add(New SqlParameter("@strCheckOutDate", SqlDbType.VarChar)).Value = strCheckOutDate
                            .Parameters.Add(New SqlParameter("@intHoldIgnore", SqlDbType.Int)).Value = intHoldIgnore
                            .Parameters.Add(New SqlParameter("@intOutValue", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@intOutID", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intOutValue = .Parameters("@intOutValue").Value
                            intOutID = .Parameters("@intOutID").Value
                            CheckOut = intOutValue
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select

            lngTransactionID = intOutID
            If strErrorMsg = "" Then
                Call CommitTrans()
            Else
                Call RollBackTrans()
            End If
        End Function

        Public Function CheckOut(ByVal intHoldIgnore As Integer, ByVal intRadLoanType As Integer) As Integer
            Dim intOutValue As Integer = 0
            Dim intOutID As Integer = 0

            Call BeginTrans()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_CHECKOUTOther"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            '.Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = lngItemID
                            '.Parameters.Add(New OracleParameter("intLocationID", OracleType.Number)).Value = lngLocationID
                            .Parameters.Add(New OracleParameter("strPatronCode", SqlDbType.VarChar, 30)).Value = strPatronCode
                            .Parameters.Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                            .Parameters.Add(New OracleParameter("intLoanMode", OracleType.Number)).Value = intLoanMode
                            .Parameters.Add(New OracleParameter("strCopyNumber", OracleType.VarChar, 30)).Value = strCopyNumber
                            .Parameters.Add(New OracleParameter("strDueDate", OracleType.VarChar, 30)).Value = strDueDate
                            .Parameters.Add(New OracleParameter("intRadLoanType", OracleType.Number)).Value = intRadLoanType
                            .Parameters.Add(New OracleParameter("strCheckOutDate", OracleType.VarChar, 30)).Value = strCheckOutDate
                            .Parameters.Add(New OracleParameter("intHoldIgnore", OracleType.Number)).Value = intHoldIgnore
                            .Parameters.Add(New OracleParameter("intOutValue", OracleType.Number)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("intOutID", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intOutValue = .Parameters("intOutValue").Value
                            intOutID = .Parameters("intOutID").Value
                            CheckOut = intOutValue
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spHolding_CheckOutOther"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            '.Parameters.Add(New SqlParameter("@lngItemID", SqlDbType.Int)).Value = lngItemID
                            '.Parameters.Add(New SqlParameter("@lngLocationID", SqlDbType.Int)).Value = lngLocationID
                            .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar)).Value = strPatronCode
                            .Parameters.Add(New SqlParameter("@intLoanMode", SqlDbType.Int)).Value = intLoanMode
                            .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                            .Parameters.Add(New SqlParameter("@intRadLoanType", SqlDbType.Int)).Value = intRadLoanType
                            .Parameters.Add(New SqlParameter("@strCopyNumber", SqlDbType.VarChar)).Value = strCopyNumber
                            .Parameters.Add(New SqlParameter("@strDueDate", SqlDbType.VarChar)).Value = strDueDate
                            .Parameters.Add(New SqlParameter("@strCheckOutDate", SqlDbType.VarChar)).Value = strCheckOutDate
                            .Parameters.Add(New SqlParameter("@intHoldIgnore", SqlDbType.Int)).Value = intHoldIgnore
                            .Parameters.Add(New SqlParameter("@intOutValue", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@intOutID", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intOutValue = .Parameters("@intOutValue").Value
                            intOutID = .Parameters("@intOutID").Value
                            CheckOut = intOutValue
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select

            lngTransactionID = intOutID
            If strErrorMsg = "" Then
                Call CommitTrans()
            Else
                Call RollBackTrans()
            End If
        End Function

        Public Function CheckOut(ByVal intHoldIgnore As Integer, ByVal intRadLoanType As Integer, ByVal strCataloguerName As String) As Integer
            Dim intOutValue As Integer = 0
            Dim intOutID As Integer = 0

            Call BeginTrans()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spHolding_CheckOutOther_CataloguerName"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            '.Parameters.Add(New SqlParameter("@lngItemID", SqlDbType.Int)).Value = lngItemID
                            '.Parameters.Add(New SqlParameter("@lngLocationID", SqlDbType.Int)).Value = lngLocationID
                            .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar)).Value = strPatronCode
                            .Parameters.Add(New SqlParameter("@intLoanMode", SqlDbType.Int)).Value = intLoanMode
                            .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                            .Parameters.Add(New SqlParameter("@intRadLoanType", SqlDbType.Int)).Value = intRadLoanType
                            .Parameters.Add(New SqlParameter("@strCopyNumber", SqlDbType.VarChar)).Value = strCopyNumber
                            .Parameters.Add(New SqlParameter("@strDueDate", SqlDbType.VarChar)).Value = strDueDate
                            .Parameters.Add(New SqlParameter("@strCheckOutDate", SqlDbType.VarChar)).Value = strCheckOutDate
                            .Parameters.Add(New SqlParameter("@strCataloguerName", SqlDbType.NVarChar, 100)).Value = strCataloguerName
                            .Parameters.Add(New SqlParameter("@intHoldIgnore", SqlDbType.Int)).Value = intHoldIgnore
                            .Parameters.Add(New SqlParameter("@intOutValue", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@intOutID", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intOutValue = .Parameters("@intOutValue").Value
                            intOutID = .Parameters("@intOutID").Value
                            CheckOut = intOutValue
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select

            lngTransactionID = intOutID
            If strErrorMsg = "" Then
                Call CommitTrans()
            Else
                Call RollBackTrans()
            End If
        End Function

        Public Function CheckPermissionPatronGroupLoanType() As Integer
            Dim intOut As Integer = 0
            Call BeginTrans()
            With sqlCommand
                .CommandText = "Cir_permission_PatronGroup_LoanType"
                .CommandType = CommandType.StoredProcedure
                Try
                    .Parameters.Add(New SqlParameter("@strCopyNumber", SqlDbType.VarChar)).Value = strCopyNumber
                    .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar)).Value = strPatronCode
                    .Parameters.Add(New SqlParameter("@intOut", SqlDbType.Int)).Direction = ParameterDirection.Output
                    .ExecuteNonQuery()
                    intOut = .Parameters("@intOut").Value
                    CheckPermissionPatronGroupLoanType = intOut
                Catch sqlClientEx As SqlException
                    strErrorMsg = sqlClientEx.Message
                    intErrorCode = sqlClientEx.Number
                Finally
                    .Parameters.Clear()
                End Try
            End With
            If strErrorMsg = "" Then
                Call CommitTrans()
            Else
                Call RollBackTrans()
            End If
        End Function
        Public Function CheckOutOther(ByVal intHoldIgnore As Integer) As Integer
            Dim intOutValue As Integer = 0
            Dim intOutID As Integer = 0

            Call BeginTrans()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_CHECKOUT_Other"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            '.Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = lngItemID
                            '.Parameters.Add(New OracleParameter("intLocationID", OracleType.Number)).Value = lngLocationID
                            .Parameters.Add(New OracleParameter("strPatronCode", SqlDbType.VarChar, 30)).Value = strPatronCode
                            .Parameters.Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                            .Parameters.Add(New OracleParameter("intLoanMode", OracleType.Number)).Value = intLoanMode
                            .Parameters.Add(New OracleParameter("strCopyNumber", OracleType.VarChar, 30)).Value = strCopyNumber
                            .Parameters.Add(New OracleParameter("strDueDate", OracleType.VarChar, 30)).Value = strDueDate
                            .Parameters.Add(New OracleParameter("strCheckOutDate", OracleType.VarChar, 30)).Value = strCheckOutDate
                            .Parameters.Add(New OracleParameter("intHoldIgnore", OracleType.Number)).Value = intHoldIgnore
                            .Parameters.Add(New OracleParameter("intOutValue", OracleType.Number)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("intOutID", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intOutValue = .Parameters("intOutValue").Value
                            intOutID = .Parameters("intOutID").Value
                            CheckOutOther = intOutValue
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spHolding_CheckOut_Other"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            '.Parameters.Add(New SqlParameter("@lngItemID", SqlDbType.Int)).Value = lngItemID
                            '.Parameters.Add(New SqlParameter("@lngLocationID", SqlDbType.Int)).Value = lngLocationID
                            .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar)).Value = strPatronCode
                            .Parameters.Add(New SqlParameter("@intLoanMode", SqlDbType.Int)).Value = intLoanMode
                            .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                            .Parameters.Add(New SqlParameter("@strCopyNumber", SqlDbType.VarChar)).Value = strCopyNumber
                            .Parameters.Add(New SqlParameter("@strDueDate", SqlDbType.VarChar)).Value = strDueDate
                            .Parameters.Add(New SqlParameter("@strCheckOutDate", SqlDbType.VarChar)).Value = strCheckOutDate
                            .Parameters.Add(New SqlParameter("@intHoldIgnore", SqlDbType.Int)).Value = intHoldIgnore
                            .Parameters.Add(New SqlParameter("@intOutValue", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@intOutID", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intOutValue = .Parameters("@intOutValue").Value
                            intOutID = .Parameters("@intOutID").Value
                            CheckOutOther = intOutValue
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select

            lngTransactionID = intOutID
            If strErrorMsg = "" Then
                Call CommitTrans()
            Else
                Call RollBackTrans()
            End If
        End Function

        ' CreateAnnualStatistic function
        ' Purpose: Statistic Year
        Public Function CreateAnnualStatistic() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_STAT_LOANYEARS"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("OptItemID", OracleType.Number)).Value = intOptItemID
                        .Parameters.Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                        .Parameters.Add(New OracleParameter("intHistory", OracleType.Number)).Value = intHistory
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            CreateAnnualStatistic = dsData.Tables("tblResult")
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
                        .CommandText = "Cir_spStatLoanYear"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@OptItemID", SqlDbType.Int)).Value = intOptItemID
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                        .Parameters.Add(New SqlParameter("@intHistory", SqlDbType.Int)).Value = intHistory
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            CreateAnnualStatistic = dsData.Tables("tblResult")
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

        Public Function CreateAnnualStatisticEx(Optional fromCheckOutDate As DateTime? = Nothing,
                                                    Optional toCheckOutDate As DateTime? = Nothing,
                                                    Optional fromCheckInDate As DateTime? = Nothing,
                                                    Optional toCheckInDate As DateTime? = Nothing,
                                                    Optional offset As Integer? = Nothing,
                                                    Optional take As Integer? = Nothing) As DataTable
            CreateAnnualStatisticEx = Nothing
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spStatLoanYearOther"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@OptItemID", SqlDbType.Int)).Value = intOptItemID
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                        .Parameters.Add(New SqlParameter("@intHistory", SqlDbType.Int)).Value = intHistory
                        .Parameters.Add(New SqlParameter("@intLocation", SqlDbType.Int)).Value = LocationID
                        .Parameters.Add(New SqlParameter("@intLoanMode", SqlDbType.Int)).Value = LoanMode
                        .Parameters.Add(New SqlParameter("@intOffset", SqlDbType.Int)).Value =
                            If(offset Is Nothing, DBNull.Value, DirectCast(offset, Object))
                        .Parameters.Add(New SqlParameter("@intTake", SqlDbType.Int)).Value =
                            If(take Is Nothing, DBNull.Value, DirectCast(take, Object))
                        .Parameters.Add(New SqlParameter("@dtFromCheckOutDate", SqlDbType.DateTime)).Value =
                            If(fromCheckOutDate Is Nothing, DBNull.Value, DirectCast(fromCheckOutDate, Object))
                        .Parameters.Add(New SqlParameter("@dtToCheckOutDate", SqlDbType.DateTime)).Value =
                            If(toCheckOutDate Is Nothing, DBNull.Value, DirectCast(toCheckOutDate, Object))
                        .Parameters.Add(New SqlParameter("@dtFromCheckInDate", SqlDbType.DateTime)).Value =
                            If(fromCheckInDate Is Nothing, DBNull.Value, DirectCast(fromCheckInDate, Object))
                        .Parameters.Add(New SqlParameter("@dtToCheckInDate", SqlDbType.DateTime)).Value =
                            If(toCheckInDate Is Nothing, DBNull.Value, DirectCast(toCheckInDate, Object))
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            CreateAnnualStatisticEx = dsData.Tables("tblResult")
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

        Public Function CreateAnnualStatisticDetail(ByRef total As Integer,
                                                    Optional fromCheckOutDate As DateTime? = Nothing,
                                                    Optional toCheckOutDate As DateTime? = Nothing,
                                                    Optional fromCheckInDate As DateTime? = Nothing,
                                                    Optional toCheckInDate As DateTime? = Nothing,
                                                    Optional offset As Integer? = Nothing,
                                                    Optional take As Integer? = Nothing
                                                    ) As DataTable
            CreateAnnualStatisticDetail = Nothing
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spStatLoanYearOther_Detail"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@OptItemID", SqlDbType.Int)).Value = intOptItemID
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                        .Parameters.Add(New SqlParameter("@intHistory", SqlDbType.Int)).Value = intHistory
                        .Parameters.Add(New SqlParameter("@intLocation", SqlDbType.Int)).Value = LocationID
                        .Parameters.Add(New SqlParameter("@intLoanMode", SqlDbType.Int)).Value = LoanMode
                        .Parameters.Add(New SqlParameter("@intTotal", SqlDbType.Int)).Direction = ParameterDirection.Output
                        .Parameters.Add(New SqlParameter("@intOffset", SqlDbType.Int)).Value =
                            If(offset Is Nothing, DBNull.Value, DirectCast(offset, Object))
                        .Parameters.Add(New SqlParameter("@intTake", SqlDbType.Int)).Value =
                            If(take Is Nothing, DBNull.Value, DirectCast(take, Object))
                        .Parameters.Add(New SqlParameter("@dtFromCheckOutDate", SqlDbType.DateTime)).Value =
                            If(fromCheckOutDate Is Nothing, DBNull.Value, DirectCast(fromCheckOutDate, Object))
                        .Parameters.Add(New SqlParameter("@dtToCheckOutDate", SqlDbType.DateTime)).Value =
                            If(toCheckOutDate Is Nothing, DBNull.Value, DirectCast(toCheckOutDate, Object))
                        .Parameters.Add(New SqlParameter("@dtFromCheckInDate", SqlDbType.DateTime)).Value =
                            If(fromCheckInDate Is Nothing, DBNull.Value, DirectCast(fromCheckInDate, Object))
                        .Parameters.Add(New SqlParameter("@dtToCheckInDate", SqlDbType.DateTime)).Value =
                            If(toCheckInDate Is Nothing, DBNull.Value, DirectCast(toCheckInDate, Object))
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            If Not IsDBNull(.Parameters("@intTotal")) Then
                                total = .Parameters("@intTotal").Value
                            Else
                                total = 0
                            End If
                            CreateAnnualStatisticDetail = dsData.Tables("tblResult")
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

        ' CreateMonthStatistic function
        ' Purpose: Static month
        Public Function CreateMonthStatistic(ByVal intStatYear As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_STAT_LOANMON"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("OptItemID", OracleType.Number)).Value = intOptItemID
                        .Parameters.Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                        .Parameters.Add(New OracleParameter("intStatYear", OracleType.VarChar, 10)).Value = intStatYear
                        .Parameters.Add(New OracleParameter("intHistory", OracleType.Number)).Value = intHistory
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            CreateMonthStatistic = dsData.Tables("tblResult")
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
                        .CommandText = "Cir_spStatLoanMon"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@OptItemID", SqlDbType.Int)).Value = intOptItemID
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                        .Parameters.Add(New SqlParameter("@intStatYear", SqlDbType.Int)).Value = intStatYear
                        .Parameters.Add(New SqlParameter("@intHistory", SqlDbType.Int)).Value = intHistory
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            CreateMonthStatistic = dsData.Tables("tblResult")
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

        Public Function CreateMonthStatisticOther(Optional fromCheckOutDate As DateTime? = Nothing,
                                                    Optional toCheckOutDate As DateTime? = Nothing,
                                                    Optional fromCheckInDate As DateTime? = Nothing,
                                                    Optional toCheckInDate As DateTime? = Nothing,
                                                    Optional offset As Integer? = Nothing,
                                                    Optional take As Integer? = Nothing) As DataTable
            CreateMonthStatisticOther = Nothing
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spStatLoanMonOther"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@OptItemID", SqlDbType.Int)).Value = intOptItemID
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                        .Parameters.Add(New SqlParameter("@intHistory", SqlDbType.Int)).Value = intHistory
                        .Parameters.Add(New SqlParameter("@intLocation", SqlDbType.Int)).Value = LocationID
                        .Parameters.Add(New SqlParameter("@intLoanMode", SqlDbType.Int)).Value = LoanMode
                        .Parameters.Add(New SqlParameter("@intOffset", SqlDbType.Int)).Value =
                            If(offset Is Nothing, DBNull.Value, DirectCast(offset, Object))
                        .Parameters.Add(New SqlParameter("@intTake", SqlDbType.Int)).Value =
                            If(take Is Nothing, DBNull.Value, DirectCast(take, Object))
                        .Parameters.Add(New SqlParameter("@dtFromCheckOutDate", SqlDbType.DateTime)).Value =
                            If(fromCheckOutDate Is Nothing, DBNull.Value, DirectCast(fromCheckOutDate, Object))
                        .Parameters.Add(New SqlParameter("@dtToCheckOutDate", SqlDbType.DateTime)).Value =
                            If(toCheckOutDate Is Nothing, DBNull.Value, DirectCast(toCheckOutDate, Object))
                        .Parameters.Add(New SqlParameter("@dtFromCheckInDate", SqlDbType.DateTime)).Value =
                            If(fromCheckInDate Is Nothing, DBNull.Value, DirectCast(fromCheckInDate, Object))
                        .Parameters.Add(New SqlParameter("@dtToCheckInDate", SqlDbType.DateTime)).Value =
                            If(toCheckInDate Is Nothing, DBNull.Value, DirectCast(toCheckInDate, Object))
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            CreateMonthStatisticOther = dsData.Tables("tblResult")
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

        Public Function CreateHoldingPlaceStatisticOther(
                                                        Optional optLib As Integer = 0,
                                                        Optional ids As String = Nothing,
                                                        Optional fromCheckOutDate As DateTime? = Nothing,
                                                        Optional toCheckOutDate As DateTime? = Nothing,
                                                        Optional fromCheckInDate As DateTime? = Nothing,
                                                        Optional toCheckInDate As DateTime? = Nothing,
                                                        Optional offset As Integer? = Nothing,
                                                        Optional take As Integer? = Nothing) As DataTable
            CreateHoldingPlaceStatisticOther = Nothing
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spStatHoldingPlaceOther"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@OptLib", SqlDbType.Int)).Value = optLib
                        .Parameters.Add(New SqlParameter("@strIDs", SqlDbType.VarChar, 8000)).Value =
                            If(ids Is Nothing, DBNull.Value, DirectCast(ids, Object))
                        .Parameters.Add(New SqlParameter("@OptItemID", SqlDbType.Int)).Value = intOptItemID
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                        .Parameters.Add(New SqlParameter("@intHistory", SqlDbType.Int)).Value = intHistory
                        .Parameters.Add(New SqlParameter("@intLocation", SqlDbType.Int)).Value = LocationID
                        .Parameters.Add(New SqlParameter("@intLoanMode", SqlDbType.Int)).Value = LoanMode
                        .Parameters.Add(New SqlParameter("@intOffset", SqlDbType.Int)).Value =
                            If(offset Is Nothing, DBNull.Value, DirectCast(offset, Object))
                        .Parameters.Add(New SqlParameter("@intTake", SqlDbType.Int)).Value =
                            If(take Is Nothing, DBNull.Value, DirectCast(take, Object))
                        .Parameters.Add(New SqlParameter("@dtFromCheckOutDate", SqlDbType.DateTime)).Value =
                            If(fromCheckOutDate Is Nothing, DBNull.Value, DirectCast(fromCheckOutDate, Object))
                        .Parameters.Add(New SqlParameter("@dtToCheckOutDate", SqlDbType.DateTime)).Value =
                            If(toCheckOutDate Is Nothing, DBNull.Value, DirectCast(toCheckOutDate, Object))
                        .Parameters.Add(New SqlParameter("@dtFromCheckInDate", SqlDbType.DateTime)).Value =
                            If(fromCheckInDate Is Nothing, DBNull.Value, DirectCast(fromCheckInDate, Object))
                        .Parameters.Add(New SqlParameter("@dtToCheckInDate", SqlDbType.DateTime)).Value =
                            If(toCheckInDate Is Nothing, DBNull.Value, DirectCast(toCheckInDate, Object))
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            CreateHoldingPlaceStatisticOther = dsData.Tables("tblResult")
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

        Public Function CreateHoldingPlaceStatisticOther_Detail(ByRef total As Integer,
                                                    Optional optLib As Integer = 0,
                                                    Optional ids As String = Nothing,
                                                    Optional fromCheckOutDate As DateTime? = Nothing,
                                                    Optional toCheckOutDate As DateTime? = Nothing,
                                                    Optional fromCheckInDate As DateTime? = Nothing,
                                                    Optional toCheckInDate As DateTime? = Nothing,
                                                    Optional offset As Integer? = Nothing,
                                                    Optional take As Integer? = Nothing
                                                    ) As DataTable
            CreateHoldingPlaceStatisticOther_Detail = Nothing
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spStatHoldingPlaceOther_Detail"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@OptLib", SqlDbType.Int)).Value = optLib
                        .Parameters.Add(New SqlParameter("@strIDs", SqlDbType.VarChar, 8000)).Value =
                            If(ids Is Nothing, DBNull.Value, DirectCast(ids, Object))
                        .Parameters.Add(New SqlParameter("@OptItemID", SqlDbType.Int)).Value = intOptItemID
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                        .Parameters.Add(New SqlParameter("@intHistory", SqlDbType.Int)).Value = intHistory
                        .Parameters.Add(New SqlParameter("@intLocation", SqlDbType.Int)).Value = LocationID
                        .Parameters.Add(New SqlParameter("@intLoanMode", SqlDbType.Int)).Value = LoanMode
                        .Parameters.Add(New SqlParameter("@intTotal", SqlDbType.Int)).Direction = ParameterDirection.Output
                        .Parameters.Add(New SqlParameter("@intOffset", SqlDbType.Int)).Value =
                            If(offset Is Nothing, DBNull.Value, DirectCast(offset, Object))
                        .Parameters.Add(New SqlParameter("@intTake", SqlDbType.Int)).Value =
                            If(take Is Nothing, DBNull.Value, DirectCast(take, Object))
                        .Parameters.Add(New SqlParameter("@dtFromCheckOutDate", SqlDbType.DateTime)).Value =
                            If(fromCheckOutDate Is Nothing, DBNull.Value, DirectCast(fromCheckOutDate, Object))
                        .Parameters.Add(New SqlParameter("@dtToCheckOutDate", SqlDbType.DateTime)).Value =
                            If(toCheckOutDate Is Nothing, DBNull.Value, DirectCast(toCheckOutDate, Object))
                        .Parameters.Add(New SqlParameter("@dtFromCheckInDate", SqlDbType.DateTime)).Value =
                            If(fromCheckInDate Is Nothing, DBNull.Value, DirectCast(fromCheckInDate, Object))
                        .Parameters.Add(New SqlParameter("@dtToCheckInDate", SqlDbType.DateTime)).Value =
                            If(toCheckInDate Is Nothing, DBNull.Value, DirectCast(toCheckInDate, Object))
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            If Not IsDBNull(.Parameters("@intTotal")) Then
                                total = .Parameters("@intTotal").Value
                            Else
                                total = 0
                            End If
                            CreateHoldingPlaceStatisticOther_Detail = dsData.Tables("tblResult")
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
        Public Function CreateMonthStatisticDetail(ByVal year As Integer, ByRef total As Integer,
                                                    Optional offset As Integer? = Nothing,
                                                    Optional take As Integer? = Nothing
                                                    ) As DataTable
            CreateMonthStatisticDetail = Nothing
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spStatLoanMonOther_Detail"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@OptItemID", SqlDbType.Int)).Value = intOptItemID
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                        .Parameters.Add(New SqlParameter("@intHistory", SqlDbType.Int)).Value = intHistory
                        .Parameters.Add(New SqlParameter("@intLocation", SqlDbType.Int)).Value = LocationID
                        .Parameters.Add(New SqlParameter("@intLoanMode", SqlDbType.Int)).Value = LoanMode
                        .Parameters.Add(New SqlParameter("@intTotal", SqlDbType.Int)).Direction = ParameterDirection.Output
                        .Parameters.Add(New SqlParameter("@intOffset", SqlDbType.Int)).Value =
                            If(offset Is Nothing, DBNull.Value, DirectCast(offset, Object))
                        .Parameters.Add(New SqlParameter("@intTake", SqlDbType.Int)).Value =
                            If(take Is Nothing, DBNull.Value, DirectCast(take, Object))
                        .Parameters.Add(New SqlParameter("@intStatYear", SqlDbType.Int)).Value = year
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            If Not IsDBNull(.Parameters("@intTotal")) Then
                                total = .Parameters("@intTotal").Value
                            Else
                                total = 0
                            End If
                            CreateMonthStatisticDetail = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                            CreateMonthStatisticDetail = Nothing
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function CreateDayStatisticDetail(ByVal month As Integer,
                                                 ByVal year As Integer,
                                                 ByRef total As Integer,
                                                    Optional offset As Integer? = Nothing,
                                                    Optional take As Integer? = Nothing
                                                    ) As DataTable
            CreateDayStatisticDetail = Nothing
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spStatLoanDayOther_Detail"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@OptItemID", SqlDbType.Int)).Value = intOptItemID
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                        .Parameters.Add(New SqlParameter("@intHistory", SqlDbType.Int)).Value = intHistory
                        .Parameters.Add(New SqlParameter("@intLocation", SqlDbType.Int)).Value = LocationID
                        .Parameters.Add(New SqlParameter("@intLoanMode", SqlDbType.Int)).Value = LoanMode
                        .Parameters.Add(New SqlParameter("@intTotal", SqlDbType.Int)).Direction = ParameterDirection.Output
                        .Parameters.Add(New SqlParameter("@intOffset", SqlDbType.Int)).Value =
                            If(offset Is Nothing, DBNull.Value, DirectCast(offset, Object))
                        .Parameters.Add(New SqlParameter("@intTake", SqlDbType.Int)).Value =
                            If(take Is Nothing, DBNull.Value, DirectCast(take, Object))
                        .Parameters.Add(New SqlParameter("@intStatMonth", SqlDbType.Int)).Value = month
                        .Parameters.Add(New SqlParameter("@intStatYear", SqlDbType.Int)).Value = year
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            If Not IsDBNull(.Parameters("@intTotal")) Then
                                total = .Parameters("@intTotal").Value
                            Else
                                total = 0
                            End If
                            CreateDayStatisticDetail = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                            CreateDayStatisticDetail = Nothing
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function CreateHoldingPlaceStatisticDetail(ByVal month As Integer,
                                                 ByVal year As Integer,
                                                 ByRef total As Integer,
                                                    Optional offset As Integer? = Nothing,
                                                    Optional take As Integer? = Nothing
                                                    ) As DataTable
            CreateHoldingPlaceStatisticDetail = Nothing
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spStatLoanDayOther_Detail"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@OptItemID", SqlDbType.Int)).Value = intOptItemID
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                        .Parameters.Add(New SqlParameter("@intHistory", SqlDbType.Int)).Value = intHistory
                        .Parameters.Add(New SqlParameter("@intLocation", SqlDbType.Int)).Value = LocationID
                        .Parameters.Add(New SqlParameter("@intLoanMode", SqlDbType.Int)).Value = LoanMode
                        .Parameters.Add(New SqlParameter("@intTotal", SqlDbType.Int)).Direction = ParameterDirection.Output
                        .Parameters.Add(New SqlParameter("@intOffset", SqlDbType.Int)).Value =
                            If(offset Is Nothing, DBNull.Value, DirectCast(offset, Object))
                        .Parameters.Add(New SqlParameter("@intTake", SqlDbType.Int)).Value =
                            If(take Is Nothing, DBNull.Value, DirectCast(take, Object))
                        .Parameters.Add(New SqlParameter("@intStatMonth", SqlDbType.Int)).Value = month
                        .Parameters.Add(New SqlParameter("@intStatYear", SqlDbType.Int)).Value = year
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            If Not IsDBNull(.Parameters("@intTotal")) Then
                                total = .Parameters("@intTotal").Value
                            Else
                                total = 0
                            End If
                            CreateHoldingPlaceStatisticDetail = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                            CreateHoldingPlaceStatisticDetail = Nothing
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' CreateDayStatistic function
        ' Purpose: Static day 
        Public Function CreateDayStatistic(ByVal intStatMon As Integer, ByVal intStatYear As Integer) As DataTable
            CreateDayStatistic = Nothing
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spStatLoanDay"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@OptItemID", SqlDbType.Int)).Value = intOptItemID
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                        .Parameters.Add(New SqlParameter("@intHistory", SqlDbType.Int)).Value = intHistory
                        .Parameters.Add(New SqlParameter("@intStatMonth", SqlDbType.Int)).Value = intStatMon
                        .Parameters.Add(New SqlParameter("@intStatYear", SqlDbType.Int)).Value = intStatYear
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            CreateDayStatistic = dsData.Tables("tblResult")
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


        Public Function CreateDayStatisticOther(Optional fromCheckOutDate As DateTime? = Nothing,
                                                    Optional toCheckOutDate As DateTime? = Nothing,
                                                    Optional fromCheckInDate As DateTime? = Nothing,
                                                    Optional toCheckInDate As DateTime? = Nothing,
                                                    Optional offset As Integer? = Nothing,
                                                    Optional take As Integer? = Nothing) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spStatLoanDayOther"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@OptItemID", SqlDbType.Int)).Value = intOptItemID
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                        .Parameters.Add(New SqlParameter("@intHistory", SqlDbType.Int)).Value = intHistory
                        .Parameters.Add(New SqlParameter("@intLocation", SqlDbType.Int)).Value = LocationID
                        .Parameters.Add(New SqlParameter("@intLoanMode", SqlDbType.Int)).Value = LoanMode
                        .Parameters.Add(New SqlParameter("@intOffset", SqlDbType.Int)).Value =
                            If(offset Is Nothing, DBNull.Value, DirectCast(offset, Object))
                        .Parameters.Add(New SqlParameter("@intTake", SqlDbType.Int)).Value =
                            If(take Is Nothing, DBNull.Value, DirectCast(take, Object))
                        .Parameters.Add(New SqlParameter("@dtFromCheckOutDate", SqlDbType.DateTime)).Value =
                            If(fromCheckOutDate Is Nothing, DBNull.Value, DirectCast(fromCheckOutDate, Object))
                        .Parameters.Add(New SqlParameter("@dtToCheckOutDate", SqlDbType.DateTime)).Value =
                            If(toCheckOutDate Is Nothing, DBNull.Value, DirectCast(toCheckOutDate, Object))
                        .Parameters.Add(New SqlParameter("@dtFromCheckInDate", SqlDbType.DateTime)).Value =
                            If(fromCheckInDate Is Nothing, DBNull.Value, DirectCast(fromCheckInDate, Object))
                        .Parameters.Add(New SqlParameter("@dtToCheckInDate", SqlDbType.DateTime)).Value =
                            If(toCheckInDate Is Nothing, DBNull.Value, DirectCast(toCheckInDate, Object))
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            CreateDayStatisticOther = dsData.Tables("tblResult")
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

        ' CreatePatronGroupStatistic function 
        ' Purpose:
        Public Function CreatePatronGroupStatistic(ByVal strCheckOutDateFrom As String, ByVal strCheckOutDateTo As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_STAT_PATRONGROUP"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("strCheckOutDateFrom", OracleType.VarChar, 30)).Value = strCheckOutDateFrom
                        .Parameters.Add(New OracleParameter("strCheckOutDateTo", OracleType.VarChar, 30)).Value = strCheckOutDateTo
                        .Parameters.Add(New OracleParameter("OptItemID", OracleType.Number)).Value = intOptItemID
                        .Parameters.Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                        .Parameters.Add(New OracleParameter("intHistory", OracleType.Number)).Value = intHistory
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            CreatePatronGroupStatistic = dsData.Tables("tblResult")
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
                        .CommandText = "Cir_spStatPatronGroup"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strCheckOutDateFrom", SqlDbType.VarChar, 30)).Value = strCheckOutDateFrom
                        .Parameters.Add(New SqlParameter("@strCheckOutDateTo", SqlDbType.VarChar, 30)).Value = strCheckOutDateTo
                        .Parameters.Add(New SqlParameter("@OptItemID", SqlDbType.Int)).Value = intOptItemID
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                        .Parameters.Add(New SqlParameter("@intHistory", SqlDbType.Int)).Value = intHistory
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            CreatePatronGroupStatistic = dsData.Tables("tblResult")
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

        ' CreatePolicyStatistic function
        ' Purpose: Create Policy Statistic
        Public Function CreatePolicyStatistic(ByVal strCheckOutDateFrom As String, ByVal strCheckOutDateTo As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_STAT_HOLDINGLOANTYPE"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("strCheckOutDateFrom", OracleType.VarChar, 20)).Value = strCheckOutDateFrom
                        .Parameters.Add(New OracleParameter("strCheckOutDateTo", OracleType.VarChar, 20)).Value = strCheckOutDateTo
                        .Parameters.Add(New OracleParameter("OptItemID", OracleType.Number)).Value = intOptItemID
                        .Parameters.Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                        .Parameters.Add(New OracleParameter("intHistory", OracleType.Number)).Value = intHistory
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            CreatePolicyStatistic = dsData.Tables("tblResult")
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
                        .CommandText = "Cir_spStatHoldingLoanType"
                        .CommandType = CommandType.StoredProcedure

                        .Parameters.Add(New SqlParameter("@strCheckOutDateFrom", SqlDbType.VarChar)).Value = strCheckOutDateFrom
                        .Parameters.Add(New SqlParameter("@strCheckOutDateTo", SqlDbType.VarChar)).Value = strCheckOutDateTo
                        .Parameters.Add(New SqlParameter("@OptItemID", SqlDbType.Int)).Value = intOptItemID
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                        .Parameters.Add(New SqlParameter("@intHistory", SqlDbType.Int)).Value = intHistory
                        .Parameters.Add(New SqlParameter("@intLoanType", SqlDbType.Int)).Value = LoanTypeID
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            CreatePolicyStatistic = dsData.Tables("tblResult")
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

        ' CreateTop20Statistic function
        ' Purpose:
        Public Function CreateTop20Statistic(ByVal intID As Integer, ByVal intHistory As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_STAT_TOP20"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("intID", OracleType.Number)).Value = intID
                        .Parameters.Add(New OracleParameter("intHistory", OracleType.Number)).Value = intHistory
                        .Parameters.Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            CreateTop20Statistic = dsData.Tables("tblResult")
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
                        .CommandText = "Cir_spStatTop20"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intHistory", SqlDbType.Int)).Value = intHistory
                        .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intID
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            CreateTop20Statistic = dsData.Tables("tblResult")
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

        ' CreateTopCopyStatistic function 
        ' Purpose:
        Public Function CreateTopCopyStatistic(ByVal strCheckOutDateFrom As String, ByVal strCheckOutDateTo As String, ByVal intTopNum As Integer, ByVal intMinLoan As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_STAT_ITEMMAX"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("strCheckOutDateFrom", OracleType.VarChar, 30)).Value = strCheckOutDateFrom
                        .Parameters.Add(New OracleParameter("strCheckOutDateTo", OracleType.VarChar, 30)).Value = strCheckOutDateTo
                        .Parameters.Add(New OracleParameter("intTopNum", OracleType.Number)).Value = intTopNum
                        .Parameters.Add(New OracleParameter("intMinLoan", OracleType.Number)).Value = intMinLoan
                        .Parameters.Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            CreateTopCopyStatistic = dsData.Tables("tblResult")
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
                        .CommandText = "Cir_spStatItemMax"
                        .CommandType = CommandType.StoredProcedure

                        .Parameters.Add(New SqlParameter("@strCheckOutDateFrom", SqlDbType.VarChar)).Value = strCheckOutDateFrom
                        .Parameters.Add(New SqlParameter("@strCheckOutDateTo", SqlDbType.VarChar)).Value = strCheckOutDateTo
                        .Parameters.Add(New SqlParameter("@intTopNum", SqlDbType.Int)).Value = intTopNum
                        .Parameters.Add(New SqlParameter("@intMinLoan", SqlDbType.Int)).Value = intMinLoan
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            CreateTopCopyStatistic = dsData.Tables("tblResult")
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

        Public Function CreateStatisticLoanHistoryCopyNumber(ByVal strCheckOutDateFrom As String, ByVal strCheckOutDateTo As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spStatLoanHistoryCopyNumber"
                        .CommandType = CommandType.StoredProcedure

                        .Parameters.Add(New SqlParameter("@strCheckOutDateFrom", SqlDbType.VarChar)).Value = strCheckOutDateFrom
                        .Parameters.Add(New SqlParameter("@strCheckOutDateTo", SqlDbType.VarChar)).Value = strCheckOutDateTo
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            CreateStatisticLoanHistoryCopyNumber = dsData.Tables("tblResult")
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

        Public Function CreateStatisticLoanHistoryCopyNumberDetail(ByVal strCheckOutDateFrom As String, ByVal strCheckOutDateTo As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spStatLoanHistoryCopyNumber_Detail"
                        .CommandType = CommandType.StoredProcedure

                        .Parameters.Add(New SqlParameter("@strCheckOutDateFrom", SqlDbType.VarChar)).Value = strCheckOutDateFrom
                        .Parameters.Add(New SqlParameter("@strCheckOutDateTo", SqlDbType.VarChar)).Value = strCheckOutDateTo
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            CreateStatisticLoanHistoryCopyNumberDetail = dsData.Tables("tblResult")
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

        ' CreateTopPatrolStatistic function 
        ' Purpose:
        Public Function CreateTopPatrolStatistic(ByVal strCheckOutDateFrom As String, ByVal strCheckOutDateTo As String, ByVal intTopNum As Integer, ByVal intMinLoan As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_STAT_PATRONMAX"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("strCheckOutDateFrom", OracleType.VarChar, 30)).Value = strCheckOutDateFrom
                        .Parameters.Add(New OracleParameter("strCheckOutDateTo", OracleType.VarChar, 30)).Value = strCheckOutDateTo
                        .Parameters.Add(New OracleParameter("intTopNum", OracleType.Number)).Value = intTopNum
                        .Parameters.Add(New OracleParameter("intMinLoan", OracleType.Number)).Value = intMinLoan
                        .Parameters.Add(New OracleParameter("OptItemID", OracleType.Number)).Value = intOptItemID
                        .Parameters.Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            CreateTopPatrolStatistic = dsData.Tables("tblResult")
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
                        .CommandText = "Cir_spStatPatronMax"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                        .Parameters.Add(New SqlParameter("@strCheckOutDateFrom", SqlDbType.VarChar)).Value = strCheckOutDateFrom
                        .Parameters.Add(New SqlParameter("@strCheckOutDateTo", SqlDbType.VarChar)).Value = strCheckOutDateTo
                        .Parameters.Add(New SqlParameter("@intTopNum", SqlDbType.Int)).Value = intTopNum
                        .Parameters.Add(New SqlParameter("@intMinLoan", SqlDbType.Int)).Value = intMinLoan
                        .Parameters.Add(New SqlParameter("@OptItemID", SqlDbType.Int)).Value = intOptItemID
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            CreateTopPatrolStatistic = dsData.Tables("tblResult")
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

        ' CreateHoldingPlaceStatistic function 
        ' Purpose: Static place holding
        Function CreateHoldingPlaceStatistic(ByVal intOptLib As Integer, ByVal strCheckOutDateFrom As String, ByVal strCheckOutDateTo As String, ByVal strLibIDs As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_STAT_HOLDINGPALCE"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("strCheckOutDateFrom", OracleType.VarChar, 30)).Value = strCheckOutDateFrom
                        .Parameters.Add(New OracleParameter("strCheckOutDateTo", OracleType.VarChar, 30)).Value = strCheckOutDateTo
                        .Parameters.Add(New OracleParameter("strLibIDs", OracleType.VarChar, 500)).Value = strLibIDs
                        .Parameters.Add(New OracleParameter("OptItemID", OracleType.Number)).Value = intOptItemID
                        .Parameters.Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                        .Parameters.Add(New OracleParameter("OptLib", OracleType.Number)).Value = intOptLib
                        .Parameters.Add(New OracleParameter("intHistory", OracleType.Number)).Value = intHistory
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            CreateHoldingPlaceStatistic = dsData.Tables("tblResult")
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
                        .CommandText = "Lib_spStatHoldingPlace"
                        .CommandType = CommandType.StoredProcedure

                        .Parameters.Add(New SqlParameter("@strCheckOutDateFrom", SqlDbType.VarChar)).Value = strCheckOutDateFrom
                        .Parameters.Add(New SqlParameter("@strCheckOutDateTo", SqlDbType.VarChar)).Value = strCheckOutDateTo
                        .Parameters.Add(New SqlParameter("@strLibIDs", SqlDbType.VarChar)).Value = strLibIDs
                        .Parameters.Add(New SqlParameter("@OptItemID", SqlDbType.Int)).Value = intOptItemID
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                        .Parameters.Add(New SqlParameter("@OptLib", SqlDbType.Int)).Value = intOptLib
                        .Parameters.Add(New SqlParameter("@intHistory", SqlDbType.Int)).Value = intHistory
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            CreateHoldingPlaceStatistic = dsData.Tables("tblResult")
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

        ' GetPatronHoldInfor method
        ' Purpose: get patron' holding information
        ' Input: lngItemID, lngTransactionID
        ' Output: datatable result
        Public Function GetPatronHoldInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_GETPATRONHOLD"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strCopyNumber", OracleType.VarChar)).Value = strCopyNumber
                            .Parameters.Add(New OracleParameter("lngItemID", OracleType.Number)).Value = lngItemID
                            .Parameters.Add(New OracleParameter("lngTransactionID", OracleType.Number)).Value = lngTransactionID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetPatronHoldInfor = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ser_spRecallCopies"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strCopyNumber", SqlDbType.VarChar)).Value = strCopyNumber
                            .Parameters.Add(New SqlParameter("@lngItemID", SqlDbType.Int)).Value = lngItemID
                            .Parameters.Add(New SqlParameter("@lngTransactionID", SqlDbType.Int)).Value = lngTransactionID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetPatronHoldInfor = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' GetLocationByCopyNumber method
        ' Purpose: Get LocationID of the input copynumber
        ' Input: lngItemID, strCopyNumber
        ' Output: int value
        Public Function GetLocationByCopyNumber() As Integer
            Dim intOutValue As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_GETLOCBYCOPYNUMBER"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strCopyNumber", OracleType.VarChar, 30)).Value = strCopyNumber
                            .Parameters.Add(New OracleParameter("lngItemID", OracleType.Number)).Value = lngItemID
                            .Parameters.Add(New OracleParameter("intOutValue", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intOutValue = .Parameters("intOutValue").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHolding_SelLocBycopyNumber"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strCopyNumber", SqlDbType.VarChar)).Value = strCopyNumber
                            .Parameters.Add(New SqlParameter("@lngItemID", SqlDbType.Int)).Value = lngItemID
                            .Parameters.Add(New SqlParameter("@intOutValue", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intOutValue = .Parameters("@intOutValue").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            GetLocationByCopyNumber = intOutValue
        End Function

        ' UpdatePatronHoldInfor method
        ' Purpose: Update holding information
        ' Input: strCopyNumber, lngItemID, strTimeOutDate, lngTransactionID
        Public Sub UpdatePatronHoldInfor()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_UPDATEPATRONHOLD"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strCopyNumber", OracleType.VarChar, 30)).Value = strCopyNumber
                            .Parameters.Add(New OracleParameter("lngItemID", OracleType.Number)).Value = lngItemID
                            .Parameters.Add(New OracleParameter("strTimeOutDate", OracleType.VarChar, 30)).Value = strTimeOutDate
                            .Parameters.Add(New OracleParameter("lngTransactionID", OracleType.Number)).Value = lngTransactionID
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatronHold_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strCopyNumber", SqlDbType.VarChar)).Value = strCopyNumber
                            .Parameters.Add(New SqlParameter("@lngItemID", SqlDbType.Int)).Value = lngItemID
                            .Parameters.Add(New SqlParameter("@strTimeOutDate", SqlDbType.VarChar)).Value = strTimeOutDate
                            .Parameters.Add(New SqlParameter("@lngTransactionID", SqlDbType.VarChar)).Value = lngTransactionID
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' CreateloanReport method
        ' Purpose: Get the loan patron and copy number infor
        ' Output: Datatable
        ' Created: Tuanhv
        Public Function CreateloanReport(ByVal strPatronCode As String, ByVal strItemCode As String, ByVal strCopyNumber As String, ByVal intLocationID As Integer, ByVal strCheckOutDateFrom As String, ByVal strCheckOutDateTo As String, ByVal strCheckInDateFrom As String, ByVal strCheckInDateTo As String, ByVal intUserID As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.GET_PATRON_LOANINFOR"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("strPatronCode", OracleType.VarChar, 50)).Value = strPatronCode
                        .Parameters.Add(New OracleParameter("strItemCode", OracleType.VarChar, 30)).Value = strItemCode
                        .Parameters.Add(New OracleParameter("strCopyNumber", OracleType.VarChar, 30)).Value = strCopyNumber
                        .Parameters.Add(New OracleParameter("intLocationID", OracleType.Number)).Value = intLocationID
                        .Parameters.Add(New OracleParameter("strCheckOutDateFrom", OracleType.VarChar, 30)).Value = strCheckOutDateFrom
                        .Parameters.Add(New OracleParameter("strCheckOutDateTo", OracleType.VarChar, 30)).Value = strCheckOutDateTo
                        .Parameters.Add(New OracleParameter("strCheckInDateFrom", OracleType.VarChar, 30)).Value = strCheckInDateFrom
                        .Parameters.Add(New OracleParameter("strCheckInDateTo", OracleType.VarChar, 30)).Value = strCheckInDateTo
                        .Parameters.Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            CreateloanReport = dsData.Tables("tblResult")
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
                        .CommandText = "Cir_spLoanHistory_SelLoanInfor"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 50)).Value = strPatronCode
                        .Parameters.Add(New SqlParameter("@strItemCode", SqlDbType.VarChar, 30)).Value = strItemCode
                        .Parameters.Add(New SqlParameter("@strCopyNumber", SqlDbType.VarChar, 30)).Value = strCopyNumber
                        .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                        .Parameters.Add(New SqlParameter("@strCheckOutDateFrom", SqlDbType.VarChar, 30)).Value = strCheckOutDateFrom
                        .Parameters.Add(New SqlParameter("@strCheckOutDateTo", SqlDbType.VarChar, 30)).Value = strCheckOutDateTo
                        .Parameters.Add(New SqlParameter("@strCheckInDateFrom", SqlDbType.VarChar, 30)).Value = strCheckInDateFrom
                        .Parameters.Add(New SqlParameter("@strCheckInDateTo", SqlDbType.VarChar, 30)).Value = strCheckInDateTo
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            CreateloanReport = dsData.Tables("tblResult")
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
        Public Function CreateloanReportCataloguerName(ByVal strItemCode As String,
                                                        ByRef total As Integer,
                                                        Optional fromCheckOutDate As DateTime? = Nothing,
                                                        Optional toCheckOutDate As DateTime? = Nothing,
                                                        Optional fromCheckInDate As DateTime? = Nothing,
                                                        Optional toCheckInDate As DateTime? = Nothing,
                                                        Optional offset As Integer? = Nothing,
                                                        Optional take As Integer? = Nothing) As DataTable
            CreateloanReportCataloguerName = Nothing
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spLoanHistory_SelLoanInfor_CataloguerName"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 50)).Value =
                            If(PatronCode Is Nothing, DBNull.Value, DirectCast(PatronCode, Object))
                        .Parameters.Add(New SqlParameter("@strItemCode", SqlDbType.VarChar, 30)).Value =
                            If(strItemCode Is Nothing, DBNull.Value, DirectCast(strItemCode, Object))
                        .Parameters.Add(New SqlParameter("@strCopyNumber", SqlDbType.VarChar, 30)).Value =
                            If(CopyNumber Is Nothing, DBNull.Value, DirectCast(CopyNumber, Object))
                        .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = LocationID
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = UserID
                        .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = LibID
                        .Parameters.Add(New SqlParameter("@intTotal", SqlDbType.Int)).Direction = ParameterDirection.Output
                        .Parameters.Add(New SqlParameter("@intOffset", SqlDbType.Int)).Value =
                            If(offset Is Nothing, DBNull.Value, DirectCast(offset, Object))
                        .Parameters.Add(New SqlParameter("@intTake", SqlDbType.Int)).Value =
                            If(take Is Nothing, DBNull.Value, DirectCast(take, Object))
                        .Parameters.Add(New SqlParameter("@dtFromCheckOutDate", SqlDbType.DateTime)).Value =
                            If(fromCheckOutDate Is Nothing, DBNull.Value, DirectCast(fromCheckOutDate, Object))
                        .Parameters.Add(New SqlParameter("@dtToCheckOutDate", SqlDbType.DateTime)).Value =
                            If(toCheckOutDate Is Nothing, DBNull.Value, DirectCast(toCheckOutDate, Object))
                        .Parameters.Add(New SqlParameter("@dtFromCheckInDate", SqlDbType.DateTime)).Value =
                            If(fromCheckInDate Is Nothing, DBNull.Value, DirectCast(fromCheckInDate, Object))
                        .Parameters.Add(New SqlParameter("@dtToCheckInDate", SqlDbType.DateTime)).Value =
                            If(toCheckInDate Is Nothing, DBNull.Value, DirectCast(toCheckInDate, Object))
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            If Not IsDBNull(.Parameters("@intTotal")) Then
                                total = .Parameters("@intTotal").Value
                            Else
                                total = 0
                            End If
                            CreateloanReportCataloguerName = dsData.Tables("tblResult")
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

        ' GetOnLoanCopies method
        ' Purpose: Get the loanning patron and copy number infor
        ' Output: Datatable
        ' Created: Tuanhv
        Public Function CreateOnloanReport(ByVal strPatronCode As String, ByVal strItemCode As String, ByVal strCopyNumber As String, ByVal intLocationID As Integer, ByVal strCheckOutDateFrom As String, ByVal strCheckOutDateTo As String, ByVal strDueDateFrom As String, ByVal strDueDateTo As String, ByVal intUserID As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.GET_PATRON_ONLOANINFOR"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("strPatronCode", OracleType.VarChar, 50)).Value = strPatronCode
                        .Parameters.Add(New OracleParameter("strItemCode", OracleType.VarChar, 30)).Value = strItemCode
                        .Parameters.Add(New OracleParameter("strCopyNumber", OracleType.VarChar, 30)).Value = strCopyNumber
                        .Parameters.Add(New OracleParameter("intLocationID", OracleType.Number)).Value = intLocationID
                        .Parameters.Add(New OracleParameter("strCheckOutDateFrom", OracleType.VarChar, 30)).Value = strCheckOutDateFrom
                        .Parameters.Add(New OracleParameter("strCheckOutDateTo", OracleType.VarChar, 30)).Value = strCheckOutDateTo
                        .Parameters.Add(New OracleParameter("strDueDateFrom", OracleType.VarChar, 30)).Value = strDueDateFrom
                        .Parameters.Add(New OracleParameter("strDueDateTo", OracleType.VarChar, 30)).Value = strDueDateTo
                        .Parameters.Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            CreateOnloanReport = dsData.Tables("tblResult")
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
                        .CommandText = "Cir_spLoanHistory_SelOnLoanInfor"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 50)).Value = strPatronCode
                        .Parameters.Add(New SqlParameter("@strItemCode", SqlDbType.VarChar, 30)).Value = strItemCode
                        .Parameters.Add(New SqlParameter("@strCopyNumber", SqlDbType.VarChar, 30)).Value = strCopyNumber
                        .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                        .Parameters.Add(New SqlParameter("@strCheckOutDateFrom", SqlDbType.VarChar, 30)).Value = strCheckOutDateFrom
                        .Parameters.Add(New SqlParameter("@strCheckOutDateTo", SqlDbType.VarChar, 30)).Value = strCheckOutDateTo
                        .Parameters.Add(New SqlParameter("@strDueDateFrom", SqlDbType.VarChar, 30)).Value = strDueDateFrom
                        .Parameters.Add(New SqlParameter("@strDueDateTo", SqlDbType.VarChar, 30)).Value = strDueDateTo
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                        .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            CreateOnloanReport = dsData.Tables("tblResult")
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
        Public Function CreateOnloanReportCataloguerName(
                                                        ByVal strItemCode As String,
                                                        ByRef total As Integer,
                                                        Optional fromCheckOutDate As DateTime? = Nothing,
                                                        Optional toCheckOutDate As DateTime? = Nothing,
                                                        Optional fromCheckInDate As DateTime? = Nothing,
                                                        Optional toCheckInDate As DateTime? = Nothing,
                                                        Optional offset As Integer? = Nothing,
                                                        Optional take As Integer? = Nothing
                                                        ) As DataTable
            CreateOnloanReportCataloguerName = Nothing
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spLoanHistory_SelOnLoanInfor_CataloguerName"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 50)).Value =
                            If(PatronCode Is Nothing, DBNull.Value, DirectCast(PatronCode, Object))
                        .Parameters.Add(New SqlParameter("@strItemCode", SqlDbType.VarChar, 30)).Value =
                            If(strItemCode Is Nothing, DBNull.Value, DirectCast(strItemCode, Object))
                        .Parameters.Add(New SqlParameter("@strCopyNumber", SqlDbType.VarChar, 30)).Value =
                            If(CopyNumber Is Nothing, DBNull.Value, DirectCast(CopyNumber, Object))
                        .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = LocationID
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = UserID
                        .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = LibID
                        .Parameters.Add(New SqlParameter("@intTotal", SqlDbType.Int)).Direction = ParameterDirection.Output
                        .Parameters.Add(New SqlParameter("@intOffset", SqlDbType.Int)).Value =
                            If(offset Is Nothing, DBNull.Value, DirectCast(offset, Object))
                        .Parameters.Add(New SqlParameter("@intTake", SqlDbType.Int)).Value =
                            If(take Is Nothing, DBNull.Value, DirectCast(take, Object))
                        .Parameters.Add(New SqlParameter("@dtFromCheckOutDate", SqlDbType.DateTime)).Value =
                            If(fromCheckOutDate Is Nothing, DBNull.Value, DirectCast(fromCheckOutDate, Object))
                        .Parameters.Add(New SqlParameter("@dtToCheckOutDate", SqlDbType.DateTime)).Value =
                            If(toCheckOutDate Is Nothing, DBNull.Value, DirectCast(toCheckOutDate, Object))
                        .Parameters.Add(New SqlParameter("@dtFromCheckInDate", SqlDbType.DateTime)).Value =
                            If(fromCheckInDate Is Nothing, DBNull.Value, DirectCast(fromCheckInDate, Object))
                        .Parameters.Add(New SqlParameter("@dtToCheckInDate", SqlDbType.DateTime)).Value =
                            If(toCheckInDate Is Nothing, DBNull.Value, DirectCast(toCheckInDate, Object))
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            If Not IsDBNull(.Parameters("@intTotal")) Then
                                total = .Parameters("@intTotal").Value
                            Else
                                total = 0
                            End If
                            CreateOnloanReportCataloguerName = dsData.Tables("tblResult")
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

        ' GetOnLoanCopies method
        ' Purpose: Get the loanning patron and copy number infor
        ' Output: Datatable
        Public Function GetOnLoanCopies() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_GET_LOANNING_INFOR"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = lngItemID
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetOnLoanCopies = dsData.Tables("tblResult")
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
                        .CommandText = "Cir_spLoan_SelInforByItemId"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = lngItemID
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetOnLoanCopies = dsData.Tables("tblResult")
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

        ' GetOnLoanCopiesOfPatron method
        ' Purpose: Get Onloan copies of the selected patron
        ' Input: PatronID
        ' Output: Datatable
        Public Function GetOnLoanCopiesOfPatron() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_GET_PATRON_ONLOAN_COPIES"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("lngPatronID", OracleType.Number)).Value = lngPatronID
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetOnLoanCopiesOfPatron = dsData.Tables("tblResult")
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
                        .CommandText = "Cir_spLoan_SelPatronOnLoanCopies"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@lngPatronID", SqlDbType.Int)).Value = lngPatronID
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetOnLoanCopiesOfPatron = dsData.Tables("tblResult")
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

        ' GetPatronLocations method
        ' Purpose: Get valid locations of the selected patron
        ' Input: strPatronCode
        ' Output: datatable result
        Public Function GetPatronLocations(ByVal strPatronCode As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_GETPATRONLOCATIONS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strPatronCode", OracleType.VarChar, 30)).Value = strPatronCode
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetPatronLocations = dsData.Tables("tblResult")
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
                        .CommandText = "Cir_spPatron_SelLocation"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar)).Value = strPatronCode
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetPatronLocations = dsData.Tables("tblResult")
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

        ' GetCurrentLoanInfor method
        ' Purpose: Get information of the current transactions
        ' Input: strTransactionIDs
        ' Output: datatable result
        Public Function GetCurrentLoanInfor(ByVal strTransactionIDs As String, Optional ByVal strType As String = "") As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_GET_CURRENT_LOANINFOR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strTransactionIDs", OracleType.VarChar, 100)).Value = strTransactionIDs
                            .Parameters.Add(New OracleParameter("strType", OracleType.VarChar, 30)).Value = strType
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetCurrentLoanInfor = dsData.Tables("tblResult")
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
                        .CommandText = "Cir_spLoan_SelCurrentLoanInfor"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strTransactionIDs", SqlDbType.VarChar)).Value = strTransactionIDs
                            .Parameters.Add(New SqlParameter("@strType", SqlDbType.VarChar)).Value = strType
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetCurrentLoanInfor = dsData.Tables("tblResult")
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

        Public Function GetCurrentLoanInforToPrintCheckOut(ByVal strTransactionIDs As String, Optional ByVal strType As String = "Patron") As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spLoan_SelCurrentLoanInforToPrintCheckOut"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strTransactionIDs", SqlDbType.VarChar)).Value = strTransactionIDs
                            .Parameters.Add(New SqlParameter("@strType", SqlDbType.VarChar)).Value = strType
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetCurrentLoanInforToPrintCheckOut = dsData.Tables("tblResult")
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

        ' Purpose: Get quick view informations
        ' Input: intUserID
        ' Output: datatable result
        Public Function GetQuickView(ByVal intOption As Integer, ByVal intUserID As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_CIR_STAT_QUICKVIEW"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intOption", OracleType.Number, 4)).Value = intOption
                            .Parameters.Add(New OracleParameter("intUserID", OracleType.Number, 4)).Value = intUserID

                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetQuickView = dsData.Tables("tblResult")
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
                        .CommandText = "Cir_spSelStatQuickView"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intOption", SqlDbType.Int)).Value = intOption
                            .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetQuickView = dsData.Tables("tblResult")
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

        ' UpdateCurrentLoanRecord method
        ' Purpose: Update information of the current transactions
        ' Input: strTransactionIDs
        Public Sub UpdateCurrentLoanRecord(ByVal strNote As String)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_UPDATE_CURRENT_LOAN"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngTransactionID", OracleType.Number)).Value = lngTransactionID
                            .Parameters.Add(New OracleParameter("strDueDate", OracleType.VarChar, 30)).Value = strDueDate
                            .Parameters.Add(New OracleParameter("strCheckOutDate", OracleType.VarChar, 30)).Value = strCheckOutDate
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
                        .CommandText = "Cir_spCurrentLoan_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngTransactionID", SqlDbType.Int)).Value = lngTransactionID
                            .Parameters.Add(New SqlParameter("@strDueDate", SqlDbType.VarChar, 30)).Value = strDueDate
                            .Parameters.Add(New SqlParameter("@strCheckOutDate", SqlDbType.VarChar, 30)).Value = strCheckOutDate
                            .Parameters.Add(New SqlParameter("@strNote", SqlDbType.NVarChar, 200)).Value = strNote
                            SqlDataAdapter.SelectCommand = SqlCommand
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

        Public Sub UpdateCurrentLoanRecord(ByVal strNote As String, ByVal dbDepositFee As Double)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spCurrentLoanWithDepositFee_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngTransactionID", SqlDbType.Int)).Value = lngTransactionID
                            .Parameters.Add(New SqlParameter("@strDueDate", SqlDbType.VarChar, 30)).Value = strDueDate
                            .Parameters.Add(New SqlParameter("@strNote", SqlDbType.NVarChar, 200)).Value = strNote
                            .Parameters.Add(New SqlParameter("@dbDepositFee", SqlDbType.Money)).Value = dbDepositFee
                            sqlDataAdapter.SelectCommand = sqlCommand
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
        ' GetCurrentCheckInInfor method
        ' Purpose: Get information of the current checkin transactions
        ' Input: TransactionIDs
        ' Output: datatable result
        Public Function GetCurrentCheckInInfor(Optional ByVal strType As String = "") As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_GET_CURRENT_CHECKIN_INFOR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strType", OracleType.VarChar, 30)).Value = strType
                            .Parameters.Add(New OracleParameter("strTransactionIDs", OracleType.VarChar, 300)).Value = strTransactionIDs
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetCurrentCheckInInfor = dsData.Tables("tblResult")
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
                        .CommandText = "Lib_spHolding_SelCurrentCheckInInfor"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strType", SqlDbType.VarChar, 30)).Value = strType
                            .Parameters.Add(New SqlParameter("@strTransactionIDs", SqlDbType.VarChar, 300)).Value = strTransactionIDs
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetCurrentCheckInInfor = dsData.Tables("tblResult")
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

        ' GetFineFees method
        ' Purpose: Get fine & fees
        ' Input: TransactionIDs
        ' Output: datatable result
        Public Function GetFineFees() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_GET_FINE_FEES"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strTransactionIDs", OracleType.VarChar, 300)).Value = strTransactionIDs
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetFineFees = dsData.Tables("tblResult")
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
                        .CommandText = "Cir_spLoanHistory_SelFineFee"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strTransactionIDs", SqlDbType.VarChar, 300)).Value = strTransactionIDs
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetFineFees = dsData.Tables("tblResult")
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

        ' GetHoldRequest method
        ' Purpose: check hold request to send notice email
        ' Input: TransactionIDs
        ' Output: datatable result
        Public Function GetHoldRequest() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_CHECK_HOLD_REQUEST"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngTransactionID", OracleType.Number)).Value = lngTransactionID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetHoldRequest = dsData.Tables("tblResult")
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
                        .CommandText = "Cir_spHolding_CheckHoldRequest"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngTransactionID", SqlDbType.Int)).Value = lngTransactionID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetHoldRequest = dsData.Tables("tblResult")
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
        ' GetDisList method
        ' Purpose: check hold request to send notice email
        ' Output: datatable result
        Public Function GetDisList() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_GET_DIC_LIST"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetDisList = dsData.Tables("tblResult")
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
                        .CommandText = "Cat_spDicList_SelBySimple"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intSimple", SqlDbType.Int)).Value = intSimple
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetDisList = dsData.Tables("tblResult")
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

        ' LogFineFees method
        ' Purpose: Log fine & fees
        ' Input: TransactionIDs
        ' Output: datatable result
        Public Sub LogFineFees()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_LOG_FINE_FEES"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strTransactionIDs", OracleType.VarChar, 300)).Value = strTransactionIDs
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
                        .CommandText = "Cir_spFine_LogFee"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strTransactionIDs", SqlDbType.VarChar, 300)).Value = strTransactionIDs
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

        Public Function GetRenewInfor(ByVal bytType As Byte, ByVal strTypeVal As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spSelRenew"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                            .Add(New SqlParameter("@intType", SqlDbType.SmallInt)).Value = bytType
                            .Add(New SqlParameter("@strCodeVal", SqlDbType.VarChar, 50)).Value = strTypeVal
                        End With
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "RenewInformation")
                            GetRenewInfor = dsData.Tables("RenewInformation")
                            dsData.Tables.Remove("RenewInformation")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_CIR_GET_RENEW"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                            .Add(New OracleParameter("intType", OracleType.Number)).Value = bytType
                            .Add(New OracleParameter("strCodeVal", OracleType.VarChar, 50)).Value = strTypeVal
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "RenewInformation")
                            GetRenewInfor = dsData.Tables("RenewInformation")
                            dsData.Tables.Remove("RenewInformation")
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

        Public Sub Renew(ByVal intLoanID As Integer, ByVal bytAddTime As Byte, ByVal bytTimeUnit As Byte, ByVal strFixedDueDate As String)
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spRenewItem"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intLoanID", SqlDbType.Int)).Value = intLoanID
                            .Add(New SqlParameter("@intAddTime", SqlDbType.SmallInt)).Value = bytAddTime
                            .Add(New SqlParameter("@intTimeUnit", SqlDbType.SmallInt)).Value = bytTimeUnit
                            .Add(New SqlParameter("@strFixedDueDate", SqlDbType.VarChar, 20)).Value = strFixedDueDate
                        End With
                        Try
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
                        .CommandText = "CIRCULATION.SP_RENEW_ITEM"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intLoanID", OracleType.Number)).Value = intLoanID
                            .Add(New OracleParameter("intAddTime", OracleType.Number)).Value = bytAddTime
                            .Add(New OracleParameter("intTimeUnit", OracleType.Number)).Value = bytTimeUnit
                            .Add(New OracleParameter("strFixedDueDate", OracleType.VarChar, 30)).Value = strFixedDueDate
                        End With
                        Try
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Sub

        Public Function CreateLocationCheckOutStatistic(Optional fromCheckOutDate As DateTime? = Nothing,
                                                    Optional toCheckOutDate As DateTime? = Nothing,
                                                    Optional offset As Integer? = Nothing,
                                                    Optional take As Integer? = Nothing) As DataTable
            CreateLocationCheckOutStatistic = Nothing
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_Location_CountOut"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intLoanMode", SqlDbType.Int)).Value = LoanMode
                        .Parameters.Add(New SqlParameter("@intOption", SqlDbType.Int)).Value = OptItemID
                        .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = LocationID
                        .Parameters.Add(New SqlParameter("@intOffset", SqlDbType.Int)).Value =
                            If(offset Is Nothing, DBNull.Value, DirectCast(offset, Object))
                        .Parameters.Add(New SqlParameter("@intTake", SqlDbType.Int)).Value =
                            If(take Is Nothing, DBNull.Value, DirectCast(take, Object))
                        .Parameters.Add(New SqlParameter("@dtFromCheckOutDate", SqlDbType.DateTime)).Value =
                            If(fromCheckOutDate Is Nothing, DBNull.Value, DirectCast(fromCheckOutDate, Object))
                        .Parameters.Add(New SqlParameter("@dtToCheckOutDate", SqlDbType.DateTime)).Value =
                            If(toCheckOutDate Is Nothing, DBNull.Value, DirectCast(toCheckOutDate, Object))
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            CreateLocationCheckOutStatistic = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                            CreateLocationCheckOutStatistic = Nothing
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
            End Select
            Call CloseConnection()
        End Function

        Public Function CreateLocationCheckOutStatisticDetail(ByRef total As Integer,
                                                    Optional fromCheckOutDate As DateTime? = Nothing,
                                                    Optional toCheckOutDate As DateTime? = Nothing,
                                                    Optional offset As Integer? = Nothing,
                                                    Optional take As Integer? = Nothing
                                                    ) As DataTable
            CreateLocationCheckOutStatisticDetail = Nothing
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spStatLocationCheckOutDetail"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@OptItemID", SqlDbType.Int)).Value = intOptItemID
                        .Parameters.Add(New SqlParameter("@intLocation", SqlDbType.Int)).Value = LocationID
                        .Parameters.Add(New SqlParameter("@intLoanMode", SqlDbType.Int)).Value = LoanMode
                        .Parameters.Add(New SqlParameter("@intTotal", SqlDbType.Int)).Direction = ParameterDirection.Output
                        .Parameters.Add(New SqlParameter("@intOffset", SqlDbType.Int)).Value =
                            If(offset Is Nothing, DBNull.Value, DirectCast(offset, Object))
                        .Parameters.Add(New SqlParameter("@intTake", SqlDbType.Int)).Value =
                            If(take Is Nothing, DBNull.Value, DirectCast(take, Object))
                        .Parameters.Add(New SqlParameter("@dtFromCheckOutDate", SqlDbType.DateTime)).Value =
                            If(fromCheckOutDate Is Nothing, DBNull.Value, DirectCast(fromCheckOutDate, Object))
                        .Parameters.Add(New SqlParameter("@dtToCheckOutDate", SqlDbType.DateTime)).Value =
                            If(toCheckOutDate Is Nothing, DBNull.Value, DirectCast(toCheckOutDate, Object))

                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            If Not IsDBNull(.Parameters("@intTotal")) Then
                                total = .Parameters("@intTotal").Value
                            Else
                                total = 0
                            End If
                            CreateLocationCheckOutStatisticDetail = dsData.Tables("tblResult")
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

        Public Function CreateLocationCheckIn(ByVal strDateInputFrom As String, ByVal strDateInputTo As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_Location_CountIn"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@OptItemID", SqlDbType.Int)).Value = intOptItemID
                            .Add(New SqlParameter("@DateInputFrom", SqlDbType.VarChar, 30)).Value = strDateInputFrom
                            .Add(New SqlParameter("@DateInputTo", SqlDbType.VarChar, 30)).Value = strDateInputTo
                            .Add(New SqlParameter("@intLocation", SqlDbType.Int)).Value = LocationID
                        End With
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            CreateLocationCheckIn = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"

            End Select
            Call CloseConnection()
        End Function


        Public Function GetCheckInDate(ByVal strDateInputFrom As String, ByVal strDateInputTo As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spHoldingHistory_GetCheckInDate"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strDateFrom", SqlDbType.VarChar, 30)).Value = strDateInputFrom
                            .Add(New SqlParameter("@strDateTo", SqlDbType.VarChar, 30)).Value = strDateInputTo
                        End With
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetCheckInDate = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"

            End Select
            Call CloseConnection()
        End Function

        Public Function GetCheckInLocationName(ByVal strDateInputFrom As String, ByVal strDateInputTo As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spHoldingHistory_GetCheckInLocationName"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strDateFrom", SqlDbType.VarChar, 30)).Value = strDateInputFrom
                            .Add(New SqlParameter("@strDateTo", SqlDbType.VarChar, 30)).Value = strDateInputTo
                        End With
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetCheckInLocationName = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"

            End Select
            Call CloseConnection()
        End Function

        Public Function GetHoldingHistoryCheckInDate(ByVal strDateInputFrom As String, ByVal strDateInputTo As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spHoldingHistory_GetHoldingHistoryCheckInDate"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@OptItemID", SqlDbType.Int)).Value = intOptItemID
                            .Add(New SqlParameter("@strDateFrom", SqlDbType.VarChar, 30)).Value = strDateInputFrom
                            .Add(New SqlParameter("@strDateTo", SqlDbType.VarChar, 30)).Value = strDateInputTo
                        End With
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetHoldingHistoryCheckInDate = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"

            End Select
            Call CloseConnection()
        End Function

        Public Function GetCheckOutDate(ByVal strDateInputFrom As String, ByVal strDateInputTo As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spHoldingHistory_GetCheckOutDate"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strDateFrom", SqlDbType.VarChar, 30)).Value = strDateInputFrom
                            .Add(New SqlParameter("@strDateTo", SqlDbType.VarChar, 30)).Value = strDateInputTo
                        End With
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetCheckOutDate = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"

            End Select
            Call CloseConnection()
        End Function

        Public Function GetCheckOutLocationName(ByVal strDateInputFrom As String, ByVal strDateInputTo As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spHoldingHistory_GetCheckOutLocationName"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strDateFrom", SqlDbType.VarChar, 30)).Value = strDateInputFrom
                            .Add(New SqlParameter("@strDateTo", SqlDbType.VarChar, 30)).Value = strDateInputTo
                        End With
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetCheckOutLocationName = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"

            End Select
            Call CloseConnection()
        End Function

        Public Function GetHoldingHistoryCheckOutDate(ByVal strDateInputFrom As String, ByVal strDateInputTo As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spHoldingHistory_GetHoldingHistoryCheckOutDate"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@OptItemID", SqlDbType.Int)).Value = intOptItemID
                            .Add(New SqlParameter("@strDateFrom", SqlDbType.VarChar, 30)).Value = strDateInputFrom
                            .Add(New SqlParameter("@strDateTo", SqlDbType.VarChar, 30)).Value = strDateInputTo
                        End With
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetHoldingHistoryCheckOutDate = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"

            End Select
            Call CloseConnection()
        End Function

        Public Function GetItemView(ByVal strDateFrom As String, ByVal strDateTo As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_tblItemView_Filter"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strDateFrom", SqlDbType.VarChar, 20)).Value = strDateFrom
                            .Add(New SqlParameter("@strDateTo", SqlDbType.VarChar, 20)).Value = strDateTo
                        End With
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemView = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"

            End Select
            Call CloseConnection()
        End Function
        Public Function GetItemViewByMonth(Optional ByVal intYear As Integer = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_tblItemView_Filter_By_Month"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = intYear
                        End With
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemViewByMonth = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"

            End Select
            Call CloseConnection()
        End Function
        Public Function GetItemViewByYear(Optional ByVal intYearFrom As Integer = 0, Optional ByVal intYearTo As Integer = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_tblItemView_Filter_By_Year"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intYearFrom", SqlDbType.Int)).Value = intYearFrom
                            .Add(New SqlParameter("@intYearTo", SqlDbType.Int)).Value = intYearTo
                        End With
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemViewByYear = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"

            End Select
            Call CloseConnection()
        End Function
        Public Function GetItemViewByDay(Optional ByVal intMonth As Integer = 0, Optional ByVal intYear As Integer = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_tblItemView_Filter_By_Day"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intMonth", SqlDbType.Int)).Value = intMonth
                            .Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = intYear
                        End With
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemViewByDay = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"

            End Select
            Call CloseConnection()
        End Function
        Public Function GetItemViewByWeek(Optional ByVal intWeekFrom As Integer = 0, Optional ByVal intWeekTo As Integer = 0, Optional ByVal intYear As Integer = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_tblItemView_Filter_By_Week"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intWeekFrom", SqlDbType.Int)).Value = intWeekFrom
                            .Add(New SqlParameter("@intWeekTo", SqlDbType.Int)).Value = intWeekTo
                            .Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = intYear
                        End With
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemViewByWeek = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"

            End Select
            Call CloseConnection()
        End Function

        Public Function GetItemDownLoad(ByVal strDateFrom As String, ByVal strDateTo As String, Optional ByVal intTypeStatic As Integer = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_tblItemDownLoadFile_Filter"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strDateFrom", SqlDbType.VarChar, 20)).Value = strDateFrom
                            .Add(New SqlParameter("@strDateTo", SqlDbType.VarChar, 20)).Value = strDateTo
                            .Add(New SqlParameter("@intTypeStatic", SqlDbType.Int)).Value = intTypeStatic
                        End With
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemDownLoad = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"

            End Select
            Call CloseConnection()
        End Function
        Public Function GetItemDownLoadByMonth(Optional ByVal intYear As Integer = 0, Optional ByVal intTypeStatic As Integer = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_tblItemDownLoadFile_Filter_By_Month"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = intYear
                            .Add(New SqlParameter("@intTypeStatic", SqlDbType.Int)).Value = intTypeStatic
                        End With
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemDownLoadByMonth = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"

            End Select
            Call CloseConnection()
        End Function
        Public Function GetItemDownLoadByYear(Optional ByVal intYearFrom As Integer = 0, Optional ByVal intYearTo As Integer = 0, Optional ByVal intTypeStatic As Integer = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_tblItemDownLoadFile_Filter_By_Year"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intYearFrom", SqlDbType.Int)).Value = intYearFrom
                            .Add(New SqlParameter("@intYearTo", SqlDbType.Int)).Value = intYearTo
                            .Add(New SqlParameter("@intTypeStatic", SqlDbType.Int)).Value = intTypeStatic
                        End With
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemDownLoadByYear = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"

            End Select
            Call CloseConnection()
        End Function
        Public Function GetItemDownLoadByDay(Optional ByVal intMonth As Integer = 0, Optional ByVal intYear As Integer = 0, Optional ByVal intTypeStatic As Integer = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_tblItemDownLoadFile_Filter_By_Day"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intMonth", SqlDbType.Int)).Value = intMonth
                            .Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = intYear
                            .Add(New SqlParameter("@intTypeStatic", SqlDbType.Int)).Value = intTypeStatic
                        End With
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemDownLoadByDay = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"

            End Select
            Call CloseConnection()
        End Function
        Public Function GetItemDownLoadByWeek(Optional ByVal intWeekFrom As Integer = 0, Optional ByVal intWeekTo As Integer = 0, Optional ByVal intYear As Integer = 0, Optional ByVal intTypeStatic As Integer = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_tblItemDownLoadFile_Filter_By_Week"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intWeekFrom", SqlDbType.Int)).Value = intWeekFrom
                            .Add(New SqlParameter("@intWeekTo", SqlDbType.Int)).Value = intWeekTo
                            .Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = intYear
                            .Add(New SqlParameter("@intTypeStatic", SqlDbType.Int)).Value = intTypeStatic
                        End With
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemDownLoadByWeek = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"

            End Select
            Call CloseConnection()
        End Function

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