Imports eMicLibAdmin.DataAccess
Imports eMicLibAdmin.DataAccess.Common
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Catalogue
    Public Class clsDCatDicList
        Inherits clsDBase

        ' *****************************************************************************************************
        ' Declare Private variables
        ' *****************************************************************************************************

        Private strIDs As String
        Private bytSystemDic As Byte
        Private intIsClassifiCation As Integer
        Private intIsAuthority As Integer
        Private strFieldCode As String
        Private bytIsDic As Byte

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        Public Property IsDic() As Byte
            Get
                Return bytIsDic
            End Get
            Set(ByVal Value As Byte)
                bytIsDic = Value
            End Set
        End Property

        Public Property IsAuthority() As Integer
            Get
                Return intIsAuthority
            End Get
            Set(ByVal Value As Integer)
                intIsAuthority = Value
            End Set
        End Property

        Public Property IsClassifiCation() As Integer
            Get
                Return intIsClassifiCation
            End Get
            Set(ByVal Value As Integer)
                intIsClassifiCation = Value
            End Set
        End Property

        Public Property SystemDic() As Byte
            Get
                Return bytSystemDic
            End Get
            Set(ByVal Value As Byte)
                bytSystemDic = Value
            End Set
        End Property

        Public Property IDs() As String
            Get
                Return strIDs
            End Get
            Set(ByVal Value As String)
                strIDs = Value
            End Set
        End Property

        ' FieldCode property
        Public Property FieldCode() As String
            Get
                Return strFieldCode
            End Get
            Set(ByVal Value As String)
                strFieldCode = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Insert method
        Public Sub Insert()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                Case "ORACLE"
            End Select
        End Sub

        ' Update method
        Public Sub Update()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                Case "ORACLE"
            End Select
        End Sub

        ' Delete method
        Public Sub Delete()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                Case "ORACLE"
            End Select
        End Sub

        ' Retrieve function
        Public Function Retrieve() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spDicList_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strIDs", SqlDbType.VarChar, 4000)).Value = strIDs
                                .Add(New SqlParameter("@intIsClassifiCation", SqlDbType.Int)).Value = intIsClassifiCation
                                .Add(New SqlParameter("@intIsAuthority", SqlDbType.Int)).Value = intIsAuthority
                                .Add(New SqlParameter("@intSytemDic", SqlDbType.Int)).Value = bytSystemDic
                                .Add(New SqlParameter("@intIsDic", SqlDbType.Int)).Value = bytIsDic
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "Cat_tblDicList")
                            Retrieve = dsData.Tables("Cat_tblDicList")
                            dsData.Tables.Remove("Cat_tblDicList")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CAT_DIC_LIST_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strIDs", OracleType.VarChar, 4000)).Value = strIDs
                                .Add(New OracleParameter("intIsClassifICation", OracleType.Number)).Value = intIsClassifiCation
                                .Add(New OracleParameter("intIsAuthority", OracleType.Number)).Value = intIsAuthority
                                .Add(New OracleParameter("intSytemDic", OracleType.Number)).Value = bytSystemDic
                                .Add(New OracleParameter("intIsDic", OracleType.Number)).Value = bytIsDic
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "Cat_tblDicList")
                            Retrieve = dsData.Tables("Cat_tblDicList")
                            dsData.Tables.Remove("Cat_tblDicList")
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

        ' GetReferenceByFieldCode method
        ' Purpose: get reference infor by FieldCode
        ' Input: string value of FieldCode
        ' Output: datatable
        Public Function GetReferenceByFieldCode() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_GETREFERENCE_BYFIELCODE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strFieldCode", OracleType.VarChar, 5)).Value = strFieldCode
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblReferenceInfor")
                            GetReferenceByFieldCode = dsData.Tables("tblReferenceInfor")
                            dsData.Tables.Remove("tblReferenceInfor")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spMARCBibField_SelReferenceByFieldCode"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strFieldCode", SqlDbType.VarChar, 5)).Value = strFieldCode
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblReferenceInfor")
                            GetReferenceByFieldCode = dsData.Tables("tblReferenceInfor")
                            dsData.Tables.Remove("tblReferenceInfor")
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

        ' Purpose : Get ID, Name from Cat_tblDicList table
        ' In: intID
        ' Out: Datatable
        ' Created by: Sondp
        Public Function GetCatDicList(ByVal intID As Integer) As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spDicList_SelById"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intID", SqlDbType.Int, 4)).Value = intID
                        End With
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "SP_ACQ_GET_CAT_DIC_LIST")
                            GetCatDicList = dsData.Tables("SP_ACQ_GET_CAT_DIC_LIST")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("SP_ACQ_GET_CAT_DIC_LIST")
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_ACQ_GET_CAT_DIC_LIST"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intID", OracleType.Number, 4)).Value = intID
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "SP_ACQ_GET_CAT_DIC_LIST")
                            GetCatDicList = dsData.Tables("SP_ACQ_GET_CAT_DIC_LIST")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("SP_ACQ_GET_CAT_DIC_LIST")
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        ' Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not oraCommand Is Nothing Then
                        oraCommand.Dispose()
                        oraCommand = Nothing
                    End If
                    If Not sqlCommand Is Nothing Then
                        sqlCommand.Dispose()
                        sqlCommand = Nothing
                    End If
                    If Not sqlConnection Is Nothing Then
                        sqlConnection.Close()
                        sqlConnection.Dispose()
                        sqlConnection = Nothing
                    End If
                    If Not oraConnection Is Nothing Then
                        oraConnection.Close()
                        oraConnection.Dispose()
                        oraConnection = Nothing
                    End If
                    If Not oraDataAdapter Is Nothing Then
                        oraDataAdapter.Dispose()
                        oraDataAdapter = Nothing
                    End If
                    If Not sqlDataAdapter Is Nothing Then
                        sqlDataAdapter.Dispose()
                        sqlDataAdapter = Nothing
                    End If
                    If Not dsData Is Nothing Then
                        dsData.Dispose()
                        dsData = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace