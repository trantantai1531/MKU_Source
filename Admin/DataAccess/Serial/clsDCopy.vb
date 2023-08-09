' Name: clsDAcqRequest
' Purpose: Management index of Issue
' Creator: Oanhtn
' Created Date: 20/09/2004
' Modification History:

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Serial
    Public Class clsDCopy
        Inherits clsDBase

        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************

        Private intLocationID As Integer
        Private intPubYear As Integer
        Private strName As String
        Private strReceivedDate As String
        Private strNote As String
        Private intReceivedCopies As Integer
        Private lngCopyID As Long
        Private lngIssueID As Long

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' LocationID Property
        Public Property LocationID() As Integer
            Get
                Return intLocationID
            End Get
            Set(ByVal Value As Integer)
                intLocationID = Value
            End Set
        End Property

        ' PubYear Property
        Public Property PubYear() As Integer
            Get
                Return intPubYear
            End Get
            Set(ByVal Value As Integer)
                intPubYear = Value
            End Set
        End Property

        ' Name Property
        Public Property Name() As String
            Get
                Return strName
            End Get
            Set(ByVal Value As String)
                strName = Value
            End Set
        End Property

        ' ReceivedDate Property
        Public Property ReceivedDate() As String
            Get
                Return strReceivedDate
            End Get
            Set(ByVal Value As String)
                strReceivedDate = Value
            End Set
        End Property

        ' Note Property
        Public Property Note() As String
            Get
                Return strNote
            End Get
            Set(ByVal Value As String)
                strNote = Value
            End Set
        End Property

        ' ReceivedCopies Property
        Public Property ReceivedCopies() As Integer
            Get
                Return intReceivedCopies
            End Get
            Set(ByVal Value As Integer)
                intReceivedCopies = Value
            End Set
        End Property

        ' CopyID Property
        Public Property CopyID() As Long
            Get
                Return lngCopyID
            End Get
            Set(ByVal Value As Long)
                lngCopyID = Value
            End Set
        End Property

        ' IssueID Property
        Public Property IssueID() As Long
            Get
                Return lngIssueID
            End Get
            Set(ByVal Value As Long)
                lngIssueID = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' UpdateReceiveDate method
        ' Purpose: update receiveddate of the selected issue
        ' Input: Some main infor of the current copy
        Public Sub UpdateReceiveDate()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_UPDATE_RECEIVED_DATE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngCopyID", OracleType.Number)).Value = lngCopyID
                            .Parameters.Add(New OracleParameter("strReceivedDate", OracleType.VarChar, 30)).Value = strReceivedDate
                            .Parameters.Add(New OracleParameter("strNote", OracleType.NVarChar, 200)).Value = strNote
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
                        .CommandText = "Ser_spCopy_UpdReceivedDate"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngCopyID", SqlDbType.Int)).Value = lngCopyID
                            .Parameters.Add(New SqlParameter("@strReceivedDate", SqlDbType.VarChar)).Value = strReceivedDate
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

        ' Receive method
        ' Purpose: Receive some copies
        ' Input: some main information of the current issue
        ' Output: 0 if fail
        Public Function Receive() As Integer
            Dim intOutValue As Integer = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_RECEIVE_COPIES"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngIssueID", OracleType.Number)).Value = lngIssueID
                            .Parameters.Add(New OracleParameter("intLocationID", OracleType.Number)).Value = intLocationID
                            .Parameters.Add(New OracleParameter("strReceivedDate", OracleType.VarChar, 30)).Value = strReceivedDate
                            .Parameters.Add(New OracleParameter("strNote", OracleType.VarChar, 30)).Value = strNote
                            .Parameters.Add(New OracleParameter("intReceivedCopies", OracleType.Number)).Value = intReceivedCopies
                            .Parameters.Add(New OracleParameter("intOutValue", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intOutValue = .Parameters("intOutValue").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ser_spReceiveCopies"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngIssueID", SqlDbType.Int)).Value = lngIssueID
                            .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                            .Parameters.Add(New SqlParameter("@strReceivedDate", SqlDbType.VarChar)).Value = strReceivedDate
                            .Parameters.Add(New SqlParameter("@strNote", SqlDbType.NVarChar)).Value = strNote
                            .Parameters.Add(New SqlParameter("@intReceivedCopies", SqlDbType.Int)).Value = intReceivedCopies
                            .Parameters.Add(New SqlParameter("@intOutValue", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intOutValue = .Parameters("@intOutValue").Value
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

        ' UnReceive method
        ' Purpose: UnReceive some issues
        ' Input: IssueID for unreceive
        Public Sub UnReceive(ByVal strCopyIDs As String, ByVal intCount As Integer)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_UNRECEIVE_COPIES"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngIssueID", OracleType.Number)).Value = lngIssueID
                            .Parameters.Add(New OracleParameter("intCount", OracleType.Number)).Value = intCount
                            .Parameters.Add(New OracleParameter("strCopyIDs", OracleType.VarChar, 2000)).Value = strCopyIDs
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
                        .CommandText = "Ser_spUnreceiveCopy"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngIssueID", SqlDbType.VarChar)).Value = lngIssueID
                            .Parameters.Add(New SqlParameter("@intCount", SqlDbType.Int)).Value = intCount
                            .Parameters.Add(New SqlParameter("@strCopyIDs", SqlDbType.VarChar, 5000)).Value = strCopyIDs
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