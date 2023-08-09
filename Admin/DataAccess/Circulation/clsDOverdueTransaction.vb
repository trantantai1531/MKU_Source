' Name: clsDOverdueTransaction
' Purpose: allow manage OverdueTransaction
' Creator: Oanhtn
' CreatedDate: 16/08/2004
' Modification History:
'   +)27/8/2004: by Sondp, create function GetOverdueList, function GetOverDuePatron
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Circulation
    Public Class clsDOverdueTransaction
        Inherits clsDBase

        ' *****************************************************************************************************
        ' Declare member variables
        ' *****************************************************************************************************

        Private strPatronIDs As String
        Private strEmail As String
        Private strPatronCode As String
        Private intOverdueDays As Integer = 0
        Private intOverdueTemplateID As Int16 = 0
        Private strSelectMode As String = "ALL"
        Public strLogic As String
        Public intDueTime As Integer = 0

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' PatronIDs property
        Public Property PatronIDs() As String
            Get
                Return strPatronIDs
            End Get
            Set(ByVal Value As String)
                strPatronIDs = Value
            End Set
        End Property


        ' PatronID property
        Public Property PatronCode() As String
            Get
                Return strPatronCode
            End Get
            Set(ByVal Value As String)
                strPatronCode = Value
            End Set
        End Property
        ' PatronID property
        Public Property Email() As String
            Get
                Return strEmail
            End Get
            Set(ByVal Value As String)
                strEmail = Value
            End Set
        End Property

        ' OverdueDays property
        Public Property OverdueDays() As Integer
            Get
                Return intOverdueDays
            End Get
            Set(ByVal Value As Integer)
                intOverdueDays = Value
            End Set
        End Property

        ' OverdueTemplateID property
        Public Property OverdueTemplateID() As Int16
            Get
                Return intOverdueTemplateID
            End Get
            Set(ByVal Value As Int16)
                intOverdueTemplateID = Value
            End Set
        End Property

        'Select Mode property
        Public Property SelectMode() As String
            Get
                Return (strSelectMode)
            End Get
            Set(ByVal Value As String)
                strSelectMode = Value
            End Set
        End Property

        ' Logic Select property
        Public Property Logic() As String
            Get
                Return (strLogic)
            End Get
            Set(ByVal Value As String)
                strLogic = Value
            End Set
        End Property

        'DueTime property
        Public Property DueTime() As Integer
            Get
                Return (intDueTime)
            End Get
            Set(ByVal Value As Integer)
                intDueTime = Value
            End Set
        End Property


        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' GetOverdueList method
        ' Purpose: get list of OverdueTransaction
        ' Input: UserID, ID of overdue patron
        ' Output: datatable result
        Public Function GetOverdueList() As DataTable
            OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spLoan_SelOverDueList"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strPatronIDs", SqlDbType.VarChar, 1000)).Value = strPatronIDs
                        End With
                        Try
                            .ExecuteNonQuery()
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsdata, "tblResult")
                            GetOverdueList = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message
                            interrorcode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    Try
                        With oracommand
                            .CommandText = "CIRCULATION.SP_CIR_OVERDUELIST_SEL"
                            .CommandType = CommandType.StoredProcedure
                            With .Parameters
                                .Add(New OracleParameter("strPatronIDs", OracleType.VarChar, 1000)).Value = strPatronIDs
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                        End With
                        oraDataAdapter.SelectCommand = OraCommand
                        oraDataAdapter.Fill(dsdata, "tblResult")
                        GetOverdueList = dsdata.Tables("tblResult")
                        dsdata.Tables.Remove("tblResult")
                    Catch ex As OracleException
                        strErrorMsg = ex.Message
                        intErrorCode = ex.Code
                    Finally
                    End Try
            End Select
            CloseConnection()
        End Function

        ' GetOverdueList method
        ' Purpose: get list of OverdueTransaction depend on UserID
        ' Input: UserID, ID of overdue patron
        ' Output: datatable result
        Public Function GetOverdueListAuthority(Optional ByVal intFacultyID As Integer = 0, Optional ByVal intPatronGroupID As Integer = 0) As DataTable
            OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spLoan_SelOverDueListInfor"
                        ' .CommandText = "SP_CIR_OVERDUELIST_SEL_AUTHORITY"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                            .Add(New SqlParameter("@strPatronIDs", SqlDbType.VarChar, 1000)).Value = strPatronIDs
                            .Add(New SqlParameter("@intFacultyID", SqlDbType.Int)).Value = intFacultyID
                            .Add(New SqlParameter("@intPatronGroupID", SqlDbType.Int)).Value = intPatronGroupID
                        End With
                        Try
                            .ExecuteNonQuery()
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetOverdueListAuthority = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    Try
                        With oraCommand
                            .CommandText = "CIRCULATION.SP_CIR_OVERDUELIST_GETINFOR"
                            ' .CommandText = "CIRCULATION.SP_CIR_OVERDUELIST_SEL_AUTHORITY"
                            .CommandType = CommandType.StoredProcedure
                            With .Parameters
                                .Add(New OracleParameter("intUserID", OracleType.Number, 4)).Value = intUserID
                                .Add(New OracleParameter("strPatronIDs", OracleType.VarChar, 1000)).Value = strPatronIDs
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                        End With
                        oraDataAdapter.SelectCommand = oraCommand
                        oraDataAdapter.Fill(dsData, "tblResult")
                        GetOverdueListAuthority = dsData.Tables("tblResult")
                        dsData.Tables.Remove("tblResult")
                    Catch ex As OracleException
                        strErrorMsg = ex.Message
                        intErrorCode = ex.Code
                    Finally
                    End Try
            End Select
            CloseConnection()
        End Function

        ' GetOverduePatron method
        ' Purpose: Get Overdue Patron to Send mail or Print complaint report
        ' Input: some infor
        Public Function GetOverduePatron(Optional strFullName As String = "", Optional intPatronGroupID As Integer = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spLoan_SelOverDuePatron"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strModeSelect", SqlDbType.VarChar, 10)).Value = strSelectMode
                            .Add(New SqlParameter("@strLogic", SqlDbType.VarChar, 10)).Value = strLogic
                            .Add(New SqlParameter("@intDueTime", SqlDbType.Int)).Value = intDueTime
                            .Add(New SqlParameter("@strPatronIDs", SqlDbType.VarChar, 2000)).Value = strPatronIDs
                            .Add(New SqlParameter("@strFullName", SqlDbType.NVarChar, 255)).Value = strFullName
                            .Add(New SqlParameter("@intPatronGroup", SqlDbType.Int)).Value = intPatronGroupID
                            .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                        End With
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblOVERDUEPATRON")
                            GetOverduePatron = dsData.Tables("tblOVERDUEPATRON")
                            dsData.Tables.Remove("tblOVERDUEPATRON")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_CIR_OVERDUEPATRON_SELECT"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("strModeSelect", OracleType.VarChar, 10)).Value = strSelectMode
                            .Add(New OracleParameter("strLogic", OracleType.VarChar, 10)).Value = strLogic
                            .Add(New OracleParameter("intDueTime", OracleType.Number, 4)).Value = intDueTime
                            .Add(New OracleParameter("strPatronIDs", OracleType.VarChar, 2000)).Value = strPatronIDs
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblOVERDUEPATRON")
                            GetOverduePatron = dsData.Tables("tblOVERDUEPATRON")
                            dsData.Tables.Remove("tblOVERDUEPATRON")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' GetOverduePatron method
        ' Purpose: Get Overdue Patron to Send mail or Print complaint report
        ' Input: some infor
        Public Function GetOverduePatronAuthority() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spLoan_SelOverDuePatronAuthority"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserid
                            .Add(New SqlParameter("@strModeSelect", SqlDbType.VarChar, 10)).Value = strSelectMode
                            .Add(New SqlParameter("@strLogic", SqlDbType.VarChar, 10)).Value = strLogic
                            .Add(New SqlParameter("@intDueTime", SqlDbType.Int)).Value = intDueTime
                            .Add(New SqlParameter("@strPatronIDs", SqlDbType.VarChar, 2000)).Value = strPatronIDs
                            .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                        End With
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsdata, "tblResult")
                            GetOverduePatronAuthority = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message
                            interrorcode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oracommand
                        .CommandText = "CIRCULATION.SP_CIR_OVERDUEPATRON_SEL_AT"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intUserID", OracleType.Number, 4)).Value = intUserID
                            .Add(New OracleParameter("strModeSelect", OracleType.VarChar, 10)).Value = strSelectMode
                            .Add(New OracleParameter("strLogic", OracleType.VarChar, 10)).Value = strLogic
                            .Add(New OracleParameter("intDueTime", OracleType.Number, 4)).Value = intDueTime
                            .Add(New OracleParameter("strPatronIDs", OracleType.VarChar, 2000)).Value = strPatronIDs
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            oraDataAdapter.SelectCommand = OraCommand
                            oraDataAdapter.Fill(dsdata, "tblResult")
                            GetOverduePatronAuthority = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function


        ' UpDatePatronEmail method
        ' Purpose: UpDate Patron Email
        ' Input: some infor
        Public Sub UpDatePatronEmail()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spPatronUpdateEmail"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 200)).Value = strPatronCode
                            .Add(New SqlParameter("@strEmail", SqlDbType.VarChar, 200)).Value = strEmail
                            .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                        End With
                        Try
                            .ExecuteNonQuery()
                            sqlDataAdapter.SelectCommand = sqlCommand
                        Catch ex As SqlException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Number
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
