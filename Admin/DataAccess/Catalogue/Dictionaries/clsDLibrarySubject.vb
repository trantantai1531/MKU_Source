Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Catalogue
    Public Class clsDLibrarySubject
        Inherits clsDBase

#Region "Properties"
        Private intId As Integer
        Public Property Id() As String
            Get
                Return intId
            End Get
            Set(ByVal value As String)
                intId = value
            End Set
        End Property



        Private strSubject As String
        Public Property Subject() As String
            Get
                Return strSubject
            End Get
            Set(ByVal value As String)
                strSubject = value
            End Set
        End Property

        Private intParentId As Integer
        Public Property ParentId() As Integer
            Get
                Return intParentId
            End Get
            Set(ByVal value As Integer)
                intParentId = value
            End Set
        End Property




#End Region

#Region "subject dictionary funtion"
        Public Function Create() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Sys_spLibraryDictionary_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                '.Add(New SqlParameter("@strEnglishVocabulary", SqlDbType.NVarChar, 150)).Value = strEnglishVocabulary
                                '.Add(New SqlParameter("@strMean", SqlDbType.NVarChar)).Value = strMean
                                .Add(New SqlParameter("@intRetval", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            Create = .Parameters("@intRetval").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function Update() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Sys_spLibraryDictionary_Up"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                '.Add(New SqlParameter("@intId", SqlDbType.Int)).Value = intId
                                '.Add(New SqlParameter("@strEnglishVocabulary", SqlDbType.NVarChar)).Value = strEnglishVocabulary
                                '.Add(New SqlParameter("@strMean", SqlDbType.NVarChar)).Value = strMean
                                .Add(New SqlParameter("@intRetval", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            Update = .Parameters("@intRetval").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function Delete() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Sys_spLibraryDictionary_Del"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intId", SqlDbType.Int)).Value = intId

                                .Add(New SqlParameter("@intRetval", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            Delete = .Parameters("@intRetval").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function GetAllSubject() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)

                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Sys_spLibrarySubj_SelAll"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetAllSubject = dsData.Tables("tblResult")
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

        Public Function GetAllSubjectName() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)

                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Sys_spLibrarySubj_SelSubjectName"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetAllSubjectName = dsData.Tables("tblResult")
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

        Public Function GetSubjectByName() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)

                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Sys_spLibraryDictionary_SelMeanOfEnglishVocabulary"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            '.Parameters.Add(New SqlParameter("@strEnglishVocabulary ", SqlDbType.NVarChar)).Value = strEnglishVocabulary
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetSubjectByName = dsData.Tables("tblResult")
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
#End Region

    End Class
End Namespace

