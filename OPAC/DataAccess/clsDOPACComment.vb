Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibOPAC.DataAccess.OPAC
    Public Class clsDOPACComment
        Inherits clsDBase
        '***************************************************************************************************
        '                                  DECLARE PRIVATE VARIABLES
        '***************************************************************************************************
        Private strCardNo As String
        Private strPassword As String
        Private strContent As String
        Private intRanking As Integer
        Private strSubject As String
        Private strComment As String
        Private lngItemID As Long
        Private strCode As String

        '***************************************************************************************************
        '                               END DECLARE PRIVATE VARIABLES
        '                                DECLARE PRIVATE PROPARTIES
        '***************************************************************************************************

        'ItemID Property
        Public Property ItemID() As Long
            Get
                Return lngItemID
            End Get
            Set(ByVal Value As Long)
                lngItemID = Value
            End Set
        End Property


        'Code Property
        Public Property Code() As String
            Get
                Return strCode
            End Get
            Set(ByVal Value As String)
                strCode = Value
            End Set
        End Property

        'Comment Property
        Public Property Comment() As String
            Get
                Return strComment
            End Get
            Set(ByVal Value As String)
                strComment = Value
            End Set
        End Property

        'CardNo Property
        Public Property CardNo() As String
            Get
                Return strCardNo
            End Get
            Set(ByVal Value As String)
                strCardNo = Value
            End Set
        End Property

        'Password Property
        Public Property Password() As String
            Get
                Return strPassword
            End Get
            Set(ByVal Value As String)
                strPassword = Value
            End Set
        End Property

        'Content Property
        Public Property Content() As String
            Get
                Return strContent
            End Get
            Set(ByVal Value As String)
                strContent = Value
            End Set
        End Property

        'Ranking Property
        Public Property Ranking() As Integer
            Get
                Return intRanking
            End Get
            Set(ByVal Value As Integer)
                intRanking = Value
            End Set
        End Property

        'Subject Property
        Public Property Subject()
            Get
                Return strSubject
            End Get
            Set(ByVal Value)
                strSubject = Value
            End Set
        End Property

        '***************************************************************************************************
        '                                          END DECLARE PROPERTIES
        '                                          IMPLEMENT METHODS HERE
        '***************************************************************************************************
        Public Function Create(ByVal intSelect As Integer) As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spComment_Create"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strComment", SqlDbType.NVarChar, 2000)).Value = strComment
                                .Add(New SqlParameter("@strSubject", SqlDbType.NVarChar, 100)).Value = strSubject
                                .Add(New SqlParameter("@intRanking", SqlDbType.Int)).Value = intRanking
                                .Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = lngItemID
                                .Add(New SqlParameter("@strCode", SqlDbType.VarChar, 30)).Value = strCode
                                .Add(New SqlParameter("@intSelect", SqlDbType.Int)).Value = intSelect
                                .Add(New SqlParameter("@intSucess", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            Create = .Parameters("@intSucess").Value
                        Catch sqlClientEx As SqlException
                            strerrormsg = sqlClientEx.Message
                            interrorcode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oracommand
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "OPAC.Opac_spComment_Create"
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strComment", OracleType.VarChar, 100)).Value = strComment
                                .Add(New OracleParameter("strSubject", OracleType.VarChar, 100)).Value = strSubject
                                .Add(New OracleParameter("strCode", OracleType.VarChar, 30)).Value = strCode
                                .Add(New OracleParameter("intRanking", OracleType.Number)).Value = intRanking
                                .Add(New OracleParameter("intItemID", OracleType.Number)).Value = lngItemID
                                .Add(New OracleParameter("intSelect", OracleType.Number)).Value = intSelect
                                .Add(New OracleParameter("intSucess", OracleType.Number, 1)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            Create = .Parameters("intSucess").Value
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

        Public Function Update(ByVal intSelect As Integer, ByVal intCo_ID As Integer) As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spComment_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strComment", SqlDbType.NVarChar, 100)).Value = strComment
                                .Add(New SqlParameter("@strSubject", SqlDbType.NVarChar, 100)).Value = strSubject
                                .Add(New SqlParameter("@intRanking", SqlDbType.Int)).Value = intRanking
                                .Add(New SqlParameter("@strCode", SqlDbType.VarChar, 30)).Value = strCode
                                .Add(New SqlParameter("@strPass", SqlDbType.VarChar, 30)).Value = strPassword
                                .Add(New SqlParameter("@intCo_ID", SqlDbType.Int)).Value = intCo_ID
                                .Add(New SqlParameter("@intSelect", SqlDbType.Int)).Value = intSelect
                                .Add(New SqlParameter("@intSucess", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            Update = .Parameters("@intSucess").Value
                        Catch sqlClientEx As SqlException
                            strerrormsg = sqlClientEx.Message
                            interrorcode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oracommand
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "OPAC.Opac_spComment_Upd"
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strComment", OracleType.VarChar, 100)).Value = strComment
                                .Add(New OracleParameter("strSubject", OracleType.VarChar, 100)).Value = strSubject
                                .Add(New OracleParameter("strCode", OracleType.VarChar, 30)).Value = strCode
                                .Add(New OracleParameter("strPass", OracleType.VarChar, 30)).Value = strPassword
                                .Add(New OracleParameter("intRanking", OracleType.Number)).Value = intRanking
                                .Add(New OracleParameter("intItemID", OracleType.Number)).Value = lngItemID
                                .Add(New OracleParameter("intSucess", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            Update = .Parameters("intSucess").Value
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

        Public Function Delete(ByVal intCo_ID As Integer) As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spComment_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intCo_ID", SqlDbType.Int)).Value = intCo_ID
                                .Add(New SqlParameter("@intSucess", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            Delete = .Parameters("@intSucess").Value
                        Catch sqlClientEx As SqlException
                            strerrormsg = sqlClientEx.Message
                            interrorcode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oracommand
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "OPAC.Opac_spComment_Upd"
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intCo_ID", OracleType.Number)).Value = intCo_ID
                                .Add(New OracleParameter("intSucess", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            Delete = .Parameters("intSucess").Value
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

        'Dispose method
        'Purpose: Release all resource
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