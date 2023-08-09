Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType
Namespace eMicLibAdmin.DataAccess.News
    Public Class clsDCAT_News
        Inherits clsDBase
#Region "Propertites"

        Private idStr As String
        Public Property id() As String
            Get
                Return idStr
            End Get
            Set(ByVal value As String)
                idStr = value
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

        Private id_LStr As Integer
        Public Property id_L() As Integer
            Get
                Return id_LStr
            End Get
            Set(ByVal value As Integer)
                id_LStr = value
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

        Private Tieu_deStr As String
        Public Property Tieu_de() As String
            Get
                Return Tieu_deStr
            End Get
            Set(ByVal value As String)
                Tieu_deStr = value
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

        Private Tom_tatStr As String
        Public Property Tom_tat() As String
            Get
                Return Tom_tatStr
            End Get
            Set(ByVal value As String)
                Tom_tatStr = value
            End Set
        End Property

        Private Noi_dungStr As String
        Public Property Noi_dung() As String
            Get
                Return Noi_dungStr
            End Get
            Set(ByVal value As String)
                Noi_dungStr = value
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

        Private iconNewStr As String
        Public Property iconNew() As String
            Get
                Return iconNewStr
            End Get
            Set(ByVal value As String)
                iconNewStr = value
            End Set
        End Property

        Private TitleStr As String
        Public Property Title() As String
            Get
                Return TitleStr
            End Get
            Set(ByVal value As String)
                TitleStr = value
            End Set
        End Property

        Private MetaMoTaStr As String
        Public Property MetaMoTa() As String
            Get
                Return MetaMoTaStr
            End Get
            Set(ByVal value As String)
                MetaMoTaStr = value
            End Set
        End Property

        Private KeywordStr As String
        Public Property Keyword() As String
            Get
                Return KeywordStr
            End Get
            Set(ByVal value As String)
                KeywordStr = value
            End Set
        End Property


        Private DuoiAnhStr As String
        Public Property DuoiAnh() As String
            Get
                Return DuoiAnhStr
            End Get
            Set(ByVal value As String)
                DuoiAnhStr = value
            End Set
        End Property


        Private TKStr As String
        Public Property TK() As String
            Get
                Return TKStr
            End Get
            Set(ByVal value As String)
                TKStr = value
            End Set
        End Property


        Private id_CStr As String
        Public Property id_C() As String
            Get
                Return id_CStr
            End Get
            Set(ByVal value As String)
                id_CStr = value
            End Set
        End Property

        Private intLibID As Integer = 0
        ' LibID property
        Public Property LibID() As Integer
            Get
                Return intLibID
            End Get
            Set(ByVal Value As Integer)
                intLibID = Value
            End Set
        End Property

#End Region


        Public Function Create(ByVal intSelect As Integer) As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spCatNew_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@id_L", SqlDbType.NVarChar, 10)).Value = id_LStr
                                .Add(New SqlParameter("@Hot", SqlDbType.NVarChar, 10)).Value = HotStr
                                .Add(New SqlParameter("@Tieu_de", SqlDbType.NText)).Value = Tieu_deStr
                                .Add(New SqlParameter("@Anh", SqlDbType.NVarChar, 500)).Value = AnhStr
                                .Add(New SqlParameter("@Tom_tat", SqlDbType.NText)).Value = Tom_tatStr
                                .Add(New SqlParameter("@Noi_dung", SqlDbType.NText)).Value = Noi_dungStr
                                .Add(New SqlParameter("@NN", SqlDbType.NVarChar, 10)).Value = NNStr
                                .Add(New SqlParameter("@id", SqlDbType.Int)).Direction = ParameterDirection.Output
                                .Add(New SqlParameter("@iconNew", SqlDbType.NVarChar, 10)).Value = iconNewStr
                                .Add(New SqlParameter("@Title", SqlDbType.NVarChar, 2000)).Value = TitleStr
                                .Add(New SqlParameter("@MetaMoTa", SqlDbType.NVarChar, 2000)).Value = MetaMoTaStr
                                .Add(New SqlParameter("@DuoiAnh", SqlDbType.NVarChar, 2000)).Value = DuoiAnhStr
                                .Add(New SqlParameter("@Keyword", SqlDbType.NVarChar, 2000)).Value = KeywordStr
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
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

        Public Function Update() As Integer
            Dim intRetval As Integer = 0
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spCatNew_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@id", SqlDbType.Int)).Value = idStr
                                .Add(New SqlParameter("@Hot", SqlDbType.NVarChar, 10)).Value = HotStr
                                .Add(New SqlParameter("@Tieu_de", SqlDbType.NVarChar, 256)).Value = Tieu_deStr
                                .Add(New SqlParameter("@Anh", SqlDbType.NVarChar, 200)).Value = AnhStr
                                .Add(New SqlParameter("@Tom_tat", SqlDbType.NText)).Value = Tom_tatStr
                                .Add(New SqlParameter("@Noi_dung", SqlDbType.NText)).Value = Noi_dungStr
                                .Add(New SqlParameter("@NN", SqlDbType.NVarChar, 10)).Value = NNStr
                                .Add(New SqlParameter("@id_L", SqlDbType.NVarChar, 10)).Value = id_LStr
                                .Add(New SqlParameter("@iconNew", SqlDbType.NVarChar, 10)).Value = iconNewStr
                                .Add(New SqlParameter("@Title", SqlDbType.NVarChar, 2000)).Value = TitleStr
                                .Add(New SqlParameter("@MetaMoTa", SqlDbType.NVarChar, 2000)).Value = MetaMoTaStr
                                .Add(New SqlParameter("@Keyword", SqlDbType.NVarChar, 2000)).Value = KeywordStr
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
            Update = intRetval
        End Function

        Public Function News_update_Hot() As Integer
            Dim intRetval As Integer = 0
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spCatNew_UpdHot"
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
            News_update_Hot = intRetval
        End Function


        Public Function News_update_Status() As Integer
            Dim intRetval As Integer = 0
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spCatNew_UpdStatus"
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
            News_update_Status = intRetval
        End Function

        Public Function CAT_News_up_vi_tri() As Integer
            Dim intRetval As Integer = 0
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Edl_tblCatNew_UpdIndex"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@id", SqlDbType.Int)).Value = idStr
                                .Add(New SqlParameter("@vi_tri", SqlDbType.NVarChar, 10)).Value = Vi_triStr
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
            CAT_News_up_vi_tri = intRetval
        End Function

        Public Function CAT_News_sl_admin() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spCatNew_SelAdmin"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@NN", SqlDbType.NVarChar, 10)).Value = NNStr
                            .Parameters.Add(New SqlParameter("@id_L", SqlDbType.NVarChar, 10)).Value = id_LStr
                            .Parameters.Add(New SqlParameter("@intLidID", SqlDbType.Int)).Value = intLibID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            CAT_News_sl_admin = dsData.Tables("tblResult")
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

        Public Function CAT_News_sl_admin_all() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spCatNew_SelAdminAll"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@NN", SqlDbType.NVarChar, 10)).Value = NNStr
                            .Parameters.Add(New SqlParameter("@id_L", SqlDbType.Int, 10)).Value = id_LStr
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            CAT_News_sl_admin_all = dsData.Tables("tblResult")
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


        Public Function CAT_News_sl_id() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spCatNew_SelById"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@id", SqlDbType.NVarChar, 10)).Value = idStr
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            CAT_News_sl_id = dsData.Tables("tblResult")
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


        Public Function CAT_News_sl_id_out() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spCatNew_SelIdOut"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@id", SqlDbType.NVarChar, 10)).Value = idStr
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            CAT_News_sl_id_out = dsData.Tables("tblResult")
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

        Public Function CAT_News_SelectId_L() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "CAT_News_SelectId_L"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@id_L", SqlDbType.NVarChar, 10)).Value = id_LStr
                            .Parameters.Add(New SqlParameter("@NN", SqlDbType.NVarChar, 10)).Value = NNStr
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            CAT_News_SelectId_L = dsData.Tables("tblResult")
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



        Public Function CAT_News_sl_admin_search() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spCatNew_SelAdminSearch"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@id_L", SqlDbType.NVarChar, 10)).Value = id_LStr
                            .Parameters.Add(New SqlParameter("@NN", SqlDbType.NVarChar, 10)).Value = NNStr
                            .Parameters.Add(New SqlParameter("@TK", SqlDbType.NVarChar, 200)).Value = TKStr
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            CAT_News_sl_admin_search = dsData.Tables("tblResult")
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

        Public Function CAT_News_SelectIndex() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spCatNew_SelIndex"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@NN", SqlDbType.NVarChar, 10)).Value = NNStr
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            CAT_News_SelectIndex = dsData.Tables("tblResult")
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


        Public Function CAT_News_de_id(ByVal intCo_ID As Integer) As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spCatNew_DelById"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@id", SqlDbType.Int)).Value = intCo_ID
                            End With
                            .ExecuteNonQuery()
                            CAT_News_de_id = .Parameters("@id").Value
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

    End Class
End Namespace

