Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Patron
    Public Class clsDFaculty
        Inherits clsDBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Private intID As Integer
        Private strFaculty As String
        Private intCollegeID As Integer
        Private strIDs As String

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************

        ' ID property
        Public Property ID() As Integer
            Get
                Return intID
            End Get
            Set(ByVal Value As Integer)
                intID = Value
            End Set
        End Property

        ' Faculty Property
        Public Property Faculty() As String
            Get
                Return strFaculty
            End Get
            Set(ByVal Value As String)
                strFaculty = Value
            End Set
        End Property

        ' CollegeID property
        Public Property CollegeID() As Integer
            Get
                Return intCollegeID
            End Get
            Set(ByVal Value As Integer)
                intCollegeID = Value
            End Set
        End Property

        ' IDs Property
        Public Property IDs() As String
            Get
                Return strIDs
            End Get
            Set(ByVal Value As String)
                strIDs = Value
            End Set
        End Property

        ' *************************************************************************************************
        ' End declare properties
        ' Declare public method
        ' *************************************************************************************************

        ' Method: GetFaculty
        ' Purpose: Get faculties
        ' Input: intCollegeID, intFacultyID
        ' Output: Datatable
        ' Created by: Sondp
        Public Function GetFaculty() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatGetFaculty"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intCollegeID", SqlDbType.Int)).Value = intCollegeID
                                .Add(New SqlParameter("@intFacultyID", SqlDbType.Int)).Value = intID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetFaculty = dsData.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        ' Change SP
                        ' .CommandText = "PATRON.SP_CIR_DIC_FACULTY_SELECT"
                        .CommandText = "PATRON.SP_PAT_GET_FACULTY"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intCollegeID", OracleType.Number)).Value = intCollegeID
                                .Add(New OracleParameter("intFacultyID", OracleType.Number)).Value = intID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetFaculty = dsData.Tables("tblResult")
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
        ' Purpose: Create one faculty
        ' Input: faculty information
        ' Output: -1 if exists
        ' Created by: Lent
        Public Function Create() As Integer
            Dim intOut As Integer = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatCreatFaculty"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intCollegeID", SqlDbType.Int)).Value = intCollegeID
                                .Add(New SqlParameter("@strFaculty", SqlDbType.NVarChar, 50)).Value = strFaculty
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
                    With OraCommand
                        .CommandText = "PATRON.SP_PAT_CREATE_FACULTY"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intCollegeID", OracleType.Number)).Value = intCollegeID
                                .Add(New OracleParameter("strFaculty", OracleType.VarChar, 50)).Value = strFaculty
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
        ' Purpose : Update one faculty
        ' Input: ID, name
        ' Output: 0 if success, 1 if exists
        ' Created by: LENT
        Public Function Update() As Integer
            Dim intOut As Integer = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatUpdateFaculty"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intID
                                .Add(New SqlParameter("@intCollegeID", SqlDbType.Int)).Value = intCollegeID
                                .Add(New SqlParameter("@strFaculty", SqlDbType.NVarChar, 50)).Value = strFaculty
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
                    With OraCommand
                        ' Change SP
                        ' .CommandText = "PATRON.SP_CIR_DIC_FACULTY_UPDATE"
                        .CommandText = "PATRON.SP_PAT_UPDATE_FACULTY"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intID", OracleType.Number)).Value = intID
                                .Add(New OracleParameter("intCollegeID", OracleType.Number)).Value = intCollegeID
                                .Add(New OracleParameter("strFaculty", OracleType.VarChar, 50)).Value = strFaculty
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

        ' Method: Merger
        ' Purpose : Merger one Faculty
        ' Created by: LENT
        Public Sub Merger()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatMergeFaculty"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intID
                                .Add(New SqlParameter("@strIDs", SqlDbType.VarChar, 200)).Value = strIDs
                            End With
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        ' Change SP
                        ' .CommandText = "PATRON.SP_CIR_DIC_FACULTY_MER"
                        .CommandText = "PATRON.SP_PAT_MERGER_FACULTY"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intID", OracleType.Number)).Value = intID
                                .Add(New OracleParameter("strIDs", OracleType.VarChar, 200)).Value = strIDs
                            End With
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' Purpose: Delete one Faculty
        ' Created by: Lent
        Public Sub Delete()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spDicFaculty_DelById"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intID
                            End With
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "PATRON.SP_CIR_DIC_FACULTY_DELETE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intID", OracleType.Number)).Value = intID
                            End With
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        Public Function GetFacultyByName() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spPatGetFacultyByName"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intCollegeID", SqlDbType.Int)).Value = intCollegeID
                                .Add(New SqlParameter("@Faculty", SqlDbType.NVarChar, 100)).Value = Faculty
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetFacultyByName = dsData.Tables("tblResult")
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
                        ' Change SP
                        ' .CommandText = "PATRON.SP_CIR_DIC_FACULTY_SELECT"
                        .CommandText = "Cir_spPatGetFacultyByName"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intCollegeID", OracleType.Number)).Value = intCollegeID
                                .Add(New OracleParameter("Faculty", OracleType.Number)).Value = Faculty
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetFacultyByName = dsData.Tables("tblResult")
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