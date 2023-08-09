Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Patron
    Public Class clsDPatron
        Inherits clsDBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Private strCode As String
        Private strValidDate As String
        Private strExpiredDate As String
        Private strLastIssuedDate As String
        Private strLastName As String
        Private strFirstName As String
        Private strMiddleName As String
        Private blnSex As Boolean
        Private strDOB As String
        Private intEthnicID As Integer
        Private intEducationID As Integer
        Private intOccupationID As Integer
        Private strWorkPlace As String
        Private strTelephone As String
        Private strMobile As String
        Private strZalo As String
        Private strEmail As String
        Private strPortrait As String
        Private intPatronGroupID As Integer
        Private strPassword As String
        Private intStatus As Integer
        Private strNote As String
        Private strIDCard As String
        Private dblDebt As Double
        Private strLastModifiedDate As String
        Private intPatronID As Integer
        Private strPatronIDs As String
        Private strFields As String = ""
        Private strIDs As String
        Private strNameCreate As String = ""
        Private strNameUpdate As String = ""
        Dim strAddressInfor As String

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
        ' AddressInfor property
        Public Property AddressInfor() As String
            Get
                Return strAddressInfor
            End Get
            Set(ByVal Value As String)
                strAddressInfor = Value
            End Set
        End Property
        ' Code Property
        Public Property Code() As String
            Get
                Return strCode
            End Get
            Set(ByVal Value As String)
                strCode = Value
            End Set
        End Property

        ' ValidDate Property
        Public Property ValidDate() As String
            Get
                Return strValidDate
            End Get
            Set(ByVal Value As String)
                strValidDate = Value
            End Set
        End Property

        ' ExpiredDate Property
        Public Property ExpiredDate() As String
            Get
                Return strExpiredDate
            End Get
            Set(ByVal Value As String)
                strExpiredDate = Value
            End Set
        End Property

        ' LastIssuedDate Property
        Public Property LastIssuedDate() As String
            Get
                Return strLastIssuedDate
            End Get
            Set(ByVal Value As String)
                strLastIssuedDate = Value
            End Set
        End Property

        ' LastName Property
        Public Property LastName() As String
            Get
                Return strLastName
            End Get
            Set(ByVal Value As String)
                strLastName = Value
            End Set
        End Property

        ' FirstName Property
        Public Property FirstName() As String
            Get
                Return strFirstName
            End Get
            Set(ByVal Value As String)
                strFirstName = Value
            End Set
        End Property

        ' MiddleName Property
        Public Property MiddleName() As String
            Get
                Return strMiddleName
            End Get
            Set(ByVal Value As String)
                strMiddleName = Value
            End Set
        End Property

        ' Sex Property
        Public Property Sex() As Boolean
            Get
                Return blnSex
            End Get
            Set(ByVal Value As Boolean)
                blnSex = Value
            End Set
        End Property

        ' DOB Property
        Public Property DOB() As String
            Get
                Return strDOB
            End Get
            Set(ByVal Value As String)
                strDOB = Value
            End Set
        End Property

        ' EthnicID Property
        Public Property EthnicID() As Integer
            Get
                Return intEthnicID
            End Get
            Set(ByVal Value As Integer)
                intEthnicID = Value
            End Set
        End Property

        ' EducationID Property
        Public Property EducationID() As Integer
            Get
                Return intEducationID
            End Get
            Set(ByVal Value As Integer)
                intEducationID = Value
            End Set
        End Property

        ' OccupationID Property
        Public Property OccupationID() As Integer
            Get
                Return intOccupationID
            End Get
            Set(ByVal Value As Integer)
                intOccupationID = Value
            End Set
        End Property

        ' WorkPlace Property
        Public Property WorkPlace() As String
            Get
                Return strWorkPlace
            End Get
            Set(ByVal Value As String)
                strWorkPlace = Value
            End Set
        End Property

        ' Telephone Property
        Public Property Telephone() As String
            Get
                Return strTelephone
            End Get
            Set(ByVal Value As String)
                strTelephone = Value
            End Set
        End Property

        ' Mobile Property
        Public Property Mobile() As String
            Get
                Return strMobile
            End Get
            Set(ByVal Value As String)
                strMobile = Value
            End Set
        End Property
        ' Zalo Property
        Public Property Zalo() As String
            Get
                Return strZalo
            End Get
            Set(ByVal Value As String)
                strZalo = Value
            End Set
        End Property
        ' Email Property
        Public Property Email() As String
            Get
                Return strEmail
            End Get
            Set(ByVal Value As String)
                strEmail = Value
            End Set
        End Property

        Public Property Facebook() As String


        ' Portrait Property
        Public Property Portrait() As String
            Get
                Return strPortrait
            End Get
            Set(ByVal Value As String)
                strPortrait = Value
            End Set
        End Property

        ' PatronGroupID Property
        Public Property PatronGroupID() As Integer
            Get
                Return intPatronGroupID
            End Get
            Set(ByVal Value As Integer)
                intPatronGroupID = Value
            End Set
        End Property

        ' Password Property
        Public Property Password() As String
            Get
                Return strPassword
            End Get
            Set(ByVal Value As String)
                strPassword = Value
            End Set
        End Property

        ' Status Property
        Public Property Status() As Integer
            Get
                Return intStatus
            End Get
            Set(ByVal Value As Integer)
                intStatus = Value
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

        ' IDCard property
        Public Property IDCard() As String
            Get
                Return (strIDCard)
            End Get
            Set(ByVal Value As String)
                strIDCard = Value
            End Set
        End Property

        ' Debt Property
        Public Property Debt() As Double
            Get
                Return dblDebt
            End Get
            Set(ByVal Value As Double)
                dblDebt = Value
            End Set
        End Property

        ' LastModifiedDate Property
        Public Property LastModifiedDate() As String
            Get
                Return strLastModifiedDate
            End Get
            Set(ByVal Value As String)
                strLastModifiedDate = Value
            End Set
        End Property

        ' PatronId Property
        Public Property PatronID() As Integer
            Get
                Return intPatronID
            End Get
            Set(ByVal Value As Integer)
                intPatronID = Value
            End Set
        End Property

        ' PatronIds Property
        Public Property PatronIDs() As String
            Get
                Return strPatronIDs
            End Get
            Set(ByVal Value As String)
                strPatronIDs = Value
            End Set
        End Property

        ' Fields Property
        Public Property Fields() As String
            Get
                Return strFields
            End Get
            Set(ByVal Value As String)
                strFields = Value
            End Set
        End Property

        ' strIDs
        Public Property IDs() As String
            Get
                Return strIDs
            End Get
            Set(ByVal Value As String)
                strIDs = Value
            End Set
        End Property

        ' strNameCreate
        Public Property NameCreate() As String
            Get
                Return strNameCreate
            End Get
            Set(ByVal Value As String)
                strNameCreate = Value
            End Set
        End Property

        ' strNameUpdate
        Public Property NameUpdate() As String
            Get
                Return strNameUpdate
            End Get
            Set(ByVal Value As String)
                strNameUpdate = Value
            End Set
        End Property

        ' *************************************************************************************************
        ' End declare properties
        ' Declare public method
        ' *************************************************************************************************

        Public Function GetPatron_byPatronGroupID(Optional ByVal intpatronGroupID As Integer = 0) As DataTable
            Call OpenConnection()
            With sqlCommand
                .CommandText = "Cir_spPatGetPatron_byGroupID"
                .CommandType = CommandType.StoredProcedure
                Try
                    With .Parameters
                        .Add(New SqlParameter("@intPatronGroupID", SqlDbType.Int)).Value = intpatronGroupID
                    End With
                    sqlDataAdapter.SelectCommand = sqlCommand
                    sqlDataAdapter.Fill(dsData, "tblResult")
                    GetPatron_byPatronGroupID = dsData.Tables("tblResult")
                    dsData.Tables.Remove("tblResult")
                Catch sqlClientEx As SqlException
                    strErrorMsg = sqlClientEx.Message.ToString
                    intErrorCode = sqlClientEx.Number
                Finally
                    .Parameters.Clear()
                End Try
            End With
            Call CloseConnection()
        End Function
        Public Function GetPatron_byOrder(Optional ByVal intFacultyID As Integer = 0, Optional ByVal intPatronGroupID As Integer = 0, Optional ByVal intYearFrom As Integer = 0, Optional ByVal intYearTo As Integer = 0) As DataTable
            Call OpenConnection()
            With sqlCommand
                .CommandText = "Cir_spPatGetPatron_byProperty"
                .CommandType = CommandType.StoredProcedure
                Try
                    With .Parameters
                        .Add(New SqlParameter("@intFacultyID", SqlDbType.Int)).Value = intFacultyID
                        .Add(New SqlParameter("@intPatronGroupID", SqlDbType.Int)).Value = intPatronGroupID
                        .Add(New SqlParameter("@intYearFrom", SqlDbType.Int)).Value = intYearFrom
                        .Add(New SqlParameter("@intYearTo", SqlDbType.Int)).Value = intYearTo
                    End With
                    sqlDataAdapter.SelectCommand = sqlCommand
                    sqlDataAdapter.Fill(dsData, "tblResult")
                    GetPatron_byOrder = dsData.Tables("tblResult")
                    dsData.Tables.Remove("tblResult")
                Catch sqlClientEx As SqlException
                    strErrorMsg = sqlClientEx.Message.ToString
                    intErrorCode = sqlClientEx.Number
                Finally
                    .Parameters.Clear()
                End Try
            End With
            Call CloseConnection()
        End Function
        Public Function GetPatron(Optional ByVal strOrder As String = "") As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    Dim SqlClientDataAdapter As SqlDataAdapter
                    With SqlCommand
                        .CommandText = "Cir_spPatGetPatron"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strPatronIDs", SqlDbType.VarChar)).Value = strPatronIDs
                                .Add(New SqlParameter("@strOrder", SqlDbType.VarChar, 100)).Value = strOrder
                                .Add(New SqlParameter("@strFields", SqlDbType.VarChar)).Value = strFields & ""
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetPatron = dsData.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch SqlClientEx As SqlException
                            strErrorMsg = SqlClientEx.Message.ToString
                            intErrorCode = SqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "PATRON.SP_PAT_GET_PATRON"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                .Add(New OracleParameter("strPatronIDs", OracleType.VarChar, 8000)).Value = strPatronIDs
                                .Add(New OracleParameter("strOrder", OracleType.VarChar, 100)).Value = strOrder
                                .Add(New OracleParameter("strFields", OracleType.VarChar, 1000)).Value = strFields & ""
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetPatron = dsData.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
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

        Public Function GetMaxCardNo() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    Dim SqlClientDataAdapter As SqlDataAdapter
                    With sqlCommand
                        .CommandText = "SP_GET_MAX_CARDNO"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetMaxCardNo = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch SqlClientEx As SqlException
                            strErrorMsg = SqlClientEx.Message.ToString
                            intErrorCode = SqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.SP_GET_MAX_CARDNO"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetMaxCardNo = dsData.Tables("tblResult")
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

        Public Function GetPatronByCodeFromTo(Optional ByVal intFrom As Integer = 0, Optional ByVal intTo As Integer = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    Dim SqlClientDataAdapter As SqlDataAdapter
                    With sqlCommand
                        .CommandText = "SP_PAT_GET_PATRON_BYCODE_FROMTO"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intFrom", SqlDbType.Int)).Value = intFrom
                                .Add(New SqlParameter("@intTo", SqlDbType.Int)).Value = intTo
                                .Add(New SqlParameter("@strFields", SqlDbType.VarChar)).Value = strFields & ""
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetPatronByCodeFromTo = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch SqlClientEx As SqlException
                            strErrorMsg = SqlClientEx.Message.ToString
                            intErrorCode = SqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.SP_PAT_GET_PATRON_BYCODE_FROMTO"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                .Add(New OracleParameter("strFields", OracleType.VarChar, 1000)).Value = strFields & ""
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetPatronByCodeFromTo = dsData.Tables("tblResult")
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

        ' Purpose: Retrieve a datatable from cir_patron
        ' Intput: 
        ' Output: DataTable for queue
        ' Creator: Lent
        Public Function GetPatronQueue() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    Dim SqlClientDataAdapter As SqlDataAdapter
                    With SqlCommand
                        .CommandText = "Cir_spPatron_SelQueue"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "PatronQueue")
                            GetPatronQueue = dsData.Tables("PatronQueue")
                        Catch SqlClientEx As SqlException
                            strErrorMsg = SqlClientEx.Message.ToString
                            intErrorCode = SqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsdata.Tables.Remove("PatronQueue")
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "PATRON.SP_CIR_PATRON_SELECT_QUEUE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "PatronQueue")
                            GetPatronQueue = dsData.Tables("PatronQueue")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsdata.Tables.Remove("PatronQueue")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function Create(Optional ByVal intIsQue As Int16 = 0) As Long
            Create = 0
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatCreatePatron"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strCode", SqlDbType.VarChar, 20)).Value = strCode
                                .Add(New SqlParameter("@strValidDate", SqlDbType.VarChar, 20)).Value = strValidDate
                                .Add(New SqlParameter("@strExpiredDate", SqlDbType.VarChar, 20)).Value = strExpiredDate
                                .Add(New SqlParameter("@strLastIssuedDate", SqlDbType.VarChar, 20)).Value = strLastIssuedDate
                                .Add(New SqlParameter("@strLastName", SqlDbType.NVarChar, 30)).Value = strLastName
                                .Add(New SqlParameter("@strFirstName", SqlDbType.NVarChar, 20)).Value = strFirstName
                                .Add(New SqlParameter("@strMiddleName", SqlDbType.NVarChar, 30)).Value = strMiddleName
                                .Add(New SqlParameter("@blnSex", SqlDbType.Bit)).Value = blnSex
                                .Add(New SqlParameter("@strDOB", SqlDbType.VarChar, 20)).Value = strDOB
                                .Add(New SqlParameter("@intEthnicID", SqlDbType.Int)).Value = intEthnicID
                                .Add(New SqlParameter("@intEducationID", SqlDbType.Int)).Value = intEducationID
                                .Add(New SqlParameter("@intOccupationID", SqlDbType.Int)).Value = intOccupationID
                                .Add(New SqlParameter("@strWorkPlace", SqlDbType.NVarChar, 150)).Value = strWorkPlace
                                .Add(New SqlParameter("@strTelephone", SqlDbType.NVarChar, 50)).Value = strTelephone
                                .Add(New SqlParameter("@strMobile", SqlDbType.VarChar, 12)).Value = strMobile
                                .Add(New SqlParameter("@strEmail", SqlDbType.VarChar, 50)).Value = strEmail
                                .Add(New SqlParameter("@strFacebook", SqlDbType.NVarChar, 250)).Value = Facebook
                                .Add(New SqlParameter("@strPortrait", SqlDbType.VarChar, 150)).Value = strPortrait
                                .Add(New SqlParameter("@intPatronGroupID", SqlDbType.Int)).Value = intPatronGroupID
                                .Add(New SqlParameter("@strNote", SqlDbType.NVarChar, 1000)).Value = strNote
                                .Add(New SqlParameter("@strNameCreate", SqlDbType.NVarChar, 255)).Value = strNameCreate
                                .Add(New SqlParameter("@strNameUpdate", SqlDbType.NVarChar, 255)).Value = strNameUpdate
                                .Add(New SqlParameter("@strIDCard", SqlDbType.VarChar, 10)).Value = strIDCard
                                .Add(New SqlParameter("@strZalo", SqlDbType.VarChar, 12)).Value = strZalo
                                .Add(New SqlParameter("@intIsQue", SqlDbType.Int)).Value = intIsQue
                                .Add(New SqlParameter("@intRetval", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            Create = .Parameters("@intRetval").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        ' Change SP
                        .CommandText = "PATRON.SP_PAT_CREATE_PATRON"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strCode", OracleType.VarChar, 20)).Value = strCode
                                .Add(New OracleParameter("strValidDate", OracleType.VarChar, 20)).Value = strValidDate
                                .Add(New OracleParameter("strExpiredDate", OracleType.VarChar, 20)).Value = strExpiredDate
                                .Add(New OracleParameter("strLastIssuedDate", OracleType.VarChar, 20)).Value = strLastIssuedDate
                                .Add(New OracleParameter("strLastName", OracleType.VarChar, 30)).Value = strLastName
                                .Add(New OracleParameter("strFirstName", OracleType.VarChar, 20)).Value = strFirstName
                                .Add(New OracleParameter("strMiddleName", OracleType.VarChar, 30)).Value = strMiddleName
                                If blnSex Then
                                    .Add(New OracleParameter("blnSex", OracleType.Char, 1)).Value = "1"
                                Else
                                    .Add(New OracleParameter("blnSex", OracleType.Char, 1)).Value = "0"
                                End If
                                .Add(New OracleParameter("strDOB", OracleType.VarChar, 20)).Value = strDOB
                                .Add(New OracleParameter("intEthnicID", OracleType.Number)).Value = intEthnicID
                                .Add(New OracleParameter("intEducationID", OracleType.Number)).Value = intEducationID
                                .Add(New OracleParameter("intOccupationID", OracleType.Number)).Value = intOccupationID
                                .Add(New OracleParameter("strWorkPlace", OracleType.VarChar, 150)).Value = strWorkPlace
                                .Add(New OracleParameter("strTelephone", OracleType.VarChar, 50)).Value = strTelephone
                                .Add(New OracleParameter("strMobile", OracleType.VarChar, 12)).Value = strMobile
                                .Add(New OracleParameter("strEmail", OracleType.VarChar, 50)).Value = strEmail
                                .Add(New OracleParameter("strPortrait", OracleType.VarChar, 150)).Value = strPortrait
                                .Add(New OracleParameter("intPatronGroupID", OracleType.Number)).Value = intPatronGroupID
                                .Add(New OracleParameter("strNote", OracleType.VarChar, 1000)).Value = strNote
                                .Add(New OracleParameter("strIDCard", OracleType.VarChar, 10)).Value = strIDCard
                                .Add(New OracleParameter("intIsQue", OracleType.Number)).Value = intIsQue
                                .Add(New OracleParameter("intRetval", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            Create = .Parameters("intRetval").Value
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

        Public Function CreatePatron(ByVal intFaculty As Integer, ByVal intCollege As Integer) As Long
            CreatePatron = 0
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spPatron_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strCode", SqlDbType.VarChar, 20)).Value = strCode
                                .Add(New SqlParameter("@strValidDate", SqlDbType.VarChar, 20)).Value = strValidDate
                                .Add(New SqlParameter("@strExpiredDate", SqlDbType.VarChar, 20)).Value = strExpiredDate
                                .Add(New SqlParameter("@strLastIssuedDate", SqlDbType.VarChar, 20)).Value = strLastIssuedDate
                                .Add(New SqlParameter("@strLastModifiedDate", SqlDbType.VarChar, 20)).Value = strLastModifiedDate
                                .Add(New SqlParameter("@strLastName", SqlDbType.NVarChar, 30)).Value = strLastName
                                .Add(New SqlParameter("@strFirstName", SqlDbType.NVarChar, 20)).Value = strFirstName
                                .Add(New SqlParameter("@strMiddleName", SqlDbType.NVarChar, 30)).Value = strMiddleName
                                .Add(New SqlParameter("@blnSex", SqlDbType.Bit)).Value = blnSex
                                .Add(New SqlParameter("@strDOB", SqlDbType.VarChar, 20)).Value = strDOB
                                .Add(New SqlParameter("@intEthnicID", SqlDbType.Int)).Value = intEthnicID
                                .Add(New SqlParameter("@intEducationID", SqlDbType.Int)).Value = intEducationID
                                .Add(New SqlParameter("@intOccupationID", SqlDbType.Int)).Value = intOccupationID
                                .Add(New SqlParameter("@strWorkPlace", SqlDbType.NVarChar, 150)).Value = strWorkPlace
                                .Add(New SqlParameter("@strTelephone", SqlDbType.NVarChar, 50)).Value = strTelephone
                                .Add(New SqlParameter("@strMobile", SqlDbType.VarChar, 12)).Value = strMobile
                                .Add(New SqlParameter("@strEmail", SqlDbType.VarChar, 50)).Value = strEmail
                                .Add(New SqlParameter("@strPortrait", SqlDbType.VarChar, 150)).Value = strPortrait
                                .Add(New SqlParameter("@intPatronGroupID", SqlDbType.Int)).Value = intPatronGroupID
                                .Add(New SqlParameter("@strNote", SqlDbType.NVarChar, 1000)).Value = strNote
                                .Add(New SqlParameter("@strNameCreate", SqlDbType.NVarChar, 255)).Value = strNameCreate
                                .Add(New SqlParameter("@strNameUpdate", SqlDbType.NVarChar, 255)).Value = strNameUpdate
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@intStatus", SqlDbType.Int)).Value = intStatus
                                .Add(New SqlParameter("@intFaculty", SqlDbType.Int)).Value = intFaculty
                                .Add(New SqlParameter("@intCollege", SqlDbType.Int)).Value = intCollege
                                .Add(New SqlParameter("@intRetval", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            CreatePatron = .Parameters("@intRetval").Value
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

        ' Purpose: Get patronID from PatronCard
        ' Input: strCode
        ' Output: datatable
        ' Creator: Sondp
        Public Function GetPatronIDFromCode() As DataTable
            GetPatronIDFromCode = Nothing
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatSearchPatronCard"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strCode", SqlDbType.VarChar, 20)).Value = strCode
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetPatronIDFromCode = dsData.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "PATRON.SP_PAT_SEARCH_PATRON_HCARD"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strCode", OracleType.VarChar, 20)).Value = strCode
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetPatronIDFromCode = dsData.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
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

        ' Purpose: Check patron
        ' Input: strCode, strDOB, strIDCard
        ' Output: Patron record
        ' Creator: Sondp
        Public Function CheckExistPatron() As DataTable
            CheckExistPatron = Nothing
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatCheckImport"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strCode", SqlDbType.VarChar, 20)).Value = strCode
                                .Add(New SqlParameter("@strDOB", SqlDbType.VarChar, 20)).Value = strDOB
                                .Add(New SqlParameter("@strIDCard", SqlDbType.VarChar, 10)).Value = strIDCard
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            CheckExistPatron = dsData.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "PATRON.SP_PAT_CHECK_IMPORT_PATRON"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strCode", OracleType.VarChar, 20)).Value = strCode
                                .Add(New OracleParameter("strDOB", OracleType.VarChar, 20)).Value = strDOB
                                .Add(New OracleParameter("strIDCard", OracleType.VarChar, 10)).Value = strIDCard
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            CheckExistPatron = dsData.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
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

        Public Function Update() As Long
            Update = 0
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatUpdatePatron"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intPatronID", SqlDbType.Int)).Value = intPatronID
                                .Add(New SqlParameter("@strCode", SqlDbType.VarChar, 20)).Value = strCode
                                .Add(New SqlParameter("@strValidDate", SqlDbType.VarChar, 20)).Value = strValidDate
                                .Add(New SqlParameter("@strExpiredDate", SqlDbType.VarChar, 20)).Value = strExpiredDate
                                .Add(New SqlParameter("@strLastIssuedDate", SqlDbType.VarChar, 20)).Value = strLastIssuedDate
                                .Add(New SqlParameter("@strLastName", SqlDbType.NVarChar, 30)).Value = strLastName
                                .Add(New SqlParameter("@strFirstName", SqlDbType.NVarChar, 20)).Value = strFirstName
                                .Add(New SqlParameter("@strMiddleName", SqlDbType.NVarChar, 30)).Value = strMiddleName
                                .Add(New SqlParameter("@blnSex", SqlDbType.Bit)).Value = blnSex
                                .Add(New SqlParameter("@strDOB", SqlDbType.VarChar, 20)).Value = strDOB
                                .Add(New SqlParameter("@intEthnicID", SqlDbType.Int)).Value = intEthnicID
                                .Add(New SqlParameter("@intEducationID", SqlDbType.Int)).Value = intEducationID
                                .Add(New SqlParameter("@intOccupationID", SqlDbType.Int)).Value = intOccupationID
                                .Add(New SqlParameter("@strWorkPlace", SqlDbType.NVarChar, 150)).Value = strWorkPlace
                                .Add(New SqlParameter("@strTelephone", SqlDbType.NVarChar, 50)).Value = strTelephone
                                .Add(New SqlParameter("@strMobile", SqlDbType.VarChar, 12)).Value = strMobile
                                .Add(New SqlParameter("@strEmail", SqlDbType.VarChar, 50)).Value = strEmail
                                .Add(New SqlParameter("@strFacebook", SqlDbType.NVarChar, 250)).Value = Facebook
                                .Add(New SqlParameter("@strPortrait", SqlDbType.VarChar, 150)).Value = strPortrait
                                .Add(New SqlParameter("@intPatronGroupID", SqlDbType.Int)).Value = intPatronGroupID
                                .Add(New SqlParameter("@strNote", SqlDbType.NVarChar, 1000)).Value = strNote
                                .Add(New SqlParameter("@strNameUpdate", SqlDbType.NVarChar, 255)).Value = strNameUpdate
                                .Add(New SqlParameter("@strIDCard", SqlDbType.VarChar, 10)).Value = strIDCard
                                .Add(New SqlParameter("@intRetval", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            Update = .Parameters("@intRetval").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "PATRON.SP_PAT_UPDATE_PATRON"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intPatronID", OracleType.Number)).Value = intPatronID
                                .Add(New OracleParameter("strCode", OracleType.VarChar, 20)).Value = strCode
                                .Add(New OracleParameter("strValidDate", OracleType.VarChar, 20)).Value = strValidDate
                                .Add(New OracleParameter("strExpiredDate", OracleType.VarChar, 20)).Value = strExpiredDate
                                .Add(New OracleParameter("strLastIssuedDate", OracleType.VarChar, 20)).Value = strLastIssuedDate
                                .Add(New OracleParameter("strLastName", OracleType.VarChar, 30)).Value = strLastName
                                .Add(New OracleParameter("strFirstName", OracleType.VarChar, 20)).Value = strFirstName
                                .Add(New OracleParameter("strMiddleName", OracleType.VarChar, 30)).Value = strMiddleName
                                If blnSex Then
                                    .Add(New OracleParameter("blnSex", OracleType.Char, 1)).Value = "1"
                                Else
                                    .Add(New OracleParameter("blnSex", OracleType.Char, 1)).Value = "0"
                                End If
                                .Add(New OracleParameter("strDOB", OracleType.VarChar, 20)).Value = strDOB
                                .Add(New OracleParameter("intEthnicID", OracleType.Number)).Value = intEthnicID
                                .Add(New OracleParameter("intEducationID", OracleType.Number)).Value = intEducationID
                                .Add(New OracleParameter("intOccupationID", OracleType.Number)).Value = intOccupationID
                                .Add(New OracleParameter("strWorkPlace", OracleType.VarChar, 150)).Value = strWorkPlace
                                .Add(New OracleParameter("strTelephone", OracleType.VarChar, 50)).Value = strTelephone
                                .Add(New OracleParameter("strMobile", OracleType.VarChar, 12)).Value = strMobile
                                .Add(New OracleParameter("strEmail", OracleType.VarChar, 50)).Value = strEmail
                                .Add(New OracleParameter("strPortrait", OracleType.VarChar, 150)).Value = strPortrait
                                .Add(New OracleParameter("intPatronGroupID", OracleType.Number)).Value = intPatronGroupID
                                .Add(New OracleParameter("strNote", OracleType.VarChar, 1000)).Value = strNote
                                .Add(New OracleParameter("strIDCard", OracleType.VarChar, 10)).Value = strIDCard
                                .Add(New OracleParameter("intRetval", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            Update = .Parameters("intRetval").Value
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

        Public Function Delete() As Integer
            Delete = 0
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatDeletePatron"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intPatronID", SqlDbType.Int)).Value = intPatronID
                                .Add(New SqlParameter("@intRetval", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            Delete = .Parameters("@intRetval").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "PATRON.SP_PAT_DELETE_PATRON"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intPatronID", OracleType.Number)).Value = intPatronID
                                .Add(New OracleParameter("intRetval", OracleType.Number)).Direction = ParameterDirection.InputOutput
                            End With
                            .ExecuteNonQuery()
                            Delete = .Parameters("intRetval").Value
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

        ' Purpose: update status=1 in Cir_Patron table
        ' Input: strIDs
        ' Output: 
        ' Creator: lent
        Public Sub UpdateQueue()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatron_UpdQueue"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strIDs", SqlDbType.VarChar)).Value = strIDs
                            End With
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "PATRON.SP_CIR_PATRON_UPDATE_QUEUE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strIDs", OracleType.VarChar)).Value = strIDs
                            End With
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' Method: Dispose
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