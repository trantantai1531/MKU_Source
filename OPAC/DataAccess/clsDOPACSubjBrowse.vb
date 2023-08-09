Imports System
Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibOPAC.DataAccess.OPAC
    Public Class clsDOPACSubjBrowse
        Inherits clsDBase
        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private intIDDic As Integer
        Private strWord As String

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
        Public Property DicID() As Integer
            Get
                Return intIDDic
            End Get
            Set(ByVal Value As Integer)
                intIDDic = Value
            End Set
        End Property
        Public Property Word() As String
            Get
                Return strWord
            End Get
            Set(ByVal Value As String)
                strWord = Value
            End Set
        End Property

        ' *************************************************************************************************
        ' End declare properties
        ' IMPLEMENT METHODS HERE
        ' *************************************************************************************************
        ' Purpose: Get information depend on strWord input and intIDDIc

        Public Function GetSubjBrowse() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spSubBrowse"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intDicID", SqlDbType.Int)).Value = intIDDic
                                .Add(New SqlParameter("@strWord", SqlDbType.NVarChar, 5)).Value = strWord.Trim
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblSubjBrowse")
                            GetSubjBrowse = dsData.Tables("tblSubjBrowse")
                            dsData.Tables.Remove("tblSubjBrowse")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spSubBrowse"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intDicID", OracleType.Number)).Value = intIDDic
                                .Add(New OracleParameter("strWord", OracleType.VarChar, 100)).Value = strWord.Trim
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblSubjBrowse")
                            GetSubjBrowse = dsData.Tables("tblSubjBrowse")
                            dsData.Tables.Remove("tblSubjBrowse")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function
        ' *************************************************************************************************
        ' IMPLEMENT METHODS HERE
        ' *************************************************************************************************
        ' Purpose: Select ItemID depend on  intIDDIc,ID

        Public Function SelectSubjBrowseByID(ByVal intIDDic As Integer, ByVal intID As Integer) As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spSubjBrowse_SelByID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intDicID", SqlDbType.Int)).Value = intIDDic
                                .Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblSelectSubjBrowseByID")
                            SelectSubjBrowseByID = dsData.Tables("tblSelectSubjBrowseByID")
                            dsData.Tables.Remove("tblSelectSubjBrowseByID")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spSubjBrowse_SelByID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intDicID", OracleType.Number)).Value = intIDDic
                                .Add(New OracleParameter("intID", OracleType.Number)).Value = intID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblSelectSubjBrowseByID")
                            SelectSubjBrowseByID = dsData.Tables("tblSelectSubjBrowseByID")
                            dsData.Tables.Remove("tblSelectSubjBrowseByID")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function
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

