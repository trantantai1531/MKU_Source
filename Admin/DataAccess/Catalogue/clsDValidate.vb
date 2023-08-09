' Purpose: process form
' Creator: KhoaNA
' Created Date: 29/04/2004
' Modification history:

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace Libol60.DataAccess.Catalogue
    Public Class clsDValidate
        Inherits clsDField

        ' GetMarcAuthorityField method
        Public Function GetMarcAuthorityField() As DataTable
            Call OpenConnection()
            Select Case UCase(strdbserver)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_MARC_AUTHORITY_FIELD_SELECT"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        .ExecuteNonQuery()
                    End With
                    oraDataAdapter.SelectCommand = oraCommand
                    oraDataAdapter.Fill(dsData, "tblMarcAutority")
                    GetMarcAuthorityField = dsData.Tables("tblMarcAutority")
                    dsData.Tables.Remove("tblMarcAutority")
                    oraCommand.Parameters.Clear()
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "SP_CATA_MARC_AUTHORITY_FIELD_SELECT"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strFieldCode", SqlDbType.VarChar, 3000)).Value = strFieldCode
                        .ExecuteNonQuery()
                    End With
                    SqlDataAdapter.SelectCommand = SqlCommand
                    SqlDataAdapter.Fill(dsData, "tblMarcAutority")
                    GetMarcAuthorityField = dsData.Tables("tblMarcAutority")
                    dsData.Tables.Remove("tblMarcAutority")
                    SqlCommand.Parameters.Clear()
            End Select
            Call CloseConnection()
        End Function

        ' GetValidateDataInfo 
        Public Function GetValidateDataInfo() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_GETINDICATORS"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        .ExecuteNonQuery()
                    End With
                    oraDataAdapter.SelectCommand = oraCommand
                    oraDataAdapter.Fill(dsData, "tblItemQueue")
                    GetValidateDataInfo = dsData.Tables("tblItemQueue")
                    dsData.Tables.Remove("tblItemQueue")
                    oraCommand.Parameters.Clear()
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "SP_GETINDICATORS"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strFieldCode", SqlDbType.VarChar, 3000)).Value = strFieldCode
                        .ExecuteNonQuery()
                    End With
                    SqlDataAdapter.SelectCommand = SqlCommand
                    SqlDataAdapter.Fill(dsData, "tblItemQueue")
                    GetValidateDataInfo = dsData.Tables("tblItemQueue")
                    dsData.Tables.Remove("tblItemQueue")
                    SqlCommand.Parameters.Clear()
            End Select
            Call CloseConnection()
        End Function
    End Class
End Namespace