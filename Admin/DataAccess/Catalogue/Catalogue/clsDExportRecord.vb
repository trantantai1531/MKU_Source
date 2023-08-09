Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Catalogue
    Public Class clsDExportRecord
        Inherits clsDBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Private intID As Integer
        Private intCount As Integer
        Private strTerm As String
        Private intReferenceID As String
        Private intSourceID As Integer
        Private strCataFrom As String
        Private strCataTo As String
        Private intFromID As Integer
        Private intToID As Integer
        Private strAccessEntry As String

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' AccessEntry Property
        Public Property AccessEntry() As String
            Get
                Return strAccessEntry
            End Get
            Set(ByVal Value As String)
                strAccessEntry = Value
            End Set
        End Property

        ' Term property
        Public Property Term() As String
            Get
                Return strTerm
            End Get
            Set(ByVal Value As String)
                strTerm = Value
            End Set
        End Property

        ' ReferenceID property
        Public Property ReferenceID() As Integer
            Get
                Return intReferenceID
            End Get
            Set(ByVal Value As Integer)
                intReferenceID = Value
            End Set
        End Property

        ' SourceID property
        Public Property SourceID() As Integer
            Get
                Return intSourceID
            End Get
            Set(ByVal Value As Integer)
                intSourceID = Value
            End Set
        End Property

        ' CataFrom property
        Public Property CataFrom() As String
            Get
                Return strCataFrom
            End Get
            Set(ByVal Value As String)
                strCataFrom = Value
            End Set
        End Property

        ' CataTo property
        Public Property CataTo() As String
            Get
                Return strCataTo
            End Get
            Set(ByVal Value As String)
                strCataTo = Value
            End Set
        End Property

        ' FromID property
        Public Property FromID() As Integer
            Get
                Return intFromID
            End Get
            Set(ByVal Value As Integer)
                intFromID = Value
            End Set
        End Property

        ' ToID property
        Public Property ToID() As Integer
            Get
                Return intToID
            End Get
            Set(ByVal Value As Integer)
                intToID = Value
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

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' GetAuthorityMainInfor
        ' Purpose: Get main authority data
        ' Input: somecondition
        ' Ouput: datatable result
        Public Function GetAuthorityMainInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_GET_AUTHORITY_MINFOR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strTerm", OracleType.VarChar, 200)).Value = strTerm
                            .Parameters.Add(New OracleParameter("intReferenceID", OracleType.Number)).Value = intReferenceID
                            .Parameters.Add(New OracleParameter("intSourceID", OracleType.VarChar, 200)).Value = intSourceID
                            .Parameters.Add(New OracleParameter("strCataFrom", OracleType.VarChar, 30)).Value = strCataFrom
                            .Parameters.Add(New OracleParameter("strCataTo", OracleType.VarChar, 30)).Value = strCataTo
                            .Parameters.Add(New OracleParameter("intFromID", OracleType.Number)).Value = intFromID
                            .Parameters.Add(New OracleParameter("intToID", OracleType.Number)).Value = intToID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetAuthorityMainInfor = dsData.Tables("tblResult")
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
                        .CommandText = "Cat_spAuthority_SelMainInfor"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strTerm", SqlDbType.NVarChar)).Value = strTerm
                            .Parameters.Add(New SqlParameter("@intReferenceID", SqlDbType.Int)).Value = intReferenceID
                            .Parameters.Add(New SqlParameter("@intSourceID", SqlDbType.Int)).Value = intSourceID
                            .Parameters.Add(New SqlParameter("@strCataFrom", SqlDbType.VarChar)).Value = strCataFrom
                            .Parameters.Add(New SqlParameter("@strCataTo", SqlDbType.VarChar)).Value = strCataTo
                            .Parameters.Add(New SqlParameter("@intFromID", SqlDbType.Int)).Value = intFromID
                            .Parameters.Add(New SqlParameter("@intToID", SqlDbType.Int)).Value = intToID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetAuthorityMainInfor = dsData.Tables("tblResult")
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

        ' Method: GetAuthorityDetailInfor
        ' Purpose: Get detail (field) information of authority data
        ' Input: some conditions
        ' Ouput: datatable result
        Public Function GetAuthorityDetailInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_GET_AUTHORITY_DINFOR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strTerm", OracleType.VarChar, 200)).Value = strTerm
                            .Parameters.Add(New OracleParameter("intReferenceID", OracleType.Number)).Value = intReferenceID
                            .Parameters.Add(New OracleParameter("intSourceID", OracleType.Number)).Value = intSourceID
                            .Parameters.Add(New OracleParameter("strCataFrom", OracleType.VarChar, 30)).Value = strCataFrom
                            .Parameters.Add(New OracleParameter("strCataTo", OracleType.VarChar, 30)).Value = strCataTo
                            .Parameters.Add(New OracleParameter("intFromID", OracleType.Number)).Value = intFromID
                            .Parameters.Add(New OracleParameter("intToID", OracleType.Number)).Value = intToID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetAuthorityDetailInfor = dsData.Tables("tblResult")
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
                        .CommandText = "Cat_spAuthority_SelDetailInfor"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strTerm", SqlDbType.NVarChar)).Value = strTerm
                            .Parameters.Add(New SqlParameter("@intReferenceID", SqlDbType.Int)).Value = intReferenceID
                            .Parameters.Add(New SqlParameter("@intSourceID", SqlDbType.Int)).Value = intSourceID
                            .Parameters.Add(New SqlParameter("@strCataFrom", SqlDbType.VarChar)).Value = strCataFrom
                            .Parameters.Add(New SqlParameter("@strCataTo", SqlDbType.VarChar)).Value = strCataTo
                            .Parameters.Add(New SqlParameter("@intFromID", SqlDbType.Int)).Value = intFromID
                            .Parameters.Add(New SqlParameter("@intToID", SqlDbType.Int)).Value = intToID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetAuthorityDetailInfor = dsData.Tables("tblResult")
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

        ' GetClassficationData
        ' Purpose: Get classification data to export
        ' Input: some conditions
        ' Ouput: datatable redult
        Public Function GetClassficationData() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_GET_CLASSIFIC_ITEMS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strAccessEntry", OracleType.VarChar, 100)).Value = strAccessEntry
                            .Parameters.Add(New OracleParameter("intFromID", OracleType.Number)).Value = intFromID
                            .Parameters.Add(New OracleParameter("intToID", OracleType.Number)).Value = intToID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetClassficationData = dsData.Tables("tblResult")
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
                        .CommandText = "SP_CATA_GET_CLASSIFICATION_ITEMS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strAccessEntry", SqlDbType.NVarChar, 100)).Value = strAccessEntry
                            .Parameters.Add(New SqlParameter("@intFromID", SqlDbType.Int)).Value = intFromID
                            .Parameters.Add(New SqlParameter("@intToID", SqlDbType.Int)).Value = intToID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetClassficationData = dsData.Tables("tblResult")
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

        ' GetSourceAuthority method
        ' Purpose: Get authority source
        ' Output: result datatable
        Public Function GetSourceAuthority() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_GET_AUTHORITYSOURCE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetSourceAuthority = dsData.Tables("tblResult")
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
                        .CommandText = "Lib_spHoldingLibrary_SelAuthoritySource"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetSourceAuthority = dsData.Tables("tblResult")
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
                Call MyBase.Dispose(isDisposing)
            Finally
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace