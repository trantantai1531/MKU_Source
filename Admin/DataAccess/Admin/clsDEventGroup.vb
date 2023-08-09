' Name: clsDEventGroup
' Purpose: Management event
' Creator: Oanhtn
' Created Date: 18/11/2004
' Modification History:

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Admin
    Public Class clsDEventGroup
        Inherits clsDBase

        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************

        Private intEventGroupID As Integer
        Private intParentID As Integer
        Private intLogMode As Integer
        Private strEventIDs As String

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' EventGroupID property
        Public Property EventGroupID() As Integer
            Get
                Return intEventGroupID
            End Get
            Set(ByVal Value As Integer)
                intEventGroupID = Value
            End Set
        End Property

        ' ParentID property
        Public Property ParentID() As Integer
            Get
                Return intParentID
            End Get
            Set(ByVal Value As Integer)
                intParentID = Value
            End Set
        End Property

        ' LogMode property
        Public Property LogMode() As Integer
            Get
                Return intLogMode
            End Get
            Set(ByVal Value As Integer)
                intLogMode = Value
            End Set
        End Property

        ' EventIDs property
        Public Property EventIDs() As String
            Get
                Return strEventIDs
            End Get
            Set(ByVal Value As String)
                strEventIDs = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' SetLogMode method
        ' Purpose: Set log mode
        ' Input: strEventIDs
        Public Sub SetLogMode()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ADMINISTRATOR.Admin_spLogMode_Up"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intParentID", OracleType.Number)).Value = intParentID
                            .Parameters.Add(New OracleParameter("strEventIDs", OracleType.VarChar, 1000)).Value = strEventIDs
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
                        .CommandText = "Admin_spLogMode_Up"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intParentID", SqlDbType.Int)).Value = intParentID
                            .Parameters.Add(New SqlParameter("@strEventIDs", SqlDbType.VarChar)).Value = strEventIDs
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' GetEventsOfGroup method
        ' Purpose: Get events to write log
        ' Input: EventGroupID
        ' Output: datatable result
        Public Function GetEventsOfGroup() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ADMINISTRATOR.Admin_spEvent_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intEventGroupID", OracleType.Number)).Value = intEventGroupID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetEventsOfGroup = dsData.Tables("tblResult")
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
                        .CommandText = "Admin_spEvent_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intEventGroupID", SqlDbType.Int)).Value = intEventGroupID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetEventsOfGroup = dsData.Tables("tblResult")
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

        ' GetEventGroups method
        ' Purpose: Get groups of events
        ' Output: datatable result
        Public Function GetEventGroups() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ADMINISTRATOR.Admin_spEventGroup_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetEventGroups = dsData.Tables("tblResult")
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
                        .CommandText = "Admin_spEventGroup_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetEventGroups = dsData.Tables("tblResult")
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