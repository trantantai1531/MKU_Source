Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibOPAC.DataAccess.OPAC
    Public Class clsDItemCollection
        Inherits clsDBase

        ' *****************************************************************************************************
        ' Declare Private variables
        ' *****************************************************************************************************


        Private intIsAuthority As Integer
        Private strItemIDs As String

        ' IsAuthority property
        Public Property IsAuthority() As Integer
            Get
                Return intIsAuthority
            End Get
            Set(ByVal Value As Integer)
                intIsAuthority = Value
            End Set
        End Property
        ' ItemIDs property
        Public Property ItemIDs() As String
            Get
                Return strItemIDs
            End Get
            Set(ByVal Value As String)
                strItemIDs = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' GetItemMainInfor method
        ' Purpose: get all main information of item (Leader, ItemType, ItemMedia...)
        ' Input: string value of ItemIDs
        ' Output: Datatable
        Public Function GetItemMainInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.Lib_spItem_SelMainInforOfItem"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIsAuthority", OracleType.Number)).Value = intIsAuthority
                            .Parameters.Add(New OracleParameter("strItemIDs", OracleType.VarChar, 1000)).Value = strItemIDs
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetItemMainInfor = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spItem_SelMainInforOfItem"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIsAuthority", SqlDbType.Int)).Value = intIsAuthority
                            .Parameters.Add(New SqlParameter("@strItemIDs", SqlDbType.VarChar, 1000)).Value = strItemIDs
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemMainInfor = dsData.Tables("tblResult")
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


        ' GetItemDetailInfor method
        ' Purpose: get all main information of item (Leader, ItemType, ItemMedia...)
        ' Input: string value of ItemIDs
        ' Output: Datatable
        Public Function GetItemDetailInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.Lib_spItem_SelDetailInforOfItem"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIsAuthority", OracleType.Number)).Value = intIsAuthority
                            .Parameters.Add(New OracleParameter("strItemIDs", OracleType.VarChar, 1000)).Value = strItemIDs
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetItemDetailInfor = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spItem_SelDetailInforOfItem"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIsAuthority", SqlDbType.Int)).Value = intIsAuthority
                            .Parameters.Add(New SqlParameter("@strItemIDs", SqlDbType.VarChar)).Value = strItemIDs
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemDetailInfor = dsData.Tables("tblResult")
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


        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                ' Release unmanaged resources.
                If Not dsData Is Nothing Then
                    dsData.Dispose()
                    dsData = Nothing
                End If
                If Not oraConnection Is Nothing Then
                    oraConnection.Dispose()
                    oraConnection = Nothing
                End If
                If Not oraCommand Is Nothing Then
                    oraCommand.Dispose()
                    oraCommand = Nothing
                End If
                If Not SqlConnection Is Nothing Then
                    SqlConnection.Dispose()
                    SqlConnection = Nothing
                End If
                If Not SqlCommand Is Nothing Then
                    SqlCommand.Dispose()
                    SqlCommand = Nothing
                End If
            Finally
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace