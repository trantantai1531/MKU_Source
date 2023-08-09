Imports eMicLibAdmin.DataAccess
Imports eMicLibAdmin.DataAccess.Common
Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Catalogue
    Public Class clsDClassification
        Inherits clsDBase

        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************
        Private strAccessEntry As String
        Private intTypeID As Integer

        ' *******************************************************************************************************
        ' End declare variables
        ' Declare properties here
        ' *******************************************************************************************************
        ' IDs property

        ' AccessEntry property
        Public Property AccessEntry() As String
            Get
                Return strAccessEntry
            End Get
            Set(ByVal Value As String)
                strAccessEntry = Value
            End Set
        End Property

        ' TypeID property
        Public Property TypeID() As Integer
            Get
                Return intTypeID
            End Get
            Set(ByVal Value As Integer)
                intTypeID = Value
            End Set
        End Property



        ' Method: GetClassification
        ' Purpose: Get classification data
        ' Input: ClassificationID, AccessEntry
        ' Output: Datatable result
        Public Function GetClassification() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        ' Add new
                        .CommandText = "Lib_spClassification_SelData"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intTypeID", SqlDbType.Int)).Value = intTypeID
                                .Add(New SqlParameter("@strAccessEntry", SqlDbType.NVarChar, 200)).Value = strAccessEntry
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsdata, "tblResult")
                            GetClassification = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch ex As SqlException
                            strerrormsg = ex.Message.ToString
                            interrorcode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oracommand
                        ' Add new
                        .CommandText = "CATALOGUE.SP_CATA_GET_CLASSIFICATION_DT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intTypeID", OracleType.Number)).Value = intTypeID
                                .Add(New OracleParameter("strAccessEntry", OracleType.VarChar, 200)).Value = strAccessEntry
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsdata, "tblResult")
                            GetClassification = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch ex As OracleException
                            strerrormsg = ex.Message
                            interrorcode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Method: Dispose
        ' Purpose: Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                Call MyBase.Dispose(isDisposing)
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace