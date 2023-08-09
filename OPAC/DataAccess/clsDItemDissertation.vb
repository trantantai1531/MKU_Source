Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibOPAC.DataAccess.OPAC
    Public Class clsDItemDissertation
        Inherits clsDBase

        Private intItemDissertationID As Int16 = 0
        Private intItemID As Integer = 0
        Private strNumber As String = ""
        Private intYear As Integer = 0
        Private strPathImage As String = ""
        Private strPathFile As String = ""

        Public Property ItemDissertationID() As Int16
            Get
                Return intItemDissertationID
            End Get
            Set(ByVal Value As Int16)
                intItemDissertationID = Value
            End Set
        End Property
        Public Property ItemID() As Integer
            Get
                Return intItemID
            End Get
            Set(ByVal Value As Integer)
                intItemID = Value
            End Set
        End Property
        Public Property Number() As String
            Get
                Return strNumber
            End Get
            Set(ByVal Value As String)
                strNumber = Value
            End Set
        End Property
        Public Property Year() As Integer
            Get
                Return intYear
            End Get
            Set(ByVal Value As Integer)
                intYear = Value
            End Set
        End Property
        Public Property PathImage() As String
            Get
                Return strPathImage
            End Get
            Set(ByVal Value As String)
                strPathImage = Value
            End Set
        End Property
        Public Property PathFile() As String
            Get
                Return strPathFile
            End Get
            Set(ByVal Value As String)
                strPathFile = Value
            End Set
        End Property

        Public Function GetItemDissertationById() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemDissertation_GetById"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intId", SqlDbType.Int)).Value = intItemDissertationID
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemDissertationById = dsData.Tables("tblResult")
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
        Public Function GetItemDissertationYear() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemDissertation_GetYear"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intItemId", SqlDbType.Int)).Value = intItemID
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemDissertationYear = dsData.Tables("tblResult")
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

        Public Function GetItemDissertationNumber() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemDissertation_GetNumber"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intItemId", SqlDbType.Int)).Value = intItemID
                        .Parameters.Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = intYear
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemDissertationNumber = dsData.Tables("tblResult")
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

        Public Function GetItemDissertation() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemDissertation_GetItemDissertation"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intItemId", SqlDbType.Int)).Value = intItemID
                        .Parameters.Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = intYear
                        .Parameters.Add(New SqlParameter("@strNumber", SqlDbType.NVarChar, 50)).Value = strNumber
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemDissertation = dsData.Tables("tblResult")
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
                ' Release unmanaged resources.
                If Not dsData Is Nothing Then
                    dsData.Dispose()
                    dsData = Nothing
                End If
                If Not oraConnection Is Nothing Then
                    oraConnection.Dispose()
                    oraConnection = Nothing
                End If
                If Not oraCommand Is Nothing Then
                    oraCommand.Dispose()
                    oraCommand = Nothing
                End If
                If Not SqlConnection Is Nothing Then
                    SqlConnection.Dispose()
                    SqlConnection = Nothing
                End If
                If Not SqlCommand Is Nothing Then
                    SqlCommand.Dispose()
                    SqlCommand = Nothing
                End If
            Finally
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
