' Name: clsDILLInRequestCollection
' Purpose: ILL In Request Collection
' Creator: Sondp
' Created Date: 25/11/2004
' Modification History:

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.ILL
    Public Class clsDILLInRequestCollection
        Inherits clsDBase

        ' ***********************************************************************************************
        ' Declare Private variables
        ' ***********************************************************************************************

        Private strRequestIDs As String
        Private intStatusID As Integer
        Private strLibIDs As String
        Private intTimeMode As Int16
        Private strTimeFrom As String
        Private strTimeTo As String
        Private strTitle As String
        Private strAuthor As String
        Private strPatronName As String
        Private strPatronCode As String
        Private intDocType As Int16

        ' ***********************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' ***********************************************************************************************

        ' RequestIDs property
        Public Property RequestIDs() As String
            Get
                Return strRequestIDs
            End Get
            Set(ByVal Value As String)
                strRequestIDs = Value
            End Set
        End Property

        ' StatusID property
        Public Property StatusID() As Integer
            Get
                Return intStatusID
            End Get
            Set(ByVal Value As Integer)
                intStatusID = Value
            End Set
        End Property

        ' LibIDs property
        Public Property LibIDs() As String
            Get
                Return strLibIDs
            End Get
            Set(ByVal Value As String)
                strLibIDs = Value
            End Set
        End Property

        ' TimeMode property
        Public Property TimeMode() As Int16
            Get
                Return intTimeMode
            End Get
            Set(ByVal Value As Int16)
                intTimeMode = Value
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

        ' Title property
        Public Property Title() As String
            Get
                Return strTitle
            End Get
            Set(ByVal Value As String)
                strTitle = Value
            End Set
        End Property

        ' Author property
        Public Property Author() As String
            Get
                Return strAuthor
            End Get
            Set(ByVal Value As String)
                strAuthor = Value
            End Set
        End Property

        ' PatronName property
        Public Property PatronName() As String
            Get
                Return strPatronName
            End Get
            Set(ByVal Value As String)
                strPatronName = Value
            End Set
        End Property

        ' PatronCode property
        Public Property PatronCode() As String
            Get
                Return strPatronCode
            End Get
            Set(ByVal Value As String)
                strPatronCode = Value
            End Set
        End Property

        ' DocType property
        Public Property DocType() As Int16
            Get
                Return intDocType
            End Get
            Set(ByVal Value As Int16)
                intDocType = Value
            End Set
        End Property

        ' ***********************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' ***********************************************************************************************
        Public Function FilterIRList() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_GET_FILTER_ILLINREQUESTS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strLibIDs", OracleType.VarChar, 500)).Value = strLibIDs
                            .Parameters.Add(New OracleParameter("intTimeMode", OracleType.Number)).Value = intTimeMode
                            .Parameters.Add(New OracleParameter("strTimeFrom", OracleType.VarChar, 30)).Value = strTimeFrom
                            .Parameters.Add(New OracleParameter("strTimeTo", OracleType.VarChar, 30)).Value = strTimeTo
                            .Parameters.Add(New OracleParameter("strTitle", OracleType.VarChar, 400)).Value = strTitle
                            .Parameters.Add(New OracleParameter("strAuthor", OracleType.VarChar, 30)).Value = strAuthor
                            .Parameters.Add(New OracleParameter("strPatronName", OracleType.VarChar, 30)).Value = strPatronName
                            .Parameters.Add(New OracleParameter("strPatronCode", OracleType.VarChar, 20)).Value = strPatronCode
                            .Parameters.Add(New OracleParameter("intDocType", OracleType.Number)).Value = intDocType
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            FilterIRList = dsData.Tables("tblResult")
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
                        .CommandText = "Ill_spRequestItem_SelFilter"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strLibIDs", SqlDbType.VarChar, 500)).Value = strLibIDs
                            .Parameters.Add(New SqlParameter("@intTimeMode", SqlDbType.Int)).Value = intTimeMode
                            .Parameters.Add(New SqlParameter("@strTimeFrom", SqlDbType.VarChar, 30)).Value = strTimeFrom
                            .Parameters.Add(New SqlParameter("@strTimeTo", SqlDbType.VarChar, 30)).Value = strTimeTo
                            .Parameters.Add(New SqlParameter("@strTitle", SqlDbType.NVarChar, 400)).Value = strTitle
                            .Parameters.Add(New SqlParameter("@strAuthor", SqlDbType.NVarChar, 30)).Value = strAuthor
                            .Parameters.Add(New SqlParameter("@strPatronName", SqlDbType.NVarChar, 30)).Value = strPatronName
                            .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 20)).Value = strPatronCode
                            .Parameters.Add(New SqlParameter("@intDocType", SqlDbType.Int)).Value = intDocType
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            FilterIRList = dsData.Tables("tblResult")
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

        Public Function GetIRList() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_GET_ILL_IN_REQUESTS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intStatusID", OracleType.Number)).Value = intStatusID
                            .Parameters.Add(New OracleParameter("strRequestIDs", OracleType.VarChar, 1000)).Value = strRequestIDs
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetIRList = dsData.Tables("tblResult")
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
                        .CommandText = "Ill_spInComingRequests_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intStatusID", SqlDbType.Int)).Value = intStatusID
                            .Parameters.Add(New SqlParameter("@strRequestIDs", SqlDbType.VarChar, 1000)).Value = strRequestIDs
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetIRList = dsData.Tables("tblResult")
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

        ' Purpose: Report all process
        ' Input: intSelectMode (1, 2, 3)
        ' Output: Datatable
        ' Creator: Sondp
        Public Function CreateGeneralReport(ByVal intSelectMode As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spInComingRequests_SelGenerateReport"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intSelectMode", SqlDbType.Int)).Value = intSelectMode
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            CreateGeneralReport = dsData.Tables("tblResult")
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
                        .CommandText = "ILL.SP_ILL_INGENERATEREPORT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intSelectMode", OracleType.Number)).Value = intSelectMode
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            CreateGeneralReport = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch oraClientEx As OracleException
                            strErrorMsg = oraClientEx.Message.ToString
                            intErrorCode = oraClientEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose: Report not serviced request
        ' Input: 
        ' Output: 
        ' Creator: lent  8-12-04
        Public Function CreateDeniedIRReport() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_GET_ILL_ID_INCOMING"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            CreateDeniedIRReport = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "ILLsplIncomingRequestDenied_SelIdComing"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            CreateDeniedIRReport = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose: Report incomming serviced request
        ' Input: intSelectMode (0, 1, 2, 3)
        ' Output: Datable
        ' Creator: Sondp
        Public Function CreateServReport(ByVal intSelectMode As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spInComingRequests_SelReport"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intSelectMode", SqlDbType.Int)).Value = intSelectMode
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            CreateServReport = dsData.Tables("tblResult")
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
                        .CommandText = "ILL.SP_ILL_GET_INSERREPORT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intSelectMode", OracleType.Number)).Value = intSelectMode
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            CreateServReport = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch oraClientEx As OracleException
                            strErrorMsg = oraClientEx.Message.ToString
                            intErrorCode = oraClientEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' GetILLInRequestProcess
        ' Purpose: Get the incoming ill request processing
        ' Output: datatable result
        Public Function GetILLInRequestProcess(ByRef intNumOfReq As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_GET_ILL_IN_REQUEST_PROCESS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("intNumOfReqProcessing", OracleType.Number)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetILLInRequestProcess = dsData.Tables("tblResult")
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
                        .CommandText = "Ill_spInComingRequests_SelInProcess"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intNumOfReqProcessing", SqlDbType.Int)).Direction = ParameterDirection.Output
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetILLInRequestProcess = dsData.Tables("tblResult")
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

        ' Purpose: get reason code from table Ill_responses
        ' Output: result table
        ' Creator: lent  8-12-04
        Public Function GetIllReasonCode() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_GET_ILL_REASONCODE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetIllReasonCode = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spRespond_SelResonCode"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetIllReasonCode = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose: Generate suite action of in request
        ' Input: 
        ' Output: 
        ' Creator: 
        Public Function GenAction() As Object
            Try
                Call OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                    Case "ORACLE"
                End Select
                Call CloseConnection()
            Catch ex As Exception
                strerrormsg = ex.Message
            End Try
        End Function

        ' Method: Dispose
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                Call MyBase.Dispose(isDisposing)
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace