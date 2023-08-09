'class:
' Purpose:
' Creator:
' CreatedDate:
'histoty update:

Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Acquisition
    Public Class clsDCopyNumber
        Inherits clsDBase
        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private intHoLibID As Integer
        Private intLocID As Integer
        Private strShelf As String
        Private strToCopyNum As String
        Private strFromCopyNum As String
        Private intOrderby As Integer
        Private intDesc As Integer

        Private lngItemID As Long = 0
        Private lngCopyID As Long = 0
        Private intUseCount As Integer = 0
        Private strVolume As String = ""
        Private strAcquiredDate As String = ""
        Private strCopyNumber As String = ""
        Private bytInUsed As Byte = 0
        Private bytInCirculation As Byte = 0
        Private intILLID As Integer = 0
        Private dblPrice As Double = 0
        Private intPOID As Integer = 0
        Private strDateLastUsed As String = ""
        Private strCallNumber As String = ""
        Private bytAcquired As Byte = 0
        Private strNote As String = ""
        Private intLoanTypeID As Integer = 0
        Private intAcquiredSourceID As Integer = 0
        Private strCopyIDs As String = ""
        Private intOutPut As Integer = 0
        Private strCurrencyCode As String = ""
        Private strCode As String = ""
        Private strBarCode As String = ""
        Private strNumberCopies As String = ""
        Private strStatusCode As String = ""
        Private strStatusNode As String = ""
        Private strDateCreate As Date = Date.Now
        Private strDateUpdate As Date = Date.Now
        Private strAdditionalBy As String = ""


        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
        ' CurrencyCode property
        Public Property CurrencyCode() As String
            Get
                Return strCurrencyCode
            End Get
            Set(ByVal Value As String)
                strCurrencyCode = Value
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
        ' OutPut property
        Public Property OutPut() As Integer
            Get
                Return intOutPut
            End Get
            Set(ByVal Value As Integer)
                intOutPut = Value
            End Set
        End Property

        ' CopyID property
        Public Property CopyIDs() As String
            Get
                Return (strCopyIDs)
            End Get
            Set(ByVal Value As String)
                strCopyIDs = Value
            End Set
        End Property


        ' HolLibID property
        Public Property HolLibID() As Integer
            Get
                Return (intHoLibID)
            End Get
            Set(ByVal Value As Integer)
                intHoLibID = Value
            End Set
        End Property


        ' LocID property
        Public Property LocID() As Integer
            Get
                Return (intLocID)
            End Get
            Set(ByVal Value As Integer)
                intLocID = Value
            End Set
        End Property
        ' Shelf property
        Public Property Shelf() As String
            Get
                Return (strShelf)
            End Get
            Set(ByVal Value As String)
                strShelf = Value
            End Set
        End Property
        ' ToCopyNum property
        Public Property ToCopyNum() As String
            Get
                Return (strToCopyNum)
            End Get
            Set(ByVal Value As String)
                strToCopyNum = Value
            End Set
        End Property
        ' FromCopyNum property
        Public Property FromCopyNum() As String
            Get
                Return (strFromCopyNum)
            End Get
            Set(ByVal Value As String)
                strFromCopyNum = Value
            End Set
        End Property
        ' Orderby property
        Public Property Orderby() As Integer
            Get
                Return (intOrderby)
            End Get
            Set(ByVal Value As Integer)
                intOrderby = Value
            End Set
        End Property
        ' OrderByDesc property
        Public Property OrderByDesc() As Integer
            Get
                Return (intDesc)
            End Get
            Set(ByVal Value As Integer)
                intDesc = Value
            End Set
        End Property

        ' ItemID Property
        Public Property ItemID() As Long
            Get
                Return lngItemID
            End Get
            Set(ByVal Value As Long)
                lngItemID = Value
            End Set
        End Property

        ' CopyID Property
        Public Property CopyID() As Long
            Get
                Return lngCopyID
            End Get
            Set(ByVal Value As Long)
                lngCopyID = Value
            End Set
        End Property

        ' UseCount Property
        Public Property UseCount() As Integer
            Get
                Return intUseCount
            End Get
            Set(ByVal Value As Integer)
                intUseCount = Value
            End Set
        End Property

        ' Volume Property
        Public Property Volume() As String
            Get
                Return strVolume
            End Get
            Set(ByVal Value As String)
                strVolume = Value
            End Set
        End Property

        ' AcquiredDate Property
        Public Property AcquiredDate() As String
            Get
                Return strAcquiredDate
            End Get
            Set(ByVal Value As String)
                strAcquiredDate = Value
            End Set
        End Property

        ' CopyNumber Property
        Public Property CopyNumber() As String
            Get
                Return strCopyNumber
            End Get
            Set(ByVal Value As String)
                strCopyNumber = Value
            End Set
        End Property

        ' InUsed Property
        Public Property InUsed() As Byte
            Get
                Return bytInUsed
            End Get
            Set(ByVal Value As Byte)
                bytInUsed = Value
            End Set
        End Property

        ' InCirculation Property
        Public Property InCirculation() As Byte
            Get
                Return bytInCirculation
            End Get
            Set(ByVal Value As Byte)
                bytInCirculation = Value
            End Set
        End Property

        ' ILLidID Property
        Public Property ILLID() As Integer
            Get
                Return intILLID
            End Get
            Set(ByVal Value As Integer)
                intILLID = Value
            End Set
        End Property

        ' Price Property
        Public Property Price() As Double
            Get
                Return dblPrice
            End Get
            Set(ByVal Value As Double)
                dblPrice = Value
            End Set
        End Property

        ' POID Property
        Public Property POID() As Integer
            Get
                Return intPOID
            End Get
            Set(ByVal Value As Integer)
                intPOID = Value
            End Set
        End Property

        ' DateLastUsed Property
        Public Property DateLastUsed() As String
            Get
                Return strDateLastUsed
            End Get
            Set(ByVal Value As String)
                strDateLastUsed = Value
            End Set
        End Property

        ' CallNumber Property
        Public Property CallNumber() As String
            Get
                Return strCallNumber
            End Get
            Set(ByVal Value As String)
                strCallNumber = Value
            End Set
        End Property

        ' Acquired  Property
        Public Property Acquired() As Byte
            Get
                Return bytAcquired
            End Get
            Set(ByVal Value As Byte)
                bytAcquired = Value
            End Set
        End Property

        ' Note Property
        Public Property Note() As String
            Get
                Return strNote
            End Get
            Set(ByVal Value As String)
                strNote = Value
            End Set
        End Property

        ' LoanTypeID  Property
        Public Property LoanTypeID() As Integer
            Get
                Return intLoanTypeID
            End Get
            Set(ByVal Value As Integer)
                intLoanTypeID = Value
            End Set
        End Property

        ' AcquiredSourceID  Property
        Public Property AcquiredSourceID() As Integer
            Get
                Return intAcquiredSourceID
            End Get
            Set(ByVal Value As Integer)
                intAcquiredSourceID = Value
            End Set
        End Property

        ' BarCode Property
        Public Property BarCode() As String
            Get
                Return strBarCode
            End Get
            Set(ByVal Value As String)
                strBarCode = Value
            End Set
        End Property

        ' NumberCopies Property
        Public Property NumberCopies() As String
            Get
                Return strNumberCopies
            End Get
            Set(ByVal Value As String)
                strNumberCopies = Value
            End Set
        End Property

        ' StatusCode Property
        Public Property StatusCode() As String
            Get
                Return strStatusCode
            End Get
            Set(ByVal Value As String)
                strStatusCode = Value
            End Set
        End Property

        ' StatusNode Property
        Public Property StatusNode() As String
            Get
                Return strStatusNode
            End Get
            Set(ByVal Value As String)
                strStatusNode = Value
            End Set
        End Property

        ' StatusNode Property
        Public Property DateCreate() As Date
            Get
                Return strDateCreate
            End Get
            Set(ByVal Value As Date)
                strDateCreate = Value
            End Set
        End Property

        ' StatusNode Property
        Public Property DateUpdate() As Date
            Get
                Return strDateUpdate
            End Get
            Set(ByVal Value As Date)
                strDateUpdate = Value
            End Set
        End Property
        ' AdditionalBy Property
        Public Property AdditionalBy() As String
            Get
                Return strAdditionalBy
            End Get
            Set(ByVal Value As String)
                strAdditionalBy = Value
            End Set
        End Property

        Public Function CountCopyNumbers(ByVal ids() As Integer) As Integer
            If ids Is Nothing OrElse ids.Length = 0 Then
                Return 0
            End If
            Dim count As Integer = 0
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = String.Format("SELECT COUNT(*) FROM Lib_tblItem WHERE ID IN(SELECT ItemID FROM Lib_tblHolding WHERE ID IN({0}))", String.Join(",", ids))
                        .CommandType = CommandType.Text
                        Try
                            count = Integer.Parse(.ExecuteScalar().ToString())
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Return count
        End Function

        Public Sub UpdateLocationMaxNumber(ByVal locationID As Integer, ByVal newMaxNumber As Integer)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = String.Format("UPDATE Lib_tblHoldingLocation SET MaxNumber={0} WHERE ID={1}", newMaxNumber, locationID)
                        .CommandType = CommandType.Text
                        Try
                            .ExecuteNonQuery()
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        Public Function GetLatestCopyNumberCopy(ByVal id As Integer) As String
            Dim latest As String = "C.0"
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = String.Format("SELECT TOP 1 NumberCopies from Lib_tblHolding WHERE ItemID={0} ORDER BY ID DESC", id)
                        .CommandType = CommandType.Text
                        Try
                            Dim dt As SqlDataReader = .ExecuteReader()
                            Try
                                If dt.HasRows Then
                                    dt.Read()
                                    latest = dt.GetString(0)
                                    If latest Is Nothing Then
                                        latest = "C.0"
                                    Else
                                        latest = latest.Replace(Convert.ToChar(0), "")
                                    End If
                                End If
                                dt.Close()
                            Catch ex As Exception
                                dt.Close()
                            End Try

                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Return latest
        End Function

        Public Sub CreateHolding()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHolding_InsUpdate"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@lngItemID", SqlDbType.Int)).Value = lngItemID
                            .Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocID
                            .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intHoLibID
                            .Add(New SqlParameter("@intUseCount", SqlDbType.Int)).Value = intUseCount
                            .Add(New SqlParameter("@strVolume", SqlDbType.NVarChar, 32)).Value = strVolume
                            .Add(New SqlParameter("@strAcquiredDate", SqlDbType.VarChar, 30)).Value = strAcquiredDate
                            .Add(New SqlParameter("@strCopyNumber", SqlDbType.VarChar, 33)).Value = strCopyNumber
                            .Add(New SqlParameter("@strBarCode", SqlDbType.VarChar, 33)).Value = strBarCode
                            .Add(New SqlParameter("@intInUsed", SqlDbType.Int)).Value = bytInUsed
                            .Add(New SqlParameter("@intInCirculation", SqlDbType.Int)).Value = bytInCirculation
                            .Add(New SqlParameter("@intILLID", SqlDbType.Int)).Value = intILLID
                            .Add(New SqlParameter("@dblPrice", SqlDbType.Float)).Value = dblPrice
                            .Add(New SqlParameter("@strShelf", SqlDbType.NVarChar, 50)).Value = strShelf
                            .Add(New SqlParameter("@intPOID", SqlDbType.Int)).Value = intPOID
                            .Add(New SqlParameter("@strDateLastUsed", SqlDbType.VarChar, 20)).Value = strDateLastUsed
                            .Add(New SqlParameter("@strCallNumber", SqlDbType.NVarChar, 32)).Value = strCallNumber
                            .Add(New SqlParameter("@intAcquired", SqlDbType.Int)).Value = bytAcquired
                            .Add(New SqlParameter("@strNote", SqlDbType.NVarChar, 100)).Value = strNote
                            .Add(New SqlParameter("@intLoanTypeID", SqlDbType.Int)).Value = intLoanTypeID
                            .Add(New SqlParameter("@intAcquiredSourceID", SqlDbType.Int)).Value = intAcquiredSourceID
                            .Add(New SqlParameter("@strNumberCopies", SqlDbType.NVarChar, 25)).Value = strNumberCopies
                            .Add(New SqlParameter("@strStatusCode", SqlDbType.NVarChar, 50)).Value = strStatusCode
                            .Add(New SqlParameter("@strStatusNode", SqlDbType.NVarChar, 255)).Value = strStatusNode
                            .Add(New SqlParameter("@strDateCreate", SqlDbType.DateTime)).Value = strDateCreate
                            .Add(New SqlParameter("@strDateUpdate", SqlDbType.DateTime)).Value = strDateUpdate
                            .Add(New SqlParameter("@strAdditionalBy", SqlDbType.NVarChar, 500)).Value = strAdditionalBy
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
                        .CommandText = "ACQUISITION.SP_HOLDING_INS"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intItemID", OracleType.Number)).Value = lngItemID
                            .Add(New OracleParameter("intLocationID", OracleType.Number)).Value = intLocID
                            .Add(New OracleParameter("intlibID", OracleType.Number)).Value = intLibID
                            .Add(New OracleParameter("intUseCount", OracleType.Number)).Value = intUseCount
                            .Add(New OracleParameter("strVolume", OracleType.VarChar, 32)).Value = strVolume
                            .Add(New OracleParameter("strAcquiredDate", OracleType.VarChar, 30)).Value = strAcquiredDate
                            .Add(New OracleParameter("strCopyNumber", OracleType.VarChar, 33)).Value = strCopyNumber
                            .Add(New OracleParameter("intInUsed", OracleType.Number)).Value = bytInUsed
                            .Add(New OracleParameter("intInCirculation", OracleType.Number)).Value = bytInCirculation
                            .Add(New OracleParameter("intILLID", OracleType.Number)).Value = intILLID
                            .Add(New OracleParameter("dblPrice", OracleType.Float)).Value = dblPrice
                            .Add(New OracleParameter("strShelf", OracleType.VarChar, 50)).Value = strShelf
                            .Add(New OracleParameter("intPOID", OracleType.Number)).Value = intPOID
                            .Add(New OracleParameter("strDateLastUsed", OracleType.VarChar, 20)).Value = strDateLastUsed
                            .Add(New OracleParameter("strCallNumber", OracleType.VarChar, 32)).Value = strCallNumber
                            .Add(New OracleParameter("intAcquired", OracleType.Number)).Value = bytAcquired
                            .Add(New OracleParameter("strNote", OracleType.VarChar, 100)).Value = strNote
                            .Add(New OracleParameter("intLoanTypeID", OracleType.Number)).Value = intLoanTypeID
                            .Add(New OracleParameter("intAcquiredSourceID", OracleType.Number)).Value = intAcquiredSourceID
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
        Public Sub CreateHolding(Optional ByVal strNameCreate As String = "", Optional ByVal strNameUpdate As String = "")
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHolding_InsUpdate_Cataloguer"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@lngItemID", SqlDbType.Int)).Value = lngItemID
                            .Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocID
                            .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intHoLibID
                            .Add(New SqlParameter("@intUseCount", SqlDbType.Int)).Value = intUseCount
                            .Add(New SqlParameter("@strVolume", SqlDbType.NVarChar, 32)).Value = strVolume
                            .Add(New SqlParameter("@strAcquiredDate", SqlDbType.VarChar, 30)).Value = strAcquiredDate
                            .Add(New SqlParameter("@strCopyNumber", SqlDbType.VarChar, 33)).Value = strCopyNumber
                            .Add(New SqlParameter("@strBarCode", SqlDbType.VarChar, 33)).Value = strBarCode
                            .Add(New SqlParameter("@intInUsed", SqlDbType.Int)).Value = bytInUsed
                            .Add(New SqlParameter("@intInCirculation", SqlDbType.Int)).Value = bytInCirculation
                            .Add(New SqlParameter("@intILLID", SqlDbType.Int)).Value = intILLID
                            .Add(New SqlParameter("@dblPrice", SqlDbType.Float)).Value = dblPrice
                            .Add(New SqlParameter("@strShelf", SqlDbType.NVarChar, 50)).Value = strShelf
                            .Add(New SqlParameter("@intPOID", SqlDbType.Int)).Value = intPOID
                            .Add(New SqlParameter("@strDateLastUsed", SqlDbType.VarChar, 20)).Value = strDateLastUsed
                            .Add(New SqlParameter("@strCallNumber", SqlDbType.NVarChar, 32)).Value = strCallNumber
                            .Add(New SqlParameter("@intAcquired", SqlDbType.Int)).Value = bytAcquired
                            .Add(New SqlParameter("@strNote", SqlDbType.NVarChar, 100)).Value = strNote
                            .Add(New SqlParameter("@intLoanTypeID", SqlDbType.Int)).Value = intLoanTypeID
                            .Add(New SqlParameter("@intAcquiredSourceID", SqlDbType.Int)).Value = intAcquiredSourceID
                            .Add(New SqlParameter("@strNumberCopies", SqlDbType.NVarChar, 25)).Value = strNumberCopies
                            .Add(New SqlParameter("@strStatusCode", SqlDbType.NVarChar, 50)).Value = strStatusCode
                            .Add(New SqlParameter("@strStatusNode", SqlDbType.NVarChar, 255)).Value = strStatusNode
                            .Add(New SqlParameter("@strDateCreate", SqlDbType.DateTime)).Value = strDateCreate
                            .Add(New SqlParameter("@strDateUpdate", SqlDbType.DateTime)).Value = strDateUpdate
                            .Add(New SqlParameter("@strNameCreate", SqlDbType.NVarChar, 255)).Value = strNameCreate
                            .Add(New SqlParameter("@strNameUpdate", SqlDbType.NVarChar, 255)).Value = strNameUpdate
                            .Add(New SqlParameter("@strAdditionalBy", SqlDbType.NVarChar, 500)).Value = strAdditionalBy
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
            End Select
            Call CloseConnection()
        End Sub

        Public Sub Update()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHolding_Upd"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@lngCopyID", SqlDbType.Int)).Value = lngCopyID
                            .Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocID
                            .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            .Add(New SqlParameter("@strVolume", SqlDbType.NVarChar, 32)).Value = strVolume
                            .Add(New SqlParameter("@strAcquiredDate", SqlDbType.VarChar, 20)).Value = strAcquiredDate
                            .Add(New SqlParameter("@strCopyNumber", SqlDbType.VarChar, 33)).Value = strCopyNumber
                            .Add(New SqlParameter("@dblPrice", SqlDbType.Float)).Value = dblPrice
                            .Add(New SqlParameter("@strShelf", SqlDbType.NVarChar, 50)).Value = strShelf
                            .Add(New SqlParameter("@strCallNumber", SqlDbType.NVarChar, 32)).Value = strCallNumber
                            .Add(New SqlParameter("@strNote", SqlDbType.NVarChar, 100)).Value = strNote
                            .Add(New SqlParameter("@intAcquiredSourceID", SqlDbType.Int)).Value = intAcquiredSourceID
                            .Add(New SqlParameter("@strBarCode", SqlDbType.NVarChar, 150)).Value = strBarCode
                            .Add(New SqlParameter("@strNumberCopies", SqlDbType.NVarChar, 25)).Value = strNumberCopies
                            .Add(New SqlParameter("@strAdditionalBy", SqlDbType.NVarChar, 500)).Value = strAdditionalBy
                            .Add(New SqlParameter("@strStatusCode", SqlDbType.NVarChar, 50)).Value = strStatusCode
                            .Add(New SqlParameter("@strStatusNode", SqlDbType.NVarChar, 255)).Value = strStatusNode
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
                        .CommandText = "ACQUISITION.SP_HOLDING_UPD"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("lngCopyID", OracleType.Number)).Value = lngCopyID
                            .Add(New OracleParameter("intLocationID", OracleType.Number)).Value = intLocID
                            .Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                            .Add(New OracleParameter("strVolume", OracleType.NVarChar, 32)).Value = strVolume
                            .Add(New OracleParameter("strAcquiredDate", OracleType.VarChar, 20)).Value = strAcquiredDate
                            .Add(New OracleParameter("strCopyNumber", OracleType.VarChar, 33)).Value = strCopyNumber
                            .Add(New OracleParameter("dblPrice", OracleType.Float)).Value = dblPrice
                            .Add(New OracleParameter("strShelf", OracleType.NVarChar, 50)).Value = strShelf
                            .Add(New OracleParameter("strCallNumber", OracleType.NVarChar, 32)).Value = strCallNumber
                            .Add(New OracleParameter("strNote", OracleType.NVarChar, 100)).Value = strNote
                            .Add(New OracleParameter("intAcquiredSourceID", OracleType.Number)).Value = intAcquiredSourceID
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

        Public Sub ProcessCopyNumber(ByVal bytMode As Byte, ByVal bytNewLocation As Byte)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spProcessHolding"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strCopyIDs", SqlDbType.VarChar, 4000)).Value = strCopyIDs
                            .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            .Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocID
                            .Add(New SqlParameter("@strShelf", SqlDbType.NVarChar, 50)).Value = strShelf
                            .Add(New SqlParameter("@intMode", SqlDbType.Int)).Value = bytMode
                            .Add(New SqlParameter("@intNew", SqlDbType.Int)).Value = bytNewLocation
                            .Add(New SqlParameter("@strStatusCode", SqlDbType.VarChar, 50)).Value = StatusCode
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
                        .CommandText = "ACQUISITION.SP_PROCESS_HOLDING"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("strCopyIDs", OracleType.VarChar, 4000)).Value = strCopyIDs
                            .Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                            .Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocID
                            .Add(New OracleParameter("strShelf", OracleType.NVarChar, 50)).Value = strShelf
                            .Add(New OracleParameter("intMode", OracleType.Number)).Value = bytMode
                            .Add(New OracleParameter("intNew", OracleType.Number)).Value = bytNewLocation
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

        Public Sub UpdateStatus(ByVal statusCode As String, ByVal loanTypeID As String)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spUpdateStatus"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strCopyIDs", SqlDbType.VarChar, 4000)).Value = strCopyIDs
                            .Add(New SqlParameter("@strStatusCode", SqlDbType.VarChar, 16)).Value = statusCode
                            .Add(New SqlParameter("@intLoanTypeID", SqlDbType.Int)).Value = loanTypeID
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
            End Select
            Call CloseConnection()
        End Sub

        Public Sub UpdateHoldingCopy(ByVal intTotalCopies As Integer, ByVal intFreeCopies As Integer)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHodingCopy_Upd"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@lngItemID", SqlDbType.Int)).Value = lngItemID
                            .Add(New SqlParameter("@intTotalCopies", SqlDbType.Int)).Value = intTotalCopies
                            .Add(New SqlParameter("@intFreeCopies", SqlDbType.Int)).Value = intFreeCopies
                            .Add(New SqlParameter("@intLoanTypeID", SqlDbType.Int)).Value = intLoanTypeID
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
                        .CommandText = "ACQUISITION.SP_UPDATE_HOLDING_CP"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("lngItemID", OracleType.Number)).Value = lngItemID
                            .Add(New OracleParameter("intTotalCopies", OracleType.Number)).Value = intTotalCopies
                            .Add(New OracleParameter("intFreeCopies", OracleType.Number)).Value = intFreeCopies
                            .Add(New OracleParameter("intLoanTypeID", OracleType.Number)).Value = intLoanTypeID
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

        Public Sub Remove(ByVal intReasonID As Integer)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHolding_DelProc"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intRemovedReasonID", SqlDbType.Int)).Value = intReasonID
                            .Add(New SqlParameter("@strCopyIDs", SqlDbType.VarChar, 4000)).Value = strCopyIDs
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
                        .CommandText = "ACQUISITION.SP_HOLDING_REMOVED_PROC"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intRemovedReasonID", OracleType.Number)).Value = intReasonID
                            .Add(New OracleParameter("strCopyIDs", OracleType.VarChar, 4000)).Value = strCopyIDs
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

        Public Sub DeleteDKCB()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spDelete_DKCB"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strCopyIDs", SqlDbType.VarChar, 4000)).Value = strCopyIDs
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
            End Select
            Call CloseConnection()
        End Sub

        ' Method: Delete
        ' Purpose: Delete selected copynumber
        ' Input: IDs
        ' Creator: chuyenpt
        ' CreatedDate: 01/06/2007
        Public Sub Delete()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHoldingRemoved_DelByIds"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strCopyIDs", SqlDbType.VarChar, 4000)).Value = strCopyIDs
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
                        .CommandText = "ACQUISITION.SP_HOLDING_DELETE_PROC"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("strCopyIDs", OracleType.VarChar, 4000)).Value = strCopyIDs
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


        ' Method: Liquidate
        ' Purpose: process liquidate
        ' Input: all infor for liquidate
        ' CreatedDate: 07/03/2005
        ' Create by lent
        Public Sub Liquidate(ByRef intOnLoan As Integer, ByRef intTotalItem As Integer, ByRef intOnInventory As Integer, ByVal strRemovedDate As String, ByVal intReasonID As Integer, ByVal strItemCode As String, ByVal strLiquidCode As String)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_HOLDING_REMOVED_LIQUIDATE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strLiquidCode", OracleType.VarChar, 50)).Value = strLiquidCode
                                .Add(New OracleParameter("strCopyNumbers", OracleType.VarChar, 2500)).Value = strCopyIDs
                                .Add(New OracleParameter("strRemovedDate", OracleType.VarChar, 20)).Value = strRemovedDate
                                .Add(New OracleParameter("intReasonID", OracleType.Number)).Value = intReasonID
                                .Add(New OracleParameter("strItemCode", OracleType.VarChar, 20)).Value = strItemCode
                                .Add(New OracleParameter("intTotalItem", OracleType.Number)).Direction = ParameterDirection.Output
                                .Add(New OracleParameter("intOnLoan", OracleType.Number)).Direction = ParameterDirection.Output
                                .Add(New OracleParameter("intOnInventory", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intTotalItem = .Parameters("intTotalItem").Value
                            intOnLoan = .Parameters("intOnLoan").Value
                            intOnInventory = .Parameters("intOnInventory").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_upHoldingRemoved_UpdLiquiDate"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strLiquidCode", SqlDbType.VarChar, 50)).Value = strLiquidCode
                                .Add(New SqlParameter("@strCopyNumbers", SqlDbType.VarChar, 4000)).Value = strCopyIDs
                                .Add(New SqlParameter("@strRemovedDate", SqlDbType.VarChar, 20)).Value = strRemovedDate
                                .Add(New SqlParameter("@intReasonID", SqlDbType.Int)).Value = intReasonID
                                .Add(New SqlParameter("@strItemCode", SqlDbType.VarChar, 20)).Value = strItemCode
                                .Add(New SqlParameter("@intTotalItem", SqlDbType.Int)).Direction = ParameterDirection.Output
                                .Add(New SqlParameter("@intOnLoan", SqlDbType.Int)).Direction = ParameterDirection.Output
                                .Add(New SqlParameter("@intOnInventory", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intTotalItem = .Parameters("@intTotalItem").Value
                            intOnLoan = .Parameters("@intOnLoan").Value
                            intOnInventory = .Parameters("@intOnInventory").Value
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

        ' Purpose: move a location to another
        ' Creator: lent
        ' Output: int value (0 if fail)
        ' CreatedDate : 23-2-2005
        Public Function MoveLocation(ByVal intLibID2 As Integer, ByVal intLocID2 As Integer, ByVal strShelf2 As String) As String
            Dim strerror As String
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_HOLDING_MOVE_UPD"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intLibID1", OracleType.Number)).Value = intLibID
                                .Add(New OracleParameter("intLibID2", OracleType.Number)).Value = intLibID2
                                .Add(New OracleParameter("intLocationID1", OracleType.Number)).Value = intLocID
                                .Add(New OracleParameter("intLocationID2", OracleType.Number)).Value = intLocID2
                                .Add(New OracleParameter("strShelf1", OracleType.VarChar, 50)).Value = strShelf
                                .Add(New OracleParameter("strShelf2", OracleType.VarChar, 50)).Value = strShelf2
                                .Add(New OracleParameter("strCode", OracleType.VarChar, 20)).Value = strCode
                                .Add(New OracleParameter("strCopyNumber", OracleType.VarChar, 2500)).Value = strCopyNumber
                                .Add(New OracleParameter("strerror", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            strerror = .Parameters("intRetVal").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHolding_UpdMoveCopyNumber"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLibID1", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@intLibID2", SqlDbType.Int)).Value = intLibID2
                                .Add(New SqlParameter("@intLocationID1", SqlDbType.Int)).Value = intLocID
                                .Add(New SqlParameter("@intLocationID2", SqlDbType.Int)).Value = intLocID2
                                .Add(New SqlParameter("@strShelf1", SqlDbType.NVarChar, 50)).Value = strShelf
                                .Add(New SqlParameter("@strShelf2", SqlDbType.NVarChar, 50)).Value = strShelf2
                                .Add(New SqlParameter("@strCode", SqlDbType.NVarChar, 20)).Value = strCode
                                .Add(New SqlParameter("@strCopyNumber", SqlDbType.NVarChar, 2500)).Value = strCopyNumber
                                .Add(New SqlParameter("@intRetVal", SqlDbType.VarChar, 1000)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            strerror = .Parameters("@intRetVal").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Return strerror
        End Function
        Public Sub ReceiveUnlock()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_HOLDING_RECEIVEUNLOCK"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                                .Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocID
                                .Add(New OracleParameter("strFromCopyNum", OracleType.VarChar, 30)).Value = strFromCopyNum
                                .Add(New OracleParameter("strToCopyNum", OracleType.VarChar, 30)).Value = strToCopyNum
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
                        .CommandText = "Lib_spHolding_UpdReceiveUnlock"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocID
                                .Add(New SqlParameter("@strFromCopyNum", SqlDbType.NVarChar, 30)).Value = strFromCopyNum
                                .Add(New SqlParameter("@strToCopyNum", SqlDbType.NVarChar, 30)).Value = strToCopyNum
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

        Public Sub RestoreCopyNumber(ByVal bytMode As Byte, ByVal bytUnlock As Byte, ByRef strCopyNumbers As String)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spRestoreHolding"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strCopyIDs", SqlDbType.VarChar, 1000)).Value = strCopyIDs
                            .Add(New SqlParameter("@intNewLibID", SqlDbType.Int)).Value = intLibID
                            .Add(New SqlParameter("@intNewLocID", SqlDbType.Int)).Value = intLocID
                            .Add(New SqlParameter("@strNewShelf", SqlDbType.NVarChar, 50)).Value = strShelf
                            .Add(New SqlParameter("@intUnlock", SqlDbType.Int)).Value = bytUnlock
                            .Add(New SqlParameter("@intMode", SqlDbType.Int)).Value = bytMode
                            .Add(New SqlParameter("@strCopyNumbers", SqlDbType.VarChar, 2000)).Value = strCopyNumbers
                            .Add(New SqlParameter("@strCopyNumExist", SqlDbType.VarChar, 2000)).Direction = ParameterDirection.Output
                        End With
                        Try
                            .ExecuteNonQuery()
                            strCopyNumbers = .Parameters("@strCopyNumExist").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_RESTORE_HOLDING"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("strCopyIDs", OracleType.VarChar, 1000)).Value = strCopyIDs
                            .Add(New OracleParameter("intNewLibID", OracleType.Number)).Value = intLibID
                            .Add(New OracleParameter("intNewLocID", OracleType.Number)).Value = intLocID
                            .Add(New OracleParameter("strNewShelf", OracleType.VarChar, 50)).Value = strShelf
                            .Add(New OracleParameter("intUnlock", OracleType.Number)).Value = bytUnlock
                            .Add(New OracleParameter("intMode", OracleType.Number)).Value = bytMode
                            .Add(New OracleParameter("strCopyNumbers", OracleType.VarChar, 2000)).Value = strCopyNumbers
                            .Add(New OracleParameter("strCopyNumExist", OracleType.VarChar, 2000)).Direction = ParameterDirection.Output
                        End With
                        Try
                            .ExecuteNonQuery()
                            If Not IsDBNull(.Parameters("strCopyNumExist").Value) Then
                                strCopyNumbers = .Parameters("strCopyNumExist").Value
                            Else
                                strCopyNumbers = ""
                            End If
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

        ' Get Data Holding by Max Id - Tho
        Public Function GetLastRecordHoldingOfItem() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHolding_SelLastRecordOfItem"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strCode", SqlDbType.NVarChar)).Value = strCode
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblGetMaxRecordHolding")
                            GetLastRecordHoldingOfItem = dsData.Tables("tblGetMaxRecordHolding")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblGetMaxRecordHolding")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function


        Public Function GetAcqSource(ByVal strSource As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHolding_GetAcqSource"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strSource", SqlDbType.NVarChar, 100)).Value = strSource
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetAcqSource = dsData.Tables("tblResult")
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

        Public Function GetHoldingDevered(Optional strIDs As String = "", Optional strCopyNumber As String = "", Optional strTitle As String = "", Optional strAuthor As String = "", Optional strClassification As String = "", Optional intAcquiredSource As Integer = 0,
                                          Optional strAdditionalBy As String = "", Optional strDateFrom As String = "", Optional strDateTo As String = "") As DataTable

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHoldingDelivered_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strIDs", SqlDbType.NVarChar, 1000)).Value = strIDs
                                .Add(New SqlParameter("@strCopyNumber", SqlDbType.NVarChar, 33)).Value = strCopyNumber
                                .Add(New SqlParameter("@strTitle", SqlDbType.NVarChar, 255)).Value = strTitle
                                .Add(New SqlParameter("@strAuthor", SqlDbType.NVarChar, 255)).Value = strAuthor
                                .Add(New SqlParameter("@strClassification", SqlDbType.NVarChar, 100)).Value = strClassification
                                .Add(New SqlParameter("@intAcquiredSource", SqlDbType.Int)).Value = intAcquiredSource
                                .Add(New SqlParameter("@strAdditionalBy", SqlDbType.NVarChar, 255)).Value = strAdditionalBy
                                .Add(New SqlParameter("@strDateFrom", SqlDbType.VarChar, 10)).Value = strDateFrom
                                .Add(New SqlParameter("@strDateTo", SqlDbType.VarChar, 10)).Value = strDateTo
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetHoldingDevered = dsData.Tables("tblResult")
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

        Public Function GetHoldingDeveredDetailStatis(Optional strDateFrom As String = "", Optional strDateTo As String = "") As DataTable

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_splHoldingDeliveredDetail_Statis"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strDateFrom", SqlDbType.VarChar, 10)).Value = strDateFrom
                                .Add(New SqlParameter("@strDateTo", SqlDbType.VarChar, 10)).Value = strDateTo
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetHoldingDeveredDetailStatis = dsData.Tables("tblResult")
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

        Public Sub UpdateholdingDelivered(ByVal strIDs As String)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHoldingDelivered_UpdateDelivered"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strIDs", SqlDbType.NVarChar, 1000)).Value = strIDs
                            .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
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
            End Select
            Call CloseConnection()
        End Sub

        Public Sub UpdateholdingDeliveredSuccess(ByVal strIDs As String, ByVal strUserCreate As String, ByVal strDateDelivered As String, ByVal strSenderDelivered As String, ByVal strReceiverDelivered As String)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHoldingDelivered_UpdateDeliveredSuccess"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strIDs", SqlDbType.NVarChar, 1000)).Value = strIDs
                            .Add(New SqlParameter("@strUserCreate", SqlDbType.NVarChar, 100)).Value = strUserCreate
                            .Add(New SqlParameter("@strDateDelivered", SqlDbType.VarChar, 10)).Value = strDateDelivered
                            .Add(New SqlParameter("@strSenderDelivered", SqlDbType.NVarChar, 255)).Value = strSenderDelivered
                            .Add(New SqlParameter("@strReceiverDelivered", SqlDbType.NVarChar, 255)).Value = strReceiverDelivered
                            .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
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
            End Select
            Call CloseConnection()
        End Sub

        Public Function GetHolding() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHoldingLibrary_Selnfor"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = lngItemID
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblGetHolding")
                            GetHolding = dsData.Tables("tblGetHolding")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblGetHolding")
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_HOLDING_INFO_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intItemID", OracleType.Number)).Value = lngItemID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblGetHolding")
                            GetHolding = dsData.Tables("tblGetHolding")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblGetHolding")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function GetHoldingByCopyNumber() As DataTable
            Call OpenConnection()
            With sqlCommand
                .CommandText = "lib_GetHoldingByCopyNumber"
                .CommandType = CommandType.StoredProcedure
                Try
                    With .Parameters
                        .Add(New SqlParameter("@strCopyNumber", SqlDbType.VarChar, 50)).Value = strCopyNumber
                    End With
                    sqlDataAdapter.SelectCommand = sqlCommand
                    sqlDataAdapter.Fill(dsData, "tblGetHolding")
                    GetHoldingByCopyNumber = dsData.Tables("tblGetHolding")
                Catch sqlClientEx As SqlException
                    strErrorMsg = sqlClientEx.Message.ToString
                    intErrorCode = sqlClientEx.Number
                Finally
                    .Parameters.Clear()
                    dsData.Tables.Remove("tblGetHolding")
                End Try
            End With
            Call CloseConnection()
        End Function

        'Check exitcoppynumber in holding
        Public Function CheckExitByCopyNumber(ByVal strCopyNumbers As String, ByVal startPoisition As Integer, ByVal endPoisition As Integer)
            Dim strerror As Integer = 1
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHolding_CheckExitByCopyNumber"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLibId", SqlDbType.NVarChar)).Value = intLibID
                                .Add(New SqlParameter("@strCopyNumbers", SqlDbType.NVarChar)).Value = strCopyNumbers
                                .Add(New SqlParameter("@startPoisition", SqlDbType.Int)).Value = startPoisition
                                .Add(New SqlParameter("@endPoisition", SqlDbType.Int)).Value = endPoisition
                                .Add(New SqlParameter("@intOut", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            strerror = .Parameters("@intOut").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Return strerror
        End Function


        Public Function GetNumberRowOfCopyNumber(strCopyNumber As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Sys_spHolding_SelNumberRowOfCopyNumber"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strCopyNumber", SqlDbType.NVarChar)).Value = strCopyNumber
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblNumbrRow")
                            GetNumberRowOfCopyNumber = dsData.Tables("tblNumbrRow")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblNumbrRow")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose: Execute Forming And Seach CopyNumber by condition
        ' Input:    intLibID,intLocID,strShelf,strCopyNumber,strCallNumber,strVolume,strTitle,strIDs,bytMode
        'bytMode =
        '   0: All (tat ca trong kho)
        '   1: OnLoan (dang cho muon trong kho)
        '   2: OnLock (dang khoa trong kho)
        '   3: NotCheck (chua kiem nhan)
        ' Output: DataTable, intSaveID
        ' Creator: Sondp
        ' CreatedDate: 28/11/2005
        Public Function SearchReceiveSegment(ByVal bytMode As Byte, ByVal strTitle As String, ByVal intNextID As Integer, ByRef intSaveID As Integer, ByVal isUpdate As Boolean) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        If isUpdate Then
                            .CommandText = "Lib__spHolding_SelHolInfor" ' Get data and return intSaveID
                        Else
                            .CommandText = "Lib__spHolding_SelHolInfor1" ' Get data only
                        End If
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocID
                                .Add(New SqlParameter("@strShelf", SqlDbType.NVarChar, 50)).Value = strShelf
                                .Add(New SqlParameter("@strCopyNumber", SqlDbType.NVarChar, 33)).Value = strCopyNumber
                                .Add(New SqlParameter("@strCallNumber", SqlDbType.NVarChar, 32)).Value = strCallNumber
                                .Add(New SqlParameter("@strVolume", SqlDbType.NVarChar, 32)).Value = strVolume
                                .Add(New SqlParameter("@strTitle", SqlDbType.NVarChar, 1000)).Value = strTitle
                                .Add(New SqlParameter("@intNextID", SqlDbType.Int)).Value = intNextID
                                .Add(New SqlParameter("@intMode", SqlDbType.Int)).Value = bytMode
                                If isUpdate Then
                                    .Add(New SqlParameter("@intSaveID", SqlDbType.Int)).Direction = ParameterDirection.Output
                                End If
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            SearchReceiveSegment = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            If isUpdate Then
                                ' Return startID on previous segment
                                intSaveID = .Parameters("@intSaveID").Value
                            End If
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE" ' don't do
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_GET_HOLDING_INFOR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                                .Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocID
                                .Add(New OracleParameter("strShelf", OracleType.VarChar, 50)).Value = strShelf
                                .Add(New OracleParameter("strCopyNumber", OracleType.VarChar, 33)).Value = strCopyNumber
                                .Add(New OracleParameter("strCallNumber", OracleType.VarChar, 32)).Value = strCallNumber
                                .Add(New OracleParameter("strVolume", OracleType.VarChar, 32)).Value = strVolume
                                .Add(New OracleParameter("strTitle", OracleType.VarChar, 1000)).Value = strTitle
                                .Add(New OracleParameter("intMode", OracleType.Number)).Value = bytMode
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            SearchReceiveSegment = dsData.Tables("tblResult")
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

        Public Function SearchCopyNumber(ByVal bytMode As Byte, ByVal strTitle As String, ByVal strIDs As String, ByVal boolIsHaveLibLoc As Boolean, Optional ByVal strItemCode As String = "") As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        If Not boolIsHaveLibLoc Then
                            .CommandText = "Lib_spHolding_SelInfor"
                        Else
                            .CommandText = "Lib_spHolding_SelLibLocInfor"
                        End If
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocID
                                .Add(New SqlParameter("@strShelf", SqlDbType.NVarChar, 50)).Value = strShelf
                                .Add(New SqlParameter("@strCopyNumber", SqlDbType.NVarChar, 33)).Value = strCopyNumber
                                .Add(New SqlParameter("@strCallNumber", SqlDbType.NVarChar, 32)).Value = strCallNumber
                                .Add(New SqlParameter("@strVolume", SqlDbType.NVarChar, 32)).Value = strVolume
                                .Add(New SqlParameter("@strTitle", SqlDbType.NVarChar, 1000)).Value = strTitle
                                .Add(New SqlParameter("@strIDs", SqlDbType.VarChar, 4000)).Value = strIDs
                                .Add(New SqlParameter("@intMode", SqlDbType.Int)).Value = bytMode
                                .Add(New SqlParameter("@strItemCode", SqlDbType.NVarChar, 32)).Value = strItemCode
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            SearchCopyNumber = dsData.Tables("tblResult")
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
                        If Not boolIsHaveLibLoc Then
                            .CommandText = "ACQUISITION.SP_GET_HOLDING_INFOR"
                        Else
                            .CommandText = "ACQUISITION.SP_GET_HOLDING_LIBLOC_INFOR"
                        End If
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                                .Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocID
                                .Add(New OracleParameter("strShelf", OracleType.VarChar, 50)).Value = strShelf
                                .Add(New OracleParameter("strCopyNumber", OracleType.VarChar, 33)).Value = strCopyNumber
                                .Add(New OracleParameter("strCallNumber", OracleType.VarChar, 32)).Value = strCallNumber
                                .Add(New OracleParameter("strVolume", OracleType.VarChar, 32)).Value = strVolume
                                .Add(New OracleParameter("strTitle", OracleType.VarChar, 1000)).Value = strTitle
                                .Add(New OracleParameter("strIDs", OracleType.VarChar, 4000)).Value = strIDs
                                .Add(New OracleParameter("intMode", OracleType.Number)).Value = bytMode
                                .Add(New OracleParameter("strItemCode", OracleType.VarChar, 32)).Value = strItemCode
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            SearchCopyNumber = dsData.Tables("tblResult")
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

        ' Purpose: Execute Forming And Seach CopyNumber by condition
        ' Input:    intLibID,intLocID,bytMode
        'bytMode =
        '   0: All (tat ca trong kho)
        '   1: OnLoan (dang cho muon trong kho)
        '   2: OnLock (dang khoa trong kho)
        '   3: NotCheck (chua kiem nhan)
        ' Output: DataTable
        ' Creator: Sondp
        ' CreatedDate: 21/11/2005
        Public Function SearchSummary(ByVal bytMode As Byte) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHolding_SelSumaryInfor"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocID
                                .Add(New SqlParameter("@intMode", SqlDbType.Int)).Value = bytMode
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            SearchSummary = dsData.Tables("tblResult")
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
                        .CommandText = "ACQUISITION.SP_GET_HOLDING_SUMMARY_INFOR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                                .Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocID
                                .Add(New OracleParameter("intMode", OracleType.Number)).Value = bytMode
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            SearchSummary = dsData.Tables("tblResult")
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

        ' Purpose: Execute Forming And Seach Holding.ID by condition
        ' Input:    intLibID,intLocID,strShelf,bytMode
        'bytMode =
        '   0: All (tat ca trong kho)
        '   1: OnLoan (dang cho muon trong kho)
        '   2: OnLock (dang khoa trong kho)
        '   3: NotCheck (chua kiem nhan)
        ' Output: DataTable
        ' Creator: Sondp
        ' CreatedDate: 21/11/2005
        Public Function SearchHoldingID(ByVal bytMode As Byte) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHolding_SelCountId"
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
                            SearchHoldingID = dsData.Tables("tblResult")
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
                        .CommandText = "ACQUISITION.SP_GET_COUNT_HOLDING_ID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                                .Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocID
                                .Add(New OracleParameter("strShelf", OracleType.VarChar, 50)).Value = strShelf
                                .Add(New OracleParameter("intMode", OracleType.Number)).Value = bytMode
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            SearchHoldingID = dsData.Tables("tblResult")
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

        ' Purpose: Execute Forming And Seach CopyNumber Removed by condition
        ' Input:    intLibID,intLocID,strShelf,strCopyNumber,strCallNumber,strVolume,strTitle
        ' Output: DataTable
        ' Creator: Sondp
        ' CreatedDate: 02/12/2005
        Public Function SearchCopyNumberRemovedIDs(ByVal strTitle As String, Optional ByVal strItemCode As String = "") As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHoldingRemoved_SelByIds"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocID
                                .Add(New SqlParameter("@strShelf", SqlDbType.NVarChar, 50)).Value = strShelf
                                .Add(New SqlParameter("@strCopyNumber", SqlDbType.NVarChar, 33)).Value = strCopyNumber
                                .Add(New SqlParameter("@strCallNumber", SqlDbType.NVarChar, 32)).Value = strCallNumber
                                .Add(New SqlParameter("@strVolume", SqlDbType.NVarChar, 32)).Value = strVolume
                                .Add(New SqlParameter("@strTitle", SqlDbType.NVarChar, 1000)).Value = strTitle
                                .Add(New SqlParameter("@strItemCode", SqlDbType.NVarChar, 32)).Value = strItemCode
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            SearchCopyNumberRemovedIDs = dsData.Tables("tblResult")
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
                        .CommandText = "ACQUISITION.SP_GET_HOLDING_REMOVED_IDs"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                                .Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocID
                                .Add(New OracleParameter("strShelf", OracleType.VarChar, 50)).Value = strShelf
                                .Add(New OracleParameter("strCopyNumber", OracleType.VarChar, 33)).Value = strCopyNumber
                                .Add(New OracleParameter("strCallNumber", OracleType.VarChar, 32)).Value = strCallNumber
                                .Add(New OracleParameter("strVolume", OracleType.VarChar, 32)).Value = strVolume
                                .Add(New OracleParameter("strTitle", OracleType.VarChar, 1000)).Value = strTitle
                                .Add(New OracleParameter("strItemCode", OracleType.VarChar, 32)).Value = strItemCode
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            SearchCopyNumberRemovedIDs = dsData.Tables("tblResult")
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

        ' Purpose: Execute Forming And Seach CopyNumber Removed by strIDs input
        ' Input:   strIDs
        ' Output: DataTable
        ' Creator: Sondp
        ' CreatedDate: 02/12/2005
        Public Function SearchCopyNumberRemovedOnIDs(ByVal strIDs As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHoldingRemoved_SelOnIds"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strIDs", SqlDbType.VarChar, 3000)).Value = strIDs
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            SearchCopyNumberRemovedOnIDs = dsData.Tables("tblResult")
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
                        .CommandText = "ACQUISITION.SP_GET_HOLDING_REMOVED_ONIDs"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strIDs", OracleType.VarChar, 3000)).Value = strIDs
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            SearchCopyNumberRemovedOnIDs = dsData.Tables("tblResult")
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

        Public Function SearchCopyNumberRemoved(ByVal strTitle As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHoldingRemoved_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocID
                                .Add(New SqlParameter("@strShelf", SqlDbType.NVarChar, 50)).Value = strShelf
                                .Add(New SqlParameter("@strCopyNumber", SqlDbType.NVarChar, 33)).Value = strCopyNumber
                                .Add(New SqlParameter("@strCallNumber", SqlDbType.NVarChar, 32)).Value = strCallNumber
                                .Add(New SqlParameter("@strVolume", SqlDbType.NVarChar, 32)).Value = strVolume
                                .Add(New SqlParameter("@strTitle", SqlDbType.NVarChar, 1000)).Value = strTitle
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            SearchCopyNumberRemoved = dsData.Tables("tblResult")
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
                        .CommandText = "ACQUISITION.SP_GET_HOLDING_REMOVED"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                                .Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocID
                                .Add(New OracleParameter("strShelf", OracleType.VarChar, 50)).Value = strShelf
                                .Add(New OracleParameter("strCopyNumber", OracleType.VarChar, 33)).Value = strCopyNumber
                                .Add(New OracleParameter("strCallNumber", OracleType.VarChar, 32)).Value = strCallNumber
                                .Add(New OracleParameter("strVolume", OracleType.VarChar, 32)).Value = strVolume
                                .Add(New OracleParameter("strTitle", OracleType.VarChar, 1000)).Value = strTitle
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            SearchCopyNumberRemoved = dsData.Tables("tblResult")
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

        Public Function GetSumCopyNumber(ByVal strCN As String, ByVal intCopyID As Integer, ByVal intLibID As Integer, ByVal intLocID As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Acq_spCopyNumber_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strCopyNumber", SqlDbType.VarChar, 33)).Value = strCN
                                .Add(New SqlParameter("@intCopyID", SqlDbType.Int)).Value = intCopyID
                                .Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocID
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblGetSumCopyNumber")
                            GetSumCopyNumber = dsData.Tables("tblGetSumCopyNumber")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblGetSumCopyNumber")
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_CHECK_COPYNUMBER"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strCopyNumber", OracleType.VarChar, 33)).Value = strCN
                                .Add(New OracleParameter("intCopyID", OracleType.Number)).Value = intCopyID
                                .Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblGetSumCopyNumber")
                            GetSumCopyNumber = dsData.Tables("tblGetSumCopyNumber")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblGetSumCopyNumber")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function CheckExistCopyNumber(ByVal strCN As String, ByVal intCopyID As Integer, ByVal intLibID As Integer, ByVal intLocID As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Acq_spCopyNumber_CheckExist"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strCopyNumber", SqlDbType.VarChar, 33)).Value = strCN
                                .Add(New SqlParameter("@intCopyID", SqlDbType.Int)).Value = intCopyID
                                .Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocID
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblGetSumCopyNumber")
                            CheckExistCopyNumber = dsData.Tables("tblGetSumCopyNumber")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblGetSumCopyNumber")
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_CHECK_COPYNUMBER"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strCopyNumber", OracleType.VarChar, 33)).Value = strCN
                                .Add(New OracleParameter("intCopyID", OracleType.Number)).Value = intCopyID
                                .Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblGetSumCopyNumber")
                            CheckExistCopyNumber = dsData.Tables("tblGetSumCopyNumber")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblGetSumCopyNumber")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose : Get information for generate list copynumber
        ' In: 
        ' Out: Datatable
        ' Created by: Lent
        ' date : 21-2-2005
        Public Function GenListCopyNumber() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHolding_SelCopyNumber"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocID
                                .Add(New SqlParameter("@strShelf", SqlDbType.NVarChar, 50)).Value = strShelf
                                .Add(New SqlParameter("@strToCopyNum", SqlDbType.VarChar, 32)).Value = strToCopyNum
                                .Add(New SqlParameter("@strFromCopyNum", SqlDbType.VarChar, 32)).Value = strFromCopyNum
                                .Add(New SqlParameter("@intOrderby", SqlDbType.Int)).Value = intOrderby
                                .Add(New SqlParameter("@intDesc", SqlDbType.Int)).Value = intDesc
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GenListCopyNumber = dsData.Tables("tblResult")
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
                        .CommandText = "ACQUISITION.SP_HOLDING_GET_COPYNUMBER"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intLibID", OracleType.Number, 2)).Value = intLibID
                                .Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocID
                                .Add(New OracleParameter("strShelf", OracleType.VarChar, 50)).Value = strShelf
                                .Add(New OracleParameter("strToCopyNum", OracleType.VarChar, 32)).Value = strToCopyNum
                                .Add(New OracleParameter("strFromCopyNum", OracleType.VarChar, 32)).Value = strFromCopyNum
                                .Add(New OracleParameter("intOrderby", OracleType.Number)).Value = intOrderby
                                .Add(New OracleParameter("intDesc", OracleType.Number)).Value = intDesc
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GenListCopyNumber = dsData.Tables("tblResult")
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

        Public Function GetNumBookNotAccept(ByVal strCodeBook As String, ByVal intPOIDi As Integer) As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHolding_SelNumberRowByCopyNumber"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strCode", SqlDbType.VarChar, 20)).Value = strCodeBook
                                .Add(New SqlParameter("@intPOIDi", SqlDbType.Int)).Value = intPOIDi
                                .Add(New SqlParameter("@intResult", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            GetNumBookNotAccept = .Parameters("@intResult").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_GET_NUMBOOKNOTACCEPT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strCode", OracleType.VarChar, 20)).Value = strCodeBook
                                .Add(New OracleParameter("intPOIDi", OracleType.Number)).Value = intPOIDi
                                .Add(New OracleParameter("intResult", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            GetNumBookNotAccept = .Parameters("intResult").Value
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

        Public Function GetRemoveReason(Optional ByVal intReasonID As Integer = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHoldingRemoveReason_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intReasonID", SqlDbType.Int)).Value = intReasonID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblRemovedreason")
                            GetRemoveReason = dsData.Tables("tblRemovedreason")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblRemovedreason")
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_HOLDING_REMOVE_REASON_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intReasonID", OracleType.Number)).Value = intReasonID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblRemovedreason")
                            GetRemoveReason = dsData.Tables("tblRemovedreason")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblRemovedreason")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function GetStatus() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHoldingStatus_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblStatus")
                            GetStatus = dsData.Tables("tblStatus")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblStatus")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function
        Public Function GetStatusByNote(ByVal strStatusNote As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHoldingStatus_SelByNote"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strStatusNote", SqlDbType.NVarChar, 128)).Value = strStatusNote
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblStatus")
                            GetStatusByNote = dsData.Tables("tblStatus")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblStatus")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function
        Public Function GetStatusByCode(ByVal strStatusCode As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHoldingStatus_SelByCode"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strStatusCode", SqlDbType.NVarChar, 128)).Value = strStatusCode
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblStatus")
                            GetStatusByCode = dsData.Tables("tblStatus")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblStatus")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' AddCopyNumber method
        ' Purpose: Add one CopyNumber
        ' Input: some main information of CopyNumber
        Public Sub AddCopyNumber()
            Try
                Call OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With sqlCommand
                            .CommandText = "Lib_spHolding_Ins"
                            .CommandType = CommandType.StoredProcedure
                            With .Parameters
                                .Add(New SqlParameter("@strItemCode", SqlDbType.VarChar, 30)).Value = strCode
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocID
                                .Add(New SqlParameter("@strShelf", SqlDbType.NVarChar, 50)).Value = strShelf
                                .Add(New SqlParameter("@strCallNumber", SqlDbType.NVarChar, 30)).Value = strCallNumber
                                .Add(New SqlParameter("@strCopyNumber", SqlDbType.VarChar, 30)).Value = strCopyNumber
                                .Add(New SqlParameter("@dblPrice", SqlDbType.Float)).Value = dblPrice
                                .Add(New SqlParameter("@strCur", SqlDbType.VarChar)).Value = strCurrencyCode
                                .Add(New SqlParameter("@intItemType", SqlDbType.Int)).Value = intLoanTypeID
                                .Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                                .Add(New SqlParameter("@intLoanTypeID", SqlDbType.Int)).Value = intLoanTypeID
                                .Add(New SqlParameter("@intOutPut", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            Try
                                .ExecuteNonQuery()
                                intOutPut = .Parameters("@intOutPut").Value
                            Catch ex As SqlException
                                strErrorMsg = ex.Message.ToString
                                intErrorCode = ex.Number
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "ORACLE"
                        With oraCommand
                            .CommandText = "ACQUISITION.SP_COPYNUMBER_INS"
                            .CommandType = CommandType.StoredProcedure

                            With .Parameters
                                .Add(New OracleParameter("strItemCode", OracleType.VarChar, 30)).Value = strCode
                                .Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                                .Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocID
                                .Add(New OracleParameter("strShelf", OracleType.VarChar, 50)).Value = strShelf
                                .Add(New OracleParameter("strCallNumber", OracleType.VarChar, 30)).Value = strCallNumber
                                .Add(New OracleParameter("strCopyNumber", OracleType.VarChar, 30)).Value = strCopyNumber
                                .Add(New OracleParameter("dblPrice", OracleType.Number)).Value = dblPrice
                                .Add(New OracleParameter("strCur", OracleType.VarChar, 5)).Value = strCurrencyCode
                                .Add(New OracleParameter("intItemType", OracleType.Number)).Value = intLoanTypeID
                                .Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                                .Add(New OracleParameter("intLoanTypeID", OracleType.Number)).Value = intLoanTypeID
                                .Add(New OracleParameter("intOutPut", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            Try
                                .ExecuteNonQuery()
                                intOutPut = .Parameters("intOutPut").Value
                            Catch ex As OracleException
                                strErrorMsg = ex.Message.ToString
                                intErrorCode = ex.Code
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Call CloseConnection()
            End Try
        End Sub

        ' Purpose: Get summary infor in holding
        ' Input:    intLibID,intLocID,strShelf,bytMode
        'bytMode =
        '   0: All (tat ca trong kho)
        '   1: OnLoan (dang cho muon trong kho)
        '   2: OnLock (dang khoa trong kho)
        '   3: NotCheck (chua kiem nhan)
        ' Output: DataTable
        ' Creator: Sondp
        ' CreatedDate: 21/11/2005
        Public Function GetTotalSearch(ByVal bytMode As Byte) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHolding_SelSummaryHolding"
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
                            GetTotalSearch = dsData.Tables("tblResult")
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
                        .CommandText = "ACQUISITION.SP_ACQ_GET_SUMMARY_HOLDING"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                                .Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocID
                                .Add(New OracleParameter("strShelf", OracleType.VarChar, 50)).Value = strShelf
                                .Add(New OracleParameter("intMode", OracleType.Number)).Value = bytMode
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetTotalSearch = dsData.Tables("tblResult")
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

        ' GetCopyNumberInfor method
        ' Purpose: Get all information of the selected copynumber
        ' Input: CopyNumber
        ' Output: datatable result
        Public Function GetCopyNumberInfor() As DataTable
            Try
                Call OpenConnection()
                Select Case UCase(strDBServer)
                    Case "ORACLE"
                        With oraCommand
                            .CommandText = "ACQUISITION.SP_GETCOPYNUMBERINFOR"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                .Parameters.Add(New OracleParameter("strCopyNumber", OracleType.VarChar, 30)).Value = strCopyNumber
                                .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsData, "tblResult")
                                GetCopyNumberInfor = dsData.Tables("tblResult")
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
                            .CommandText = "Lib_spHolding_SelInforByCopyNumber"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                .Parameters.Add(New SqlParameter("@strCopyNumber", SqlDbType.VarChar, 30)).Value = strCopyNumber
                                sqlDataAdapter.SelectCommand = sqlCommand
                                sqlDataAdapter.Fill(dsData, "tblResult")
                                GetCopyNumberInfor = dsData.Tables("tblResult")
                                dsData.Tables.Remove("tblResult")
                            Catch sqlClientEx As SqlException
                                strErrorMsg = sqlClientEx.Message.ToString
                                intErrorCode = sqlClientEx.Number
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Call CloseConnection()
            End Try
        End Function

        ' Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not oraCommand Is Nothing Then
                        oraCommand.Dispose()
                        oraCommand = Nothing
                    End If
                    If Not sqlCommand Is Nothing Then
                        sqlCommand.Dispose()
                        sqlCommand = Nothing
                    End If
                    If Not sqlConnection Is Nothing Then
                        sqlConnection.Close()
                        sqlConnection.Dispose()
                        sqlConnection = Nothing
                    End If
                    If Not oraConnection Is Nothing Then
                        oraConnection.Close()
                        oraConnection.Dispose()
                        oraConnection = Nothing
                    End If
                    If Not oraDataAdapter Is Nothing Then
                        oraDataAdapter.Dispose()
                        oraDataAdapter = Nothing
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
            Finally
                MyBase.Dispose()
                Call Dispose()
            End Try
        End Sub
    End Class
End Namespace