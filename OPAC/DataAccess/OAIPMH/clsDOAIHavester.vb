' Name: clsDOAIHavester
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
    Public Class clsDOAIHavester
        Inherits clsDBase
        ' ************************************************************************************************
        ' Declare Private variables
        ' ************************************************************************************************

        Private strURLResource As String
        Private strFromDate As String
        Private strToDate As String
        Private strMetadataPrefix As String
        Private strIdentifier As String
        Private strOAISet As String
        Private strResumptionToken As String
        Private intID As Integer

        ' ************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' ************************************************************************************************

        ' IDResource Property
        Public Property ID() As Integer
            Get
                Return intID
            End Get
            Set(ByVal Value As Integer)
                intID = Value
            End Set
        End Property

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

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' CreateURLResource method
        ' Purpose: Create URLResource
        ' Input: some main infor: URLResource, ...
        ' Output: 0 if fail, else is Max(ID)
        Public Function CreateURLResource() As Integer
            Try
                Me.OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"

                    Case "ORACLE"

                End Select
                Me.CloseConnection()
            Catch ex As Exception

            End Try
        End Function

        ' UpdateURLResource method
        ' Purpose: Update URLResource
        ' Input: some main infor: ID, URLResource, ...
        ' Output: 0 if fail, else is CurrentID
        Public Function UpdateURLResource() As Integer
            Try
                Me.OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"

                    Case "ORACLE"

                End Select
                Me.CloseConnection()
            Catch ex As Exception

            End Try
        End Function

        ' DeleteURLResource method
        ' Purpose: Delete URLResource
        ' Input: some main infor: ID, ...
        ' Output: 0 if fail, else is CurrentID
        Public Function DeleteURLResource() As Integer
            Try
                Me.OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"

                    Case "ORACLE"

                End Select
                Me.CloseConnection()
            Catch ex As Exception

            End Try
        End Function

        ' GetURLResource method
        ' Purpose: Get URLResource
        ' Input: intID
        ' Output: DataTable
        Public Function GetURLResource() As DataTable
            Try
                Me.OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With SqlCommand
                            .CommandText = "SP_GET_OAI_URL"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intID
                            Try
                                SqlDataAdapter.SelectCommand = SqlCommand
                                SqlDataAdapter.Fill(dsData, "tblOAIURL")
                                GetURLResource = dsData.Tables("tblOAIURL")
                                dsData.Tables.Remove("tblOAIURL")
                            Catch sqlClientEx As SqlException
                                strErrorMsg = sqlClientEx.Message.ToString
                                intErrorCode = sqlClientEx.Number
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "ORACLE"
                        With oraCommand
                            .CommandText = "OPAC.SP_GET_OAI_URL"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                .Parameters.Add(New OracleParameter("intID", OracleType.Number)).Value = intID
                                .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsData, "tblOAIURL")
                                GetURLResource = dsData.Tables("tblOAIURL")
                                dsData.Tables.Remove("tblOAIURL")
                            Catch OraEx As OracleException
                                strErrorMsg = OraEx.Message.ToString
                                intErrorCode = OraEx.Code
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
                Me.CloseConnection()
            Catch ex As Exception
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