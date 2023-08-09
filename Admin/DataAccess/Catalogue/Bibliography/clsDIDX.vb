Imports eMicLibAdmin.DataAccess
Imports eMicLibAdmin.DataAccess.Common
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Catalogue
    Public Class clsDIDX
        Inherits clsDBase

        ' *****************************************************************************************************
        ' Declare Private variables
        ' *****************************************************************************************************

        Private strIDs As String
        Private strTitle As String
        Private strGroupBy As String
        Private strUPDType As String
        Private intNORs As Integer
        Private intGroupID As Integer
        Private intTORsAdd As Integer
        Private intGroupIDOUT As Integer
        Private intPositionOUT As Integer

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' IDs property
        Public Property IDs() As String
            Get
                Return strIDs
            End Get
            Set(ByVal Value As String)
                strIDs = Value
            End Set
        End Property

        ' Title property
        Public Property Title() As String
            Get
                Return strTitle
            End Get
            Set(ByVal Value As String)
                strTitle = Value
            End Set
        End Property

        ' GroupBy property
        Public Property GroupBy() As String
            Get
                Return strGroupBy
            End Get
            Set(ByVal Value As String)
                strGroupBy = Value
            End Set
        End Property

        ' TORsAdd property
        Public Property TORsAdd() As Integer
            Get
                Return intTORsAdd
            End Get
            Set(ByVal Value As Integer)
                intTORsAdd = Value
            End Set
        End Property

        ' NORs property
        Public Property NORs() As Integer
            Get
                Return intNORs
            End Get
            Set(ByVal Value As Integer)
                intNORs = Value
            End Set
        End Property

        ' GroupID property
        Public Property GroupID() As Integer
            Get
                Return intGroupID
            End Get
            Set(ByVal Value As Integer)
                intGroupID = Value
            End Set
        End Property

        ' UPDType property
        Public Property UPDType() As String
            Get
                Return strUPDType
            End Get
            Set(ByVal Value As String)
                strUPDType = Value
            End Set
        End Property

        ' PositionOUT property
        Public ReadOnly Property PositionOUT() As Integer
            Get
                Return intPositionOUT
            End Get
        End Property

        ' GroupIDOUT property
        Public ReadOnly Property GroupIDOUT() As Integer
            Get
                Return intGroupIDOUT
            End Get
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' IDXDelete method
        Public Sub IDXDelete()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spBibliography_DelIDX"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strIDs", SqlDbType.VarChar, 1000)).Value = strIDs
                        End With
                        Try
                            .ExecuteNonQuery()
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_IDX_DEL"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("strIDs", OracleType.VarChar, 1000)).Value = strIDs
                        End With
                        Try
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' IDXInsert method
        Public Function IDXInsert() As Integer
            Call OpenConnection()
            Dim intOut As Integer = 0
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spBibliography_InsIDX"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strTitle", SqlDbType.NVarChar, 200)).Value = strTitle
                            .Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                            .Add(New SqlParameter("@strGroupBy", SqlDbType.NVarChar, 30)).Value = strGroupBy
                            .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            .Add(New SqlParameter("@intOut", SqlDbType.Int)).Direction = ParameterDirection.Output

                        End With
                        Try
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
                        .CommandText = "CATALOGUE.SP_IDX_INS"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("strTitle", OracleType.VarChar, 200)).Value = strTitle
                            .Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                            .Add(New OracleParameter("strGroupBy", OracleType.VarChar, 30)).Value = strGroupBy

                        End With
                        Try
                            .ExecuteNonQuery()

                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Return intOut
        End Function

        ' IDXRetrieve method
        Public Function IDXRetrieve() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spBibliography_SelIDX"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strIDs", SqlDbType.VarChar, 1000)).Value = strIDs
                            .Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                            .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                        End With
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            .ExecuteNonQuery()
                            sqlDataAdapter.Fill(dsData, "tblIDX")
                            IDXRetrieve = dsData.Tables("tblIDX")
                            dsData.Tables.Remove("tblIDX")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_IDX_SEL"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            .Add(New OracleParameter("strIDs", OracleType.VarChar, 1000)).Value = strIDs
                            .Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                        End With
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblIDX")
                            IDXRetrieve = dsData.Tables("tblIDX")
                            dsData.Tables.Remove("tblIDX")
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

        ' IDXChange method
        Public Sub IDXChange()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spBibliography_ChangeIndex"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strUPDType", SqlDbType.VarChar, 30)).Value = strUPDType
                            .Add(New SqlParameter("@intID", SqlDbType.Int)).Value = strIDs
                            .Add(New SqlParameter("@intGroupID", SqlDbType.Int)).Value = intGroupID
                            .Add(New SqlParameter("@intNORs", SqlDbType.Int)).Value = intNORs
                            .Add(New SqlParameter("@intPositionOUT", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .Add(New SqlParameter("@intGroupIDOUT", SqlDbType.Int)).Direction = ParameterDirection.Output
                        End With
                        Try
                            .ExecuteNonQuery()
                            intPositionOUT = .Parameters("@intPositionOUT").Value
                            intGroupIDOUT = .Parameters("@intGroupIDOUT").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_IDX_CHANGE"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("strUPDType", OracleType.VarChar, 30)).Value = strUPDType
                            .Add(New OracleParameter("intID", OracleType.Number)).Value = strIDs
                            .Add(New OracleParameter("intGroupID", OracleType.Number)).Value = intGroupID
                            .Add(New OracleParameter("intNORs", OracleType.Number)).Value = intNORs
                            .Add(New OracleParameter("intPositionOUT", OracleType.Number)).Direction = ParameterDirection.Output
                            .Add(New OracleParameter("intGroupIDOUT", OracleType.Number)).Direction = ParameterDirection.Output
                        End With
                        Try
                            .ExecuteNonQuery()
                            intPositionOUT = .Parameters("intPositionOUT").Value
                            intGroupIDOUT = .Parameters("intGroupIDOUT").Value
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' IDXUpdate method
        Public Function IDXUpdate() As Integer
            Call OpenConnection()
            Dim intOut As Integer = 0
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spBibliography_UpdIDX"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intID", SqlDbType.Int)).Value = strIDs
                            .Add(New SqlParameter("@strTitle", SqlDbType.NVarChar, 200)).Value = strTitle
                            .Add(New SqlParameter("@intTORsAdd", SqlDbType.Int)).Value = intTORsAdd
                            .Add(New SqlParameter("@strGroupBy", SqlDbType.NVarChar, 30)).Value = strGroupBy
                            .Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                            .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            .Add(New SqlParameter("@intOut", SqlDbType.Int)).Direction = ParameterDirection.Output
                        End With
                        Try
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
                        .CommandText = "CATALOGUE.SP_IDX_UPD"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intID", OracleType.Number)).Value = strIDs
                            .Add(New OracleParameter("strTitle", OracleType.NVarChar, 200)).Value = strTitle
                            .Add(New OracleParameter("intTORsAdd", OracleType.Number)).Value = intTORsAdd
                            .Add(New OracleParameter("strGroupBy", OracleType.VarChar, 30)).Value = strGroupBy
                        End With
                        Try
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Return intOut
        End Function

        ' Method: Dispose
        ' Purpose: Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                Call MyBase.Dispose(True)
            Finally
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace