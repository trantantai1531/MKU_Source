Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Catalogue
    Public Class clsDItemCollection
        Inherits clsDItem

        ' *****************************************************************************************************
        ' Declare Private variables
        ' *****************************************************************************************************
        Private intTypeItem As Integer
        Private intTopNum As Integer


        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' TypeItem property
        Public Property TypeItem() As Integer
            Get
                Return intTypeItem
            End Get
            Set(ByVal Value As Integer)
                intTypeItem = Value
            End Set
        End Property

        ' TopNum property
        Public Property TopNum() As Integer
            Get
                Return intTopNum
            End Get
            Set(ByVal Value As Integer)
                intTopNum = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' GetRangeItemID method
        ' Purpose: Retrieve all items
        ' Output: Datatable
        Public Function GetRangeItemID() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_GET_RANGE_OF_ITEMID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIsAuthority", OracleType.Number)).Value = intIsAuthority
                            .Parameters.Add(New OracleParameter("intTypeItem", OracleType.Number)).Value = intTypeItem
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetRangeItemID = dsData.Tables("tblResult")
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
                        .CommandText = "Lib_spItem_SelRangeOfItemId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIsAuthority", SqlDbType.Int)).Value = intIsAuthority
                            .Parameters.Add(New SqlParameter("@intTypeItem", SqlDbType.Int)).Value = intTypeItem
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID

                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetRangeItemID = dsData.Tables("tblResult")
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

        ' GetItemMainInfor method
        ' Purpose: get all main information of item (Leader, ItemType, ItemMedia...)
        ' Input: string value of ItemIDs
        ' Output: Datatable
        Public Function GetItemMainInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_GET_MAININFOR_OF_ITEM"
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
        ' Input: lngItemIDs
        ' Output: Datatable
        Public Function GetItemDetailInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_GET_DETAIL_OF_ITEM"
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
                            .Parameters.Add(New SqlParameter("@strItemIDs", SqlDbType.VarChar)).Value = strItemIDs
                            .Parameters.Add(New SqlParameter("@intIsAuthority", SqlDbType.Int)).Value = intIsAuthority
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

        ' GetTitles method
        ' Purpose: get title which like the title of existing items
        ' Input: string value of title to cheking
        ' Output: datatable
        Public Function GetExistTitles() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_CHECK_EXIST_TITLE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strTitle", OracleType.VarChar, 200)).Value = strTitle
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetExistTitles = dsData.Tables("tblResult")
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
                        .CommandText = "Lib_spField200S_CheckExitTitle"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strTitle", SqlDbType.NVarChar)).Value = strTitle
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetExistTitles = dsData.Tables("tblResult")
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

        ' Delete method
        ' Purpose: Delete some selected items
        ' Input: string value of ItemIDs
        Public Sub Delete()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_DELETE_ITEMS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIsAuthority", OracleType.Number)).Value = intIsAuthority
                            .Parameters.Add(New OracleParameter("strIDs", OracleType.VarChar, 1000)).Value = strItemIDs
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spItem_Del"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIsAuthority", SqlDbType.Int)).Value = intIsAuthority
                            .Parameters.Add(New SqlParameter("@strIDs", SqlDbType.VarChar)).Value = strItemIDs
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub



        Public Sub DeleteBookCodeByCode(ByVal code As Integer)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "Lib_spBookCode_Del_ByCode"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strCode", OracleType.Int16)).Value = code
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = strSQLStatement & "->" & OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spBookCode_Del_ByCode"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strCode", SqlDbType.Int)).Value = code
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = strSQLStatement & "->" & sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub
        Public Function GetItemByID(ByVal itemID As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.Lib_spItem_SelAllOrById"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intID", OracleType.Int16, 200)).Value = itemID
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetItemByID = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItem_SelAllOrById"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Value = itemID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemByID = dsData.Tables("tblResult")
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

        'Retrieve Search Code_Tile Results
        Public Function RetrieveCodeTitle_Result(Optional itemInfor As Integer = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SEARCH_CODE_TITLE_SEL"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("strIDs", OracleType.VarChar, 8000)).Value = strItemIDs
                            .Add(New OracleParameter("smintCHECKJAVASCRIPT", OracleType.Number)).Value = 1
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            .ExecuteNonQuery()
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblCodeTitleResult")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spField200S_SelCodeTitle"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strIDs", SqlDbType.NVarChar, 4000)).Value = strItemIDs
                        .Parameters.Add(New SqlParameter("@smintCHECKJAVASCRIPT", SqlDbType.SmallInt)).Value = 1
                        .Parameters.Add(New SqlParameter("@intLidID", SqlDbType.Int)).Value = intLibID
                        .Parameters.Add(New SqlParameter("@intItemInfor", SqlDbType.Int)).Value = itemInfor
                        Try
                            .ExecuteNonQuery()
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblCodeTitleResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            RetrieveCodeTitle_Result = dsData.Tables("tblCodeTitleResult")
            dsData.Tables.Remove("tblCodeTitleResult")
            Call CloseConnection()
        End Function

        ' Retrieve Holding item to delete
        Public Function GetHoldingDel() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_SEARCH_HOLDING_DEL"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("strIDs", OracleType.VarChar, 8000)).Value = strItemIDs
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            .ExecuteNonQuery()
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblCodeTitleResult")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItem_SelHoldingDel"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strIDs", SqlDbType.VarChar, 8000)).Value = strItemIDs
                        Try
                            .ExecuteNonQuery()
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblCodeTitleResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            GetHoldingDel = dsData.Tables("tblCodeTitleResult")
            dsData.Tables.Remove("tblCodeTitleResult")
            Call CloseConnection()
        End Function

        ''' <summary>
        ''' Include Non-DKCB and DKCB with state denote by 0 or 1
        ''' </summary>
        ''' <param name="strSQL"></param>
        ''' <returns></returns>
        Public Function GetHoldingDel(ByVal strSQL As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItem_SelHoldingDelSql"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strSQL", SqlDbType.NVarChar, 4000)).Value = strSQL
                        Try
                            .ExecuteNonQuery()
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblCodeTitleResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            GetHoldingDel = dsData.Tables("tblCodeTitleResult")
            dsData.Tables.Remove("tblCodeTitleResult")
            Call CloseConnection()
        End Function

        ' GetContents method
        ' Purpose: Get content of the one or some items
        Public Function GetContents() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_GET_CONTENTS_OF_ITEMS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIsAuthority", OracleType.Number)).Value = intIsAuthority
                            .Parameters.Add(New OracleParameter("strItemIDs", OracleType.VarChar, 1000)).Value = strItemIDs
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetContents = dsData.Tables("tblResult")
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
                        .CommandText = "Lib_spItem_SelContentsOfItem"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIsAuthority", SqlDbType.Int)).Value = intIsAuthority
                            .Parameters.Add(New SqlParameter("@strItemIDs", SqlDbType.VarChar, 1000)).Value = strItemIDs
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetContents = dsData.Tables("tblResult")
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

        ' GetIDByTopNum method
        ' Purpose: Get Max Item ID by a top number of Item
        Public Function GetIDByTopNum(ByVal strSQLFilter As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_GET_ITEMID_BY_TOPNUM"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIsAuthority", OracleType.Number)).Value = intIsAuthority
                            .Parameters.Add(New OracleParameter("intTopNum", OracleType.Number)).Value = intTopNum
                            .Parameters.Add(New OracleParameter("strSQLFilter", OracleType.VarChar, 2000)).Value = strSQLFilter
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetIDByTopNum = dsData.Tables("tblResult")
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
                        .CommandText = "Lib_spItem_SelByTopNum"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intTopNum", SqlDbType.Int)).Value = intTopNum
                            .Parameters.Add(New SqlParameter("@strSQLFilter", SqlDbType.NVarChar, 2000)).Value = strSQLFilter
                            .Parameters.Add(New SqlParameter("@intIsAuthority", SqlDbType.Int)).Value = intIsAuthority

                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetIDByTopNum = dsData.Tables("tblResult")
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

        Public Function GetListOnTopNum(ByVal strSQLFilter As String, Optional ByVal intPage As Integer = 1) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItem_GetListOnTopNum"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intTopNum", SqlDbType.Int)).Value = intTopNum
                            .Parameters.Add(New SqlParameter("@intPage", SqlDbType.Int)).Value = intPage
                            .Parameters.Add(New SqlParameter("@strSQLFilter", SqlDbType.NVarChar, 2000)).Value = strSQLFilter
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID

                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetListOnTopNum = dsData.Tables("tblResult")
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

        ' GetAvailableItems method 
        ' Purpose: Get the Item is available at the moment
        ' Input: strItemIDs
        ' Output: DataTable
        Public Function GetAvailableItems() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spItem_SelItemAvailable"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strItemIDs", SqlDbType.VarChar, 4000)).Value = strItemIDs
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "ITEM_AVAILABLE")
                            GetAvailableItems = dsData.Tables("ITEM_AVAILABLE")
                            dsData.Tables.Remove("ITEM_AVAILABLE")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ITEM_AVAILABLE_SEL"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("strItemIDs", OracleType.VarChar, 4000)).Value = strItemIDs
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "ITEM_AVAILABLE")
                            GetAvailableItems = dsData.Tables("ITEM_AVAILABLE")
                            dsData.Tables.Remove("ITEM_AVAILABLE")
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

        ' Purpose: Get the Holding copies of item
        ' GetItemCount method 
        ' Input: strItemIDs
        ' Output: DataTable
        Public Function GetItemCount() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spItem_SelCount"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strItemIDs", SqlDbType.VarChar, 4000)).Value = strItemIDs
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "ITEM_COUNT")
                            GetItemCount = dsData.Tables("ITEM_COUNT")
                            dsData.Tables.Remove("ITEM_COUNT")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ITEM_COUNT_SEL"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("strItemIDs", OracleType.VarChar, 4000)).Value = strItemIDs
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "ITEM_COUNT")
                            GetItemCount = dsData.Tables("ITEM_COUNT")
                            dsData.Tables.Remove("ITEM_COUNT")
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

        ' GetLoanHistory method 
        ' Purpose: Get the Item is being loaned
        ' Input: strItemIDs
        ' Output: DataTable
        Public Function GetLoanHistory() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spLoanHistory_SelByItemIds"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strItemIDs", SqlDbType.VarChar, 4000)).Value = strItemIDs
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "LOAN_HISTORY")
                            GetLoanHistory = dsData.Tables("LOAN_HISTORY")
                            dsData.Tables.Remove("LOAN_HISTORY")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_CIR_LOAN_HISTORY_SEL"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("strItemIDs", OracleType.VarChar, 4000)).Value = strItemIDs
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "LOAN_HISTORY")
                            GetLoanHistory = dsData.Tables("LOAN_HISTORY")
                            dsData.Tables.Remove("LOAN_HISTORY")
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

        ' GetOrderedItems method
        ' Purpose: Get the Item ordered details
        ' Input: strTitle
        ' Output: DataTable
        Public Function GetOrderedItems() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spPO_SelItem"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strTitle", SqlDbType.NVarChar, 100)).Value = strTitle
                        .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "ITEM_ODERED")
                            GetOrderedItems = dsData.Tables("ITEM_ODERED")
                            dsData.Tables.Remove("ITEM_ODERED")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ITEM_ODERED_SEL"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("strTitle", OracleType.NVarChar, 1000)).Value = strTitle
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "ITEM_ODERED")
                            GetOrderedItems = dsData.Tables("ITEM_ODERED")
                            dsData.Tables.Remove("ITEM_ODERED")
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

        Public Sub UpdateLoanTypeOfCopies(ByVal strCopyNumberIDs As String, ByVal intLoanTypeID As Integer)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spLoanTypeHolding_Upd"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strHoldingIDs", SqlDbType.VarChar, 4000)).Value = strCopyNumberIDs
                            .Add(New SqlParameter("@intLoanTypeID", SqlDbType.Int)).Value = intLoanTypeID
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
                        .CommandText = "CATALOGUE.SP_UPD_LOANTYPE_OFHOLDING"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("strHoldingIDs", OracleType.VarChar, 4000)).Value = strCopyNumberIDs
                            .Add(New OracleParameter("intLoanTypeID", OracleType.Number)).Value = intLoanTypeID
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
            End Select
            Call CloseConnection()
        End Sub

        Public Function SearchHolding(ByVal intLoanTypeID As Integer, ByVal strQueryIn As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spQueryHolding"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intLoanTypeID", SqlDbType.Int)).Value = intLoanTypeID
                            .Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                            .Add(New SqlParameter("@strQueryIn", SqlDbType.NVarChar, 4000)).Value = strQueryIn
                        End With
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblQUERY_HOLDING")
                            SearchHolding = dsData.Tables("tblQUERY_HOLDING")
                            dsData.Tables.Remove("tblQUERY_HOLDING")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_QUERY_HOLDING"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intLoanTypeID", OracleType.Number)).Value = intLoanTypeID
                            .Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                            .Add(New OracleParameter("strQueryIn", OracleType.VarChar, 4000)).Value = strQueryIn
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try

                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblQUERY_HOLDING")
                            SearchHolding = dsData.Tables("tblQUERY_HOLDING")
                            dsData.Tables.Remove("tblQUERY_HOLDING")
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

        '**********************************************************************
        '**********************************************************************
        ' *************************** SERIAL **********************************
        ' GetTitlesPO method
        ' Purpose: get title which like the title of existing items
        ' Input: string value of title to cheking
        ' Output: datatable
        Public Function GetExistTitlesPO(ByVal strItemType As String) As DataTable
            Try
                Call OpenConnection()
                Select Case UCase(strDBServer)
                    Case "ORACLE"
                        With oraCommand
                            .CommandText = "CATALOGUE.SP_GET_EXIT_TITLE"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                .Parameters.Add(New OracleParameter("strTitle", OracleType.NVarChar, 200)).Value = strTitle
                                .Parameters.Add(New OracleParameter("strItemType", OracleType.NVarChar, 200)).Value = strItemType
                                .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsData, "tblTitles")
                                GetExistTitlesPO = dsData.Tables("tblTitles")
                                dsData.Tables.Remove("tblTitles")
                            Catch OraEx As OracleException
                                strErrorMsg = OraEx.Message.ToString
                                intErrorCode = OraEx.Code
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "SQLSERVER"
                        With SqlCommand
                            .CommandText = "Acq_spItem_SelExitTitle"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                .Parameters.Add(New SqlParameter("@strTitle", SqlDbType.NVarChar)).Value = strTitle
                                .Parameters.Add(New SqlParameter("@strItemType", SqlDbType.NVarChar)).Value = strItemType
                                SqlDataAdapter.SelectCommand = SqlCommand
                                SqlDataAdapter.Fill(dsData, "tblTitles")
                                GetExistTitlesPO = dsData.Tables("tblTitles")
                                dsData.Tables.Remove("tblTitles")
                            Catch sqlClientEx As SqlException
                                strErrorMsg = sqlClientEx.Message.ToString
                                intErrorCode = sqlClientEx.Number
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

        Public Function GetSysUserViews(ByVal strUserName As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Sys_spView_SelByUserName"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Clear()
                        With .Parameters
                            .Add(New SqlParameter("@strUserName", SqlDbType.VarChar, 50)).Value = strUserName.Replace("-", "")
                        End With
                        .ExecuteNonQuery()
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblSYSVIEW")
                            GetSysUserViews = dsData.Tables("tblSYSVIEW")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblSYSVIEW")
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_GET_SYS_VIEW"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Clear()
                        With .Parameters
                            .Add(New OracleParameter("strUserName", OracleType.VarChar, 50)).Value = strUserName
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblSYSVIEW")
                            GetSysUserViews = dsData.Tables("tblSYSVIEW")
                            dsData.Tables.Remove("tblSYSVIEW")
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

        Public Function SearchSerialItems(ByVal strUserName As String, ByVal strViewName As String, ByVal strSQL As String, ByVal strSelectStatement As String, ByVal lngViewID As Long, ByRef strOutPut As String, Optional ByVal intUpdate As Integer = 0) As DataTable
            'If strSQL = "" Then
            '    Exit Function
            'End If
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_SER_SEARCH_ITEM"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strSQL", OracleType.VarChar, 1000)).Value = strSQL
                            .Parameters.Add(New OracleParameter("strUser", OracleType.VarChar, 50)).Value = strUserName
                            .Parameters.Add(New OracleParameter("strViewName", OracleType.VarChar, 50)).Value = strViewName
                            .Parameters.Add(New OracleParameter("strSelectStatement", OracleType.VarChar, 500)).Value = strSelectStatement
                            .Parameters.Add(New OracleParameter("intID", OracleType.Number)).Value = lngViewID
                            .Parameters.Add(New OracleParameter("intUpdate", OracleType.Number)).Value = intUpdate
                            .Parameters.Add(New OracleParameter("strOutPut", OracleType.VarChar, 1000)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblItemDetails")
                            SearchSerialItems = dsData.Tables("tblItemDetails")
                            If Not IsDBNull(.Parameters("strOutPut").Value) Then
                                strOutPut = .Parameters("strOutPut").Value
                            Else
                                strOutPut = ""
                            End If
                            If Not dsData.Tables("tblItemDetails") Is Nothing Then
                                dsData.Tables.Remove("tblItemDetails")
                            End If

                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ser_spSearchItem"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strSQL", SqlDbType.NVarChar)).Value = strSQL
                            .Parameters.Add(New SqlParameter("@strUser", SqlDbType.VarChar)).Value = strUserName.Replace("-", "")
                            .Parameters.Add(New SqlParameter("@strViewName", SqlDbType.NVarChar)).Value = strViewName.Replace("-", "")
                            .Parameters.Add(New SqlParameter("@strSelectStatement", SqlDbType.NVarChar)).Value = strSelectStatement
                            .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Value = lngViewID
                            .Parameters.Add(New SqlParameter("@intUpdate", SqlDbType.TinyInt)).Value = intUpdate
                            .Parameters.Add(New SqlParameter("@strOutPut", SqlDbType.NVarChar, 4000)).Direction = ParameterDirection.Output
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblItemDetails")
                            SearchSerialItems = dsData.Tables("tblItemDetails")
                            strOutPut = .Parameters("@strOutPut").Value
                            If Not dsData.Tables("tblItemDetails") Is Nothing Then
                                dsData.Tables.Remove("tblItemDetails")
                            End If
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

        Public Function SearchSerialItemsNoSave(ByVal strSQL As String) As DataTable
            'If strSQL = "" Then
            '    Exit Function
            'End If
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Ser_spSearchItemNoSave"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strSQL", SqlDbType.NVarChar)).Value = strSQL

                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblItemDetails")
                            SearchSerialItemsNoSave = dsData.Tables("tblItemDetails")
                            If Not dsData.Tables("tblItemDetails") Is Nothing Then
                                dsData.Tables.Remove("tblItemDetails")
                            End If
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

        ' method: Check GroupName
        ' Creator: chuyenpt(5/4/07)
        Public Function CheckGroupName(ByVal strUserName As String, ByVal strViewName As String) As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_SER_CHECKGROUPNAME"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strUser", OracleType.VarChar, 50)).Value = strUserName
                            .Parameters.Add(New OracleParameter("strViewName", OracleType.VarChar, 50)).Value = strViewName
                            .Parameters.Add(New OracleParameter("intOutPut", OracleType.Number, 10)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            .ExecuteNonQuery()
                            CheckGroupName = .Parameters("intOutPut").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ser_spCheckGroupName"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strUser", SqlDbType.VarChar)).Value = strUserName
                            .Parameters.Add(New SqlParameter("@strViewName", SqlDbType.NVarChar)).Value = strViewName
                            .Parameters.Add(New SqlParameter("@intOutPut", SqlDbType.Int, 10)).Direction = ParameterDirection.Output
                            SqlDataAdapter.SelectCommand = SqlCommand
                            .ExecuteNonQuery()
                            CheckGroupName = .Parameters("@intOutPut").Value
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

        Public Sub RemoveSysUserView(ByVal lngViewID As Long)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_SYS_VIEW_DEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intID", OracleType.Number)).Value = lngViewID
                            oraDataAdapter.SelectCommand = oraCommand
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Sys_spView_Del"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Value = lngViewID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' GetOrderedItems method
        ' Purpose: Get the Item ordered details
        ' Input: strTitle
        ' Output: DataTable
        Public Function GetFreeItemNum() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHolding_SellFreeItemNum"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = lngItemID
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetFreeItemNum = dsData.Tables("tblResult")
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
                        .CommandText = "CATALOGUE.SP_GET_FREE_ITEM_NUM"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = lngItemID
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetFreeItemNum = dsData.Tables("tblResult")
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

        ' Method: GetIssueList
        ' Purpose: Get list of issues
        ' Input: Search conditions
        ' Output: DataTable result
        Public Function GetIssueList(ByVal strTitle As String, ByVal strFromDate As String, ByVal strToDate As String, ByVal strIssueNo As String, ByVal strVolume As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Ser_spIssue_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strTitle", SqlDbType.NVarChar)).Value = strTitle
                            .Parameters.Add(New SqlParameter("@strFromDate", SqlDbType.VarChar)).Value = strFromDate
                            .Parameters.Add(New SqlParameter("@strToDate", SqlDbType.VarChar)).Value = strToDate
                            .Parameters.Add(New SqlParameter("@strIssueNo", SqlDbType.VarChar)).Value = strIssueNo
                            .Parameters.Add(New SqlParameter("@strVolume", SqlDbType.NVarChar)).Value = strVolume
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetIssueList = dsData.Tables("tblResult")
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
                        .CommandText = "CATALOGUE.SP_CATA_GET_ISSUES"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strTitle", OracleType.VarChar, 500)).Value = strTitle
                            .Parameters.Add(New OracleParameter("strFromDate", OracleType.VarChar, 30)).Value = strFromDate
                            .Parameters.Add(New OracleParameter("strToDate", OracleType.VarChar, 30)).Value = strToDate
                            .Parameters.Add(New OracleParameter("strIssueNo", OracleType.VarChar, 50)).Value = strIssueNo
                            .Parameters.Add(New OracleParameter("strVolume", OracleType.VarChar, 50)).Value = strVolume
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetIssueList = dsData.Tables("tblResult")
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


        ' Method: GetCatalogue
        ' Purpose: Get list of issues
        ' Input: Search conditions
        ' Output: DataTable result
        Public Function GetCatalogueStatOverView() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spDic_ItemType_SelOverView"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetCatalogueStatOverView = dsData.Tables("tblResult")
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
                        .CommandText = "CATALOGUE.SP_CATALOGUE_STAT_OVERVIEW"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetCatalogueStatOverView = dsData.Tables("tblResult")
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

        ' Method: GetPeriodicalList  
        ' Purpose: Get list of periodicals
        ' Input: Search conditions
        ' Output: DataTable result
        Public Function GetPeriodicalList(ByVal strTitle As String, ByVal strFromDate As String, ByVal strToDate As String, ByVal strIssueNo As String, ByVal strVolume As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Ser_spIssue_SelPeriodicals"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strTitle", SqlDbType.NVarChar)).Value = strTitle
                            .Parameters.Add(New SqlParameter("@strFromDate", SqlDbType.VarChar)).Value = strFromDate
                            .Parameters.Add(New SqlParameter("@strToDate", SqlDbType.VarChar)).Value = strToDate
                            .Parameters.Add(New SqlParameter("@strIssueNo", SqlDbType.VarChar)).Value = strIssueNo
                            .Parameters.Add(New SqlParameter("@strVolume", SqlDbType.NVarChar)).Value = strVolume
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetPeriodicalList = dsData.Tables("tblResult")
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
                        .CommandText = "CATALOGUE.SP_CATA_GET_PERIODICALS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("@strTitle", OracleType.VarChar, 500)).Value = strTitle
                            .Parameters.Add(New OracleParameter("@strFromDate", OracleType.VarChar, 30)).Value = strFromDate
                            .Parameters.Add(New OracleParameter("@strToDate", OracleType.VarChar, 30)).Value = strToDate
                            .Parameters.Add(New OracleParameter("@strIssueNo", OracleType.VarChar, 50)).Value = strIssueNo
                            .Parameters.Add(New OracleParameter("@strVolume", OracleType.VarChar, 50)).Value = strVolume
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetPeriodicalList = dsData.Tables("tblResult")
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

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                Call MyBase.Dispose(True)
            Finally
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace