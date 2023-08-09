Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibOPAC.DataAccess.OPAC
    Public Class clsDOpacRequestCataloguer
        Inherits clsDBase

        Private strFullName As String
        Private strPatronCode As String
        Private strEmail As String
        Private strPhone As String
        Private strFacebook As String
        Private strSupplier As String
        Private strGroupName As String
        Private strTitle As String
        Private strAuthor As String
        Private strPublisher As String
        Private strPublishYear As String
        Private strInformation As String

        Public Property FullName() As String
            Get
                Return strFullName
            End Get
            Set(ByVal Value As String)
                strFullName = Value
            End Set
        End Property

        Public Property PatronCode() As String
            Get
                Return strPatronCode
            End Get
            Set(ByVal Value As String)
                strPatronCode = Value
            End Set
        End Property

        Public Property Email() As String
            Get
                Return strEmail
            End Get
            Set(ByVal Value As String)
                strEmail = Value
            End Set
        End Property

        Public Property Phone() As String
            Get
                Return strPhone
            End Get
            Set(ByVal Value As String)
                strPhone = Value
            End Set
        End Property

        Public Property Facebook() As String
            Get
                Return strFacebook
            End Get
            Set(ByVal Value As String)
                strFacebook = Value
            End Set
        End Property

        Public Property Supplier() As String
            Get
                Return strSupplier
            End Get
            Set(ByVal Value As String)
                strSupplier = Value
            End Set
        End Property

        Public Property GroupName() As String
            Get
                Return strGroupName
            End Get
            Set(ByVal Value As String)
                strGroupName = Value
            End Set
        End Property

        Public Property Title() As String
            Get
                Return strTitle
            End Get
            Set(ByVal Value As String)
                strTitle = Value
            End Set
        End Property

        Public Property Author() As String
            Get
                Return strAuthor
            End Get
            Set(ByVal Value As String)
                strAuthor = Value
            End Set
        End Property

        Public Property Publisher() As String
            Get
                Return strPublisher
            End Get
            Set(ByVal Value As String)
                strPublisher = Value
            End Set
        End Property

        Public Property PublishYear() As String
            Get
                Return strPublishYear
            End Get
            Set(ByVal Value As String)
                strPublishYear = Value
            End Set
        End Property

        Public Property Information() As String
            Get
                Return strInformation
            End Get
            Set(ByVal Value As String)
                strInformation = Value
            End Set
        End Property

        Public Function Insert() As Integer
            Dim intRetval As Integer = 0
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Opac_spPatron_Ins_RequestCataloguer"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strFullName", SqlDbType.NVarChar, 250)).Value = strFullName
                                .Add(New SqlParameter("@strPatronCode", SqlDbType.NVarChar, 50)).Value = strPatronCode
                                .Add(New SqlParameter("@strEmail", SqlDbType.NVarChar, 250)).Value = strEmail
                                .Add(New SqlParameter("@strPhone", SqlDbType.NVarChar, 20)).Value = strPhone
                                .Add(New SqlParameter("@strFacebook", SqlDbType.NVarChar, 250)).Value = strFacebook
                                .Add(New SqlParameter("@strSupplier", SqlDbType.NVarChar, 250)).Value = strSupplier
                                .Add(New SqlParameter("@strGroupName", SqlDbType.NVarChar, 250)).Value = strGroupName
                                .Add(New SqlParameter("@strTitle", SqlDbType.NVarChar, 250)).Value = strTitle
                                .Add(New SqlParameter("@strAuthor", SqlDbType.NVarChar, 250)).Value = strAuthor
                                .Add(New SqlParameter("@strPublisher", SqlDbType.NVarChar, 250)).Value = strPublisher
                                .Add(New SqlParameter("@strPublishYear", SqlDbType.NVarChar, 250)).Value = strPublishYear
                                .Add(New SqlParameter("@strInformation", SqlDbType.NVarChar, 2000)).Value = strInformation
                            End With
                            .ExecuteNonQuery()
                            intRetval = 1
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
            Insert = intRetval
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
                    If Not sqlConnection Is Nothing Then
                        sqlConnection.Dispose()
                        sqlConnection = Nothing
                    End If
                    If Not sqlCommand Is Nothing Then
                        sqlCommand.Dispose()
                        sqlCommand = Nothing
                    End If
                    If Not sqlDataAdapter Is Nothing Then
                        sqlDataAdapter.Dispose()
                        sqlDataAdapter = Nothing
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

