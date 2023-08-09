Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Catalogue
    Public Class clsDItem
        Inherits clsDBase

        ' *****************************************************************************************************
        ' Declare Private variables
        ' *****************************************************************************************************

        Protected lngItemID As Long
        Protected strItemIDs As String
        Private strCode As String
        Private intIsUnion As Integer
        Private strSessionID As String
        Private intField912Value As Integer
        Protected strTitle As String
        Protected intIsAuthority As Integer
        Private strControlName As String
        Protected intLibID As Integer
        Protected intIndexID As Integer

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' ControlName property
        Public Property ControlName() As String
            Get
                Return (strControlName)
            End Get
            Set(ByVal Value As String)
                strControlName = Value
            End Set
        End Property

        ' ItemID property
        Public Property ItemID() As Long
            Get
                Return lngItemID
            End Get
            Set(ByVal Value As Long)
                lngItemID = Value
            End Set
        End Property

        ' Field912Value property
        Public Property Field912Value() As Integer
            Get
                Field912Value = intField912Value
            End Get
            Set(ByVal Value As Integer)
                intField912Value = Value
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

        ' Code property
        Public Property Code() As String
            Get
                Return strCode
            End Get
            Set(ByVal Value As String)
                strCode = Value
            End Set
        End Property

        ' IsUnion property
        Public Property IsUnion() As Integer
            Get
                Return intIsUnion
            End Get
            Set(ByVal Value As Integer)
                intIsUnion = Value
            End Set
        End Property

        ' SessionID property
        Public Property SessionID() As String
            Get
                Return strSessionID
            End Get
            Set(ByVal Value As String)
                strSessionID = Value
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

        ' IsAuthority property
        Public Property IsAuthority() As Integer
            Get
                Return intIsAuthority
            End Get
            Set(ByVal Value As Integer)
                intIsAuthority = Value
            End Set
        End Property

        ' LibID property
        Public Property LibID() As Integer
            Get
                Return intLibID
            End Get
            Set(ByVal Value As Integer)
                intLibID = Value
            End Set
        End Property


        ' intIndexID property
        Public Property IndexID() As Integer
            Get
                Return intIndexID
            End Get
            Set(ByVal Value As Integer)
                intIndexID = Value
            End Set
        End Property

       

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' GetReserveItemCode method
        ' Purpose: Get content of the one or some items
        ' Input: IsUnion (check also ITEM table), Code, SessionID
        ' Output: Datatable
        Public Function GetReserveItemCode() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_BOOKCODE_RES_GET"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIsUnion", OracleType.Number)).Value = intIsUnion
                            .Parameters.Add(New OracleParameter("SessionID", OracleType.VarChar, 50)).Value = SessionID
                            .Parameters.Add(New OracleParameter("strCode", OracleType.VarChar, 30)).Value = strCode
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetReserveItemCode = dsData.Tables("tblResult")
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
                        .CommandText = "Cat_spBookCodeRes_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIsUnion", SqlDbType.Int)).Value = intIsUnion
                            .Parameters.Add(New SqlParameter("@strSessionID", SqlDbType.VarChar)).Value = strSessionID
                            .Parameters.Add(New SqlParameter("@strCode", SqlDbType.NVarChar)).Value = strCode
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetReserveItemCode = dsData.Tables("tblResult")
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


        ' GetReserveItemCode method
        ' Purpose: Get content of item by index and libid
        ' Output: Datatable
        Public Function GetItemByIndexAndLibID() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItem_SelAllFieldByIndexAndLibId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemIndexId", SqlDbType.Int)).Value = intIndexID
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.VarChar)).Value = intLibID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemByIndexAndLibID = dsData.Tables("tblResult")
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



        ' GetReserveItemCode method
        ' Purpose: Get content of item by index and libid
        ' Output: Datatable
        Public Function GetIndexOfItemByItemIdAndLibID() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItem_SelByIndexAndLibId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemId", SqlDbType.Int)).Value = lngItemID
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.VarChar)).Value = intLibID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetIndexOfItemByItemIdAndLibID = dsData.Tables("tblResult")
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

        ' CreateItemCodeRes method
        ' Purpose: create new reserve ItemCode 
        ' Input: two string value of reserve ItemCode and SessionID
        Public Sub CreateItemCodeRes()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_BOOKCODE_RES_CREATE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strCode", OracleType.VarChar, 30)).Value = strCode
                            .Parameters.Add(New OracleParameter("strSessionID", OracleType.VarChar, 50)).Value = strSessionID
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
                        .CommandText = "Cat_spBookCodeRes_Create"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strCode", SqlDbType.NVarChar)).Value = strCode
                            .Parameters.Add(New SqlParameter("@strSessionID", SqlDbType.VarChar)).Value = strSessionID
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

        ' DeleteItemCodeRes method
        ' Purpose: Delete some selected reserve ItemCode 
        ' Input: string value of reserve ItemCode 
        Public Sub DeleteItemCodeRes()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_BOOKCODE_RES_DEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strCode", OracleType.VarChar, 30)).Value = strCode
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
                        .CommandText = "Cat_spBookCodeRes_Del"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strCode", SqlDbType.NVarChar, 30)).Value = strCode
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

        ' UpdateOpacItem method
        ' Purpose: update OPAC field in ITEM table
        ' Input: ItemID,Tag912

        'Modify: 26/02/2007(chuyenpt)
        '   intType=0: Bien muc so luoc
        '   intType=1: Tao moi
        '   intType=1: Hang doi cho duyet hoac sua an pham
        Public Sub UpdateOpacItem(Optional ByVal intType As Integer = 0)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_UPDATE_OPAC_ITEM"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intType", OracleType.Number)).Value = intType
                            .Parameters.Add(New OracleParameter("lngItemID", OracleType.Number)).Value = lngItemID
                            .Parameters.Add(New OracleParameter("intField912Value", OracleType.Number)).Value = intField912Value
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
                        .CommandText = "Cat_spItem_UpdOpacItem"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intType", SqlDbType.Int)).Value = intType
                            .Parameters.Add(New SqlParameter("@lngItemID", SqlDbType.Int)).Value = lngItemID
                            .Parameters.Add(New SqlParameter("@intField912Value", SqlDbType.Int)).Value = intField912Value
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

        ' DeleteCatQueue method
        ' Purpose: Delete data in CAT_QUEUE table
        Public Sub DeleteCatQueue()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_QUEUE_DEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strIDs", OracleType.VarChar, 1000)).Value = ItemIDs
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
                        .CommandText = "Cat_spQueue_Del"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strIDs", SqlDbType.NVarChar)).Value = ItemIDs
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

        ' UpdateItemReview method
        ' Purpose: Update data in CAT_QUEUE table
        Public Sub UpdateItemReview(ByVal strReviewer As String)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_UPPDATE_ITEM_REVIEWER"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strIDs", OracleType.VarChar, 500)).Value = ItemIDs
                            .Parameters.Add(New OracleParameter("strReviewer", OracleType.VarChar, 50)).Value = strReviewer
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
                        .CommandText = "Lib_spItem_UpdReviewer"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strIDs", SqlDbType.VarChar, 500)).Value = ItemIDs
                            .Parameters.Add(New SqlParameter("@strReviewer", SqlDbType.VarChar, 50)).Value = strReviewer
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

        ' UpdateItemReview method
        ' Purpose: Update data in CAT_QUEUE table
        Public Function GetItemReview() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_GET_ITEM_REVIEWER"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strIDs", OracleType.VarChar, 500)).Value = ItemIDs
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetItemReview = dsData.Tables("tblResult")
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
                        .CommandText = "Cat_spQueue_SelItemReviewer"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strIDs", SqlDbType.VarChar, 500)).Value = ItemIDs
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemReview = dsData.Tables("tblResult")
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

        ' Get the dictionary list
        ' Modify: 17/6/2004
        Public Function GetCatDicList() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.CAT_DIC_LIST_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetCatDicList = dsData.Tables("tblResult")
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
                        .CommandText = "Cat_spDicList_SelAll"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetCatDicList = dsData.Tables("tblResult")
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

        ' Get the dictionary list
        ' Modify: 17/6/2004
        Public Function GetCatDicListBasic() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.CAT_DIC_LIST_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetCatDicListBasic = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spDicList_SelAll_Basic"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetCatDicListBasic = dsData.Tables("tblResult")
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

        ' GetTopNumByID method
        ' Purpose: Get topnumber by ItemID
        Public Function GetTopNumByID() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_ITEM_GETTOPNUM_BY_ID"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("intID", OracleType.Number)).Value = lngItemID
                        .Parameters.Add(New OracleParameter("intIsAuthority", OracleType.Number)).Value = intIsAuthority
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblTopNum")
                            GetTopNumByID = dsData.Tables("tblTopNum")
                            dsData.Tables.Remove("tblTopNum")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spItem_SelTopNumById"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Value = lngItemID
                        .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                        .Parameters.Add(New SqlParameter("@intIsAuthority", SqlDbType.Int)).Value = intIsAuthority
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblTopNum")
                            GetTopNumByID = dsData.Tables("tblTopNum")
                            dsData.Tables.Remove("tblTopNum")
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

        ' CheckExistItemByNumber method
        ' Purpose: Check exist item by ISBN or ISSN
        ' Input: FieldValue, FieldCode
        ' Output: long value
        Public Function CheckExistItemByNumber(ByVal strFieldValue As String, ByVal strFieldCode As String) As Long
            Dim lngItemID As Long = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_CHECK_EXIST_ITEMNUMBER"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strFieldValue", OracleType.VarChar)).Value = strFieldValue
                            .Parameters.Add(New OracleParameter("strFieldCode", OracleType.VarChar)).Value = strFieldCode
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            Dim tblTemps As DataTable
                            tblTemps = dsData.Tables("tblResult")
                            If tblTemps.Rows.Count > 0 Then
                                lngItemID = tblTemps.Rows(0).Item("ItemID")
                            End If
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
                        .CommandText = "Cat_spDicNumber_CheckExit"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strFieldValue", SqlDbType.VarChar)).Value = strFieldValue
                        .Parameters.Add(New SqlParameter("@strFieldCode", SqlDbType.VarChar)).Value = strFieldCode
                        .Parameters.Add(New SqlParameter("@lngItemID", SqlDbType.Int)).Direction = ParameterDirection.Output
                        Try
                            .ExecuteNonQuery()
                            lngItemID = .Parameters("@lngItemID").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Return lngItemID
        End Function
        ' GetCopyNumbers method
        ' Purpose: Get the holding information
        ' Output: Datatable
        Public Function GetCopyNumbers() As DataTable

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_GET_COPYNUMBER"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("intID", OracleType.Number)).Value = lngItemID
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblCopyNum")
                            GetCopyNumbers = dsData.Tables("tblCopyNum")
                            dsData.Tables.Remove("tblCopyNum")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHolding_Sel"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Value = lngItemID
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblCopyNum")
                            GetCopyNumbers = dsData.Tables("tblCopyNum")
                            dsData.Tables.Remove("tblCopyNum")
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

        Public Function GetItems() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_GET_ITEMS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strCode", OracleType.VarChar, 20)).Value = strCode
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = lngItemID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblGetItems")
                        Catch oraex As OracleException
                            strerrormsg = oraex.Message.ToString
                            interrorcode = oraex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spItem_SelByIdOrCode"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strCode", SqlDbType.VarChar, 20)).Value = strCode
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = lngItemID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblGetItems")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            GetItems = dsData.Tables("tblGetItems")
            dsData.Tables.Remove("tblGetItems")
            Call CloseConnection()
        End Function
        ' Method: GetCataTimeList
        ' Purpose: Get catalogue time list
        ' Output: Datatable result
        ' Created by: Lent
        Function GetCataTimeList() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spQueue_SelWithOrder"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetCataTimeList = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "ACQUISITION.SP_ITEM_CAT_QUEUE_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetCataTimeList = dsData.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Function CreditItemDownLoadFile() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    CreditItemDownLoadFile = 0
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_tblItemDownLoadFile_Credit"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = lngItemID
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
                        .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = lngItemID
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


        Public Function UpdateCountPage(Optional ByVal intItemId As Integer = 0, Optional ByVal intCountPage As Integer = 0) As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    UpdateCountPage = -1
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemFile_Update_CountPage"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intItemId", SqlDbType.Int)).Value = intItemId
                        .Parameters.Add(New SqlParameter("@intCountPage", SqlDbType.Int)).Value = intCountPage
                        Try
                            .ExecuteNonQuery()
                            UpdateCountPage = 1
                        Catch ex As SqlException
                            UpdateCountPage = -1
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Method: GetItemInQueueList
        ' Purpose : Get list of items in queue
        ' Input: Orderby, CataloguedDate
        ' Output: Datatable
        ' Createdby: Lent
        Function GetItemInQueueList(ByVal intOrderBy As Int16, ByVal strMonth As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spQueue_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intOrderBy", SqlDbType.Int)).Value = intOrderBy
                                .Add(New SqlParameter("@strDate", SqlDbType.VarChar, 20)).Value = strMonth
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemInQueueList = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_ITEM_QUEUE_SELECT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                .Add(New OracleParameter("intOrderBy", OracleType.Number)).Value = intOrderBy
                                .Add(New OracleParameter("strDate", OracleType.VarChar, 20)).Value = strMonth
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetItemInQueueList = dsData.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function GetTitlesAndCode() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_GET_TITLES"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strItemIDs", OracleType.NVarChar, 4000)).Value = strItemIDs
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetTitlesAndCode = dsData.Tables("tblResult")
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
                        .CommandText = "Lib_spItem_SelByItemIds"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strItemIDs", SqlDbType.NVarChar, 4000)).Value = strItemIDs
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetTitlesAndCode = dsData.Tables("tblResult")
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

        ' Method: GetItemInfor
        ' Purpose: Get the Item main infor
        ' Output: Datatable
        Public Function GetItemInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_GET_ITEM_INFOR"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = lngItemID
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblItemInfor")
                            GetItemInfor = dsData.Tables("tblItemInfor")
                            dsData.Tables.Remove("tblItemInfor")
                        Catch oraex As OracleException
                            strerrormsg = oraex.Message.ToString
                            interrorcode = oraex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spField_SelItemInfor"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intitemid", SqlDbType.Int)).Value = lngItemID
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsdata, "tbliteminfor")
                            GetItemInfor = dsdata.Tables("tbliteminfor")
                            dsdata.Tables.Remove("tbliteminfor")
                        Catch sqlclientex As SqlException
                            strerrormsg = sqlclientex.Message.ToString
                            interrorcode = sqlclientex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' GetItemIDByItemCode method
        ' Purpose: Get the Item ID by ItemCode
        ' Output: Datatable
        Public Function GetItemIDByItemCode() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_GET_ITEMID_BYCODE"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("strItemCode", OracleType.VarChar, 50)).Value = strCode
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblItemID")
                            GetItemIDByItemCode = dsData.Tables("tblItemID")
                            dsData.Tables.Remove("tblItemID")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spItem_SelIdByCode"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strItemCode", SqlDbType.VarChar, 50)).Value = strCode
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblItemID")
                            GetItemIDByItemCode = dsData.Tables("tblItemID")
                            dsData.Tables.Remove("tblItemID")
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

        Public Sub CreateQueue()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CREATE_QUEUE"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = lngItemID
                        Try
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
                        .CommandText = "Cat_spQueue_Ins"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = lngItemID
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

        Public Function GetItemByKeyword(ByVal intKeywordId As Integer, Optional ByVal intTypeId As Integer = 0, Optional ByVal intLoanTypeId As Integer = 0, Optional ByVal intYearFrom As Integer = 0, Optional intYearTo As Integer = 0, Optional intAcqSource As Integer = 0, Optional intLocation As Integer = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spItem_Keyword_Sel"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intKeywordId", SqlDbType.Int)).Value = intKeywordId
                        .Parameters.Add(New SqlParameter("@intLoanTypeId", SqlDbType.Int)).Value = intLoanTypeId
                        .Parameters.Add(New SqlParameter("@intTypeId", SqlDbType.Int)).Value = intTypeId
                        .Parameters.Add(New SqlParameter("@intYearFrom", SqlDbType.Int)).Value = intYearFrom
                        .Parameters.Add(New SqlParameter("@intYearTo", SqlDbType.Int)).Value = intYearTo
                        .Parameters.Add(New SqlParameter("@intAcqSource", SqlDbType.Int)).Value = intAcqSource
                        .Parameters.Add(New SqlParameter("@intLocation", SqlDbType.Int)).Value = intLocation
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemByKeyword = dsData.Tables("tblResult")
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

        Public Function GetItemByKeyword(ByVal strKeyword As String, Optional ByVal intTypeId As Integer = 0, Optional ByVal intLoanTypeId As Integer = 0, Optional ByVal intYearFrom As Integer = 0, Optional intYearTo As Integer = 0, Optional intAcqSource As Integer = 0, Optional intLocation As Integer = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spItem_Keyword_SelKeyword"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strKeyword", SqlDbType.NVarChar)).Value = strKeyword
                        .Parameters.Add(New SqlParameter("@intLoanTypeId", SqlDbType.Int)).Value = intLoanTypeId
                        .Parameters.Add(New SqlParameter("@intTypeId", SqlDbType.Int)).Value = intTypeId
                        .Parameters.Add(New SqlParameter("@intYearFrom", SqlDbType.Int)).Value = intYearFrom
                        .Parameters.Add(New SqlParameter("@intYearTo", SqlDbType.Int)).Value = intYearTo
                        .Parameters.Add(New SqlParameter("@intAcqSource", SqlDbType.Int)).Value = intAcqSource
                        .Parameters.Add(New SqlParameter("@intLocation", SqlDbType.Int)).Value = intLocation
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemByKeyword = dsData.Tables("tblResult")
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

        Public Function GetItemByKeywordCount(ByVal intKeywordId As Integer, Optional ByVal intTypeId As Integer = 0, Optional ByVal intLoanTypeId As Integer = 0, Optional ByVal intYearFrom As Integer = 0, Optional intYearTo As Integer = 0, Optional intAcqSource As Integer = 0, Optional intLocation As Integer = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spItem_Keyword_Sel_Count"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intKeywordId", SqlDbType.Int)).Value = intKeywordId
                        .Parameters.Add(New SqlParameter("@intLoanTypeId", SqlDbType.Int)).Value = intLoanTypeId
                        .Parameters.Add(New SqlParameter("@intTypeId", SqlDbType.Int)).Value = intTypeId
                        .Parameters.Add(New SqlParameter("@intYearFrom", SqlDbType.Int)).Value = intYearFrom
                        .Parameters.Add(New SqlParameter("@intYearTo", SqlDbType.Int)).Value = intYearTo
                        .Parameters.Add(New SqlParameter("@intAcqSource", SqlDbType.Int)).Value = intAcqSource
                        .Parameters.Add(New SqlParameter("@intLocation", SqlDbType.Int)).Value = intLocation
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemByKeywordCount = dsData.Tables("tblResult")
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

        Public Function GetItemByKeywordCount(ByVal strKeyword As String, Optional ByVal intTypeId As Integer = 0, Optional ByVal intLoanTypeId As Integer = 0, Optional ByVal intYearFrom As Integer = 0, Optional intYearTo As Integer = 0, Optional intAcqSource As Integer = 0, Optional intLocation As Integer = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spItem_Keyword_SelKeyword_Count"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strKeyword", SqlDbType.NVarChar)).Value = strKeyword
                        .Parameters.Add(New SqlParameter("@intLoanTypeId", SqlDbType.Int)).Value = intLoanTypeId
                        .Parameters.Add(New SqlParameter("@intTypeId", SqlDbType.Int)).Value = intTypeId
                        .Parameters.Add(New SqlParameter("@intYearFrom", SqlDbType.Int)).Value = intYearFrom
                        .Parameters.Add(New SqlParameter("@intYearTo", SqlDbType.Int)).Value = intYearTo
                        .Parameters.Add(New SqlParameter("@intAcqSource", SqlDbType.Int)).Value = intAcqSource
                        .Parameters.Add(New SqlParameter("@intLocation", SqlDbType.Int)).Value = intLocation
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemByKeywordCount = dsData.Tables("tblResult")
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

        Public Function GetItemBySH(ByVal intSHId As Integer, Optional ByVal intTypeId As Integer = 0, Optional ByVal intLoanTypeId As Integer = 0, Optional ByVal intYearFrom As Integer = 0, Optional intYearTo As Integer = 0, Optional intAcqSource As Integer = 0, Optional intLocation As Integer = 0, Optional strAdditionalBy As String = "", Optional strDicFaculty As String = "", Optional strDateFrom As String = "", Optional strDateTo As String = "") As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spItem_SH_Sel"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intSHId", SqlDbType.Int)).Value = intSHId
                        .Parameters.Add(New SqlParameter("@intLoanTypeId", SqlDbType.Int)).Value = intLoanTypeId
                        .Parameters.Add(New SqlParameter("@intTypeId", SqlDbType.Int)).Value = intTypeId
                        .Parameters.Add(New SqlParameter("@intYearFrom", SqlDbType.Int)).Value = intYearFrom
                        .Parameters.Add(New SqlParameter("@intYearTo", SqlDbType.Int)).Value = intYearTo
                        .Parameters.Add(New SqlParameter("@intAcqSource", SqlDbType.Int)).Value = intAcqSource
                        .Parameters.Add(New SqlParameter("@intLocation", SqlDbType.Int)).Value = intLocation
                        .Parameters.Add(New SqlParameter("@strAdditionalBy", SqlDbType.NVarChar)).Value = strAdditionalBy
                        .Parameters.Add(New SqlParameter("@strDicFaculty", SqlDbType.NVarChar)).Value = strDicFaculty
                        .Parameters.Add(New SqlParameter("@strDateFrom", SqlDbType.NVarChar)).Value = strDateFrom
                        .Parameters.Add(New SqlParameter("@strDateTo", SqlDbType.NVarChar)).Value = strDateTo
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemBySH = dsData.Tables("tblResult")
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

        Public Function GetItemBySH(ByVal strSH As String, Optional ByVal intTypeId As Integer = 0, Optional ByVal intLoanTypeId As Integer = 0, Optional ByVal intYearFrom As Integer = 0, Optional intYearTo As Integer = 0, Optional intAcqSource As Integer = 0, Optional intLocation As Integer = 0, Optional strAdditionalBy As String = "", Optional strDicFaculty As String = "", Optional strDateFrom As String = "", Optional strDateTo As String = "") As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spItem_SH_SelSH"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strSH", SqlDbType.NVarChar)).Value = strSH
                        .Parameters.Add(New SqlParameter("@intLoanTypeId", SqlDbType.Int)).Value = intLoanTypeId
                        .Parameters.Add(New SqlParameter("@intTypeId", SqlDbType.Int)).Value = intTypeId
                        .Parameters.Add(New SqlParameter("@intYearFrom", SqlDbType.Int)).Value = intYearFrom
                        .Parameters.Add(New SqlParameter("@intYearTo", SqlDbType.Int)).Value = intYearTo
                        .Parameters.Add(New SqlParameter("@intAcqSource", SqlDbType.Int)).Value = intAcqSource
                        .Parameters.Add(New SqlParameter("@intLocation", SqlDbType.Int)).Value = intLocation
                        .Parameters.Add(New SqlParameter("@strAdditionalBy", SqlDbType.NVarChar)).Value = strAdditionalBy
                        .Parameters.Add(New SqlParameter("@strDicFaculty", SqlDbType.NVarChar)).Value = strDicFaculty
                        .Parameters.Add(New SqlParameter("@strDateFrom", SqlDbType.NVarChar)).Value = strDateFrom
                        .Parameters.Add(New SqlParameter("@strDateTo", SqlDbType.NVarChar)).Value = strDateTo
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemBySH = dsData.Tables("tblResult")
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

        Public Function GetItemBySHCount(ByVal intSHId As Integer, Optional ByVal intTypeId As Integer = 0, Optional ByVal intLoanTypeId As Integer = 0, Optional ByVal intYearFrom As Integer = 0, Optional intYearTo As Integer = 0, Optional intAcqSource As Integer = 0, Optional intLocation As Integer = 0, Optional strAdditionalBy As String = "", Optional strDicFaculty As String = "", Optional strDateFrom As String = "", Optional strDateTo As String = "") As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spItem_SH_Sel_Count"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intSHId", SqlDbType.Int)).Value = intSHId
                        .Parameters.Add(New SqlParameter("@intLoanTypeId", SqlDbType.Int)).Value = intLoanTypeId
                        .Parameters.Add(New SqlParameter("@intTypeId", SqlDbType.Int)).Value = intTypeId
                        .Parameters.Add(New SqlParameter("@intYearFrom", SqlDbType.Int)).Value = intYearFrom
                        .Parameters.Add(New SqlParameter("@intYearTo", SqlDbType.Int)).Value = intYearTo
                        .Parameters.Add(New SqlParameter("@intAcqSource", SqlDbType.Int)).Value = intAcqSource
                        .Parameters.Add(New SqlParameter("@intLocation", SqlDbType.Int)).Value = intLocation
                        .Parameters.Add(New SqlParameter("@strAdditionalBy", SqlDbType.NVarChar)).Value = strAdditionalBy
                        .Parameters.Add(New SqlParameter("@strDicFaculty", SqlDbType.NVarChar)).Value = strDicFaculty
                        .Parameters.Add(New SqlParameter("@strDateFrom", SqlDbType.NVarChar)).Value = strDateFrom
                        .Parameters.Add(New SqlParameter("@strDateTo", SqlDbType.NVarChar)).Value = strDateTo
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemBySHCount = dsData.Tables("tblResult")
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

        Public Function GetItemBySHCount(ByVal strSH As String, Optional ByVal intTypeId As Integer = 0, Optional ByVal intLoanTypeId As Integer = 0, Optional ByVal intYearFrom As Integer = 0, Optional intYearTo As Integer = 0, Optional intAcqSource As Integer = 0, Optional intLocation As Integer = 0, Optional strAdditionalBy As String = "", Optional strDicFaculty As String = "", Optional strDateFrom As String = "", Optional strDateTo As String = "") As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spItem_SH_SelSH_Count"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strSH", SqlDbType.NVarChar)).Value = strSH
                        .Parameters.Add(New SqlParameter("@intLoanTypeId", SqlDbType.Int)).Value = intLoanTypeId
                        .Parameters.Add(New SqlParameter("@intTypeId", SqlDbType.Int)).Value = intTypeId
                        .Parameters.Add(New SqlParameter("@intYearFrom", SqlDbType.Int)).Value = intYearFrom
                        .Parameters.Add(New SqlParameter("@intYearTo", SqlDbType.Int)).Value = intYearTo
                        .Parameters.Add(New SqlParameter("@intAcqSource", SqlDbType.Int)).Value = intAcqSource
                        .Parameters.Add(New SqlParameter("@intLocation", SqlDbType.Int)).Value = intLocation
                        .Parameters.Add(New SqlParameter("@strAdditionalBy", SqlDbType.NVarChar)).Value = strAdditionalBy
                        .Parameters.Add(New SqlParameter("@strDicFaculty", SqlDbType.NVarChar)).Value = strDicFaculty
                        .Parameters.Add(New SqlParameter("@strDateFrom", SqlDbType.NVarChar)).Value = strDateFrom
                        .Parameters.Add(New SqlParameter("@strDateTo", SqlDbType.NVarChar)).Value = strDateTo
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemBySHCount = dsData.Tables("tblResult")
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


        Public Function GetListCataloguer() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItem_GetListCataloguer"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblItemID")
                            GetListCataloguer = dsData.Tables("tblItemID")
                            dsData.Tables.Remove("tblItemID")
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


        Public Function GetItemStatisticTotal(Optional ByVal strDateFrom As String = "", Optional ByVal strDateTo As String = "") As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"

                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItem_StatisticTotal"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strDateFrom", SqlDbType.NVarChar)).Value = strDateFrom
                        .Parameters.Add(New SqlParameter("@strDateTo", SqlDbType.NVarChar)).Value = strDateTo
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemStatisticTotal = dsData.Tables("tblResult")
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

        Public Function GetItemDissertationTotal(Optional ByVal strDateFrom As String = "", Optional ByVal strDateTo As String = "") As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"

                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemDissertation_GetByDate"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strDateFrom", SqlDbType.NVarChar)).Value = strDateFrom
                        .Parameters.Add(New SqlParameter("@strDateTo", SqlDbType.NVarChar)).Value = strDateTo
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblItemDissertation")
                            GetItemDissertationTotal = dsData.Tables("tblItemDissertation")
                            dsData.Tables.Remove("tblItemDissertation")
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
                Call MyBase.Dispose(True)
            Finally
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace