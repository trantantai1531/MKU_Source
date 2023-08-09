' Name: clsDPeriodicalCollection
' Purpose: Management periodical collection
' Creator: Oanhtn
' Created Date: 20/09/2004
' Modification History:
'   + 05/10/2004 by Tuanhv
'       + Add sub: StatByClassification   
'       + Add sub: StatByCountry
'       + Add sub: StatByLanguage
'       + Add Code for sub static  
'   + 07/10/2004 by Tuanhv, Lent  
'       + Add sub:GetTotalExpried
'       + Add sub:CreateReportByAcqSourceStatus
'       + Add sub:GetTotalIssue
'       + Add sub:GetGenIssueItem
'   + 11/10/2004 by Oanhtn
'       + Add new methods:
'   + 20/10/2004 by Sondp
'       + Modfied: GetIssueToClaim, GetClaimList method
'       + Add New: GetVendorToClaim method
'   + 17/04/2005 by Sondp
'       + Add New: GetReportByRangeTime method

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Serial
    Public Class clsDPeriodicalCollection
        Inherits clsDPeriodical

        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************

        Private intAcqSourceID As Integer
        Private intOnSubscription As Integer
        Private intVendorID As Integer
        Private strFromDate As String
        Private strToDate As String
        Private chrClaimCycleMode As Char
        Private strIssueYear As String
        Private strIDs As String
        Private chrSelectMode As Char

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' Flage property
        Public Property SelectMode() As Char
            Get
                Return (chrSelectMode)
            End Get
            Set(ByVal Value As Char)
                chrSelectMode = Value
            End Set
        End Property

        ' IDs property
        Public Shadows Property IDs() As String
            Get
                Return (strIDs)
            End Get
            Set(ByVal Value As String)
                strIDs = Value
            End Set
        End Property

        'ClaimCycleMode  property
        Public Property ClaimCycleMode() As Char
            Get
                Return (chrClaimCycleMode)
            End Get
            Set(ByVal Value As Char)
                chrClaimCycleMode = Value
            End Set
        End Property

        'IssueDate property
        Public Property IssueYear() As String
            Get
                Return (strIssueYear)
            End Get
            Set(ByVal Value As String)
                strIssueYear = Value
            End Set
        End Property

        'get/set VendorID property
        Public Property VendorID() As Integer
            Get
                Return (intVendorID)
            End Get
            Set(ByVal Value As Integer)
                intVendorID = Value
            End Set
        End Property

        'get/set FromDate as string
        Public Property FromDate() As String
            Get
                Return (strFromDate)
            End Get
            Set(ByVal Value As String)
                strFromDate = Value
            End Set
        End Property

        'get/set Todate as string
        Public Property ToDate() As String
            Get
                Return (strToDate)
            End Get
            Set(ByVal Value As String)
                strToDate = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************       

        ' FilterPeriodicalForReceive method
        ' Purpose: Filter Periodicals For Receive
        ' Input: LocationID, IssuedDate
        ' Output: datatable result
        Public Function FilterPeriodicalForReceive(ByVal intLocationID As Integer, ByVal strIssuedDate As String, ByVal strReceivedDate As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_DAYLY_RECEIVE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intLocationID", OracleType.Number)).Value = intLocationID
                            .Parameters.Add(New OracleParameter("strIssuedDate", OracleType.VarChar, 30)).Value = strIssuedDate
                            .Parameters.Add(New OracleParameter("strReceivedDate", OracleType.VarChar, 30)).Value = strReceivedDate
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            FilterPeriodicalForReceive = dsData.Tables("tblResult")
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
                        .CommandText = "Ser_spIssue_SelDaylyReceive"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                            .Parameters.Add(New SqlParameter("@strIssuedDate", SqlDbType.VarChar, 30)).Value = strIssuedDate
                            .Parameters.Add(New SqlParameter("@strReceivedDate", SqlDbType.VarChar, 30)).Value = strReceivedDate
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            FilterPeriodicalForReceive = dsData.Tables("tblResult")
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

        ' FilterPeriodicalForRegister method
        ' Purpose: Filter Periodicals For Register
        ' Input: RegisterDate, PubCoutry, PubLanguage, RegularityCode
        ' Output: datatable result
        Public Function FilterPeriodicalForRegister(ByVal strRegisterDate As String, ByVal strPubCountry As String, ByVal strPubLanguage As String, ByVal chrRegularityCode As String, ByVal strViewCode As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_DAYLY_REGISTER"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strIssuedDate", OracleType.VarChar, 20)).Value = strRegisterDate
                            .Parameters.Add(New OracleParameter("strPubCountry", OracleType.VarChar, 10)).Value = strPubCountry
                            .Parameters.Add(New OracleParameter("strPubLanguage", OracleType.VarChar, 10)).Value = strPubLanguage
                            .Parameters.Add(New OracleParameter("chrRegularityCode", OracleType.Char, 1)).Value = chrRegularityCode
                            .Parameters.Add(New OracleParameter("strViewCode", OracleType.VarChar, 50)).Value = strViewCode
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            FilterPeriodicalForRegister = dsData.Tables("tblResult")
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
                        .CommandText = "Ser_spItem_SelDaylyRegister"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strIssuedDate", SqlDbType.VarChar, 20)).Value = strRegisterDate
                            .Parameters.Add(New SqlParameter("@strPubCountry", SqlDbType.VarChar, 10)).Value = strPubCountry
                            .Parameters.Add(New SqlParameter("@strPubLanguage", SqlDbType.VarChar, 10)).Value = strPubLanguage
                            .Parameters.Add(New SqlParameter("@chrRegularityCode", SqlDbType.Char, 1)).Value = chrRegularityCode
                            .Parameters.Add(New SqlParameter("@strViewCode", SqlDbType.VarChar, 50)).Value = strViewCode
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            FilterPeriodicalForRegister = dsData.Tables("tblResult")
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

        ' StatByRegularity method
        ' Purpose: create statistic by regularity
        ' Output: datatable result
        Public Function StatByRegularity() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_STAT_SERIAL_FREQ "
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            StatByRegularity = dsData.Tables("tblResult")
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
                        .CommandText = "Ser_spStatFreq"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            StatByRegularity = dsData.Tables("tblResult")
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

        ' StatByCategory method
        ' Purpose: create statistic by category
        ' Output: datatable result
        ' Khung phan loai
        Public Function StatByCategory() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_STAT_CATEGORY "
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            StatByCategory = dsData.Tables("tblResult")
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
                        .CommandText = "Ser_spStatCategory"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            StatByCategory = dsData.Tables("tblResult")
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

        ' StatByLocation method
        ' Purpose: create statistic by category
        ' Input: some infor of LibID, LocationID
        ' Output: datatable result
        Public Function StatByLocation() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_STAT_LOCATION_SER "
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            StatByLocation = dsData.Tables("tblResult")
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
                        .CommandText = "Ser_spStatLocation"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            StatByLocation = dsData.Tables("tblResult")
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

        ' StatByTop20 method
        ' Purpose: create statistic by top20 infor
        ' Input: TypeID
        ' Output: datatable result
        Public Function StatByTop20(ByVal intID As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_STAT_SER_TOP20"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intID", OracleType.Number)).Value = intID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            StatByTop20 = dsData.Tables("tblResult")
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
                        .CommandText = "Ser_spStatTop20"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intID
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            StatByTop20 = dsData.Tables("tblResult")
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

        ' StatByGeneralClassification method
        ' Purpose: create statistic by general classification
        ' Output: datatable result
        Public Function StatByGenClassification() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_STAT_GENCLASSIFICATION "
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            StatByGenClassification = dsData.Tables("tblResult")
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
                        .CommandText = "Ser_spStatGenClassification"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            StatByGenClassification = dsData.Tables("tblResult")
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

        ' StatByClassification method
        ' Purpose: create statistic by general classification
        ' Output: datatable result
        Public Function StatByClassification(ByVal strInput As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_STAT_SERIAL_CLASS_DDC"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strInput", OracleType.VarChar, 50)).Value = strInput
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            StatByClassification = dsData.Tables("tblResult")
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
                        .CommandText = "Ser_spStatClassDDC"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strInput", SqlDbType.VarChar, 50)).Value = strInput
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            StatByClassification = dsData.Tables("tblResult")
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

        ' StatByCountry method
        ' Purpose: create statistic by country
        ' Output: datatable result
        Public Function StatByCountry() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_STAT_SERIAL_COUNTRY"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            StatByCountry = dsData.Tables("tblResult")
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
                        .CommandText = "SP_STAT_SERIAL_COUNTRY"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            StatByCountry = dsData.Tables("tblResult")
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

        ' GetReportDetailInfor method
        ' Purpose:  View detail infor Items when create link from statistic
        Public Function GetReportDetailInfor(ByVal strCatagory As String, ByVal strGenclassification As String, ByVal strLocation As String, ByVal strFreq As String, ByVal strLanguage As String, ByVal strCountry As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_REPORT_DETAIL_ITEMS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strCatagory", OracleType.VarChar, 100)).Value = strCatagory
                            .Parameters.Add(New OracleParameter("strGenclassification", OracleType.VarChar, 100)).Value = strGenclassification
                            .Parameters.Add(New OracleParameter("strLocation", OracleType.VarChar, 100)).Value = strLocation
                            .Parameters.Add(New OracleParameter("strFreq", OracleType.VarChar, 100)).Value = strFreq
                            .Parameters.Add(New OracleParameter("strLanguage", OracleType.VarChar, 100)).Value = strLanguage
                            .Parameters.Add(New OracleParameter("strCountry", OracleType.VarChar, 100)).Value = strCountry
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetReportDetailInfor = dsData.Tables("tblResult")
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
                        .CommandText = "Ser_spReportDetailItem"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strCatagory", SqlDbType.NVarChar, 100)).Value = strCatagory
                            .Parameters.Add(New SqlParameter("@strGenclassification", SqlDbType.NVarChar, 100)).Value = strGenclassification
                            .Parameters.Add(New SqlParameter("@strLocation", SqlDbType.NVarChar, 100)).Value = strLocation
                            .Parameters.Add(New SqlParameter("@strFreq", SqlDbType.NVarChar, 100)).Value = strFreq
                            .Parameters.Add(New SqlParameter("@strLanguage", SqlDbType.NVarChar, 100)).Value = strLanguage
                            .Parameters.Add(New SqlParameter("@strCountry", SqlDbType.NVarChar, 100)).Value = strCountry
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetReportDetailInfor = dsData.Tables("tblResult")
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

        ' StatByLanguage method
        ' Purpose: create statistic by language
        ' Output: datatable result
        Public Function StatByLanguage() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_STAT_SERIAL_LANGUAGE "
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            StatByLanguage = dsData.Tables("tblResult")
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
                        .CommandText = "Ser_spStatLanguage"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            StatByLanguage = dsData.Tables("tblResult")
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

        ' CreateGeneralReport method
        ' Purpose: create general report
        ' Output: datatable result
        Public Function CreateGeneralReport() As DataTable
            Try

            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetTotalExpried method
        ' Purpose: Get total expried 
        ' Output: datatable result
        Public Function GetTotalExpired() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_GET_EXPIRED_SER_ITEM"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetTotalExpired = dsData.Tables("tblResult")
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
                        .CommandText = "Ser_spItem_SelExpired"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetTotalExpired = dsData.Tables("tblResult")
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

        ' CreateReportByAcqSourceStatus method
        ' Purpose: create report by Acquire Source and Status
        ' Output: datatable result
        Public Function CreateReportByAcqSourceStatus() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_GET_SOURCE_STATUS_SER_ITEM"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            CreateReportByAcqSourceStatus = dsData.Tables("tblResult")
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
                        .CommandText = "Ser_spItem_SelSourceStatus"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            CreateReportByAcqSourceStatus = dsData.Tables("tblResult")
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

        ' GetTotalIssue method
        ' Purpose: Get total ReceivedCopies and VolumeByLibrary
        ' Output: datatable result
        Public Sub GetTotalIssue(ByRef intTotalID As Integer, ByRef intTotalReceivedCopies As Integer, ByRef intTotalVolumeByLibrary As Integer)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_GET_TOTAL_ISSUE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intTotalID", OracleType.Number)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("intTotalReceivedCopies", OracleType.Number)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("intTotalVolumeByLibrary", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            If Not IsDBNull(.Parameters("intTotalID").Value.ToString) Then
                                intTotalID = CInt(.Parameters("intTotalID").Value.ToString)
                            End If
                            If Not IsDBNull(.Parameters("intTotalReceivedCopies").Value.ToString) Then
                                intTotalReceivedCopies = CInt(.Parameters("intTotalReceivedCopies").Value.ToString)
                            End If
                            If .Parameters("intTotalVolumeByLibrary").Value.ToString Then
                                intTotalVolumeByLibrary = CInt(.Parameters("intTotalVolumeByLibrary").Value.ToString)
                            End If
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ser_spIssue_SelTotalIssue"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intTotalID", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@intTotalReceivedCopies", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@intTotalVolumeByLibrary", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intTotalID = CInt(.Parameters("@intTotalID").Value.ToString)
                            intTotalReceivedCopies = CInt(.Parameters("@intTotalReceivedCopies").Value.ToString)
                            intTotalVolumeByLibrary = CInt(.Parameters("@intTotalVolumeByLibrary").Value.ToString)
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

        ' GetgenIssueItem method
        ' Purpose: Get information genarate of Issue and Item
        ' Output: datatable result
        Public Function GetGenIssueItem(ByVal intAcqSourceID As Integer, ByVal intOnSubscription As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_GET_GEN_ISSUE_ITEM"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intAcqSourceID", OracleType.Number, 4)).Value = intAcqSourceID
                            .Parameters.Add(New OracleParameter("intOnSubscription", OracleType.Number, 4)).Value = intOnSubscription
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetGenIssueItem = dsData.Tables("tblResult")
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
                        .CommandText = "Ser_spItem_SelReport"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intAcqSourceID", SqlDbType.Int)).Value = intAcqSourceID
                            .Parameters.Add(New SqlParameter("@intOnSubscription", SqlDbType.Int)).Value = intOnSubscription
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetGenIssueItem = dsData.Tables("tblResult")
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

        ' GetGenExpriedItem method
        ' Purpose: Get information genarate of expried Item
        ' Output: datatable result
        Public Function GetGenExpriedItem() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_GET_GEN_EXPIRED"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetGenExpriedItem = dsData.Tables("tblResult")
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
                        .CommandText = "Acq_spItem_SelGenExpried"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetGenExpriedItem = dsData.Tables("tblResult")
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

        ' GetAnnualSummaryHolding method
        ' Purpose: Get Annual SummaryHolding
        ' Output: datatable result
        Public Function GetAnnualSummaryHolding(ByVal strIDs As String, ByVal intyears As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_GET_ISSUEINYEARS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strIDs", OracleType.VarChar, 2000)).Value = strIDs
                            .Parameters.Add(New OracleParameter("intYears", OracleType.Number)).Value = intyears
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetAnnualSummaryHolding = dsData.Tables("tblResult")
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
                        .CommandText = "Ser_spIssue_SelInYear"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strIDs", SqlDbType.VarChar)).Value = strIDs
                            .Parameters.Add(New SqlParameter("@intYears", SqlDbType.Int)).Value = intyears
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetAnnualSummaryHolding = dsData.Tables("tblResult")
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

        ' GetVendorToClaim method
        ' Purponse: Get Vendor to Claim
        ' In: IDs
        ' Out: Datatable
        ' Creator: Sondp
        Public Function GetVendorToClaim() As DataTable
            Try
                Call OpenConnection()
                Select Case UCase(strdbserver)
                    Case "SQLSERVER"
                        Try
                            With SqlCommand
                                .CommandText = "Acq_spPO_SelVendorToClaim"
                                .CommandType = CommandType.StoredProcedure
                                .Parameters.Add(New SqlParameter("@strIDs", SqlDbType.VarChar, 500)).Value = strIDs
                                SqlDataAdapter.SelectCommand = SqlCommand
                                SqlDataAdapter.Fill(dsData, "tblResult")
                                GetVendorToClaim = dsData.Tables("tblResult")
                            End With
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            SqlCommand.Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    Case "ORACLE"
                        Try
                            With oracommand
                                .CommandType = CommandType.StoredProcedure
                                .CommandText = "SERIAL.SP_GET_VENDOR_TO_CLAIM"
                                .Parameters.Add(New OracleParameter("strIDs", OracleType.VarChar, 500)).Value = strIDs
                                .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                oraDataAdapter.SelectCommand = oracommand
                                oraDataAdapter.Fill(dsData, "tblResult")
                                GetVendorToClaim = dsData.Tables("tblResult")
                            End With
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            oracommand.Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                End Select
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Call CloseConnection()
        End Function

        ' GetClaimIssueList method
        ' Purpose: Get claim issues
        ' Output: datatable result
        Public Function GetClaimIssueList() As DataTable
            Call OpenConnection()
            Select Case UCase(strDbserver)
                Case "SQLSERVER"
                    With SqlCommand
                        Try
                            .CommandText = "Ser_spGetClaimedItemList"
                            .CommandType = CommandType.StoredProcedure
                            With .Parameters
                                .Add(New SqlParameter("@intVendorID", Int, 4)).Value = intVendorID
                                .Add(New SqlParameter("@strFromDate", SqlDbType.VarChar, 12)).Value = strFromDate
                                .Add(New SqlParameter("@strToDate", SqlDbType.VarChar, 12)).Value = strToDate
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetClaimIssueList = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            dsData.Tables.Remove("tblResult")
                            SqlCommand.Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oracommand
                        Try
                            ' Change SP
                            ' .CommandText = "SERIAL.SP_CLAIM_REVIEW"
                            .CommandText = "SERIAL.SP_SER_GET_CLAIMED_ITEM_LIST"
                            .CommandType = CommandType.StoredProcedure
                            With .Parameters
                                .Add(New OracleParameter("intVendorID", OracleType.Number, 4)).Value = intVendorID
                                .Add(New OracleParameter("strFromDate", OracleType.VarChar, 12)).Value = strFromDate
                                .Add(New OracleParameter("strToDate", OracleType.VarChar, 12)).Value = strToDate
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oracommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetClaimIssueList = dsData.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            oracommand.Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' GetIssueForClaim method
        ' Purpose: Get Issue for claim
        ' In: SelectMode(0, 1), ClaimCycleMode(1, 2, 3), IssueYear, IDs
        ' Output: datatable result
        Public Function GetIssueForClaim() As DataTable
            Call OpenConnection()

            Select Case UCase(strDbserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "Ser_spGetIssueForClaim"
                        With .Parameters
                            .Add(New SqlParameter("@chrSelectMode", SqlDbType.Char)).Value = chrSelectMode
                            .Add(New SqlParameter("@chrClaimCycleMode", SqlDbType.Char, 1)).Value = chrClaimCycleMode
                            .Add(New SqlParameter("@strIssueYear", SqlDbType.VarChar, 4)).Value = strIssueYear
                            .Add(New SqlParameter("@strItemIDs", SqlDbType.VarChar, 200)).Value = strIDs
                            .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                        End With
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetIssueForClaim = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oracommand
                        ' Change SP
                        ' .CommandText = "SERIAL.SP_GET_UNRECEIVEDISSUES"
                        .CommandText = "SERIAL.SP_SER_GET_ISSUES_FOR_CLAIM"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("chrSelectMode", OracleType.Char, 1)).Value = chrSelectMode
                            .Add(New OracleParameter("chrClaimCycleMode", OracleType.Char, 1)).Value = chrClaimCycleMode
                            .Add(New OracleParameter("strIssueYear", OracleType.VarChar, 4)).Value = strIssueYear
                            .Add(New OracleParameter("strItemIDs", OracleType.VarChar, 200)).Value = strIDs
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            oraDataAdapter.SelectCommand = oracommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetIssueForClaim = dsData.Tables("tblResult")
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

        ' Purpose: Get acquisition item in range time
        ' In: some infor
        ' Output: Datatable
        ' Creator: Sondp
        Public Function GenReportByRangeTime(ByVal strFlage As String, Optional ByVal intItemID As Integer = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDbserver)
                Case "SQLSERVER"
                    With SqlCommand
                        Try
                            .CommandText = "Ser_spGetReportInf"
                            .CommandType = CommandType.StoredProcedure
                            With .Parameters
                                .Add(New SqlParameter("@strFlage", SqlDbType.VarChar, 20)).Value = strFlage
                                .Add(New SqlParameter("@strFromDate", SqlDbType.VarChar, 20)).Value = strFromDate
                                .Add(New SqlParameter("@strToDate", SqlDbType.VarChar, 20)).Value = strToDate
                                .Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GenReportByRangeTime = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            SqlCommand.Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oracommand
                        Try
                            .CommandText = "SERIAL.SP_SER_GET_REPORTINF"
                            .CommandType = CommandType.StoredProcedure
                            With .Parameters
                                .Add(New OracleParameter("strFlage", OracleType.VarChar, 20)).Value = strFlage
                                .Add(New OracleParameter("strFromDate", OracleType.VarChar, 20)).Value = strFromDate
                                .Add(New OracleParameter("strToDate", OracleType.VarChar, 20)).Value = strToDate
                                .Add(New OracleParameter("intItemID", OracleType.Number, 4)).Value = intItemID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oracommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GenReportByRangeTime = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            oracommand.Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function GetLastReceivedDate(ByVal lngItemID As Long) As DataTable
            Call OpenConnection()
            Select Case UCase(strDbserver)
                Case "SQLSERVER"
                    With SqlCommand
                        Try
                            .CommandText = "Ser_spGetLastReceivedDate"
                            .CommandType = CommandType.StoredProcedure
                            With .Parameters
                                .Add(New SqlParameter("@lngItemID", SqlDbType.Int)).Value = lngItemID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetLastReceivedDate = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            dsData.Tables.Remove("tblResult")
                            SqlCommand.Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oracommand
                        Try
                            .CommandText = "SERIAL.SP_SER_GET_LAST_RECEIVED_DATE"
                            .CommandType = CommandType.StoredProcedure
                            With .Parameters
                                .Add(New OracleParameter("lngItemID", OracleType.Number, 4)).Value = lngItemID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oracommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetLastReceivedDate = dsData.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            oracommand.Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                Call MyBase.Dispose(isDisposing)
            Finally
                Call Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace