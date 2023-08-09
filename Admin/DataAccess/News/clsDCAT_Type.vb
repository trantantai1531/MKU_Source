Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.News
    Public Class clsDCAT_Type
        Inherits clsDBase

#Region "Properties"
        Private idStr As String
        Public Property id() As String
            Get
                Return idStr
            End Get
            Set(ByVal value As String)
                idStr = value
            End Set
        End Property

        Private id_LStr As Integer
        Public Property id_L() As Integer
            Get
                Return id_LStr
            End Get
            Set(ByVal value As Integer)
                id_LStr = value
            End Set
        End Property


        Private LoaiStr As String
        Public Property Loai() As String
            Get
                Return LoaiStr
            End Get
            Set(ByVal value As String)
                LoaiStr = value
            End Set
        End Property


        Private Vi_triStr As String
        Public Property Vi_tri() As String
            Get
                Return Vi_triStr
            End Get
            Set(ByVal value As String)
                Vi_triStr = value
            End Set
        End Property


        Private NNStr As String
        Public Property NN() As String
            Get
                Return NNStr
            End Get
            Set(ByVal value As String)
                NNStr = value
            End Set
        End Property


        Private StatusStr As String
        Public Property Status() As String
            Get
                Return StatusStr
            End Get
            Set(ByVal value As String)
                StatusStr = value
            End Set
        End Property


        Private AnhStr As String
        Public Property Anh() As String
            Get
                Return AnhStr
            End Get
            Set(ByVal value As String)
                AnhStr = value
            End Set
        End Property


        Private HotStr As String
        Public Property Hot() As String
            Get
                Return HotStr
            End Get
            Set(ByVal value As String)
                HotStr = value
            End Set
        End Property


        Private GioiThieuStr As String
        Public Property GioiThieu() As String
            Get
                Return GioiThieuStr
            End Get
            Set(ByVal value As String)
                GioiThieuStr = value
            End Set
        End Property


        Private LinkStr As String
        Public Property Link() As String
            Get
                Return LinkStr
            End Get
            Set(ByVal value As String)
                LinkStr = value
            End Set
        End Property
#End Region


        Public Function Create(ByVal intSelect As Integer) As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spType_Add"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@Loai", SqlDbType.NVarChar, 2000)).Value = LoaiStr
                                .Add(New SqlParameter("@NN", SqlDbType.NVarChar, 10)).Value = NNStr
                                .Add(New SqlParameter("@id_L", SqlDbType.NVarChar, 10)).Value = id_LStr
                                .Add(New SqlParameter("@Anh", SqlDbType.NVarChar, 500)).Value = AnhStr
                                .Add(New SqlParameter("@Hot", SqlDbType.NVarChar, 10)).Value = HotStr
                                .Add(New SqlParameter("@GioiThieu", SqlDbType.NText)).Value = GioiThieuStr
                                .Add(New SqlParameter("@Link", SqlDbType.NVarChar, 200)).Value = LinkStr
                                .Add(New SqlParameter("@intLidID", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@id", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            Create = .Parameters("@id").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"

            End Select
            Call CloseConnection()
        End Function


        Public Function CAT_Type_sl() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spType_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try

                            .Parameters.Add(New SqlParameter("@id_L", SqlDbType.NVarChar, 10)).Value = id_LStr
                            .Parameters.Add(New SqlParameter("@NN", SqlDbType.NVarChar, 10)).Value = NNStr
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            CAT_Type_sl = dsData.Tables("tblResult")
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

        Public Function CAT_Type_sl_all() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spType_SelAll"
                        .CommandType = CommandType.StoredProcedure
                        Try

                            .Parameters.Add(New SqlParameter("@id_L", SqlDbType.Int)).Value = id_LStr
                            .Parameters.Add(New SqlParameter("@NN", SqlDbType.NVarChar, 10)).Value = NNStr
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            CAT_Type_sl_all = dsData.Tables("tblResult")
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

        Public Function CAT_Type_sl_id() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spType_SelId"
                        .CommandType = CommandType.StoredProcedure
                        Try

                            .Parameters.Add(New SqlParameter("@id", SqlDbType.NVarChar, 10)).Value = idStr
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            CAT_Type_sl_id = dsData.Tables("tblResult")
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



        Public Function CAT_Type_de(ByVal intCo_ID As Integer) As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spType_Del"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@id", SqlDbType.Int)).Value = intCo_ID
                            End With
                            .ExecuteNonQuery()
                            CAT_Type_de = .Parameters("@id").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
            End Select
            Call CloseConnection()
        End Function

        Public Function CAT_Type_up_vi_tri() As Integer
            Dim intRetval As Integer = 0
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spType_UpdIndex"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@id", SqlDbType.Int)).Value = idStr
                                .Add(New SqlParameter("@vi_tri", SqlDbType.Int)).Value = Vi_triStr
                                .Add(New SqlParameter("@id_L", SqlDbType.Int)).Value = id_LStr
                                .Add(New SqlParameter("@Loai", SqlDbType.NVarChar, 256)).Value = LoaiStr
                            End With
                            .ExecuteNonQuery()
                            intRetval = 1
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"

            End Select
            Me.CloseConnection()
            CAT_Type_up_vi_tri = intRetval
        End Function

        Public Function CAT_Type_up() As Integer
            Dim intRetval As Integer = 0
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spType_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@id", SqlDbType.Int)).Value = idStr
                                .Add(New SqlParameter("@id_L", SqlDbType.Int)).Value = id_LStr
                                .Add(New SqlParameter("@Loai", SqlDbType.NVarChar, 256)).Value = LoaiStr
                                .Add(New SqlParameter("@NN", SqlDbType.NVarChar, 10)).Value = NNStr
                                .Add(New SqlParameter("@Anh", SqlDbType.NVarChar, 256)).Value = AnhStr
                                .Add(New SqlParameter("@Hot", SqlDbType.NVarChar, 10)).Value = HotStr
                                .Add(New SqlParameter("@GioiThieu", SqlDbType.NVarChar, 4000)).Value = GioiThieuStr
                            End With
                            .ExecuteNonQuery()
                            intRetval = 1
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"

            End Select
            Me.CloseConnection()
            CAT_Type_up = intRetval
        End Function

        Public Function CAT_Type_update_Status() As Integer
            Dim intRetval As Integer = 0
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spType_UpdStatus"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@id", SqlDbType.Int)).Value = idStr
                            End With
                            .ExecuteNonQuery()
                            intRetval = 1
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"

            End Select
            Me.CloseConnection()
            CAT_Type_update_Status = intRetval
        End Function

        Public Function CAT_Typeupdate_Hot() As Integer
            Dim intRetval As Integer = 0
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spType_UpdHot"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@id", SqlDbType.Int)).Value = idStr
                            End With
                            .ExecuteNonQuery()
                            intRetval = 1
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"

            End Select
            Me.CloseConnection()
            CAT_Typeupdate_Hot = intRetval
        End Function

    End Class
End Namespace

