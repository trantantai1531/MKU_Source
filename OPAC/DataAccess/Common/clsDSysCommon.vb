Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibOPAC.DataAccess.Common
    Public Class clsDSysCommon
        Inherits clsDBase
        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private strCondition As String
        Private strFileName As String
        Private strCreatedDate As String
        Private intCount As Integer

        ' *************************************************************************************************
        ' Declare public properties
        ' *************************************************************************************************
        ' ---- Condition Property
        Public Property Condition() As String
            Get
                Condition = strCondition
            End Get
            Set(ByVal Value As String)
                strCondition = Value
            End Set
        End Property

        ' ---- Condition Property
        Public Property FileName() As String
            Get
                FileName = strFileName
            End Get
            Set(ByVal Value As String)
                strFileName = Value
            End Set
        End Property

        ' ---- Condition Property
        Public Property CreatedDate() As String
            Get
                CreatedDate = strCreatedDate
            End Get
            Set(ByVal Value As String)
                strCreatedDate = Value
            End Set
        End Property

        ' *************************************************************************************************
        ' Implement methods here
        ' *************************************************************************************************

        ' *************************************************************************************************
        ' Method: RetrieveSysDownloadFile
        ' Purpose: Retrieve temporary file from table SYS_DOWNLOAD_FILE
        ' Input: strCondition like: ' WHERE FileName like %abc%'
        ' Output:  datatable
        ' *************************************************************************************************                
        Public Function GetSysDownloadFile() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "COMMON.Sys_spDownloadFile_Sel"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("strWhere", OracleType.VarChar, 200)).Value = strCondition
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(DSdata, "TEMPORARYFILE")
                            GetSysDownloadFile = DSdata.Tables("TEMPORARYFILE")
                            DSdata.Tables.Remove("TEMPORARYFILE")
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Sys_spDownloadFile_Sel"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strCondition", SqlDbType.VarChar, 200)).Value = strCondition
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(DSdata, "TEMPORARYFILE")
                            GetSysDownloadFile = DSdata.Tables("TEMPORARYFILE")
                            DSdata.Tables.Remove("TEMPORARYFILE")
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' *************************************************************************************************
        ' Method: RetrieveSysDownloadFile
        ' Purpose: Delete temporary file from table SYS_DOWNLOAD_FILE
        ' Input: strCondition like: ' WHERE FileName like %abc%'
        ' Output:  boolean
        ' *************************************************************************************************                        
        Public Function DeleteSysDownloadFile() As Boolean
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "COMMON.Sys_spDownloadFile_Del"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("strCondition", OracleType.VarChar, 200)).Value = strCondition
                        Try
                            .ExecuteNonQuery()
                            DeleteSysDownloadFile = True
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Sys_spDownloadFile_Del"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strCondition", SqlDbType.VarChar, 200)).Value = strCondition
                        Try
                            .ExecuteNonQuery()
                            DeleteSysDownloadFile = True
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' *************************************************************************************************
        ' Method: RetrieveSysDownloadFile
        ' Purpose: Insert new record into table SYS_DOWNLOAD_FILE
        ' Input: strFileName, dtCreateDate
        ' Output:  boolean
        ' *************************************************************************************************                                
        Public Function InsertSysDownloadFile() As Boolean
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "COMMON.Sys_spDownloadFile_Ins"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("strFileName", OracleType.VarChar, 200)).Value = strFileName
                        .Parameters.Add(New OracleParameter("dtCreatedDate", OracleType.DateTime, 8)).Value = strCreatedDate
                        Try
                            .ExecuteNonQuery()
                            InsertSysDownloadFile = True
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Sys_spDownloadFile_Ins"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strFileName", SqlDbType.VarChar, 20)).Value = strFileName
                        .Parameters.Add(New SqlParameter("@dtCreatedDate", SqlDbType.DateTime)).Value = strCreatedDate
                        Try
                            .ExecuteNonQuery()
                            InsertSysDownloadFile = True
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' *************************************************************************************************
        ' Dispose method
        ' Purpose: Release all resource
        ' *************************************************************************************************
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
