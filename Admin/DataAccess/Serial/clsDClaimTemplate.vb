' Name: clsDClaimTemplate
' Purpose: Management claim template
' Creator: Oanhtn
' Created Date: 20/09/2004
' Modification History:
'+) by Sondp

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Serial
    Public Class clsDClaimTemplate
        Inherits clsDBase

        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************

        Dim intItemID As Integer
        Dim strFileName As String
        Dim dtCreatedDate As DateTime
        Dim strIDs As String

        'get/set IDs property
        Public Property IDs() As String
            Get
                Return (strIDs)
            End Get
            Set(ByVal Value As String)
                strIDs = Value
            End Set
        End Property

        'get/set strFileName to inrert into table SYS_DOWNLOAD_FILE
        Public Property DownloadFileName() As String
            Get
                Return (strFileName)
            End Get
            Set(ByVal Value As String)
                strFileName = Value
            End Set
        End Property

        'get/set dtCreatedDate to insert into table SYS_DOWNLOAD_FILE
        Public Property DownloadFileCreateDate() As DateTime
            Get
                Return (dtCreatedDate)
            End Get
            Set(ByVal Value As DateTime)
                dtCreatedDate = Value
            End Set
        End Property

        'ItemID property
        Public Property ItemID() As Integer
            Get
                Return (intItemID)
            End Get
            Set(ByVal Value As Integer)
                intItemID = Value
            End Set
        End Property

        ' GenClaimTemplate method
        ' Purpose: gen claim letter with template
        ' Input: ID of claim template
        ' Output: datatable result
        Public Function GenClaimTemplate() As DataTable
            Try

            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        '---------------------------------------------------------------------------------------------------
        'purpose: insert new record into table SYS_DOWNLOAD_FILE
        'in: strFileName, dtCreateDate
        'out: boolean
        '---------------------------------------------------------------------------------------------------
        Public Function InsertSysDownloadFile() As Boolean
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.Sys_spDownloadFile_Ins"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("strFileName", OracleType.VarChar, 200)).Value = strFileName
                        .Parameters.Add(New OracleParameter("dtCreatedDate", OracleType.DateTime)).Value = dtCreatedDate
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
                        .Parameters.Add(New SqlParameter("@dtCreatedDate", SqlDbType.DateTime)).Value = dtCreatedDate
                        Try
                            .ExecuteNonQuery()
                            InsertSysDownloadFile = True
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
        End Function

        ' Dispose method
        ' Purpose: Release all resource
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