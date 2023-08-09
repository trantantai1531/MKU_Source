' Purpose: process libraries location informations
' Creator: Lent
' Created Date: 17-2-2005
' Last Modified Date: 
' modify : lent 2-3 -2005

Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Acquisition
    Public Class clsDLocation
        Inherits clsDBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Private intLibID As Integer
        Private intLocID As Integer
        Private strSymbol As String
        Private intSouLocID As Integer
        Private intDesLocID As Integer
        Private intStatus As Integer
        Private strLocIDs As String
        Private strShelf As String
        Private strImgURL As String
        Private intImgWidth As Integer
        Private intImgHeight As Integer
        Private intTopCoor As Integer
        Private intLeftCoor As Integer
        Private dbImgWidthMetter As Single
        Private dbImgHeightMetter As Single
        Private intWidth As Integer
        Private intDepth As Integer
        Private intDirection As Integer
        Private strSelShelf As String
        Private strCodeLoc As String
        Private byteImgByte() As Byte

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************

        ' Library ID property
        Public Property LibID() As Integer
            Get
                Return (intLibID)
            End Get
            Set(ByVal Value As Integer)
                intLibID = Value
            End Set
        End Property
        ' intStatus property
        Public Property Status() As Integer
            Get
                Return (intStatus)
            End Get
            Set(ByVal Value As Integer)
                intStatus = Value
            End Set
        End Property

        ' StoreID property
        Public Property LocID() As Integer
            Get
                Return (intLocID)
            End Get
            Set(ByVal Value As Integer)
                intLocID = Value
            End Set
        End Property

        ' Symbol property
        Public Property Symbol() As String
            Get
                Return (strSymbol)
            End Get
            Set(ByVal Value As String)
                strSymbol = Value
            End Set
        End Property

        ' Code property
        Public Property CodeLoc() As String
            Get
                Return (strCodeLoc)
            End Get
            Set(ByVal Value As String)
                strCodeLoc = Value
            End Set
        End Property

        ' SouLocID property
        Public Property SouLocID() As Integer
            Get
                Return (intSouLocID)
            End Get
            Set(ByVal Value As Integer)
                intSouLocID = Value
            End Set
        End Property

        ' DesLocID property
        Public Property DesLocID() As Integer
            Get
                Return (intDesLocID)
            End Get
            Set(ByVal Value As Integer)
                intDesLocID = Value
            End Set
        End Property
        Public Property LocIDs() As String
            Get
                Return (strLocIDs)
            End Get
            Set(ByVal Value As String)
                strLocIDs = Value
            End Set
        End Property
        Public Property Shelf() As String
            Get
                Return (strShelf)
            End Get
            Set(ByVal Value As String)
                strShelf = Value
            End Set
        End Property
        Public Property ImgURL() As String
            Get
                Return (strImgURL)
            End Get
            Set(ByVal Value As String)
                strImgURL = Value
            End Set
        End Property
        Public Property ImgWidth() As Integer
            Get
                Return (intImgWidth)
            End Get
            Set(ByVal Value As Integer)
                intImgWidth = Value
            End Set
        End Property
        Public Property ImgHeight() As Integer
            Get
                Return (intImgHeight)
            End Get
            Set(ByVal Value As Integer)
                intImgHeight = Value
            End Set
        End Property
        Public Property TopCoor() As Integer
            Get
                Return (intTopCoor)
            End Get
            Set(ByVal Value As Integer)
                intTopCoor = Value
            End Set
        End Property
        Public Property LeftCoor() As Integer
            Get
                Return (intLeftCoor)
            End Get
            Set(ByVal Value As Integer)
                intLeftCoor = Value
            End Set
        End Property
        Public Property ImgWidthMetter() As Single
            Get
                Return (dbImgWidthMetter)
            End Get
            Set(ByVal Value As Single)
                dbImgWidthMetter = Value
            End Set
        End Property
        Public Property ImgHeightMetter() As Single
            Get
                Return (dbImgHeightMetter)
            End Get
            Set(ByVal Value As Single)
                dbImgHeightMetter = Value
            End Set
        End Property
        Public Property Width() As Integer
            Get
                Return (intWidth)
            End Get
            Set(ByVal Value As Integer)
                intWidth = Value
            End Set
        End Property

        Public Property Depth() As Integer
            Get
                Return (intDepth)
            End Get
            Set(ByVal Value As Integer)
                intDepth = Value
            End Set
        End Property

        Public Property Direction() As Integer
            Get
                Return (intDirection)
            End Get
            Set(ByVal Value As Integer)
                intDirection = Value
            End Set
        End Property
        Public Property SelShelf() As String
            Get
                Return (strSelShelf)
            End Get
            Set(ByVal Value As String)
                strSelShelf = Value
            End Set
        End Property

        Public Property ImgByte() As Byte()
            Get
                Return (byteImgByte)
            End Get
            Set(ByVal Value As Byte())
                byteImgByte = Value
            End Set
        End Property

        ' *************************************************************************************************
        ' End declare properties
        ' Declare public function 
        ' *************************************************************************************************

        ' Purpose: insert and getID one location from library
        ' Input: location informations
        ' Output: Create and get ID
        ' Creator: PhuongTT
        ' CreatedDate: 01-07-2008
        Public Function CreateAndGetID() As Integer
            Dim intRetVal As Integer = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_HOLDING_LOCATION_INS_GETID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                                .Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                                .Add(New OracleParameter("strSymbol", OracleType.VarChar, 50)).Value = strSymbol
                                .Add(New OracleParameter("strCodeLoc", OracleType.VarChar, 100)).Value = strCodeLoc
                                .Add(New OracleParameter("intRetVal", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("intRetVal").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHoldingLocation_InsSelId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                                .Add(New SqlParameter("@strSymbol", SqlDbType.NVarChar)).Value = strSymbol
                                .Add(New SqlParameter("@intRetVal", SqlDbType.Int)).Direction = ParameterDirection.Output
                                .Add(New SqlParameter("@strCodeLoc", SqlDbType.NVarChar, 100)).Value = strCodeLoc
                            End With
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("@intRetVal").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()

            CreateAndGetID = intRetVal
        End Function


        ' Purpose: insert one location into library
        ' Input: location informations
        ' Output: 0 if success
        ' Creator: lent
        ' CreatedDate: 17-2-2005
        Public Function Create() As Integer
            Dim intRetVal As Integer = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_HOLDING_LOCATION_INS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                                .Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                                .Add(New OracleParameter("strSymbol", OracleType.VarChar, 50)).Value = strSymbol
                                .Add(New OracleParameter("strCodeLoc", OracleType.VarChar, 100)).Value = strCodeLoc
                                .Add(New OracleParameter("intRetVal", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("intRetVal").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHoldingLocation_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                                .Add(New SqlParameter("@strSymbol", SqlDbType.NVarChar)).Value = strSymbol
                                .Add(New SqlParameter("@intRetVal", SqlDbType.Int)).Direction = ParameterDirection.Output
                                .Add(New SqlParameter("@strCodeLoc", SqlDbType.NVarChar, 100)).Value = strCodeLoc
                            End With
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("@intRetVal").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()

            Create = intRetVal
        End Function

        ' Method: Update
        ' Purpose: change information of location into library
        ' Input: sysmbol, status 
        ' Output: 0 if success
        ' Creator: lent
        ' CreatedDate: 17-2-2005
        Public Function Update() As Integer
            Dim intRetVal As Integer = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_HOLDING_LOCATION_UPD"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocID
                                .Add(New OracleParameter("strSymbol", OracleType.VarChar, 50)).Value = strSymbol
                                .Add(New OracleParameter("strCodeLoc", OracleType.VarChar, 100)).Value = strCodeLoc
                                .Add(New OracleParameter("intRetVal", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("intRetVal").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHoldingLocation_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocID
                                .Add(New SqlParameter("@strSymbol", SqlDbType.NVarChar, 50)).Value = strSymbol
                                .Add(New SqlParameter("@intRetVal", SqlDbType.Int)).Direction = ParameterDirection.Output
                                .Add(New SqlParameter("@strCodeLoc", SqlDbType.NVarChar, 100)).Value = strCodeLoc
                            End With
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("@intRetVal").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()

            Update = intRetVal
        End Function

        ' Purpose: Get MinID, MaxID from Holding in one Location, for SQL only
        ' Input: LocID
        ' Output: Datatable
        ' Creator: Sondp
        ' CreatedDate: 15-11-2005
        Public Function GetMin_Max_ID() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE" ' do nothing
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHolding_SelMinMaxHoldingId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocID
                            End With
                            .ExecuteNonQuery()
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetMin_Max_ID = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose: change status of location into library: Open,close location
        ' Input: some infor
        ' Output:
        ' Creator: lent
        ' CreatedDate: 18-2-2005
        Public Sub UpdateStatusLocation()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_HOLDING_LOCATION_UPD_STATUS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strLocIDs", OracleType.VarChar, 200)).Value = strLocIDs
                                .Add(New OracleParameter("intStatus", OracleType.Number)).Value = intStatus
                                .Add(New OracleParameter("strShelf", OracleType.VarChar, 20)).Value = strShelf
                            End With
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
                        .CommandText = "Lib_spHoldingLocation_UpdStatus"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strLocIDs", SqlDbType.VarChar, 100)).Value = strLocIDs
                                .Add(New SqlParameter("@strShelf", SqlDbType.NVarChar, 20)).Value = strShelf
                                .Add(New SqlParameter("@bitStatus", SqlDbType.Bit)).Value = intStatus
                            End With
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

        ' Purpose: merger one location into other location
        ' Input: 
        ' Output:
        ' Creator: lent
        ' CreatedDate: 17-2-2005
        Public Sub MergeLocation(ByVal strSouLocIDs As String)
            Call OpenConnection()

            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_HOLDING_LOCATION_MER"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                                .Add(New OracleParameter("strSouLocIDs", OracleType.VarChar, 1000)).Value = strSouLocIDs
                                .Add(New OracleParameter("intDesLocID", OracleType.Number)).Value = intDesLocID
                            End With
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
                        .CommandText = "Acq_spHoldingLocation_Merge"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                                .Add(New SqlParameter("@strSouLocIDs", SqlDbType.VarChar, 1000)).Value = strSouLocIDs
                                .Add(New SqlParameter("@intDesLocID", SqlDbType.Int)).Value = intDesLocID
                            End With
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

        ' Purpose: create new position of  location
        ' Input: 
        ' Output:
        ' Creator: lent
        ' CreatedDate: 8-3-2005
        Public Sub CreateLocPosition()
            Call OpenConnection()

            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_HOLDING_LOC_SCHEMA_INSERT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocID
                                .Add(New OracleParameter("strImgURL", OracleType.VarChar, 200)).Value = strImgURL
                                .Add(New OracleParameter("intImgWidth", OracleType.Number)).Value = intImgWidth
                                .Add(New OracleParameter("intImgHeight", OracleType.Number)).Value = intImgHeight
                                .Add(New OracleParameter("intTopCoor", OracleType.Number)).Value = intTopCoor
                                .Add(New OracleParameter("intLeftCoor", OracleType.Number)).Value = intLeftCoor
                                .Add(New OracleParameter("dbImgWidthMetter", OracleType.Float)).Value = dbImgWidthMetter
                                .Add(New OracleParameter("dbImgHeightMetter", OracleType.Float)).Value = dbImgHeightMetter
                                '.Add(New OracleParameter("byteImgByte", OracleType.Blob, byteImgByte.LongLength)).Value = byteImgByte
                            End With
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try

                        .CommandText = "update HOLDING_LOCATION_SCHEMA set ImgByte=:byteImgByte where LocID=:intLocID"
                        .CommandType = CommandType.Text
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocID
                                .Add(New OracleParameter("byteImgByte", OracleType.Blob, byteImgByte.LongLength)).Value = byteImgByte
                            End With
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
                        .CommandText = "Lib_spHoldingLocationSchema_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocID
                                .Add(New SqlParameter("@strImgURL", SqlDbType.NVarChar)).Value = strImgURL
                                .Add(New SqlParameter("@intImgWidth", SqlDbType.Int)).Value = intImgWidth
                                .Add(New SqlParameter("@intImgHeight", SqlDbType.Int)).Value = intImgHeight
                                .Add(New SqlParameter("@intTopCoor", SqlDbType.Int)).Value = intTopCoor
                                .Add(New SqlParameter("@intLeftCoor", SqlDbType.Int)).Value = intLeftCoor
                                .Add(New SqlParameter("@dbImgWidthMetter", SqlDbType.Real)).Value = dbImgWidthMetter
                                .Add(New SqlParameter("@dbImgHeightMetter", SqlDbType.Real)).Value = dbImgHeightMetter
                                .Add(New SqlParameter("@byteImgByte", SqlDbType.Image)).Value = byteImgByte
                            End With
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
        ' Purpose: Update one position of  location
        ' Input: 
        ' Output:
        ' Creator: lent
        ' CreatedDate: 8-3-2005
        Public Sub UpdateLocPosition()
            Call OpenConnection()

            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_HOLDING_LOC_SCHEMA_UPDATE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocID
                                .Add(New OracleParameter("strImgURL", OracleType.VarChar, 200)).Value = strImgURL
                                .Add(New OracleParameter("intImgWidth", OracleType.Number)).Value = intImgWidth
                                .Add(New OracleParameter("intImgHeight", OracleType.Number)).Value = intImgHeight
                                .Add(New OracleParameter("intTopCoor", OracleType.Number)).Value = intTopCoor
                                .Add(New OracleParameter("intLeftCoor", OracleType.Number)).Value = intLeftCoor
                                .Add(New OracleParameter("dbImgWidthMetter", OracleType.Float)).Value = dbImgWidthMetter
                                .Add(New OracleParameter("dbImgHeightMetter", OracleType.Float)).Value = dbImgHeightMetter
                            End With
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                        If strImgURL <> "" Then
                            .CommandText = "update HOLDING_LOCATION_SCHEMA set ImgByte=:byteImgByte where LocID=:intLocID"
                            .CommandType = CommandType.Text
                            Try
                                With .Parameters
                                    .Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocID
                                    .Add(New OracleParameter("byteImgByte", OracleType.Blob, byteImgByte.LongLength)).Value = byteImgByte
                                End With
                                .ExecuteNonQuery()
                            Catch OraEx As OracleException
                                strErrorMsg = OraEx.Message.ToString
                                intErrorCode = OraEx.Code
                            Finally
                                .Parameters.Clear()
                            End Try
                        End If
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHoldingLocationSchema_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocID
                                .Add(New SqlParameter("@strImgURL", SqlDbType.VarChar, 200)).Value = strImgURL
                                .Add(New SqlParameter("@intImgWidth", SqlDbType.Int)).Value = intImgWidth
                                .Add(New SqlParameter("@intImgHeight", SqlDbType.Int)).Value = intImgHeight
                                .Add(New SqlParameter("@intTopCoor", SqlDbType.Int)).Value = intTopCoor
                                .Add(New SqlParameter("@intLeftCoor", SqlDbType.Int)).Value = intLeftCoor
                                .Add(New SqlParameter("@dbImgWidthMetter", SqlDbType.Real)).Value = dbImgWidthMetter
                                .Add(New SqlParameter("@dbImgHeightMetter", SqlDbType.Real)).Value = dbImgHeightMetter
                                .Add(New SqlParameter("@byteImgByte", SqlDbType.Image)).Value = byteImgByte
                            End With
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

        ' Purpose: delete one position of  location
        ' Input: 
        ' Output:
        ' Creator: lent
        ' CreatedDate: 8-3-2005
        Public Sub DeleteLocPosition()
            Call OpenConnection()

            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_HOLDING_LOC_SCHEMA_DELETE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocID
                            End With
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
                        .CommandText = "Lib_spHoldingLocationSchema_DelByLocId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocID
                            End With
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
        ' Purpose : Get information Location and its schema 
        ' Input: intLibID,intUserID
        ' Output: Datatable
        ' Created by: Lent
        ' date : 8-3-2005
        Public Function GetHoldingLocSchema() As DataTable
            Call OpenConnection()

            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHoldingLocationSchema_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocID
                                .Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetHoldingLocSchema = dsData.Tables("tblResult")
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
                        .CommandText = "ACQUISITION.SP_HOLDING_LOC_SCHEMA_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                                .Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocID
                                .Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetHoldingLocSchema = dsData.Tables("tblResult")
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


        ' Purpose : Get information Location and its schema 
        ' Input: 
        ' Output: Datatable
        ' Created by: Minhns
        ' date : 8-3-2005
        Public Function GetHoldingLocationSchema() As DataTable
            Call OpenConnection()

            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHoldingLocationSchema_SelByLocId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetHoldingLocationSchema = dsData.Tables("tblResult")
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
                        .CommandText = "ACQUISITION.SP_HOLDING_LOC_SCHEMA"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetHoldingLocationSchema = dsData.Tables("tblResult")
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

        ' Purpose: create new shelf on position of location
        ' Input: 
        ' Output:
        ' Creator: lent
        ' CreatedDate: 8-3-2005
        Public Function CreateShelfPosition() As Integer
            Call OpenConnection()
            Dim intRetval As Integer = 0
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_HOLDING_SHELF_SCHEMA_INSERT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocID
                                .Add(New OracleParameter("strShelf", OracleType.VarChar, 32)).Value = strShelf
                                .Add(New OracleParameter("intWidth", OracleType.Number)).Value = intWidth
                                .Add(New OracleParameter("intDepth", OracleType.Number)).Value = intDepth
                                .Add(New OracleParameter("intTopCoor", OracleType.Number)).Value = intTopCoor
                                .Add(New OracleParameter("intLeftCoor", OracleType.Number)).Value = intLeftCoor
                                .Add(New OracleParameter("intDirection", OracleType.Number)).Value = intDirection
                                .Add(New OracleParameter("intRetVal", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetval = .Parameters("intRetval").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHoldingShelfSchema_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocID
                                .Add(New SqlParameter("@strShelf", SqlDbType.VarChar, 32)).Value = strShelf
                                .Add(New SqlParameter("@intWidth", SqlDbType.Int)).Value = intWidth
                                .Add(New SqlParameter("@intDepth", SqlDbType.Int)).Value = intDepth
                                .Add(New SqlParameter("@intTopCoor", SqlDbType.Int)).Value = intTopCoor
                                .Add(New SqlParameter("@intLeftCoor", SqlDbType.Int)).Value = intLeftCoor
                                .Add(New SqlParameter("@intDirection", SqlDbType.Int)).Value = intDirection
                                .Add(New SqlParameter("@intRetVal", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetval = .Parameters("@intRetval").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            CreateShelfPosition = intRetval
        End Function
        ' Purpose: update shelf on position of location
        ' Input: 
        ' Output:
        ' Creator: lent
        ' CreatedDate: 8-3-2005
        Public Function UpdateShelfPosition() As Integer
            Call OpenConnection()
            Dim intRetval As Integer = 0

            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_HOLDING_SHELF_SCHEMA_UPDATE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocID
                                .Add(New OracleParameter("strShelf", OracleType.VarChar, 32)).Value = strShelf
                                .Add(New OracleParameter("intWidth", OracleType.Number)).Value = intWidth
                                .Add(New OracleParameter("intDepth", OracleType.Number)).Value = intDepth
                                .Add(New OracleParameter("intTopCoor", OracleType.Number)).Value = intTopCoor
                                .Add(New OracleParameter("intLeftCoor", OracleType.Number)).Value = intLeftCoor
                                .Add(New OracleParameter("intDirection", OracleType.Number)).Value = intDirection
                                .Add(New OracleParameter("strSelShelf", OracleType.VarChar)).Value = strSelShelf
                                .Add(New OracleParameter("intRetVal", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetval = .Parameters("intRetval").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHoldingShelfSchema_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocID
                                .Add(New SqlParameter("@strShelf", SqlDbType.VarChar, 32)).Value = strShelf
                                .Add(New SqlParameter("@intWidth", SqlDbType.Int)).Value = intWidth
                                .Add(New SqlParameter("@intDepth", SqlDbType.Int)).Value = intDepth
                                .Add(New SqlParameter("@intTopCoor", SqlDbType.Int)).Value = intTopCoor
                                .Add(New SqlParameter("@intLeftCoor", SqlDbType.Int)).Value = intLeftCoor
                                .Add(New SqlParameter("@intDirection", SqlDbType.Int)).Value = intDirection
                                .Add(New SqlParameter("@strSelShelf", SqlDbType.VarChar)).Value = strSelShelf
                                .Add(New SqlParameter("@intRetVal", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetval = .Parameters("@intRetval").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            UpdateShelfPosition = intRetval
        End Function

        ' Purpose: delete shelf on position of location
        ' Input: 
        ' Output:
        ' Creator: lent
        ' CreatedDate: 8-3-2005
        Public Sub DeleteShelfPosition()
            Call OpenConnection()

            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_HOLDING_SHELF_SCHEMA_DELETE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocID
                                .Add(New OracleParameter("strShelf", OracleType.VarChar, 32)).Value = strShelf
                            End With
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
                        .CommandText = "Lib_spHoldingShelfSchema_DelByLocIdAndShelf "
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocID
                                .Add(New SqlParameter("@strShelf", SqlDbType.VarChar, 32)).Value = strShelf
                            End With
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

        ' Purpose : Get information Location's Shelf and its schema 
        ' Input: intLibID,intUserID
        ' Output: Datatable
        ' Created by: Lent
        ' date : 8-3-2005
        Public Function GetHoldingShelfSchema() As DataTable
            Call OpenConnection()

            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHoldingLocationSchema_SelByLocIdWithOrderBy"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetHoldingShelfSchema = dsData.Tables("tblResult")
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
                        .CommandText = "ACQUISITION.SP_HOLDING_SHELF_SCHEMA_SELECT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetHoldingShelfSchema = dsData.Tables("tblResult")
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

        ' Purpose : Get Holding Location of Library
        ' Input: intLibID, intStoreID,intUserID
        ' Output: Datatable
        ' Created by: Lent
        ' date : 17-2-2005
        Public Function GetLocation() As DataTable
            Call OpenConnection()

            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spHoldingLocationInfor_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intHolLibID", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                                .Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocID
                                .Add(New SqlParameter("@intStatus", SqlDbType.Int)).Value = intStatus
                            End With
                            sqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetLocation = dsData.Tables("tblResult")
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
                        .CommandText = "ACQUISITION.SP_HOLDING_LOCATION_GET_INFO"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intLibID", OracleType.Number, 4)).Value = intLibID
                                .Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                                .Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocID
                                .Add(New OracleParameter("intStatus", OracleType.Number, 4)).Value = intStatus
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetLocation = dsData.Tables("tblResult")
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

        Public Function GetLocationBySymbol(ByVal strSymbol As String) As DataTable
            Call OpenConnection()

            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHolding_SelBySymbol"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strSymbol", SqlDbType.NVarChar, 50)).Value = strSymbol
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetLocationBySymbol = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()

        End Function

        Public Function GetShelf() As DataTable
            Call OpenConnection()

            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHolding_SelSelf"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetShelf = dsData.Tables("tblResult")
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
                        .CommandText = "ACQUISITION.SP_GET_SHELF"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                                .Add(New OracleParameter("intLocID", OracleType.Number, 2)).Value = intLocID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetShelf = dsData.Tables("tblResult")
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

        Public Function GetGeneralInfor(ByVal bytMode As Byte) As DataTable
            Call OpenConnection()

            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHoldingLibrary_SelgenaralLocInfor"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocID
                                .Add(New SqlParameter("@strShelf", SqlDbType.NVarChar, 50)).Value = strShelf
                                .Add(New SqlParameter("@intMode", SqlDbType.Int)).Value = bytMode
                            End With
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
                        .CommandText = "ACQUISITION.SP_GET_GENERAL_LOC_INFOR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                                .Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocID
                                .Add(New OracleParameter("strShelf", OracleType.NVarChar, 10)).Value = strShelf
                                .Add(New OracleParameter("intMode", OracleType.Number)).Value = bytMode
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetGeneralInfor = dsData.Tables("tblResult")
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

        ' Purpose: set order number in holding_location table
        ' Input: strLocIDs, maxNumbers
        ' Output: 
        ' Create: lent
        ' CreatedDate: 25-3-2005
        Public Sub SetMaxID2Loc(ByVal strMaxNumber As String)
            Call OpenConnection()

            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_HOLDING_LOCATION_MAXNUMBER"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strLocIDs", OracleType.VarChar, 2000)).Value = strLocIDs
                                .Add(New OracleParameter("strMaxNumber", OracleType.VarChar, 4000)).Value = strMaxNumber
                            End With
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
                        .CommandText = "Lib_spHoldingLocation_SelMaxNumber"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strLocIDs", SqlDbType.VarChar, 2000)).Value = strLocIDs
                                .Add(New SqlParameter("@strMaxNumber", SqlDbType.VarChar, 4000)).Value = strMaxNumber
                            End With
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

        ' Method: Dispose
        ' Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                Call MyBase.Dispose(isDisposing)
            Finally
                MyBase.Dispose()
                Call Dispose()
            End Try
        End Sub
    End Class
End Namespace