' Name: clsDRequestCollection
' Purpose: Management collection of requests
' Creator: Oanhtn
' Created Date: 01/11/2004
' Modification History:

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Edeliv
    Public Class clsDRequestCollection
        Inherits clsDERequest

        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************

        Private strCustomerName As String
        Private strNameOfFile As String
        Private dblPriceOfFile As Double
        Private dblPriceOfFileFrom As Double = 0
        Private dblPriceOfFileTo As Double = 0
        Protected strSizeOfFileFrom As String = ""
        Protected strSizeOfFileTo As String = ""
        Private intTimeMode As Integer
        'Private intStatusID As Integer
        Private strRequestIDs As String
        Private strTimeFrom As String
        Private strTimeTo As String
        Private lngTopNum As Long

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' SizeOfFileTo property
        Public Property SizeOfFileTo() As String
            Get
                Return strSizeOfFileTo
            End Get
            Set(ByVal Value As String)
                strSizeOfFileTo = Value
            End Set
        End Property

        ' SizeOfFileFrom property
        Public Property SizeOfFileFrom() As String
            Get
                Return strSizeOfFile
            End Get
            Set(ByVal Value As String)
                strSizeOfFileFrom = Value
            End Set
        End Property

        ' PriceOfFileFrom property
        Public Property PriceOfFileFrom() As Double
            Get
                Return dblPriceOfFileFrom
            End Get
            Set(ByVal Value As Double)
                dblPriceOfFileFrom = Value
            End Set
        End Property

        ' PriceOfFile property
        Public Property PriceOfFileTo() As Double
            Get
                Return dblPriceOfFileTo
            End Get
            Set(ByVal Value As Double)
                dblPriceOfFileTo = Value
            End Set
        End Property

        ' CustomerName property
        Public Property CustomerName() As String
            Get
                Return strCustomerName
            End Get
            Set(ByVal Value As String)
                strCustomerName = Value
            End Set
        End Property

        ' NameOfFile property
        Public Property NameOfFile() As String
            Get
                Return strNameOfFile
            End Get
            Set(ByVal Value As String)
                strNameOfFile = Value
            End Set
        End Property

        ' PriceOfFile property
        Public Property PriceOfFile() As Double
            Get
                Return dblPriceOfFile
            End Get
            Set(ByVal Value As Double)
                dblPriceOfFile = Value
            End Set
        End Property

        ' TimeMode property
        Public Property TimeMode() As Integer
            Get
                Return intTimeMode
            End Get
            Set(ByVal Value As Integer)
                intTimeMode = Value
            End Set
        End Property

        ' StatusID property
        'Public Property StatusID() As Integer
        '    Get
        '        Return intStatusID
        '    End Get
        '    Set(ByVal Value As Integer)
        '        intStatusID = Value
        '    End Set
        'End Property

        ' RequestIDs property
        Public Property RequestIDs() As String
            Get
                Return strRequestIDs
            End Get
            Set(ByVal Value As String)
                strRequestIDs = Value
            End Set
        End Property

        ' TimeFrom property
        Public Property TimeFrom() As String
            Get
                Return strTimeFrom
            End Get
            Set(ByVal Value As String)
                strTimeFrom = Value
            End Set
        End Property

        ' TimeTo property
        Public Property TimeTo() As String
            Get
                Return strTimeTo
            End Get
            Set(ByVal Value As String)
                strTimeTo = Value
            End Set
        End Property

        ' TopNum property
        Public Property TopNum() As Long
            Get
                Return lngTopNum
            End Get
            Set(ByVal Value As Long)
                lngTopNum = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Filter method
        ' Purpose: Filter request list
        ' Input: some infor of request
        ' Output: datatable result
        Public Function Filter() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    ' Change EDELIV_FILE to CAT_EDATA_FILE
                    With oraCommand
                        .CommandText = "EDELIV.SP_GET_FILTER_EREQUESTS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strCustomerName", OracleType.NVarChar, 100)).Value = strCustomerName
                            .Parameters.Add(New OracleParameter("strNameOfFile", OracleType.VarChar, 100)).Value = strNameOfFile
                            .Parameters.Add(New OracleParameter("dblPriceOfFileFrom", OracleType.Float)).Value = dblPriceOfFileFrom
                            .Parameters.Add(New OracleParameter("dblPriceOfFileTo", OracleType.Float)).Value = dblPriceOfFileTo
                            .Parameters.Add(New OracleParameter("strSizeOfFileFrom", OracleType.VarChar, 100)).Value = strSizeOfFileFrom
                            .Parameters.Add(New OracleParameter("strSizeOfFileTo", OracleType.VarChar, 100)).Value = strSizeOfFileTo
                            .Parameters.Add(New OracleParameter("intTimeMode", OracleType.Number)).Value = intTimeMode
                            .Parameters.Add(New OracleParameter("strTimeFrom", OracleType.VarChar, 100)).Value = strTimeFrom
                            .Parameters.Add(New OracleParameter("strTimeTo", OracleType.VarChar, 100)).Value = strTimeTo
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output

                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            Filter = dsData.Tables("tblResult")
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
                        .CommandText = "Edl_spRequest_SelFilter"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strCustomerName", SqlDbType.NVarChar, 100)).Value = strCustomerName
                            .Parameters.Add(New SqlParameter("@strNameOfFile", SqlDbType.VarChar, 100)).Value = strNameOfFile
                            .Parameters.Add(New SqlParameter("@dblPriceOfFileFrom", SqlDbType.Float)).Value = dblPriceOfFileFrom
                            .Parameters.Add(New SqlParameter("@dblPriceOfFileTo", SqlDbType.Float)).Value = dblPriceOfFileTo
                            .Parameters.Add(New SqlParameter("@strSizeOfFileFrom", SqlDbType.VarChar, 100)).Value = strSizeOfFileFrom
                            .Parameters.Add(New SqlParameter("@strSizeOfFileTo", SqlDbType.VarChar, 100)).Value = strSizeOfFileTo
                            .Parameters.Add(New SqlParameter("@intTimeMode", SqlDbType.Int)).Value = intTimeMode
                            .Parameters.Add(New SqlParameter("@strTimeFrom", SqlDbType.VarChar, 100)).Value = strTimeFrom
                            .Parameters.Add(New SqlParameter("@strTimeTo", SqlDbType.VarChar, 100)).Value = strTimeTo

                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            Filter = dsData.Tables("tblResult")
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

        ' CreateAnnualStat method
        ' Purpose: Create annual statistic
        ' Input: some infor
        ' Output: datatable result
        Public Function CreateAnnualStat(ByVal intType As Int16) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_GET_EDELIV_ANNUALSTAT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intType", OracleType.Number)).Value = intType
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            CreateAnnualStat = dsData.Tables("tblResult")
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
                        .CommandText = "Edl_spRequest_AnnualStat"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intType", SqlDbType.Int)).Value = intType
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            CreateAnnualStat = dsData.Tables("tblResult")
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

        ' GetRequestedYears method
        ' Purpose: Get requested years
        ' Input: some infor
        ' Output: datatable result
        Public Function GetRequestedYears() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_GET_EDELIV_REQYEAR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetRequestedYears = dsData.Tables("tblResult")
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
                        .CommandText = "Edl_spRequest_SelYearOrderByYear"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetRequestedYears = dsData.Tables("tblResult")
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

        ' GetRequestedMonths method
        ' Purpose: Get requested month
        ' Input: some infor
        ' Output: datatable result
        Public Function GetRequestedMonths(ByVal intYear As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_GET_EDELIV_REQMONTH"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intYear", OracleType.Number)).Value = intYear
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetRequestedMonths = dsData.Tables("tblResult")
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
                        .CommandText = "Edl_spRequest_SelYear"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = intYear
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetRequestedMonths = dsData.Tables("tblResult")
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

        ' CreateMonthlyStat method
        ' Purpose: Create monthly statistic
        ' Input: some infor
        ' Output: datatable result
        Public Function CreateMonthlyStat(ByVal intType As Int16, ByVal intYear As Integer, ByVal strTemp As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_GET_EDELIV_MONTHSTAT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intType", OracleType.Number)).Value = intType
                            .Parameters.Add(New OracleParameter("intYear", OracleType.Number)).Value = intYear
                            .Parameters.Add(New OracleParameter("strTemp", OracleType.VarChar, 10)).Value = strTemp
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            CreateMonthlyStat = dsData.Tables("tblResult")
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
                        .CommandText = "Edl_spRequest_SelMonthStat"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intType", SqlDbType.Int)).Value = intType
                            .Parameters.Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = intYear
                            .Parameters.Add(New SqlParameter("@strTemp", SqlDbType.NVarChar, 10)).Value = strTemp

                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            CreateMonthlyStat = dsData.Tables("tblResult")
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

        ' CreateDailyStat method
        ' Purpose: Create daily statistic
        ' Input: some infor
        ' Output: datatable result
        Public Function CreateDailyStat(ByVal intType As Int16, ByVal intYear As Integer, ByVal intMonth As Integer, ByVal strTemp As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_GET_EDELIV_DAYSTAT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intType", OracleType.Number)).Value = intType
                            .Parameters.Add(New OracleParameter("intYear", OracleType.Number)).Value = intYear
                            .Parameters.Add(New OracleParameter("intMonth", OracleType.Number)).Value = intMonth
                            .Parameters.Add(New OracleParameter("strTemp", OracleType.VarChar, 10)).Value = strTemp
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            CreateDailyStat = dsData.Tables("tblResult")
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
                        .CommandText = "Edl_spRequest_SelDayStat"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intType", SqlDbType.Int)).Value = intType
                            .Parameters.Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = intYear
                            .Parameters.Add(New SqlParameter("@intMonth", SqlDbType.Int)).Value = intMonth
                            .Parameters.Add(New SqlParameter("@strTemp", SqlDbType.NVarChar, 10)).Value = strTemp
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            CreateDailyStat = dsData.Tables("tblResult")
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

        ' CreateTopCustomersStat method
        ' Purpose: Create top customer statistic
        ' Input: some infor
        ' Output: datatable result
        Public Function CreateTopCustomersStat(ByVal lngMinTurn As Long) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_GET_EDELIV_TOPCUSSTAT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strTimeFrom", OracleType.VarChar, 20)).Value = strTimeFrom
                            .Parameters.Add(New OracleParameter("strTimeTo", OracleType.VarChar, 20)).Value = strTimeTo
                            .Parameters.Add(New OracleParameter("intTopItems", OracleType.Number)).Value = lngTopNum
                            .Parameters.Add(New OracleParameter("intMinTurn", OracleType.Number)).Value = lngMinTurn
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            CreateTopCustomersStat = dsData.Tables("tblResult")
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
                        .CommandText = "Cat_spEdata_SelTopCusStat"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strTimeFrom", SqlDbType.VarChar, 20)).Value = strTimeFrom
                            .Parameters.Add(New SqlParameter("@strTimeTo", SqlDbType.VarChar, 20)).Value = strTimeTo
                            .Parameters.Add(New SqlParameter("@intTopItems", SqlDbType.Int)).Value = lngTopNum
                            .Parameters.Add(New SqlParameter("@intMinTurn", SqlDbType.Int)).Value = lngMinTurn

                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            CreateTopCustomersStat = dsData.Tables("tblResult")
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

        ' CreateTop20Stat method
        ' Purpose: Create top20 statistic
        ' Input: some infor
        ' Output: datatable result
        Public Function CreateTop20Stat(ByVal intPropertyID As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_GET_EDELIV_TOP20STAT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intPropertyID", OracleType.Number)).Value = intPropertyID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            CreateTop20Stat = dsData.Tables("tblResult")
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
                        .CommandText = "Cat_spEdata_SelTop20Stat"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intPropertyID", SqlDbType.Int)).Value = intPropertyID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            CreateTop20Stat = dsData.Tables("tblResult")
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

        ' CreateTopItemsStat method
        ' Purpose: Create top items statistic
        ' Input: some infor
        ' Output: datatable result
        Public Function CreateTopItemsStat(ByVal lngMinTurn As Long) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_GET_EDELIV_TOPITEMSTAT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strTimeFrom", OracleType.VarChar, 20)).Value = strTimeFrom
                            .Parameters.Add(New OracleParameter("strTimeTo", OracleType.VarChar, 20)).Value = strTimeTo
                            .Parameters.Add(New OracleParameter("intTopItems", OracleType.Number)).Value = lngTopNum
                            .Parameters.Add(New OracleParameter("intMinTurn", OracleType.Number)).Value = lngMinTurn
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            CreateTopItemsStat = dsData.Tables("tblResult")
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
                        .CommandText = "Cat_spEdata_SelTopOtemStat"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strTimeFrom", SqlDbType.VarChar, 20)).Value = strTimeFrom
                            .Parameters.Add(New SqlParameter("@strTimeTo", SqlDbType.VarChar, 20)).Value = strTimeTo
                            .Parameters.Add(New SqlParameter("@intTopItems", SqlDbType.Int)).Value = lngTopNum
                            .Parameters.Add(New SqlParameter("@intMinTurn", SqlDbType.Int)).Value = lngMinTurn

                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            CreateTopItemsStat = dsData.Tables("tblResult")
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

        ' GetERequestList method
        ' Purpose: Get request list
        ' Input: some infor of request
        ' Output: datatable result
        Public Function GetERequestList() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_GET_EDELIV_REQUESTS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intStatusID", OracleType.Number)).Value = intStatusID
                            .Parameters.Add(New OracleParameter("strRequestIDs", OracleType.VarChar, 1000)).Value = strRequestIDs
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetERequestList = dsData.Tables("tblResult")
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
                        .CommandText = "Edl_spRequest_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intStatusID", SqlDbType.Int)).Value = intStatusID
                            .Parameters.Add(New SqlParameter("@strRequestIDs", SqlDbType.VarChar, 1000)).Value = strRequestIDs
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetERequestList = dsData.Tables("tblResult")
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

        ' GetERequestNum method
        ' Purpose: Get number of requests
        ' Input: topnumber 
        ' Output: datatable result
        Public Function GetERequestNum(ByRef lngTotalRec As Long, ByRef lngCurrentPos As Long) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_GET_EREQUEST_BY_TOPNUM"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngRequestID", OracleType.Number)).Value = lngRequestID
                            .Parameters.Add(New OracleParameter("lngTopNum", OracleType.Number)).Value = lngTopNum
                            .Parameters.Add(New OracleParameter("lngTotalRec", OracleType.Number)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("lngCurrentPos", OracleType.Number)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            lngTotalRec = .Parameters("lngTotalRec").Value
                            lngCurrentPos = .Parameters("lngCurrentPos").Value
                            GetERequestNum = dsData.Tables("tblResult")
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
                        .CommandText = "Edl_spRequest_SelByTopNum"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngRequestID", SqlDbType.Int)).Value = lngRequestID
                            .Parameters.Add(New SqlParameter("@lngTopNum", SqlDbType.Int)).Value = lngTopNum
                            .Parameters.Add(New SqlParameter("@lngTotalRec", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@lngCurrentPos", SqlDbType.Int)).Direction = ParameterDirection.Output

                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            lngTotalRec = .Parameters("@lngTotalRec").Value
                            lngCurrentPos = .Parameters("@lngCurrentPos").Value
                            GetERequestNum = dsData.Tables("tblResult")
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

        ' GetERequestProcess
        ' Purpose: Get the request processing
        ' Output: datatable result
        Public Function GetERequestProcess(ByRef intNumOfReq As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_GET_EDELIV_REQUEST_PROCESS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intNumOfReqProcessing", OracleType.Number)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetERequestProcess = dsData.Tables("tblResult")
                            intNumOfReq = .Parameters("intNumOfReqProcessing").Value
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
                        .CommandText = "Edl_spRequest_SelProcess"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intNumOfReqProcessing", SqlDbType.Int)).Direction = ParameterDirection.Output
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetERequestProcess = dsData.Tables("tblResult")
                            intNumOfReq = .Parameters("@intNumOfReqProcessing").Value
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

        ' GetCatDicList method
        ' Purpose: Get information of Catdiclist table
        ' Input: intID (optional default=0)
        ' Output: DataTable
        ' Creator: Lent. Date:02/11/04
        Public Function GetCatDicList2Field(Optional ByVal intID As Integer = 0) As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spDicList_SelNameAndIdByIdWithIndex"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblCatDicList2Field")
                            GetCatDicList2Field = dsData.Tables("tblCatDicList2Field")
                            dsData.Tables.Remove("tblCatDicList2Field")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oracommand
                        .CommandText = "OPAC.SP_GETCATDICLIST2FIELD"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intID", OracleType.Number)).Value = intID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblCatDicList2Field")
                            GetCatDicList2Field = dsData.Tables("tblCatDicList2Field")
                            dsData.Tables.Remove("tblCatDicList2Field")
                        Catch oraClientEx As OracleException
                            strErrorMsg = oraClientEx.Message.ToString
                            intErrorCode = oraClientEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
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