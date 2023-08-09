Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Patron
    Public Class clsDRequestCataloguer
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
        Private strPublishYear As Integer
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

        Public Function GetRequestCataloguer_ByID(ByVal intID As Integer) As DataTable
            Call OpenConnection()
            With sqlCommand
                .CommandText = "Cir_spPatron_SelByID_RequestCataloguer"
                .CommandType = CommandType.StoredProcedure
                Try
                    With .Parameters
                        .Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intID
                    End With
                    sqlDataAdapter.SelectCommand = sqlCommand
                    sqlDataAdapter.Fill(dsData, "tblResult")
                    GetRequestCataloguer_ByID = dsData.Tables("tblResult")
                    dsData.Tables.Remove("tblResult")
                Catch sqlClientEx As SqlException
                    strErrorMsg = sqlClientEx.Message.ToString
                    intErrorCode = sqlClientEx.Number
                Finally
                    .Parameters.Clear()
                End Try
            End With
            Call CloseConnection()
        End Function

        Public Function GetRequestCataloguer() As DataTable
            Call OpenConnection()
            With sqlCommand
                .CommandText = "Cir_spPatron_Sel_RequestCataloguer"
                .CommandType = CommandType.StoredProcedure
                Try
                    sqlDataAdapter.SelectCommand = sqlCommand
                    sqlDataAdapter.Fill(dsData, "tblResult")
                    GetRequestCataloguer = dsData.Tables("tblResult")
                    dsData.Tables.Remove("tblResult")
                Catch sqlClientEx As SqlException
                    strErrorMsg = sqlClientEx.Message.ToString
                    intErrorCode = sqlClientEx.Number
                Finally
                    .Parameters.Clear()
                End Try
            End With
            Call CloseConnection()
        End Function

        Public Function GetRequestCataloguerFill(Optional ByVal strDateFrom As String = "", Optional ByVal strDateTo As String = "") As DataTable
            Call OpenConnection()
            With sqlCommand
                .CommandText = "Cir_spPatron_Fill_RequestCataloguer"
                .CommandType = CommandType.StoredProcedure
                Try
                    With .Parameters
                        .Add(New SqlParameter("@strFullName", SqlDbType.NVarChar, 250)).Value = strFullName
                        .Add(New SqlParameter("@strPatronCode", SqlDbType.NVarChar, 50)).Value = strPatronCode
                        .Add(New SqlParameter("@strTitle", SqlDbType.NVarChar, 250)).Value = strTitle
                        .Add(New SqlParameter("@strDateFrom", SqlDbType.NVarChar, 10)).Value = strDateFrom
                        .Add(New SqlParameter("@strDateTo", SqlDbType.NVarChar, 10)).Value = strDateTo
                    End With
                    sqlDataAdapter.SelectCommand = sqlCommand
                    sqlDataAdapter.Fill(dsData, "tblResult")
                    GetRequestCataloguerFill = dsData.Tables("tblResult")
                    dsData.Tables.Remove("tblResult")
                Catch sqlClientEx As SqlException
                    strErrorMsg = sqlClientEx.Message.ToString
                    intErrorCode = sqlClientEx.Number
                Finally
                    .Parameters.Clear()
                End Try
            End With
            Call CloseConnection()
        End Function

        Public Function Delete(ByVal intID As Integer) As Integer
            Delete = 0
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spPatron_DelByID_RequestCataloguer"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intID
                            End With
                            .ExecuteNonQuery()
                            Delete = 1
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

        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                Call MyBase.Dispose(isDisposing)
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace

