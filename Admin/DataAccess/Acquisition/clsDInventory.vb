'  Class: clsBLibrary
'  Purpose:
'  Creator: Tuanhv
'  Created date: 09/03/2004
'  Modification history:

Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Acquisition
    Public Class clsDInventory
        Inherits clsDBase

        Private strSQL As String
        Private strShelf As String
        Private strCopyIDs As String
        Private strCopyNumbers As String
        Private intLibID As Integer
        Private intLocationID As Integer
        Private intInventoryID As Integer
        Private intType As Integer
        Private intPurpose As Integer
        Private objCopyIDs As Object
        Private strReason As String
        Private strOnLoan As String
        Private strInputDate As String
        Private intIsFromHolding As Integer
        Private intReasonID As Integer = 0
        Private strInventoryName As String
        Private strInputer As String
        Private strInventoryDate As String
        Private strLocationIDs As String
        Private strOrderField As String
        Private strDirection As String

        Private intOptInventory As Integer
        Private strFromOpenDate As String
        Private strToOpenDate As String

        '  *****************************************************************************************************
        Public Property OptInventory() As Integer
            Get
                Return intOptInventory
            End Get
            Set(ByVal Value As Integer)
                intOptInventory = Value
            End Set
        End Property
        Public Property FromOpenDate() As String
            Get
                Return strFromOpenDate
            End Get
            Set(ByVal Value As String)
                strFromOpenDate = Value
            End Set
        End Property
        Public Property ToOpenDate() As String
            Get
                Return strToOpenDate
            End Get
            Set(ByVal Value As String)
                strToOpenDate = Value
            End Set
        End Property
        '  InventoryDate property
        Public Property InventoryDate() As String
            Get
                InventoryDate = strInventoryDate
            End Get
            Set(ByVal Value As String)
                strInventoryDate = Value
            End Set
        End Property

        '  InventoryName property 
        Public Property InventoryName() As String
            Get
                InventoryName = strInventoryName
            End Get
            Set(ByVal Value As String)
                strInventoryName = Value
            End Set
        End Property

        '  Inputer property
        Public Property Inputer() As String
            Get
                Inputer = strInputer
            End Get
            Set(ByVal Value As String)
                strInputer = Value
            End Set
        End Property

        '  SQL property
        Public Property SQL() As String
            Get
                Return strSQL
            End Get
            Set(ByVal Value As String)
                strSQL = Value
            End Set
        End Property

        '  Shelf property
        Public Property Shelf() As String
            Get
                Return strShelf
            End Get
            Set(ByVal Value As String)
                strShelf = Value
            End Set
        End Property

        '  strCopyIDs property
        Public Property CopyIDs() As String
            Get
                Return strCopyIDs
            End Get
            Set(ByVal Value As String)
                strCopyIDs = Value
            End Set
        End Property

        '  strCopyNumbers property
        Public Property CopyNumbers() As String
            Get
                Return strCopyNumbers
            End Get
            Set(ByVal Value As String)
                strCopyNumbers = Value
            End Set
        End Property

        '  LibID property
        Public Property LibID() As Integer
            Get
                Return intLibID
            End Get
            Set(ByVal Value As Integer)
                intLibID = Value
            End Set
        End Property

        '  LocationID property
        Public Property LocationID() As Integer
            Get
                Return intLocationID
            End Get
            Set(ByVal Value As Integer)
                intLocationID = Value
            End Set
        End Property

        '  InventoryID property
        Public Property InventoryID() As Integer
            Get
                Return intInventoryID
            End Get
            Set(ByVal Value As Integer)
                intInventoryID = Value
            End Set
        End Property

        '  Type property
        Public Property Type() As Integer
            Get
                Return intType
            End Get
            Set(ByVal Value As Integer)
                intType = Value
            End Set
        End Property

        '  Purpose property
        Public Property Purpose() As Integer
            Get
                Return intPurpose
            End Get
            Set(ByVal Value As Integer)
                intPurpose = Value
            End Set
        End Property

        '  ArrCopyIDs property
        Public Property ArrCopyIDs() As Object
            Get
                Return objCopyIDs
            End Get
            Set(ByVal Value As Object)
                objCopyIDs = Value
            End Set
        End Property

        '  Reason property
        Public Property Reason() As String
            Get
                Return strReason
            End Get
            Set(ByVal Value As String)
                strReason = Value
            End Set
        End Property

        '  OnLoan property
        Public Property OnLoan() As String
            Get
                Return strOnLoan
            End Get
            Set(ByVal Value As String)
                strOnLoan = Value
            End Set
        End Property

        '  InputDate property
        Public Property InputDate() As String
            Get
                Return strInputDate
            End Get
            Set(ByVal Value As String)
                strInputDate = Value
            End Set
        End Property


        '  IsFromHolding property
        Public Property IsFromHolding() As Integer
            Get
                Return intIsFromHolding
            End Get
            Set(ByVal Value As Integer)
                intIsFromHolding = Value
            End Set
        End Property

        '  ReasonID property
        Public Property ReasonID() As Integer
            Get
                Return intReasonID
            End Get
            Set(ByVal Value As Integer)
                intReasonID = Value
            End Set
        End Property

        '  LocationIDs property
        Public Property LocationIDs() As String
            Get
                Return strLocationIDs
            End Get
            Set(ByVal Value As String)
                strLocationIDs = Value
            End Set
        End Property

        ' OrderField property
        Public Property OrderField() As String
            Get
                Return (strOrderField)
            End Get
            Set(ByVal Value As String)
                strOrderField = Value
            End Set
        End Property

        ' Direction property
        Public Property Direction() As String
            Get
                Return (strDirection)
            End Get
            Set(ByVal Value As String)
                strDirection = Value
            End Set
        End Property

        ' OpenInventory method
        ' Purpose: Open some closed locations
        ' Input: int value of UserID, string value of locationID, shelf
        Public Sub OpenInventory()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_HOLDING_LOCATION_OPEN"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strLocationIDs", OracleType.VarChar, 2000)).Value = strLocationIDs
                            .Parameters.Add(New OracleParameter("strShelf", OracleType.VarChar, 20)).Value = strShelf
                            .ExecuteNonQuery()
                        Catch Ex As OracleException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHoldingLocation_UpdStatusOpen"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strLocationIDs", SqlDbType.VarChar)).Value = strLocationIDs
                            .Parameters.Add(New SqlParameter("@strShelf", SqlDbType.NVarChar)).Value = strShelf
                            .ExecuteNonQuery()
                        Catch Ex As SqlException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' Method: CloseInventory
        ' Purpose: Close selected locations
        ' Input: intInventoryID
        Public Sub CloseInventory()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_CLOSE_INVENTORY"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intInventoryID", OracleType.Number)).Value = intInventoryID
                            .ExecuteNonQuery()
                        Catch Ex As OracleException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHoldingLocation_UpdCloseInventory"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intInventoryID", SqlDbType.Int)).Value = intInventoryID
                            .ExecuteNonQuery()
                        Catch Ex As SqlException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        '  DeleteInventory method
        '  Purpose: Delete from holding inventory
        '  Input: string of CopyIDs
        '  Output: DataTable
        Public Sub DeleteInventory()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_HINTVENTORY_DEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intInventoryID", OracleType.Number, 4)).Value = intInventoryID
                            .Parameters.Add(New OracleParameter("strCopynumbers", OracleType.VarChar, 2000)).Value = strCopyNumbers
                            oraDataAdapter.SelectCommand = oraCommand
                            .ExecuteNonQuery()
                        Catch Ex As OracleException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHoldingInventory_DelByInventoryId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intInventoryID", SqlDbType.Int)).Value = intInventoryID
                            .Parameters.Add(New SqlParameter("@strCopynumbers", SqlDbType.VarChar, 2000)).Value = strCopyNumbers
                            .ExecuteNonQuery()
                        Catch Ex As SqlException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub


        '  RetrieveInventoryResult method
        '  Purpose: Retrieve detail infor of these selected records from HOLDING, Lib_tblField200S table
        '  Input: string of CopyIDs
        '  Output: DataTable
        Public Function ResultInventory() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_INVENTORY_RESULT_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIsFromHolding", OracleType.Number)).Value = intIsFromHolding
                            .Parameters.Add(New OracleParameter("strCopyIDs", OracleType.VarChar, 1000)).Value = strCopyIDs
                            .Parameters.Add(New OracleParameter("strReason", OracleType.NVarChar, 50)).Value = strReason
                            .Parameters.Add(New OracleParameter("strOnLoan", OracleType.NVarChar, 50)).Value = strOnLoan
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                        Catch Ex As OracleException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHoldingInventory_SelResult"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIsFromHolding", SqlDbType.Int)).Value = intIsFromHolding
                            .Parameters.Add(New SqlParameter("@strCopyIDs", SqlDbType.VarChar, 1000)).Value = strCopyIDs
                            .Parameters.Add(New SqlParameter("@strReason", SqlDbType.NVarChar, 50)).Value = strReason
                            .Parameters.Add(New SqlParameter("@strOnLoan", SqlDbType.NVarChar, 50)).Value = strOnLoan
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                        Catch Ex As SqlException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            ResultInventory = dsData.Tables("tblResult")
            dsData.Tables.Remove("tblResult")
            Call CloseConnection()
        End Function


        ' GetInventory method
        ' Purpose: Get lib and loc
        Public Function GetInventory(Optional ByVal intStatus As Integer = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_INVENTORY_GET"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intInventoryID", OracleType.Number)).Value = intInventoryID
                            .Parameters.Add(New OracleParameter("intStatus", OracleType.Number)).Value = intStatus
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                        Catch Ex As OracleException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spInventory_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intInventoryID", SqlDbType.Int)).Value = intInventoryID
                            .Parameters.Add(New SqlParameter("@intStatus", SqlDbType.Int)).Value = intStatus
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                        Catch Ex As SqlException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            GetInventory = dsData.Tables("tblResult")
            dsData.Tables.Remove("tblResult")
            Call CloseConnection()
        End Function

        ' GetInventoryInfor method
        ' Purpose: Get lib and loc
        Public Function GetInventoryInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_LIB_GET"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocationID
                            .Parameters.Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                        Catch Ex As OracleException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHoldingLibrary_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocationID
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                        Catch Ex As SqlException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            GetInventoryInfor = dsData.Tables("tblResult")
            dsData.Tables.Remove("tblResult")
            Call CloseConnection()
        End Function

        ' Method: NewInventory
        ' Purpose: Insert new record int Inventory table 
        ' Input: strInventoryDate, strInventoryName, strInputer
        ' Output: int value (0 if success)
        Public Function NewInventory() As Integer
            Call OpenConnection()

            NewInventory = 0
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_NEW_INVENTORY"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strInventoryName", OracleType.VarChar, 200)).Value = strInventoryName
                            .Parameters.Add(New OracleParameter("strInventoryDate", OracleType.VarChar, 30)).Value = strInventoryDate
                            .Parameters.Add(New OracleParameter("strInputer", OracleType.VarChar, 50)).Value = strInputer
                            .Parameters.Add(New OracleParameter("intResult", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            NewInventory = .Parameters("intResult").Value
                        Catch Ex As OracleException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spInventory_InsNew"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strInventoryName", SqlDbType.NVarChar, 200)).Value = strInventoryName
                            .Parameters.Add(New SqlParameter("@strInventoryDate", SqlDbType.VarChar, 30)).Value = strInventoryDate
                            .Parameters.Add(New SqlParameter("@strInputer", SqlDbType.NVarChar, 50)).Value = strInputer
                            .Parameters.Add(New SqlParameter("@intLibID ", SqlDbType.Int)).Value = intLibID
                            .Parameters.Add(New SqlParameter("@intResult", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            NewInventory = CInt(.Parameters("@intResult").Value)
                        Catch Ex As SqlException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function


        ' UpdateInventoryRe method
        ' Purpose: Update holding changer Lockreason
        ' Input: intInventoryID, strReason, strCopyNumbers
        Public Function UpdateInventoryRe() As Integer
            UpdateInventoryRe = 0
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_HOLDING_UPDATE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intInventoryID", OracleType.Number)).Value = intInventoryID
                            .Parameters.Add(New OracleParameter("strCopynumbers", OracleType.VarChar, 2000)).Value = strCopyNumbers
                            .Parameters.Add(New OracleParameter("strReason", OracleType.VarChar, 100)).Value = strReason
                            .ExecuteNonQuery()
                        Catch Ex As OracleException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Code
                            UpdateInventoryRe = 1
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHoldingInventory_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intInventoryID", SqlDbType.Int)).Value = intInventoryID
                            .Parameters.Add(New SqlParameter("@strCopynumbers", SqlDbType.VarChar)).Value = strCopyNumbers
                            .Parameters.Add(New SqlParameter("@strReason", SqlDbType.NVarChar)).Value = strReason
                            .ExecuteNonQuery()
                        Catch Ex As SqlException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Number
                            UpdateInventoryRe = 1
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function


        ' RemoveHoldingNoHave method
        ' Purpose: Update holding changer Lockreason
        ' Input: strInventoryDate, strInventoryName, strInputer
        Public Function RemoveHoldingNoHave() As Integer
            RemoveHoldingNoHave = 0
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_HOLDING_REMOVED"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intUseID", OracleType.Number, 4)).Value = intUserID
                            .Parameters.Add(New OracleParameter("strCopynumbers", OracleType.VarChar, 2000)).Value = strCopyNumbers
                            .ExecuteNonQuery()
                        Catch Ex As OracleException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Code
                            RemoveHoldingNoHave = 1
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHolding_DelCopyNumber"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intUseID", SqlDbType.Int, 4)).Value = intUserID
                            .Parameters.Add(New SqlParameter("@strCopyNumbers", SqlDbType.VarChar, 2000)).Value = strCopyNumbers
                            .ExecuteNonQuery()
                        Catch Ex As SqlException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Number
                            RemoveHoldingNoHave = 1
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' RemoveHoldingNoHave method
        ' Purpose: Update holding changer Lockreason
        ' Input: intUserID, strCopyNumbers,intInventoryID
        Public Function RemoveHoldingInvNoHave() As Integer
            RemoveHoldingInvNoHave = 0
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_HOLDING_INV_REMOVED"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intInventoryID", OracleType.Number, 4)).Value = intInventoryID
                            .Parameters.Add(New OracleParameter("intUseID", OracleType.Number, 4)).Value = intUserID
                            .Parameters.Add(New OracleParameter("strCopynumbers", OracleType.VarChar, 4000)).Value = strCopyNumbers
                            .ExecuteNonQuery()
                        Catch Ex As OracleException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Code
                            RemoveHoldingInvNoHave = 1
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHolding_Del"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intInventoryID", SqlDbType.Int, 4)).Value = intInventoryID
                            .Parameters.Add(New SqlParameter("@intUseID", SqlDbType.Int, 4)).Value = intUserID
                            .Parameters.Add(New SqlParameter("@strCopyNumbers", SqlDbType.VarChar, 2000)).Value = strCopyNumbers
                            .ExecuteNonQuery()
                        Catch Ex As SqlException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Number
                            RemoveHoldingInvNoHave = 1
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' PendingLocation method
        ' Purpose: Pending insert into location
        ' Input: 
        Public Function PendingLocation() As Integer
            PendingLocation = 0
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_INVENTORY_SUCESS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .ExecuteNonQuery()
                        Catch Ex As OracleException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Code
                            PendingLocation = 1
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHoldingLocation_UpdStatustoSuccess"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .ExecuteNonQuery()
                        Catch Ex As SqlException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Number
                            PendingLocation = 1
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function


        ' GetmaxInventoryTime method
        ' Purpose: Get max inventorytime
        ' Input: Location, liblary, shelf and purpose 
        Public Function GetmaxInventoryTime() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_GETMAXID_HINT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intInventoryTime", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            GetmaxInventoryTime = .Parameters("intInventoryTime").Value
                        Catch Ex As OracleException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHoldingInventory_SelMaxIdHint"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intInventoryTime", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            GetmaxInventoryTime = .Parameters("@intInventoryTime").Value
                        Catch Ex As SqlException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Init inventory method
        ' Purpose: Init inventory: insert into INIT_INVENTORY
        ' In: intSessionID
        ' Input: strCopyNumbers
        Public Sub InitInventory(ByRef intSessionID As Integer)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_INIT_COPYNUMBERINVEN"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strCopyNumbers", OracleType.VarChar, 3999)).Value = strCopyNumbers
                            .Parameters.Add(New OracleParameter("intSessionID", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                        Catch Ex As OracleException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Code
                        Finally
                            intSessionID = .Parameters("intSessionID").Value
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spInitInventory_InsertCopyNumber"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strCopynumbers", SqlDbType.NVarChar, 3999)).Value = strCopyNumbers

                            .Parameters.Add(New SqlParameter("@intSessionIDInput", SqlDbType.Int)).Value = intSessionID
                            .Parameters.Add(New SqlParameter("@intSessionIDOutput", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                        Catch Ex As SqlException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Number
                        Finally
                            intSessionID = .Parameters("@intSessionIDOutput").Value
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' clear inventory method
        ' Purpose: clear  INIT_INVENTORY table
        ' Input: intSessionID
        Public Sub ClearInventory(ByRef intSessionID As Integer)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_CLEAR_INIT_INVENTORY"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intSessionID", OracleType.Number)).Value = intSessionID
                            .ExecuteNonQuery()
                        Catch Ex As OracleException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spInitInventory_DeleteBySessionId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intSessionID", SqlDbType.Int)).Value = intSessionID
                            .ExecuteNonQuery()
                        Catch Ex As SqlException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' Purpose: Get total copynumber false path
        ' Input:    intInventoryID
        ' Output:   Datatable
        Public Function GetCNsFalsePath() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_GET_CNs_FALSE_PATH"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intInventoryID", OracleType.Number)).Value = intInventoryID
                            .Parameters.Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                            .Parameters.Add(New OracleParameter("intLocationID", OracleType.Number)).Value = intLocationID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetCNsFalsePath = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch Ex As OracleException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHoldingInventory_SelFaPath"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intInventoryID", SqlDbType.Int)).Value = intInventoryID
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                            .ExecuteNonQuery()
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetCNsFalsePath = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch Ex As SqlException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' RunInventory method
        ' Purpose: run inventory
        ' Input: Location, liblary, shelf and purpose, isFirstTimeInventory (0: not, 1: correct) 
        Public Sub RunInventory(ByVal intInventoryTime As Integer, ByVal intIsFirstTimeInventory As Integer, ByVal intSessionID As Integer)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_RUN_INVENTORY"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocationID
                            .Parameters.Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                            .Parameters.Add(New OracleParameter("intPurpose", OracleType.Number)).Value = intPurpose
                            .Parameters.Add(New OracleParameter("intInventoryID", OracleType.Number)).Value = intInventoryID
                            .Parameters.Add(New OracleParameter("strShelf", OracleType.VarChar, 20)).Value = strShelf
                            .Parameters.Add(New OracleParameter("intInventoryTime", OracleType.Number)).Value = intInventoryTime
                            .Parameters.Add(New OracleParameter("intIsFirstTimeInventory", OracleType.Number)).Value = intIsFirstTimeInventory
                            .Parameters.Add(New OracleParameter("intSessionID", OracleType.Number)).Value = intSessionID
                            .ExecuteNonQuery()
                        Catch Ex As OracleException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHoldingInventory_RunInventory"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocationID
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            .Parameters.Add(New SqlParameter("@intPurpose", SqlDbType.Int)).Value = intPurpose
                            .Parameters.Add(New SqlParameter("@intInventoryID", SqlDbType.Int)).Value = intInventoryID
                            .Parameters.Add(New SqlParameter("@strShelf", SqlDbType.VarChar, 20)).Value = strShelf
                            .Parameters.Add(New SqlParameter("@intInventoryTime", SqlDbType.Int)).Value = intInventoryTime
                            .Parameters.Add(New SqlParameter("@intIsFirstTimeInventory", SqlDbType.Int)).Value = intIsFirstTimeInventory
                            .Parameters.Add(New SqlParameter("@intSessionID", SqlDbType.Int)).Value = intSessionID
                            .ExecuteNonQuery()
                        Catch Ex As SqlException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' Methord: CheckCopynumberWrong
        ' Puporse: Check exits copynumber
        Public Function CheckCopynumberWrong(ByVal intSessionID As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_CHECK_EXITS_COPY_HI"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocationID
                            .Parameters.Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                            .Parameters.Add(New OracleParameter("intInventoryID", OracleType.Number)).Value = intInventoryID
                            .Parameters.Add(New OracleParameter("strShelf", OracleType.VarChar, 20)).Value = strShelf
                            .Parameters.Add(New OracleParameter("intSessionID", OracleType.Number)).Value = intSessionID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            CheckCopynumberWrong = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch Ex As OracleException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHoldingInventory_CheckExitCopyNumber"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocationID
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            .Parameters.Add(New SqlParameter("@intInventoryID", SqlDbType.Int)).Value = intInventoryID
                            .Parameters.Add(New SqlParameter("@strShelf", SqlDbType.VarChar, 20)).Value = strShelf
                            .Parameters.Add(New SqlParameter("@intSessionID", SqlDbType.Int)).Value = intSessionID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            CheckCopynumberWrong = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch Ex As SqlException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Methord: GetItemNoHaveReal
        ' Puporse: Get all Lib_tblItem no have real in lib, loc asn shelf
        Public Function GetItemNoHaveReal() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_GET_ITEM_NOHAVE_REAL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocationID
                            .Parameters.Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                            .Parameters.Add(New OracleParameter("intInventoryID", OracleType.Number)).Value = intInventoryID
                            .Parameters.Add(New OracleParameter("strShelf", OracleType.VarChar, 20)).Value = strShelf
                            .Parameters.Add(New OracleParameter("strOrderField", OracleType.VarChar, 10)).Value = strOrderField
                            .Parameters.Add(New OracleParameter("strDirection", OracleType.VarChar, 5)).Value = strDirection
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetItemNoHaveReal = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch Ex As OracleException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHoldingInventory_SelNoHaveReal"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocationID
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            .Parameters.Add(New SqlParameter("@intInventoryID", SqlDbType.Int)).Value = intInventoryID
                            .Parameters.Add(New SqlParameter("@strShelf", SqlDbType.VarChar, 20)).Value = strShelf
                            .Parameters.Add(New SqlParameter("@strOrderField", SqlDbType.VarChar, 10)).Value = strOrderField
                            .Parameters.Add(New SqlParameter("@strDirection", SqlDbType.VarChar, 5)).Value = strDirection
                            .Parameters.Add(New SqlParameter("@strFromOpenDate", SqlDbType.VarChar, 10)).Value = strFromOpenDate
                            .Parameters.Add(New SqlParameter("@strToOpenDate", SqlDbType.VarChar, 10)).Value = strToOpenDate
                            .Parameters.Add(New SqlParameter("@intOptInventory", SqlDbType.Int)).Value = intOptInventory
                            sqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemNoHaveReal = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch Ex As SqlException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select

            Call CloseConnection()
        End Function

        ' Methord: GetItemFalsePaths
        ' Puporse: Get Lib_tblItem exits holding and exit intventory but false paths
        Public Function GetItemFalsePaths() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_GET_ITEM_FALSE_PATHS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocationID
                            .Parameters.Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                            .Parameters.Add(New OracleParameter("intInventoryID", OracleType.Number)).Value = intInventoryID
                            .Parameters.Add(New OracleParameter("strShelf", OracleType.VarChar, 20)).Value = strShelf
                            .Parameters.Add(New OracleParameter("strOrderField", OracleType.VarChar, 10)).Value = strOrderField
                            .Parameters.Add(New OracleParameter("strDirection", OracleType.VarChar, 5)).Value = strDirection
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                        Catch Ex As OracleException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHoldingLibrary_SelItemFalsePaths"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocationID
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            .Parameters.Add(New SqlParameter("@intInventoryID", SqlDbType.Int)).Value = intInventoryID
                            .Parameters.Add(New SqlParameter("@strShelf", SqlDbType.VarChar, 20)).Value = strShelf
                            .Parameters.Add(New SqlParameter("@strOrderField", SqlDbType.VarChar, 10)).Value = strOrderField
                            .Parameters.Add(New SqlParameter("@strDirection", SqlDbType.VarChar, 5)).Value = strDirection
                            .Parameters.Add(New SqlParameter("@strFromOpenDate", SqlDbType.VarChar, 10)).Value = strFromOpenDate
                            .Parameters.Add(New SqlParameter("@strToOpenDate", SqlDbType.VarChar, 10)).Value = strToOpenDate
                            .Parameters.Add(New SqlParameter("@intOptInventory", SqlDbType.Int)).Value = intOptInventory
                            sqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                        Catch Ex As SqlException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            GetItemFalsePaths = dsData.Tables("tblResult")
            dsData.Tables.Remove("tblResult")
            Call CloseConnection()
        End Function

        ' Methord: CheckCopynumberNotExits
        ' Puporse: Check exits copynumber
        Public Function CheckCopynumberNotExits(ByVal intSessionID As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_CHECK_EXITS_COPY_H" ' Because in Oracle don't allow store name so max
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intSessionID", OracleType.Number)).Value = intSessionID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                        Catch Ex As OracleException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHolding_CheckExitCopyNumberHolding"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intSessionID", SqlDbType.Int)).Value = intSessionID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                        Catch Ex As SqlException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try

                    End With
            End Select
            CheckCopynumberNotExits = dsData.Tables("tblResult")
            dsData.Tables.Remove("tblResult")
            Call CloseConnection()
        End Function

        ' Methord: Get Inventory Reason
        ' Puporse: Get all reason
        Public Function GetInventoryReason() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_GET_INVENTORY_REASON"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetInventoryReason = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch Ex As OracleException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "SP_GET_INVENTORY_REASON"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetInventoryReason = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch Ex As SqlException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try

                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose:  Inser all loss Lib_tblItem in this inventory to HOLDING_INVENTORY table
        ' Input:    some infor
        ' Creator:  Sondp
        Public Sub Insert_HolInv_LossItem(ByVal intInventoryTime As Integer)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_HOL_INVENTORY_LAST_STEP"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intInventoryID", OracleType.Number)).Value = intInventoryID
                            .Parameters.Add(New OracleParameter("intInventoryTime", OracleType.Number)).Value = intInventoryTime
                            .Parameters.Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                            .Parameters.Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocationID
                            .Parameters.Add(New OracleParameter("strShelf", OracleType.VarChar, 20)).Value = strShelf

                            .ExecuteNonQuery()
                        Catch Ex As OracleException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHoldingInventory_LastStep"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intInventoryID", SqlDbType.Int)).Value = intInventoryID
                            .Parameters.Add(New SqlParameter("@intInventoryTime", SqlDbType.Int)).Value = intInventoryTime
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            .Parameters.Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocationID
                            .Parameters.Add(New SqlParameter("@strShelf", SqlDbType.VarChar, 20)).Value = strShelf
                            .ExecuteNonQuery()
                        Catch Ex As SqlException
                            strErrorMsg = Ex.Message.ToString
                            intErrorCode = Ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        '  Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                Call MyBase.Dispose(isDisposing)
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace