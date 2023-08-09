Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibOPAC.DataAccess.OPAC
    Public Class clsDPeriodical
        Inherits clsDBase

        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************

        Private lngPeriodicalID As Long
        Private intOnSubscription As Int16
        Private lngItemID As Long
        Private intAcqSourceID As Int16
        Private intCategoryID As Int16
        Private intPOID As Integer
        Private strNote As String
        Private strChangeNote As String
        Private strSummaryHolding As String
        Private strTitle As String = ""
        Private intCeased As Int16
        Private strCeasedDate As String
        Private strBasedDate As String
        Private strDays As String
        Private strWeeks As String
        Private strMonths As String
        Private intFreqMode As Int16
        Private strFreqCode As String
        Private intResetReg As Int16
        Private intLocationID As Integer
        Private intBindingRule As Integer
        Private intBindingMode As Integer
        Private intIssue As Integer = 0
        Private intCopyNumberID As Integer = 0
        Private intYear As Integer = 0
        Private strIssueNo As String = ""
        Private intNumPerMonth As Integer
        Private intNumPerYear As Integer
        Private intClaimCycle1 As Integer
        Private intClaimCycle2 As Integer
        Private intClaimCycle3 As Integer
        Private intDeliveryTime As Integer
        Private strIDs As String = ""
        Private intMonth As Integer = 0
        Private strML As String = ""

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************  
        'PubMonth Property
        Public Property Month() As Integer
            Get
                Return intMonth
            End Get
            Set(ByVal Value As Integer)
                intMonth = Value
            End Set
        End Property
        ' Muc luc property
        Public Property ML() As String
            Get
                Return strML
            End Get
            Set(ByVal Value As String)
                strML = Value
            End Set
        End Property
        'IDs property
        Public Property IDs() As String
            Get
                Return (strIDs)
            End Get
            Set(ByVal Value As String)
                strIDs = Value
            End Set
        End Property

        'DeliveryTime property
        Public Property DeliveryTime() As Integer
            Get
                Return (intDeliveryTime)
            End Get
            Set(ByVal Value As Integer)
                intDeliveryTime = Value
            End Set
        End Property

        'ClaimCycle1 property
        Public Property ClaimCycle1() As Integer
            Get
                Return (intClaimCycle1)
            End Get
            Set(ByVal Value As Integer)
                intClaimCycle1 = Value
            End Set
        End Property

        'ClaimCycle2 property
        Public Property ClaimCycle2() As Integer
            Get
                Return (intClaimCycle2)
            End Get
            Set(ByVal Value As Integer)
                intClaimCycle2 = Value
            End Set
        End Property

        'ClaimCycle3 property
        Public Property ClaimCycle3() As Integer
            Get
                Return (intClaimCycle3)
            End Get
            Set(ByVal Value As Integer)
                intClaimCycle3 = Value
            End Set
        End Property

        ' Title Property
        Public Property Title() As String
            Get
                Return strTitle
            End Get
            Set(ByVal Value As String)
                strTitle = Value
            End Set
        End Property

        ' IssueNo Property
        Public Property IssueNo() As String
            Get
                Return strIssueNo
            End Get
            Set(ByVal Value As String)
                strIssueNo = Value
            End Set
        End Property

        ' PubYear Property
        Public Property Year() As Integer
            Get
                Return intYear
            End Get
            Set(ByVal Value As Integer)
                intYear = Value
            End Set
        End Property

        ' CopyNumberID Property
        Public Property CopyNumberID() As Integer
            Get
                Return intCopyNumberID
            End Get
            Set(ByVal Value As Integer)
                intCopyNumberID = Value
            End Set
        End Property

        ' Issue Property
        Public Property Issue() As Integer
            Get
                Return intIssue
            End Get
            Set(ByVal Value As Integer)
                intIssue = Value
            End Set
        End Property

        ' PeriodicalID property
        Public Property PeriodicalID() As Long
            Get
                Return lngPeriodicalID
            End Get
            Set(ByVal Value As Long)
                lngPeriodicalID = Value
            End Set
        End Property

        ' OnSubscription property
        Public Property OnSubscription() As Int16
            Get
                Return intOnSubscription
            End Get
            Set(ByVal Value As Int16)
                intOnSubscription = Value
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

        ' AcqSourceID property
        Public Property AcqSourceID() As Int16
            Get
                Return intAcqSourceID
            End Get
            Set(ByVal Value As Int16)
                intAcqSourceID = Value
            End Set
        End Property

        ' CategoryID property
        Public Property CategoryID() As Int16
            Get
                Return intCategoryID
            End Get
            Set(ByVal Value As Int16)
                intCategoryID = Value
            End Set
        End Property

        ' POID property
        Public Property POID() As Integer
            Get
                Return intPOID
            End Get
            Set(ByVal Value As Integer)
                intPOID = Value
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

        ' ChangeNote property
        Public Property ChangeNote() As String
            Get
                Return strChangeNote
            End Get
            Set(ByVal Value As String)
                strChangeNote = Value
            End Set
        End Property

        ' SummaryHolding property
        Public Property SummaryHolding() As String
            Get
                Return strSummaryHolding
            End Get
            Set(ByVal Value As String)
                strSummaryHolding = Value
            End Set
        End Property

        ' Ceased property
        Public Property Ceased() As Int16
            Get
                Return intCeased
            End Get
            Set(ByVal Value As Int16)
                intCeased = Value
            End Set
        End Property

        ' CeasedDate property
        Public Property CeasedDate() As String
            Get
                Return strCeasedDate
            End Get
            Set(ByVal Value As String)
                strCeasedDate = Value
            End Set
        End Property

        ' BasedDate property
        Public Property BasedDate() As String
            Get
                Return strBasedDate
            End Get
            Set(ByVal Value As String)
                strBasedDate = Value
            End Set
        End Property

        ' Days property
        Public Property Days() As String
            Get
                Return strDays
            End Get
            Set(ByVal Value As String)
                strDays = Value
            End Set
        End Property

        ' Months property
        Public Property Months() As String
            Get
                Return strMonths
            End Get
            Set(ByVal Value As String)
                strMonths = Value
            End Set
        End Property

        ' Weeks property
        Public Property Weeks() As String
            Get
                Return strWeeks
            End Get
            Set(ByVal Value As String)
                strWeeks = Value
            End Set
        End Property

        ' FreqCode property
        Public Property FreqCode() As String
            Get
                Return strFreqCode
            End Get
            Set(ByVal Value As String)
                strFreqCode = Value
            End Set
        End Property

        ' FreqMode property
        Public Property FreqMode() As Int16
            Get
                Return intFreqMode
            End Get
            Set(ByVal Value As Int16)
                intFreqMode = Value
            End Set
        End Property

        ' ResetReg property
        Public Property ResetReg() As Int16
            Get
                Return intResetReg
            End Get
            Set(ByVal Value As Int16)
                intResetReg = Value
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

        ' BindingRule property
        Public Property BindingRule() As Integer
            Get
                Return intBindingRule
            End Get
            Set(ByVal Value As Integer)
                intBindingRule = Value
            End Set
        End Property

        ' BindingMode property
        Public Property BindingMode() As Integer
            Get
                Return intBindingMode
            End Get
            Set(ByVal Value As Integer)
                intBindingMode = Value
            End Set
        End Property

        ' NumPerMonth property
        Public Property NumPerMonth() As Integer
            Get
                Return intNumPerMonth
            End Get
            Set(ByVal Value As Integer)
                intNumPerMonth = Value
            End Set
        End Property

        ' NumPerYear property
        Public Property NumPerYear() As Integer
            Get
                Return intNumPerYear
            End Get
            Set(ByVal Value As Integer)
                intNumPerYear = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' GetGenaralInfor method
        ' Purpose: Get information genarate of periodical as Date, Issue.
        ' Input: ItemID 
        ' Output: datatable result
        Public Function GetGenaralInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.Ser_spIssue_SelGenarateItemPO"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intItemID", OracleType.Number)).Value = lngItemID
                                .Add(New OracleParameter("intYear", OracleType.Number)).Value = intYear
                                .Add(New OracleParameter("intMonth", OracleType.Number)).Value = intMonth
                                .Add(New OracleParameter("strIssueNo", OracleType.VarChar, 100)).Value = strIssueNo
                                .Add(New OracleParameter("strML", OracleType.VarChar, 1000)).Value = strML
                                .Add(New OracleParameter("strTitle", OracleType.VarChar, 100)).Direction = ParameterDirection.Output
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsdata, "tblResult")
                            strTitle = .Parameters("strTitle").Value
                            GetGenaralInfor = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ser_spIssue_SelGenarateItemPO"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = lngItemID
                                .Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = intYear
                                .Add(New SqlParameter("@intMonth", SqlDbType.Int)).Value = intMonth
                                .Add(New SqlParameter("@strIssueNo", SqlDbType.VarChar, 100)).Value = strIssueNo
                                .Add(New SqlParameter("@strML", SqlDbType.NVarChar, 1000)).Value = strML
                                .Add(New SqlParameter("@strTitle", SqlDbType.VarChar, 100)).Direction = ParameterDirection.Output
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsdata, "tblResult")
                            strTitle = .Parameters("@strTitle").Value
                            GetGenaralInfor = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
        End Function


        ' Acquire method
        ' Purpose: Add new periodical
        ' Input: some main infor of periodical
        ' Output: Boolean value (true when success)
        Public Function Acquire() As Boolean
            Dim intOutValue As Int16 = 1
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.Ser_sptem_UpdAcquirePeridoical"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intPOID", OracleType.Number)).Value = intPOID
                            .Parameters.Add(New OracleParameter("lngItemID", OracleType.Number)).Value = lngItemID
                            .Parameters.Add(New OracleParameter("intAcqSourceID", OracleType.Number)).Value = intAcqSourceID
                            .Parameters.Add(New OracleParameter("intCategoryID", OracleType.Number)).Value = intCategoryID
                            .Parameters.Add(New OracleParameter("intCeased", OracleType.Number)).Value = intCeased
                            .Parameters.Add(New OracleParameter("strBasedDate", OracleType.VarChar, 30)).Value = strBasedDate
                            .Parameters.Add(New OracleParameter("strCeasedDate", OracleType.VarChar, 30)).Value = strCeasedDate
                            .Parameters.Add(New OracleParameter("strNote", OracleType.NVarChar, 200)).Value = strNote
                            .Parameters.Add(New OracleParameter("strChangeNote", OracleType.NVarChar, 200)).Value = strChangeNote
                            .Parameters.Add(New OracleParameter("intOnSubscription", OracleType.Number)).Value = intOnSubscription
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
                        .CommandText = "Ser_sptem_UpdAcquirePeridoical"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intPOID", SqlDbType.Int)).Value = intPOID
                            .Parameters.Add(New SqlParameter("@lngItemID", SqlDbType.Int)).Value = lngItemID
                            .Parameters.Add(New SqlParameter("@intAcqSourceID", SqlDbType.Int)).Value = intAcqSourceID
                            .Parameters.Add(New SqlParameter("@intCategoryID", SqlDbType.Int)).Value = intCategoryID
                            .Parameters.Add(New SqlParameter("@intCeased", SqlDbType.Int)).Value = intCeased
                            .Parameters.Add(New SqlParameter("@strBasedDate", SqlDbType.VarChar, 30)).Value = strBasedDate
                            .Parameters.Add(New SqlParameter("@strCeasedDate", SqlDbType.VarChar, 30)).Value = strCeasedDate
                            .Parameters.Add(New SqlParameter("@strNote", SqlDbType.NVarChar, 200)).Value = strNote
                            .Parameters.Add(New SqlParameter("@strChangeNote", SqlDbType.NVarChar, 200)).Value = strChangeNote
                            .Parameters.Add(New SqlParameter("@intOnSubscription", SqlDbType.Int)).Value = intOnSubscription
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
            If intOutValue = 0 Then
                Return True
            Else
                Return False
            End If
        End Function

        ' GetSummaryHolding method
        ' Purpose: Get SummaryHolding of the selected periodical
        ' Input: some main infor of periodical
        ' Output: datatable result
        Public Function GetSummaryHolding() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.Ser_spGetSummaryHolding"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = lngItemID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsdata, "tblSummaryHolding")
                            GetSummaryHolding = dsdata.Tables("tblSummaryHolding")
                            dsdata.Tables.Remove("tblSummaryHolding")
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ser_spGetSummaryHolding"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = lngItemID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsdata, "tblSummaryHolding")
                            GetSummaryHolding = dsdata.Tables("tblSummaryHolding")
                            dsdata.Tables.Remove("tblSummaryHolding")
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' UpdateSummaryHolding method
        ' Purpose: Update SummaryHolding of the selected periodical
        ' Input: SummaryHolding, PeriodicalID
        Public Sub UpdateSummaryHolding()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.Ser_spSummaryHoldingUpdate"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = Me.ItemID
                            .Parameters.Add(New OracleParameter("strHolding", OracleType.VarChar, 4000)).Value = strSummaryHolding
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            intErrorCode = ex.Code
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ser_spSummaryHoldingUpdate"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = Me.ItemID
                            .Parameters.Add(New SqlParameter("@strHolding", SqlDbType.NVarChar, 4000)).Value = strSummaryHolding
                            .ExecuteNonQuery()
                        Catch ex As SqlException
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' SetRegularity method
        ' Purpose: Set regularity for the selected periodical
        ' Input: Regularity infor, PeriodicalID
        Public Sub SetRegularity()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.Ser_spSetRegularity"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = Me.ItemID
                            .Parameters.Add(New OracleParameter("strDays", OracleType.VarChar, 30)).Value = strDays
                            .Parameters.Add(New OracleParameter("strMonths", OracleType.VarChar, 50)).Value = strMonths
                            .Parameters.Add(New OracleParameter("strWeeks", OracleType.VarChar, 20)).Value = strWeeks
                            .Parameters.Add(New OracleParameter("intFreqMode", OracleType.Number)).Value = intFreqMode
                            .Parameters.Add(New OracleParameter("strFreqCode", OracleType.VarChar, 10)).Value = strFreqCode
                            .Parameters.Add(New OracleParameter("intResetRegularity", OracleType.Number)).Value = intResetReg
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            intErrorCode = ex.Code
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ser_spSetRegularity"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = Me.ItemID
                            .Parameters.Add(New SqlParameter("@strDays", SqlDbType.VarChar, 30)).Value = strDays
                            .Parameters.Add(New SqlParameter("@strMonths", SqlDbType.VarChar, 50)).Value = strMonths
                            .Parameters.Add(New SqlParameter("@strWeeks", SqlDbType.VarChar, 20)).Value = strWeeks
                            .Parameters.Add(New SqlParameter("@intFreqMode", SqlDbType.TinyInt)).Value = intFreqMode
                            .Parameters.Add(New SqlParameter("@strFreqCode", SqlDbType.VarChar, 10)).Value = strFreqCode
                            .Parameters.Add(New SqlParameter("@intResetRegularity", SqlDbType.Int)).Value = intResetReg
                            .ExecuteNonQuery()
                        Catch ex As SqlException
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' GetLocationItemPO method
        ' Purpose: get information about location, symbol, total, total copynumber
        ' Input: Issue 
        ' Output: datatable result
        Public Function GetLocationInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.Lib_spHoldingLocation_SelItemPO"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intIssue", OracleType.Number, 4)).Value = intIssue
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsdata, "tblResult")
                            GetLocationInfor = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHoldingLocation_SelItemPO"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intIssue", SqlDbType.Int, 10)).Value = intIssue
                        End With
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsdata, "tblResult")
                            GetLocationInfor = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
        End Function

        ' GetVolumeItemPO method
        ' Purpose: get information about volume 
        ' Input: Issue 
        ' Output: datatable result
        Public Function GetVolumeInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.Ser_spCopy_SelItemPO"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intIssue", OracleType.Number, 4)).Value = intIssue
                                .Add(New OracleParameter("intLocationID", OracleType.Number, 4)).Value = intLocationID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsdata, "tblResult")
                            GetVolumeInfor = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ser_spCopy_SelItemPO"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intIssue", SqlDbType.Int, 10)).Value = intIssue
                                .Add(New SqlParameter("@intLocationID", SqlDbType.Int, 10)).Value = intLocationID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsdata, "tblResult")
                            GetVolumeInfor = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
        End Function

        ' GetCopyNumberByVolume method
        ' Purpose: get information about CopyNumber by volume 
        ' Input: Issue 
        ' Output: datatable result
        Public Function GetCopyNumberByVolume() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.Ser_spCopy_SelByVolume"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intIssue", OracleType.Number, 4)).Value = intIssue
                                .Add(New OracleParameter("intLocationID", OracleType.Number, 4)).Value = intLocationID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsdata, "tblResult")
                            GetCopyNumberByVolume = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ser_spCopy_SelByVolume"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intIssue", SqlDbType.Int, 10)).Value = intIssue
                                .Add(New SqlParameter("@intLocationID", SqlDbType.Int, 10)).Value = intLocationID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsdata, "tblResult")
                            GetCopyNumberByVolume = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
        End Function

        ' GetCopyNumber method
        ' Purpose: get information about location, symbol, total, total copynumber
        ' Input: Issue 
        ' Output: datatable result
        Public Function GetCopyNumber() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.Lib_spHolding_SelByCopyNumberId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intCopyNumberID", OracleType.Number, 4)).Value = intCopyNumberID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsdata, "tblResult")
                            GetCopyNumber = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHolding_SelByCopyNumberId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intCopyNumberID", SqlDbType.Int, 10)).Value = intCopyNumberID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsdata, "tblResult")
                            GetCopyNumber = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
        End Function

        ' Route method
        ' Purpose: route for the selected periodical
        ' Input: reoute infor, PeriodicalID
        Public Sub Route()
            Try

            Catch ex As Exception

            End Try
        End Sub

        ' FilterIssueList method
        ' Purpose: filter issue depending on some conditions
        ' Input: some main infor
        ' Output: Datatable result
        Public Function FilterIssueList() As DataTable
            Try

            Catch ex As Exception

            End Try
        End Function

        ' GetIssueList
        ' Purpose: get issue of the selected periodical
        ' Input: some main infor
        ' Output: Datatable result
        Public Function GetIssueList() As DataTable
            Try

            Catch ex As Exception

            End Try
        End Function

        ' GetReceivedYear method
        ' Purpose: get received year of the selected periodical
        ' Input: some main infor
        ' Output: Datatable result
        Public Function GetReceivedYear() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.Ser_spIssue_SelReceiveYears"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intLocationID", OracleType.Number)).Value = intLocationID
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = lngItemID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsdata, "tblResult")
                            GetReceivedYear = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ser_spIssue_SelReceiveYears"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = lngItemID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsdata, "tblResult")
                            GetReceivedYear = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' SetClaimCycle method
        ' Purpose: get unreceived issues of the selected periodical
        ' Input: ClaimCycle infor
        Public Sub SetClaimCycle()
            Call OpenConnection()
            Select Case UCase(strdbserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ser_spClaimCycle_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int, 4)).Value = lngItemID
                            .Parameters.Add(New SqlParameter("@intClaimCycle1", SqlDbType.Int, 4)).Value = intClaimCycle1
                            .Parameters.Add(New SqlParameter("@intClaimCycle2", SqlDbType.Int, 4)).Value = intClaimCycle2
                            .Parameters.Add(New SqlParameter("@intClaimCycle3", SqlDbType.Int, 4)).Value = intClaimCycle3
                            .Parameters.Add(New SqlParameter("@intDeliveryTime", SqlDbType.Int, 4)).Value = intDeliveryTime
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oracommand
                        .CommandText = "SERIAL.Ser_spClaimCycle_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number, 4)).Value = lngItemID
                            .Parameters.Add(New OracleParameter("intClaimCycle1", OracleType.Number, 4)).Value = intClaimCycle1
                            .Parameters.Add(New OracleParameter("intClaimCycle2", OracleType.Number, 4)).Value = intClaimCycle2
                            .Parameters.Add(New OracleParameter("intClaimCycle3", OracleType.Number, 4)).Value = intClaimCycle3
                            .Parameters.Add(New OracleParameter("intDeliveryTime", OracleType.Number, 4)).Value = intDeliveryTime
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

        ' SetBindingRule method
        ' Purpose: Set binding rule for the selected Periodical
        ' Input: Binding rule infor
        Public Sub SetBindingRule()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.Ser_spSetBindingRule"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intBindingMode", OracleType.Number)).Value = intBindingMode
                            .Parameters.Add(New OracleParameter("intBindingRule", OracleType.Number)).Value = intBindingRule
                            .Parameters.Add(New OracleParameter("lngItemID", OracleType.Number)).Value = lngItemID
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
                        .CommandText = "Ser_spSetBindingRule"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intBindingMode", SqlDbType.Int)).Value = intBindingMode
                            .Parameters.Add(New SqlParameter("@intBindingRule", SqlDbType.Int)).Value = intBindingRule
                            .Parameters.Add(New SqlParameter("@lngItemID", SqlDbType.Int)).Value = lngItemID
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

        ' GetBindingRule method
        ' Purpose: Get binding rule information of the selected Periodical into intBindingRule & intBindingMode
        ' Input: ItemID
        Public Sub GetBindingRule()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.Ser_spItemSelRule"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intBindingMode", OracleType.Number)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("intBindingRule", OracleType.Number)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("lngItemID", OracleType.Number)).Value = lngItemID
                            .ExecuteNonQuery()
                            intBindingMode = .Parameters("intBindingMode").Value
                            intBindingRule = .Parameters("intBindingRule").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ser_spItemSelRule"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intBindingMode", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@intBindingRule", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@lngItemID", SqlDbType.Int)).Value = lngItemID
                            .ExecuteNonQuery()
                            intBindingMode = .Parameters("@intBindingMode").Value
                            intBindingRule = .Parameters("@intBindingRule").Value
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

        ' GetRoutingInfor method
        ' Purpose: get routing infor of the selected periodical
        ' Input: PeriodicalID
        ' Output: Datatable result
        Public Function GetRoutingInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.Ser_spRouting_SelInfor"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngItemID", OracleType.Number)).Value = lngItemID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetRoutingInfor = dsData.Tables("tblResult")
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
                        .CommandText = "Ser_spRouting_SelInfor"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngItemID", SqlDbType.Int)).Value = lngItemID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetRoutingInfor = dsData.Tables("tblResult")
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

        ' GetPeriodicalInfor method
        ' Purpose: Get some main infor of the selected periodical
        ' Input: PeriodicalID
        ' Output: Datatable result
        Public Function GetPeriodicalInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        ' Change SP
                        ' .CommandText = "SERIAL.SP_GET_PERIODICAL_INFOR"
                        .CommandText = "SERIAL.Ser_spGetPeriodicalInfor"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngItemID", OracleType.Number)).Value = lngItemID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetPeriodicalInfor = dsData.Tables("tblResult")
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
                        .CommandText = "Ser_spGetPeriodicalInfor"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngItemID", SqlDbType.Int)).Value = lngItemID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetPeriodicalInfor = dsData.Tables("tblResult")
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

        ' RemoveRoutingRecord method
        ' Purpose: remove the seleced routing record
        Public Sub RemoveRoutingRecord(ByVal intRecordID As Integer)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.Ser_spRemoveRoutingRecord"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intRecordID", OracleType.Number)).Value = intRecordID
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
                        .CommandText = "Ser_spRemoveRoutingRecord"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intRecordID", SqlDbType.Int)).Value = intRecordID
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

        ' UpdateRoutingRecord method
        ' Purpose: Update informations of the seleced routing record
        ' Input: intRouteID
        Public Sub UpdateRoutingRecord(ByVal intRecordID As Integer, ByVal intCopies As Integer)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.Ser_spRoutingRecord_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strAppliedDate", OracleType.VarChar, 30)).Value = strBasedDate
                            .Parameters.Add(New OracleParameter("intRecordID", OracleType.Number)).Value = intRecordID
                            .Parameters.Add(New OracleParameter("intCopies", OracleType.Number)).Value = intCopies
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
                        .CommandText = "Ser_spRoutingRecord_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strAppliedDate", SqlDbType.VarChar)).Value = strBasedDate
                            .Parameters.Add(New SqlParameter("@intRecordID", SqlDbType.Int)).Value = intRecordID
                            .Parameters.Add(New SqlParameter("@intCopies", SqlDbType.Int)).Value = intCopies
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

        ' GetRemainCopies method
        ' Purpose: Get number of remain copies of the current Periodical
        ' Input: ItemID, POID
        ' Output: number of remain copies
        Public Function GetRemainCopies() As Int16
            Dim intRemainCopies As Int16 = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.Ser_spItem_SelRemainCopies"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngItemID", OracleType.Number)).Value = lngItemID
                            .Parameters.Add(New OracleParameter("intPOID", OracleType.Number)).Value = intPOID
                            .Parameters.Add(New OracleParameter("intRemainCopies", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
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
                        .CommandText = "Ser_spItem_SelRemainCopies"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngItemID", SqlDbType.VarChar)).Value = lngItemID
                            .Parameters.Add(New SqlParameter("@intPOID", SqlDbType.Int)).Value = intPOID
                            .Parameters.Add(New SqlParameter("@intRemainCopies", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
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
            GetRemainCopies = intRemainCopies
        End Function

        ' CreateRoutingRecord method
        ' Purpose: Create new routing record
        ' Input: some routing information
        Public Sub CreateRoutingRecord(ByVal intLocationID As Integer, ByVal intCopies As Integer)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.Ser_spRouting_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strAppliedDate", OracleType.VarChar, 30)).Value = strBasedDate
                            .Parameters.Add(New OracleParameter("lngItemID", OracleType.Number)).Value = lngItemID
                            .Parameters.Add(New OracleParameter("intCopies", OracleType.Number)).Value = intCopies
                            .Parameters.Add(New OracleParameter("intPOID", OracleType.Number)).Value = intPOID
                            .Parameters.Add(New OracleParameter("intLocationID", OracleType.Number)).Value = intLocationID
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
                        .CommandText = "Ser_spRouting_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strAppliedDate", SqlDbType.VarChar)).Value = strBasedDate
                            .Parameters.Add(New SqlParameter("@lngItemID", SqlDbType.Int)).Value = lngItemID
                            .Parameters.Add(New SqlParameter("@intCopies", SqlDbType.Int)).Value = intCopies
                            .Parameters.Add(New SqlParameter("@intPOID", SqlDbType.Int)).Value = intPOID
                            .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
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

        ' GetReceivedVolume method
        ' Purpose: Get received volumes
        ' Input: ItemID
        ' Output: datatable result
        Public Function GetReceivedVolume(ByVal intYear As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.Ser_spIssue_SelReceiveVolume"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngItemID", OracleType.Number)).Value = lngItemID
                            .Parameters.Add(New OracleParameter("intYear", OracleType.Number)).Value = intYear
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetReceivedVolume = dsData.Tables("tblResult")
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
                        .CommandText = "Ser_spIssue_SelReceiveVolume"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngItemID", SqlDbType.VarChar)).Value = lngItemID
                            .Parameters.Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = intYear
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetReceivedVolume = dsData.Tables("tblResult")
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

        ' GetReceivedIssues method
        ' Purpose: Get received issues
        ' Input: ItemID, Year, Volume
        ' Output: datatable result
        Public Function GetReceivedIssues(ByVal intYear As Integer, ByVal strVolumeByPublisher As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.Ser_spIssue_SelReceive"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngItemID", OracleType.Number)).Value = lngItemID
                            .Parameters.Add(New OracleParameter("intYear", OracleType.Number)).Value = intYear
                            .Parameters.Add(New OracleParameter("strVolumeByPublisher", OracleType.NVarChar, 50)).Value = strVolumeByPublisher
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetReceivedIssues = dsData.Tables("tblResult")
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
                        .CommandText = "Ser_spIssue_SelReceive"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngItemID", SqlDbType.VarChar)).Value = lngItemID
                            .Parameters.Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = intYear
                            .Parameters.Add(New SqlParameter("@strVolumeByPublisher", SqlDbType.NVarChar)).Value = strVolumeByPublisher
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetReceivedIssues = dsData.Tables("tblResult")
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

        ' GetReceiveIssueNums method
        ' Purpose: Get received issues
        ' Input: ItemID, Year
        ' Output: datatable result
        Public Sub GetReceiveIssueNums(ByVal intYear As Integer, ByRef intResetReg As Integer, ByRef strMonth1 As String, ByRef strMonth2 As String, ByRef strMonth3 As String, ByRef strMonth4 As String, ByRef strMonth5 As String, ByRef strMonth6 As String, ByRef strMonth7 As String, ByRef strMonth8 As String, ByRef strMonth9 As String, ByRef strMonth10 As String, ByRef strMonth11 As String, ByRef strMonth12 As String, ByRef strHavingYearIssue As String, ByRef strFirstIssueInYear As String)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.Ser_spGetHavingIssue"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = lngItemID
                            .Parameters.Add(New OracleParameter("intYear", OracleType.Number)).Value = intYear
                            .Parameters.Add(New OracleParameter("intLocationID", OracleType.Number)).Value = intLocationID
                            .Parameters.Add(New OracleParameter("intResetReg", OracleType.Number)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("strMonth1", OracleType.VarChar, 4000)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("strMonth2", OracleType.VarChar, 4000)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("strMonth3", OracleType.VarChar, 4000)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("strMonth4", OracleType.VarChar, 4000)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("strMonth5", OracleType.VarChar, 4000)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("strMonth6", OracleType.VarChar, 4000)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("strMonth7", OracleType.VarChar, 4000)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("strMonth8", OracleType.VarChar, 4000)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("strMonth9", OracleType.VarChar, 4000)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("strMonth10", OracleType.VarChar, 4000)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("strMonth11", OracleType.VarChar, 4000)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("strMonth12", OracleType.VarChar, 4000)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("strHavingYearIssue", OracleType.VarChar, 4000)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("strFirstIssueInYear", OracleType.VarChar, 10)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intResetReg = .Parameters("intResetReg").Value
                            If Not IsDBNull(.Parameters("strMonth1").Value) Then
                                strMonth1 = .Parameters("strMonth1").Value
                            Else
                                strMonth1 = ""
                            End If
                            If Not IsDBNull(.Parameters("strMonth2").Value) Then
                                strMonth2 = .Parameters("strMonth2").Value
                            Else
                                strMonth2 = ""
                            End If
                            If Not IsDBNull(.Parameters("strMonth3").Value) Then
                                strMonth3 = .Parameters("strMonth3").Value
                            Else
                                strMonth3 = ""
                            End If
                            If Not IsDBNull(.Parameters("strMonth4").Value) Then
                                strMonth4 = .Parameters("strMonth4").Value
                            Else
                                strMonth4 = ""
                            End If
                            If Not IsDBNull(.Parameters("strMonth5").Value) Then
                                strMonth5 = .Parameters("strMonth5").Value
                            Else
                                strMonth5 = ""
                            End If
                            If Not IsDBNull(.Parameters("strMonth6").Value) Then
                                strMonth6 = .Parameters("strMonth6").Value
                            Else
                                strMonth6 = ""
                            End If
                            If Not IsDBNull(.Parameters("strMonth7").Value) Then
                                strMonth7 = .Parameters("strMonth7").Value
                            Else
                                strMonth7 = ""
                            End If
                            If Not IsDBNull(.Parameters("strMonth8").Value) Then
                                strMonth8 = .Parameters("strMonth8").Value
                            Else
                                strMonth8 = ""
                            End If
                            If Not IsDBNull(.Parameters("strMonth9").Value) Then
                                strMonth9 = .Parameters("strMonth9").Value
                            Else
                                strMonth9 = ""
                            End If
                            If Not IsDBNull(.Parameters("strMonth10").Value) Then
                                strMonth10 = .Parameters("strMonth10").Value
                            Else
                                strMonth10 = ""
                            End If
                            If Not IsDBNull(.Parameters("strMonth11").Value) Then
                                strMonth11 = .Parameters("strMonth11").Value
                            Else
                                strMonth11 = ""
                            End If
                            If Not IsDBNull(.Parameters("strMonth12").Value) Then
                                strMonth12 = .Parameters("strMonth12").Value
                            Else
                                strMonth12 = ""
                            End If
                            If Not IsDBNull(.Parameters("strHavingYearIssue").Value) Then
                                strHavingYearIssue = .Parameters("strHavingYearIssue").Value
                            Else
                                strHavingYearIssue = ""
                            End If
                            If Not IsDBNull(.Parameters("strFirstIssueInYear").Value) Then
                                strFirstIssueInYear = .Parameters("strFirstIssueInYear").Value
                            Else
                                strFirstIssueInYear = ""
                            End If
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ser_spGetHavingIssue"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = lngItemID
                            .Parameters.Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = intYear
                            .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                            .Parameters.Add(New SqlParameter("@intResetReg", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@strMonth1", SqlDbType.NVarChar, 4000)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@strMonth2", SqlDbType.NVarChar, 4000)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@strMonth3", SqlDbType.NVarChar, 4000)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@strMonth4", SqlDbType.NVarChar, 4000)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@strMonth5", SqlDbType.NVarChar, 4000)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@strMonth6", SqlDbType.NVarChar, 4000)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@strMonth7", SqlDbType.NVarChar, 4000)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@strMonth8", SqlDbType.NVarChar, 4000)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@strMonth9", SqlDbType.NVarChar, 4000)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@strMonth10", SqlDbType.NVarChar, 4000)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@strMonth11", SqlDbType.NVarChar, 4000)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@strMonth12", SqlDbType.NVarChar, 4000)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@strHavingYearIssue", SqlDbType.NVarChar, 4000)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@strFirstIssueInYear", SqlDbType.VarChar, 10)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intResetReg = .Parameters("@intResetReg").Value
                            strMonth1 = .Parameters("@strMonth1").Value
                            strMonth2 = .Parameters("@strMonth2").Value
                            strMonth3 = .Parameters("@strMonth3").Value
                            strMonth4 = .Parameters("@strMonth4").Value
                            strMonth5 = .Parameters("@strMonth5").Value
                            strMonth6 = .Parameters("@strMonth6").Value
                            strMonth7 = .Parameters("@strMonth7").Value
                            strMonth8 = .Parameters("@strMonth8").Value
                            strMonth9 = .Parameters("@strMonth9").Value
                            strMonth10 = .Parameters("@strMonth10").Value
                            strMonth11 = .Parameters("@strMonth11").Value
                            strMonth12 = .Parameters("@strMonth12").Value
                            strHavingYearIssue = .Parameters("@strHavingYearIssue").Value
                            strFirstIssueInYear = .Parameters("@strFirstIssueInYear").Value
                            'resort  strHavingYearIssue
                            If strHavingYearIssue.Trim.Length > 2 Then
                                Dim arrHavingIssue() As String = strHavingYearIssue.Split(",")
                                Dim i, j As Integer
                                Dim strTg As String
                                For i = 0 To arrHavingIssue.Length - 3
                                    For j = i + 1 To arrHavingIssue.Length - 2
                                        If CInt(arrHavingIssue(i)) > CInt(arrHavingIssue(j)) Then
                                            strTg = arrHavingIssue(i)
                                            arrHavingIssue(i) = arrHavingIssue(j)
                                            arrHavingIssue(j) = strTg
                                        End If
                                    Next
                                Next
                                strHavingYearIssue = ""
                                For i = 0 To arrHavingIssue.Length - 1
                                    strHavingYearIssue = strHavingYearIssue & arrHavingIssue(i) & ","
                                Next
                                strHavingYearIssue = Left(strHavingYearIssue, strHavingYearIssue.Length - 1)
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
        End Sub

        ' Method: GetTitle
        Public Function GetTitle() As DataTable
            Call OpenConnection()
            Select Case UCase(strDbserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "Lib_spField200_SelByItemIdsQuery"
                        .Parameters.Add(New SqlParameter("@strItemIDs", SqlDbType.VarChar, 500)).Value = strIDs
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsdata, "tblResult")
                            GetTitle = dsdata.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsdata.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With oracommand
                        .CommandText = "SERIAL.Lib_spField200_SelByItemIdsQuery"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("strItemIDs", OracleType.VarChar, 500)).Value = strIDs
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oracommand
                            oraDataAdapter.Fill(dsdata, "tblResult")
                            GetTitle = dsdata.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsdata.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' GetReceivedIssues method
        ' Purpose: Get the received Issues by year
        Public Function GetReceivedIssuesByYear(ByVal intYear As Integer, ByRef strDOWs As String, ByRef strBasedDate As String, ByRef strCeasedDate As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.Ser_spGetReceiveIssue"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = lngItemID
                            .Parameters.Add(New OracleParameter("intYear", OracleType.Number)).Value = intYear
                            .Parameters.Add(New OracleParameter("intLocationID", OracleType.Number)).Value = intLocationID
                            .Parameters.Add(New OracleParameter("intFreqMode", OracleType.Number)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("strDOWs", OracleType.VarChar, 30)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("strBasedDate", OracleType.VarChar, 8)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("strCeasedDate", OracleType.VarChar, 8)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResultByYear")
                            GetReceivedIssuesByYear = dsData.Tables("tblResultByYear")
                            intFreqMode = .Parameters("intFreqMode").Value
                            If Not IsDBNull(.Parameters("strDOWs").Value) Then
                                strDOWs = .Parameters("strDOWs").Value
                            Else
                                strDOWs = ""
                            End If
                            If Not IsDBNull(.Parameters("strBasedDate").Value) Then
                                strBasedDate = .Parameters("strBasedDate").Value
                            Else
                                strBasedDate = ""
                            End If
                            If Not IsDBNull(.Parameters("strCeasedDate").Value) Then
                                strCeasedDate = .Parameters("strCeasedDate").Value
                            Else
                                strCeasedDate = ""
                            End If
                            dsData.Tables.Remove("tblResultByYear")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ser_spGetReceiveIssue"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = lngItemID
                            .Parameters.Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = intYear
                            .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                            .Parameters.Add(New SqlParameter("@intFreqMode", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@strDOWs", SqlDbType.VarChar, 30)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@strBasedDate", SqlDbType.VarChar, 8)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@strCeasedDate", SqlDbType.VarChar, 8)).Direction = ParameterDirection.Output
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResultByYear")
                            GetReceivedIssuesByYear = dsData.Tables("tblResultByYear")
                            intFreqMode = .Parameters("@intFreqMode").Value
                            strDOWs = .Parameters("@strDOWs").Value
                            strBasedDate = .Parameters("@strBasedDate").Value
                            strCeasedDate = .Parameters("@strCeasedDate").Value
                            dsData.Tables.Remove("tblResultByYear")
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

        ' GetRegularityOfItem method
        ' Purpose: Get the regularity of an item
        ' Output: datatable result
        Public Function GetRegularityOfItem() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.Ser_spGetRegularity"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = lngItemID
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetRegularityOfItem = dsData.Tables("tblResult")
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
                        .CommandText = "Ser_spGetRegularity"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = lngItemID
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetRegularityOfItem = dsData.Tables("tblResult")
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

        ' Method: CheckBindingPeriod
        ' Purpose: Check binding period for the selected Periodical
        ' Input: Binding rule infor
        ' Output: integer value (1 if need to bind)
        Public Function CheckBindingPeriod() As Integer
            Dim intRetVal As Int16 = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        ' Need create SP
                        .CommandText = "SERIAL.Ser_spCheckBindPeriod"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngItemID", OracleType.Number)).Value = lngItemID
                            .Parameters.Add(New OracleParameter("intLocationID", OracleType.Number)).Value = intLocationID
                            .Parameters.Add(New OracleParameter("intOut", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("intOut").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ser_spCheckBindPeriod"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngItemID", SqlDbType.Int)).Value = lngItemID
                            .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                            .Parameters.Add(New SqlParameter("@intOut", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("@intOut").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            CheckBindingPeriod = intRetVal
        End Function

        Public Function CreateReportByAcqSourceStatus() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_GET_SOURCE_STATUS_SER_ITEM"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            CreateReportByAcqSourceStatus = dsData.Tables("tblResult")
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
                        .CommandText = "Ser_spItem_SelSourceStatus"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            CreateReportByAcqSourceStatus = dsData.Tables("tblResult")
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