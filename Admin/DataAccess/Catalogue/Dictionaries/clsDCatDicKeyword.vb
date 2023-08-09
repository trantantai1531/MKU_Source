Imports eMicLibAdmin.DataAccess
Imports eMicLibAdmin.DataAccess.Common
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Catalogue
    Public Class clsDCatDicKeyword
        Inherits clsDBase

        Private intID As Integer
        Private strDisplayEntry As String
        Private strAccessEntry As String
        Private intDicItemID As Integer
        Private strVietnameseAccent As String

        Public Property ID() As Integer
            Get
                Return intID
            End Get
            Set(ByVal Value As Integer)
                intID = Value
            End Set
        End Property

        Public Property DicItemID() As Integer
            Get
                Return intDicItemID
            End Get
            Set(ByVal Value As Integer)
                intDicItemID = Value
            End Set
        End Property

        Public Property DisplayEntry() As String
            Get
                Return strDisplayEntry
            End Get
            Set(ByVal Value As String)
                strDisplayEntry = Value
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

        Public Property VietnameseAccent() As String
            Get
                Return strVietnameseAccent
            End Get
            Set(ByVal Value As String)
                strVietnameseAccent = Value
            End Set
        End Property

        Public Function Insert() As Integer
            Dim intRetval As Integer = 1
            Call OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_tblDicKeyword_Insert"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strDisplayEntry", SqlDbType.NVarChar, 500)).Value = strDisplayEntry
                                .Add(New SqlParameter("@strAccessEntry", SqlDbType.NVarChar, 500)).Value = strAccessEntry
                                .Add(New SqlParameter("@intDicItemID", SqlDbType.Int)).Value = intDicItemID
                                .Add(New SqlParameter("@strVietnameseAccent", SqlDbType.NVarChar, 250)).Value = strVietnameseAccent
                            End With
                            .ExecuteNonQuery()
                            intRetval = 1
                        Catch ex As SqlException
                            intRetval = -1
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    'With oraCommand
                    '    .CommandText = "CATALOGUE.SP_CAT_DIC_ITEM_TYPE_INS"
                    '    .CommandType = CommandType.StoredProcedure
                    '    Try
                    '        With .Parameters
                    '            .Add(New OracleParameter("strTypeCode", OracleType.VarChar, 6)).Value = strTypeCode
                    '            .Add(New OracleParameter("strTypeName", OracleType.VarChar, 64)).Value = strTypeName
                    '            .Add(New OracleParameter("strAccessEntry", OracleType.VarChar, 6)).Value = strAccessEntry
                    '            .Add(New OracleParameter("intRetval", OracleType.Number)).Direction = ParameterDirection.Output
                    '        End With
                    '        .ExecuteNonQuery()
                    '        intRetval = .Parameters("intRetval").Value
                    '    Catch ex As OracleException
                    '        strerrormsg = ex.Message.ToString
                    '        interrorcode = ex.Code
                    '    Finally
                    '        .Parameters.Clear()
                    '    End Try
                    'End With
            End Select
            Call CloseConnection()
            Insert = intRetval
        End Function

        Public Function Update() As Integer
            Dim intRetval As Integer = 1
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_tblDicKeyword_Update"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intId", SqlDbType.Int)).Value = intID
                                .Add(New SqlParameter("@strDisplayEntry", SqlDbType.NVarChar, 500)).Value = strDisplayEntry
                                .Add(New SqlParameter("@strAccessEntry", SqlDbType.NVarChar, 500)).Value = strAccessEntry
                                .Add(New SqlParameter("@intDicItemID", SqlDbType.Int)).Value = intDicItemID
                                .Add(New SqlParameter("@strVietnameseAccent", SqlDbType.NVarChar, 250)).Value = strVietnameseAccent
                            End With
                            .ExecuteNonQuery()
                            intRetval = 1
                        Catch ex As SqlException
                            intRetval = -1
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    'With oraCommand
                    '    .CommandText = "CATALOGUE.SP_CAT_DIC_ITEM_TYPE_INS"
                    '    .CommandType = CommandType.StoredProcedure
                    '    Try
                    '        With .Parameters
                    '            .Add(New OracleParameter("strTypeCode", OracleType.VarChar, 6)).Value = strTypeCode
                    '            .Add(New OracleParameter("strTypeName", OracleType.VarChar, 64)).Value = strTypeName
                    '            .Add(New OracleParameter("strAccessEntry", OracleType.VarChar, 6)).Value = strAccessEntry
                    '            .Add(New OracleParameter("intRetval", OracleType.Number)).Direction = ParameterDirection.Output
                    '        End With
                    '        .ExecuteNonQuery()
                    '        intRetval = .Parameters("intRetval").Value
                    '    Catch ex As OracleException
                    '        strerrormsg = ex.Message.ToString
                    '        interrorcode = ex.Code
                    '    Finally
                    '        .Parameters.Clear()
                    '    End Try
                    'End With
            End Select
            Call CloseConnection()
            Update = intRetval
        End Function

        Public Function GetAll(Optional ByVal strSearch As String = "") As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_tblDicKeyword_SelectAll"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strSearch", SqlDbType.NVarChar, 500)).Value = strSearch
                            End With
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
                    '        Retrieve = dsData.Tables("CAT_DIC_ITEM_TYPE_INDEX")
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

        Public Function GetAllKeywordBibliography() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_tblDicKeyword_Bibliography_SelectAll"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetAllKeywordBibliography = dsData.Tables("tblResult")
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
                    '        Retrieve = dsData.Tables("CAT_DIC_ITEM_TYPE_INDEX")
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

        Public Function InsertKeywordBibliography(ByVal intKeywordID As Integer) As Integer
            Dim intRetval As Integer = 1
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_tblDicKeyword_Bibliography_Insert"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intKeywordID", SqlDbType.Int)).Value = intKeywordID
                            End With
                            .ExecuteNonQuery()
                            intRetval = 1
                        Catch ex As SqlException
                            intRetval = -1
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    'With oraCommand
                    '    .CommandText = "CATALOGUE.SP_CAT_DIC_ITEM_TYPE_INS"
                    '    .CommandType = CommandType.StoredProcedure
                    '    Try
                    '        With .Parameters
                    '            .Add(New OracleParameter("strTypeCode", OracleType.VarChar, 6)).Value = strTypeCode
                    '            .Add(New OracleParameter("strTypeName", OracleType.VarChar, 64)).Value = strTypeName
                    '            .Add(New OracleParameter("strAccessEntry", OracleType.VarChar, 6)).Value = strAccessEntry
                    '            .Add(New OracleParameter("intRetval", OracleType.Number)).Direction = ParameterDirection.Output
                    '        End With
                    '        .ExecuteNonQuery()
                    '        intRetval = .Parameters("intRetval").Value
                    '    Catch ex As OracleException
                    '        strerrormsg = ex.Message.ToString
                    '        interrorcode = ex.Code
                    '    Finally
                    '        .Parameters.Clear()
                    '    End Try
                    'End With
            End Select
            Call CloseConnection()
            InsertKeywordBibliography = intRetval
        End Function

        Public Function DeleteKeywordBibliography(ByVal intKeywordID As Integer) As Integer
            Dim intRetval As Integer = 1
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_tblDicKeyword_Bibliography_Delete"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intKeywordID", SqlDbType.Int)).Value = intKeywordID
                            End With
                            .ExecuteNonQuery()
                            intRetval = 1
                        Catch ex As SqlException
                            intRetval = -1
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    'With oraCommand
                    '    .CommandText = "CATALOGUE.SP_CAT_DIC_ITEM_TYPE_INS"
                    '    .CommandType = CommandType.StoredProcedure
                    '    Try
                    '        With .Parameters
                    '            .Add(New OracleParameter("strTypeCode", OracleType.VarChar, 6)).Value = strTypeCode
                    '            .Add(New OracleParameter("strTypeName", OracleType.VarChar, 64)).Value = strTypeName
                    '            .Add(New OracleParameter("strAccessEntry", OracleType.VarChar, 6)).Value = strAccessEntry
                    '            .Add(New OracleParameter("intRetval", OracleType.Number)).Direction = ParameterDirection.Output
                    '        End With
                    '        .ExecuteNonQuery()
                    '        intRetval = .Parameters("intRetval").Value
                    '    Catch ex As OracleException
                    '        strerrormsg = ex.Message.ToString
                    '        interrorcode = ex.Code
                    '    Finally
                    '        .Parameters.Clear()
                    '    End Try
                    'End With
            End Select
            Call CloseConnection()
            DeleteKeywordBibliography = intRetval
        End Function

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
