' Name: clsDAcqRequest
' Purpose: Management index of Issue
' Creator: PhuongTT
' Created Date: 2014.12.02
' Modification History:

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Serial
    Public Class clsDMagazine
        Inherits clsDBase

        'Mag no
        Private intId As Integer
        Private intMagId As Integer
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

        'Mag no Detail
        Private strFileName As String
        Private strXMLpath As String
        Private strThumnail As String
        Private intDownloadTimes As Integer
        Private dtmDateUpload As Object
        Private bolViewer As Boolean
        Private intFileSize As Integer
        Private strPath As String
        Private intPageNum As Integer


        'TOC
        Private intSubjectId As Integer
        Private intAuthorId As Integer
        Private strOverview As String
        Private dblcoordinatesX As Double
        Private dblcoordinatesY As Double

        'CAT_DIC_KEYWORD-AUTHOR
        Private strDisplayEntry As String
        Private strAccessEntry As String
        Private intDicItemID As Integer
        Private strVietnameseAccent As String

        'TOC-Annotation
        Private DblaWidth As Double
        Private DblaHeight As Double
        Private strtitle As String
        Private strlnk As String
        Private intmagDetailId As Integer
        Private straId As String
        Private intLibId As String

        Public Property aId() As String
            Get
                Return straId
            End Get
            Set(ByVal Value As String)
                straId = Value
            End Set
        End Property

        Public Property magDetailId() As Integer
            Get
                Return intmagDetailId
            End Get
            Set(ByVal Value As Integer)
                intmagDetailId = Value
            End Set
        End Property
        Public Property aWidth() As Double
            Get
                Return DblaWidth
            End Get
            Set(ByVal Value As Double)
                DblaWidth = Value
            End Set
        End Property
        Public Property aHeight() As Double
            Get
                Return DblaHeight
            End Get
            Set(ByVal Value As Double)
                DblaHeight = Value
            End Set
        End Property
        Public Property title() As String
            Get
                Return strtitle
            End Get
            Set(ByVal Value As String)
                strtitle = Value
            End Set
        End Property
        Public Property lnk() As String
            Get
                Return strlnk
            End Get
            Set(ByVal Value As String)
                strlnk = Value
            End Set
        End Property

        Public Property DisplayEntry() As String
            Get
                Return strDisplayEntry
            End Get
            Set(ByVal Value As String)
                strDisplayEntry = Value
            End Set
        End Property
        Public Property AccessEntry() As String
            Get
                Return strAccessEntry
            End Get
            Set(ByVal Value As String)
                strAccessEntry = Value
            End Set
        End Property
        Public Property DicItemID() As Integer
            Get
                Return intDicItemID
            End Get
            Set(ByVal Value As Integer)
                intDicItemID = Value
            End Set
        End Property
        Public Property VietnameseAccent() As String
            Get
                Return strVietnameseAccent
            End Get
            Set(ByVal Value As String)
                strVietnameseAccent = Value
            End Set
        End Property

        Public Property SubjectId() As Integer
            Get
                Return intSubjectId
            End Get
            Set(ByVal Value As Integer)
                intSubjectId = Value
            End Set
        End Property
        Public Property AuthorId() As Integer
            Get
                Return intAuthorId
            End Get
            Set(ByVal Value As Integer)
                intAuthorId = Value
            End Set
        End Property
        Public Property Overview() As String
            Get
                Return strOverview
            End Get
            Set(ByVal Value As String)
                strOverview = Value
            End Set
        End Property

        Public Property coordinatesX() As Double
            Get
                Return dblcoordinatesX
            End Get
            Set(ByVal Value As Double)
                dblcoordinatesX = Value
            End Set
        End Property
        Public Property coordinatesY() As Double
            Get
                Return dblcoordinatesY
            End Get
            Set(ByVal Value As Double)
                dblcoordinatesY = Value
            End Set
        End Property

        Public Property MagId() As Integer
            Get
                Return intMagId
            End Get
            Set(ByVal Value As Integer)
                intMagId = Value
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

        Public Property eNumMag() As String
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
        Public Property LibID() As Integer
            Get
                Return intLibID
            End Get
            Set(ByVal Value As Integer)
                intLibID = Value
            End Set
        End Property



        ' getAllSerialItems method
        ' Purpose: Get all the collection of items
        ' Creator: PhuongTT - 2014.12.01
        Public Function getAllSerialItems() As DataTable
            'If strSQL = "" Then
            '    Exit Function
            'End If
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "Select * from vGetAllSerial where " + Convert.ToString(intLibId) + " = 0 or LibID = " + Convert.ToString(intLibId)
                        .CommandType = CommandType.Text
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblItemDetails")
                            getAllSerialItems = dsData.Tables("tblItemDetails")
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
                    With sqlCommand
                        .CommandText = "Select * from vGetAllSerial where " + Convert.ToString(intLibId) + " = 0 or LibID = " + Convert.ToString(intLibId)
                        .CommandType = CommandType.Text
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblItemDetails")
                            getAllSerialItems = dsData.Tables("tblItemDetails")
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

        ' Method: getAllMagazineByItemID  
        ' Purpose: Get list of Table of content by ItemID
        ' Input: ItemID
        ' Output: DataTable result
        Public Function getAllMagazineByItemID() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Ser_spTocByItemID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = ItemID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            getAllMagazineByItemID = dsData.Tables("tblResult")
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
                        .CommandText = "SERIAL.SP_SER_TOC_BY_ITEMID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = ItemID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            getAllMagazineByItemID = dsData.Tables("tblResult")
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


        ' Method: getMagazineByMagNo  
        ' Purpose: Get list of Table of content by ItemID
        ' Input: ItemID
        ' Output: DataTable result
        Public Function getMagazineByMagNo(ByVal strUpdateNumNew As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Ser_spTocCheckExist"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strNum", SqlDbType.NVarChar, 200)).Value = eNumMag
                            .Parameters.Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = eYear
                            .Parameters.Add(New SqlParameter("@strUpdateNumNew", SqlDbType.NVarChar, 200)).Value = strUpdateNumNew
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            getMagazineByMagNo = dsData.Tables("tblResult")
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
                        .CommandText = "SERIAL.SP_SER_TOC_CHECK_EXIST"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strNum", OracleType.NVarChar, 200)).Value = eNumMag
                            .Parameters.Add(New OracleParameter("intYear", OracleType.Number)).Value = eYear
                            .Parameters.Add(New OracleParameter("strUpdateNumNew", OracleType.NVarChar, 200)).Value = strUpdateNumNew
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            getMagazineByMagNo = dsData.Tables("tblResult")
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

        ' Method: getAllMagazineByItemID  
        ' Purpose: Get list of Table of content by ItemID
        ' Input: ItemID
        ' Output: DataTable result
        Public Function getMagazineByMagID() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Ser_spTocMagByMagID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intMagID", SqlDbType.Int)).Value = MagId
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            getMagazineByMagID = dsData.Tables("tblResult")
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
                        .CommandText = "SERIAL.SP_SER_TOC_MAG_BY_MAGID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intMagID", OracleType.Number)).Value = MagId
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            getMagazineByMagID = dsData.Tables("tblResult")
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

        ' Method: getAllMagazineByItemID  
        ' Purpose: Get list of Table of content by ItemID
        ' Input: ItemID
        ' Output: DataTable result
        Public Function getMagazineDetailByMagID() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Ser_spTocMagDetailByMagID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intMagID", SqlDbType.Int)).Value = MagId
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            getMagazineDetailByMagID = dsData.Tables("tblResult")
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
                        .CommandText = "SERIAL.SP_SER_TOC_MAG_DETAIL_BY_MAGID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intMagID", OracleType.Number)).Value = MagId
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            getMagazineDetailByMagID = dsData.Tables("tblResult")
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

        ' updateMagazineDetai method
        ' Purpose: Update information into magazine detail
        ' Input: Some row in metadata
        ' Output: Return id
        Public Function updateMagazineDetai(ByVal intUpdate As Integer) As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_SER_INSERT_MAG_DETAIL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intUpdate", OracleType.Number)).Value = intUpdate
                            .Parameters.Add(New OracleParameter("MagId", OracleType.Number)).Value = MagId
                            .Parameters.Add(New OracleParameter("FileName", OracleType.NVarChar, 50)).Value = FileName
                            .Parameters.Add(New OracleParameter("Status", OracleType.Number)).Value = Status
                            .Parameters.Add(New OracleParameter("DownloadTimes", OracleType.Number)).Value = DownloadTimes
                            .Parameters.Add(New OracleParameter("FileSize", OracleType.Number)).Value = FileSize
                            .Parameters.Add(New OracleParameter("Path", OracleType.NVarChar, 500)).Value = Path
                            .Parameters.Add(New OracleParameter("PageNum", OracleType.Number)).Value = PageNum
                            .Parameters.Add(New OracleParameter("Id", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            updateMagazineDetai = .Parameters.Item("Id").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Ser_spInsertMagDetail"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intUpdate", SqlDbType.Int)).Value = intUpdate
                            .Parameters.Add(New SqlParameter("@MagId", SqlDbType.Int)).Value = MagId
                            .Parameters.Add(New SqlParameter("@FileName", SqlDbType.NVarChar, 50)).Value = FileName
                            .Parameters.Add(New SqlParameter("@Status", SqlDbType.Int)).Value = Status
                            .Parameters.Add(New SqlParameter("@DownloadTimes", SqlDbType.Int)).Value = DownloadTimes
                            .Parameters.Add(New SqlParameter("@FileSize", SqlDbType.Int)).Value = FileSize
                            .Parameters.Add(New SqlParameter("@Path", SqlDbType.NVarChar, 500)).Value = Path
                            .Parameters.Add(New SqlParameter("@PageNum", SqlDbType.Int)).Value = PageNum
                            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            updateMagazineDetai = .Parameters.Item("@Id").Value
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


        ' insertMagazineNo method
        ' Purpose: Update information into magazine detail
        ' Input: Some row in metadata
        ' Output: Return o or 1
        Public Function insertMagazineNo() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_SER_INSERT_MAG"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("eYear", OracleType.Number)).Value = eYear
                            .Parameters.Add(New OracleParameter("eMonth", OracleType.Number)).Value = eMonth
                            .Parameters.Add(New OracleParameter("eDay", OracleType.Number)).Value = eDay
                            .Parameters.Add(New OracleParameter("ItemID", OracleType.Number)).Value = ItemID
                            .Parameters.Add(New OracleParameter("Description", OracleType.NVarChar, 2000)).Value = Description
                            .Parameters.Add(New OracleParameter("eNum", OracleType.NVarChar, 100)).Value = eNumMag
                            .Parameters.Add(New OracleParameter("userName", OracleType.NVarChar, 100)).Value = userName
                            .Parameters.Add(New OracleParameter("Id", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            insertMagazineNo = .Parameters.Item("Id").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Ser_spInserMag"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@eYear", SqlDbType.Int)).Value = eYear
                            .Parameters.Add(New SqlParameter("@eMonth", SqlDbType.Int)).Value = eMonth
                            .Parameters.Add(New SqlParameter("@eDay", SqlDbType.Int)).Value = eDay
                            .Parameters.Add(New SqlParameter("@ItemID", SqlDbType.Int)).Value = ItemID
                            .Parameters.Add(New SqlParameter("@Description", SqlDbType.NVarChar, 2000)).Value = Description
                            .Parameters.Add(New SqlParameter("@eNum", SqlDbType.NVarChar, 100)).Value = eNumMag
                            .Parameters.Add(New SqlParameter("@userName", SqlDbType.NVarChar, 100)).Value = userName
                            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            insertMagazineNo = .Parameters.Item("@Id").Value
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


        ' insertMagazineNo method
        ' Purpose: Update information into magazine detail
        ' Input: Some row in metadata
        ' Output: Return o or 1
        Public Function updateMagazineNo() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_SER_UPDATE_MAG"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intMagID", OracleType.Number)).Value = MagId
                            .Parameters.Add(New OracleParameter("eYear", OracleType.Number)).Value = eYear
                            .Parameters.Add(New OracleParameter("eMonth", OracleType.Number)).Value = eMonth
                            .Parameters.Add(New OracleParameter("eDay", OracleType.Number)).Value = eDay
                            .Parameters.Add(New OracleParameter("Description", OracleType.NVarChar, 2000)).Value = Description
                            .Parameters.Add(New OracleParameter("eNum", OracleType.NVarChar, 100)).Value = eNumMag
                            .Parameters.Add(New OracleParameter("userNameUpdate", OracleType.NVarChar, 100)).Value = userNameUpdate
                            .Parameters.Add(New OracleParameter("Id", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            updateMagazineNo = .Parameters.Item("Id").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Ser_spUpdateMag"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intMagID", SqlDbType.Int)).Value = MagId
                            .Parameters.Add(New SqlParameter("@eYear", SqlDbType.Int)).Value = eYear
                            .Parameters.Add(New SqlParameter("@eMonth", SqlDbType.Int)).Value = eMonth
                            .Parameters.Add(New SqlParameter("@eDay", SqlDbType.Int)).Value = eDay
                            .Parameters.Add(New SqlParameter("@Description", SqlDbType.NVarChar, 2000)).Value = Description
                            .Parameters.Add(New SqlParameter("@eNum", SqlDbType.NVarChar, 100)).Value = eNumMag
                            .Parameters.Add(New SqlParameter("@userNameUpdate", SqlDbType.NVarChar, 100)).Value = userNameUpdate
                            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            updateMagazineNo = .Parameters.Item("@Id").Value
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

        ' deleteMagazineNo method
        ' Purpose: Delete (magazine - magazine detail)
        ' Input: Some row in metadata
        ' Output: Return o or 1
        Public Function deleteMagazineNo() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_SER_DELETE_MAG"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intMagID", OracleType.Number)).Value = MagId
                            .Parameters.Add(New OracleParameter("Id", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            deleteMagazineNo = .Parameters.Item("Id").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Ser_spDeleteMag"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intMagId", SqlDbType.Int)).Value = MagId
                            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            deleteMagazineNo = .Parameters.Item("@Id").Value
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

        ' Method: getAnnotationByMagID  
        ' Purpose: Get list of Table of content by MagDetailID
        ' Input: MagDetailID
        ' Output: DataTable result
        Public Function getAnnotationByMagID() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Ser_spTocAnnByMagID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intMagID", SqlDbType.Int)).Value = MagId
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            getAnnotationByMagID = dsData.Tables("tblResult")
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
                        .CommandText = "SERIAL.SP_SER_TOC_ANNOTAION_BY_MAGID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intMagID", OracleType.Number)).Value = MagId
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            getAnnotationByMagID = dsData.Tables("tblResult")
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

        ' Method: getManazineTOCByID  
        ' Purpose: Get list of Table of content by MagTOCID
        ' Input: MagDetailID
        ' Output: DataTable result
        Public Function getManazineTOCByID() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Ser_spMagazineTocByID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@ID", SqlDbType.Int)).Value = Id
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            getManazineTOCByID = dsData.Tables("tblResult")
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
                        .CommandText = "SERIAL.sp_SER_MAGAZINE_TOC_BY_ID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("ID", OracleType.Number)).Value = Id
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            getManazineTOCByID = dsData.Tables("tblResult")
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

        ' Method: getManazineTOCByMagDetailID  
        ' Purpose: Get list of Table of content by MagDetailID
        ' Input: MagDetailID
        ' Output: DataTable result
        Public Function getManazineTOCByMagDetailID() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Ser_spMagazineTocByMagDetailID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intMagDetailID", SqlDbType.Int)).Value = intMagId
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            getManazineTOCByMagDetailID = dsData.Tables("tblResult")
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
                        .CommandText = "SERIAL.sp_SER_MAGAZINE_TOC_BY_MAGDETAILID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intMagDetailID", OracleType.Number)).Value = MagId
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            getManazineTOCByMagDetailID = dsData.Tables("tblResult")
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



        ' insertMagazineTOC method
        ' Purpose: Insert information into magazine detail TOC
        ' Input: Some row in metadata
        ' Output: Return id
        Public Function insertMagazineTOC() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.sp_SER_MAGAZINE_TOC_INS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("MagDetailId", OracleType.Number)).Value = MagId
                            .Parameters.Add(New OracleParameter("SubjectId", OracleType.Number)).Value = SubjectId
                            .Parameters.Add(New OracleParameter("AuthorId", OracleType.Number)).Value = AuthorId
                            .Parameters.Add(New OracleParameter("Overview", OracleType.NVarChar, 500)).Value = Overview
                            .Parameters.Add(New OracleParameter("PageNum", OracleType.Number)).Value = PageNum
                            .Parameters.Add(New OracleParameter("userName", OracleType.NVarChar, 100)).Value = userName
                            .Parameters.Add(New OracleParameter("coordinatesX", OracleType.Float)).Value = coordinatesX
                            .Parameters.Add(New OracleParameter("coordinatesY", OracleType.Float)).Value = coordinatesY
                            .Parameters.Add(New OracleParameter("IdOUT", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            insertMagazineTOC = .Parameters.Item("IdOUT").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Ser_spMagazineTocIns"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@MagDetailId", SqlDbType.Int)).Value = MagId
                            .Parameters.Add(New SqlParameter("@SubjectId", SqlDbType.Int)).Value = SubjectId
                            .Parameters.Add(New SqlParameter("@AuthorId", SqlDbType.NVarChar, 50)).Value = AuthorId
                            .Parameters.Add(New SqlParameter("@Overview", SqlDbType.NVarChar, 500)).Value = Overview
                            .Parameters.Add(New SqlParameter("@PageNum", SqlDbType.Int)).Value = PageNum
                            .Parameters.Add(New SqlParameter("@userName", SqlDbType.NVarChar, 100)).Value = userName
                            .Parameters.Add(New SqlParameter("@coordinatesX", SqlDbType.Float)).Value = coordinatesX
                            .Parameters.Add(New SqlParameter("@coordinatesY", SqlDbType.Float)).Value = coordinatesY
                            .Parameters.Add(New SqlParameter("@IdOUT", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            insertMagazineTOC = .Parameters.Item("@IdOUT").Value
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


        ' updateMagazineTOC method
        ' Purpose: update information magazine detail TOC
        ' Input: Some row in metadata
        ' Output: Return id
        Public Function updateMagazineTOC() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.sp_SER_MAGAZINE_TOC_UPD"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("Id", OracleType.Number)).Value = Id
                            .Parameters.Add(New OracleParameter("SubjectId", OracleType.Number)).Value = SubjectId
                            .Parameters.Add(New OracleParameter("AuthorId", OracleType.Number)).Value = AuthorId
                            .Parameters.Add(New OracleParameter("Overview", OracleType.NVarChar, 500)).Value = Overview
                            .Parameters.Add(New OracleParameter("PageNum", OracleType.Number)).Value = PageNum
                            .Parameters.Add(New OracleParameter("userNameUpdate", OracleType.NVarChar, 100)).Value = userName
                            .Parameters.Add(New OracleParameter("coordinatesX", OracleType.Float)).Value = coordinatesX
                            .Parameters.Add(New OracleParameter("coordinatesY", OracleType.Float)).Value = coordinatesY
                            .Parameters.Add(New OracleParameter("IdOUT", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            updateMagazineTOC = .Parameters.Item("IdOUT").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Ser_spMagazineTocUpd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int)).Value = Id
                            .Parameters.Add(New SqlParameter("@SubjectId", SqlDbType.Int)).Value = SubjectId
                            .Parameters.Add(New SqlParameter("@AuthorId", SqlDbType.NVarChar, 50)).Value = AuthorId
                            .Parameters.Add(New SqlParameter("@Overview", SqlDbType.NVarChar, 500)).Value = Overview
                            .Parameters.Add(New SqlParameter("@PageNum", SqlDbType.Int)).Value = PageNum
                            .Parameters.Add(New SqlParameter("@userNameUpdate", SqlDbType.NVarChar, 100)).Value = userNameUpdate
                            .Parameters.Add(New SqlParameter("@coordinatesX", SqlDbType.Float)).Value = coordinatesX
                            .Parameters.Add(New SqlParameter("@coordinatesY", SqlDbType.Float)).Value = coordinatesY
                            .Parameters.Add(New SqlParameter("@IdOUT", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            updateMagazineTOC = .Parameters.Item("@IdOUT").Value
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


        ' deleteMagazineTOC method
        ' Purpose: delete magazine detail TOC
        ' Input: Some row in metadata
        ' Output: Return id
        Public Function deleteMagazineTOC() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.sp_SER_MAGAZINE_TOC_DEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intID", OracleType.Number)).Value = Id
                            .Parameters.Add(New OracleParameter("IdOUT", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            deleteMagazineTOC = .Parameters.Item("IdOUT").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Ser_spMagazineTocDel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Value = Id
                            .Parameters.Add(New SqlParameter("@IdOUT", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            deleteMagazineTOC = .Parameters.Item("@IdOUT").Value
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

        ' insertMagazineTOCForKeyWord method
        ' Purpose: Insert information into Cat_tblDic_keyword
        ' Input: Some row in metadata
        ' Output: Return id
        Public Function insertMagazineTOCForKeyWord() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.sp_SER_MAGAZINE_TOC_KEYWORD_INS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("DisplayEntry", OracleType.NVarChar, 500)).Value = DisplayEntry
                            .Parameters.Add(New OracleParameter("AccessEntry", OracleType.NVarChar, 500)).Value = AccessEntry
                            .Parameters.Add(New OracleParameter("VietnameseAccent", OracleType.NVarChar, 500)).Value = VietnameseAccent
                            .Parameters.Add(New OracleParameter("IdOUT", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            insertMagazineTOCForKeyWord = .Parameters.Item("IdOUT").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Ser_spMagazineTocKeywordIns"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@DisplayEntry", SqlDbType.NVarChar, 500)).Value = DisplayEntry
                            .Parameters.Add(New SqlParameter("@AccessEntry", SqlDbType.NVarChar, 500)).Value = AccessEntry
                            .Parameters.Add(New SqlParameter("@VietnameseAccent", SqlDbType.NVarChar, 500)).Value = VietnameseAccent
                            .Parameters.Add(New SqlParameter("@IdOUT", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            insertMagazineTOCForKeyWord = .Parameters.Item("@IdOUT").Value
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

        ' insertMagazineTOCAuthor method
        ' Purpose: Insert information into Cat_tblDic_Author
        ' Input: Some row in metadata
        ' Output: Return id
        Public Function insertMagazineTOCForAuthor() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.sp_SER_MAGAZINE_TOC_AUTHOR_INS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("DisplayEntry", OracleType.NVarChar, 500)).Value = DisplayEntry
                            .Parameters.Add(New OracleParameter("AccessEntry", OracleType.NVarChar, 500)).Value = AccessEntry
                            .Parameters.Add(New OracleParameter("VietnameseAccent", OracleType.NVarChar, 500)).Value = VietnameseAccent
                            .Parameters.Add(New OracleParameter("IdOUT", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            insertMagazineTOCForAuthor = .Parameters.Item("IdOUT").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Ser_spMagazineTocAuthorIns"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@DisplayEntry", SqlDbType.NVarChar, 500)).Value = DisplayEntry
                            .Parameters.Add(New SqlParameter("@AccessEntry", SqlDbType.NVarChar, 500)).Value = AccessEntry
                            .Parameters.Add(New SqlParameter("@VietnameseAccent", SqlDbType.NVarChar, 500)).Value = VietnameseAccent
                            .Parameters.Add(New SqlParameter("@IdOUT", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            insertMagazineTOCForAuthor = .Parameters.Item("@IdOUT").Value
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


        ' updateMagazineTOCAnnotation method
        ' Purpose: update information magazine detail TOC Annotaiton
        ' Input: Some row in metadata
        ' Output: Return id
        Public Function updateMagazineTOCAnnotation() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.sp_SER_MAGAZINE_TOC_ANNOTATION_UPD"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("magDetailId", OracleType.Number)).Value = magDetailId
                            .Parameters.Add(New OracleParameter("aId", OracleType.NVarChar, 50)).Value = aId
                            .Parameters.Add(New OracleParameter("coordinatesX", OracleType.Float)).Value = coordinatesX
                            .Parameters.Add(New OracleParameter("coordinatesY", OracleType.Float)).Value = coordinatesY
                            .Parameters.Add(New OracleParameter("aWidth", OracleType.Number)).Value = aWidth
                            .Parameters.Add(New OracleParameter("aHeight", OracleType.Number)).Value = aHeight
                            .Parameters.Add(New OracleParameter("title", OracleType.NVarChar, 150)).Value = title
                            .Parameters.Add(New OracleParameter("lnk", OracleType.NVarChar, 500)).Value = lnk
                            .Parameters.Add(New OracleParameter("IdOUT", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            updateMagazineTOCAnnotation = .Parameters.Item("IdOUT").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Ser_spMagazineTocAnnUpd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@magDetailId", SqlDbType.Int)).Value = magDetailId
                            .Parameters.Add(New SqlParameter("@aId", SqlDbType.NVarChar, 50)).Value = aId
                            .Parameters.Add(New SqlParameter("@coordinatesX", SqlDbType.Float)).Value = coordinatesX
                            .Parameters.Add(New SqlParameter("@coordinatesY", SqlDbType.Float)).Value = coordinatesY
                            .Parameters.Add(New SqlParameter("@aWidth", SqlDbType.Float)).Value = aWidth
                            .Parameters.Add(New SqlParameter("@aHeight", SqlDbType.Float)).Value = aHeight
                            .Parameters.Add(New SqlParameter("@title", SqlDbType.NVarChar, 150)).Value = title
                            .Parameters.Add(New SqlParameter("@lnk", SqlDbType.NVarChar, 500)).Value = lnk
                            .Parameters.Add(New SqlParameter("@IdOUT", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            updateMagazineTOCAnnotation = .Parameters.Item("@IdOUT").Value
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


        ' deleteMagazineTOCAnnotation method
        ' Purpose: delete magazine detail TOC Annotaiton
        ' Input: Some row in metadata
        ' Output: Return id
        Public Function deleteMagazineTOCAnnotation() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.sp_SER_MAGAZINE_TOC_ANNOTATION_DEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("magDetailId", OracleType.Number)).Value = magDetailId
                            .Parameters.Add(New OracleParameter("aId", OracleType.NVarChar, 50)).Value = aId
                            .Parameters.Add(New OracleParameter("IdOUT", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            deleteMagazineTOCAnnotation = .Parameters.Item("IdOUT").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Ser_spMagazineTocAnnDel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@magDetailId", SqlDbType.Int)).Value = magDetailId
                            .Parameters.Add(New SqlParameter("@aId", SqlDbType.NVarChar, 50)).Value = aId
                            .Parameters.Add(New SqlParameter("@IdOUT", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            deleteMagazineTOCAnnotation = .Parameters.Item("@IdOUT").Value
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
                Call MyBase.Dispose(isDisposing)
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace