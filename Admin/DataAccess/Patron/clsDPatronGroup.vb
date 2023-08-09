Imports System.IO
Imports System.Data
Imports System.Math
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Patron
    Public Class clsDPatronGroup
        Inherits clsDBase

        ' *************************************************************************************************
        ' Begin declare variables
        ' *************************************************************************************************

        Private intID As Integer
        Private strName As String
        Private intInLibraryQuota As Integer
        Private intLoanQuota As Integer
        Private intHoldQuota As Integer
        Private intHoldTurnTimeOut As Integer
        Private intPriority As Integer
        Private intILLQuota As Integer
        Private intAccessLevel As Integer
        Private strStoreIDs As String
        'Private intLibID As Integer
        Private intLoanDayPeriod As Integer
        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************

        ' ID Property 
        Public Property ID() As Integer
            Get
                Return intID
            End Get
            Set(ByVal Value As Integer)
                intID = Value
            End Set
        End Property

        Public Property Name() As String
            Get
                Return strName
            End Get
            Set(ByVal Value As String)
                strName = Value
            End Set
        End Property

        Public Property InLibraryQuota() As Integer
            Get
                Return intInLibraryQuota
            End Get
            Set(ByVal Value As Integer)
                intInLibraryQuota = Value
            End Set
        End Property

        Public Property LoanQuota() As Integer
            Get
                Return intLoanQuota
            End Get
            Set(ByVal Value As Integer)
                intLoanQuota = Value
            End Set
        End Property

        Public Property HoldQuota() As Integer
            Get
                Return intHoldQuota
            End Get
            Set(ByVal Value As Integer)
                intHoldQuota = Value
            End Set
        End Property

        Public Property HoldTurnTimeOut() As Integer
            Get
                Return intHoldTurnTimeOut
            End Get
            Set(ByVal Value As Integer)
                intHoldTurnTimeOut = Value
            End Set
        End Property

        Public Property Priority() As Integer
            Get
                Return intPriority
            End Get
            Set(ByVal Value As Integer)
                intPriority = Value
            End Set
        End Property

        Public Property ILLQuota() As Integer
            Get
                Return intILLQuota
            End Get
            Set(ByVal Value As Integer)
                intILLQuota = Value
            End Set
        End Property

        Public Property AccessLevel() As Integer
            Get
                Return intAccessLevel
            End Get
            Set(ByVal Value As Integer)
                intAccessLevel = Value
            End Set
        End Property

        Public Property StoreIDs() As String
            Get
                Return strStoreIDs
            End Get
            Set(ByVal Value As String)
                strStoreIDs = Value
            End Set
        End Property

        ' LIBID 
        'Public Property LibID() As Integer
        '    Get
        '        Return intLibID
        '    End Get
        '    Set(ByVal Value As Integer)
        '        intLibID = Value
        '    End Set
        'End Property

        'LoanDayPeriod
        Public Property LoanDayPeriod() As Integer
            Get
                Return intLoanDayPeriod
            End Get
            Set(ByVal Value As Integer)
                intLoanDayPeriod = Value
            End Set
        End Property

        ' *************************************************************************************************
        ' End declare properties
        ' Declare public method
        ' *************************************************************************************************

        ' Method: GetPatronGroup
        ' Purpose: GetPatronGroup
        ' Output: Datatable
        ' Created by: Sondp
        Public Function GetAllPatronGroup() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spPatronGroupStatistic"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetAllPatronGroup = dsData.Tables("tblResult")
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
        Public Function GetPatronGroup() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spPatGetPatronGroup"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetPatronGroup = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.SP_PAT_GET_PATRONGROUP"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetPatronGroup = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function GetPatronGroupByPatronCode(ByVal strPatronCode As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spPatGetPatronGroup_ByPatronCode"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 20)).Value = strPatronCode
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetPatronGroupByPatronCode = dsData.Tables("tblResult")
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

        Public Function GetPatronGroupByName(strName As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spPatGetPatronGroupByName"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            .Parameters.Add(New SqlParameter("@strName", SqlDbType.NVarChar)).Value = strName
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetPatronGroupByName = dsData.Tables("tblResult")
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


        ' Method: GetLocation
        ' Purpose: Get available locations
        ' Output: Datatable
        ' Created by: lent
        Public Function GetLocation() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Pat_spLocationInfor_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetLocation = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.SP_PAT_GET_LOCATION"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetLocation = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Method: GetLocationOfGroup
        ' Purpose: Get all locations of the selected group
        ' Input: GroupID
        ' Output: Datatable
        ' Created by: lent
        Public Function GetLocationOfGroup() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spPatGetLocationGroup"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetLocationOfGroup = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.SP_PAT_GET_LOCATION_OF_GROUP"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intID", OracleType.Number)).Value = intID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetLocationOfGroup = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Method: Create
        ' Purpose: Create one PatronGroup
        ' Input: patrongoup information
        ' Output: -1 if exists
        ' Created by: Lent
        Public Function Create() As Integer
            Dim intOut As Integer = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spPatCreatePatronGroup"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strName", SqlDbType.NVarChar, 256)).Value = strName
                                .Add(New SqlParameter("@intInLibraryQuota", SqlDbType.Int)).Value = intInLibraryQuota
                                .Add(New SqlParameter("@intLoanQuota", SqlDbType.Int)).Value = intLoanQuota
                                .Add(New SqlParameter("@intHoldQuota", SqlDbType.Int)).Value = intHoldQuota
                                .Add(New SqlParameter("@intHoldTurnTimeOut", SqlDbType.Int)).Value = intHoldTurnTimeOut
                                .Add(New SqlParameter("@intPriority", SqlDbType.Int)).Value = intPriority
                                .Add(New SqlParameter("@intILLQuota", SqlDbType.Int)).Value = intILLQuota
                                .Add(New SqlParameter("@intAccessLevel", SqlDbType.Int)).Value = intAccessLevel
                                .Add(New SqlParameter("@strStoreIDs", SqlDbType.VarChar, 200)).Value = strStoreIDs
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@intLoanDayPeriod", SqlDbType.Int)).Value = intLoanDayPeriod
                                .Add(New SqlParameter("@intOut", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intOut = Abs(.Parameters("@intOut").Value)
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.SP_PAT_CREATE_PATRONGROUP"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strName", OracleType.VarChar, 256)).Value = strName
                                .Add(New OracleParameter("intInLibraryQuota", OracleType.Number)).Value = intInLibraryQuota
                                .Add(New OracleParameter("intLoanQuota", OracleType.Number)).Value = intLoanQuota
                                .Add(New OracleParameter("intHoldQuota", OracleType.Number)).Value = intHoldQuota
                                .Add(New OracleParameter("intHoldTurnTimeOut", OracleType.Number)).Value = intHoldTurnTimeOut
                                .Add(New OracleParameter("intPriority", OracleType.Number)).Value = intPriority
                                .Add(New OracleParameter("intILLQuota", OracleType.Number)).Value = intILLQuota
                                .Add(New OracleParameter("intAccessLevel", OracleType.Number)).Value = intAccessLevel
                                .Add(New OracleParameter("strStoreIDs", OracleType.VarChar, 200)).Value = strStoreIDs
                                .Add(New OracleParameter("intOut", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intOut = .Parameters("intOut").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Return intOut
        End Function

        ' Method: Update
        ' Purpose : Update one patron group
        ' Input: ID, name
        ' Output: 0 if success, 1 if exists
        ' Created by: LENT
        Public Function Update() As Integer
            Dim intOut As Integer = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spPatUpdatePatronGroup"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intID
                                .Add(New SqlParameter("@strName", SqlDbType.NVarChar, 256)).Value = strName
                                .Add(New SqlParameter("@intInLibraryQuota", SqlDbType.Int)).Value = intInLibraryQuota
                                .Add(New SqlParameter("@intLoanQuota", SqlDbType.Int)).Value = intLoanQuota
                                .Add(New SqlParameter("@intHoldQuota", SqlDbType.Int)).Value = intHoldQuota
                                .Add(New SqlParameter("@intHoldTurnTimeOut", SqlDbType.Int)).Value = intHoldTurnTimeOut
                                .Add(New SqlParameter("@intPriority", SqlDbType.Int)).Value = intPriority
                                .Add(New SqlParameter("@intILLQuota", SqlDbType.Int)).Value = intILLQuota
                                .Add(New SqlParameter("@intAccessLevel", SqlDbType.Int)).Value = intAccessLevel
                                .Add(New SqlParameter("@strStoreIDs", SqlDbType.VarChar, 200)).Value = strStoreIDs
                                .Add(New SqlParameter("@intLoanDayPeriod", SqlDbType.Int)).Value = intLoanDayPeriod
                                .Add(New SqlParameter("@intOut", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intOut = .Parameters("@intOut").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.SP_PAT_UPDATE_PATRONGROUP"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intID", OracleType.Number)).Value = intID
                                .Add(New OracleParameter("strName", OracleType.VarChar, 256)).Value = strName
                                .Add(New OracleParameter("intInLibraryQuota", OracleType.Number)).Value = intInLibraryQuota
                                .Add(New OracleParameter("intLoanQuota", OracleType.Number)).Value = intLoanQuota
                                .Add(New OracleParameter("intHoldQuota", OracleType.Number)).Value = intHoldQuota
                                .Add(New OracleParameter("intHoldTurnTimeOut", OracleType.Number)).Value = intHoldTurnTimeOut
                                .Add(New OracleParameter("intPriority", OracleType.Number)).Value = intPriority
                                .Add(New OracleParameter("intILLQuota", OracleType.Number)).Value = intILLQuota
                                .Add(New OracleParameter("intAccessLevel", OracleType.Number)).Value = intAccessLevel
                                .Add(New OracleParameter("strStoreIDs", OracleType.VarChar, 200)).Value = strStoreIDs
                                .Add(New OracleParameter("intOut", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intOut = .Parameters("intOut").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Return intOut
        End Function

        ' Method: Delete
        ' Purpose: Delete selected patrongroup
        ' Input: GroupID
        ' Created by: Lent
        Public Function Delete() As Integer
            Delete = 0
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spPatDeletePatronGroup"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intID
                                .Add(New SqlParameter("@intRetval", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            Delete = .Parameters("@intRetval").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.SP_PAT_DELETE_PATRONGROUP"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intID", OracleType.Number)).Value = intID
                                .Add(New OracleParameter("intRetval", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            Delete = .Parameters("intRetval").Value
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