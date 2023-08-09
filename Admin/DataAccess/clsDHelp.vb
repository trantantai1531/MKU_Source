' Name: clsDOPACHelp
' Purpose: Manage HelpInfor
' Creator: thaott
' Created Date: 30/Aug/2006
' Modification History: 
Imports System
Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType
Namespace eMicLibAdmin.DataAccess
    Public Class clsDHelp
        Inherits clsDBase
        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private strFileURL As String
        Private strHelpTitle As String
        Private intParentID As Integer
        Private strHelpContent As String
        Private strAccessContent As String
        Private strItemLinkID As String = ""
        Private intCatDicID As Integer
        Private strCatDicID As String
        Private strNotSelectCatDicID As String
        Private strSQL As String
        Private intType As Integer = 0
        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
        'file URL help name 
        Public Property FileURL() As String
            Get
                Return strFileURL
            End Get
            Set(ByVal Value As String)
                strFileURL = Value
            End Set
        End Property
        'Title help
        Public Property HelpTitle() As String
            Get
                Return strHelpTitle
            End Get
            Set(ByVal Value As String)
                strHelpTitle = Value
            End Set
        End Property
        'parentID
        Public Property ParentID() As Integer
            Get
                Return intParentID
            End Get
            Set(ByVal Value As Integer)
                intParentID = Value
            End Set
        End Property
        'Help content        
        Public Property HelpContent() As String
            Get
                Return strHelpContent
            End Get
            Set(ByVal Value As String)
                strHelpContent = Value
            End Set
        End Property
        ' help content reject all HTML tag
        Public Property AccessContent() As String
            Get
                Return strAccessContent
            End Get
            Set(ByVal Value As String)
                strAccessContent = Value
            End Set
        End Property
        ' all Help ID link and separate by ","
        Public Property ItemLinkID() As String
            Get
                Return strItemLinkID
            End Get
            Set(ByVal Value As String)
                strItemLinkID = Value
            End Set
        End Property
        '--Help CatDic ID
        Public Property CatDicID() As Integer
            Get
                Return intCatDicID
            End Get
            Set(ByVal Value As Integer)
                intCatDicID = Value
            End Set
        End Property
        '--list help CatDic ID
        Public Property ListCatDicID() As String
            Get
                Return strCatDicID
            End Get
            Set(ByVal Value As String)
                strCatDicID = Value
            End Set
        End Property
        '--list not select help CatDic ID
        Public Property NotSelectCatDicID() As String
            Get
                Return strNotSelectCatDicID
            End Get
            Set(ByVal Value As String)
                strNotSelectCatDicID = Value
            End Set
        End Property
        '--String SQL
        Public Property SQL() As String
            Get
                Return strSQL
            End Get
            Set(ByVal Value As String)
                strSQL = Value
            End Set
        End Property
        Public Property type() As Integer
            Get
                Return intType
            End Get
            Set(ByVal Value As Integer)
                intType = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************
        ' Name: GetInforSearch
        ' Purpose: get infor search
        ' Input:HelpTitle,AccessContent
        ' Output: Datatable
        ' Creator: thaott
        ' Created Date: 8Sep2006
        ' Modification History: 
        '
        Public Function GetInforSearch() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHelpCatDic_SelToSearch"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strHelpTitle", SqlDbType.NVarChar)).Value = strHelpTitle
                                .Add(New SqlParameter("@strAccessContent", SqlDbType.NVarChar)).Value = strAccessContent
                                .Add(New SqlParameter("@blnType", SqlDbType.Bit)).Value = intType
                            End With
                            strErrorMsg = ""
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetInforSearch = dsData.Tables("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.SP_HELP_SEARCH"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strHelpTitle", OracleType.VarChar)).Value = strHelpTitle
                                .Add(New OracleParameter("strAccessContent", OracleType.LongVarChar)).Value = strAccessContent
                                .Add(New OracleParameter("blnType", OracleType.Number)).Value = intType
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblSelectHelpByParentID")
                            GetInforSearch = dsData.Tables("tblSelectHelpByParentID")
                            dsData.Tables.Remove("tblSelectHelpByParentID")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function
        ' Name: ExecuteSQL
        ' Purpose: Execute SQL command
        ' Input: string
        ' Output: Datatable
        ' Creator: thaott
        ' Created Date: 6Sep2006
        ' Modification History: 
        '
        Public Function GetInfor() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = strSQL
                        .CommandType = CommandType.Text
                        Try
                            strErrorMsg = ""
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetInfor = dsData.Tables("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "strSQL"
                        .CommandType = CommandType.Text
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetInfor = dsData.Tables("tblResult")
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
        End Function
        '
        ' Name: DeleteHelp
        ' Purpose: Delete help in database
        ' Input: intCatDicID
        ' Output: Boolean
        ' Creator: thaott
        ' Created Date: 5Sep2006
        ' Modification History: 
        '
        Public Function DeleteHelp() As Boolean
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHelpCatDic_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intDicID", SqlDbType.Int)).Value = intCatDicID
                            End With
                            .ExecuteNonQuery()
                            Return True
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.SP_HELP_DIC_DEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intDicID", OracleType.Number)).Value = intCatDicID
                            End With
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function
        '
        ' Name: UpdatetHelp
        ' Purpose: Update data help in all table in database
        ' Input: intCatDicID,strFileURL, strHelpTitle, intParentID,
        '        strHelpContent,strAccessContent,strItemLinkID
        ' Output: Boolean
        ' Creator: thaott
        ' Created Date: 31/Aug/2006
        ' Modification History: 
        '
        Public Function UpdatetHelp() As Boolean
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHelpCatDic_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intDicID", SqlDbType.Int)).Value = intCatDicID
                                .Add(New SqlParameter("@FileURL", SqlDbType.NVarChar)).Value = strFileURL
                                .Add(New SqlParameter("@HelpTitle", SqlDbType.NVarChar)).Value = strHelpTitle
                                .Add(New SqlParameter("@ParentID", SqlDbType.Int)).Value = intParentID
                                .Add(New SqlParameter("@HelpContent", SqlDbType.NText)).Value = strHelpContent
                                .Add(New SqlParameter("@AccessContent", SqlDbType.NText)).Value = strAccessContent
                                .Add(New SqlParameter("@strLinkID", SqlDbType.NVarChar)).Value = strItemLinkID
                            End With
                            .ExecuteNonQuery()
                            Return True
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.SP_HELP_DIC_UPD"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intDicID", OracleType.Number)).Value = intCatDicID
                                .Add(New OracleParameter("strFileURL", OracleType.VarChar)).Value = strFileURL
                                .Add(New OracleParameter("strHelpTitle", OracleType.VarChar)).Value = strHelpTitle
                                .Add(New OracleParameter("intParentID", OracleType.Number)).Value = intParentID
                                .Add(New OracleParameter("lngHelpContent", OracleType.LongVarChar)).Value = strHelpContent
                                .Add(New OracleParameter("lngAccessContent", OracleType.LongVarChar)).Value = strAccessContent
                                .Add(New OracleParameter("strstrLinkID", OracleType.VarChar)).Value = strItemLinkID
                                .Add(New OracleParameter("blnType", OracleType.Number)).Value = intType
                            End With
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With

            End Select
            Me.CloseConnection()
        End Function
        '
        ' Name: InsertHelp
        ' Purpose: Insert data help in all table in database
        ' Input: strFileURL, strHelpTitle, intParentID,
        '        strHelpContent,strAccessContent,strItemLinkID
        ' Output: Boolean
        ' Creator: thaott
        ' Created Date: 30/Aug/2006
        ' Modification History: 
        '
        Public Function InsertHelp() As Boolean
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHelpCatDic_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@FileURL", SqlDbType.NVarChar)).Value = strFileURL
                                .Add(New SqlParameter("@HelpTitle", SqlDbType.NVarChar)).Value = strHelpTitle
                                .Add(New SqlParameter("@ParentID", SqlDbType.Int)).Value = intParentID
                                .Add(New SqlParameter("@HelpContent", SqlDbType.NText)).Value = strHelpContent
                                .Add(New SqlParameter("@AccessContent", SqlDbType.NText)).Value = strAccessContent
                                .Add(New SqlParameter("@strLinkID", SqlDbType.NVarChar)).Value = strItemLinkID
                                .Add(New SqlParameter("@blnType", SqlDbType.Bit)).Value = intType
                            End With
                            .ExecuteNonQuery()
                            Return True
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.SP_HELP_DIC_INS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strFileURL", OracleType.VarChar, 4000)).Value = strFileURL
                                .Add(New OracleParameter("strHelpTitle", OracleType.VarChar, 2000)).Value = strHelpTitle
                                .Add(New OracleParameter("intParentID", OracleType.Number)).Value = intParentID
                                .Add(New OracleParameter("strHelpContent", OracleType.LongVarChar)).Value = strHelpContent
                                .Add(New OracleParameter("strAccessContent", OracleType.LongVarChar)).Value = strAccessContent
                                .Add(New OracleParameter("strLinkID", OracleType.VarChar, 800)).Value = strItemLinkID
                                .Add(New OracleParameter("blnType", OracleType.Number)).Value = intType
                            End With
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function
        '
        ' Name: GetHepCatFileByURL
        ' Purpose: Get  catalogy File Help 
        ' Input: strFileURL
        ' Output: DataTable
        ' Creator: thaott
        ' Created Date: 30/Aug/2006
        ' Modification History: 
        Public Function GetHepCatFileByURL() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHelpCatFile_SelByFileUrl"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strFileURL", SqlDbType.NVarChar)).Value = strFileURL
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblSelect")
                            GetHepCatFileByURL = dsData.Tables("tblSelect")
                            dsData.Tables.Remove("tblSelect")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.SP_HELP_CAT_FILE_BYURL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strFileURL", OracleType.VarChar)).Value = strFileURL
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetHepCatFileByURL = dsData.Tables("tblResult")
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
        End Function
        '
        ' Name: GetHepCatFileByDicID
        ' Purpose: Get catalogy File Help by CatDicID
        ' Input: CatDicID
        ' Output: DataTable
        ' Creator: thaott
        ' Created Date: 30/Aug/2006
        ' Modification History: 
        Public Function GetHepCatFileByDicID() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHelpCatFile_SelByCatDicId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intCatDicID", SqlDbType.Int)).Value = intCatDicID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblSelect")
                            GetHepCatFileByDicID = dsData.Tables("tblSelect")
                            dsData.Tables.Remove("tblSelect")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.SP_HELP_CAT_FILE_BYDICID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intCatDicID", OracleType.Number)).Value = intCatDicID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetHepCatFileByDicID = dsData.Tables("tblResult")
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
        End Function
        '
        ' Name: GetHepCatDicByID
        ' Purpose: Get  catalogy File Help 
        ' Input: strNotSelectCatDicID,strCatDicID
        ' Output: DataTable
        ' Creator: thaott
        ' Created Date: 30/Aug/2006
        ' Modification History: 
        Public Function GetHepCatDicByID() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHelpCatDic_SelByDicId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strCatDicID", SqlDbType.NVarChar)).Value = strCatDicID
                                .Add(New SqlParameter("@strNotSelectCatDicID", SqlDbType.NVarChar)).Value = strNotSelectCatDicID
                                .Add(New SqlParameter("@blnType", SqlDbType.Bit)).Value = intType
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblSelect")
                            GetHepCatDicByID = dsData.Tables("tblSelect")
                            dsData.Tables.Remove("tblSelect")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.SP_HELP_CAT_DIC_BYDICID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strCatDicID", OracleType.VarChar, 400)).Value = strCatDicID
                                .Add(New OracleParameter("strNotSelectCatDicID", OracleType.VarChar, 400)).Value = strNotSelectCatDicID
                                .Add(New OracleParameter("blnType", OracleType.Number)).Value = intType
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetHepCatDicByID = dsData.Tables("tblResult")
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
        End Function
        '
        ' Name: GetHepItemLinkByID
        ' Purpose: Get  HELP_ITEM _LINK
        ' Input: intCatDicID
        ' Output: DataTable
        ' Creator: thaott
        ' Created Date: 30/Aug/2006
        ' Modification History: 
        Public Function GetHepItemLinkByID() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHelpItemLink_SelByCatDicId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intCatDicID", SqlDbType.Int)).Value = intCatDicID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetHepItemLinkByID = dsData.Tables("tblResult")
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
                        .CommandText = "OPAC.SP_HELP_ITEM_LINK_BYDICID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intCatDicID", OracleType.Number)).Value = intCatDicID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult2")
                            GetHepItemLinkByID = dsData.Tables("tblResult2")
                            dsData.Tables.Remove("tblResult2")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function
        '
        ' Name: GetHepDicItemByID
        ' Purpose: Get  Lib_tblHelpDicItem infor
        ' Input: intCatDicID
        ' Output: DataTable
        ' Creator: thaott
        ' Created Date: 30/Aug/2006
        ' Modification History: 
        Public Function GetHepDicItemByID() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHelpDicItem_SelByCatDicID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intCatDicID", SqlDbType.Int)).Value = intCatDicID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblSelect")
                            GetHepDicItemByID = dsData.Tables("tblSelect")
                            dsData.Tables.Remove("tblSelect")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.SP_HELP_DIC_ITEM_BYID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intCatDicID", OracleType.Number)).Value = intCatDicID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblSelectHelpByParentID")
                            GetHepDicItemByID = dsData.Tables("tblSelectHelpByParentID")
                            dsData.Tables.Remove("tblSelectHelpByParentID")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function
        ' Name: GetHepDicByParentID
        ' Purpose: Get Help_Cat_Dic infor 
        ' Input: intCatDicID
        ' Output: DataTable
        ' Creator: thaott
        ' Created Date: 30/Aug/2006
        ' Modification History: 
        Public Function GetHepCatDicByParentID() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHelpCatDic_SelByParentId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intParentID", SqlDbType.Int)).Value = intParentID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblSelectHelpByParentID")
                            GetHepCatDicByParentID = dsData.Tables("tblSelectHelpByParentID")
                            dsData.Tables.Remove("tblSelectHelpByParentID")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.SP_HELP_CAT_DIC_BYPARENTID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intParentID", OracleType.Number)).Value = intParentID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetHepCatDicByParentID = dsData.Tables("tblResult")
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
        End Function
        '
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
