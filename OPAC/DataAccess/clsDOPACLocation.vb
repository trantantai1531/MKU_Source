Imports System
Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibOPAC.DataAccess.OPAC
    Public Class clsDOPACLocation
        Inherits clsDBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private intLocationID As Integer
        Private intItemID As Integer
        Private intLocID As Integer
        Private strLanguage As String
        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
        ' LocID property
        Public Property LocID() As Integer
            Get
                Return intLocID
            End Get
            Set(ByVal Value As Integer)
                intLocID = Value
            End Set
        End Property

        ' ItemID property
        Public Property ItemID() As Integer
            Get
                Return intItemID
            End Get
            Set(ByVal Value As Integer)
                intItemID = Value
            End Set
        End Property

        ' LocationID property
        Public Property LocationID() As Integer
            Get
                Return intLocationID
            End Get
            Set(ByVal Value As Integer)
                intLocationID = Value
            End Set
        End Property

        Public Property Language() As String
            Get
                Return strLanguage
            End Get
            Set(ByVal Value As String)
                strLanguage = Value
            End Set
        End Property

        Public Function GetInfoShelfLocation() As DataTable
            Try
                Me.OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With SqlCommand
                            .CommandText = "Lib_spHoldingLocation_SelCodeAndSymbolByLocId"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                .Parameters.Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocID
                                SqlDataAdapter.SelectCommand = SqlCommand
                                SqlDataAdapter.Fill(dsData, "tblResult")
                                GetInfoShelfLocation = dsData.Tables("tblResult")
                            Catch sqlClientEx As SqlException
                                strErrorMsg = sqlClientEx.Message.ToString
                                intErrorCode = sqlClientEx.Number
                            Finally
                                dsData.Tables.Remove("tblResult")
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "ORACLE"
                        With oracommand
                            .CommandText = "OPAC.Lib_spHoldingLocation_SelCodeAndSymbolByLocId"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocID
                                    .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                End With
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsdata, "tblResult")
                                GetInfoShelfLocation = dsdata.Tables("tblResult")
                            Catch OraEx As OracleException
                                strErrorMsg = OraEx.Message.ToString
                                intErrorCode = OraEx.Code
                            Finally
                                dsdata.Tables.Remove("tblResult")
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
                Me.CloseConnection()
            Catch ex As Exception
                strerrormsg = ex.Message
            End Try
        End Function

        Public Function GetHoldingShelfSchema() As DataTable
            Try
                Me.OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With SqlCommand
                            .CommandText = "Lib_spHoldingShelfSchema_SelByLocId"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                .Parameters.Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocID
                                SqlDataAdapter.SelectCommand = SqlCommand
                                SqlDataAdapter.Fill(dsdata, "tblResult")
                                GetHoldingShelfSchema = dsdata.Tables("tblResult")
                            Catch sqlClientEx As SqlException
                                strErrorMsg = sqlClientEx.Message.ToString
                                intErrorCode = sqlClientEx.Number
                            Finally
                                dsdata.Tables.Remove("tblResult")
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "ORACLE"
                        With oracommand
                            .CommandText = "OPAC.Lib_spHoldingShelfSchema_SelByLocId"
                            .CommandType = CommandType.StoredProcedure
                            With .Parameters
                                .Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            Try
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsdata, "tblResult")
                                GetHoldingShelfSchema = dsdata.Tables("tblResult")
                            Catch OraEx As OracleException
                                strErrorMsg = OraEx.Message.ToString
                                intErrorCode = OraEx.Code
                            Finally
                                dsdata.Tables.Remove("tblResult")
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
                Me.CloseConnection()
            Catch ex As Exception
                strerrormsg = ex.Message
            End Try
        End Function

        Public Function GetHoldingLocSchema() As DataTable
            Try
                Me.OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With SqlCommand
                            .CommandText = "Lib_spHoldingLocationSchema_SelByLocId"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                .Parameters.Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocID
                                SqlDataAdapter.SelectCommand = SqlCommand
                                SqlDataAdapter.Fill(dsdata, "tblResult")
                                GetHoldingLocSchema = dsdata.Tables("tblResult")
                            Catch sqlClientEx As SqlException
                                strErrorMsg = sqlClientEx.Message.ToString
                                intErrorCode = sqlClientEx.Number
                            Finally
                                dsdata.Tables.Remove("tblResult")
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "ORACLE"
                        With oracommand
                            .CommandText = "OPAC.Lib_spHoldingLocationSchema_SelByLocId"
                            .CommandType = CommandType.StoredProcedure
                            With .Parameters
                                .Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            Try
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsdata, "tblResult")
                                GetHoldingLocSchema = dsdata.Tables("tblResult")
                            Catch OraEx As OracleException
                                strErrorMsg = OraEx.Message.ToString
                                intErrorCode = OraEx.Code
                            Finally
                                dsdata.Tables.Remove("tblResult")
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
                Me.CloseConnection()
            Catch ex As Exception
                strerrormsg = ex.Message
            End Try
        End Function

        Public Function GetContentField200s() As DataTable
            Try
                Me.OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With SqlCommand
                            .CommandText = "Lib_spField200S_SelContent"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                                SqlDataAdapter.SelectCommand = SqlCommand
                                SqlDataAdapter.Fill(dsdata, "tblResult")
                                GetContentField200s = dsdata.Tables("tblResult")
                            Catch sqlClientEx As SqlException
                                strErrorMsg = sqlClientEx.Message.ToString
                                intErrorCode = sqlClientEx.Number
                            Finally
                                dsdata.Tables.Remove("tblResult")
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "ORACLE"
                        With oracommand
                            .CommandText = "OPAC.Lib_spField200S_SelContent"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New OracleParameter("intItemID", OracleType.Number)).Value = intItemID
                                    .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                End With
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsdata, "tblResult")
                                GetContentField200s = dsdata.Tables("tblResult")
                            Catch OraEx As OracleException
                                strErrorMsg = OraEx.Message.ToString
                                intErrorCode = OraEx.Code
                            Finally
                                dsdata.Tables.Remove("tblResult")
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
                Me.CloseConnection()
            Catch ex As Exception
                strerrormsg = ex.Message
            End Try
        End Function

        Public Function GetCalendar(ByVal intMonth As Integer, ByVal intYear As String, ByVal intLocationID As Integer, ByVal chrSelectMode As Char) As DataTable
            Try
                Me.OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With SqlCommand
                            Try
                                Select Case chrSelectMode
                                    Case "1" ' select for display Calendar View List
                                        .CommandText = "Opac_spSchedule_Get"
                                        .CommandType = CommandType.StoredProcedure
                                        With .Parameters
                                            .Add(New SqlParameter("@intLocationID", SqlDbType.Int, 4)).Value = intLocationID
                                        End With
                                    Case Else 'select OffDay in Library
                                        .CommandText = "Opac_spGetOffDay"
                                        .CommandType = CommandType.StoredProcedure
                                        With .Parameters
                                            .Add(New SqlParameter("@intMonth", SqlDbType.VarChar, 11)).Value = intMonth
                                            .Add(New SqlParameter("@intYear", SqlDbType.VarChar, 11)).Value = intYear
                                            .Add(New SqlParameter("@intLocationID", SqlDbType.Int, 4)).Value = intLocationID
                                        End With
                                End Select
                                SqlDataAdapter.SelectCommand = SqlCommand
                                SqlDataAdapter.Fill(dsdata, "tblResult")
                                GetCalendar = dsdata.Tables("tblResult")
                            Catch sqlClientEx As SqlException
                                strerrormsg = sqlClientEx.Message
                                interrorcode = sqlClientEx.Number
                            Finally
                                .Parameters.Clear()
                                dsdata.Tables.Remove("tblResult")
                            End Try
                        End With
                    Case "ORACLE"
                        With oracommand
                            Try
                                Select Case chrSelectMode
                                    Case "1" ' select for display Calendar View List
                                        .CommandType = CommandType.StoredProcedure
                                        .CommandText = "OPAC.Opac_spSchedule_Get"
                                        With .Parameters
                                            .Add(New OracleParameter("intLocationID", OracleType.Number, 4)).Value = intLocationID
                                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                        End With
                                    Case Else 'select OffDay in Library
                                        .CommandType = CommandType.StoredProcedure
                                        .CommandText = "OPAC.Opac_spGetOffDay"
                                        With .Parameters
                                            .Add(New OracleParameter("intMonth", OracleType.VarChar, 11)).Value = intMonth
                                            .Add(New OracleParameter("intYear", OracleType.VarChar, 11)).Value = intYear
                                            .Add(New OracleParameter("intLocationID", OracleType.Number, 4)).Value = intLocationID
                                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                        End With
                                End Select
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsdata, "tblResult")
                                GetCalendar = dsdata.Tables("tblResult")
                            Catch OraEx As OracleException
                                strErrorMsg = OraEx.Message.ToString
                                intErrorCode = OraEx.Code
                            Finally
                                .Parameters.Clear()
                                dsdata.Tables.Remove("tblResult")
                            End Try
                        End With
                End Select
                Me.CloseConnection()
            Catch ex As Exception
                strerrormsg = ex.Message
            End Try
        End Function

        Public Function GetAllLocations() As DataTable
            Try
                Me.OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With SqlCommand
                            .CommandText = "Opac_spLocation_GetAll"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                SqlDataAdapter.SelectCommand = SqlCommand
                                SqlDataAdapter.Fill(dsdata, "tblResult")
                                GetAllLocations = dsdata.Tables("tblResult")
                            Catch sqlClientEx As SqlException
                                strErrorMsg = sqlClientEx.Message.ToString
                                intErrorCode = sqlClientEx.Number
                            Finally
                                dsdata.Tables.Remove("tblResult")
                            End Try
                        End With
                    Case "ORACLE"
                        With oracommand
                            .CommandText = "OPAC.Opac_spLocation_GetAll"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                End With
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsdata, "tblResult")
                                GetAllLocations = dsdata.Tables("tblResult")
                            Catch OraEx As OracleException
                                strErrorMsg = OraEx.Message.ToString
                                intErrorCode = OraEx.Code
                            Finally
                                dsdata.Tables.Remove("tblResult")
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
                Me.CloseConnection()
            Catch ex As Exception
                strerrormsg = ex.Message
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

        Public Function GetAllLibrary() As DataTable
            Dim dtResult As DataTable = Nothing
            Try
                Me.OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With sqlCommand
                            .CommandText = "Opac_spLibrary_GetAll"
                            .Parameters.Add(New SqlParameter("@strLang", SqlDbType.NVarChar)).Value = strLanguage
                            .CommandType = CommandType.StoredProcedure
                            Try
                                sqlDataAdapter.SelectCommand = sqlCommand
                                sqlDataAdapter.Fill(dsData, "tblResult")
                                dtResult = dsData.Tables("tblResult")
                            Catch sqlClientEx As SqlException
                                strErrorMsg = sqlClientEx.Message.ToString
                                intErrorCode = sqlClientEx.Number
                            Finally
                                dsData.Tables.Remove("tblResult")
                            End Try
                        End With
                    Case "ORACLE"
                        With oraCommand
                            .CommandText = "OPAC.Opac_spLibrary_GetAll"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New OracleParameter("@strLang", OracleType.NVarChar)).Value = strLanguage
                                    .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                End With
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsData, "tblResult")
                                dtResult = dsData.Tables("tblResult")
                            Catch OraEx As OracleException
                                strErrorMsg = OraEx.Message.ToString
                                intErrorCode = OraEx.Code
                            Finally
                                dsData.Tables.Remove("tblResult")
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
                Me.CloseConnection()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return dtResult
        End Function
    End Class
End Namespace