' Class: Statistic
' Purpose: Statistic purpose
' Creator: Sondp
' Created date: 02/02/2005
' Modification history:

Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Acquisition
    Public Class clsDStatistic
        Inherits clsDBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Private strTypeSelect As String
        Private strIndex As String  ' DDC or BBK 
        Private strWhere As String
        Private strBranch As String

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************

        ' Branch property
        Property Branch() As String
            Get
                Return (strBranch)
            End Get
            Set(ByVal Value As String)
                strBranch = Value
            End Set
        End Property

        ' Where property
        Property Where() As String
            Get
                Return (strWhere)
            End Get
            Set(ByVal Value As String)
                strWhere = Value
            End Set
        End Property

        ' Index property
        Property Index() As String
            Get
                Return (strIndex)
            End Get
            Set(ByVal Value As String)
                strIndex = Value
            End Set
        End Property

        ' TypeSelect Property
        Property TypeSelect() As String
            Get
                Return (strTypeSelect)
            End Get
            Set(ByVal Value As String)
                strTypeSelect = Value
            End Set
        End Property

        ' *************************************************************************************************
        ' End declare properties
        ' Implement methods
        ' *************************************************************************************************

        ' Purpose: statistic by ItemType
        ' Input: strTypeSelect
        ' Output: Datatable
        ' Created by: Sondp
        Public Function StatItemType() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHolding_SelItemType"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strTypeSelect", SqlDbType.VarChar, 20)).Value = strTypeSelect
                            .Parameters.Add(New SqlParameter("@intLibId", SqlDbType.Int)).Value = intLibID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            StatItemType = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_STATITEMTYPE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strTypeSelect", OracleType.VarChar, 20)).Value = strTypeSelect
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            StatItemType = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose: Statistic ClassCopyNumber ( Dau an pham )
        ' Input: Some informations
        ' Output: Datatable
        ' Created by: Sondp
        Public Function StatClassCopyNumber() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHolding_SelStatClassCopyNumber"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strTypeSelect", SqlDbType.VarChar, 20)).Value = strTypeSelect
                                .Add(New SqlParameter("@strIndex", SqlDbType.VarChar, 3)).Value = strIndex
                                .Add(New SqlParameter("@strWhere", SqlDbType.VarChar, 400)).Value = strWhere
                                .Add(New SqlParameter("@strBranch", SqlDbType.VarChar, 10)).Value = strBranch
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            StatClassCopyNumber = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_STATCLASSCOPYNUMBER"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strTypeSelect", OracleType.VarChar, 20)).Value = strTypeSelect
                                .Add(New OracleParameter("strIndex", OracleType.VarChar, 3)).Value = strIndex
                                .Add(New OracleParameter("strWhere", OracleType.VarChar, 400)).Value = strWhere
                                .Add(New OracleParameter("strBranch", OracleType.VarChar, 10)).Value = strTypeSelect
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            StatClassCopyNumber = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Method: StatYear
        ' Purpose: Create statisitc by acqyear
        ' Input: Some need info
        ' Output: datatable result
        ' Creator: Sondp
        Public Function StatYear() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHolding_SelStatYear"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strTypeSelect", SqlDbType.VarChar, 20)).Value = strTypeSelect
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            StatYear = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_STATYEAR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strTypeSelect", OracleType.VarChar, 20)).Value = strTypeSelect
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            StatYear = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function StatYearOther(ByVal intYearStart As Integer, ByVal intYearEnd As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHolding_SelStatYearOther"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strTypeSelect", SqlDbType.VarChar, 20)).Value = strTypeSelect
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            .Parameters.Add(New SqlParameter("@intYearStart", SqlDbType.Int)).Value = intYearStart
                            .Parameters.Add(New SqlParameter("@intYearEnd", SqlDbType.Int)).Value = intYearEnd
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            StatYearOther = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    'With oraCommand
                    '    .CommandText = "ACQUISITION.SP_ACQ_STATYEAR"
                    '    .CommandType = CommandType.StoredProcedure
                    '    Try
                    '        .Parameters.Add(New OracleParameter("strTypeSelect", OracleType.VarChar, 20)).Value = strTypeSelect
                    '        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                    '        oraDataAdapter.SelectCommand = oraCommand
                    '        oraDataAdapter.Fill(dsData, "tblResult")
                    '        StatYearOther = dsData.Tables("tblResult")
                    '        dsData.Tables.Remove("tblResult")
                    '    Catch OraEx As OracleException
                    '        strErrorMsg = OraEx.Message.ToString
                    '        intErrorCode = OraEx.Code
                    '    Finally
                    '        .Parameters.Clear()
                    '    End Try
                    'End With
            End Select
            Call CloseConnection()
        End Function

        Public Function StatYearOtherDetail(ByVal intYearStart As Integer, ByVal intYearEnd As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHolding_SelStatYearOther_Detail"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intYearStart", SqlDbType.Int)).Value = intYearStart
                            .Parameters.Add(New SqlParameter("@intYearEnd", SqlDbType.Int)).Value = intYearEnd
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            StatYearOtherDetail = dsData.Tables("tblResult")
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

        ' Purpose: Get summary of holding
        ' In: intUserID
        ' Output: datatable result
        ' Creator: Sondp
        Public Function GetSummaryHoldings(ByVal intUserID As Integer, ByVal intMode As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHolding_StatQuickView"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intMode", SqlDbType.Int, 4)).Value = intMode
                            .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int, 4)).Value = intUserID
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetSummaryHoldings = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_STAT_QUICKVIEW"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intMode", OracleType.Number, 4)).Value = intMode
                            .Parameters.Add(New OracleParameter("intUserID", OracleType.Number, 4)).Value = intUserID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetSummaryHoldings = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose: Statistic Month
        ' Input: strSelectType, strYear
        ' Output: Datatable
        ' Created by: Sondp
        Public Function StatMonth(ByVal strYear As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHolding_SelStatMonth"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strTypeSelect", SqlDbType.VarChar, 20)).Value = strTypeSelect
                                .Add(New SqlParameter("@strYear", SqlDbType.VarChar, 4)).Value = strYear
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            StatMonth = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_STATMONTH"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strTypeSelect", OracleType.VarChar, 20)).Value = strTypeSelect
                                .Add(New OracleParameter("strYear", OracleType.VarChar, 4)).Value = strYear
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            StatMonth = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function StatMonthDetail(ByVal strYear As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHolding_SelStatMonth_Detail"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strYear", SqlDbType.VarChar, 4)).Value = strYear
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            StatMonthDetail = dsData.Tables("tblResult")
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

        ' Method: StatDay
        ' Purpose: Statistic Day
        ' Input: strMonth, strYear and some infor
        ' Creator: Sondp
        Public Function StatDay(ByVal strDay As String, ByVal strMonth As String, ByVal strYear As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHolding_SelStatDay"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strTypeSelect", SqlDbType.VarChar, 20)).Value = strTypeSelect
                                .Add(New SqlParameter("@strDay", SqlDbType.VarChar, 2)).Value = strDay
                                .Add(New SqlParameter("@strMonth", SqlDbType.VarChar, 4)).Value = strMonth
                                .Add(New SqlParameter("@strYear", SqlDbType.VarChar, 4)).Value = strYear
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            StatDay = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_STATDAY"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strTypeSelect", OracleType.VarChar, 20)).Value = strTypeSelect
                                .Add(New OracleParameter("strDay", OracleType.VarChar, 2)).Value = strDay
                                .Add(New OracleParameter("strMonth", OracleType.VarChar, 2)).Value = strMonth
                                .Add(New OracleParameter("strYear", OracleType.VarChar, 4)).Value = strYear
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            StatDay = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function StatDayDetail(ByVal strMonth As String, ByVal strYear As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHolding_SelStatDay_Detail"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strMonth", SqlDbType.VarChar, 2)).Value = strMonth
                                .Add(New SqlParameter("@strYear", SqlDbType.VarChar, 4)).Value = strYear
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            StatDayDetail = dsData.Tables("tblResult")
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

        Public Function StatTimes(ByVal strDateFrom As String, ByVal strDateTo As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHolding_SelStatTimes"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strTypeSelect", SqlDbType.VarChar, 20)).Value = strTypeSelect
                                .Add(New SqlParameter("@strDateFrom", SqlDbType.VarChar, 20)).Value = strDateFrom
                                .Add(New SqlParameter("@strDateTo", SqlDbType.VarChar, 20)).Value = strDateTo
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            StatTimes = dsData.Tables("tblResult")
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

        Public Function StatTimesDetail(ByVal strDateFrom As String, ByVal strDateTo As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHolding_SelStatTimes_Detail"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strDateFrom", SqlDbType.VarChar, 20)).Value = strDateFrom
                                .Add(New SqlParameter("@strDateTo", SqlDbType.VarChar, 20)).Value = strDateTo
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            StatTimesDetail = dsData.Tables("tblResult")
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

        ' Purpose: Statistic ClassItemID ( Bau an pham )
        ' Input: Some informations
        ' Output: Datatable
        ' Created by: Sondp
        Public Function StatClassItemID() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHolding_SelStatClassItemId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strTypeSelect", SqlDbType.VarChar, 20)).Value = strTypeSelect
                                .Add(New SqlParameter("@strIndex", SqlDbType.VarChar, 3)).Value = strIndex
                                .Add(New SqlParameter("@strWhere", SqlDbType.VarChar, 400)).Value = strWhere
                                .Add(New SqlParameter("@strBranch", SqlDbType.VarChar, 10)).Value = strBranch
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            StatClassItemID = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_STATCLASSITEMID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strTypeSelect", OracleType.VarChar, 20)).Value = strTypeSelect
                                .Add(New OracleParameter("strIndex", OracleType.VarChar, 3)).Value = strIndex
                                .Add(New OracleParameter("strWhere", OracleType.VarChar, 400)).Value = strWhere
                                .Add(New OracleParameter("strBranch", OracleType.VarChar, 10)).Value = strTypeSelect
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            StatClassItemID = dsData.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose: Statistic Language
        ' Input: strTypeSelect
        ' Output: Datatable
        ' Created by: Sondp
        Public Function StatLanguage() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHolding_SelStatLanguage"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strTypeSelect", SqlDbType.VarChar, 20)).Value = strTypeSelect
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            StatLanguage = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_STATLANGUAGE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strTypeSelect", OracleType.VarChar, 20)).Value = strTypeSelect
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            StatLanguage = dsData.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose: Create statistic by medium
        ' Input: some main information
        ' Creator: Sondp
        Public Function StatMedium() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHolding_SelStatMedium"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strTypeSelect", SqlDbType.VarChar, 20)).Value = strTypeSelect
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            StatMedium = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_STATMEDIUM"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strTypeSelect", OracleType.VarChar, 20)).Value = strTypeSelect
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            StatMedium = dsData.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose: Statistic Source (Publisher)
        ' Input: strTypeSelect, strFromDate, strToDate
        ' Output: Datatable
        ' Created by: Sondp
        Public Function StatSource(ByVal strFromDate As String, ByVal strToDate As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHolding_SelSource"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strTypeSelect", SqlDbType.VarChar, 20)).Value = strTypeSelect
                                .Add(New SqlParameter("@strFromDate", SqlDbType.VarChar, 24)).Value = strFromDate
                                .Add(New SqlParameter("@strToDate", SqlDbType.VarChar, 24)).Value = strToDate
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            StatSource = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_STATSOURCE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strTypeSelect", OracleType.VarChar, 20)).Value = strTypeSelect
                                .Add(New OracleParameter("strFromDate", OracleType.VarChar, 24)).Value = strFromDate
                                .Add(New OracleParameter("strToDate", OracleType.VarChar, 24)).Value = strToDate
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            StatSource = dsData.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose: Statistic Nation Publisher
        ' Input: strTypeSelect
        ' Output: Datatable
        ' Created by: Sondp
        Public Function StatNationPub() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHolding_SelStatNationPub"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strTypeSelect", SqlDbType.VarChar, 20)).Value = strTypeSelect
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            StatNationPub = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_STATNATIONPUB"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strTypeSelect", OracleType.VarChar, 20)).Value = strTypeSelect
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            StatNationPub = dsData.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose: Statistic Top20
        ' Input: strTypeSelect
        ' Output: Datatable
        ' Created by: Sondp
        Public Function StatTop20() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHolding_SelStat20"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strTypeSelect", SqlDbType.VarChar, 20)).Value = strTypeSelect
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            StatTop20 = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_STATTOP20"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strTypeSelect", OracleType.VarChar, 20)).Value = strTypeSelect
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            StatTop20 = dsData.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Methopd: StatLocation
        ' Purpose: Create statistic by location
        ' Input: intLocID
        ' Output: some Information
        ' Creator: Sondp
        Public Function StatLocation(ByVal intLocID As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHolding_SelStatLocation"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strTypeSelect", SqlDbType.VarChar, 20)).Value = strTypeSelect
                                .Add(New SqlParameter("@intLocID", SqlDbType.Int, 4)).Value = intLocID
                            End With
                            .ExecuteNonQuery()
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            StatLocation = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_STATLOCATION"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strTypeSelect", OracleType.VarChar, 20)).Value = strTypeSelect
                                .Add(New OracleParameter("intLocID", OracleType.Number, 4)).Value = intLocID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            StatLocation = dsData.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Method: GetAcqYear
        ' Purpose: Get AcqYear in holding table
        ' Output: Datatable
        ' Creator: Sondp
        Public Function GetAcqYear() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHolding_SelAcqYear"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetAcqYear = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_GET_ACQYEAR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetAcqYear = dsData.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function GetItemPulishYear(Optional ByVal intYearStart As Integer = 0, Optional ByVal intYearEnd As Integer = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHolding_SelPublishYear"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intYearStart", SqlDbType.Int)).Value = intYearStart
                                .Add(New SqlParameter("@intYearEnd", SqlDbType.Int)).Value = intYearEnd
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemPulishYear = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    'With oraCommand
                    '    .CommandText = "ACQUISITION.SP_ACQ_GET_ACQYEAR"
                    '    .CommandType = CommandType.StoredProcedure
                    '    Try
                    '        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                    '        oraDataAdapter.SelectCommand = oraCommand
                    '        oraDataAdapter.Fill(dsData, "tblResult")
                    '        GetItemPulishYear = dsData.Tables("tblResult")
                    '    Catch OraEx As OracleException
                    '        strErrorMsg = OraEx.Message.ToString
                    '        intErrorCode = OraEx.Code
                    '    Finally
                    '        .Parameters.Clear()
                    '        dsData.Tables.Remove("tblResult")
                    '    End Try
                    'End With
            End Select
            Call CloseConnection()
        End Function

        Public Function GetItemPulishYearDetail(Optional ByVal intYearStart As Integer = 0, Optional ByVal intYearEnd As Integer = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHolding_SelPublishYear_Detail"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intYearStart", SqlDbType.Int)).Value = intYearStart
                                .Add(New SqlParameter("@intYearEnd", SqlDbType.Int)).Value = intYearEnd
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemPulishYearDetail = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Method: Dispose
        ' Purpose: Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                Call MyBase.Dispose(isDisposing)
            Finally
                MyBase.Dispose()
                Call Dispose()
            End Try
        End Sub
    End Class
End Namespace