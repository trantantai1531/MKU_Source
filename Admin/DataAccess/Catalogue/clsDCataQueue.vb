' Purpose: process form
' Creator: KhoaNA
' Created Date: 27/04/2004
' Modification history:
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Catalogue
    Public Class clsDCataQueue
        Inherits clsDBase

        ' *****************************************************************************************************
        ' Declare Private variables
        ' *****************************************************************************************************

        Private strInputDate As String
        Private strSQL As String
        Private intReviewed As Integer

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' Reviewed property
        Public Property Reviewed() As Integer
            Get
                Reviewed = intReviewed
            End Get
            Set(ByVal Value As Integer)
                intReviewed = Value
            End Set
        End Property

        ' InputDate property
        Public Property InputDate() As String
            Get
                InputDate = strInputDate
            End Get
            Set(ByVal Value As String)
                strInputDate = Value
            End Set
        End Property

        ' SQL property
        Public Property SQL() As String
            Get
                SQL = strSQL
            End Get
            Set(ByVal Value As String)
                strSQL = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Method: RetrieveInputTime 
        Public Function RetrieveInputTime(ByVal intReviewed As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_QUEUE_DURATION_SEL"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("intReviewed", OracleType.Number)).Value = intReviewed
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                    End With
                    Try
                        oraDataAdapter.SelectCommand = oraCommand
                        oraDataAdapter.Fill(dsData, "tblResult")
                        RetrieveInputTime = dsData.Tables("tblResult")
                        dsData.Tables.Remove("tblResult")
                    Catch OraEx As OracleException
                        strErrorMsg = OraEx.Message.ToString
                        intErrorCode = OraEx.Code
                    Finally
                        oraCommand.Parameters.Clear()
                    End Try
                Case "SQLSERVER"
                    With sqlCommand
                        .Parameters.Add(New SqlParameter("@intLibId", SqlDbType.Int)).Value = intLibID
                        .CommandText = "Cat_spQueue_SelDuration"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intReviewed", SqlDbType.Int)).Value = intReviewed
                    End With
                    Try
                        SqlDataAdapter.SelectCommand = SqlCommand
                        SqlDataAdapter.Fill(dsData, "tblResult")
                        RetrieveInputTime = dsData.Tables("tblResult")
                        dsData.Tables.Remove("tblResult")
                    Catch sqlClientEx As SqlException
                        strErrorMsg = sqlClientEx.Message.ToString
                        intErrorCode = sqlClientEx.Number
                    Finally
                        SqlCommand.Parameters.Clear()
                    End Try
            End Select
            Call CloseConnection()
        End Function

        ' Purpose: danh sach bien muc so luoc theo Inputdate
        ' Input: Inputdate
        ' Output: DataTable have sorted
        Public Function RetrieveItemCatQueueField(ByVal intModeSort As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CAT_QUEUE_SEL_INPUTDATE"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("intReviewed", OracleType.Number)).Value = intReviewed
                        .Parameters.Add(New OracleParameter("InputDate", OracleType.VarChar, 10)).Value = strInputDate
                        .Parameters.Add(New OracleParameter("intModeSort", OracleType.Number)).Value = intModeSort
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                    End With
                    Try
                        oraDataAdapter.SelectCommand = oraCommand
                        oraDataAdapter.Fill(dsData, "tblResult")
                        RetrieveItemCatQueueField = dsData.Tables("tblResult")
                        dsData.Tables.Remove("tblResult")
                    Catch OraEx As OracleException
                        strErrorMsg = OraEx.Message.ToString
                        intErrorCode = OraEx.Code
                    Finally
                        oraCommand.Parameters.Clear()
                    End Try
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spQueue_SelInputDate"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intReviewed", SqlDbType.Int)).Value = intReviewed
                        .Parameters.Add(New SqlParameter("@intModeSort", SqlDbType.Int)).Value = intModeSort
                        .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                        .Parameters.Add(New SqlParameter("@InputDate", SqlDbType.VarChar, 10)).Value = strInputDate
                    End With
                    Try
                        SqlDataAdapter.SelectCommand = SqlCommand
                        SqlDataAdapter.Fill(dsData, "tblResult")
                        RetrieveItemCatQueueField = dsData.Tables("tblResult")
                        dsData.Tables.Remove("tblResult")
                    Catch sqlClientEx As SqlException
                        strErrorMsg = sqlClientEx.Message.ToString
                        intErrorCode = sqlClientEx.Number
                    Finally
                        SqlCommand.Parameters.Clear()
                    End Try
            End Select
            Call CloseConnection()
        End Function

        ' Purpose: danh sach bien muc so luoc theo Inputdate(like as RetrieveItemCatQueueField defirrent at sort field)
        ' Input: intReviewed, Inputdate, intModeSort(0: Title, 1: CreatedDate, 2: Code)
        ' Output: DataTable have sorted
        Public Function GetItemCatQueueField(ByVal intModeSort As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CAT_QUEUE_SEL_INDATE_SORT"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("intReviewed", OracleType.Number)).Value = intReviewed
                        .Parameters.Add(New OracleParameter("intModeSort", OracleType.Number)).Value = intModeSort
                        .Parameters.Add(New OracleParameter("InputDate", OracleType.VarChar, 10)).Value = strInputDate
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                    End With
                    Try
                        oraDataAdapter.SelectCommand = oraCommand
                        oraDataAdapter.Fill(dsData, "tblResult")
                        GetItemCatQueueField = dsData.Tables("tblResult")
                        dsData.Tables.Remove("tblResult")
                    Catch OraEx As OracleException
                        strErrorMsg = OraEx.Message.ToString
                        intErrorCode = OraEx.Code
                    Finally
                        oraCommand.Parameters.Clear()
                    End Try
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spQueue_SelInDateSort"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intReviewed", SqlDbType.Int)).Value = intReviewed
                        .Parameters.Add(New SqlParameter("@intModeSort", SqlDbType.Int)).Value = intModeSort
                        .Parameters.Add(New SqlParameter("@intLibId", SqlDbType.Int)).Value = intLibID
                        .Parameters.Add(New SqlParameter("@InputDate", SqlDbType.VarChar, 10)).Value = strInputDate
                    End With
                    Try
                        SqlDataAdapter.SelectCommand = SqlCommand
                        SqlDataAdapter.Fill(dsData, "tblResult")
                        GetItemCatQueueField = dsData.Tables("tblResult")
                        dsData.Tables.Remove("tblResult")
                    Catch sqlClientEx As SqlException
                        strErrorMsg = sqlClientEx.Message.ToString
                        intErrorCode = sqlClientEx.Number
                    Finally
                        SqlCommand.Parameters.Clear()
                    End Try
            End Select
            Call CloseConnection()
        End Function
        Public Function GetItemCatQueueFieldPaging(ByVal intModeSort As Integer, ByVal offset As Integer, ByVal take As Integer, ByRef total As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spQueue_SelInDateSort_Paging"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intReviewed", SqlDbType.Int)).Value = intReviewed
                        .Parameters.Add(New SqlParameter("@intModeSort", SqlDbType.Int)).Value = intModeSort
                        .Parameters.Add(New SqlParameter("@intLibId", SqlDbType.Int)).Value = intLibID
                        .Parameters.Add(New SqlParameter("@intOffset", SqlDbType.Int)).Value = offset
                        .Parameters.Add(New SqlParameter("@intTake", SqlDbType.Int)).Value = take
                        .Parameters.Add(New SqlParameter("@intTotal", SqlDbType.Int)).Direction = ParameterDirection.Output
                        .Parameters.Add(New SqlParameter("@InputDate", SqlDbType.VarChar, 10)).Value = strInputDate

                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemCatQueueFieldPaging = dsData.Tables("tblResult")
                            total = If(IsDBNull(.Parameters("@intTotal").Value), 0, .Parameters("@intTotal").Value)
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            sqlCommand.Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose: Display quick view for catalogue module
        ' Output: DataTable 
        Public Function GetQuickView() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_QUICK_VIEW"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                    End With
                    Try
                        oraDataAdapter.SelectCommand = oraCommand
                        oraDataAdapter.Fill(dsData, "tblResult")
                        GetQuickView = dsData.Tables("tblResult")
                        dsData.Tables.Remove("tblResult")
                    Catch OraEx As OracleException
                        strErrorMsg = OraEx.Message.ToString
                        intErrorCode = OraEx.Code
                    Finally
                        oraCommand.Parameters.Clear()
                    End Try
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spItem_SelQuickView"
                        .CommandType = CommandType.StoredProcedure

                    End With
                    Try
                        SqlDataAdapter.SelectCommand = SqlCommand
                        SqlDataAdapter.Fill(dsData, "tblResult")
                        GetQuickView = dsData.Tables("tblResult")
                    Catch sqlClientEx As SqlException
                        strErrorMsg = sqlClientEx.Message.ToString
                        intErrorCode = sqlClientEx.Number
                    Finally
                        dsData.Tables.Remove("tblResult")
                    End Try
            End Select
            Call CloseConnection()
        End Function

        ' Method: Dispose
        ' Purpose: Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    Call MyBase.Dispose(isDisposing)
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace