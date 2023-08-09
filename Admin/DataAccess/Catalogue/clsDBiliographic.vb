' Purpose: process form
' Creator: Oanhtn
' Created Date: 14/04/2004
' Modification history:

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Catalogue
    Public Class clsDBiliographic
        Inherits clsDBase

        ' *****************************************************************************************************
        ' Declare Private variables
        ' *****************************************************************************************************

        Public intType As Integer
        Public intBibliographicID As Integer
        Private lngTORs As Long
        Private strTitle As String
        Private strGroupedBy As String
        Private strCreatedDate As String
        Private strLastModifiedDate As String

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' Type property
        Public Property Type() As Integer
            Get
                Return intType
            End Get
            Set(ByVal Value As Integer)
                intType = Value
            End Set
        End Property

        ' BibliographicID property
        Public Property BibliographicID() As Integer
            Get
                Return intBibliographicID
            End Get
            Set(ByVal Value As Integer)
                intBibliographicID = Value
            End Set
        End Property

        ' TORs property
        Public Property TORs() As Long
            Get
                Return lngTORs
            End Get
            Set(ByVal Value As Long)
                lngTORs = Value
            End Set
        End Property

        ' FieldName property
        Public Property Title() As String
            Get
                Return strTitle
            End Get
            Set(ByVal Value As String)
                strTitle = Value
            End Set
        End Property

        ' GroupedBy property
        Public Property GroupedBy() As String
            Get
                Return strGroupedBy
            End Get
            Set(ByVal Value As String)
                strGroupedBy = Value
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

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Create method
        ' Purpose: Create new template
        ' Output: int value of created biliographic
        Public Function Create() As Integer
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CAT_BIBLIOGRAPHIC_INS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                            .Parameters.Add(New OracleParameter("lngTORs", OracleType.Number)).Value = lngTORs
                            .Parameters.Add(New OracleParameter("strTitle", OracleType.VarChar, 100)).Value = strTitle
                            .Parameters.Add(New OracleParameter("strGroupedBy", OracleType.VarChar, 5)).Value = strGroupedBy
                            .Parameters.Add(New OracleParameter("strCreatedDate", OracleType.VarChar, 30)).Value = strCreatedDate
                            '.Parameters.Add(New OracleParameter("intBibliographicID", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            'intBibliographicID = .Parameters("intBibliographicID").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spBibliography_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("intUserID", SqlDbType.Int)).Value = intUserID
                            .Parameters.Add(New SqlParameter("lngTORs", SqlDbType.Int)).Value = lngTORs
                            .Parameters.Add(New SqlParameter("strTitle", SqlDbType.NVarChar, 100)).Value = strTitle
                            .Parameters.Add(New SqlParameter("strGroupedBy", SqlDbType.VarChar, 5)).Value = strGroupedBy
                            .Parameters.Add(New SqlParameter("strCreatedDate", SqlDbType.VarChar, 30)).Value = strCreatedDate
                            '.Parameters.Add(New SqlParameter("intBibliographicID", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            'intBibliographicID = .Parameters("intBibliographicID").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
        End Function

        ' Modify method
        ' Purpose: Modify the content of the selected template
        Public Sub Modify()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CAT_BIBLIOGRAPHIC_UPD"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intType", OracleType.Number)).Value = intType
                            .Parameters.Add(New OracleParameter("intBibliographicID", OracleType.Number)).Value = intBibliographicID
                            .Parameters.Add(New OracleParameter("lngTORs", OracleType.Number)).Value = lngTORs
                            .Parameters.Add(New OracleParameter("strLastModifiedDate", OracleType.VarChar, 30)).Value = strLastModifiedDate
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spBibliography_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("intType", SqlDbType.Int)).Value = intType
                            .Parameters.Add(New SqlParameter("intBibliographicID", SqlDbType.Int)).Value = intBibliographicID
                            .Parameters.Add(New SqlParameter("lngTORs", SqlDbType.Int)).Value = lngTORs
                            .Parameters.Add(New SqlParameter("strLastModifiedDate", SqlDbType.VarChar, 30)).Value = strLastModifiedDate
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
        End Sub

        ' Delete method
        ' Purpose: Delete the selected template
        ' Output: int value of the selected biliographic
        Public Sub Delete()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CAT_BIBLIOGRAPHIC_DEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intBibliographicID", OracleType.Number)).Value = intBibliographicID
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spBibliography_Del"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("intBibliographicID", SqlDbType.Int)).Value = intBibliographicID
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
        End Sub

        ' GetBibliographics method
        ' Purpose: Get all systemplate
        Public Function GetBibliographics() As DataTable
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CAT_BIBLIOGRAPHIC_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                            .Parameters.Add(New OracleParameter("intBibliographicID", OracleType.Number)).Value = intBibliographicID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter = New OracleDataAdapter(oraCommand)
                            oraDataAdapter.Fill(dsData, "MARCFIELDS")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spBibliography_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                            .Parameters.Add(New SqlParameter("@intBibliographicID", SqlDbType.Int)).Value = intBibliographicID
                            SqlDataAdapter = New SqlDataAdapter(SqlCommand)
                            SqlDataAdapter.Fill(dsData, "MARCFIELDS")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Return dsData.Tables(0)
            dsData.Tables(0).Clear()
            dsData.Tables(0).Dispose()
        End Function
    End Class
End Namespace