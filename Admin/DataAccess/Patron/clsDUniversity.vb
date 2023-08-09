Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Patron
    Public Class clsDUniversity
        Inherits clsDBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private strPatronIDs As String
        Private intPatronID As Integer
        Private intFacultyID As Integer
        Private intCollegeID As Integer
        Private strGrade As String
        Private strUClass As String

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
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
        Public Property PatronID() As Integer
            Get
                Return intPatronID
            End Get
            Set(ByVal Value As Integer)
                intPatronID = Value
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

        ' FacultyID property
        Public Property FacultyID() As Integer
            Get
                Return intFacultyID
            End Get
            Set(ByVal Value As Integer)
                intFacultyID = Value
            End Set
        End Property

        ' Grade property
        Public Property Grade() As String
            Get
                Return strGrade
            End Get
            Set(ByVal Value As String)
                strGrade = Value
            End Set
        End Property

        ' Class property
        Public Property UClass() As String
            Get
                Return strUClass
            End Get
            Set(ByVal Value As String)
                strUClass = Value
            End Set
        End Property

        ' *************************************************************************************************
        ' End declare properties
        ' Declare public method
        ' *************************************************************************************************

        Public Function GetUniversity() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatronUniversity_SelByPatronIds"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strPatronIDs", SqlDbType.VarChar, 8000)).Value = strPatronIDs
                            End With
                            .ExecuteNonQuery()
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "UNI")
                            GetUniversity = dsData.Tables("UNI")
                            dsData.Tables.Remove("UNI")
                            'Catch ex As SqlException
                            '    strErrorMsg = ex.Message.ToString
                            '    intErrorCode = ex.Number
                        Finally
                            'dsdata.Tables.Remove("")
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.SP_CIR_PATRON_UNI_SELECT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                .Add(New OracleParameter("strPatronIDs", OracleType.VarChar, 8000)).Value = strPatronIDs
                            End With
                            .ExecuteNonQuery()
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "UNI")
                            GetUniversity = dsData.Tables("UNI")
                            'Catch ex As OracleException
                            '    strErrorMsg = ex.Message.ToString
                            '    intErrorCode = ex.Code
                        Finally
                            'dsData.Tables.Remove("")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Sub Create()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatCreatePatronUniv"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intPatronID", SqlDbType.Int)).Value = intPatronID
                                .Add(New SqlParameter("@intCollegeID", SqlDbType.Int)).Value = intCollegeID
                                .Add(New SqlParameter("@intFacultyID", SqlDbType.Int)).Value = intFacultyID
                                .Add(New SqlParameter("@strGrade", SqlDbType.NVarChar, 50)).Value = strGrade
                                .Add(New SqlParameter("@strClass", SqlDbType.NVarChar, 100)).Value = strUClass
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
                        .CommandText = "PATRON.SP_PAT_CREATE_PATRON_UNIV"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intPatronID", OracleType.Number)).Value = intPatronID
                                .Add(New OracleParameter("intCollegeID", OracleType.Number)).Value = intCollegeID
                                .Add(New OracleParameter("intFacultyID", OracleType.Number)).Value = intFacultyID
                                .Add(New OracleParameter("strGrade", OracleType.VarChar, 50)).Value = strGrade
                                .Add(New OracleParameter("strClass", OracleType.VarChar, 100)).Value = strUClass
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

        Public Sub Update()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatUpdatePatronUniv"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intPatronID", SqlDbType.Int)).Value = intPatronID
                                .Add(New SqlParameter("@intCollegeID", SqlDbType.Int)).Value = intCollegeID
                                .Add(New SqlParameter("@intFacultyID", SqlDbType.Int)).Value = intFacultyID
                                .Add(New SqlParameter("@strGrade", SqlDbType.NVarChar, 50)).Value = strGrade
                                .Add(New SqlParameter("@strClass", SqlDbType.NVarChar, 100)).Value = strUClass
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
                        .CommandText = "PATRON.SP_PAT_UPDATE_PATRON_UNIV"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intPatronID", OracleType.Number)).Value = intPatronID
                                .Add(New OracleParameter("intCollegeID", OracleType.Number)).Value = intCollegeID
                                .Add(New OracleParameter("intFacultyID", OracleType.Number)).Value = intFacultyID
                                .Add(New OracleParameter("strGrade", OracleType.VarChar, 50)).Value = strGrade
                                .Add(New OracleParameter("strClass", OracleType.VarChar, 100)).Value = strUClass
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

        Public Sub Delete()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatronUniversity_DelByPatronId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intPatronID", SqlDbType.Int)).Value = intPatronID
                            End With
                            .ExecuteNonQuery()
                            'Catch sqlClientEx As SqlException
                            '    strErrorMsg = sqlClientEx.Message.ToString
                            '    intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "SP_CIR_PATRON_UNI_DELETE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intPatronID", OracleType.Number)).Value = intPatronID
                            End With
                            .ExecuteNonQuery()
                            'Catch OraEx As OracleException
                            '    strErrorMsg = OraEx.Message.ToString
                            '    intErrorCode = OraEx.Code
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