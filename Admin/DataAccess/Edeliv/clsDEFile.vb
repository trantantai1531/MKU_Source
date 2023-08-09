' Name: clsDEFile
' Purpose: Management file information
' Creator: Oanhtn
' Created Date: 01/11/2004
' Modification History:

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Edeliv
    Public Class clsDEFile
        Inherits clsDBase

        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************

        Private dblSizeOfFile As Double
        Private dblPriceOfFile As Double
        Private strNote As String
        Private strTypeOfFile As String
        Private strCurrency As String
        Private lngFileID As Long

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' GetFileInfor method
        ' Purpose: Get information of the selected file
        ' Input: FileID
        ' Output: datatable result
        Public Function GetFileInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_GET_EDELIV_FILEINFOR"
                        .CommandType = CommandType.StoredProcedure
                        Try

                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetFileInfor = dsData.Tables("tblResult")
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
                        .CommandText = "SP_GET_EDELIV_FILEINFOR"
                        .CommandType = CommandType.StoredProcedure
                        Try

                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetFileInfor = dsData.Tables("tblResult")
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


        Public Function StatisFileUpload(Optional ByVal strCateloguer As String = "", Optional ByVal strDateFrom As String = "", Optional ByVal strDateTo As String = "", Optional ByVal intStatus As Integer = 3, Optional ByVal intType As Integer = 0)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"

                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemFile_StatisFileUpload"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strCataloguer", SqlDbType.NVarChar, 255)).Value = strCateloguer
                                .Add(New SqlParameter("@strDateUploadFrom", SqlDbType.VarChar, 20)).Value = strDateFrom
                                .Add(New SqlParameter("@strDateUploadTo", SqlDbType.VarChar, 20)).Value = strDateTo
                                .Add(New SqlParameter("@intStatus", SqlDbType.Int)).Value = intStatus
                                .Add(New SqlParameter("@intType", SqlDbType.Int)).Value = intType
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            StatisFileUpload = dsData.Tables("tblResult")
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