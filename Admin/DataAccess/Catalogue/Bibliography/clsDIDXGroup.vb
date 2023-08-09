Imports System.Data
Imports eMicLibAdmin.DataAccess
Imports eMicLibAdmin.DataAccess.Common
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Catalogue
    Public Class clsDIDXGroup
        Inherits clsDBase

        ' *****************************************************************************************************
        ' Declare Private variables
        ' *****************************************************************************************************

        Private strIDs As String
        Private strItemIDs As String
        Private intNORs As Integer
        Private intPart_Index As Integer
        Private intPosition As Integer
        Private strQString As String
        Private strSQL As String
        Private strGroupName As String
        Private intGroupID As Integer

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' IDs Property
        Public Property IDs() As String
            Get
                Return strIDs
            End Get
            Set(ByVal Value As String)
                strIDs = Value
            End Set
        End Property

        ' ItemIDs Property
        Public Property ItemIDs() As String
            Get
                Return strItemIDs
            End Get
            Set(ByVal Value As String)
                strItemIDs = Value
            End Set
        End Property

        ' NORs Property
        Public Property NORs() As Integer
            Get
                Return intNORs
            End Get
            Set(ByVal Value As Integer)
                intNORs = Value
            End Set
        End Property

        ' QString Property
        Public Property QString() As String
            Get
                Return strQString
            End Get
            Set(ByVal Value As String)
                strQString = Value
            End Set
        End Property

        ' GroupID Property
        Public Property GroupID() As Integer
            Get
                Return intGroupID
            End Get
            Set(ByVal Value As Integer)
                intGroupID = Value
            End Set
        End Property

        ' GroupName Property
        Public Property GroupName() As String
            Get
                Return strGroupName
            End Get
            Set(ByVal Value As String)
                strGroupName = Value
            End Set
        End Property

        ' SQL Property
        Public Property SQL() As String
            Get
                Return strSQL
            End Get
            Set(ByVal Value As String)
                strSQL = Value
            End Set
        End Property

        ' Position Property
        Public Property Position() As Integer
            Get
                Return intPosition
            End Get
            Set(ByVal Value As Integer)
                intPosition = Value
            End Set
        End Property

        ' Part_Index Property
        Public Property Part_Index() As Integer
            Get
                Return intPart_Index
            End Get
            Set(ByVal Value As Integer)
                intPart_Index = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' IDXDetailInsert method
        ' Purpose: Create detail index records
        Public Sub IDXDetailInsert()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spBibliographyDetail_Ins"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intID", SqlDbType.Int)).Value = CInt(strIDs)
                            .Add(New SqlParameter("@strItemIDs", SqlDbType.VarChar, 1000)).Value = strItemIDs
                            .Add(New SqlParameter("@intNORs", SqlDbType.Int)).Value = intNORs
                            .Add(New SqlParameter("@intPart_Index", SqlDbType.Int)).Value = intPart_Index
                            .Add(New SqlParameter("@intPosition", SqlDbType.Int)).Value = intPosition
                            .Add(New SqlParameter("@strQString", SqlDbType.NVarChar, 4000)).Value = strQString
                            .Add(New SqlParameter("@strSQL", SqlDbType.NVarChar, 4000)).Value = strSQL
                            .Add(New SqlParameter("@strGroupName", SqlDbType.NVarChar, 30)).Value = strGroupName
                            .Add(New SqlParameter("@intGroupID", SqlDbType.Int)).Value = intGroupID
                        End With
                        Try
                            .ExecuteNonQuery()
                        Catch ex As SqlException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "CATALOGUE.SP_IDX_DETAIL_INS"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intID", OracleType.Number)).Value = CInt(strIDs)
                            .Add(New OracleParameter("strItemIDs", OracleType.VarChar, 1000)).Value = strItemIDs
                            .Add(New OracleParameter("intNORs", OracleType.Number)).Value = intNORs
                            .Add(New OracleParameter("intPart_Index", OracleType.Number)).Value = intPart_Index
                            .Add(New OracleParameter("intPosition", OracleType.Number)).Value = intPosition
                            .Add(New OracleParameter("strQString", OracleType.VarChar, 4000)).Value = strQString
                            .Add(New OracleParameter("strSQL", OracleType.VarChar, 4000)).Value = strSQL
                            .Add(New OracleParameter("strGroupName", OracleType.VarChar, 30)).Value = strGroupName
                            .Add(New OracleParameter("intGroupID", OracleType.Number)).Value = intGroupID
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

        ' IDXDetailDelete method
        Public Sub IDXDetailDelete()
            Call OpenConnection()
            Select Case UCase(strDbServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spBibliographyDetail_DelIDX"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intIDIdx", SqlDbType.Int)).Value = strIDs
                            .Add(New SqlParameter("@intIDGroup", SqlDbType.Int)).Value = intGroupID
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
                        .CommandText = "CATALOGUE.SP_IDX_DETAIL_DEL"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intIDIdx", OracleType.Number)).Value = strIDs
                            .Add(New OracleParameter("intIDGroup", OracleType.Number)).Value = intGroupID
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

        ' IDXDetailRetrieve method
        Public Function IDXDetailRetrieve() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spBibliographyDetail_Sel"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strIDs", SqlDbType.VarChar, 1000)).Value = strIDs
                            .Add(New SqlParameter("@intGroupID", SqlDbType.Int)).Value = intGroupID
                            .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                        End With
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            IDXDetailRetrieve = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_IDX_DETAIL_SEL"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("strIDs", OracleType.VarChar, 1000)).Value = strIDs
                            .Add(New OracleParameter("intGroupID", OracleType.Number)).Value = intGroupID
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            oraDataAdapter.SelectCommand = oracommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            IDXDetailRetrieve = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
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

        ' IDXDetailRetrieveDist method
        Public Function IDXDetailRetrieveDist() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spBibliographyDetail_SelDist"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strIDs", SqlDbType.VarChar, 1000)).Value = strIDs
                            .Add(New SqlParameter("@intGroupID", SqlDbType.Int)).Value = intGroupID
                        End With
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            IDXDetailRetrieveDist = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_IDX_DETAIL_DIST_SEL"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("strIDs", OracleType.VarChar, 1000)).Value = strIDs
                            .Add(New OracleParameter("intGroupID", OracleType.Number)).Value = intGroupID
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            oraDataAdapter.SelectCommand = oracommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            IDXDetailRetrieveDist = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
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

        ' IDXDetailRetrieveDistLink method
        Public Function IDXDetailRetrieveDistLink() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spBibliographyDetail_SelDistLink"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strIDs", SqlDbType.VarChar, 1000)).Value = strIDs
                            .Add(New SqlParameter("@intGroupID", SqlDbType.Int)).Value = intGroupID
                        End With
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            IDXDetailRetrieveDistLink = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_IDX_DETAIL_DIST_LINK_SEL"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("strIDs", OracleType.VarChar, 1000)).Value = strIDs
                            .Add(New OracleParameter("intGroupID", OracleType.Number)).Value = intGroupID
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            oraDataAdapter.SelectCommand = oracommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            IDXDetailRetrieveDistLink = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
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

        ' Method: Dispose
        ' Purpose: Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                Call MyBase.Dispose(isDisposing)
            Finally
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace