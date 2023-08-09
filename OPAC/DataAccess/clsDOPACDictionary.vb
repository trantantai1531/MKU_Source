Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibOPAC.DataAccess.OPAC
    Public Class clsDOPACDictionary
        Inherits clsDBase
        ' ***********************************************************************************************
        ' Declare Private variables
        ' ***********************************************************************************************

        Private strAccessEntry As String
        Private strDicName As String
        Private strDirection As String
        Private intDicType As Integer

        ' ***********************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' ***********************************************************************************************

        ' AccessEntry Property
        Public Property AccessEntry() As String
            Get
                Return strAccessEntry
            End Get
            Set(ByVal Value As String)
                strAccessEntry = Value
            End Set
        End Property

        ' DicName Property
        Public Property DicName() As String
            Get
                Return strDicName
            End Get
            Set(ByVal Value As String)
                strDicName = Value
            End Set
        End Property

        ' Direction Property
        Public Property Direction() As String
            Get
                Return strDirection
            End Get
            Set(ByVal Value As String)
                strDirection = Value
            End Set
        End Property

        ' intDicType Property
        Public Property DicType() As Integer
            Get
                Return intDicType
            End Get
            Set(ByVal Value As Integer)
                intDicType = Value
            End Set
        End Property

        ' ***********************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' ***********************************************************************************************

        Public Function GetDictionary(ByVal strSQL As String) As DataTable
            Try
                Me.OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With SqlCommand
                            .CommandText = "Opac_spDictionary"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New SqlParameter("@strSQL", SqlDbType.NVarChar)).Value = strSQL
                                End With
                                SqlDataAdapter.SelectCommand = SqlCommand
                                sqlDataAdapter.Fill(dsData, "Opac_spDictionary")
                                GetDictionary = dsData.Tables("Opac_spDictionary")
                            Catch sqlClientEx As SqlException
                                strErrorMsg = sqlClientEx.Message.ToString
                                intErrorCode = sqlClientEx.Number
                            Finally
                                .Parameters.Clear()
                                dsData.Tables.Remove("Opac_spDictionary")
                            End Try
                        End With
                    Case "ORACLE"
                        With OraCommand
                            .CommandText = "OPAC.Opac_spDictionary"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New OracleParameter("strSQL", OracleType.VarChar)).Value = strSQL
                                    .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                End With
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsData, "Opac_spDictionary")
                                GetDictionary = dsData.Tables("Opac_spDictionary")
                            Catch OraEx As OracleException
                                strErrorMsg = OraEx.Message.ToString
                                intErrorCode = OraEx.Code
                            Finally
                                dsData.Tables.Remove("Opac_spDictionary")
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
                Me.CloseConnection()
            Catch ex As Exception
                strerrormsg = ex.Message
            End Try
        End Function

        ' GetCatDicList method
        ' Purpose: Get information of Catdiclist table
        Public Function GetCatDicList2Field(Optional ByVal intID As Integer = 0) As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spDicList_SelNameAndIdByIdWithIndex"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblCatDicList2Field")
                            GetCatDicList2Field = dsData.Tables("tblCatDicList2Field")
                            dsData.Tables.Remove("tblCatDicList2Field")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oracommand
                        .CommandText = "OPAC.Cat_spDicList_SelNameAndIdByIdWithIndex"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intID", OracleType.Number)).Value = intID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblCatDicList2Field")
                            GetCatDicList2Field = dsData.Tables("tblCatDicList2Field")
                            dsData.Tables.Remove("tblCatDicList2Field")
                        Catch oraClientEx As OracleException
                            strErrorMsg = oraClientEx.Message.ToString
                            intErrorCode = oraClientEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function
        ' GetCatDicList method
        ' Purpose: Get information of Catdiclist table
        ' Input: intID (optional default=0)
        ' Output: DataTable
        ' Creator: dgsoft
        Public Function GetCatDicList(Optional ByVal intID As Integer = 0) As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spDicList_SelByIdWithIndex"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblCatDicList")
                            GetCatDicList = dsData.Tables("tblCatDicList")
                            dsData.Tables.Remove("tblCatDicList")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oracommand
                        .CommandText = "OPAC.Cat_spDicList_SelByIdWithIndex"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intID", OracleType.Number)).Value = intID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblCatDicList")
                            GetCatDicList = dsData.Tables("tblCatDicList")
                            dsData.Tables.Remove("tblCatDicList")
                        Catch oraClientEx As OracleException
                            strErrorMsg = oraClientEx.Message.ToString
                            intErrorCode = oraClientEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function


        ' Purpose: get Item from dictionary AccessEntry
        ' Input: dictionary AccessEntry
        ' Output: datatable
        ' Created by: PhuongTT
        ' Date : 2014.09.06
        Public Function getItemFromDictionaryAccessEntry(ByVal intItemID As Integer, Optional ByVal intLibID As Integer = 0) As DataTable
            Try
                Me.OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With sqlCommand
                            .CommandText = "Cat_spDicSerCategory_SelRelation"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                .Parameters.Add(New SqlParameter("@intDicID", SqlDbType.Int)).Value = DicType
                                .Parameters.Add(New SqlParameter("@strDIC", SqlDbType.NVarChar, 200)).Value = AccessEntry
                                .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                                .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                sqlDataAdapter.SelectCommand = sqlCommand
                                sqlDataAdapter.Fill(dsData, "tblDictionaryAccessEntry")
                                getItemFromDictionaryAccessEntry = dsData.Tables("tblDictionaryAccessEntry")
                            Catch sqlClientEx As SqlException
                                strErrorMsg = sqlClientEx.Message
                                intErrorCode = sqlClientEx.Number
                            Finally
                                .Parameters.Clear()
                                dsData.Tables.Remove("tblDictionaryAccessEntry")
                            End Try
                        End With
                    Case "ORACLE"
                        With oraCommand
                            .CommandType = CommandType.StoredProcedure
                            .CommandText = "OPAC.Cat_spDicSerCategory_SelRelation"
                            Try
                                .Parameters.Add(New OracleParameter("intDicID", OracleType.Number)).Value = DicType
                                .Parameters.Add(New OracleParameter("strDIC", OracleType.NVarChar, 200)).Value = AccessEntry
                                .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = intItemID
                                .Parameters.Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                                .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsData, "tblDictionaryAccessEntry")
                                getItemFromDictionaryAccessEntry = dsData.Tables("tblDictionaryAccessEntry")
                            Catch OraEx As OracleException
                                strErrorMsg = OraEx.Message.ToString
                                intErrorCode = OraEx.Code
                            Finally
                                .Parameters.Clear()
                                dsData.Tables.Remove("tblDictionaryAccessEntry")
                            End Try
                        End With
                End Select
                Me.CloseConnection()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
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