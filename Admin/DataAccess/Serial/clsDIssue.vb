' Name: clsDIssue
' Purpose: Management Issue
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
    Public Class clsDIssue
        Inherits clsDBase

        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************

        Private strPhysDetail As String
        Private dblPrice As Double
        Private strIssuedDate As String
        Private strIssueNo As String
        Private strOvIssueNo As String
        Private strVolume As String
        Private strSpecialTitle As String
        Private strSummary As String
        Private intSubscribedCopies As Int16
        Private intToBindery As Int16
        Private strNote As String
        Private lngItemID As Long
        Private lngIssueID As Long
        Private intFirstIssueInYear As Int16
        Private intResetRegularity As Int16 = 1
        Private strVolumeByPublisher As String
        Private intSpecialIssue As Int16
        Private intClaimCycle1 As Int16
        Private intClaimCycle2 As Int16
        Private intClaimCycle3 As Int16
        Private intDeliveryTime As Int16

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' PhysDetail property
        Public Property PhysDetail() As String
            Get
                Return strPhysDetail
            End Get
            Set(ByVal Value As String)
                strPhysDetail = Value
            End Set
        End Property

        ' Price property
        Public Property Price() As Double
            Get
                Return dblPrice
            End Get
            Set(ByVal Value As Double)
                dblPrice = Value
            End Set
        End Property

        ' IssuedDate property
        Public Property IssuedDate() As String
            Get
                Return strIssuedDate
            End Get
            Set(ByVal Value As String)
                strIssuedDate = Value
            End Set
        End Property

        ' IssueNo property
        Public Property IssueNo() As String
            Get
                Return strIssueNo
            End Get
            Set(ByVal Value As String)
                strIssueNo = Value
            End Set
        End Property

        ' OvIssueNo property
        Public Property OvIssueNo() As String
            Get
                Return strOvIssueNo
            End Get
            Set(ByVal Value As String)
                strOvIssueNo = Value
            End Set
        End Property

        ' Volume property
        Public Property Volume() As String
            Get
                Return strVolume
            End Get
            Set(ByVal Value As String)
                strVolume = Value
            End Set
        End Property

        ' SpecialTitle property
        Public Property SpecialTitle() As String
            Get
                Return strSpecialTitle
            End Get
            Set(ByVal Value As String)
                strSpecialTitle = Value
            End Set
        End Property

        ' Summary property
        Public Property Summary() As String
            Get
                Return strSummary
            End Get
            Set(ByVal Value As String)
                strSummary = Value
            End Set
        End Property

        ' SubscribedCopies property
        Public Property SubscribedCopies() As Int16
            Get
                Return intSubscribedCopies
            End Get
            Set(ByVal Value As Int16)
                intSubscribedCopies = Value
            End Set
        End Property

        ' ToBindery property
        Public Property ToBindery() As Int16
            Get
                Return intToBindery
            End Get
            Set(ByVal Value As Int16)
                intToBindery = Value
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

        ' ItemID property
        Public Property ItemID() As Long
            Get
                Return lngItemID
            End Get
            Set(ByVal Value As Long)
                lngItemID = Value
            End Set
        End Property

        ' IssueID property
        Public Property IssueID() As Long
            Get
                Return lngIssueID
            End Get
            Set(ByVal Value As Long)
                lngIssueID = Value
            End Set
        End Property

        ' FirstIssueInYear property
        Public Property FirstIssueInYear() As Int16
            Get
                Return intFirstIssueInYear
            End Get
            Set(ByVal Value As Int16)
                intFirstIssueInYear = Value
            End Set
        End Property

        ' ResetRegularity property
        Public Property ResetRegularity() As Int16
            Get
                Return intResetRegularity
            End Get
            Set(ByVal Value As Int16)
                intResetRegularity = Value
            End Set
        End Property

        ' VolumeByPublisher property
        Public Property VolumeByPublisher() As String
            Get
                Return strVolumeByPublisher
            End Get
            Set(ByVal Value As String)
                strVolumeByPublisher = Value
            End Set
        End Property

        ' SpecialIssue property
        Public Property SpecialIssue() As Int16
            Get
                Return intSpecialIssue
            End Get
            Set(ByVal Value As Int16)
                intSpecialIssue = Value
            End Set
        End Property

        ' ClaimCycle1 property
        Public Property ClaimCycle1() As Int16
            Get
                Return intClaimCycle1
            End Get
            Set(ByVal Value As Int16)
                intClaimCycle1 = Value
            End Set
        End Property

        ' ClaimCycle2 property
        Public Property ClaimCycle2() As Int16
            Get
                Return intClaimCycle2
            End Get
            Set(ByVal Value As Int16)
                intClaimCycle2 = Value
            End Set
        End Property

        ' ClaimCycle3 property
        Public Property ClaimCycle3() As Int16
            Get
                Return intClaimCycle3
            End Get
            Set(ByVal Value As Int16)
                intClaimCycle3 = Value
            End Set
        End Property

        ' DeliveryTime property
        Public Property DeliveryTime() As Int16
            Get
                Return intDeliveryTime
            End Get
            Set(ByVal Value As Int16)
                intDeliveryTime = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Add method
        ' Purpose: Add new Issue
        ' Input: some main infor of Issue
        ' Output: Integer value
        '   0: success
        '   1: exist IssueNo
        '   2: fail
        '	3: exist OvIssueNo
        Public Function Add() As Integer
            Dim intOutValue As Integer = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_ADD_ISSUE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngItemID", OracleType.Number)).Value = lngItemID
                            .Parameters.Add(New OracleParameter("intClaimCycle1", OracleType.Number)).Value = intClaimCycle1
                            .Parameters.Add(New OracleParameter("intClaimCycle2", OracleType.Number)).Value = intClaimCycle2
                            .Parameters.Add(New OracleParameter("intClaimCycle3", OracleType.Number)).Value = intClaimCycle3
                            .Parameters.Add(New OracleParameter("intDeliveryTime", OracleType.Number)).Value = intDeliveryTime
                            .Parameters.Add(New OracleParameter("intSpecialIssue", OracleType.Number)).Value = intSpecialIssue
                            .Parameters.Add(New OracleParameter("strPhysDetail", OracleType.VarChar, 200)).Value = strPhysDetail
                            .Parameters.Add(New OracleParameter("dblPrice", OracleType.Float)).Value = dblPrice
                            .Parameters.Add(New OracleParameter("strNote", OracleType.VarChar, 200)).Value = strNote
                            .Parameters.Add(New OracleParameter("strIssuedDate", OracleType.VarChar, 30)).Value = strIssuedDate
                            .Parameters.Add(New OracleParameter("strIssueNo", OracleType.VarChar, 20)).Value = strIssueNo
                            .Parameters.Add(New OracleParameter("strOvIssueNo", OracleType.VarChar, 30)).Value = strOvIssueNo
                            .Parameters.Add(New OracleParameter("strVolumeByPublisher", OracleType.VarChar, 50)).Value = strVolumeByPublisher
                            .Parameters.Add(New OracleParameter("strSpecialTitle", OracleType.VarChar, 200)).Value = strSpecialTitle
                            .Parameters.Add(New OracleParameter("strSummary", OracleType.VarChar, 3000)).Value = strSummary
                            .Parameters.Add(New OracleParameter("intFirstIssueInYear", OracleType.Number)).Value = intFirstIssueInYear
                            .Parameters.Add(New OracleParameter("intResetRegularity", OracleType.Number)).Value = intResetRegularity
                            .Parameters.Add(New OracleParameter("intSubscribedCopies", OracleType.Number)).Value = intSubscribedCopies
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
                        .CommandText = "Ser_spIssue_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngItemID", SqlDbType.Int)).Value = lngItemID
                            .Parameters.Add(New SqlParameter("@intClaimCycle1", SqlDbType.Int)).Value = intClaimCycle1
                            .Parameters.Add(New SqlParameter("@intClaimCycle2", SqlDbType.Int)).Value = intClaimCycle2
                            .Parameters.Add(New SqlParameter("@intClaimCycle3", SqlDbType.Int)).Value = intClaimCycle3
                            .Parameters.Add(New SqlParameter("@intDeliveryTime", SqlDbType.Int)).Value = intDeliveryTime
                            .Parameters.Add(New SqlParameter("@intSpecialIssue", SqlDbType.Int)).Value = intSpecialIssue
                            .Parameters.Add(New SqlParameter("@strPhysDetail", SqlDbType.NVarChar)).Value = strPhysDetail
                            .Parameters.Add(New SqlParameter("@dblPrice", SqlDbType.Float)).Value = dblPrice
                            .Parameters.Add(New SqlParameter("@strNote", SqlDbType.NVarChar)).Value = strNote
                            .Parameters.Add(New SqlParameter("@strIssuedDate", SqlDbType.VarChar)).Value = strIssuedDate
                            .Parameters.Add(New SqlParameter("@strIssueNo", SqlDbType.VarChar, 20)).Value = strIssueNo
                            .Parameters.Add(New SqlParameter("@strOvIssueNo", SqlDbType.VarChar)).Value = strOvIssueNo
                            .Parameters.Add(New SqlParameter("@strVolumeByPublisher", SqlDbType.NVarChar)).Value = strVolumeByPublisher
                            .Parameters.Add(New SqlParameter("@strSpecialTitle", SqlDbType.NVarChar)).Value = strSpecialTitle
                            .Parameters.Add(New SqlParameter("@strSummary", SqlDbType.NVarChar)).Value = strSummary
                            .Parameters.Add(New SqlParameter("@intFirstIssueInYear", SqlDbType.Int)).Value = intFirstIssueInYear
                            .Parameters.Add(New SqlParameter("@intResetRegularity", SqlDbType.Int)).Value = intResetRegularity
                            .Parameters.Add(New SqlParameter("@intSubscribedCopies", SqlDbType.Int)).Value = intSubscribedCopies
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
            Add = intOutValue
        End Function

        ' Update method
        ' Purpose: Update information of the selected Issue
        ' Input: some main infor of Issue
        ' Output: Integer value
        '   0: success
        '   1: exist IssueNo
        '   2: fail
        '	3: exist OvIssueNo
        Public Function Update() As Int16
            Dim intOutValue As Int16 = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_UPDATE_ISSUE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngItemID", OracleType.Number)).Value = lngItemID
                            .Parameters.Add(New OracleParameter("lngIssueID", OracleType.Number)).Value = lngIssueID
                            .Parameters.Add(New OracleParameter("intClaimCycle1", OracleType.Number)).Value = intClaimCycle1
                            .Parameters.Add(New OracleParameter("intClaimCycle2", OracleType.Number)).Value = intClaimCycle2
                            .Parameters.Add(New OracleParameter("intClaimCycle3", OracleType.Number)).Value = intClaimCycle3
                            .Parameters.Add(New OracleParameter("intDeliveryTime", OracleType.Number)).Value = intDeliveryTime
                            .Parameters.Add(New OracleParameter("intSpecialIssue", OracleType.Number)).Value = intSpecialIssue
                            .Parameters.Add(New OracleParameter("strPhysDetail", OracleType.NVarChar, 200)).Value = strPhysDetail
                            .Parameters.Add(New OracleParameter("dblPrice", OracleType.Float)).Value = dblPrice
                            .Parameters.Add(New OracleParameter("strNote", OracleType.NVarChar, 200)).Value = strNote
                            .Parameters.Add(New OracleParameter("strIssuedDate", OracleType.VarChar, 30)).Value = strIssuedDate
                            .Parameters.Add(New OracleParameter("strIssueNo", OracleType.VarChar, 20)).Value = strIssueNo
                            .Parameters.Add(New OracleParameter("strOvIssueNo", OracleType.VarChar, 30)).Value = strOvIssueNo
                            .Parameters.Add(New OracleParameter("strVolumeByPublisher", OracleType.NVarChar, 50)).Value = strVolumeByPublisher
                            .Parameters.Add(New OracleParameter("strSpecialTitle", OracleType.NVarChar, 200)).Value = strSpecialTitle
                            .Parameters.Add(New OracleParameter("strSummary", OracleType.NVarChar, 3000)).Value = strSummary
                            .Parameters.Add(New OracleParameter("intFirstIssueInYear", OracleType.Number)).Value = intFirstIssueInYear
                            .Parameters.Add(New OracleParameter("intResetRegularity", OracleType.Number)).Value = intResetRegularity
                            .Parameters.Add(New OracleParameter("intSubscribedCopies", OracleType.Number)).Value = intSubscribedCopies
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
                        .CommandText = "Ser_spIssue_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngItemID", SqlDbType.Int)).Value = lngItemID
                            .Parameters.Add(New SqlParameter("@lngIssueID", SqlDbType.Int)).Value = lngIssueID
                            .Parameters.Add(New SqlParameter("@intClaimCycle1", SqlDbType.Int)).Value = intClaimCycle1
                            .Parameters.Add(New SqlParameter("@intClaimCycle2", SqlDbType.Int)).Value = intClaimCycle2
                            .Parameters.Add(New SqlParameter("@intClaimCycle3", SqlDbType.Int)).Value = intClaimCycle3
                            .Parameters.Add(New SqlParameter("@intDeliveryTime", SqlDbType.Int)).Value = intDeliveryTime
                            .Parameters.Add(New SqlParameter("@intSpecialIssue", SqlDbType.Int)).Value = intSpecialIssue
                            .Parameters.Add(New SqlParameter("@strPhysDetail", SqlDbType.NVarChar)).Value = strPhysDetail
                            .Parameters.Add(New SqlParameter("@dblPrice", SqlDbType.Float)).Value = dblPrice
                            .Parameters.Add(New SqlParameter("@strNote", SqlDbType.NVarChar)).Value = strNote
                            .Parameters.Add(New SqlParameter("@strIssuedDate", SqlDbType.VarChar)).Value = strIssuedDate
                            .Parameters.Add(New SqlParameter("@strIssueNo", SqlDbType.VarChar, 20)).Value = strIssueNo
                            .Parameters.Add(New SqlParameter("@strOvIssueNo", SqlDbType.VarChar)).Value = strOvIssueNo
                            .Parameters.Add(New SqlParameter("@strVolumeByPublisher", SqlDbType.NVarChar)).Value = strVolumeByPublisher
                            .Parameters.Add(New SqlParameter("@strSpecialTitle", SqlDbType.NVarChar)).Value = strSpecialTitle
                            .Parameters.Add(New SqlParameter("@strSummary", SqlDbType.NVarChar)).Value = strSummary
                            .Parameters.Add(New SqlParameter("@intFirstIssueInYear", SqlDbType.Int)).Value = intFirstIssueInYear
                            .Parameters.Add(New SqlParameter("@intResetRegularity", SqlDbType.Int)).Value = intResetRegularity
                            .Parameters.Add(New SqlParameter("@intSubscribedCopies", SqlDbType.Int)).Value = intSubscribedCopies
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
            Update = intOutValue
        End Function

        ' Delete method
        ' Purpose: delete selected Issue
        ' Input: IssueID
        ' Output: Integer value
        '   + 0: Delete successfull
        '   + 1: exist atlease one copy
        Public Function Delete() As Int16
            Dim intOutValue As Int16 = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_REMOVE_ISSUE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngIssueID", OracleType.Number)).Value = lngIssueID
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
                        .CommandText = "Ser_spRemoveIssue"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngIssueID", SqlDbType.Int)).Value = lngIssueID
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
            Delete = intOutValue
        End Function

        ' Register method       
        ' Purpose: Auto registe issues
        ' Input: some main infor
        ' Output: 
        '   0 when error
        '   Total issue inserted when success
        Public Function Register(ByVal intStartIssueNo As Integer, ByVal intStartOvIssueNo As Integer, ByVal strStartDate As String, ByVal strEndDate As String) As Integer
            Dim intOutValue As Integer = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_AUTO_REGISTER_ISSUE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngItemID", OracleType.Number)).Value = lngItemID
                            .Parameters.Add(New OracleParameter("intStartIssueNo", OracleType.Number)).Value = intStartIssueNo
                            .Parameters.Add(New OracleParameter("intStartOvIssueNo", OracleType.Number)).Value = intStartOvIssueNo
                            .Parameters.Add(New OracleParameter("strStartDate", OracleType.VarChar, 20)).Value = strStartDate
                            .Parameters.Add(New OracleParameter("strEndDate", OracleType.VarChar, 20)).Value = strEndDate
                            .Parameters.Add(New OracleParameter("dblPrice", OracleType.Float)).Value = dblPrice
                            .Parameters.Add(New OracleParameter("strVolumeByPublisher", OracleType.VarChar, 50)).Value = strVolumeByPublisher
                            .Parameters.Add(New OracleParameter("intSubscribedCopies", OracleType.Number)).Value = intSubscribedCopies
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
                        .CommandText = "Ser_spIssue_InsAutoRegisterIssue"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngItemID", SqlDbType.Int)).Value = lngItemID
                            .Parameters.Add(New SqlParameter("@intStartIssueNo", SqlDbType.Int)).Value = intStartIssueNo
                            .Parameters.Add(New SqlParameter("@intStartOvIssueNo", SqlDbType.Int)).Value = intStartOvIssueNo
                            .Parameters.Add(New SqlParameter("@strStartDate", SqlDbType.VarChar, 20)).Value = strStartDate
                            .Parameters.Add(New SqlParameter("@strEndDate", SqlDbType.VarChar, 20)).Value = strEndDate
                            .Parameters.Add(New SqlParameter("@dblPrice", SqlDbType.Float)).Value = dblPrice
                            .Parameters.Add(New SqlParameter("@strVolumeByPublisher", SqlDbType.NVarChar)).Value = strVolumeByPublisher
                            .Parameters.Add(New SqlParameter("@intSubscribedCopies", SqlDbType.Int)).Value = intSubscribedCopies
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
            Register = intOutValue
        End Function

        ' GetIssueInfor method
        ' Purpose: get infor of the selected issue
        ' Input: IssueID
        ' Output: datatable result
        Public Function GetIssueInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_GET_ISSUE_INFOR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngIssueID", OracleType.Number)).Value = lngIssueID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetIssueInfor = dsData.Tables("tblResult")
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
                        .CommandText = "Ser_spIssue_SelInfor"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngIssueID", SqlDbType.Int)).Value = lngIssueID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetIssueInfor = dsData.Tables("tblResult")
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

        ' GetLastIssueInfor method
        ' Purpose: Get last issue infor
        ' Input: ItemID
        ' Output: datatable result
        Public Function GetLastIssueInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_GET_LAST_ISSUE_INFOR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngItemID", OracleType.Number)).Value = lngItemID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetLastIssueInfor = dsData.Tables("tblResult")
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
                        .CommandText = "Ser_spIssue_SelLastIssueInfor"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngItemID", SqlDbType.Int)).Value = lngItemID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetLastIssueInfor = dsData.Tables("tblResult")
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

        ' Claim method
        ' Purpose: Update Claim date for issue
        ' Input: ItemIds, Claim mode (1,2,3)
        Public Sub UpdateClaimDate(ByVal strItemID As String, ByVal intClaimMode As Int16)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_SER_UPDATE_ISSUE_CLAIMDATE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strItemID", OracleType.VarChar, 200)).Value = Trim(strItemID)
                            .Parameters.Add(New OracleParameter("intClaimMode", OracleType.Number)).Value = intClaimMode

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
                        .CommandText = "Ser_spUpdateIssueClaimDate"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strItemID", SqlDbType.VarChar, 200)).Value = Trim(strItemID)
                            .Parameters.Add(New SqlParameter("@intClaimMode", SqlDbType.Int)).Value = intClaimMode

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

        ' GetReceivedCopies method
        ' Purpose: Get received copies of the selected issue
        ' Input: IssueID
        ' Output: datatable result, remaincopies
        Public Function GetReceivedCopies(ByRef intRemainCopies As Integer, ByVal intLocationID As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_GET_RECEIVED_COPIES"
                        .CommandType = CommandType.StoredProcedure
                        Try

                            .Parameters.Add(New OracleParameter("lngIssueID", OracleType.Number)).Value = lngIssueID
                            .Parameters.Add(New OracleParameter("intLocationID", OracleType.Number)).Value = intLocationID
                            .Parameters.Add(New OracleParameter("intRemainCopies", OracleType.Number)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetReceivedCopies = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                            intRemainCopies = .Parameters("intRemainCopies").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ser_spCopy_SelRecieve"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngIssueID", SqlDbType.Int)).Value = lngIssueID
                            .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                            .Parameters.Add(New SqlParameter("@intRemainCopies", SqlDbType.Int)).Direction = ParameterDirection.Output
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetReceivedCopies = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                            intRemainCopies = .Parameters("@intRemainCopies").Value
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