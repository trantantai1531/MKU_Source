' Name: clsDRepository
' Purpose: 
' Creator: Kiemdv
' Created Date: 20/10/2004
' Modification History:

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibOPAC.DataAccess.OPAC
    Public Class clsDOAIRepository
        Inherits clsDBase
        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************

        Private strURLResource As String
        Private strFromDate As String
        Private strToDate As String
        Private strMetadataPrefix As String
        Private strIdentifier As String
        Private strOAISet As String
        Private strResumptionToken As String

        Private strIDs As String
        Private strFile As String
        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' URLResource Property
        Public Property URLResource() As String
            Get
                Return strURLResource
            End Get
            Set(ByVal Value As String)
                strURLResource = Value
            End Set
        End Property

        ' FromDate Property
        Public Property FromDate() As String
            Get
                Return strFromDate
            End Get
            Set(ByVal Value As String)
                strFromDate = Value
            End Set
        End Property

        ' ToDate Property
        Public Property ToDate() As String
            Get
                Return strToDate
            End Get
            Set(ByVal Value As String)
                strToDate = Value
            End Set
        End Property

        ' MetadataPrefix Property
        Public Property MetadataPrefix() As String
            Get
                Return strMetadataPrefix
            End Get
            Set(ByVal Value As String)
                strMetadataPrefix = Value
            End Set
        End Property

        ' Identifier Property
        Public Property Identifier()
            Get
                Return strIdentifier
            End Get
            Set(ByVal Value)
                strIdentifier = Value
            End Set
        End Property

        ' OAISet Property
        Public Property OAISet() As String
            Get
                Return strOAISet
            End Get
            Set(ByVal Value As String)
                strOAISet = Value
            End Set
        End Property

        ' ResumptionToken Property
        Public Property ResumptionToken() As String
            Get
                Return strResumptionToken
            End Get
            Set(ByVal Value As String)
                strResumptionToken = Value
            End Set
        End Property
        ' IDs property
        Public Property IDs() As String
            Get
                Return strIDs
            End Get
            Set(ByVal Value As String)
                strIDs = Value
            End Set
        End Property

        Public Property File() As String
            Get
                Return strFile
            End Get
            Set(ByVal Value As String)
                strFile = Value
            End Set
        End Property
        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************
        ' GetItemByOAI method
        ' Purpose: GetOAIItem
        ' Input: some main infor: , ...
        ' Output: DataTable
        Public Function GetItemByOAI() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "SP_OPAC_GET_ITEM_BY_OAI"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strOAISet", SqlDbType.VarChar, 50)).Value = strOAISet
                                .Add(New SqlParameter("@strFromDate", SqlDbType.VarChar, 10)).Value = strFromDate
                                .Add(New SqlParameter("@strToDate", SqlDbType.VarChar, 150)).Value = strToDate
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "OAIItem")
                            GetItemByOAI = dsData.Tables("OAIItem")
                            dsData.Tables.Remove("OAIItem")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SP_OPAC_GET_ITEM_BY_OAI"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strOAISet", OracleType.VarChar, 50)).Value = strOAISet
                                .Add(New OracleParameter("strFromDate", OracleType.VarChar, 10)).Value = strFromDate
                                .Add(New OracleParameter("strToDate", OracleType.VarChar, 150)).Value = strToDate
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            OraDataAdapter.SelectCommand = oraCommand
                            OraDataAdapter.Fill(dsData, "OAIItem")
                            GetItemByOAI = dsData.Tables("OAIItem")
                            dsData.Tables.Remove("OAIItem")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        ' GetOAIItemInfor method
        ' Purpose: GetOAIItemInfor
        ' Input: some main infor: , ...
        ' Output: DataTable
        Public Function GetOAIItemInfor() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "SP_OPAC_GET_OAI_ITEM_INFOR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strIDs", SqlDbType.VarChar, 8000)).Value = strIDs
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "OAIItem")
                            GetOAIItemInfor = dsData.Tables("OAIItem")
                            dsData.Tables.Remove("OAIItem")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SP_OPAC_GET_ITEM_BY_OAI"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strIDs", OracleType.VarChar, 2000)).Value = strIDs
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            OraDataAdapter.SelectCommand = oraCommand
                            OraDataAdapter.Fill(dsData, "OAIItem")
                            GetOAIItemInfor = dsData.Tables("OAIItem")
                            dsData.Tables.Remove("OAIItem")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        Public Function GetIdentifier() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "SP_OPAC_GET_IDENTIFIER"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strFile", SqlDbType.VarChar, 8000)).Value = strFile
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "OAIItem")
                            GetIdentifier = dsData.Tables("OAIItem")
                            dsData.Tables.Remove("OAIItem")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        ' GetOAIItemLeader method
        ' Purpose: GetOAIItemInfor
        ' Input: some main infor: , ...
        ' Output: DataTable
        Public Function GetOAIItemLeader() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "SP_OPAC_GET_OAI_ITEM_LEADER"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strIDs", SqlDbType.VarChar, 8000)).Value = strIDs
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "OAIItemLeader")
                            GetOAIItemLeader = dsData.Tables("OAIItemLeader")
                            dsData.Tables.Remove("OAIItemLeader")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SP_OPAC_GET_ITEM_BY_OAI"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strIDs", OracleType.VarChar, 2000)).Value = strIDs
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            OraDataAdapter.SelectCommand = oraCommand
                            OraDataAdapter.Fill(dsData, "OAIItemLeader")
                            GetOAIItemLeader = dsData.Tables("OAIItemLeader")
                            dsData.Tables.Remove("OAIItemLeader")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
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