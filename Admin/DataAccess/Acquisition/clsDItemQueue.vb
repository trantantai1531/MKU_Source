'class:clsDItemQueue
'purpose: show list Lib_tblItem reviewed =0
'creator: lent
'created date: 15-2-2005
'histoty update:
Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType
Namespace eMicLibAdmin.DataAccess.Acquisition
    Public Class clsDItemQueue
        Inherits clsDBase
        Private intOrderBy As Integer
        Private strDate As String
        Private strIDs As String

        Public Property OrderBy() As Integer
            Get
                Return intOrderBy
            End Get
            Set(ByVal Value As Integer)
                intOrderBy = Value
            End Set
        End Property
        Public Property FilterDate() As String
            Get
                Return strDate
            End Get
            Set(ByVal Value As String)
                strDate = Value
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

        ' Purpose : Get list count items follow month and year
        ' In: 
        ' Out: Datatable
        ' Created by: Lent
        Function GetCountItemQueue() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spQueue_SelWithOrder"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetCountItemQueue = dsData.Tables("tblResult")
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
                        .CommandText = "ACQUISITION.SP_ITEM_CAT_QUEUE_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetCountItemQueue = dsData.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        ' Purpose : Get content items
        ' In: 
        ' Out: Datatable
        ' Created by: Lent
        Function GetListItemQueue() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spQueue_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intOrderBy", SqlDbType.Int)).Value = intOrderBy
                                .Add(New SqlParameter("@strDate", SqlDbType.VarChar, 20)).Value = strDate
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetListItemQueue = dsData.Tables("tblResult")
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
                        .CommandText = "ACQUISITION.SP_ACQ_ITEM_QUEUE_SELECT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                .Add(New OracleParameter("intOrderBy", OracleType.Number)).Value = intOrderBy
                                .Add(New OracleParameter("strDate", OracleType.VarChar, 20)).Value = strDate
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetListItemQueue = dsData.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function
        ' Purpose : Get content and document code of items
        ' In: 
        ' Out: Datatable
        ' Created by: Lent
        ' Date : 26-2-2005
        Function GetInfoItem() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spItem_SelByIdsWithOrderContent"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strIDs", SqlDbType.VarChar, 2000)).Value = strIDs
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetInfoItem = dsData.Tables("tblResult")
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
                        .CommandText = "ACQUISITION.SP_ITEM_SELECT_IDS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                .Add(New OracleParameter("strIDs", OracleType.VarChar, 2000)).Value = strIDs
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetInfoItem = dsData.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function


        ' Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not oraCommand Is Nothing Then
                        oraCommand.Dispose()
                        oraCommand = Nothing
                    End If
                    If Not SqlCommand Is Nothing Then
                        SqlCommand.Dispose()
                        SqlCommand = Nothing
                    End If
                    If Not SqlConnection Is Nothing Then
                        SqlConnection.Close()
                        SqlConnection.Dispose()
                        SqlConnection = Nothing
                    End If
                    If Not oraConnection Is Nothing Then
                        oraConnection.Close()
                        oraConnection.Dispose()
                        oraConnection = Nothing
                    End If
                    If Not oraDataAdapter Is Nothing Then
                        oraDataAdapter.Dispose()
                        oraDataAdapter = Nothing
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
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace