Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType
Imports eMicLibAdmin.DataAccess.Common

Public Class clsDCheckExistItem
    Inherits clsDBase
    ' *****************************************************************************************************
    ' Declare Private variables
    ' *****************************************************************************************************
    Private strTitle As String
    Private intID As Integer
    Private strIDs As String
    Private strSql As String

    ' *****************************************************************************************************
    ' Public Properties
    ' *****************************************************************************************************
    ' ---- VendorID Property
    Public Property Title()
        Get
            Return strTitle
        End Get
        Set(ByVal Value)
            strTitle = Value
        End Set
    End Property

    ' ---- ID Property
    Public Property ID()
        Get
            Return intID
        End Get
        Set(ByVal Value)
            intID = Value
        End Set
    End Property

    ' ---- IDs Property
    Public Property IDs()
        Get
            Return strIDs
        End Get
        Set(ByVal Value)
            strIDs = Value
        End Set
    End Property

    ' ---- SQL Property
    Public Property SQL() As String
        Get
            Return (strSql)
        End Get
        Set(ByVal Value As String)
            strSql = Value
        End Set
    End Property
    ' ---- End Property
    ' *****************************************************************************************************
    ' Methods here
    ' *****************************************************************************************************

    ' Retrieve 
    ' IN: strIDs
    ' Output: DataSet
    Public Function RetrieveItemOrdered() As DataTable
        Call OpenConnection()
        Dim dsItemOrdered As New DataSet
        Select Case UCase(strDBServer)
            Case "ORACLE"
                Dim oraDataAdapter As OracleDataAdapter
                With oraCommand
                    .CommandText = "ACQUISITION.SP_ITEM_ODERED_SEL"
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Add(New OracleParameter("strTitle", OracleType.NVarChar, 1000)).Value = strTitle
                    .Parameters.Add(New OracleParameter("strSql", OracleType.NVarChar, 2000)).Direction = ParameterDirection.Output
                    .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                    Try
                        .ExecuteNonQuery()
                        strSql = .Parameters("strSQL").Value
                        oraDataAdapter = New OracleDataAdapter(oraCommand)
                        oraDataAdapter.Fill(dsItemOrdered, "ITEM_ODERED")
                        'Catch OraEx As OracleException
                        '    strErrorMsg = OraEx.Message.ToString
                        '    intErrorCode = OraEx.Code
                    Finally
                        .Parameters.Clear()
                    End Try
                End With
            Case "SQLSERVER"
                Dim sqlClientDataAdapter As SqlDataAdapter
                With SqlCommand
                    .CommandText = "Acq_spPO_SelItem"
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Add(New SqlParameter("@strTitle", SqlDbType.NVarChar, 100)).Value = strTitle
                    .Parameters.Add(New SqlParameter("@strSql", SqlDbType.NVarChar, 2000)).Direction = ParameterDirection.Output
                    Try
                        .ExecuteNonQuery()
                        strSql = .Parameters("@strSQL").Value
                        sqlClientDataAdapter = New SqlDataAdapter(SqlCommand)
                        sqlClientDataAdapter.Fill(dsItemOrdered, "ITEM_ODERED")
                        'Catch sqlClientEx As SqlException
                        '    strErrorMsg = sqlClientEx.Message.ToString
                        '    intErrorCode = sqlClientEx.Number
                    Finally
                        .Parameters.Clear()
                    End Try
                End With
        End Select
        RetrieveItemOrdered = dsItemOrdered.Tables(0)
        dsItemOrdered.Dispose()
        dsItemOrdered = Nothing
        Call CloseConnection()
    End Function

    ' Retrieve 
    ' IN: strIDs
    ' Output: DataSet
    Public Function RetrieveItemRequest() As DataTable
        Call OpenConnection()
        Dim dsItemRequest As New DataSet
        Select Case UCase(strDBServer)
            Case "ORACLE"
                Dim oraDataAdapter As OracleDataAdapter
                With oraCommand
                    .CommandText = "ACQUISITION.SP_ITEM_REQUEST_SEL"
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Add(New OracleParameter("intID", OracleType.Number)).Value = intID
                    .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                    Try
                        .ExecuteNonQuery()
                        oraDataAdapter = New OracleDataAdapter(oraCommand)
                        oraDataAdapter.Fill(dsItemRequest, "ITEM_REQUEST")
                        'Catch OraEx As OracleException
                        '    strErrorMsg = OraEx.Message.ToString
                        '    intErrorCode = OraEx.Code
                    Finally
                        .Parameters.Clear()
                    End Try
                End With
            Case "SQLSERVER"
                Dim sqlClientDataAdapter As SqlDataAdapter
                With SqlCommand
                    .CommandText = "SP_ITEM_REQUEST_SEL"
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intID
                    Try
                        .ExecuteNonQuery()
                        sqlClientDataAdapter = New SqlDataAdapter(SqlCommand)
                        sqlClientDataAdapter.Fill(dsItemRequest, "ITEM_REQUEST")
                        'Catch sqlClientEx As SqlException
                        '    strErrorMsg = sqlClientEx.Message.ToString
                        '    intErrorCode = sqlClientEx.Number
                    Finally
                        .Parameters.Clear()
                    End Try
                End With
        End Select
        RetrieveItemRequest = dsItemRequest.Tables(0)
        dsItemRequest.Dispose()
        dsItemRequest = Nothing
        Call CloseConnection()
    End Function

    ' Retrieve 
    ' IN: strIDs
    ' Output: DataSet
    Public Function RetrieveItemAvailable() As DataTable
        Call OpenConnection()
        Dim dsItemAvailable As New DataSet
        Select Case UCase(strDBServer)
            Case "ORACLE"
                Dim oraDataAdapter As OracleDataAdapter
                With oraCommand
                    .CommandText = "ACQUISITION.SP_ITEM_AVAILABLE_SEL"
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Add(New OracleParameter("strIDs", OracleType.VarChar, 2000)).Value = strIDs
                    .Parameters.Add(New OracleParameter("strSql", OracleType.VarChar, 3000)).Direction = ParameterDirection.Output
                    .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                    Try
                        .ExecuteNonQuery()
                        strSql = .Parameters("strSQL").Value
                        oraDataAdapter = New OracleDataAdapter(oraCommand)
                        oraDataAdapter.Fill(dsItemAvailable, "ITEM_AVAILABLE")
                        'Catch OraEx As OracleException
                        '    strErrorMsg = OraEx.Message.ToString
                        '    intErrorCode = OraEx.Code
                    Finally
                        .Parameters.Clear()
                    End Try
                End With
            Case "SQLSERVER"
                Dim sqlClientDataAdapter As SqlDataAdapter
                With SqlCommand
                    .CommandText = "Lib_spItem_SelItemAvailable"
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Add(New SqlParameter("@strIDs", SqlDbType.VarChar, 2000)).Value = strIDs
                    .Parameters.Add(New SqlParameter("@strSql", SqlDbType.VarChar, 3000)).Direction = ParameterDirection.Output
                    Try
                        .ExecuteNonQuery()
                        strSql = .Parameters("@strSQL").Value
                        sqlClientDataAdapter = New SqlDataAdapter(SqlCommand)
                        sqlClientDataAdapter.Fill(dsItemAvailable, "ITEM_AVAILABLE")
                        'Catch sqlClientEx As SqlException
                        '    strErrorMsg = sqlClientEx.Message.ToString
                        '    intErrorCode = sqlClientEx.Number
                    Finally
                        .Parameters.Clear()
                    End Try
                End With
        End Select
        RetrieveItemAvailable = dsItemAvailable.Tables(0)
        dsItemAvailable.Dispose()
        dsItemAvailable = Nothing
        Call CloseConnection()
    End Function

    ' Retrieve 
    ' IN: strIDs
    ' Output: DataSet
    Public Function RetrieveLoanHistory() As DataTable
        Call OpenConnection()
        Dim dsLoanHistory As New DataSet
        Select Case UCase(strDBServer)
            Case "SQLSERVER"
                Dim sqlClientDataAdapter As SqlDataAdapter
                With SqlCommand
                    .CommandText = "Cir_spLoanHistory_SelByItemIds"
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Add(New SqlParameter("@strIDs", SqlDbType.VarChar, 2000)).Value = strIDs
                    .Parameters.Add(New SqlParameter("@strSql", SqlDbType.VarChar, 3000)).Direction = ParameterDirection.Output
                    Try
                        .ExecuteNonQuery()
                        strSql = .Parameters("@strSQL").Value
                        sqlClientDataAdapter = New SqlDataAdapter(SqlCommand)
                        sqlClientDataAdapter.Fill(dsLoanHistory, "LOAN_HISTORY")
                        'Catch sqlClientEx As SqlException
                        '    strErrorMsg = sqlClientEx.Message.ToString
                        '    intErrorCode = sqlClientEx.Number
                    Finally
                        .Parameters.Clear()
                    End Try
                End With
            Case "ORACLE"
                Dim oraDataAdapter As OracleDataAdapter
                With oraCommand
                    .CommandText = "ACQUISITION.SP_CIR_LOAN_HISTORY_SEL"
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Add(New OracleParameter("strIDs", OracleType.VarChar, 2000)).Value = strIDs
                    .Parameters.Add(New OracleParameter("strSql", OracleType.VarChar, 3000)).Direction = ParameterDirection.Output
                    .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                    Try
                        .ExecuteNonQuery()
                        strSql = .Parameters("strSQL").Value
                        oraDataAdapter = New OracleDataAdapter(oraCommand)
                        oraDataAdapter.Fill(dsLoanHistory, "LOAN_HISTORY")
                        'Catch OraEx As OracleException
                        '    strErrorMsg = OraEx.Message.ToString
                        '    intErrorCode = OraEx.Code
                    Finally
                        .Parameters.Clear()
                    End Try
                End With
        End Select
        RetrieveLoanHistory = dsLoanHistory.Tables(0)
        dsLoanHistory.Dispose()
        dsLoanHistory = Nothing
        Call CloseConnection()
    End Function

    ' Retrieve 
    ' IN: strIDs
    ' Output: DataSet
    Public Function RetrieveItemCount() As DataTable
        Call OpenConnection()
        Dim dsItemByTitle As New DataSet
        Select Case UCase(strDBServer)
            Case "SQLSERVER"
                Dim sqlClientDataAdapter As SqlDataAdapter
                With SqlCommand
                    .CommandText = "Lib_spItem_SelCount"
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Add(New SqlParameter("@strIDs", SqlDbType.VarChar, 1000)).Value = strIDs
                    .Parameters.Add(New SqlParameter("@strSql", SqlDbType.VarChar, 1000)).Direction = ParameterDirection.Output
                    Try
                        .ExecuteNonQuery()
                        strSql = .Parameters("@strSQL").Value
                        sqlClientDataAdapter = New SqlDataAdapter(SqlCommand)
                        sqlClientDataAdapter.Fill(dsItemByTitle, "ITEM_COUNT")
                        'Catch sqlClientEx As SqlException
                        '    strErrorMsg = sqlClientEx.Message.ToString
                        '    intErrorCode = sqlClientEx.Number
                    Finally
                        .Parameters.Clear()
                    End Try
                End With
            Case "ORACLE"
                Dim oraDataAdapter As OracleDataAdapter
                With oraCommand
                    .CommandText = "ACQUISITION.SP_ITEM_COUNT_SEL"
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Add(New OracleParameter("strIDs", OracleType.VarChar, 1000)).Value = strIDs
                    .Parameters.Add(New OracleParameter("strSql", OracleType.VarChar, 1000)).Direction = ParameterDirection.Output
                    .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                    Try
                        .ExecuteNonQuery()
                        strSql = .Parameters("strSQL").Value
                        oraDataAdapter = New OracleDataAdapter(oraCommand)
                        oraDataAdapter.Fill(dsItemByTitle, "ITEM_COUNT")
                        'Catch OraEx As OracleException
                        '    strErrorMsg = OraEx.Message.ToString
                        '    intErrorCode = OraEx.Code
                    Finally
                        .Parameters.Clear()
                    End Try
                End With
        End Select
        RetrieveItemCount = dsItemByTitle.Tables(0)
        dsItemByTitle.Dispose()
        dsItemByTitle = Nothing
        Call CloseConnection()
    End Function
    Public Function CheckExitItem(ByVal strTitle As String, ByVal strAuthor As String, ByVal intPublishYear As Integer) As Integer
        Call OpenConnection()
        Dim intRetval As Integer = 0 ' Integer Return value 
        With sqlCommand
            ' this store is not exist
            .CommandText = "Lib_spFindItem"
            .CommandType = CommandType.StoredProcedure
            With .Parameters
                .Add(New SqlParameter("@title", SqlDbType.NVarChar, 2000)).Value = strTitle
                .Add(New SqlParameter("@author", SqlDbType.NVarChar, 2000)).Value = strAuthor
                .Add(New SqlParameter("@publishyear", SqlDbType.Int)).Value = intPublishYear
                .Add(New SqlParameter("@id", SqlDbType.Int)).Direction = ParameterDirection.Output
            End With
            Try
                .ExecuteNonQuery()
                intRetval = .Parameters("@id").Value
            Catch sqlClientEx As SqlException
                strErrorMsg = sqlClientEx.Message.ToString
                intErrorCode = sqlClientEx.Number
            Finally
                .Parameters.Clear()
            End Try
        End With
        Call CloseConnection()
        CheckExitItem = intRetval
    End Function


    ' ****************************** Release resource method
    Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
        Try
            If isDisposing Then
                ' Dispose manage resource
            End If
            If Not oraCommand Is Nothing Then
                oraCommand.Dispose()
                oraCommand = Nothing
            End If
            If Not oraConnection Is Nothing Then
                oraConnection.Close()
                oraConnection.Dispose()
                oraConnection = Nothing
            End If
            If Not SqlCommand Is Nothing Then
                SqlCommand.Dispose()
                SqlCommand = Nothing
            End If
            If Not SqlConnection Is Nothing Then
                SqlConnection.Close()
                SqlConnection.Dispose()
                SqlConnection = Nothing
            End If
        Finally
            MyBase.Dispose()
            Me.Dispose()
        End Try
    End Sub
    ' ********************* Only when Dispose fail
    Protected Overrides Sub Finalize()
        Dispose(False)
    End Sub
End Class
