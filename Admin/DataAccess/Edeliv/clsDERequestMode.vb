Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Edeliv
    Public Class clsDERequestMode
        Inherits clsDBase

        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************

        Private intRequestModeID As Integer
        Private strRequestMode As String

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' RequestModeID property
        Public Property RequestModeID() As Integer
            Get
                Return intRequestModeID
            End Get
            Set(ByVal Value As Integer)
                intRequestModeID = Value
            End Set
        End Property

        ' RequestMode property
        Public Property RequestMode() As String
            Get
                Return strRequestMode
            End Get
            Set(ByVal Value As String)
                strRequestMode = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Create method
        ' Purpose: create new RequestMode record
        ' Input: main infor of RequestMode infor
        ' Output: int value (0 when success)
        Public Function Create() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_CREATE_EDELIV_REQUESTMODE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strNote", OracleType.VarChar, 30)).Value = strRequestMode
                            .Parameters.Add(New OracleParameter("intOutput", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            Create = .Parameters("intOutPut").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "SP_CREATE_EDELIV_REQUESTMODE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strNote", SqlDbType.NVarChar, 30)).Value = strRequestMode
                            .Parameters.Add(New SqlParameter("@intOutput", SqlDbType.TinyInt)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            Create = .Parameters("@intOutPut").Value
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

        ' Update method
        ' Purpose: update information of the selected RequestMode record
        ' Input: main infor of RequestMode infor
        ' Output: int value (0 when success)
        Public Function Update() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_UPDATE_EDELIV_REQUESTMODE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intModeID", OracleType.Number)).Value = intRequestModeID
                            .Parameters.Add(New OracleParameter("strNote", OracleType.VarChar, 30)).Value = strRequestMode
                            .Parameters.Add(New OracleParameter("intOutput", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            Update = .Parameters("intOutPut").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Edl_spRequestMode_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intModeID", SqlDbType.Int)).Value = intRequestModeID
                            .Parameters.Add(New SqlParameter("@strNote", SqlDbType.NVarChar, 30)).Value = strRequestMode
                            .Parameters.Add(New SqlParameter("@intOutput", SqlDbType.TinyInt)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            Update = .Parameters("@intOutPut").Value
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
        ' Purpose: delete the selected RequestMode record
        ' Input: CustomerID
        Public Sub Delete()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_DELETE_EDELIV_REQUESTMODE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intModeID", OracleType.Number)).Value = intRequestModeID
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
                        .CommandText = "Edl_spRequestMode_DelByModeId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intModeID", SqlDbType.Int)).Value = intRequestModeID
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

        ' GetRequestMode method
        ' Purpose: Get information of the selected RequestMode (also of all sys RequestModes)
        ' Input: main infor of RequestMode infor
        ' Output: datatable result
        Public Function GetRequestMode() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_GET_EDELIV_REQUESTMODE"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("intModeID", OracleType.VarChar, 100)).Value = intRequestModeID
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetRequestMode = dsData.Tables("tblResult")
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
                        .CommandText = "Edl_spRequestMode_SelByModeId"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intModeID", SqlDbType.Int)).Value = intRequestModeID
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetRequestMode = dsData.Tables("tblResult")
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