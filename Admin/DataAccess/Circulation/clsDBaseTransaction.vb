' Name: clsDBaseTransaction
' Purpose: Based for another transaction
' Creator: Oanhtn
' CreatedDate: 16/08/2004
' Modification History:

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Circulation
    Public Class clsDBaseTransaction
        Inherits clsDBase

        ' *****************************************************************************************************
        ' Declare member variables
        ' *****************************************************************************************************

        Protected strTransactionDate As String = ""
        Protected strPatronCode As String = ""
        Protected strCopyNumber As String = ""
        Protected strTitle As String = ""
        Protected lngItemID As Long = 0
        Protected lngPatronID As Long = 0
        Protected lngLocationID As Long = 0
        Protected lngTransactionID As Long = 0
        Protected strTransactionIDs As String = ""

        Private oraTransaction As OracleTransaction
        Private sqlTransaction As sqlTransaction

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' TransactionDate property
        Public Property TransactionDate() As String
            Get
                Return strTransactionDate
            End Get
            Set(ByVal Value As String)
                strTransactionDate = Value
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

        ' CopyNumber property
        Public Property CopyNumber() As String
            Get
                Return strCopyNumber
            End Get
            Set(ByVal Value As String)
                strCopyNumber = Value
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

        ' ItemID property
        Public Property ItemID() As Long
            Get
                Return lngItemID
            End Get
            Set(ByVal Value As Long)
                lngItemID = Value
            End Set
        End Property

        ' LocationID property
        Public Property LocationID() As Long
            Get
                Return lngLocationID
            End Get
            Set(ByVal Value As Long)
                lngLocationID = Value
            End Set
        End Property

        ' PatronID property
        Public Property PatronID() As Long
            Get
                Return lngPatronID
            End Get
            Set(ByVal Value As Long)
                lngPatronID = Value
            End Set
        End Property

        ' TransactionID property
        Public Property TransactionID() As Long
            Get
                Return lngTransactionID
            End Get
            Set(ByVal Value As Long)
                lngTransactionID = Value
            End Set
        End Property

        ' TransactionIDs property
        Public Property TransactionIDs() As String
            Get
                Return strTransactionIDs
            End Get
            Set(ByVal Value As String)
                strTransactionIDs = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' CheckPatronCode method
        ' Purpose: Check PatronCode
        ' Input: string value of PatronCode
        ' Output: 
        '   -- 0: OK
        '   -- 2: Card expired
        '   -- 3: Quota exceeded (Loan in lib)
        '   -- 4: Card is locked
        '   -- 5: Patron doesn't has access permission to one of the locations which this librarian has manage permission
        '   -- 6: Quota exceeded (Loan out of quota)    
        Public Function CheckPatronCode(Optional ByVal intLoanMode As Int16 = 0) As Int16
            Try
                Call OpenConnection()
                Select Case UCase(strDBServer)
                    Case "ORACLE"
                        With oraCommand
                            .CommandText = "CIRCULATION.SP_CHECKPATRONCODE"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                .Parameters.Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                                .Parameters.Add(New OracleParameter("strPatronCode", OracleType.VarChar, 30)).Value = strPatronCode
                                .Parameters.Add(New OracleParameter("intLoanMode", OracleType.Number)).Value = intLoanMode
                                .Parameters.Add(New OracleParameter("intOutPut", OracleType.Number)).Direction = ParameterDirection.Output
                                .ExecuteNonQuery()
                                CheckPatronCode = .Parameters("intOutPut").Value
                            Catch OraEx As OracleException
                                strErrorMsg = OraEx.Message.ToString
                                intErrorCode = OraEx.Code
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "SQLSERVER"
                        With SqlCommand
                            .CommandText = "Cir_spPatron_CheckPatron"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                                .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar)).Value = strPatronCode
                                .Parameters.Add(New SqlParameter("@intLoanMode", SqlDbType.Int)).Value = intLoanMode
                                .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                .Parameters.Add(New SqlParameter("@intOutPut", SqlDbType.Int)).Direction = ParameterDirection.Output
                                .ExecuteNonQuery()
                                CheckPatronCode = .Parameters("@intOutPut").Value
                            Catch sqlClientEx As SqlException
                                strErrorMsg = sqlClientEx.Message.ToString
                                intErrorCode = sqlClientEx.Number
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
                Call CloseConnection()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' CheckCopyNumber method
        ' Purpose: CheckCopyNumber
        ' Input: CopyNumber, PatronCode, UserID
        ' Output: 
        '   -- 0: OK
        '   -- 1: Copynumber doesn't exists
        '   -- 2: Copynumber is locked or not in circulation
        '   -- 3: Copynumber is on load
        '   -- 4: Copynumber is on hold
        '   -- 5: Librarian has not permission to manage location of the CopyNumber
        '   -- 6: Librarian has not permission to manage location of Patron
        Public Function CheckCopyNumber() As Int16
            CheckCopyNumber = 0
            Try
                Call OpenConnection()
                Select Case UCase(strDBServer)
                    Case "ORACLE"
                        With oraCommand
                            .CommandText = "CIRCULATION.SP_CHECKCOPYNUMBER"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                .Parameters.Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                                .Parameters.Add(New OracleParameter("strPatronCode", OracleType.VarChar, 30)).Value = strPatronCode
                                .Parameters.Add(New OracleParameter("strCopyNumber", OracleType.VarChar, 30)).Value = strCopyNumber
                                .Parameters.Add(New OracleParameter("intOutPut", OracleType.Number)).Direction = ParameterDirection.Output
                                .ExecuteNonQuery()
                                CheckCopyNumber = .Parameters("intOutPut").Value
                            Catch OraEx As OracleException
                                strErrorMsg = OraEx.Message.ToString
                                intErrorCode = OraEx.Code
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "SQLSERVER"
                        With SqlCommand
                            .CommandText = "Acq_spHolding_CheckCopynumber"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                                .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 30)).Value = strPatronCode
                                .Parameters.Add(New SqlParameter("@strCopyNumber", SqlDbType.VarChar, 30)).Value = strCopyNumber
                                .Parameters.Add(New SqlParameter("@intOutPut", SqlDbType.Int)).Direction = ParameterDirection.Output
                                .ExecuteNonQuery()
                                CheckCopyNumber = .Parameters("@intOutPut").Value
                            Catch sqlClientEx As SqlException
                                strErrorMsg = sqlClientEx.Message.ToString
                                intErrorCode = sqlClientEx.Number
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
                Call CloseConnection()
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' BeginTrans method
        ' Purpose: begin new transaction
        Public Sub BeginTrans()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    oraTransaction = oraConnection.BeginTransaction()
                    oraCommand.Transaction = oraTransaction
                Case "SQLSERVER"
                    sqlTransaction = SqlConnection.BeginTransaction()
                    SqlCommand.Transaction = sqlTransaction
            End Select
        End Sub

        ' RollBackTrans method
        ' Purpose: RollBack current transaction
        Public Sub RollBackTrans()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    oraTransaction.Rollback()
                    oraTransaction.Dispose()
                    oraTransaction = Nothing
                Case "SQLSERVER"
                    sqlTransaction.Rollback()
                    sqlTransaction.Dispose()
                    sqlTransaction = Nothing
            End Select
            Call CloseConnection()
        End Sub

        ' CommitTrans method
        ' Purpose: end current transaction
        Public Sub CommitTrans()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    oraTransaction.Commit()
                    oraTransaction.Dispose()
                    oraTransaction = Nothing
                Case "SQLSERVER"
                    sqlTransaction.Commit()
                    sqlTransaction.Dispose()
                    sqlTransaction = Nothing
            End Select
            Call CloseConnection()
        End Sub

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
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
