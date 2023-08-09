Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Circulation
    Public Class clsDCirCommon
        Inherits clsDBase

        ' *****************************************************************************************************
        ' Declare member variables
        ' *****************************************************************************************************

        Private strCurrencyCode As String = ""
        Private strItemTypeID As String = ""
        Private strMediumID As String = ""

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' CurrencyCode property
        Public Property CurrencyCode() As String
            Get
                Return strCurrencyCode
            End Get
            Set(ByVal Value As String)
                strCurrencyCode = Value
            End Set
        End Property

        ' ItemTypeID property
        Public Property ItemType() As String
            Get
                Return strItemTypeID
            End Get
            Set(ByVal Value As String)
                strItemTypeID = Value
            End Set
        End Property

        ' MediumID property
        Public Property MediumID() As String
            Get
                Return strMediumID
            End Get
            Set(ByVal Value As String)
                strMediumID = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' GetCurrency method
        ' Purpose: Get currency exchange
        ' Input: strCurrencyCode
        ' Output: datatable result
        Public Function GetCurrency() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_CURRENCY_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strCurrencyCode", OracleType.VarChar, 10)).Value = strCurrencyCode
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblCurrency")
                            GetCurrency = dsData.Tables("tblCurrency")
                            dsData.Tables.Remove("tblCurrency")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spCurrency_SelByCurrencyCodeAllowNull"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strCurrencyCode", SqlDbType.VarChar, 10)).Value = strCurrencyCode
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblCurrency")
                            GetCurrency = dsData.Tables("tblCurrency")
                            dsData.Tables.Remove("tblCurrency")
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

        ' GetMediumInfor method
        ' Purpose: Retrieve medium from Cat_tblDicMedium
        ' Input: strCurrencyCode
        ' Output: DataTable
        Public Function GetMediumInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_CAT_DIC_MEDIUM_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strMediumID", OracleType.VarChar, 1000)).Value = strMediumID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "MEDIUM")
                            GetMediumInfor = dsData.Tables("MEDIUM")
                            dsData.Tables.Remove("MEDIUM")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spDicMedium_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strMediumID", SqlDbType.VarChar)).Value = strMediumID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "MEDIUM")
                            GetMediumInfor = dsData.Tables("MEDIUM")
                            dsData.Tables.Remove("MEDIUM")
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

        ' GetItemType method 
        ' purpose: Retrieve medium from Cat_tblDic_ItemType
        ' Input: strItemTypeID
        ' Output: DataTable
        Public Function GetItemType() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    Dim oraDataAdapter As OracleDataAdapter
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_CAT_DIC_ITEM_TYPE_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strTypeID", OracleType.VarChar, 1000)).Value = strItemTypeID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "ITEMTYPE")
                            GetItemType = dsData.Tables("ITEMTYPE")
                            dsData.Tables.Remove("ITEMTYPE")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    Dim sqlDataAdapter As sqlDataAdapter
                    With SqlCommand
                        .CommandText = "SP_CAT_DIC_ITEM_TYPE_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strTypeID", SqlDbType.VarChar)).Value = strItemTypeID
                            sqlDataAdapter.SelectCommand = SqlCommand
                            sqlDataAdapter.Fill(dsData, "ITEMTYPE")
                            GetItemType = dsData.Tables("ITEMTYPE")
                            dsData.Tables.Remove("ITEMTYPE")
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

        Public Function GetFormID(ByVal intBookType As Integer) As DataTable
            Dim strSQLStatement As String
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    strSQLStatement = "SELECT FormID FROM Lib_tblItem WHERE TypeID = " & intBookType & " AND FormID IS NOT NULL  AND ROWNUM <=1 GROUP BY FormID ORDER BY Count(ID) DESC"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_STATEMENT_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strSQLStatement", OracleType.NVarChar, 1000)).Value = strSQLStatement
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "ITEMFID")
                            GetFormID = dsData.Tables("ITEMFID")
                            dsData.Tables.Remove("ITEMFID")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    strSQLStatement = "SELECT TOP 1 FormID FROM Lib_tblItem WHERE TypeID =" & intBookType & " AND FormID IS NOT NULL GROUP BY FormID ORDER BY Count(ID) DESC"
                    Dim sqlDataAdapter As sqlDataAdapter
                    With SqlCommand
                        .CommandText = "Lib_spStatement_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strSQLStatement", SqlDbType.NVarChar)).Value = strSQLStatement
                            End With
                            sqlDataAdapter.SelectCommand = SqlCommand
                            sqlDataAdapter.Fill(dsData, "ITEMFID")
                            GetFormID = dsData.Tables("ITEMFID")
                            dsData.Tables.Remove("ITEMFID")
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

        Public Function Get_Marc_WS_MinID() As DataTable
            Dim strSQLStatement As String
            Call OpenConnection()
            strSQLStatement = "SELECT min(ID) AS ID FROM Lib_tblMARCWorksheet"
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    Dim oraDataAdapter As OracleDataAdapter
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_STATEMENT_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strSQLStatement", OracleType.NVarChar, 1000)).Value = strSQLStatement
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "ITEMFIDM")
                            Get_Marc_WS_MinID = dsData.Tables("ITEMFIDM")
                            dsData.Tables.Remove("ITEMFIDM")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spStatement_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strSQLStatement", SqlDbType.NVarChar)).Value = strSQLStatement
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "ITEMFIDM")
                            Get_Marc_WS_MinID = dsData.Tables("ITEMFIDM")
                            dsData.Tables.Remove("ITEMFIDM")
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
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace