' Name: clsDPatron
' Purpose: allow all action relate Patron
' Creator: Tuanhv
' CreatedDate: 19/08/2004
' Modification History:24/08/2004

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Circulation
    Public Class clsDPatron
        Inherits clsDBase

        ' *****************************************************************************************************
        ' Declare member variables
        ' *****************************************************************************************************
        Private strFullName As String = ""
        Private strLastName As String = ""
        Private strFirstName As String = ""
        Private strMiddleName As String = ""
        Private strDOB As String = ""
        Private strValidDate As String = ""
        Private strExpiredDate As String = ""
        Private intPatronGroupID As Int16 = 0
        Private intStatus As Int16 = 0
        Private tblGetPatronInfor As New DataTable
        Private tblGetPatronGroupName As New DataTable

        Private strWorkplace As String
        Private strTelephone As String
        Private strMobile As String
        Private strEmail As String
        Private intPatronID As Integer
        Private strPatronCode As String
        Private intLockedDays As Integer
        Private strStartedDate As String
        Private strNote As String
        Private strIDs As String = ""
        Private intOutValue As Integer
        Private intUser_ID As Integer
        Private strCreateDate As String
        Private intLocationID As Integer
        Private intMonth As Integer
        Private intYear As Integer
        Private strFromDate As String
        Private strToDate As String
        Private intFilter As Integer




        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        'OutValue property
        Public Property OutValue() As Integer
            Get
                Return intOutValue
            End Get
            Set(ByVal Value As Integer)
                intOutValue = Value
            End Set
        End Property

        'PatronCode property
        Public Property PatronCode() As String
            Get
                Return strPatronCode
            End Get
            Set(ByVal Value As String)
                strPatronCode = Value
            End Set
        End Property
        'IDs property
        Public Property IDs() As String
            Get
                Return strIDs
            End Get
            Set(ByVal Value As String)
                strIDs = Value
            End Set
        End Property

        'LockedDays property
        Public Property LockedDays() As Integer
            Get
                Return intLockedDays
            End Get
            Set(ByVal Value As Integer)
                intLockedDays = Value
            End Set
        End Property

        'StartedDate property
        Public Property StartedDate() As String
            Get
                Return strStartedDate
            End Get
            Set(ByVal Value As String)
                strStartedDate = Value
            End Set
        End Property

        'Note property
        Public Property Note() As String
            Get
                Return strNote
            End Get
            Set(ByVal Value As String)
                strNote = Value
            End Set
        End Property

        ' PatronID property
        Public Property PatronID() As Integer
            Get
                Return intPatronID
            End Get
            Set(ByVal Value As Integer)
                intPatronID = Value
            End Set
        End Property

        ' Email property
        Public Property Email() As String
            Get
                Return strEmail
            End Get
            Set(ByVal Value As String)
                strEmail = Value
            End Set
        End Property

        ' Mobile property
        Public Property Mobile() As String
            Get
                Return strMobile
            End Get
            Set(ByVal Value As String)
                strMobile = Value
            End Set
        End Property

        ' Telephone property
        Public Property Telephone() As String
            Get
                Return strTelephone
            End Get
            Set(ByVal Value As String)
                strTelephone = Value
            End Set
        End Property

        ' Workplace property
        Public Property Workplace() As String
            Get
                Return strWorkplace
            End Get
            Set(ByVal Value As String)
                strWorkplace = Value
            End Set
        End Property

        ' FullName property
        Public Property FullName() As String
            Get
                Return strFullName
            End Get
            Set(ByVal Value As String)
                strFullName = Value
            End Set
        End Property

        ' FirstName property
        Public Property FirstName() As String
            Get
                Return strFirstName
            End Get
            Set(ByVal Value As String)
                strFirstName = Value
            End Set
        End Property

        ' LastName property
        Public Property LastName() As String
            Get
                Return strLastName
            End Get
            Set(ByVal Value As String)
                strLastName = Value
            End Set
        End Property

        ' MiddleName property
        Public Property MiddleName() As String
            Get
                Return strMiddleName
            End Get
            Set(ByVal Value As String)
                strMiddleName = Value
            End Set
        End Property

        ' DOB property
        Public Property DOB() As String
            Get
                Return strDOB
            End Get
            Set(ByVal Value As String)
                strDOB = Value
            End Set
        End Property

        ' ValidDate property
        Public Property ValidDate() As String
            Get
                Return strValidDate
            End Get
            Set(ByVal Value As String)
                strValidDate = Value
            End Set
        End Property

        ' ExpiredDate property
        Public Property ExpiredDate() As String
            Get
                Return strExpiredDate
            End Get
            Set(ByVal Value As String)
                strExpiredDate = Value
            End Set
        End Property

        ' PatronGroupID property
        Public Property PatronGroupID() As Int16
            Get
                Return intPatronGroupID
            End Get
            Set(ByVal Value As Int16)
                intPatronGroupID = Value
            End Set
        End Property

        ' Status property
        Public Property Status() As Int16
            Get
                Return intStatus
            End Get
            Set(ByVal Value As Int16)
                intStatus = Value
            End Set
        End Property

        ' User_ID property
        Public Property User_ID() As Integer
            Get
                Return intUser_ID
            End Get
            Set(ByVal Value As Integer)
                intUser_ID = Value
            End Set
        End Property
        Public Property CreateDate() As String
            Get
                Return strCreateDate
            End Get
            Set(ByVal Value As String)
                strCreateDate = Value
            End Set
        End Property
        'DepartmentID property
        Public Property LocationID() As Integer
            Get
                Return intLocationID
            End Get
            Set(ByVal Value As Integer)
                intLocationID = Value
            End Set
        End Property
        ' Month property
        Public Property Month() As Integer
            Get
                Return intMonth
            End Get
            Set(ByVal Value As Integer)
                intMonth = Value
            End Set
        End Property
        ' Year Property
        Public Property Year() As Integer
            Get
                Return intYear
            End Get
            Set(ByVal Value As Integer)
                intYear = Value
            End Set
        End Property
        ' FromDate
        Public Property FromDate() As String
            Get
                Return strFromDate
            End Get
            Set(ByVal Value As String)
                strFromDate = Value
            End Set
        End Property
        ' ToDate
        Public Property ToDate() As String
            Get
                Return strToDate
            End Get
            Set(ByVal Value As String)
                strToDate = Value
            End Set
        End Property
        ' Filter property
        Public Property Filter() As Integer
            Get
                Return intFilter
            End Get
            Set(ByVal Value As Integer)
                intFilter = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' AddPatron method
        ' Purpose: Addnew PatronRecord
        ' Input: some main infor of Patron
        Public Sub AddPatron()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_PATRON_INSERT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strPatronCode", OracleType.VarChar, 20)).Value = strPatronCode
                            .Parameters.Add(New OracleParameter("strValidDate", OracleType.VarChar, 30)).Value = strValidDate
                            .Parameters.Add(New OracleParameter("strExpiredDate", OracleType.VarChar, 30)).Value = strExpiredDate
                            .Parameters.Add(New OracleParameter("strFirstName", OracleType.VarChar, 30)).Value = strFirstName
                            .Parameters.Add(New OracleParameter("strLastName", OracleType.VarChar, 30)).Value = strLastName
                            .Parameters.Add(New OracleParameter("strMiddleName", OracleType.VarChar, 30)).Value = strMiddleName
                            .Parameters.Add(New OracleParameter("intPatronGroupID", OracleType.Number)).Value = intPatronGroupID
                            .Parameters.Add(New OracleParameter("strWorkplace", OracleType.VarChar, 30)).Value = strWorkplace
                            .Parameters.Add(New OracleParameter("strTelephone", OracleType.VarChar, 30)).Value = strTelephone
                            .Parameters.Add(New OracleParameter("strEmail", OracleType.VarChar, 30)).Value = strEmail
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            intErrorCode = ex.Code
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatronInsert"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar)).Value = strPatronCode
                            .Parameters.Add(New SqlParameter("@strValidDate", SqlDbType.VarChar)).Value = strValidDate
                            .Parameters.Add(New SqlParameter("@strExpiredDate", SqlDbType.VarChar)).Value = strExpiredDate
                            .Parameters.Add(New SqlParameter("@strFirstName", SqlDbType.NVarChar)).Value = strFirstName
                            .Parameters.Add(New SqlParameter("@strLastName", SqlDbType.NVarChar)).Value = strLastName
                            .Parameters.Add(New SqlParameter("@strMiddleName", SqlDbType.NVarChar)).Value = strMiddleName
                            .Parameters.Add(New SqlParameter("@intPatronGroupID", SqlDbType.Int)).Value = intPatronGroupID
                            .Parameters.Add(New SqlParameter("@strWorkplace", SqlDbType.VarChar)).Value = strWorkplace
                            .Parameters.Add(New SqlParameter("@strTelephone", SqlDbType.VarChar)).Value = strTelephone
                            .Parameters.Add(New SqlParameter("@strEmail", SqlDbType.VarChar)).Value = strEmail
                            .ExecuteNonQuery()
                        Catch ex As SqlException
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub
        'Purpose: Insert into regularity_out
        'Creater: Tuannv
        Public Sub AddRegularity_out()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_INSERT_REGULARITY_OUT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            '.Parameters.Add(New OracleParameter("intID", OracleType.Number)).Value = intID
                            .Parameters.Add(New OracleParameter("strCreateDate", OracleType.VarChar, 30)).Value = strCreateDate
                            .Parameters.Add(New OracleParameter("strPatronCode", OracleType.VarChar, 30)).Value = strPatronCode
                            .Parameters.Add(New OracleParameter("intLocationID", OracleType.Number)).Value = intLocationID
                            .Parameters.Add(New OracleParameter("strNote", OracleType.VarChar, 30)).Value = strNote
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            intErrorCode = ex.Code
                            strErrorMsg = ex.Message.ToString

                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spRegularityOut_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            '.Parameters.Add(New SqlParameter("@strCreateDate", SqlDbType.VarChar)).Value = strCreateDate
                            .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar)).Value = strPatronCode
                            .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.VarChar)).Value = intLocationID
                            .Parameters.Add(New SqlParameter("@strNote", SqlDbType.NVarChar)).Value = strNote
                            .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.VarChar)).Value = intUserID
                            .ExecuteNonQuery()
                        Catch ex As SqlException
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub
        ' GetPatronInfor method
        ' Purpose: Get information of the selected Patron
        ' Input: Some main information of patron
        ' Output: datatable result
        Public Function GetPatronInfor(Optional ByVal strFixDueDate As String = "") As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_GET_PATRON_INFOR"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("strFullName", OracleType.VarChar, 200)).Value = strFullName
                        .Parameters.Add(New OracleParameter("strFixDueDate", OracleType.VarChar, 200)).Value = strFixDueDate
                        .Parameters.Add(New OracleParameter("strPatronCode", OracleType.VarChar, 200)).Value = strPatronCode
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblGetPatronInfor")
                            GetPatronInfor = dsData.Tables("tblGetPatronInfor")
                            dsData.Tables.Remove("tblGetPatronInfor")
                        Catch ex As OracleException
                            intErrorCode = ex.Code
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatron_SelInforByFullName"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strFullName", SqlDbType.NVarChar)).Value = strFullName
                        .Parameters.Add(New SqlParameter("@strFixDueDate", SqlDbType.NVarChar)).Value = strFixDueDate
                        .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar)).Value = strPatronCode
                        .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblGetPatronInfor")
                            GetPatronInfor = dsData.Tables("tblGetPatronInfor")
                            dsData.Tables.Remove("tblGetPatronInfor")
                        Catch ex As SqlException
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function GetPatron() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spPatron_SelInforPatron"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strFullName", SqlDbType.NVarChar, 150)).Value = strFullName
                        .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 30)).Value = strPatronCode
                        .Parameters.Add(New SqlParameter("@intPatronGroup", SqlDbType.Int)).Value = intPatronGroupID
                        .Parameters.Add(New SqlParameter("@strEmail", SqlDbType.VarChar, 50)).Value = strEmail
                        .Parameters.Add(New SqlParameter("@strPhone", SqlDbType.VarChar, 50)).Value = strTelephone
                        .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblGetPatronInfor")
                            GetPatron = dsData.Tables("tblGetPatronInfor")
                            dsData.Tables.Remove("tblGetPatronInfor")
                        Catch ex As SqlException
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        'Purpose: get PatronMax
        'Input: FromDate, ToDate, LocationID
        'Created by: Tuannv
        Public Function GetPatronMax() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_GET_PATRON_MAX"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("strFromDate", OracleType.VarChar, 50)).Value = strFromDate
                        .Parameters.Add(New OracleParameter("strToDate", OracleType.VarChar, 50)).Value = strToDate
                        .Parameters.Add(New OracleParameter("intLocationID", OracleType.Number)).Value = intLocationID
                        .Parameters.Add(New OracleParameter("intTotal", OracleType.Number)).Value = intFilter
                        .Parameters.Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUser_ID
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblGetPatronMax")
                            GetPatronMax = dsData.Tables("tblGetPatronMax")
                            dsData.Tables.Remove("tblGetPatronMax")
                        Catch ex As OracleException
                            intErrorCode = ex.Code
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spRegularityOut_SelPatronMax"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strFromDate", SqlDbType.VarChar, 30)).Value = strFromDate
                        .Parameters.Add(New SqlParameter("@strToDate", SqlDbType.VarChar, 30)).Value = strToDate
                        .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUser_ID
                        .Parameters.Add(New SqlParameter("@intTotal", SqlDbType.Int)).Value = intFilter
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblGetPatronMax")
                            GetPatronMax = dsData.Tables("tblGetPatronMax")
                            dsData.Tables.Remove("tblGetPatronMax")
                        Catch ex As SqlException
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function GetPatronMaxDetail() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spRegularityOut_SelPatronMax_Detail"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strFromDate", SqlDbType.VarChar, 30)).Value = strFromDate
                        .Parameters.Add(New SqlParameter("@strToDate", SqlDbType.VarChar, 30)).Value = strToDate
                        .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUser_ID
                        .Parameters.Add(New SqlParameter("@intTotal", SqlDbType.Int)).Value = intFilter
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblGetPatronMax")
                            GetPatronMaxDetail = dsData.Tables("tblGetPatronMax")
                            dsData.Tables.Remove("tblGetPatronMax")
                        Catch ex As SqlException
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function
        'Purpose: get PatronTotal
        'Input: Year, Month, LocationID
        'Output: Datatabse
        'Created by: Tuannv
        Public Function GetPatronTotal() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_GET_PATRON_TOTAL"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("intMonth", OracleType.Number)).Value = intMonth
                        .Parameters.Add(New OracleParameter("intYear", OracleType.Number)).Value = intYear
                        .Parameters.Add(New OracleParameter("intLocationID", OracleType.Number)).Value = intLocationID
                        .Parameters.Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUser_ID
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblGetPatronTotal")
                            GetPatronTotal = dsData.Tables("tblGetPatronTotal")
                            dsData.Tables.Remove("tblGetPatronTotal")
                        Catch ex As OracleException
                            intErrorCode = ex.Code
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spRegularityOut_SelPatronTotal"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intMonth", SqlDbType.Int)).Value = intMonth
                        .Parameters.Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = intYear
                        .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUser_ID
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblGetPatronTotal")
                            GetPatronTotal = dsData.Tables("tblGetPatronTotal")
                            dsData.Tables.Remove("tblGetPatronTotal")
                        Catch ex As SqlException
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function
        Public Function GetPatronTotalDetail() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spRegularityOut_SelPatronTotal_Detail"
                        .CommandType = CommandType.StoredProcedure
                        '.Parameters.Add(New SqlParameter("@intMonth", SqlDbType.Int)).Value = intMonth
                        '.Parameters.Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = intYear
                        .Parameters.Add(New SqlParameter("@strFromDate", SqlDbType.VarChar, 30)).Value = strFromDate
                        .Parameters.Add(New SqlParameter("@strToDate", SqlDbType.VarChar, 30)).Value = strToDate
                        .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUser_ID
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblGetPatronTotal")
                            GetPatronTotalDetail = dsData.Tables("tblGetPatronTotal")
                            dsData.Tables.Remove("tblGetPatronTotal")
                        Catch ex As SqlException
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function
        ' GetLocationID method
        ' Purpose: Get information departmentID
        ' Input: UserID
        ' Output: datatable result
        ' Created by: Tuannv
        Public Function GetLocationID(Optional ByVal intSubsystemID As Integer = 1) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "COMMON.SP_GETUSERLOCATIONS"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUser_ID
                        .Parameters.Add(New OracleParameter("intSubsystemID", OracleType.Number)).Value = intSubsystemID
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblGetLocationID")
                            GetLocationID = dsData.Tables("tblGetLocationID")
                            dsData.Tables.Remove("tblGetLocationID")
                        Catch ex As OracleException
                            intErrorCode = ex.Code
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Sys_spUser_Location_Sel"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.NVarChar)).Value = intUser_ID
                        .Parameters.Add(New SqlParameter("@intSubsystemID", SqlDbType.NVarChar)).Value = intSubsystemID
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblGetLocationID")
                            GetLocationID = dsData.Tables("tblGetLocationID")
                            dsData.Tables.Remove("tblGetLocationID")
                        Catch ex As SqlException
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function


        ' GetPatron method
        ' Purpose: Get information PatronID
        ' Input: code
        ' Output: datatable result
        ' Creater: Tuannv
        Public Function GetPatronID() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_GET_PATRON_ID"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("strPatronCode", OracleType.VarChar, 50)).Value = strPatronCode
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblGetPatronID")
                            GetPatronID = dsData.Tables("tblGetPatronID")
                            dsData.Tables.Remove("tblGetPatronID")
                        Catch ex As OracleException
                            intErrorCode = ex.Code
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "SP_GET_PATRON_ID"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.NVarChar)).Value = strPatronCode
                        .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar)).Value = strPatronCode
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblGetPatronID")
                            GetPatronID = dsData.Tables("tblGetPatronID")
                            dsData.Tables.Remove("tblGetPatronID")
                        Catch ex As SqlException
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function GetPatronByPatronCode() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spPatron_GetPatronByPatronCode"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 20)).Value = strPatronCode
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetPatronByPatronCode = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As SqlException
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' GetPatronInLib method
        ' Purpose: Get information of Patron in Libary
        ' Output: datatable result
        Public Function GetPatronInLib() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_GET_PATRON_INLIB"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetPatronInLib = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As OracleException
                            intErrorCode = ex.Code
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatron_InLib"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetPatronInLib = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As SqlException
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' GetPatronGroup method
        ' Purpose: get information patron group
        ' Ouput: datatable result
        Public Function GetPatronGroup() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_CIR_PATRON_GROUP_SELECT"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblGetPatronNameGroup")
                            GetPatronGroup = dsData.Tables("tblGetPatronNameGroup")
                            dsData.Tables.Remove("tblGetPatronNameGroup")
                        Catch ex As OracleException
                            intErrorCode = ex.Code
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "SP_CIR_PATRON_GROUP_SELECT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblGetPatronNameGroup")
                            GetPatronGroup = dsData.Tables("tblGetPatronNameGroup")
                            dsData.Tables.Remove("tblGetPatronNameGroup")
                            'Catch ex As SqlException
                            '    intErrorCode = ex.Number
                            '    strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function CreditPatronDownLoadFile(ByVal intIsDownLoad As Boolean) As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    CreditPatronDownLoadFile = 0
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_tblPatronDownLoadFile_Credit"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intPatronGroupID", SqlDbType.Int)).Value = intPatronGroupID
                        .Parameters.Add(New SqlParameter("@intIsDownload", SqlDbType.Bit)).Value = intIsDownLoad
                        Try
                            .ExecuteNonQuery()
                            CreditPatronDownLoadFile = 1
                        Catch ex As SqlException
                            CreditPatronDownLoadFile = 0
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function


        Public Function GetIsDownLoad_ByPatronGroup() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    GetIsDownLoad_ByPatronGroup = -1
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_tblPatronDownLoadFile_GetIsDownLoad_ByPatronGroup"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intPatronGroupID", SqlDbType.Int)).Value = intPatronGroupID
                        .Parameters.Add(New SqlParameter("@intResult", SqlDbType.Int)).Direction = ParameterDirection.Output
                        Try
                            .ExecuteNonQuery()
                            GetIsDownLoad_ByPatronGroup = .Parameters("@intResult").Value
                        Catch ex As SqlException
                            GetIsDownLoad_ByPatronGroup = -1
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function GetIsDownLoad_ByPatronCode() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    GetIsDownLoad_ByPatronCode = -1
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_tblPatronDownLoadFile_GetIsDownLoad_ByPatronCode"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 20)).Value = strPatronCode
                        .Parameters.Add(New SqlParameter("@intResult", SqlDbType.Int)).Direction = ParameterDirection.Output
                        Try
                            .ExecuteNonQuery()
                            GetIsDownLoad_ByPatronCode = .Parameters("@intResult").Value
                        Catch ex As SqlException
                            GetIsDownLoad_ByPatronCode = -1
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' GetLockedPatrons method
        ' Purpose: get information of LockedCardPatron
        ' Input:
        ' Ouput: datatable result
        Public Function GetLockedPatrons(Optional ByVal strPatronCode As String = "", Optional ByVal strLockDateTo As String = "", Optional ByVal strLockDateFrom As String = "") As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_GET_LOCKEDPATRONS"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("strPatronCode", OracleType.VarChar, 50)).Value = strPatronCode
                        .Parameters.Add(New OracleParameter("strLockDateTo", OracleType.VarChar, 50)).Value = strLockDateTo
                        .Parameters.Add(New OracleParameter("strLockDateFrom", OracleType.VarChar, 50)).Value = strLockDateFrom
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblGetLockedPatrons")
                            GetLockedPatrons = dsData.Tables("tblGetLockedPatrons")
                            dsData.Tables.Remove("tblGetLockedPatrons")
                        Catch ex As OracleException
                            intErrorCode = ex.Code
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spPatronLock_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 50)).Value = strPatronCode
                            .Parameters.Add(New SqlParameter("@strLockDateTo", SqlDbType.VarChar, 30)).Value = strLockDateTo
                            .Parameters.Add(New SqlParameter("@strLockDateFrom", SqlDbType.VarChar, 30)).Value = strLockDateFrom
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblGetLockedPatrons")
                            GetLockedPatrons = dsData.Tables("tblGetLockedPatrons")
                            dsData.Tables.Remove("tblGetLockedPatrons")
                        Catch ex As SqlException
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' LockPatronCard method
        ' Purpose: lock PatronCard because of some reason
        ' Input: strPatronCode, intLockDays
        Public Sub LockPatronCard(Optional ByVal intType As Integer = 0)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_LOCK_PATRON_CARD"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strPatronCode", OracleType.VarChar, 50)).Value = strPatronCode
                            .Parameters.Add(New OracleParameter("intLockedDays", OracleType.Number)).Value = intLockedDays
                            .Parameters.Add(New OracleParameter("strStartedDate", OracleType.VarChar, 30)).Value = strStartedDate
                            .Parameters.Add(New OracleParameter("strNote", OracleType.VarChar, 200)).Value = strNote
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            intErrorCode = ex.Code
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spPatronLock_InsOrUpdate"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 50)).Value = strPatronCode
                            .Parameters.Add(New SqlParameter("@intLockedDays", SqlDbType.Int)).Value = intLockedDays
                            .Parameters.Add(New SqlParameter("@strStartedDate", SqlDbType.VarChar, 30)).Value = strStartedDate
                            .Parameters.Add(New SqlParameter("@strNote", SqlDbType.NVarChar, 200)).Value = strNote
                            .Parameters.Add(New SqlParameter("@intType", SqlDbType.Int)).Value = intType
                            .ExecuteNonQuery()
                        Catch ex As SqlException
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' UnLockPatronCard method
        ' Purpose: Unlock PatronCard because of some reason
        ' Input: PatronCode
        Public Function UnLockPatronCard(Optional intAccept As Integer = 0) As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_UNLOCK_PATRON_CARD"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strPatronCode", OracleType.VarChar, 500)).Value = strPatronCode
                            '.ExecuteNonQuery()
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            Dim tblResult As DataTable = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")

                            UnLockPatronCard = tblResult.Rows(0).Item(0) & ""
                        Catch ex As OracleException
                            intErrorCode = ex.Code
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spPatronCard_Unlock"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 500)).Value = strPatronCode
                            .Parameters.Add(New SqlParameter("@intAccept", SqlDbType.Int)).Value = intAccept
                            '.ExecuteNonQuery()
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            Dim tblResult As DataTable = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")

                            UnLockPatronCard = tblResult.Rows(0).Item(0) & ""
                        Catch ex As SqlException
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function
        ' Delete PatronPhotocopy
        ' Purpose: Unlock PatronCard because of some reason
        ' Input: PatronCode
        Public Sub DelPtronPhotocopy()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_DEL_PATRON_PHOTOCOPY"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strIDs", OracleType.VarChar, 500)).Value = strIDs
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            intErrorCode = ex.Code
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "SP_DEL_PATRON_PHOTOCOPY"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 500)).Value = strPatronCode
                            .ExecuteNonQuery()
                        Catch ex As SqlException
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' RenewPatronCard method
        ' Purpose: Renew for expired patron card
        ' Input: PatronCode, NewExpiredDate
        Public Sub RenewPatronCard(ByVal strNewDate As String)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        ' Change SP
                        ' .CommandText = "CIRCULATION.SP_RENEW_PATRONCARD"
                        .CommandText = "CIRCULATION.SP_CIR_RENEW_PATRONCARD"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strPatronCode", OracleType.VarChar, 30)).Value = strPatronCode
                            .Parameters.Add(New OracleParameter("strNewDate", OracleType.VarChar, 30)).Value = strNewDate
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            intErrorCode = ex.Code
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spPatron_UpdToRenewCard"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar)).Value = strPatronCode
                            .Parameters.Add(New SqlParameter("@strNewDate", SqlDbType.VarChar)).Value = strNewDate
                            .ExecuteNonQuery()
                        Catch ex As SqlException
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                Call MyBase.Dispose(isDisposing)
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace