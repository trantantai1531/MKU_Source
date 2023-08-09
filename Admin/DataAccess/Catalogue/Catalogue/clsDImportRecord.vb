' clsDExportRecord class
' Creator: Tuanhv
' Purpose: used for exportdata
' CreatedDate: 02/08/2004
' Modified history:

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Catalogue
    Public Class clsDImportRecord
        Inherits clsDBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private strItemCode As String
        Private strItemLeader As String
        Private strDisplayEntry As String
        Private strAccessEntry As String
        Private strCaption As String
        Private strType As String
        Private strVersion As String
        Private strDescription As String

        ' *************************************************************************************************
        ' Declare public properties
        ' *************************************************************************************************

        ' Property ItemCode
        Public Property ItemCode() As String
            Get
                ItemCode = strItemCode
            End Get
            Set(ByVal Value As String)
                strItemCode = Value
            End Set
        End Property

        ' Property ItemLeader
        Public Property ItemLeader() As String
            Get
                ItemLeader = strItemLeader
            End Get
            Set(ByVal Value As String)
                strItemLeader = Value
            End Set
        End Property

        ' Property DisplayEntry
        Public Property DisplayEntry() As String
            Get
                DisplayEntry = strDisplayEntry
            End Get
            Set(ByVal Value As String)
                strDisplayEntry = Value
            End Set
        End Property

        ' Property AccessEntry
        Public Property AccessEntry() As String
            Get
                Return strAccessEntry
            End Get
            Set(ByVal Value As String)
                strAccessEntry = Value
            End Set
        End Property

        ' Property Caption
        Public Property Caption() As String
            Get
                Caption = strCaption
            End Get
            Set(ByVal Value As String)
                strCaption = Value
            End Set
        End Property

        ' Property Type
        Public Property Type() As String
            Get
                Type = strType
            End Get
            Set(ByVal Value As String)
                strType = Value
            End Set
        End Property

        ' Property Version
        Public Property Version() As String
            Get
                Version = strVersion
            End Get
            Set(ByVal Value As String)
                strVersion = Value
            End Set
        End Property

        ' Property Description
        Public Property Description() As String
            Get
                Description = strDescription
            End Get
            Set(ByVal Value As String)
                strDescription = Value
            End Set
        End Property

        ' ImportClassfication method
        ' Purpose: import data
        ' Input: record informations
        ' Ouput: intID
        Public Function ImportClassfication() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_INS_CLASSIFICATION"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strItemCode", OracleType.VarChar, 100)).Value = strItemCode
                            .Parameters.Add(New OracleParameter("strItemLeader", OracleType.VarChar, 100)).Value = strItemLeader
                            .Parameters.Add(New OracleParameter("strDisplayEntry", OracleType.VarChar, 100)).Value = strDisplayEntry
                            .Parameters.Add(New OracleParameter("strAccessEntry", OracleType.VarChar, 100)).Value = strAccessEntry
                            .Parameters.Add(New OracleParameter("strType", OracleType.VarChar, 100)).Value = strType
                            .Parameters.Add(New OracleParameter("strCaption", OracleType.VarChar, 256)).Value = strCaption
                            .Parameters.Add(New OracleParameter("strVietCaption", OracleType.VarChar, 256)).Value = strCaption
                            .Parameters.Add(New OracleParameter("strDescription", OracleType.VarChar, 512)).Value = strDescription
                            .Parameters.Add(New OracleParameter("strVersion", OracleType.VarChar, 100)).Value = strVersion
                            .Parameters.Add(New OracleParameter("intRetval", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            ImportClassfication = .Parameters("intRetval").Value
                            .Parameters.Clear()
                        End Try
                    End With

                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "SP_CATA_INS_CLASSIFICATION"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strItemLeader", SqlDbType.VarChar)).Value = strItemLeader
                            .Parameters.Add(New SqlParameter("@strItemCode", SqlDbType.VarChar)).Value = strItemCode
                            .Parameters.Add(New SqlParameter("@strDisplayEntry", SqlDbType.NVarChar)).Value = strDisplayEntry
                            .Parameters.Add(New SqlParameter("@strAccessEntry", SqlDbType.NVarChar)).Value = strAccessEntry
                            .Parameters.Add(New SqlParameter("@strType", SqlDbType.VarChar)).Value = strType
                            .Parameters.Add(New SqlParameter("@strVietCaption", SqlDbType.NVarChar)).Value = strCaption
                            .Parameters.Add(New SqlParameter("@strCaption", SqlDbType.NVarChar)).Value = strCaption
                            .Parameters.Add(New SqlParameter("@strDescription", SqlDbType.NVarChar)).Value = strDescription
                            .Parameters.Add(New SqlParameter("@strVersion", SqlDbType.VarChar)).Value = strVersion
                            .Parameters.Add(New SqlParameter("@intRetval", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            ImportClassfication = .Parameters("@intRetval").Value
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Retrieve data
        ' Input: string of select statement
        ' Output: DataTable
        Public Function GetData() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = strSQLStatement '"ACQUISITION.SP_ITEM_SEL"
                        .CommandType = CommandType.Text '.StoredProcedure
                        Try
                            'With .Parameters
                            '    .Add(New OracleParameter("strSQLStatement", OracleType.NVarChar, 1000)).Value = strSQLStatement
                            '    .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            'End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetData = dsData.Tables("tblResult")
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
                        .CommandText = "SP_ITEM_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strSQLStatement", SqlDbType.NVarChar)).Value = strSQLStatement
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetData = dsData.Tables("tblResult")
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

        ' Insert (Update)
        ' Input: string of SQL statement
        ' STOREPROCEDURE
        Public Sub ExecuteQuery()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = strSQLStatement '"SP_ITEM_PROCESS"
                        .CommandType = CommandType.Text '.StoredProcedure
                        Try
                            '.Parameters.Add(New OracleParameter("strSQLStatement", OracleType.VarChar, 4000)).Value = strSQLStatement
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
                        .CommandText = "Lib_spExecQueryString"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strSQLStatement", SqlDbType.NVarChar, 4000)).Value = strSQLStatement
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

        ' CreateID Function
        Public Function CreateID(ByVal strTableName As String, ByVal strFieldName As String) As DataTable
            Dim lngRet As Long

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    Try
                        oraCommand.CommandText = "SELECT NVL(Max(" & strFieldName & "), 0) + 1 as ID FROM " & strTableName
                        oraCommand.CommandType = CommandType.Text
                        oraDataAdapter.SelectCommand = oraCommand
                        oraDataAdapter.Fill(dsData, "tblResult")
                        CreateID = dsData.Tables("tblResult")
                        dsData.Tables.Remove("tblResult")
                    Catch ex As OracleException
                        intErrorCode = ex.Code
                        strErrorMsg = ex.Message.ToString
                    End Try
                Case "SQLSERVER"
                    Try
                        SqlCommand.CommandText = "SELECT ISNULL(Max(" & strFieldName & "), 0) + 1 as ID FROM " & strTableName
                        SqlCommand.CommandType = CommandType.Text
                        SqlDataAdapter.SelectCommand = SqlCommand
                        SqlDataAdapter.Fill(dsData, "tblResult")
                        CreateID = dsData.Tables("tblResult")
                        dsData.Tables.Remove("tblResult")
                    Catch ex As SqlException
                        intErrorCode = ex.Number
                        strErrorMsg = ex.Message.ToString
                    End Try
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