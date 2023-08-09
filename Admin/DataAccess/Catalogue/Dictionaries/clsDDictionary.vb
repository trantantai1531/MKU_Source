Imports eMicLibAdmin.DataAccess
Imports eMicLibAdmin.DataAccess.Common
Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Catalogue
    Public Class clsDDictionary
        Inherits clsDBase
        Private strIDs As String
        Private strIDNew As String
        Private intIDTableDic As Integer
        Private strItemLeader As String
        Private strItemCode As String
        Private strDisplayEntry As String
        Private strAccessEntry As String
        Private strSearchFields As String
        Private strISOCode As String
        Private strName As String
        Private strNameViet As String
        Private strNote As String
        Private lngParentID As Long
        Private intTypeID As Integer
        Private strCaption As String
        Private strVietCaption As String
        Private strDescription As String
        Private strVersion As String
        Private strTableDic As String
        Private intTopNumber As Integer = 0
        Private strType As String
        Private lngID As Long

        ' IDs property
        Public Property IDs() As String
            Get
                Return strIDs
            End Get
            Set(ByVal Value As String)
                strIDs = Value
            End Set
        End Property

        ' IDNew property
        Public Property IDNew() As String
            Get
                Return strIDNew
            End Get
            Set(ByVal Value As String)
                strIDNew = Value
            End Set
        End Property

        ' DicIndexID property
        Public Property DicIndexID() As Integer
            Get
                Return intIDTableDic
            End Get
            Set(ByVal Value As Integer)
                intIDTableDic = Value
            End Set
        End Property

        ' ItemLeader property
        Public Property ItemLeader() As String
            Get
                Return strItemLeader
            End Get
            Set(ByVal Value As String)
                strItemLeader = Value
            End Set
        End Property

        ' ItemCode property
        Public Property ItemCode() As String
            Get
                Return strItemCode
            End Get
            Set(ByVal Value As String)
                strItemCode = Value
            End Set
        End Property

        ' DisplayEntry property
        Public Property DisplayEntry() As String
            Get
                Return strDisplayEntry
            End Get
            Set(ByVal Value As String)
                strDisplayEntry = Value
            End Set
        End Property

        ' AccessEntry property
        Public Property AccessEntry() As String
            Get
                Return strAccessEntry
            End Get
            Set(ByVal Value As String)
                strAccessEntry = Value
            End Set
        End Property

        ' SearchFields property
        Public Property SearchFields() As String
            Get
                Return strSearchFields
            End Get
            Set(ByVal Value As String)
                strSearchFields = Value
            End Set
        End Property

        ' IsoCode property
        Public Property IsoCode() As String
            Get
                Return strISOCode
            End Get
            Set(ByVal Value As String)
                strISOCode = Value
            End Set
        End Property

        ' Name property
        Public Property Name() As String
            Get
                Return strName
            End Get
            Set(ByVal Value As String)
                strName = Value
            End Set
        End Property

        ' NameViet property
        Public Property NameViet() As String
            Get
                Return strNameViet
            End Get
            Set(ByVal Value As String)
                strNameViet = Value
            End Set
        End Property

        ' Note property
        Public Property Note() As String
            Get
                Return strNote
            End Get
            Set(ByVal Value As String)
                strNote = Value
            End Set
        End Property

        ' Note property
        Public Property ParentID() As Long
            Get
                Return lngParentID
            End Get
            Set(ByVal Value As Long)
                lngParentID = Value
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

        ' Caption property
        Public Property Caption() As String
            Get
                Return strCaption
            End Get
            Set(ByVal Value As String)
                strCaption = Value
            End Set
        End Property

        ' VietCaption property
        Public Property VietCaption() As String
            Get
                Return strVietCaption
            End Get
            Set(ByVal Value As String)
                strVietCaption = Value
            End Set
        End Property

        ' Description property
        Public Property Description() As String
            Get
                Return strDescription
            End Get
            Set(ByVal Value As String)
                strDescription = Value
            End Set
        End Property

        ' Version property
        Public Property Version() As String
            Get
                Return strVersion
            End Get
            Set(ByVal Value As String)
                strVersion = Value
            End Set
        End Property

        ' TableDicName
        Public Property TableDicName() As String
            Get
                Return strTableDic
            End Get
            Set(ByVal Value As String)
                strTableDic = Value
            End Set
        End Property

        ' TopNumber property
        Public Property TopNumber() As Integer
            Get
                Return intTopNumber
            End Get
            Set(ByVal Value As Integer)
                intTopNumber = Value
            End Set
        End Property

        ' Type property
        Public Property Type() As String
            Get
                Return strType
            End Get
            Set(ByVal Value As String)
                strType = Value
            End Set
        End Property

        ' ID property
        Public Property ID() As Long
            Get
                Return lngID
            End Get
            Set(ByVal Value As Long)
                lngID = Value
            End Set
        End Property

        ' Method: Insert
        Public Function Insert() As Integer
            Dim intRetval As Integer = 1
            Call OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "SP_CATA_INS_CLASSIFICATION"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strItemLeader", SqlDbType.VarChar, 50)).Value = strItemLeader
                                .Add(New SqlParameter("@strItemCode", SqlDbType.VarChar, 50)).Value = strItemCode
                                .Add(New SqlParameter("@strDisplayEntry", SqlDbType.NVarChar, 64)).Value = strDisplayEntry
                                .Add(New SqlParameter("@strAccessEntry", SqlDbType.NVarChar, 64)).Value = strAccessEntry
                                .Add(New SqlParameter("@strType", SqlDbType.VarChar)).Value = strType
                                .Add(New SqlParameter("@strCaption", SqlDbType.NVarChar, 256)).Value = strCaption
                                .Add(New SqlParameter("@strVietCaption", SqlDbType.NVarChar, 256)).Value = strVietCaption
                                .Add(New SqlParameter("@strDescription", SqlDbType.NVarChar, 512)).Value = strDescription
                                .Add(New SqlParameter("@strVersion", SqlDbType.VarChar, 10)).Value = strVersion
                                .Add(New SqlParameter("@intRetval", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetval = .Parameters("@intRetval").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_INS_CLASSIFICATION"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strItemLeader", OracleType.VarChar, 256)).Value = strItemLeader
                                .Add(New OracleParameter("strItemCode", OracleType.VarChar, 256)).Value = strItemCode
                                .Add(New OracleParameter("strDisplayEntry", OracleType.VarChar, 64)).Value = strDisplayEntry
                                .Add(New OracleParameter("strAccessEntry", OracleType.VarChar, 64)).Value = strAccessEntry
                                ' Change datatype
                                .Add(New OracleParameter("strType", OracleType.VarChar)).Value = strType
                                .Add(New OracleParameter("strCaption", OracleType.VarChar, 256)).Value = strCaption
                                .Add(New OracleParameter("strVietCaption", OracleType.VarChar, 256)).Value = strVietCaption
                                .Add(New OracleParameter("strDescription", OracleType.VarChar, 512)).Value = strDescription
                                .Add(New OracleParameter("strVersion", OracleType.VarChar, 10)).Value = strVersion
                                .Add(New OracleParameter("intRetval", OracleType.Number)).Direction = ParameterDirection.Output

                            End With
                            .ExecuteNonQuery()
                            intRetval = .Parameters("intRetval").Value
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Insert = intRetval
        End Function

        ' Method: UpdateDicIndex
        Public Sub UpdateDicIndex()
            Call OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spDic_UpdIndex"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strDisplayEntry", SqlDbType.NVarChar, 1000)).Value = strDisplayEntry
                                .Add(New SqlParameter("@strAccessEntry", SqlDbType.NVarChar, 1000)).Value = strAccessEntry
                                .Add(New SqlParameter("@strISOCode", SqlDbType.VarChar, 5)).Value = strISOCode
                                .Add(New SqlParameter("@strName", SqlDbType.NVarChar, 1000)).Value = strName
                                .Add(New SqlParameter("@strNameViet", SqlDbType.NVarChar, 1000)).Value = strNameViet
                                .Add(New SqlParameter("@strNote", SqlDbType.NVarChar, 1000)).Value = strNote
                                .Add(New SqlParameter("@intParentID", SqlDbType.Int)).Value = lngParentID
                                .Add(New SqlParameter("@strTableDic", SqlDbType.VarChar, 100)).Value = strTableDic
                                .Add(New SqlParameter("@strID", SqlDbType.VarChar, 10)).Value = strIDs
                            End With
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
                        .CommandText = "CATALOGUE.SP_CATA_UPDATE_DIC_INDEX"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strDisplayEntry", OracleType.VarChar, 1000)).Value = strDisplayEntry
                                .Add(New OracleParameter("strAccessEntry", OracleType.VarChar, 1000)).Value = strAccessEntry
                                .Add(New OracleParameter("strISOCode", OracleType.VarChar, 5)).Value = strISOCode
                                .Add(New OracleParameter("strName", OracleType.VarChar, 1000)).Value = strName
                                .Add(New OracleParameter("strNameViet", OracleType.VarChar, 1000)).Value = strNameViet
                                .Add(New OracleParameter("strNote", OracleType.VarChar, 1000)).Value = strNote
                                .Add(New OracleParameter("intParentID", OracleType.Number)).Value = lngParentID
                                .Add(New OracleParameter("strTableDic", OracleType.VarChar, 100)).Value = strTableDic
                                .Add(New OracleParameter("strID", OracleType.VarChar, 10)).Value = strIDs
                            End With
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' Method: MergeDicIndex
        Public Sub MergeDicIndex()
            Call OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spDic_MergeIndex"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strIDNew", SqlDbType.VarChar, 10)).Value = strIDNew
                                .Add(New SqlParameter("@intIDTableDic", SqlDbType.Int)).Value = intIDTableDic
                                .Add(New SqlParameter("@strID", SqlDbType.VarChar, 1000)).Value = strIDs
                            End With
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
                        .CommandText = "CATALOGUE.SP_CATA_MERGE_DIC_INDEX"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strIDNew", OracleType.VarChar, 10)).Value = strIDNew
                                .Add(New OracleParameter("intIDTableDic", OracleType.Number)).Value = intIDTableDic
                                .Add(New OracleParameter("strID", OracleType.VarChar, 1000)).Value = strIDs
                            End With
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' Method: Update
        Public Function Update() As Integer
            Dim intRetval As Integer = 1
            Call OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spClassification_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strItemLeader", SqlDbType.VarChar, 50)).Value = strItemLeader
                                .Add(New SqlParameter("@strDisplayEntry", SqlDbType.NVarChar, 64)).Value = strDisplayEntry
                                .Add(New SqlParameter("@strAccessEntry", SqlDbType.NVarChar, 64)).Value = strAccessEntry
                                .Add(New SqlParameter("@strType", SqlDbType.VarChar)).Value = strType
                                .Add(New SqlParameter("@strCaption", SqlDbType.NVarChar, 256)).Value = strCaption
                                .Add(New SqlParameter("@strVietCaption", SqlDbType.NVarChar, 256)).Value = strVietCaption
                                .Add(New SqlParameter("@strDescription", SqlDbType.NVarChar, 512)).Value = strDescription
                                .Add(New SqlParameter("@strVersion", SqlDbType.NVarChar, 10)).Value = strVersion
                                .Add(New SqlParameter("@lngID", SqlDbType.Int)).Value = lngID
                                .Add(New SqlParameter("@intRetval", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetval = .Parameters("@intRetval").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_UPDATE_CLASSIFICATION"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strItemLeader", OracleType.VarChar, 256)).Value = strItemLeader
                                .Add(New OracleParameter("strDisplayEntry", OracleType.VarChar, 64)).Value = strDisplayEntry
                                .Add(New OracleParameter("strAccessEntry", OracleType.VarChar, 64)).Value = strAccessEntry
                                ' Change datatype
                                .Add(New OracleParameter("strType", OracleType.VarChar)).Value = strType
                                .Add(New OracleParameter("strCaption", OracleType.VarChar, 256)).Value = strCaption
                                .Add(New OracleParameter("strVietCaption", OracleType.VarChar, 256)).Value = strVietCaption
                                .Add(New OracleParameter("strDescription", OracleType.VarChar, 512)).Value = strDescription
                                .Add(New OracleParameter("strVersion", OracleType.VarChar, 10)).Value = strVersion
                                .Add(New OracleParameter("lngID", OracleType.Number)).Value = lngID
                                .Add(New OracleParameter("intRetval", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetval = .Parameters("intRetval").Value
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Update = intRetval
        End Function

        ' Method: Delete
        Public Sub Delete()
            Call OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spClassification_Del"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strIDs", SqlDbType.VarChar, 4000)).Value = strIDs
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
                        .CommandText = "CATALOGUE.SP_CATA_DEL_CLASSIFICATION"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strIDs", OracleType.VarChar, 4000)).Value = strIDs
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' Method: Retrieve
        Public Function Retrieve() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spClassification_SelByType"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strType", SqlDbType.VarChar, 10)).Value = strType
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            Retrieve = dsData.Tables("tblResult")
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
                        .CommandText = "CATALOGUE.SP_CATA_GET_CLASSIFICATION"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strType", OracleType.VarChar, 10)).Value = strType
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            Retrieve = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' RetrieveDicInfor method
        ' Purpose: get data from reference tables
        ' Input: 
        ' Output: datatable
        Public Function RetrieveDicInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_tblDic_SelIndex"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intTopNumber", SqlDbType.Int)).Value = intTopNumber
                            .Parameters.Add(New SqlParameter("@strAccessEntry", SqlDbType.NVarChar, 200)).Value = strAccessEntry
                            .Parameters.Add(New SqlParameter("@strTableDicName", SqlDbType.VarChar, 32)).Value = strTableDic
                            .Parameters.Add(New SqlParameter("@strSearchFields", SqlDbType.VarChar, 100)).Value = strSearchFields
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            RetrieveDicInfor = dsData.Tables("tblResult")
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
                        .CommandText = "CATALOGUE.SP_CATA_GET_DIC_INDEX"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intTopNumber", OracleType.Number)).Value = intTopNumber
                            .Parameters.Add(New OracleParameter("strAccessEntry", OracleType.VarChar, 200)).Value = strAccessEntry
                            .Parameters.Add(New OracleParameter("strTableDicName", OracleType.VarChar, 32)).Value = strTableDic
                            .Parameters.Add(New OracleParameter("strSearchFields", OracleType.VarChar, 2000)).Value = strSearchFields
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            RetrieveDicInfor = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' RetrieveDicAuthor method
        ' Purpose: Retrieve the details of a Authority Dictionary table
        ' Input: TableDicName, AccessEntry
        ' Out put: Datatable
        Public Function RetrieveDicAuthor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spDic_SelAuthor"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strDicName", SqlDbType.VarChar, 1000)).Value = strTableDic
                            .Parameters.Add(New SqlParameter("@strAccessEntry", SqlDbType.NVarChar, 1000)).Value = strAccessEntry
                            .Parameters.Add(New SqlParameter("@strSearchFields", SqlDbType.VarChar, 100)).Value = strSearchFields
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            RetrieveDicAuthor = dsData.Tables("tblResult")
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
                        .CommandText = "CATALOGUE.SP_CATA_GET_DICAUTHOR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strDicName", OracleType.VarChar, 1000)).Value = strTableDic
                            .Parameters.Add(New OracleParameter("strAccessEntry", OracleType.VarChar, 1000)).Value = strAccessEntry
                            .Parameters.Add(New OracleParameter("strSearchFields", OracleType.VarChar, 1000)).Value = strSearchFields
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            RetrieveDicAuthor = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function GetCatDicList(Optional ByVal intID As Integer = 0) As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spDicList_SelByIdWithIndex"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblCatDicList")
                            GetCatDicList = dsData.Tables("tblCatDicList")
                            dsData.Tables.Remove("tblCatDicList")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oracommand
                        .CommandText = "OPAC.Cat_spDicList_SelByIdWithIndex"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intID", OracleType.Number)).Value = intID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblCatDicList")
                            GetCatDicList = dsData.Tables("tblCatDicList")
                            dsData.Tables.Remove("tblCatDicList")
                        Catch oraClientEx As OracleException
                            strErrorMsg = oraClientEx.Message.ToString
                            intErrorCode = oraClientEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        Public Function GetPublisher() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spDicPublisher_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strPublisher", SqlDbType.NVarChar, 1000)).Value = strDisplayEntry
                            .ExecuteNonQuery()
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsdata, "tblResult")
                            GetPublisher = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oracommand
                        .CommandText = "CATALOGUE.SP_CAT_DIC_PUBLISHER_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strPublisher", OracleType.VarChar, 1000)).Value = strDisplayEntry
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsdata, "tblResult")
                            GetPublisher = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Dispose method
        ' Prpose: Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                Call MyBase.Dispose(isDisposing)
            Finally
                Call MyBase.Dispose()
                Call Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace