Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Circulation
    Public Class clsDRenew
        Inherits clsDBase

        ' ***************************************************************************************************
        ' Declare member variables
        ' ***************************************************************************************************
        Private intItemID As Integer


        ' ***************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' ***************************************************************************************************
        'ItemID property
        Public Property ItemID() As Integer
            Get
                Return intItemID
            End Get
            Set(ByVal Value As Integer)
                intItemID = Value
            End Set
        End Property

        ' ***************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' ***************************************************************************************************

        ' GetHolding method
        ' Purpose: Get cir_holding table
        ' Input:ItemID
        ' Output: datatable result
        Public Function GetHolding() As DataTable
            Try
                Call OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With SqlCommand
                            .CommandText = "Cir_tblReserveRequest_Sel"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                            Try
                                SqlDataAdapter.SelectCommand = SqlCommand
                                SqlDataAdapter.Fill(dsData, "tblCirHolding")
                                GetHolding = dsData.Tables("tblCirHolding")
                                dsData.Tables.Remove("tblCirHolding")
                            Catch sqlClientEx As SqlException
                                strErrorMsg = sqlClientEx.Message.ToString
                                intErrorCode = sqlClientEx.Number
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "ORACLE"
                        With oraCommand
                            .CommandText = "CIRCULATION.SP_CIR_HOLDING_SEL"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = intItemID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            Try
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsData, "tblLoanType")
                                GetHolding = dsData.Tables("tblLoanType")
                                dsData.Tables.Remove("tblLoanType")
                            Catch OraEx As OracleException
                                strErrorMsg = OraEx.Message.ToString
                                intErrorCode = OraEx.Code
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
                Call CloseConnection()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: Get information from Renews
        ' Input: UserID, Type, TypeValue
        ' Output: datatable 
        Public Function GetRenewInformation(ByVal bytType As Byte, ByVal strTypeVal As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spSelRenew"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                            .Add(New SqlParameter("@intType", SqlDbType.SmallInt)).Value = bytType
                            .Add(New SqlParameter("@strCodeVal", SqlDbType.VarChar, 50)).Value = strTypeVal
                        End With
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "RenewInformation")
                            GetRenewInformation = dsData.Tables("RenewInformation")
                            dsData.Tables.Remove("RenewInformation")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_CIR_GET_RENEW"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                            .Add(New OracleParameter("intType", OracleType.Number)).Value = bytType
                            .Add(New OracleParameter("strCodeVal", OracleType.VarChar, 50)).Value = strTypeVal
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "RenewInformation")
                            GetRenewInformation = dsData.Tables("RenewInformation")
                            dsData.Tables.Remove("RenewInformation")
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

        ' Purpose: RenewItems
        ' Input: intLoanID + bytAddTime + bytTimeUnit
        Public Sub RenewItems(ByVal intLoanID As Integer, ByVal bytAddTime As Byte, ByVal bytTimeUnit As Byte, ByVal strFixedDueDate As String)
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spRenewItem"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intLoanID", SqlDbType.Int)).Value = intLoanID
                            .Add(New SqlParameter("@intAddTime", SqlDbType.SmallInt)).Value = bytAddTime
                            .Add(New SqlParameter("@intTimeUnit", SqlDbType.SmallInt)).Value = bytTimeUnit
                            .Add(New SqlParameter("@strFixedDueDate", SqlDbType.VarChar, 30)).Value = strFixedDueDate
                        End With
                        Try
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SP_RENEW_ITEM"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intLoanID", OracleType.Number)).Value = intLoanID
                            .Add(New OracleParameter("intAddTime", OracleType.Number)).Value = bytAddTime
                            .Add(New OracleParameter("intTimeUnit", OracleType.Number)).Value = bytTimeUnit
                            .Add(New OracleParameter("strFixedDueDate", SqlDbType.VarChar, 30)).Value = strFixedDueDate
                        End With
                        Try
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
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
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
