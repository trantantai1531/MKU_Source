' Name: clsDERequest
' Purpose: Management request infor
' Creator: Oanhtn
' Created Date: 01/11/2004
' Modification History:

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Edeliv
    Public Class clsDERequest
        Inherits clsDBase

        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************

        Protected intStatusID As Integer
        Protected lngRequestID As Long
        Protected strSizeOfFile As String

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' StatusID property
        Public Property StatusID() As Integer
            Get
                Return intStatusID
            End Get
            Set(ByVal Value As Integer)
                intStatusID = Value
            End Set
        End Property

        ' RequestID property
        Public Property RequestID() As Long
            Get
                Return lngRequestID
            End Get
            Set(ByVal Value As Long)
                lngRequestID = Value
            End Set
        End Property

        ' SizeOfFile property
        Public Property SizeOfFile() As String
            Get
                Return strSizeOfFile
            End Get
            Set(ByVal Value As String)
                strSizeOfFile = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' GetRequestInfor method
        ' Purpose: Get information of the selected file
        ' Input: RequestID
        ' Output: datatable result
        Public Function GetRequestInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_GET_EDELIV_REQUESTINFFOR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngRequestID", OracleType.Number)).Value = lngRequestID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetRequestInfor = dsData.Tables("tblResult")
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
                        .CommandText = "Edl_spRequest_SelInfor"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngRequestID", SqlDbType.Int)).Value = lngRequestID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetRequestInfor = dsData.Tables("tblResult")
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

        ' Delete method
        ' Purpose: delete the selected request record
        ' Input: RequestID
        Public Sub Delete()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_DELETE_EDELIV_REQUEST"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngRequestID", OracleType.Number)).Value = lngRequestID
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
                        .CommandText = "Edl_spPayment_DelRequest"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngRequestID", SqlDbType.Int)).Value = lngRequestID
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


        ' MoveFolder method
        ' Purpose: Move to request to suite folder (Update alert = 0)
        ' Input: RequestID
        Public Sub MoveFolder()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_UPDATE_ALERT_EDELIV_REQUEST"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngRequestID", OracleType.Number)).Value = lngRequestID
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
                        .CommandText = "Edl_spRequest_UpdAlert"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngRequestID", SqlDbType.Int)).Value = lngRequestID
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

        ' ChangeStatus method
        ' Purpose: change the status of the selected request record
        ' Input: RequestID, new StatusID
        Public Sub ChangeStatus()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDELIV_CHANGESTATUS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngRequestID", OracleType.Number)).Value = lngRequestID
                            .Parameters.Add(New OracleParameter("intStatusID", OracleType.Number)).Value = intStatusID
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
                        .CommandText = "Edl_spRequest_UpdStatus"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngRequestID", SqlDbType.Int)).Value = lngRequestID
                            .Parameters.Add(New SqlParameter("@intStatusID", SqlDbType.Int)).Value = intStatusID
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