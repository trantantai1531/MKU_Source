' Name: clsDUserLocation
' Purpose: working with userlocations
' Creator: Oanhtn
' CreatedDate: 17/08/2004
' Modification History:

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Common
    Public Class clsDUserLocation
        Inherits clsDBase

        ' *****************************************************************************************************
        ' Declare member variables
        ' *****************************************************************************************************

        Private strLocationIDs As String

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' LocationIDs property
        Public Property LocationIDs() As String
            Get
                Return strLocationIDs
            End Get
            Set(ByVal Value As String)
                strLocationIDs = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' GetUserLocations method
        ' Purpose: Get valid locations of the SelectedUser
        ' Input: intUserID
        ' Output: datatable result
        Public Function GetUserLocations(Optional ByVal intSubsystemID As Integer = 1) As DataTable
            Try
                Call OpenConnection()
                Select Case UCase(strDBServer)
                    Case "ORACLE"
                        With oraCommand
                            .CommandText = "COMMON.SP_GETUSERLOCATIONS"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                .Parameters.Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                                .Parameters.Add(New OracleParameter("intSubsystemID", OracleType.Number)).Value = intSubsystemID
                                .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsData, "tblResult")
                                GetUserLocations = dsData.Tables("tblResult")
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
                            .CommandText = "Sys_spUser_Location_Sel"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                                .Parameters.Add(New SqlParameter("@intSubsystemID", SqlDbType.Int)).Value = intSubsystemID
                                SqlDataAdapter.SelectCommand = SqlCommand
                                SqlDataAdapter.Fill(dsData, "tblResult")
                                GetUserLocations = dsData.Tables("tblResult")
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
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ''' <summary>
        ''' Get HoldingLocation
        ''' </summary>
        ''' <param name="intHoldingLibrary"></param>
        ''' <param name="intUserID">0 if get all location, or get only location belong to user</param>
        ''' <param name="intTopText">0 if not generating top text (--chọn tất cả--) 1 if so</param>
        ''' <returns></returns>
        Public Function GetHoldingLocationByUserID(ByVal intHoldingLibrary As Integer,
                                                   Optional intUserID As Integer = 0,
                                                   Optional intTopText As Integer = 1,
                                                   Optional strTopText As String = Nothing) As DataTable
            GetHoldingLocationByUserID = Nothing
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    Try
                        sqlCommand.CommandText = "Lib_spHoldingLocation_SelByUserId"
                        sqlCommand.CommandType = CommandType.StoredProcedure
                        sqlCommand.Parameters.Add(New SqlParameter("@intLidID", SqlDbType.Int)).Value = intHoldingLibrary
                        sqlCommand.Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                        sqlCommand.Parameters.Add(New SqlParameter("@intTopText", SqlDbType.Int)).Value = intTopText
                        sqlCommand.Parameters.Add(New SqlParameter("@strTopText", SqlDbType.NVarChar, 100)).Value = strTopText
                        sqlDataAdapter.SelectCommand = sqlCommand
                        sqlDataAdapter.Fill(dsData, "tblResult")
                        GetHoldingLocationByUserID = dsData.Tables("tblResult")
                        dsData.Tables.Remove("tblResult")
                    Catch ex As SqlException
                        intErrorCode = ex.Number
                        strErrorMsg = ex.Message.ToString
                    End Try
            End Select
        End Function

        Public Function GetHoldingCirLocationByUserID(ByVal intHoldingLibrary As Integer,
                                                   Optional intUserID As Integer = 0,
                                                   Optional intTopText As Integer = 1,
                                                   Optional strTopText As String = Nothing) As DataTable
            GetHoldingCirLocationByUserID = Nothing
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    Try
                        sqlCommand.CommandText = "Lib_spHoldingCirLocation_SelByUserId"
                        sqlCommand.CommandType = CommandType.StoredProcedure
                        sqlCommand.Parameters.Add(New SqlParameter("@intLidID", SqlDbType.Int)).Value = intHoldingLibrary
                        sqlCommand.Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                        sqlCommand.Parameters.Add(New SqlParameter("@intTopText", SqlDbType.Int)).Value = intTopText
                        sqlCommand.Parameters.Add(New SqlParameter("@strTopText", SqlDbType.NVarChar, 100)).Value = strTopText
                        sqlDataAdapter.SelectCommand = sqlCommand
                        sqlDataAdapter.Fill(dsData, "tblResult")
                        GetHoldingCirLocationByUserID = dsData.Tables("tblResult")
                        dsData.Tables.Remove("tblResult")
                    Catch ex As SqlException
                        intErrorCode = ex.Number
                        strErrorMsg = ex.Message.ToString
                    End Try
            End Select
        End Function

        ' GetLibraries method
        ' Purpose: Get all libraries
        ' Output: datatable result
        Public Function GetLibraries() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_GET_LIBRARY"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetLibraries = dsData.Tables("tblResult")
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
                        .CommandText = "Lib_spHoldingLibrary_SelAll"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetLibraries = dsData.Tables("tblResult")
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

        ' GetHoldingLibrary method
        ' Purpose: Get valid holding library of the Selected User
        ' Input: intUserID
        ' Output: datatable result
        Public Function GetHoldingLibrary() As DataTable
            Try
                Call OpenConnection()
                Select Case UCase(strDBServer)
                    Case "ORACLE"
                        With oraCommand
                            .CommandText = "CIRCULATION.SP_HOLDING_LIB_SEL"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                .Parameters.Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                                .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsData, "tblLibrary")
                                GetHoldingLibrary = dsData.Tables("tblLibrary")
                                dsData.Tables.Remove("tblLibrary")
                            Catch OraEx As OracleException
                                strErrorMsg = OraEx.Message.ToString
                                intErrorCode = OraEx.Code
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "SQLSERVER"
                        With SqlCommand
                            .CommandText = "Lib_spHoldingLibrary_SelByUserId"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                                SqlDataAdapter.SelectCommand = SqlCommand
                                SqlDataAdapter.Fill(dsData, "tblLibrary")
                                GetHoldingLibrary = dsData.Tables("tblLibrary")
                                dsData.Tables.Remove("tblLibrary")
                            Catch sqlClientEx As SqlException
                                strErrorMsg = sqlClientEx.Message.ToString
                                intErrorCode = sqlClientEx.Number
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
                Call CloseConnection()
            Catch ex As Exception
                strErrorMsg = ex.Message
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
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace