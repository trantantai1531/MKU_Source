Imports eMicLibAdmin.DataAccess
Imports eMicLibAdmin.DataAccess.Common
Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Catalogue
    Public Class clsDCatDicMedium
        Inherits clsDBase

        Private strIDs As String
        Private intID As Integer
        Private strCode As String
        Private strAccessEntry As String
        Private strDescription As String

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

        Public Property Code() As String
            Get
                Return strCode
            End Get
            Set(ByVal Value As String)
                strCode = Value
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


        Public Property Description() As String
            Get
                Return strDescription
            End Get
            Set(ByVal Value As String)
                strDescription = Value
            End Set
        End Property

        Public Sub Insert()
            Call OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spDicMedium_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strCode", SqlDbType.NVarChar, 12)).Value = strCode
                                .Add(New SqlParameter("@strAccessEntry", SqlDbType.NVarChar, 6)).Value = strAccessEntry
                                .Add(New SqlParameter("@strDescription", SqlDbType.NVarChar, 64)).Value = strDescription
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
                        .CommandText = "CATALOGUE.SP_CAT_DIC_MEDIUM_INS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strCode", OracleType.VarChar, 12)).Value = strCode
                                .Add(New OracleParameter("strAccessEntry", OracleType.VarChar, 6)).Value = strAccessEntry
                                .Add(New OracleParameter("strDescription", OracleType.VarChar, 256)).Value = strDescription
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

        Public Sub Update()
            Call OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spDicMedium_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strCode", SqlDbType.NVarChar, 12)).Value = strCode
                                .Add(New SqlParameter("@strAccessEntry", SqlDbType.NVarChar, 6)).Value = strAccessEntry
                                .Add(New SqlParameter("@strDescription", SqlDbType.NVarChar, 64)).Value = strDescription
                                .Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intID
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
                        .CommandText = "CATALOGUE.SP_CAT_DIC_MEDIUM_UPD"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strCode", OracleType.VarChar, 12)).Value = strCode
                                .Add(New OracleParameter("strAccessEntry", OracleType.VarChar, 6)).Value = strAccessEntry
                                .Add(New OracleParameter("strDescription", OracleType.VarChar, 256)).Value = strDescription
                                .Add(New OracleParameter("intID", OracleType.Number)).Value = intID
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

        Public Sub Delete()

        End Sub

        Public Sub Merge()
            Call OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spDicMedium_Mer"
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
                        .CommandText = "CATALOGUE.SP_CAT_DIC_MEDIUM_MER"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intID", OracleType.VarChar, 5)).Value = intID
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
                        .CommandText = "Cat_spDicMediumIndex_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strAccessEntry", SqlDbType.VarChar, 6)).Value = strAccessEntry
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsdata, "CAT_DIC_MEDIUM_INDEX")
                            Retrieve = dsdata.Tables("CAT_DIC_MEDIUM_INDEX")
                            dsdata.Tables.Remove("CAT_DIC_MEDIUM_INDEX")
                        Catch ex As SqlException
                            strerrormsg = ex.Message.ToString
                            interrorcode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oracommand
                        .CommandText = "CATALOGUE.SP_CAT_DIC_MEDIUM_INDEX_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strAccessEntry", OracleType.VarChar, 6)).Value = strAccessEntry
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsdata, "CAT_DIC_MEDIUM_INDEX")
                            Retrieve = dsdata.Tables("CAT_DIC_MEDIUM_INDEX")
                            dsdata.Tables.Remove("CAT_DIC_MEDIUM_INDEX")
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