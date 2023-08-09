' clsDAuthority class
' Purpose: process authority data
' Creator: Oanhtn
' Created Date: 20/05/2004
' Modification history:

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Catalogue
    Public Class clsDAuthority
        Inherits clsDBase

        ' *****************************************************************************************************
        ' Declare Private variables
        ' *****************************************************************************************************

        Private lngID As Long
        Private intFormID As Integer
        Private strLeader As String
        Private lngReferenceID As Long
        Private intSourceID As Integer
        Private intStatus As Integer
        Private strCode As String
        Private strDisplayEntry As String
        Private strAccessEntry As String
        Private strCataloguer As String
        Private strReviewer As String
        Private strCreatedDate As String
        Private strLastModifiedDate As String
        Private strAuthorityIDs As String

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' ID property
        Public Property ID() As Long
            Get
                Return lngID
            End Get
            Set(ByVal Value As Long)
                lngID = Value
            End Set
        End Property

        ' FormID property
        Public Property FormID() As Integer
            Get
                Return intFormID
            End Get
            Set(ByVal Value As Integer)
                intFormID = Value
            End Set
        End Property

        ' Leader property
        Public Property Leader() As String
            Get
                Return strLeader
            End Get
            Set(ByVal Value As String)
                strLeader = Value
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

        ' SourceID property
        Public Property SourceID() As Integer
            Get
                Return intSourceID
            End Get
            Set(ByVal Value As Integer)
                intSourceID = Value
            End Set
        End Property

        ' Status property
        Public Property Status() As Integer
            Get
                Return intStatus
            End Get
            Set(ByVal Value As Integer)
                intStatus = Value
            End Set
        End Property

        ' Code property
        Public Property Code() As String
            Get
                Return strCode
            End Get
            Set(ByVal Value As String)
                strCode = Value
            End Set
        End Property

        ' DisplayEntry property
        Public Property DisplayEntry() As String
            Get
                Return strDisplayEntry
            End Get
            Set(ByVal Value As String)
                strDisplayEntry = Value
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

        ' Cataloguer property
        Public Property Cataloguer() As String
            Get
                Return strCataloguer
            End Get
            Set(ByVal Value As String)
                strCataloguer = Value
            End Set
        End Property

        ' Reviewer property
        Public Property Reviewer() As String
            Get
                Return strReviewer
            End Get
            Set(ByVal Value As String)
                strReviewer = Value
            End Set
        End Property

        ' CreatedDate property
        Public Property CreatedDate() As String
            Get
                Return strCreatedDate
            End Get
            Set(ByVal Value As String)
                strCreatedDate = Value
            End Set
        End Property

        ' LastModifiedDate property
        Public Property LastModifiedDate() As String
            Get
                Return strLastModifiedDate
            End Get
            Set(ByVal Value As String)
                strLastModifiedDate = Value
            End Set
        End Property

        ' AuthorityIDs property
        Public Property AuthorityIDs() As String
            Get
                Return strAuthorityIDs
            End Get
            Set(ByVal Value As String)
                strAuthorityIDs = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' GetProperties method
        ' Purpose: Get all properties of the selected field
        Public Function GetAuthority() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CAT_AUTHORITY_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strAuthorityIDs", OracleType.VarChar, 1000)).Value = strAuthorityIDs
                            .Parameters.Add(New OracleParameter("lngReferenceID", OracleType.Number)).Value = lngReferenceID
                            .Parameters.Add(New OracleParameter("strAccessEntry", OracleType.VarChar, 400)).Value = strAccessEntry
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter = New OracleDataAdapter(oraCommand)
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
                        .CommandText = "Cat_spAuthority_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strAuthorityIDs", SqlDbType.VarChar)).Value = strAuthorityIDs
                            .Parameters.Add(New SqlParameter("@lngReferenceID", SqlDbType.Int)).Value = lngReferenceID
                            .Parameters.Add(New SqlParameter("@strAccessEntry", SqlDbType.NVarChar)).Value = strAccessEntry
                            SqlDataAdapter = New SqlDataAdapter(SqlCommand)
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

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                Call MyBase.Dispose(True)
            Finally
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace