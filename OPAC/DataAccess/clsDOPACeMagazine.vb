Imports System
Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibOPAC.DataAccess.OPAC
    Public Class clsDOPACeMagazine
        Inherits clsDBase

        Private intId As Integer
        Private inteYear As Integer
        Private inteMonth As Integer
        Private inteDay As Integer
        Private intItemID As Integer
        Private streNum As String
        Private intStatus As Integer
        Private strDescription As String
        Private struserName As String
        Private struserNameUpdate As String
        Private bolHome As Boolean

        'Detail
        Private strFileName As String
        Private strXMLpath As String
        Private strThumnail As String
        Private intDownloadTimes As Integer
        Private dtmDateUpload As Object
        Private bolViewer As Boolean
        Private intFileSize As Integer
        Private strPath As String
        Private intPageNum As Integer
        Private intMagID As Integer

        Public Property MagID() As Integer
            Get
                Return intMagID
            End Get
            Set(ByVal Value As Integer)
                intMagID = Value
            End Set
        End Property
        Public Property Id() As Integer
            Get
                Return intId
            End Get
            Set(ByVal Value As Integer)
                intId = Value
            End Set
        End Property
        Public Property eYear() As Integer
            Get
                Return inteYear
            End Get
            Set(ByVal Value As Integer)
                inteYear = Value
            End Set
        End Property
        Public Property eMonth() As Integer
            Get
                Return inteMonth
            End Get
            Set(ByVal Value As Integer)
                inteMonth = Value
            End Set
        End Property
        Public Property eDay() As Integer
            Get
                Return inteDay
            End Get
            Set(ByVal Value As Integer)
                inteDay = Value
            End Set
        End Property
        Public Property ItemID() As Integer
            Get
                Return intItemID
            End Get
            Set(ByVal Value As Integer)
                intItemID = Value
            End Set
        End Property
        Public Property eMagNum() As String
            Get
                Return streNum
            End Get
            Set(ByVal Value As String)
                streNum = Value
            End Set
        End Property
        Public Property Status() As Integer
            Get
                Return intStatus
            End Get
            Set(ByVal Value As Integer)
                intStatus = Value
            End Set
        End Property
        Public Property Description() As String
            Get
                Return strDescription
            End Get
            Set(ByVal Value As String)
                strDescription = Value
            End Set
        End Property
        Public Property userName() As String
            Get
                Return struserName
            End Get
            Set(ByVal Value As String)
                struserName = Value
            End Set
        End Property
        Public Property userNameUpdate() As String
            Get
                Return struserNameUpdate
            End Get
            Set(ByVal Value As String)
                struserNameUpdate = Value
            End Set
        End Property
        Public Property Home() As Boolean
            Get
                Return bolHome
            End Get
            Set(ByVal Value As Boolean)
                bolHome = Value
            End Set
        End Property


        Public Property FileName() As String
            Get
                Return strFileName
            End Get
            Set(ByVal Value As String)
                strFileName = Value
            End Set
        End Property
        Public Property XMLpath() As String
            Get
                Return strXMLpath
            End Get
            Set(ByVal Value As String)
                strXMLpath = Value
            End Set
        End Property
        Public Property Thumnail() As String
            Get
                Return strThumnail
            End Get
            Set(ByVal Value As String)
                strThumnail = Value
            End Set
        End Property
        Public Property DownloadTimes() As Integer
            Get
                Return intDownloadTimes
            End Get
            Set(ByVal Value As Integer)
                intDownloadTimes = Value
            End Set
        End Property
        Public Property DateUpload() As Object
            Get
                Return dtmDateUpload
            End Get
            Set(ByVal Value As Object)
                dtmDateUpload = Value
            End Set
        End Property
        Public Property Viewer() As Boolean
            Get
                Return bolViewer
            End Get
            Set(ByVal Value As Boolean)
                bolViewer = Value
            End Set
        End Property
        Public Property FileSize() As Integer
            Get
                Return intFileSize
            End Get
            Set(ByVal Value As Integer)
                intFileSize = Value
            End Set
        End Property
        Public Property Path() As String
            Get
                Return strPath
            End Get
            Set(ByVal Value As String)
                strPath = Value
            End Set
        End Property
        Public Property PageNum() As Integer
            Get
                Return intPageNum
            End Get
            Set(ByVal Value As Integer)
                intPageNum = Value
            End Set
        End Property

        ' Purpose: Get year of all magazine by ItemID
        ' Input: ItemID
        ' Output: DataTable
        ' Created by: PhuongTT
        Public Function GetYearMagazineNumberByItemID() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Opac_spItemMagNumber_GetYearByItemID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = ItemID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetYearMagazineNumberByItemID = dsData.Tables("tblResult")
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
                        .CommandText = "OPAC.Opac_spItemMagNumber_GetYearByItemID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = ItemID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetYearMagazineNumberByItemID = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
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

        ' Purpose: Get all magazine detail by year
        ' Input: ItemID
        ' Output: DataTable
        ' Created by: PhuongTT
        Public Function GetMagazineNumberDetailByYear(Optional ByVal intPage As Integer = 1, Optional ByVal intPageSize As Integer = 10) As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Opac_spItemMagNumberDetail_GetByYear"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = ItemID
                            .Parameters.Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = eYear
                            .Parameters.Add(New SqlParameter("@intPage", SqlDbType.Int)).Value = intPage
                            .Parameters.Add(New SqlParameter("@intPageSize", SqlDbType.Int)).Value = intPageSize
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetMagazineNumberDetailByYear = dsData.Tables("tblResult")
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
                        .CommandText = "OPAC.Opac_spItemMagNumberDetail_GetByYear"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = ItemID
                            .Parameters.Add(New OracleParameter("intYear", OracleType.Number)).Value = eYear
                            .Parameters.Add(New OracleParameter("intPage", OracleType.Number)).Value = intPage
                            .Parameters.Add(New OracleParameter("intPageSize", OracleType.Number)).Value = intPageSize
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetMagazineNumberDetailByYear = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
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

        ' Purpose: Get Total of all magazine detail by year
        ' Input: ItemID
        ' Output: DataTable
        ' Created by: PhuongTT
        Public Function GetMagazineNumberDetailCount() As Integer
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Opac_spItemMagNumberDetail_Count"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = ItemID
                            .Parameters.Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = eYear
                            .Parameters.Add(New SqlParameter("@intCount", SqlDbType.Int)).Direction = ParameterDirection.Output
                             .ExecuteNonQuery()
                            GetMagazineNumberDetailCount = .Parameters("@intCount").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spItemMagNumberDetail_Count"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = ItemID
                            .Parameters.Add(New OracleParameter("intYear", OracleType.Number)).Value = eYear
                            .Parameters.Add(New OracleParameter("intCount", OracleType.Cursor)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            GetMagazineNumberDetailCount = .Parameters("intCount").Value
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


        ' Purpose: Get all magazine detail by MagID
        ' Input: MagID
        ' Output: DataTable
        ' Created by: PhuongTT
        Public Function GetMagazineNumberDetailByMagID(Optional ByVal intPage As Integer = 1, Optional ByVal intPageSize As Integer = 10) As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Opac_spItemMagNumberDetail_GetByMagID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intMagID", SqlDbType.Int)).Value = MagID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetMagazineNumberDetailByMagID = dsData.Tables("tblResult")
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
                        .CommandText = "OPAC.Opac_spItemMagNumberDetail_GetByMagID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intMagID", OracleType.Number)).Value = MagID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetMagazineNumberDetailByMagID = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
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


        ' Purpose: Get all magazine detail TOC by MagID
        ' Input: MagID
        ' Output: DataTable
        ' Created by: PhuongTT
        Public Function GetMagazineNumberDetailTOCByMagID(Optional ByVal intPage As Integer = 1, Optional ByVal intPageSize As Integer = 10) As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Opac_spItemMagNumberDetailToc_GetByMagID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intMagID", SqlDbType.Int)).Value = MagID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetMagazineNumberDetailTOCByMagID = dsData.Tables("tblResult")
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
                        .CommandText = "OPAC.Opac_spItemMagNumberDetailToc_GetByMagID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intMagID", OracleType.Number)).Value = MagID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetMagazineNumberDetailTOCByMagID = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
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

        ' Purpose: Get all magazine detail Annotation by MagID
        ' Input: MagID
        ' Output: DataTable
        ' Created by: PhuongTT
        Public Function GetMagazineNumberDetailAnnotationByMagID(Optional ByVal intPage As Integer = 1, Optional ByVal intPageSize As Integer = 10) As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Opac_spItemMagNumberDetailAnn_GetByMagID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intMagID", SqlDbType.Int)).Value = MagID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetMagazineNumberDetailAnnotationByMagID = dsData.Tables("tblResult")
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
                        .CommandText = "OPAC.Opac_spItemMagNumberDetailAnn_GetByMagID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intMagID", OracleType.Number)).Value = MagID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetMagazineNumberDetailAnnotationByMagID = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
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


        ' Purpose: Get all magazine number home
        ' Input: MagID
        ' Output: DataTable
        ' Created by: PhuongTT
        Public Function GetMagazineNumberHome(Optional ByVal intLibID As Integer = 0) As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Opac_spItemMagNumberHome"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetMagazineNumberHome = dsData.Tables("tblResult")
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
                        .CommandText = "OPAC.Opac_spItemMagNumberHome"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetMagazineNumberHome = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
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
                    If Not sqlConnection Is Nothing Then
                        sqlConnection.Dispose()
                        sqlConnection = Nothing
                    End If
                    If Not sqlCommand Is Nothing Then
                        sqlCommand.Dispose()
                        sqlCommand = Nothing
                    End If
                    If Not sqlDataAdapter Is Nothing Then
                        sqlDataAdapter.Dispose()
                        sqlDataAdapter = Nothing
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