' Name: clsDDenyReason
' Purpose: Deny reason
' Creator: Lent
' Created Date: 6/12/2004
' Modification History:
'   - 05/01/2005 by Oanhtn: review

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.ILL
    Public Class clsDDenyReason
        Inherits clsDBase

        ' ***********************************************************************************************
        ' Declare Private variables
        ' ***********************************************************************************************

        Private intID As Integer
        Private strCode As String
        Private strEngName As String
        Private strVietName As String

        ' ***********************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' ***********************************************************************************************

        ' ID property
        Public Property ID() As Integer
            Get
                Return (intID)
            End Get
            Set(ByVal Value As Integer)
                intID = Value
            End Set
        End Property

        ' Code property 
        Public Property Code() As String
            Get
                Return (strCode)

            End Get
            Set(ByVal Value As String)
                strCode = Value
            End Set
        End Property

        ' Code property 
        Public Property EngName() As String
            Get
                Return (strEngName)

            End Get
            Set(ByVal Value As String)
                strEngName = Value
            End Set
        End Property

        ' Code property 
        Public Property VietName() As String
            Get
                Return (strVietName)

            End Get
            Set(ByVal Value As String)
                strVietName = Value
            End Set
        End Property

        ' ***********************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' ***********************************************************************************************

        ' Purpose: Get deny reason
        ' Output: datatable result
        ' Creator: LENTA
        Public Function GetDenyReason() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_GET_RESPONSES"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetDenyReason = dsData.Tables("tblResult")
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
                        .CommandText = "Ill_spRespond_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                              
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetDenyReason = dsData.Tables("tblResult")
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

        ' Method: Create
        ' Purpose: Create deny reason
        ' Input: some main infor
        ' Output: integer value (0 if success, 1 if exist code)
        ' Creator: LENTA
        Public Function Create() As Integer
            Dim intOut As Integer = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spRespond_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strCode", SqlDbType.VarChar, 10)).Value = strCode
                                .Add(New SqlParameter("@strVietName", SqlDbType.NVarChar, 64)).Value = strVietName
                                .Add(New SqlParameter("@strEngName", SqlDbType.VarChar, 60)).Value = strEngName
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@intOut", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intOut = .Parameters("@intOut").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_CREATE_RESPONSES"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strCode", OracleType.VarChar, 10)).Value = strCode
                                .Add(New OracleParameter("strVietName", OracleType.NVarChar, 64)).Value = strVietName
                                .Add(New OracleParameter("strEngName", OracleType.VarChar, 64)).Value = strEngName
                                .Add(New OracleParameter("intOut", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intOut = .Parameters("intOut").Value
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Return intOut
        End Function

        ' Purpose: Update deny reason
        ' Input: some main infor
        ' Output: integer value (0 if success, 1 if exist code)
        ' Creator: LENTA
        Public Function Update() As Integer
            Dim intOut As Integer

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spRespond_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intID", SqlDbType.Int, 4)).Value = intID
                                .Add(New SqlParameter("@strCode", SqlDbType.VarChar, 10)).Value = strCode
                                .Add(New SqlParameter("@strVietName", SqlDbType.NVarChar, 64)).Value = strVietName
                                .Add(New SqlParameter("@strEngName", SqlDbType.VarChar, 60)).Value = strEngName
                                .Add(New SqlParameter("@intOut", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intOut = .Parameters("@intOut").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_UPDATE_RESPONSES"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intID", OracleType.Number, 4)).Value = intID
                                .Add(New OracleParameter("strCode", OracleType.VarChar, 10)).Value = strCode
                                .Add(New OracleParameter("strVietName", OracleType.NVarChar, 64)).Value = strVietName
                                .Add(New OracleParameter("strEngName", OracleType.VarChar, 64)).Value = strEngName
                                .Add(New OracleParameter("intOut", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intOut = .Parameters("intOut").Value
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Return intOut
        End Function

        ' Purpose: Delete deny reason
        ' Input: intID
        ' Creator: LENTA
        Public Function Delete() As Integer
            Dim intOut As Integer

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spRespond_Del"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intID", SqlDbType.Int, 4)).Value = intID
                            End With
                            .ExecuteNonQuery()
                            intOut = .Parameters("@intOut").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_DELETE_RESPONSES"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intID", OracleType.Number, 4)).Value = intID
                            End With
                            .ExecuteNonQuery()
                            intOut = .Parameters("intOut").Value
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Return intOut
        End Function

        ' Dispose method
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