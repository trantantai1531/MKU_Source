' Purpose: used to process catalogueform
' Creator: Oanhtn
' Created Date: 13/05/2004
' Modification history:
'   - 30/06/2004 by Oanhtn: allow modify contents of the selected Item
'           - Add new method: GetModiFields
'   - 13/8/2004 
'           - Add new method: GetAuthorityInfor method
'           Purpose: Retrieve  Authority infor by searching

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType
Imports eMicLibAdmin.DataAccess.Common

Namespace eMicLibAdmin.DataAccess.Catalogue
    Public Class clsDCatalogueForm
        Inherits clsDForm

        ' *****************************************************************************************************
        ' Declare Private variables
        ' *****************************************************************************************************

        Private strAddedFieldCodes As String
        Private intGroupBy As Integer
        Private lngAuthorityID As Long
        Private strUsedFieldCodes As String
        Private strAccessEntry As String
        Private lngReferenceID As Long

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' AddedFieldCodes property
        Public Property AddedFieldCodes() As String
            Get
                Return strAddedFieldCodes
            End Get
            Set(ByVal Value As String)
                strAddedFieldCodes = Value
            End Set
        End Property

        ' GroupBy property
        Public Property GroupBy() As Integer
            Get
                Return intGroupBy
            End Get
            Set(ByVal Value As Integer)
                intGroupBy = Value
            End Set
        End Property

        ' AuthorityID property
        Public Property AuthorityID() As Long
            Get
                Return lngAuthorityID
            End Get
            Set(ByVal Value As Long)
                lngAuthorityID = Value
            End Set
        End Property

        ' UsedFieldCodes property
        Public Property UsedFieldCodes() As String
            Get
                Return strUsedFieldCodes
            End Get
            Set(ByVal Value As String)
                strUsedFieldCodes = Value
            End Set
        End Property

        ' AccessEntry property
        Public Property AccessEntry() As String
            Get
                Return strAccessEntry
            End Get
            Set(ByVal Value As String)
                strAccessEntry = Value
            End Set
        End Property

        ' ReferenceID property
        Public Property ReferenceID() As Long
            Get
                Return lngReferenceID
            End Get
            Set(ByVal Value As Long)
                lngReferenceID = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' GetCatalogueFields method
        ' Purpose: Get all fields of the selected catalogue form
        ' Output: datatable
        Public Function GetCatalogueFields() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_GET_CATALOGUE_FIELDS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIsAuthority", OracleType.Number)).Value = intIsAuthority
                            .Parameters.Add(New OracleParameter("intFormID", OracleType.Number)).Value = intFormID
                            .Parameters.Add(New OracleParameter("strFieldCodes", OracleType.VarChar, 1000)).Value = strFieldCodes
                            .Parameters.Add(New OracleParameter("strAddedFieldCodes", OracleType.VarChar, 1000)).Value = strAddedFieldCodes
                            .Parameters.Add(New OracleParameter("intGroupBy", OracleType.Number)).Value = intGroupBy
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblCatalogueFields")
                            GetCatalogueFields = dsData.Tables("tblCatalogueFields")
                            dsData.Tables.Remove("tblCatalogueFields")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spMARCAuthorityField_SelCatalogueFields"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIsAuthority", SqlDbType.Int)).Value = intIsAuthority
                            .Parameters.Add(New SqlParameter("@intFormID", SqlDbType.Int)).Value = intFormID
                            .Parameters.Add(New SqlParameter("@strFieldCodes", SqlDbType.VarChar)).Value = strFieldCodes
                            .Parameters.Add(New SqlParameter("@strAddedFieldCodes", SqlDbType.VarChar)).Value = strAddedFieldCodes
                            .Parameters.Add(New SqlParameter("@intGroupBy", SqlDbType.Int)).Value = intGroupBy
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblCatalogueFields")
                            GetCatalogueFields = dsData.Tables("tblCatalogueFields")
                            dsData.Tables.Remove("tblCatalogueFields")
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

        ' GetAuthority method
        ' Purpose: get Authoritydata from FieldAuthority
        ' Output: datatable
        Public Function GetAuthority() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_GET_AUTHORITY"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngAuthorityID", OracleType.Number)).Value = lngAuthorityID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetAuthority = dsData.Tables("tblResult")
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
                        .CommandText = "Lib_spMARCAuthorityField_SelByAuthorityId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngAuthorityID", SqlDbType.Int)).Value = lngAuthorityID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetAuthority = dsData.Tables("tblResult")
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

        ' GetModiFields method
        ' Purpose: Get all fields of the selected item to modify
        ' Output: datatable
        Public Function GetModiFields() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_GET_MODIFIED_FIELDS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIsAuthority", OracleType.Number)).Value = intIsAuthority
                            .Parameters.Add(New OracleParameter("intFormID", OracleType.Number)).Value = intFormID
                            .Parameters.Add(New OracleParameter("strFieldCodes", OracleType.VarChar, 1000)).Value = strFieldCodes
                            .Parameters.Add(New OracleParameter("strAddedFieldCodes", OracleType.VarChar, 1000)).Value = strAddedFieldCodes
                            .Parameters.Add(New OracleParameter("strUsedFieldCodes", OracleType.VarChar, 1000)).Value = strUsedFieldCodes
                            .Parameters.Add(New OracleParameter("intGroupBy", OracleType.Number)).Value = intGroupBy
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetModiFields = dsData.Tables("tblResult")
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
                        .CommandText = "Lib_spMARCBibField_SelModifiedFields"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIsAuthority", SqlDbType.Int)).Value = intIsAuthority
                            .Parameters.Add(New SqlParameter("@intFormID", SqlDbType.Int)).Value = intFormID
                            .Parameters.Add(New SqlParameter("@strFieldCodes", SqlDbType.VarChar)).Value = strFieldCodes
                            .Parameters.Add(New SqlParameter("@strAddedFieldCodes", SqlDbType.VarChar)).Value = strAddedFieldCodes
                            .Parameters.Add(New SqlParameter("@strUsedFieldCodes", SqlDbType.VarChar)).Value = strUsedFieldCodes
                            .Parameters.Add(New SqlParameter("@intGroupBy", SqlDbType.Int)).Value = intGroupBy
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetModiFields = dsData.Tables("tblResult")
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

        ' GetAuthorityInfor method
        Public Function GetAuthorityInfor(ByVal intISCode As Byte, ByVal intFormID As Byte) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_GET_AUTHORITY_ID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strAccessEntry", OracleType.VarChar, 200)).Value = strAccessEntry
                            .Parameters.Add(New OracleParameter("intReferenceID", OracleType.Number)).Value = lngReferenceID
                            .Parameters.Add(New OracleParameter("intFormID", OracleType.Number)).Value = intFormID
                            .Parameters.Add(New OracleParameter("intISCode", OracleType.Number)).Value = intISCode
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetAuthorityInfor = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spAuthority_SelEntry"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strAccessEntry", SqlDbType.NVarChar, 200)).Value = strAccessEntry
                            .Parameters.Add(New SqlParameter("@intReferenceID", SqlDbType.Int)).Value = lngReferenceID
                            .Parameters.Add(New SqlParameter("@intFormID", SqlDbType.Int)).Value = intFormID
                            .Parameters.Add(New SqlParameter("@intISCode", SqlDbType.Int)).Value = intISCode
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetAuthorityInfor = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Dispose method
        ' Purpose: Release all resources
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                MyBase.Dispose(True)
            Finally
                Me.Dispose()
            End Try
        End Sub

        ' Finalize method
        ' Purpose: Called when Dispose fail
        Protected Overrides Sub Finalize()
            Dispose(False)
        End Sub
    End Class
End Namespace