Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibOPAC.DataAccess.Common
    Public Class clsDCounter
        Inherits clsDBase
        Protected intID As Integer
        Protected strIPAddress As String
        Protected strValidDate As DateTime
        Protected strCode As  String

        '' PatronCode
        Public Property Code() As String
            Get
                Return strCode   
            End Get
            Set( ByVal Value As String)
                strCode = Value
            End Set
        End Property
        ' ID property
        Public Property ID() As Integer
            Get
                Return intID
            End Get
            Set(ByVal Value As Integer)
                intID = Value
            End Set
        End Property

        ' IPAddress property
        Public Property IPAddress() As String
            Get
                Return strIPAddress
            End Get
            Set(ByVal Value As String)
                strIPAddress = Value
            End Set
        End Property

        ' ValidDate property
        Public Property ValidDate() As DateTime
            Get
                Return strValidDate
            End Get
            Set(ByVal Value As DateTime)
                strValidDate = Value
            End Set
        End Property

        '' insert User login 
        Public Sub InsertLoginCounter()
            Call OpenConnection()
            With sqlCommand
                .CommandText = "Sys_tblLoginCounter_Insert"
                .CommandType = CommandType.StoredProcedure
                    Try
                        .Parameters.Add(New SqlParameter("@strCode",SqlDbType.NChar)).Value = Code
                        .Parameters.Add(New SqlParameter("@strValidDate",SqlDbType.DateTime)).Value = strValidDate
                        .ExecuteNonQuery()
                    Catch sqlClientEx As Exception
                         strErrorMsg = sqlClientEx.Message.ToString
                    Finally
                         .Parameters.Clear()
                    End Try
            End With
        End Sub
        Public Sub InsertCounter()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    'With oraCommand
                    '    .CommandText = "CATALOGUE.SP_CATA_BOOKCODE_RES_CREATE"
                    '    .CommandType = CommandType.StoredProcedure
                    '    Try
                    '        .Parameters.Add(New OracleParameter("strCode", OracleType.VarChar, 30)).Value = strCode
                    '        .Parameters.Add(New OracleParameter("strSessionID", OracleType.VarChar, 50)).Value = strSessionID
                    '        .ExecuteNonQuery()
                    '    Catch OraEx As OracleException
                    '        strErrorMsg = OraEx.Message.ToString
                    '        intErrorCode = OraEx.Code
                    '    Finally
                    '        .Parameters.Clear()
                    '    End Try
                    'End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Sys_tblCounter_Insert"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strIPAddress", SqlDbType.NVarChar, 15)).Value = IPAddress
                            .Parameters.Add(New SqlParameter("@strValidDate", SqlDbType.DateTime)).Value = ValidDate
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

        Public Function GetCounterTotal() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    'With oraCommand
                    '    .CommandText = "CATALOGUE.SP_GET_ITEM_REVIEWER"
                    '    .CommandType = CommandType.StoredProcedure
                    '    Try
                    '        .Parameters.Add(New OracleParameter("strIDs", OracleType.VarChar, 500)).Value = ItemIDs
                    '        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                    '        oraDataAdapter.SelectCommand = oraCommand
                    '        oraDataAdapter.Fill(dsData, "tblResult")
                    '        GetItemReview = dsData.Tables("tblResult")
                    '        dsData.Tables.Remove("tblResult")
                    '    Catch OraEx As OracleException
                    '        strErrorMsg = OraEx.Message.ToString
                    '        intErrorCode = OraEx.Code
                    '    Finally
                    '        .Parameters.Clear()
                    '    End Try
                    'End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Sys_tblCounter_Select_Total"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetCounterTotal = dsData.Tables("tblResult")
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

        Public Function GetCounterLastDay() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    'With oraCommand
                    '    .CommandText = "CATALOGUE.SP_GET_ITEM_REVIEWER"
                    '    .CommandType = CommandType.StoredProcedure
                    '    Try
                    '        .Parameters.Add(New OracleParameter("strIDs", OracleType.VarChar, 500)).Value = ItemIDs
                    '        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                    '        oraDataAdapter.SelectCommand = oraCommand
                    '        oraDataAdapter.Fill(dsData, "tblResult")
                    '        GetItemReview = dsData.Tables("tblResult")
                    '        dsData.Tables.Remove("tblResult")
                    '    Catch OraEx As OracleException
                    '        strErrorMsg = OraEx.Message.ToString
                    '        intErrorCode = OraEx.Code
                    '    Finally
                    '        .Parameters.Clear()
                    '    End Try
                    'End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Sys_tblCounter_Select_LastDay"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetCounterLastDay = dsData.Tables("tblResult")
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

        Public Function GetCounterLastWeek() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    'With oraCommand
                    '    .CommandText = "CATALOGUE.SP_GET_ITEM_REVIEWER"
                    '    .CommandType = CommandType.StoredProcedure
                    '    Try
                    '        .Parameters.Add(New OracleParameter("strIDs", OracleType.VarChar, 500)).Value = ItemIDs
                    '        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                    '        oraDataAdapter.SelectCommand = oraCommand
                    '        oraDataAdapter.Fill(dsData, "tblResult")
                    '        GetItemReview = dsData.Tables("tblResult")
                    '        dsData.Tables.Remove("tblResult")
                    '    Catch OraEx As OracleException
                    '        strErrorMsg = OraEx.Message.ToString
                    '        intErrorCode = OraEx.Code
                    '    Finally
                    '        .Parameters.Clear()
                    '    End Try
                    'End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Sys_tblCounter_Select_LastWeek"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetCounterLastWeek = dsData.Tables("tblResult")
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

        Public Function GetCounterLastMonth() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    'With oraCommand
                    '    .CommandText = "CATALOGUE.SP_GET_ITEM_REVIEWER"
                    '    .CommandType = CommandType.StoredProcedure
                    '    Try
                    '        .Parameters.Add(New OracleParameter("strIDs", OracleType.VarChar, 500)).Value = ItemIDs
                    '        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                    '        oraDataAdapter.SelectCommand = oraCommand
                    '        oraDataAdapter.Fill(dsData, "tblResult")
                    '        GetItemReview = dsData.Tables("tblResult")
                    '        dsData.Tables.Remove("tblResult")
                    '    Catch OraEx As OracleException
                    '        strErrorMsg = OraEx.Message.ToString
                    '        intErrorCode = OraEx.Code
                    '    Finally
                    '        .Parameters.Clear()
                    '    End Try
                    'End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Sys_tblCounter_Select_LastMonth"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetCounterLastMonth = dsData.Tables("tblResult")
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
    End Class
End Namespace
