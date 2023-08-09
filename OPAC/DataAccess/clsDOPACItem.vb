Imports System
Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibOPAC.DataAccess.OPAC
    Public Class clsDOPACItem
        Inherits clsDBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private intItemID As Integer
        Private strIssueNo As String
        Private intIssueID As Integer
        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
        ' ItemID property
        Public Property ItemID() As Integer
            Get
                Return intItemID
            End Get
            Set(ByVal Value As Integer)
                intItemID = Value
            End Set
        End Property
        Public Property IssueNo() As String
            Get
                Return strIssueNo
            End Get
            Set(ByVal Value As String)
                strIssueNo = Value
            End Set
        End Property
        'IssueID property
        Public Property IssueID() As Integer
            Get
                Return intIssueID
            End Get
            Set(ByVal Value As Integer)
                intIssueID = Value
            End Set
        End Property

        Public Function GetCommentsByPatron() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spComment_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblCommentPatron")
                            GetCommentsByPatron = dsData.Tables("tblCommentPatron")
                            dsData.Tables.Remove("tblCommentPatron")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spComment_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = intItemID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblCommentPatron")
                            GetCommentsByPatron = dsData.Tables("tblCommentPatron")
                            dsData.Tables.Remove("tblCommentPatron")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function


        ' Purpose: Read Comment of information of Patron
        ' Input: ItemID
        ' Output: DataTable
        ' Created by: PhuongTT-2014.09.07
        Public Function getCommentsOfPatronByItem(Optional ByVal intPageNum As Integer = 1, Optional ByVal intPageSize As Integer = 10) As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Opac_spComment_GetByItem"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                            .Parameters.Add(New SqlParameter("@intPageNum", SqlDbType.Int)).Value = intPageNum
                            .Parameters.Add(New SqlParameter("@intPageSize", SqlDbType.Int)).Value = intPageSize
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblCommentsOfPatronByItem")
                            getCommentsOfPatronByItem = dsData.Tables("tblCommentsOfPatronByItem")
                            dsData.Tables.Remove("tblCommentsOfPatronByItem")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spComment_GetByItem"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = intItemID
                            .Parameters.Add(New OracleParameter("intPageNum", OracleType.Number)).Value = intPageNum
                            .Parameters.Add(New OracleParameter("intPageSize", OracleType.Number)).Value = intPageSize
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblCommentsOfPatronByItem")
                            getCommentsOfPatronByItem = dsData.Tables("tblCommentsOfPatronByItem")
                            dsData.Tables.Remove("tblCommentsOfPatronByItem")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        ' Method: GetArticleInfor
        ' Purpose: get infor of the current Article
        ' Input: IssueID
        ' Output: datatable result
        Public Function GetArticleInfor() As DataTable
            Call OpenConnection()

            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.Ser_spArticle_SelByIssueId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intIssueID", OracleType.Number, 10)).Value = intIssueID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsdata, "tblResult")
                            GetArticleInfor = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ser_spArticle_SelByIssueId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intIssueID", SqlDbType.Int, 5)).Value = CInt(intIssueID)
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsdata, "tblResult")
                            GetArticleInfor = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
        End Function

        Public Function GetIssueID() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spIssue_GetByID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strIssueNo", SqlDbType.VarChar)).Value = strIssueNo
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblIssueID")
                            GetIssueID = dsData.Tables("tblIssueID")
                            dsData.Tables.Remove("tblIssueID")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spIssue_GetByID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strIssueNo", OracleType.VarChar)).Value = strIssueNo
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = intItemID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblIssueID")
                            GetIssueID = dsData.Tables("tblIssueID")
                            dsData.Tables.Remove("tblIssueID")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()

        End Function

        ' Purpose: Read Title of ItemID
        ' Input: ItemID
        ' Output: DataTable
        ' Created by: dgsoft
        Public Function GetItemTite() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spItemTitle_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblItemTitle")
                            GetItemTite = dsData.Tables("tblItemTitle")
                            dsData.Tables.Remove("tblItemTitle")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spItemTitle_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = intItemID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblItemTitle")
                            GetItemTite = dsData.Tables("tblItemTitle")
                            dsData.Tables.Remove("tblItemTitle")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        Public Function GetCountItemByTypeID(ByVal intTypeID As Integer) As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Opac_spLib_Item_CountByTypeID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intTypeID", SqlDbType.Int)).Value = intTypeID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetCountItemByTypeID = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    'With oraCommand
                    '    .CommandText = "OPAC.Opac_spItemTitle_Get"
                    '    .CommandType = CommandType.StoredProcedure
                    '    Try
                    '        .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = intItemID
                    '        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                    '        oraDataAdapter.SelectCommand = oraCommand
                    '        oraDataAdapter.Fill(dsData, "tblItemTitle")
                    '        GetItemTite = dsData.Tables("tblItemTitle")
                    '        dsData.Tables.Remove("tblItemTitle")
                    '    Catch OraEx As OracleException
                    '        strErrorMsg = OraEx.Message.ToString
                    '        intErrorCode = OraEx.Code
                    '    Finally
                    '        .Parameters.Clear()
                    '    End Try
                    'End With
            End Select
            Me.CloseConnection()
        End Function

        Public Function GetReceivedYear() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.Ser_spIssue_SelReceiveYears"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intLocationID", OracleType.Number)).Value = 0
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = intItemID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsdata, "tblResult")
                            GetReceivedYear = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ser_spIssue_SelReceiveYears"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = 0
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsdata, "tblResult")
                            GetReceivedYear = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function
        ' Purpose: Get some information about Item,serials,holding
        ' Output: DataTable 
        ' Created by: dgsoft2016
        ' Update by: dgsoft
        Public Function GetGeneralInfor(Optional ByVal intLibID As Integer = 0) As DataTable
            Try
                Me.OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With sqlCommand
                            .CommandText = "Opac_spStatInfo_Get"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                sqlDataAdapter.SelectCommand = sqlCommand
                                sqlDataAdapter.Fill(dsData, "tblResult")
                                GetGeneralInfor = dsData.Tables("tblResult")
                            Catch sqlClientEx As SqlException
                                strErrorMsg = sqlClientEx.Message.ToString
                                intErrorCode = sqlClientEx.Number
                            Finally
                                .Parameters.Clear()
                                dsData.Tables.Remove("tblResult")
                            End Try
                        End With
                    Case "ORACLE"
                        With oraCommand
                            .CommandText = "OPAC.Opac_spStatInfo_Get"
                            .CommandType = CommandType.StoredProcedure
                            With .Parameters
                                .Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            Try
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsData, "tblResult")
                                GetGeneralInfor = dsData.Tables("tblResult")
                            Catch OraEx As OracleException
                                strErrorMsg = OraEx.Message.ToString
                                intErrorCode = OraEx.Code
                            Finally
                                dsData.Tables.Remove("tblResult")
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
                Me.CloseConnection()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: GetBestItems
        ' Input:  intSecuredOPAC,intAccLevel,intNumberDay,intTop
        ' Output: DataTable 
        Public Function GetBestItems(ByVal intSecuredOPAC As Integer, ByVal intAccLevel As Integer, ByVal intNumberDay As Integer, ByVal intTop As Integer, Optional ByVal intLibID As Integer = 0) As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Opac_spBestItem_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@bitSECUREDOPAC", SqlDbType.Bit)).Value = intSecuredOPAC
                                .Add(New SqlParameter("@intAccessLevel", SqlDbType.Int)).Value = intAccLevel
                                .Add(New SqlParameter("@intTop", SqlDbType.Int, 3)).Value = intTop
                                .Add(New SqlParameter("@intNumberDay", SqlDbType.Int, 4)).Value = intNumberDay
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetBestItems = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spBestItem_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("bitSECUREDOPAC", OracleType.Number)).Value = intSecuredOPAC
                                .Add(New OracleParameter("intAccessLevel", OracleType.Number)).Value = intAccLevel
                                .Add(New OracleParameter("intTop", OracleType.Number)).Value = intTop
                                .Add(New OracleParameter("intNumberDay", OracleType.Number)).Value = intNumberDay
                                .Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetBestItems = dsData.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            dsData.Tables.Remove("tblResult")
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        Public Function GetNewItem(ByVal intSecuredOPAC As Integer, ByVal intAccLevel As Integer, ByVal intNumberDay As Integer, ByVal intTop As Integer, Optional ByVal intLibID As Integer = 0) As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Opac_spGetNewItem"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@bitSECUREDOPAC", SqlDbType.Bit)).Value = intSecuredOPAC
                                .Add(New SqlParameter("@intAccessLevel", SqlDbType.Int)).Value = intAccLevel
                                .Add(New SqlParameter("@intTop", SqlDbType.Int, 3)).Value = intTop
                                .Add(New SqlParameter("@intNumberDay", SqlDbType.Int, 4)).Value = intNumberDay
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetNewItem = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spGetNewItem"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("bitSECUREDOPAC", OracleType.Number)).Value = intSecuredOPAC
                            .Add(New OracleParameter("intAccessLevel", OracleType.Number)).Value = intAccLevel
                            .Add(New OracleParameter("intTop", OracleType.Number)).Value = intTop
                            .Add(New OracleParameter("intNumberDay", OracleType.Number)).Value = intNumberDay
                            .Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetNewItem = dsData.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            dsData.Tables.Remove("tblResult")
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        Public Function GetMARC() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.Lib_spItem_SelContentsOfItem"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIsAuthority", OracleType.Number)).Value = 0
                            .Parameters.Add(New OracleParameter("strItemIDs", OracleType.Number)).Value = intItemID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblItemContents")
                            GetMARC = dsData.Tables("tblItemContents")
                            dsData.Tables.Remove("tblItemContents")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spItem_SelContentsOfItem"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIsAuthority", SqlDbType.Int)).Value = 0
                            .Parameters.Add(New SqlParameter("@strItemIDs", SqlDbType.Int)).Value = intItemID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblItemContents")
                            GetMARC = dsData.Tables("tblItemContents")
                            dsData.Tables.Remove("tblItemContents")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        Public Function GetFileCataloger() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItem_SelCataloguerOfItem"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblItemContents")
                            GetFileCataloger = dsData.Tables("tblItemContents")
                            dsData.Tables.Remove("tblItemContents")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        ' GetItemMainInfor method
        ' Purpose: get all main information of item (Leader, ItemType, ItemMedia...)
        ' Input: string value of ItemIDs
        ' Output: Datatable
        Public Function GetItemMainInfor() As DataTable
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.Lib_spItem_SelMainInforOfItem"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIsAuthority", OracleType.Number)).Value = 0
                            .Parameters.Add(New OracleParameter("strItemIDs", OracleType.VarChar, 1000)).Value = intItemID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblItemMainInfor")
                            GetItemMainInfor = dsData.Tables("tblItemMainInfor")
                            dsData.Tables.Remove("tblItemMainInfor")
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
                            .Parameters.Add(New SqlParameter("@intIsAuthority", SqlDbType.Int)).Value = 0
                            .Parameters.Add(New SqlParameter("@strItemIDs", SqlDbType.VarChar, 1000)).Value = intItemID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblItemMainInfor")
                            GetItemMainInfor = dsData.Tables("tblItemMainInfor")
                            dsData.Tables.Remove("tblItemMainInfor")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        ' GetItemDetailInfor method
        ' Purpose: get all main information of item (Leader, ItemType, ItemMedia...)
        ' Input: string value of ItemIDs
        ' Output: Datatable
        Public Function GetItemDetailInfor() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.Lib_spItem_SelDetailInforOfItem"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIsAuthority", OracleType.Number)).Value = 0
                            .Parameters.Add(New OracleParameter("strItemIDs", OracleType.VarChar, 1000)).Value = intItemID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblItemDetailInfor")
                            GetItemDetailInfor = dsData.Tables("tblItemDetailInfor")
                            dsData.Tables.Remove("tblItemDetailInfor")
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
                            .Parameters.Add(New SqlParameter("@intIsAuthority", SqlDbType.Int)).Value = 0
                            .Parameters.Add(New SqlParameter("@strItemIDs", SqlDbType.VarChar)).Value = intItemID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblItemDetailInfor")
                            GetItemDetailInfor = dsData.Tables("tblItemDetailInfor")
                            dsData.Tables.Remove("tblItemDetailInfor")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        ' GetItemDetailInfor method
        ' Purpose: get all main information of item (Leader, ItemType, ItemMedia...)
        ' Input: string value of ItemIDs
        ' Output: Datatable
        Public Function GetItemDetailInforHighlight(Optional ByVal strWord As String = "") As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.Cat_spDetailInforOfItemHighLight_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIsAuthority", OracleType.Number)).Value = 0
                            .Parameters.Add(New OracleParameter("strItemIDs", OracleType.VarChar, 1000)).Value = intItemID
                            .Parameters.Add(New OracleParameter("strWord", OracleType.NVarChar, 4000)).Value = strWord
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblItemDetailInforHighlight")
                            GetItemDetailInforHighlight = dsData.Tables("tblItemDetailInforHighlight")
                            dsData.Tables.Remove("tblItemDetailInforHighlight")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spDetailInforOfItemHighLight_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIsAuthority", SqlDbType.Int)).Value = 0
                            .Parameters.Add(New SqlParameter("@strItemIDs", SqlDbType.VarChar)).Value = intItemID
                            .Parameters.Add(New SqlParameter("@strWord", SqlDbType.NVarChar)).Value = strWord
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblItemDetailInforHighlight")
                            GetItemDetailInforHighlight = dsData.Tables("tblItemDetailInforHighlight")
                            dsData.Tables.Remove("tblItemDetailInforHighlight")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        ' GetItemDetailInfor method
        ' Purpose: get all main information of item (Leader, ItemType, ItemMedia...)
        ' Input: string value of ItemIDs
        ' Output: Datatable
        Public Function GetItemById() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)

                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItem_SelByID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblGetItemById")
                            GetItemById = dsData.Tables("tblGetItemById")
                            dsData.Tables.Remove("tblGetItemById")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        ' GetRecordTypes method
        ' Purpose: Get all recordtypes
        ' Output: Datatable result
        Public Function GetRecordTypes() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "COMMON.Cat_spDicRecordType_SelAll"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetRecordTypes = dsData.Tables("tblResult")
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
                        .CommandText = "Cat_spDicRecordType_SelAll"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetRecordTypes = dsData.Tables("tblResult")
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
        Public Function GetAccessLevel() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Opac_spLibItem_GetAccessLevel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblRelatedTerms")
                            GetAccessLevel = dsData.Tables("tblRelatedTerms")
                            dsData.Tables.Remove("tblRelatedTerms")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"

            End Select
            Me.CloseConnection()
        End Function
        Public Function GetRelatedTerms() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spRelatedTerm"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblRelatedTerms")
                            GetRelatedTerms = dsData.Tables("tblRelatedTerms")
                            dsData.Tables.Remove("tblRelatedTerms")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spRelatedTerm"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = intItemID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblRelatedTerms")
                            GetRelatedTerms = dsData.Tables("tblRelatedTerms")
                            dsData.Tables.Remove("tblRelatedTerms")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        Public Function GetRelationBooks(ByVal intTop As Integer) As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spRelatedBook"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                            .Parameters.Add(New SqlParameter("@intTop", SqlDbType.Int)).Value = intTop
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblRelationBooks")
                            GetRelationBooks = dsData.Tables("tblRelationBooks")
                            dsData.Tables.Remove("tblRelationBooks")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spRelatedBook"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = intItemID
                            .Parameters.Add(New OracleParameter("intTop", OracleType.Number)).Value = intTop
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblRelationBooks")
                            GetRelationBooks = dsData.Tables("tblRelationBooks")
                            dsData.Tables.Remove("tblRelationBooks")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        Public Function GetEData() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spGetData"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblEData")
                            GetEData = dsData.Tables("tblEData")
                            dsData.Tables.Remove("tblEData")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spGetData"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = intItemID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblEData")
                            GetEData = dsData.Tables("tblEData")
                            dsData.Tables.Remove("tblEData")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        Public Function GetRelationTitles() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        '.CommandText = "Opac_spTitle_GetRelation"
                        .CommandText = "Opac_spTitle_GetRelation2"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblRelationTitles")
                            GetRelationTitles = dsData.Tables("tblRelationTitles")
                            dsData.Tables.Remove("tblRelationTitles")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spTitle_GetRelation"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = intItemID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblRelationTitles")
                            GetRelationTitles = dsData.Tables("tblRelationTitles")
                            dsData.Tables.Remove("tblRelationTitles")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        Public Function GetRelatedAnalytics(ByVal intSerID As Integer) As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Opac_spAnalytic_GetRelate"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                            .Parameters.Add(New SqlParameter("@intSerID", SqlDbType.Int)).Value = intSerID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblRelatedAnalytics")
                            GetRelatedAnalytics = dsData.Tables("tblRelatedAnalytics")
                            dsData.Tables.Remove("tblRelatedAnalytics")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spAnalytic_GetRelate"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = intItemID
                            .Parameters.Add(New OracleParameter("intSerID", OracleType.Number)).Value = intSerID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblRelatedAnalytics")
                            GetRelatedAnalytics = dsData.Tables("tblRelatedAnalytics")
                            dsData.Tables.Remove("tblRelatedAnalytics")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        Public Function GetHolding(ByVal intSerID As Integer) As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spHolding_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                            .Parameters.Add(New SqlParameter("@intSerID", SqlDbType.Int)).Value = intSerID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblHolding")
                            GetHolding = dsData.Tables("tblHolding")
                            dsData.Tables.Remove("tblHolding")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spHolding_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = intItemID
                            .Parameters.Add(New OracleParameter("intSerID", OracleType.Number)).Value = intSerID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblHolding")
                            GetHolding = dsData.Tables("tblHolding")
                            dsData.Tables.Remove("tblHolding")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        Public Function GetHoldingInfo() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spHoldingInfo_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblHolding")
                            GetHoldingInfo = dsData.Tables("tblHolding")
                            dsData.Tables.Remove("tblHolding")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spHoldingInfo_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = intItemID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblHolding")
                            GetHoldingInfo = dsData.Tables("tblHolding")
                            dsData.Tables.Remove("tblHolding")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        Public Function GetSerHolding() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spSerHolding_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblSerHolding")
                            GetSerHolding = dsData.Tables("tblSerHolding")
                            dsData.Tables.Remove("tblSerHolding")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spSerHolding_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = intItemID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblSerHolding")
                            GetSerHolding = dsData.Tables("tblSerHolding")
                            dsData.Tables.Remove("tblSerHolding")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        Public Function GetSumHoldRequest(Optional ByVal bytInturn As Byte = 1) As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spHoldRequest_Sum"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                            .Parameters.Add(New SqlParameter("@bytInturn", SqlDbType.TinyInt)).Value = bytInturn
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblSumHoldRequest")
                            GetSumHoldRequest = dsData.Tables("tblSumHoldRequest")
                            dsData.Tables.Remove("tblSumHoldRequest")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spHoldRequest_Sum"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = intItemID
                            .Parameters.Add(New OracleParameter("bytInturn", OracleType.Number)).Value = bytInturn
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblSumHoldRequest")
                            GetSumHoldRequest = dsData.Tables("tblSumHoldRequest")
                            dsData.Tables.Remove("tblSumHoldRequest")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        Public Function GetTotalHoldRequest() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spRequest_TotalHold"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblTotalHoldRequest")
                            GetTotalHoldRequest = dsData.Tables("tblTotalHoldRequest")
                            dsData.Tables.Remove("tblTotalHoldRequest")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spRequest_TotalHold"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = intItemID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblTotalHoldRequest")
                            GetTotalHoldRequest = dsData.Tables("tblTotalHoldRequest")
                            dsData.Tables.Remove("tblTotalHoldRequest")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        Public Function GetDueDate() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spDueDate_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblDueDate")
                            GetDueDate = dsData.Tables("tblDueDate")
                            dsData.Tables.Remove("tblDueDate")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spDueDate_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = intItemID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblDueDate")
                            GetDueDate = dsData.Tables("tblDueDate")
                            dsData.Tables.Remove("tblDueDate")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        Public Function GetAcessEntryAuthor(ByVal strAccessEntry As String) As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spAccAuthor_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strAccessEntry", SqlDbType.NVarChar, 2000)).Value = strAccessEntry
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblAcAuthor")
                            GetAcessEntryAuthor = dsData.Tables("tblAcAuthor")
                            dsData.Tables.Remove("tblAcAuthor")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spAccAuthor_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strAccessEntry", OracleType.NVarChar, 2000)).Value = strAccessEntry
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblAcAuthor")
                            GetAcessEntryAuthor = dsData.Tables("tblAcAuthor")
                            dsData.Tables.Remove("tblAcAuthor")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        Public Function GetDicItemType(Optional ByVal intLibID As Integer = 0) As DataTable
            Try
                Me.OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With sqlCommand
                            .CommandText = "Opac_spDicItemType_Get"
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            .CommandType = CommandType.StoredProcedure
                            Try
                                sqlDataAdapter.SelectCommand = sqlCommand
                                sqlDataAdapter.Fill(dsData, "tblResult")
                                GetDicItemType = dsData.Tables("tblResult")
                            Catch sqlClientEx As SqlException
                                strErrorMsg = sqlClientEx.Message
                                intErrorCode = sqlClientEx.Number
                            Finally
                                .Parameters.Clear()
                                dsData.Tables.Remove("tblResult")
                            End Try
                        End With
                    Case "ORACLE"
                        With oraCommand
                            .CommandType = CommandType.StoredProcedure
                            .CommandText = "OPAC.Opac_spDicItemType_Get"
                            Try
                                .Parameters.Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                                .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsData, "tblResult")
                                GetDicItemType = dsData.Tables("tblResult")
                            Catch OraEx As OracleException
                                strErrorMsg = OraEx.Message.ToString
                                intErrorCode = OraEx.Code
                            Finally
                                .Parameters.Clear()
                                dsData.Tables.Remove("tblResult")
                            End Try
                        End With
                End Select
                Me.CloseConnection()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetCollectionForHome method
        ' Purpose: get all information of collection by home page
        ' Input: 
        ' Output: Datatable
        ' Creator: PhuongTT 2014.11.10
        Public Function GetCollectionForHome(Optional ByVal intLibID As Integer = 0) As DataTable
            Dim dtResults As DataTable = Nothing
            Try
                Me.OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With sqlCommand
                            .CommandText = "Opac_spCollectionHome"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                sqlDataAdapter.SelectCommand = sqlCommand
                                sqlDataAdapter.Fill(dsData, "tblResult")
                                dtResults = dsData.Tables("tblResult")
                                dsData.Tables.Remove("tblResult")
                            Catch ex As SqlException
                                strErrorMsg = ex.Message.ToString
                                intErrorCode = ex.Number
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "ORACLE"
                        With oraCommand
                            .CommandText = "OPAC.Opac_spCollectionHome"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                                    .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                End With
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsData, "tblResult")
                                dtResults = dsData.Tables("tblResult")
                                dsData.Tables.Remove("tblResult")
                            Catch ex As OracleException
                                strErrorMsg = ex.Message.ToString
                                intErrorCode = ex.Code
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
                Me.CloseConnection()
            Catch ex As Exception
            End Try
            Return dtResults
        End Function

        ' GetDigitalDocumentCount method
        ' Purpose: get all information of digital document by home page
        ' Input: 
        ' Output: Datatable
        ' Creator: PhuongTT 2015.02.05
        Public Function GetDigitalDocumentCount(Optional ByVal intLibID As Integer = 0) As DataTable
            Dim dtResults As DataTable = Nothing
            Try
                Me.OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With sqlCommand
                            .CommandText = "Opac_spDigitalDocument_Count"
                            .CommandType = CommandType.StoredProcedure
                            Try

                                sqlDataAdapter.SelectCommand = sqlCommand
                                sqlDataAdapter.Fill(dsData, "tblResult")
                                dtResults = dsData.Tables("tblResult")
                                dsData.Tables.Remove("tblResult")
                            Catch ex As SqlException
                                strErrorMsg = ex.Message.ToString
                                intErrorCode = ex.Number
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "ORACLE"
                        With oraCommand
                            .CommandText = "OPAC.Opac_spDigitalDocument_Count"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                                    .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                End With
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsData, "tblResult")
                                dtResults = dsData.Tables("tblResult")
                                dsData.Tables.Remove("tblResult")
                            Catch ex As OracleException
                                strErrorMsg = ex.Message.ToString
                                intErrorCode = ex.Code
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
                Me.CloseConnection()
            Catch ex As Exception
            End Try
            Return dtResults
        End Function
        Public Function GetItemFileCount(Optional ByVal intLibID As Integer = 0) As DataTable
            Dim dtResults As DataTable = Nothing
            Try
                Me.OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With sqlCommand
                            .CommandText = "Opac_spItemFile_Count"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            Try
                                sqlDataAdapter.SelectCommand = sqlCommand
                                sqlDataAdapter.Fill(dsData, "tblResult")
                                dtResults = dsData.Tables("tblResult")
                                dsData.Tables.Remove("tblResult")
                            Catch ex As SqlException
                                strErrorMsg = ex.Message.ToString
                                intErrorCode = ex.Number
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "ORACLE"

                End Select
                Me.CloseConnection()
            Catch ex As Exception
            End Try
            Return dtResults
        End Function


        Function CreditItemDownLoadFile(Optional ByVal strPatronCode As String = "") As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    CreditItemDownLoadFile = 0
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_tblItemDownLoadFile_Credit"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                        .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 20)).Value = strPatronCode
                        Try
                            .ExecuteNonQuery()
                            CreditItemDownLoadFile = 1
                        Catch ex As SqlException
                            CreditItemDownLoadFile = 0
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function GetCountDownLoad() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    GetCountDownLoad = -1
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_tblItemDownLoadFile_GetCountDownLoad"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                        .Parameters.Add(New SqlParameter("@intResult", SqlDbType.Int)).Direction = ParameterDirection.Output
                        Try
                            .ExecuteNonQuery()
                            GetCountDownLoad = .Parameters("@intResult").Value
                        Catch ex As SqlException
                            GetCountDownLoad = -1
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function GetItem(ByVal intType As Integer) As DataTable
            'Opac_spItem_SelItemType
            Dim dtResults As DataTable = Nothing
            Try
                Me.OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With sqlCommand
                            .CommandText = "Opac_spItem_SelItemType"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@intType", SqlDbType.Int)).Value = intType
                            Try

                                sqlDataAdapter.SelectCommand = sqlCommand
                                sqlDataAdapter.Fill(dsData, "tblResult")
                                dtResults = dsData.Tables("tblResult")
                                dsData.Tables.Remove("tblResult")
                            Catch ex As SqlException
                                strErrorMsg = ex.Message.ToString
                                intErrorCode = ex.Number
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "ORACLE"
                        
                End Select
                Me.CloseConnection()
            Catch ex As Exception
            End Try
            Return dtResults
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