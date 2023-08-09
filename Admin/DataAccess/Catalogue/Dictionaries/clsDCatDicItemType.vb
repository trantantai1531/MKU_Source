Imports eMicLibAdmin.DataAccess
Imports eMicLibAdmin.DataAccess.Common
Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Catalogue
    Public Class clsDCatDicItemType
        Inherits clsDBase

        Private strIDs As String
        Private intID As Integer
        Private strTypeCode As String
        Private strAccessEntry As String
        Private strTypeName As String

        ' ID property
        Public Property ID() As Integer
            Get
                Return intID
            End Get
            Set(ByVal Value As Integer)
                intID = Value
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

        Public Property TypeCode() As String
            Get
                Return strTypeCode
            End Get
            Set(ByVal Value As String)
                strTypeCode = Value
            End Set
        End Property


        Public Property AccessEntry() As String
            Get
                Return strAccessEntry
            End Get
            Set(ByVal Value As String)
                strAccessEntry = Value
            End Set
        End Property


        Public Property TypeName() As String
            Get
                Return strTypeName
            End Get
            Set(ByVal Value As String)
                strTypeName = Value
            End Set
        End Property

        ' Method: Insert
        Public Function Insert() As Integer
            Dim intRetval As Integer = 1
            Call OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spDicItemType_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strTypeCode", SqlDbType.NVarChar, 6)).Value = strTypeCode
                                .Add(New SqlParameter("@strTypeName", SqlDbType.NVarChar, 64)).Value = strTypeName
                                .Add(New SqlParameter("@strAccessEntry", SqlDbType.NVarChar, 6)).Value = strAccessEntry
                                .Add(New SqlParameter("@intRetval", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetval = .Parameters("@intRetval").Value
                        Catch ex As SqlException
                            strerrormsg = ex.Message.ToString
                            interrorcode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CAT_DIC_ITEM_TYPE_INS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strTypeCode", OracleType.VarChar, 6)).Value = strTypeCode
                                .Add(New OracleParameter("strTypeName", OracleType.VarChar, 64)).Value = strTypeName
                                .Add(New OracleParameter("strAccessEntry", OracleType.VarChar, 6)).Value = strAccessEntry
                                .Add(New OracleParameter("intRetval", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetval = .Parameters("intRetval").Value
                        Catch ex As OracleException
                            strerrormsg = ex.Message.ToString
                            interrorcode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Insert = intRetval
        End Function

        ' Method: Update
        Public Function Update() As Integer
            Dim intRetval As Integer = 1

            Call OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spDicItemType_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strTypeCode", SqlDbType.NVarChar, 6)).Value = strTypeCode
                                .Add(New SqlParameter("@strTypeName", SqlDbType.NVarChar, 164)).Value = strTypeName
                                .Add(New SqlParameter("@strAccessEntry", SqlDbType.NVarChar, 6)).Value = strAccessEntry
                                .Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intID
                                .Add(New SqlParameter("@intRetval", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetval = .Parameters("@intRetval").Value
                        Catch ex As SqlException
                            strerrormsg = ex.Message.ToString
                            interrorcode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CAT_DIC_ITEM_TYPE_UPD"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strTypeCode", OracleType.VarChar, 6)).Value = strTypeCode
                                .Add(New OracleParameter("strTypeName", OracleType.VarChar, 400)).Value = strTypeName
                                .Add(New OracleParameter("strAccessEntry", OracleType.VarChar, 6)).Value = strAccessEntry
                                .Add(New OracleParameter("intID", OracleType.Number)).Value = intID
                                .Add(New OracleParameter("intRetval", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetval = .Parameters("intRetval").Value
                        Catch ex As OracleException
                            strerrormsg = ex.Message.ToString
                            interrorcode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Update = intRetval
        End Function

        ' Method : Merger
        Public Sub Merge()
            Call OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spDicItemType_Mer"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intID
                                .Add(New SqlParameter("@strIDs", SqlDbType.VarChar, 1000)).Value = strIDs
                            End With
                            .ExecuteNonQuery()
                        Catch ex As SqlException
                            strerrormsg = ex.Message.ToString
                            interrorcode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CAT_DIC_ITEM_TYPE_MER"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intID", OracleType.Number, 5)).Value = intID
                                .Add(New OracleParameter("strIDs", OracleType.VarChar, 1000)).Value = strIDs
                            End With
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            strerrormsg = ex.Message.ToString
                            interrorcode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        Public Function Retrieve() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spDicItemTypeIndex_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strAccessEntry", SqlDbType.VarChar, 6)).Value = strAccessEntry
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsdata, "CAT_DIC_ITEM_TYPE_INDEX")
                            Retrieve = dsdata.Tables("CAT_DIC_ITEM_TYPE_INDEX")
                            dsdata.Tables.Remove("CAT_DIC_ITEM_TYPE_INDEX")
                        Catch ex As SqlException
                            strerrormsg = ex.Message.ToString
                            interrorcode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oracommand
                        .CommandText = "CATALOGUE.SP_CAT_DIC_ITEM_TYPE_INDEX_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strAccessEntry", OracleType.VarChar, 6)).Value = strAccessEntry
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsdata, "CAT_DIC_ITEM_TYPE_INDEX")
                            Retrieve = dsdata.Tables("CAT_DIC_ITEM_TYPE_INDEX")
                            dsdata.Tables.Remove("CAT_DIC_ITEM_TYPE_INDEX")
                        Catch ex As OracleException
                            strerrormsg = ex.Message
                            interrorcode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function GetAll() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spDicItemType_SelAll"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetAll = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    'With oraCommand
                    '    .CommandText = "CATALOGUE.SP_CAT_DIC_ITEM_TYPE_INDEX_SEL"
                    '    .CommandType = CommandType.StoredProcedure
                    '    Try
                    '        With .Parameters
                    '            .Add(New OracleParameter("strAccessEntry", OracleType.VarChar, 6)).Value = strAccessEntry
                    '            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                    '        End With
                    '        oraDataAdapter.SelectCommand = oraCommand
                    '        oraDataAdapter.Fill(dsData, "CAT_DIC_ITEM_TYPE_INDEX")
                    '        GetAll = dsData.Tables("CAT_DIC_ITEM_TYPE_INDEX")
                    '        dsData.Tables.Remove("CAT_DIC_ITEM_TYPE_INDEX")
                    '    Catch ex As OracleException
                    '        strErrorMsg = ex.Message
                    '        intErrorCode = ex.Code
                    '    Finally
                    '        .Parameters.Clear()
                    '    End Try
                    'End With
            End Select
            Call CloseConnection()
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
