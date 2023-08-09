Imports System
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.DataAccess.OPAC


Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBPeriodical
        Inherits clsBBase

        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************

        Private lngPeriodicalID As Long = 0
        Private intOnSubscription As Int16 = 0
        Private lngItemID As Long = 0
        Private intAcqSourceID As Int16 = 0
        Private intCategoryID As Int16 = 0
        Private intPOID As Integer
        Private strNote As String = ""
        Private strChangeNote As String = ""
        Private strSummaryHolding As String = ""
        Private intCeased As Int16 = 0
        Private intIssue As Integer = 0
        Private strCeasedDate As String = ""
        Private strBasedDate As String = ""
        Private strDays As String = ""
        Private strWeeks As String = ""
        Private strMonths As String = ""
        Private intFreqMode As Int16 = 0
        Private strFreqCode As String = ""
        Private intResetReg As Int16 = 0
        Private intLocationID As Integer = 0
        Private intBindingRule As Integer = 0
        Private intBindingMode As Integer = 0
        Private intYear As Integer = 0
        Private strIssueNo As String = ""
        Private strTitle As String = ""
        Private intCopyNumberID As Integer = 0
        Private intClaimCycle1 As Integer
        Private intClaimCycle2 As Integer
        Private intClaimCycle3 As Integer
        Private intDeliveryTime As Integer
        Private intMonth As Integer = 0
        Private strML As String = ""
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objDPeriodical As New clsDPeriodical

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

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Initialize method
        Public Sub Initialize()
            ' Init objBCSP object
            objBCSP.DBServer = strDBServer
            objBCSP.ConnectionString = strConnectionString
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            Call objBCSP.Initialize()

            ' Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            Call objBCDBS.Initialize()

            ' Init objDPeriodical object
            objDPeriodical.DBServer = strDBServer
            objDPeriodical.ConnectionString = strConnectionString
            Call objDPeriodical.Initialize()
        End Sub

        ' Acquire method
        ' Purpose: Add new periodical
        ' Input: some main infor of periodical
        ' Output: Boolean value (true when success)
        Public Function Acquire() As Boolean
            Try
                objDPeriodical.POID = intPOID
                objDPeriodical.ItemID = lngItemID
                objDPeriodical.AcqSourceID = intAcqSourceID
                objDPeriodical.CategoryID = intCategoryID
                objDPeriodical.Ceased = intCeased
                objDPeriodical.CeasedDate = objBCDBS.ConvertDateBack(strCeasedDate)
                objDPeriodical.BasedDate = objBCDBS.ConvertDateBack(strBasedDate)
                objDPeriodical.Note = Trim(objBCSP.ConvertItBack(strNote))
                objDPeriodical.ChangeNote = Trim(objBCSP.ConvertItBack(strChangeNote))
                objDPeriodical.OnSubscription = intOnSubscription
                Acquire = objDPeriodical.Acquire
                intErrorCode = objDPeriodical.ErrorCode
                strErrorMsg = objDPeriodical.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetLocationInfor method
        ' Purpose: get information about location, symbol, total, total copynumber
        ' Input: Issue 
        ' Output: datatable result
        Public Function GetLocationInfor() As DataTable
            Try
                objDPeriodical.Issue = intIssue
                GetLocationInfor = objDPeriodical.GetLocationInfor
                intErrorCode = objDPeriodical.ErrorCode
                strErrorMsg = objDPeriodical.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetVolumeItemPO method
        ' Purpose: get information about volume 
        ' Input: Issue 
        ' Output: datatable result
        Public Function GetVolumeInfor() As DataTable
            Try
                objDPeriodical.Issue = intIssue
                objDPeriodical.LocationID = intLocationID
                GetVolumeInfor = objDPeriodical.GetVolumeInfor
                intErrorCode = objDPeriodical.ErrorCode
                strErrorMsg = objDPeriodical.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetCopyNumberByVolume method
        ' Purpose: CopyNumber by Volume
        ' Input: Issue 
        ' Output: datatable result
        Public Function GetCopyNumberByVolume() As DataTable
            Try
                objDPeriodical.Issue = intIssue
                objDPeriodical.LocationID = intLocationID
                GetCopyNumberByVolume = objDPeriodical.GetCopyNumberByVolume
                intErrorCode = objDPeriodical.ErrorCode
                strErrorMsg = objDPeriodical.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function


        ' GetLocationItemPO method
        ' Purpose: get information about copynumber
        ' Input: Issue 
        ' Output: datatable result
        Public Function GetCopyNumber() As DataTable
            Try
                objDPeriodical.CopyNumberID = intCopyNumberID
                GetCopyNumber = objDPeriodical.GetCopyNumber
                intErrorCode = objDPeriodical.ErrorCode
                strErrorMsg = objDPeriodical.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        'GetSummaryHolding method
        'Purpose: Get SummaryHolding of the selected periodical
        'Input: some main infor of periodical
        'Output: datatable result
        Public Function GetSummaryHolding() As DataTable
            Try
                objDPeriodical.ItemID = lngItemID
                GetSummaryHolding = objBCDBS.ConvertTable(objDPeriodical.GetSummaryHolding)
                intErrorCode = objDPeriodical.ErrorCode
                strErrorMsg = objDPeriodical.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetGenaralInfor method
        ' Purpose: Get information genarate of periodical as Date, Issue.
        ' Input: ItemID 
        ' Output: datatable result
        Public Function GetGenaralInfor() As DataTable
            Try
                objDPeriodical.ItemID = lngItemID
                objDPeriodical.Year = intYear
                objDPeriodical.Month = intMonth
                objDPeriodical.IssueNo = strIssueNo
                objDPeriodical.ML = objBCSP.ConvertItBack(strML).Trim
                GetGenaralInfor = objBCDBS.ConvertTable(objDPeriodical.GetGenaralInfor, False)
                strTitle = objBCSP.TrimSubFieldCodes(objDPeriodical.Title)
                intErrorCode = objDPeriodical.ErrorCode
                strErrorMsg = objDPeriodical.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' UpdateSummaryHolding method
        ' Purpose: Update SummaryHolding of the selected periodical
        ' Input: SummaryHolding, PeriodicalID
        Public Sub UpdateSummaryHolding()
            Try
                objDPeriodical.ItemID = lngItemID
                objDPeriodical.SummaryHolding = objBCSP.ConvertItBack(strSummaryHolding)
                objDPeriodical.UpdateSummaryHolding()
                intErrorCode = objDPeriodical.ErrorCode
                strErrorMsg = objDPeriodical.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' SetRegularity method
        ' Purpose: Set regularity for the selected periodical
        ' Input: Regularity infor, PeriodicalID
        Public Sub SetRegularity()
            Try
                objDPeriodical.ItemID = Me.ItemID
                objDPeriodical.Days = strDays
                objDPeriodical.Months = strMonths
                objDPeriodical.Weeks = strWeeks
                objDPeriodical.FreqCode = strFreqCode
                objDPeriodical.FreqMode = intFreqMode
                objDPeriodical.ResetReg = intResetReg
                objDPeriodical.SetRegularity()

                intErrorCode = objDPeriodical.ErrorCode
                strErrorMsg = objDPeriodical.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Route method
        ' Purpose: route for the selected periodical
        ' Input: reoute infor, PeriodicalID
        Public Sub Route()
            Try
                intErrorCode = objDPeriodical.ErrorCode
                strErrorMsg = objDPeriodical.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' GetReceivedYear method
        ' Purpose: get received year of the selected periodical
        ' Input: some main infor
        ' Output: Datatable result
        Public Function GetReceivedYear() As DataTable
            Try
                objDPeriodical.ItemID = lngItemID
                objDPeriodical.LocationID = intLocationID
                GetReceivedYear = objDPeriodical.GetReceivedYear()
                intErrorCode = objDPeriodical.ErrorCode
                strErrorMsg = objDPeriodical.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' SetClaimCycle method
        ' Purpose: get unreceived issues of the selected periodical
        ' Input: ClaimCycle infor
        Public Sub SetClaimCycle()
            Try
                objDPeriodical.ItemID = lngItemID
                objDPeriodical.DeliveryTime = intDeliveryTime
                objDPeriodical.ClaimCycle1 = intClaimCycle1
                objDPeriodical.ClaimCycle2 = intClaimCycle2
                objDPeriodical.ClaimCycle3 = intClaimCycle3
                objDPeriodical.SetClaimCycle()
                ErrorCode = objDPeriodical.ErrorCode
                ErrorMsg = objDPeriodical.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' SetBindingRule method
        ' Purpose: Set binding rule for the selected Periodical
        ' Input: Binding rule infor
        Public Sub SetBindingRule()
            Try
                objDPeriodical.ItemID = lngItemID
                objDPeriodical.BindingRule = intBindingRule
                objDPeriodical.BindingMode = intBindingMode
                Call objDPeriodical.SetBindingRule()
                intErrorCode = objDPeriodical.ErrorCode
                strErrorMsg = objDPeriodical.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' GetBindingRule method
        ' Purpose: Get binding rule information of the selected Periodical into intBindingRule & intBindingMode
        ' Input: ItemID
        Public Sub GetBindingRule()
            Try
                objDPeriodical.ItemID = lngItemID
                Call objDPeriodical.GetBindingRule()
                intBindingRule = objDPeriodical.BindingRule
                intBindingMode = objDPeriodical.BindingMode
                intErrorCode = objDPeriodical.ErrorCode
                strErrorMsg = objDPeriodical.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' GetRoutingInfor method
        ' Purpose: get routing infor of the selected periodical
        ' Input: PeriodicalID
        ' Output: Datatable result
        Public Function GetRoutingInfor() As DataTable
            Try
                objDPeriodical.ItemID = lngItemID
                GetRoutingInfor = objBCDBS.ConvertTable(objDPeriodical.GetRoutingInfor, False)
                intErrorCode = objDPeriodical.ErrorCode
                strErrorMsg = objDPeriodical.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetPeriodicalInfor method
        ' Purpose: Get some main infor of the selected periodical
        ' Input: PeriodicalID
        ' Output: Datatable result
        Public Function GetPeriodicalInfor() As DataTable
            Try
                objDPeriodical.ItemID = lngItemID
                GetPeriodicalInfor = objBCDBS.ConvertTable(objDPeriodical.GetPeriodicalInfor, "CONTENT", False)
                intErrorCode = objDPeriodical.ErrorCode
                strErrorMsg = objDPeriodical.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' RemoveRoutingRecord method
        ' Purpose: remove the seleced routing record
        ' Input: intRouteID
        Public Sub RemoveRoutingRecord(ByVal intRecordID As Integer)
            Try
                Call objDPeriodical.RemoveRoutingRecord(intRecordID)
                intErrorCode = objDPeriodical.ErrorCode
                strErrorMsg = objDPeriodical.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' UpdateRoutingRecord method
        ' Purpose: Update informations of the seleced routing record
        ' Input: intRouteID
        Public Sub UpdateRoutingRecord(ByVal intRecordID As Integer, ByVal intCopies As Integer)
            Try
                objDPeriodical.BasedDate = objBCDBS.ConvertDateBack(strBasedDate)
                Call objDPeriodical.UpdateRoutingRecord(intRecordID, intCopies)
                intErrorCode = objDPeriodical.ErrorCode
                strErrorMsg = objDPeriodical.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' GetRemainCopies method
        ' Purpose: Get number of remain copies of the current Periodical
        ' Input: ItemID, POID
        ' Output: number of remain copies
        Public Function GetRemainCopies() As Int16
            Try
                objDPeriodical.POID = intPOID
                objDPeriodical.ItemID = lngItemID
                GetRemainCopies = objDPeriodical.GetRemainCopies
                intErrorCode = objDPeriodical.ErrorCode
                strErrorMsg = objDPeriodical.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' CreateRoutingRecord method
        ' Purpose: Create new routing record
        ' Input: some routing information
        Public Sub CreateRoutingRecord(ByVal intLocationID As Integer, ByVal intCopies As Integer)
            Try
                objDPeriodical.POID = intPOID
                objDPeriodical.ItemID = lngItemID
                objDPeriodical.BasedDate = objBCDBS.ConvertDateBack(strBasedDate)
                Call objDPeriodical.CreateRoutingRecord(intLocationID, intCopies)
                intErrorCode = objDPeriodical.ErrorCode
                strErrorMsg = objDPeriodical.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' GetReceivedVolume method
        ' Purpose: Get received volumes
        ' Input: ItemID
        ' Output: datatable result
        Public Function GetReceivedVolume(ByVal intYear As Integer) As DataTable
            Try
                objDPeriodical.ItemID = lngItemID
                GetReceivedVolume = objBCDBS.ConvertTable(objDPeriodical.GetReceivedVolume(intYear))
                intErrorCode = objDPeriodical.ErrorCode
                strErrorMsg = objDPeriodical.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetReceivedIssues method
        ' Purpose: Get received issues
        ' Input: ItemID, Year, Volume
        ' Output: datatable result
        Public Function GetReceivedIssues(ByVal intYear As Integer, ByVal strVolumeByPublisher As String) As DataTable
            Try
                objDPeriodical.ItemID = lngItemID
                GetReceivedIssues = objBCDBS.ConvertTable(objDPeriodical.GetReceivedIssues(intYear, Trim(objBCSP.ConvertItBack(strVolumeByPublisher))))
                intErrorCode = objDPeriodical.ErrorCode
                strErrorMsg = objDPeriodical.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetReceivedIssues method
        ' Purpose: Get the received Issues by year
        Public Function GetReceivedIssuesByYear(ByVal intYear As Integer, ByRef strDOWs As String, ByRef strBasedDate As String, ByRef strCeasedDate As String) As DataTable
            Try
                objDPeriodical.ItemID = lngItemID
                objDPeriodical.LocationID = intLocationID
                GetReceivedIssuesByYear = objBCDBS.ConvertTable(objDPeriodical.GetReceivedIssuesByYear(intYear, strDOWs, strBasedDate, strCeasedDate))
                intFreqMode = objDPeriodical.FreqMode
                intErrorCode = objDPeriodical.ErrorCode
                strErrorMsg = objDPeriodical.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetReceiveIssueNums method
        ' Purpose: Get received issues
        ' Input: ItemID, Year
        ' Output: datatable result
        Public Sub GetReceiveIssueNums(ByVal intYear As Integer, ByRef intResetReg As Integer, ByRef strMonth1 As String, ByRef strMonth2 As String, ByRef strMonth3 As String, ByRef strMonth4 As String, ByRef strMonth5 As String, ByRef strMonth6 As String, ByRef strMonth7 As String, ByRef strMonth8 As String, ByRef strMonth9 As String, ByRef strMonth10 As String, ByRef strMonth11 As String, ByRef strMonth12 As String, ByRef strHavingYearIssue As String, ByRef strFirstIssueInYear As String)
            Try
                objDPeriodical.ItemID = lngItemID
                objDPeriodical.LocationID = intLocationID
                Call objDPeriodical.GetReceiveIssueNums(intYear, intResetReg, strMonth1, strMonth2, strMonth3, strMonth4, strMonth5, strMonth6, strMonth7, strMonth8, strMonth9, strMonth10, strMonth11, strMonth12, strHavingYearIssue, strFirstIssueInYear)
                strMonth1 = objBCSP.ConvertIt(strMonth1)
                strMonth2 = objBCSP.ConvertIt(strMonth2)
                strMonth3 = objBCSP.ConvertIt(strMonth3)
                strMonth4 = objBCSP.ConvertIt(strMonth4)
                strMonth5 = objBCSP.ConvertIt(strMonth5)
                strMonth6 = objBCSP.ConvertIt(strMonth6)
                strMonth7 = objBCSP.ConvertIt(strMonth7)
                strMonth8 = objBCSP.ConvertIt(strMonth8)
                strMonth9 = objBCSP.ConvertIt(strMonth9)
                strMonth10 = objBCSP.ConvertIt(strMonth10)
                strMonth11 = objBCSP.ConvertIt(strMonth11)
                strMonth12 = objBCSP.ConvertIt(strMonth12)
                strHavingYearIssue = objBCSP.ConvertIt(strHavingYearIssue)
                intErrorCode = objDPeriodical.ErrorCode
                strErrorMsg = objDPeriodical.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' StatByRegularity method
        ' Purpose: Get the regularity of an item
        ' Output: datatable result
        Public Function GetRegularityOfItem() As DataTable
            Try
                objDPeriodical.ItemID = lngItemID
                GetRegularityOfItem = objBCDBS.ConvertTable(objDPeriodical.GetRegularityOfItem, False)
                intErrorCode = objDPeriodical.ErrorCode
                strErrorMsg = objDPeriodical.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: CheckBindingPeriod
        ' Purpose: Check binding period for the selected Periodical
        ' Input: Binding rule infor
        ' Output: integer value (1 if need to bind)
        Public Function CheckBindingPeriod() As Integer
            Try
                objDPeriodical.ItemID = lngItemID
                objDPeriodical.LocationID = intLocationID
                CheckBindingPeriod = objDPeriodical.CheckBindingPeriod
                intErrorCode = objDPeriodical.ErrorCode
                strErrorMsg = objDPeriodical.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function CreateReportByAcqSourceStatus() As DataTable
            Try
                CreateReportByAcqSourceStatus = objBCDBS.ConvertTable(objDPeriodical.CreateReportByAcqSourceStatus)
                intErrorCode = objDPeriodical.ErrorCode
                strErrorMsg = objDPeriodical.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Release resource method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objDPeriodical Is Nothing Then
                    objDPeriodical.Dispose(True)
                    objDPeriodical = Nothing
                End If
            Finally
                Call MyBase.Dispose()
                Call Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace