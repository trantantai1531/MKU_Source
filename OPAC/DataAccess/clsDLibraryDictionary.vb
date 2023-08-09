Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibOPAC.DataAccess.OPAC
    Public Class clsDLibraryDictionary
        Inherits clsDBase

#Region "Properties"
        Private idStr As String
        Public Property id() As String
            Get
                Return idStr
            End Get
            Set(ByVal value As String)
                idStr = value
            End Set
        End Property

        Private searchTypeInt As Integer
        Public Property SearchType() As Integer
            Get
                Return searchTypeInt
            End Get
            Set(ByVal value As Integer)
                searchTypeInt = value
            End Set
        End Property


        Private EnglishVocabularyStr As String
        Public Property EnglishVocabulary() As String
            Get
                Return EnglishVocabularyStr
            End Get
            Set(ByVal value As String)
                EnglishVocabularyStr = value
            End Set
        End Property


        Private MeanStr As String
        Public Property Mean() As String
            Get
                Return MeanStr
            End Get
            Set(ByVal value As String)
                Mean = value
            End Set
        End Property


    
#End Region

        Public Function Create() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Sys_spLibraryDictionary_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strEnglishVocabulary", SqlDbType.NVarChar, 150)).Value = EnglishVocabulary
                                .Add(New SqlParameter("@strMean", SqlDbType.NVarChar, 550)).Value = Mean
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


        Public Function GetVocabulary() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)

                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Sys_spLibraryDictionary_SelVocabulary"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strEnglishVocabulary ", SqlDbType.NVarChar)).Value = EnglishVocabularyStr
                            .Parameters.Add(New SqlParameter("@strSearchType ", SqlDbType.Int)).Value = searchTypeInt
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetVocabulary = dsData.Tables("tblResult")
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

        Public Function GetMeanVocabulary() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)

                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Sys_spLibraryDictionary_SelMeanOfEnglishVocabulary"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strEnglishVocabulary ", SqlDbType.NVarChar)).Value = EnglishVocabularyStr
                            .Parameters.Add(New SqlParameter("@strSearchType ", SqlDbType.Int)).Value = searchTypeInt
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetMeanVocabulary = dsData.Tables("tblResult")
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
       
   
    End Class
End Namespace

