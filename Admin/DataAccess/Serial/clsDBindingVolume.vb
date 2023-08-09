' Name: clsDAcqRequest
' Purpose: Management sysbinding
' Creator: Oanhtn
' Created Date: 20/09/2004
' Modification History:

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Serial
    Public Class clsDBindingVolume
        Inherits clsDBase

        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************

        Private intAcqSourceID As Integer
        Private intLoanTypeID As Integer
        Private dblPrice As Double
        Private strShelf As String
        Private strCopyNumber As String
        Private strCopyIDs As String
        Private intBindingMode As Int16
        Private intBindingRule As Integer
        Private intIssuedYear As Integer
        Private lngCopyNumberID As Long
        Private lngItemID As Long
        Private strVolumeByLibrary As String
        Private intLocationID As Integer

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' AcqSourceID Property
        Public Property AcqSourceID() As Integer
            Get
                Return intAcqSourceID
            End Get
            Set(ByVal Value As Integer)
                intAcqSourceID = Value
            End Set
        End Property

        ' LoanTypeID Property
        Public Property LoanTypeID() As Integer
            Get
                Return intLoanTypeID
            End Get
            Set(ByVal Value As Integer)
                intLoanTypeID = Value
            End Set
        End Property

        ' Price Property
        Public Property Price() As Integer
            Get
                Return dblPrice
            End Get
            Set(ByVal Value As Integer)
                dblPrice = Value
            End Set
        End Property

        ' Shelf Property
        Public Property Shelf() As String
            Get
                Return strShelf
            End Get
            Set(ByVal Value As String)
                strShelf = Value
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

        ' CopyIDs Property
        Public Property CopyIDs() As String
            Get
                Return strCopyIDs
            End Get
            Set(ByVal Value As String)
                strCopyIDs = Value
            End Set
        End Property

        ' BindingMode Property
        Public Property BindingMode() As Integer
            Get
                Return intBindingMode
            End Get
            Set(ByVal Value As Integer)
                intBindingMode = Value
            End Set
        End Property

        ' BindingRule Property
        Public Property BindingRule() As Integer
            Get
                Return intBindingRule
            End Get
            Set(ByVal Value As Integer)
                intBindingRule = Value
            End Set
        End Property

        ' IssuedYear Property
        Public Property IssuedYear() As Integer
            Get
                Return intIssuedYear
            End Get
            Set(ByVal Value As Integer)
                intIssuedYear = Value
            End Set
        End Property

        ' CopyNumberID property
        Public Property CopyNumberID() As Long
            Get
                Return lngCopyNumberID
            End Get
            Set(ByVal Value As Long)
                lngCopyNumberID = Value
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

        ' VolumeByLibrary property
        Public Property VolumeByLibrary() As String
            Get
                Return strVolumeByLibrary
            End Get
            Set(ByVal Value As String)
                strVolumeByLibrary = Value
            End Set
        End Property

        ' LocationID property
        Public Property LocationID() As Integer
            Get
                Return intLocationID
            End Get
            Set(ByVal Value As Integer)
                intLocationID = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Bind method
        ' Purpose: Binding
        ' Input: ID of Periodical, CopyIDs, CopyNumber, LocationID, LibID...
        ' Output: 0 when success
        Public Function Bind() As Integer
            Dim intOutValue As Integer = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_CREATE_VOLUME"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intLocationID", OracleType.Number)).Value = intLocationID
                            .Parameters.Add(New OracleParameter("strCopyNumber", OracleType.VarChar, 50)).Value = strCopyNumber
                            .Parameters.Add(New OracleParameter("strShelf", OracleType.VarChar, 50)).Value = strShelf
                            .Parameters.Add(New OracleParameter("intLoanTypeID", OracleType.Number)).Value = intLoanTypeID
                            .Parameters.Add(New OracleParameter("intAcqSourceID", OracleType.Number)).Value = intAcqSourceID
                            .Parameters.Add(New OracleParameter("dblPrice", OracleType.Float)).Value = dblPrice
                            .Parameters.Add(New OracleParameter("lngItemID", OracleType.Number)).Value = lngItemID
                            .Parameters.Add(New OracleParameter("strVolumeByLibrary", OracleType.VarChar, 50)).Value = strVolumeByLibrary
                            .Parameters.Add(New OracleParameter("strCopyIDs", OracleType.VarChar, 1000)).Value = strCopyIDs
                            .Parameters.Add(New OracleParameter("intOutValue", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intOutValue = .Parameters("intOutValue").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHoldingCopy_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                            .Parameters.Add(New SqlParameter("@strCopyNumber", SqlDbType.NVarChar)).Value = strCopyNumber
                            .Parameters.Add(New SqlParameter("@strShelf", SqlDbType.NVarChar)).Value = strShelf
                            .Parameters.Add(New SqlParameter("@intLoanTypeID", SqlDbType.Int)).Value = intLoanTypeID
                            .Parameters.Add(New SqlParameter("@intAcqSourceID", SqlDbType.Int)).Value = intAcqSourceID
                            .Parameters.Add(New SqlParameter("@dblPrice", SqlDbType.Float)).Value = dblPrice
                            .Parameters.Add(New SqlParameter("@lngItemID", SqlDbType.Int)).Value = lngItemID
                            .Parameters.Add(New SqlParameter("@strVolumeByLibrary", SqlDbType.NVarChar)).Value = strVolumeByLibrary
                            .Parameters.Add(New SqlParameter("@strCopyIDs", SqlDbType.VarChar)).Value = strCopyIDs
                            .Parameters.Add(New SqlParameter("@intOutValue", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intOutValue = .Parameters("@intOutValue").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Return intOutValue
        End Function

        ' UnBind method
        ' Purpose: Unbind now
        ' Input: CopyNumberID, ItemID
        Public Sub UnBind()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_UNBIND"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngItemID", OracleType.Number)).Value = lngItemID
                            .Parameters.Add(New OracleParameter("lngCopyNumberID", OracleType.Number)).Value = lngCopyNumberID
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
                        .CommandText = "Ser_spUnbind"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngItemID", SqlDbType.Int)).Value = lngItemID
                            .Parameters.Add(New SqlParameter("@lngCopyNumberID", SqlDbType.Int)).Value = lngCopyNumberID
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

        ' GetCopiesOfBind method
        ' Purpose: Get issues of the selected bind (for unbind)
        ' Input: IssuedYear, ItemID, VolumeByLibrary
        ' Output: datatable result
        Public Function GetCopiesOfBind() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_GET_COPIES_OF_BIND"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIssuedYear", OracleType.Number)).Value = intIssuedYear
                            .Parameters.Add(New OracleParameter("lngItemID", OracleType.Number)).Value = lngItemID
                            .Parameters.Add(New OracleParameter("intLocationID", OracleType.Number)).Value = intLocationID
                            .Parameters.Add(New OracleParameter("lngCopyNumberID", OracleType.Number)).Value = lngCopyNumberID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetCopiesOfBind = dsData.Tables("tblResult")
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
                        .CommandText = "Ser_spCopy_SelBind"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIssuedYear", SqlDbType.Int)).Value = intIssuedYear
                            .Parameters.Add(New SqlParameter("@lngItemID", SqlDbType.Int)).Value = lngItemID
                            .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                            .Parameters.Add(New SqlParameter("@lngCopyNumberID", SqlDbType.Int)).Value = lngCopyNumberID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetCopiesOfBind = dsData.Tables("tblResult")
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

        ' GetCopiesToBind method
        ' Purpose: Get copies of the selected periodical to bind
        ' Input: ItemID
        ' Output: datatable result
        Public Function GetCopiesToBind(ByVal intIssueID As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_GET_COPIES_TO_BIND"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIssuedYear", OracleType.Number)).Value = intIssuedYear
                            .Parameters.Add(New OracleParameter("intIssueID", OracleType.Number)).Value = intIssueID
                            .Parameters.Add(New OracleParameter("lngItemID", OracleType.Number)).Value = lngItemID
                            .Parameters.Add(New OracleParameter("intLocationID", OracleType.Number)).Value = intLocationID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetCopiesToBind = dsData.Tables("tblResult")
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
                        .CommandText = "Ser_spCopy_SelToBind"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIssuedYear", SqlDbType.Int)).Value = intIssuedYear
                            .Parameters.Add(New SqlParameter("@intIssueID", SqlDbType.Int)).Value = intIssueID
                            .Parameters.Add(New SqlParameter("@lngItemID", SqlDbType.Int)).Value = lngItemID
                            .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetCopiesToBind = dsData.Tables("tblResult")
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

        ' GetVolumeByLibrary method
        ' Purpose: Get issues of the selected bind (for unbind)
        ' Input: ItemID, IssuedYear
        ' Output: datatable result
        Public Function GetVolumeByLibrary(Optional ByVal strVolumeByLibrary As String = "", Optional ByVal intIndex As Integer = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_GET_VOLUMEBYLIBRARYS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIssuedYear", OracleType.Number)).Value = intIssuedYear
                            .Parameters.Add(New OracleParameter("lngItemID", OracleType.Number)).Value = lngItemID
                            .Parameters.Add(New OracleParameter("intLocationID", OracleType.Number)).Value = intLocationID
                            .Parameters.Add(New OracleParameter("intIndex", OracleType.Number)).Value = intIndex
                            .Parameters.Add(New OracleParameter("strVolumeByLibrary", OracleType.VarChar, 50)).Value = strVolumeByLibrary
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetVolumeByLibrary = dsData.Tables("tblResult")
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
                        .CommandText = "Ser_spCopy_SelByLibrary"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIssuedYear", SqlDbType.Int)).Value = intIssuedYear
                            .Parameters.Add(New SqlParameter("@lngItemID", SqlDbType.Int)).Value = lngItemID
                            .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                            .Parameters.Add(New SqlParameter("@intIndex", SqlDbType.Int)).Value = intIndex
                            .Parameters.Add(New SqlParameter("@strVolumeByLibrary", SqlDbType.NVarChar)).Value = strVolumeByLibrary
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetVolumeByLibrary = dsData.Tables("tblResult")
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