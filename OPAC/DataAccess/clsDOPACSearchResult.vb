Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibOPAC.DataAccess.OPAC
    Public Class clsDOPACSearchResult
        Inherits clsDBase
       
        Public Function GetFulltextResults(ByVal strURL As String) As DataTable
            Try
                Me.OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With SqlCommand
                            .CommandText = "Opac_spFulltext_Search"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New SqlParameter("@strURL", SqlDbType.NVarChar, 4000)).Value = strURL
                                End With
                                SqlDataAdapter.SelectCommand = SqlCommand
                                SqlDataAdapter.Fill(dsdata, "tblResult")
                                GetFulltextResults = dsdata.Tables("tblResult")
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
                            .CommandType = CommandType.StoredProcedure
                            .CommandText = "OPAC.Opac_spFulltext_Search"
                            Try
                                With .Parameters
                                    .Add(New OracleParameter("strURL", OracleType.NVarChar)).Value = strURL
                                    .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                End With
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsdata, "tblResult")
                                GetFulltextResults = dsdata.Tables("tblResult")
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

        Public Function GetItemResults(ByVal strTitle As String, ByVal strAuthor As String, ByVal strKeyWord As String, ByVal strBitmapType As String, ByVal strColorModel As String, ByVal strMinWidth As String, ByVal strMaxWidth As String, ByVal strMinHeight As String, ByVal strMaxHeight As String, ByVal strMinRes As String, ByVal strMaxRes As String, ByVal strMinSize As String, ByVal strMaxSize As String) As DataTable
            Dim strItemIDs As String = ""
            Dim intCount As Integer = 0
            Dim inti As Integer = 0
            Dim tblResult As New DataTable

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spEdata_GetImage"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strTitle", SqlDbType.NVarChar, 100)).Value = strTitle
                                .Add(New SqlParameter("@strAuthor", SqlDbType.NVarChar, 100)).Value = strAuthor
                                .Add(New SqlParameter("@strKeyWord", SqlDbType.NVarChar, 100)).Value = strKeyWord
                                .Add(New SqlParameter("@strBitmapType", SqlDbType.NVarChar, 5)).Value = strBitmapType
                                .Add(New SqlParameter("@strColorModel", SqlDbType.NVarChar, 5)).Value = strColorModel
                                .Add(New SqlParameter("@strMinWidth", SqlDbType.NVarChar, 5)).Value = strMinWidth
                                .Add(New SqlParameter("@strMaxWidth", SqlDbType.NVarChar, 5)).Value = strMaxWidth
                                .Add(New SqlParameter("@strMinHeight", SqlDbType.NVarChar, 5)).Value = strMinHeight
                                .Add(New SqlParameter("@strMaxHeight", SqlDbType.NVarChar, 5)).Value = strMaxHeight
                                .Add(New SqlParameter("@strMinRes", SqlDbType.NVarChar, 5)).Value = strMinRes
                                .Add(New SqlParameter("@strMaxRes", SqlDbType.NVarChar, 5)).Value = strMaxRes
                                .Add(New SqlParameter("@strMinSize", SqlDbType.NVarChar, 5)).Value = strMinSize
                                .Add(New SqlParameter("@strMaxSize", SqlDbType.NVarChar, 5)).Value = strMaxSize
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsdata, "tblResult")
                            tblResult = dsdata.Tables("tblResult")
                            GetItemResults = tblResult
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
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "OPAC.Opac_spEdata_GetImage"
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strTitle", OracleType.VarChar, 100)).Value = strTitle
                                .Add(New OracleParameter("strAuthor", OracleType.VarChar, 100)).Value = strAuthor
                                .Add(New OracleParameter("strKeyWord", OracleType.VarChar, 100)).Value = strKeyWord
                                .Add(New OracleParameter("strBitmapType", OracleType.VarChar, 100)).Value = strBitmapType
                                .Add(New OracleParameter("strColorModel", OracleType.VarChar, 10)).Value = strColorModel
                                .Add(New OracleParameter("strMinWidth", OracleType.VarChar, 5)).Value = strMinWidth
                                .Add(New OracleParameter("strMaxWidth", OracleType.VarChar, 5)).Value = strMaxWidth
                                .Add(New OracleParameter("strMinHeight", OracleType.VarChar, 5)).Value = strMinHeight
                                .Add(New OracleParameter("strMaxHeight", OracleType.VarChar, 5)).Value = strMaxHeight
                                .Add(New OracleParameter("strMinRes", OracleType.VarChar, 5)).Value = strMinRes
                                .Add(New OracleParameter("strMaxRes", OracleType.VarChar, 5)).Value = strMaxRes
                                .Add(New OracleParameter("strMinSize", OracleType.VarChar, 5)).Value = strMinSize
                                .Add(New OracleParameter("strMaxSize", OracleType.VarChar, 5)).Value = strMaxSize
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsdata, "tblResult")
                            tblResult = dsdata.Tables("tblResult")
                            GetItemResults = tblResult
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsdata.Tables.Remove("tblResult")
                        End Try
                    End With

                    Dim strGetItemResults
                    strGetItemResults = ""
                    If Not tblResult Is Nothing Then
                        If tblResult.Rows.Count > 0 Then
                            intCount = tblResult.Rows.Count - 1
                            For inti = 0 To intCount
                                strGetItemResults = strGetItemResults & CStr(tblResult.Rows(inti).Item("ID")) & ", "
                            Next
                            If Len(GetItemResults) > 1 Then
                                strGetItemResults = Left(strGetItemResults, Len(strGetItemResults) - 2)
                            End If
                        End If
                    End If
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

