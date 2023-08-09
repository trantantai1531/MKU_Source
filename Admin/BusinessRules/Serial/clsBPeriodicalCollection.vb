Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Serial

Namespace eMicLibAdmin.BusinessRules.Serial
    Public Class clsBPeriodicalCollection
        Inherits clsBPeriodical

        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************

        Private objarrData As Object
        Private objarrLabel As Object
        Private intAcqSourceID As Integer
        Private intOnSubscription As Integer
        Private intVendorID As Integer
        Private strFromDate As String
        Private strToDate As String
        Private chrSelectMode As Char
        Private strIDs As String = ""
        Private chrClaimCycleMode As Char
        Private strIssueYear As String

        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objDPeriodicalCollection As New clsDPeriodicalCollection

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        'IssueDate property
        Public Property IssueYear() As String
            Get
                Return (strIssueYear)
            End Get
            Set(ByVal Value As String)
                strIssueYear = Value
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

        'ClaimCycleMode  property
        Public Property ClaimCycleMode() As Char
            Get
                Return (chrClaimCycleMode)
            End Get
            Set(ByVal Value As Char)
                chrClaimCycleMode = Value
            End Set
        End Property

        'Flage property
        Public Property SelectMode() As Char
            Get
                Return (chrSelectMode)
            End Get
            Set(ByVal Value As Char)
                chrSelectMode = Value
            End Set
        End Property

        'get/set VendorID property
        Public Property VendorID() As Integer
            Get
                Return (intVendorID)
            End Get
            Set(ByVal Value As Integer)
                intVendorID = Value
            End Set
        End Property

        'get/set FromDate as string
        Public Property FromDate() As String
            Get
                Return (strFromDate)
            End Get
            Set(ByVal Value As String)
                strFromDate = Value
            End Set
        End Property

        'get/set Todate as string
        Public Property ToDate() As String
            Get
                Return (strToDate)
            End Get
            Set(ByVal Value As String)
                strToDate = Value
            End Set
        End Property

        ' arrData property 
        Public Property arrData() As Object
            Get
                Return objarrData
            End Get
            Set(ByVal Value As Object)
                objarrData = Value
            End Set
        End Property

        ' arrLabel property 
        Public Property arrLabel() As Object
            Get
                Return objarrLabel
            End Get
            Set(ByVal Value As Object)
                objarrLabel = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Initialize method
        Public Overloads Sub Initialize()
            ' Init MyBase object
            MyBase.DBServer = strDBServer
            MyBase.ConnectionString = strConnectionString
            MyBase.InterfaceLanguage = strInterfaceLanguage
            Call MyBase.Initialize()

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

            ' Init objDPeriodicalCollection object
            objDPeriodicalCollection.DBServer = strDBServer
            objDPeriodicalCollection.ConnectionString = strConnectionString
            Call objDPeriodicalCollection.Initialize()
        End Sub

        ' FilterPeriodicalForReceive method
        ' Purpose: Filter Periodicals For Receive
        ' Input: LocationID, IssuedDate
        ' Output: datatable result
        Public Function FilterPeriodicalForReceive(ByVal intLocationID As Integer, ByVal strIssuedDate As String, Optional ByVal strReceivedDate As String = "") As DataTable
            Try
                strIssuedDate = objBCDBS.ConvertDateBack(strIssuedDate)
                strReceivedDate = objBCDBS.ConvertDateBack(strReceivedDate)
                FilterPeriodicalForReceive = objBCDBS.SortTable(objBCDBS.ConvertTable(objDPeriodicalCollection.FilterPeriodicalForReceive(intLocationID, strIssuedDate, strReceivedDate), "TITLE", False), "TITLE")
                intErrorCode = objDPeriodicalCollection.ErrorCode
                strErrorMsg = objDPeriodicalCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' FilterPeriodicalForRegister method
        ' Purpose: Filter Periodicals For Register
        ' Input: RegisterDate, PubCoutry, PubLanguage, RegularityCode
        ' Output: datatable result
        Public Function FilterPeriodicalForRegister(ByVal strRegisterDate As String, ByVal strPubCountry As String, ByVal strPubLanguage As String, ByVal chrRegularityCode As String, ByVal strViewCode As String) As DataTable
            Try
                objDPeriodicalCollection.LibID = intLibID
                strRegisterDate = objBCDBS.ConvertDateBack(strRegisterDate)
                FilterPeriodicalForRegister = objBCDBS.SortTable(objBCDBS.ConvertTable(objDPeriodicalCollection.FilterPeriodicalForRegister(strRegisterDate, Trim(objBCSP.ConvertItBack(strPubCountry)), Trim(objBCSP.ConvertItBack(strPubLanguage)), chrRegularityCode, Trim(objBCSP.ConvertItBack(strViewCode))), "TITLE", False), "TITLE")
                intErrorCode = objDPeriodicalCollection.ErrorCode
                strErrorMsg = objDPeriodicalCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetReportDetailInfor method
        ' Purpose:  View detail infor Items when create link from statistic
        Public Function GetReportDetailInfor(ByVal strCatagory As String, ByVal strGenclassification As String, ByVal strLocation As String, ByVal strFreq As String, ByVal strLanguage As String, ByVal strCountry As String) As DataTable
            Try
                GetReportDetailInfor = objBCDBS.SortTable(objBCDBS.ConvertTable(objDPeriodicalCollection.GetReportDetailInfor(strCatagory, strGenclassification, strLocation, strFreq, strLanguage, strCountry), "Title"), "Title")
                intErrorCode = objDPeriodicalCollection.ErrorCode
                strErrorMsg = objDPeriodicalCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' StatByRegularity method
        ' Purpose: create statistic by regularity
        ' Output: datatable result
        Public Sub StatByRegularity(ByVal strNotIndication As String)
            Dim intRow As Integer = 0
            Dim intCount As Integer = 0
            Dim tblResult As DataTable

            Try
                objDPeriodicalCollection.LibID = intLibID
                tblResult = objBCDBS.ConvertTable(objDPeriodicalCollection.StatByRegularity)
                If Not tblResult Is Nothing Then
                    intCount = tblResult.Rows.Count
                    If intCount > 0 Then
                        ReDim arrData(intCount - 1)
                        ReDim arrLabel(intCount - 1)
                        For intRow = 0 To intCount - 1
                            arrData(intRow) = tblResult.Rows(intRow).Item("Total")
                            If tblResult.Rows(intRow).Item("Name").ToString = "" Then
                                arrLabel(intRow) = strNotIndication
                            Else
                                arrLabel(intRow) = tblResult.Rows(intRow).Item("Name")
                            End If
                        Next
                    End If
                    tblResult = Nothing
                End If
                intErrorCode = objDPeriodicalCollection.ErrorCode
                strErrorMsg = objDPeriodicalCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' StatByCountry method
        ' Purpose: create statistic by country
        ' Output: datatable result
        Public Sub StatByCountry(ByVal strNotIndicate As String)
            Dim intRow As Integer = 0
            Dim intCount As Integer = 0
            Dim tblResult As DataTable

            Try
                objDPeriodicalCollection.LibID = intLibID
                tblResult = objBCDBS.ConvertTable(objDPeriodicalCollection.StatByCountry)
                If Not tblResult Is Nothing Then
                    intCount = tblResult.Rows.Count
                    If intCount > 0 Then
                        ReDim arrData(intCount - 1)
                        ReDim arrLabel(intCount - 1)
                        For intRow = 0 To intCount - 1
                            arrData(intRow) = tblResult.Rows(intRow).Item("Total")
                            If tblResult.Rows(intRow).Item("Name").ToString = "" Then
                                arrLabel(intRow) = strNotIndicate
                            Else
                                arrLabel(intRow) = tblResult.Rows(intRow).Item("Name")
                            End If

                        Next
                    End If
                    tblResult = Nothing
                End If
                intErrorCode = objDPeriodicalCollection.ErrorCode
                strErrorMsg = objDPeriodicalCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' StatByLanguage method
        ' Purpose: create statistic by language
        ' Output: datatable result
        Public Sub StatByLanguage()
            Dim intRow As Integer = 0
            Dim intCount As Integer = 0
            Dim tblResult As DataTable

            Try
                objDPeriodicalCollection.LibID = intLibID
                tblResult = objBCDBS.ConvertTable(objDPeriodicalCollection.StatByLanguage)
                If Not tblResult Is Nothing Then
                    intCount = tblResult.Rows.Count
                    If intCount > 0 Then
                        ReDim arrData(intCount - 1)
                        ReDim arrLabel(intCount - 1)
                        For intRow = 0 To intCount - 1
                            arrData(intRow) = tblResult.Rows(intRow).Item("Total")
                            arrLabel(intRow) = tblResult.Rows(intRow).Item("Name")
                        Next
                    End If
                    tblResult = Nothing
                End If
                intErrorCode = objDPeriodicalCollection.ErrorCode
                strErrorMsg = objDPeriodicalCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' StatByCategory method
        ' Purpose: create statistic by category
        ' Output: datatable result
        Public Sub StatByCategory()
            Dim intRow As Integer = 0
            Dim intCount As Integer = 0
            Dim tblResult As DataTable

            Try
                objDPeriodicalCollection.LibID = intLibID
                tblResult = objBCDBS.ConvertTable(objDPeriodicalCollection.StatByCategory)
                If Not tblResult Is Nothing Then
                    intCount = tblResult.Rows.Count
                    If intCount > 0 Then
                        ReDim arrData(intCount - 1)
                        ReDim arrLabel(intCount - 1)
                        For intRow = 0 To intCount - 1
                            arrData(intRow) = tblResult.Rows(intRow).Item("Total")
                            arrLabel(intRow) = tblResult.Rows(intRow).Item("Name")
                        Next
                    End If
                    tblResult = Nothing
                End If
                intErrorCode = objDPeriodicalCollection.ErrorCode
                strErrorMsg = objDPeriodicalCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' StatByLocation method
        ' Purpose: create statistic by category
        ' Input: some infor of LibID, LocationID
        ' Output: datatable result
        Public Sub StatByLocation()
            Dim intRow As Integer = 0
            Dim intCount As Integer = 0
            Dim tblResult As DataTable

            Try
                objDPeriodicalCollection.LibID = intLibID
                tblResult = objBCDBS.ConvertTable(objDPeriodicalCollection.StatByLocation)
                If Not tblResult Is Nothing Then
                    intCount = tblResult.Rows.Count
                    If intCount > 0 Then
                        ReDim arrData(intCount - 1)
                        ReDim arrLabel(intCount - 1)
                        For intRow = 0 To intCount - 1
                            arrData(intRow) = tblResult.Rows(intRow).Item("Total")
                            arrLabel(intRow) = tblResult.Rows(intRow).Item("Name")
                        Next
                    End If
                    tblResult = Nothing
                End If
                intErrorCode = objDPeriodicalCollection.ErrorCode
                strErrorMsg = objDPeriodicalCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' StatByTop20 method
        ' Purpose: create statistic by top20 infor
        ' Input: 
        ' Output: datatable result
        Public Sub StatByTop20(ByVal intID As Integer)
            Dim intRow As Integer = 0
            Dim intCount As Integer = 0
            Dim tblResult As DataTable

            Try
                objDPeriodicalCollection.LibID = intLibID
                tblResult = objBCDBS.ConvertTable(objDPeriodicalCollection.StatByTop20(intID))
                If Not tblResult Is Nothing Then
                    intCount = tblResult.Rows.Count
                    If intCount > 0 Then
                        ReDim arrData(intCount - 1)
                        ReDim arrLabel(intCount - 1)
                        For intRow = 0 To intCount - 1
                            arrData(intRow) = tblResult.Rows(intRow).Item("Total")
                            arrLabel(intRow) = tblResult.Rows(intRow).Item("Name")
                        Next
                    End If
                    tblResult = Nothing
                End If
                intErrorCode = objDPeriodicalCollection.ErrorCode
                strErrorMsg = objDPeriodicalCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' StatByGeneralClassification method
        ' Purpose: create statistic by general classification
        ' Output: datatable result
        Public Sub StatByGenClassification()
            Dim intRow As Integer = 0
            Dim intCount As Integer = 0
            Dim tblResult As DataTable

            Try
                tblResult = objBCDBS.ConvertTable(objDPeriodicalCollection.StatByGenClassification)
                If Not tblResult Is Nothing Then
                    intCount = tblResult.Rows.Count
                    If intCount > 0 Then
                        ReDim arrData(intCount - 1)
                        ReDim arrLabel(intCount - 1)
                        For intRow = 0 To intCount - 1
                            arrData(intRow) = tblResult.Rows(intRow).Item("Total")
                            arrLabel(intRow) = tblResult.Rows(intRow).Item("Name")
                        Next
                    End If
                    tblResult = Nothing
                End If
                intErrorCode = objDPeriodicalCollection.ErrorCode
                strErrorMsg = objDPeriodicalCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' StatByGeneralClassification method
        ' Purpose: create statistic by general classification
        ' Output: datatable result
        Public Sub StatByClassification(ByVal strInput As String)
            Dim intRow As Integer = 0
            Dim intCount As Integer = 0
            Dim tblResult As DataTable

            Try
                objDPeriodicalCollection.LibID = intLibID
                tblResult = objBCDBS.ConvertTable(objDPeriodicalCollection.StatByClassification(strInput))
                If Not tblResult Is Nothing Then
                    intCount = tblResult.Rows.Count
                    If intCount > 0 Then
                        ReDim arrData(intCount - 1)
                        ReDim arrLabel(intCount - 1)
                        For intRow = 0 To intCount - 1
                            arrData(intRow) = tblResult.Rows(intRow).Item("Total")
                            arrLabel(intRow) = tblResult.Rows(intRow).Item("Name")
                        Next
                    End If
                    tblResult = Nothing
                End If
                intErrorCode = objDPeriodicalCollection.ErrorCode
                strErrorMsg = objDPeriodicalCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' GetTotalExpried method
        ' Purpose: Get total expried 
        ' Output: datatable result
        Public Function GetTotalExpired() As DataTable
            Try
                GetTotalExpired = objBCDBS.ConvertTable(objDPeriodicalCollection.GetTotalExpired)
                intErrorCode = objDPeriodicalCollection.ErrorCode
                strErrorMsg = objDPeriodicalCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' CreateReportByAcqSourceStatus method
        ' Purpose: create report by Acquire Source and Status
        ' Output: datatable result
        Public Function CreateReportByAcqSourceStatus() As DataTable
            Try
                CreateReportByAcqSourceStatus = objBCDBS.ConvertTable(objDPeriodicalCollection.CreateReportByAcqSourceStatus)
                intErrorCode = objDPeriodicalCollection.ErrorCode
                strErrorMsg = objDPeriodicalCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetTotalIssue method
        ' Purpose: Get total ReceivedCopies and VolumeByLibrary
        ' Output: datatable result
        Public Sub GetTotalIssue(ByRef intTotalID As Integer, ByRef intTotalReceivedCopies As Integer, ByRef intTotalVolumeByLibrary As Integer)
            Try
                objDPeriodicalCollection.GetTotalIssue(intTotalID, intTotalReceivedCopies, intTotalVolumeByLibrary)
                intErrorCode = objDPeriodicalCollection.ErrorCode
                strErrorMsg = objDPeriodicalCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' GetgenIssueItem method
        ' Purpose: Get information genarate of Issue and Item
        ' Output: datatable result
        Public Function GetGenIssueItem(ByVal intAcqSourceID As Integer, ByVal intOnSubscription As Integer) As DataTable
            Try
                GetGenIssueItem = objBCDBS.SortTable(objBCDBS.ConvertTable(objDPeriodicalCollection.GetGenIssueItem(intAcqSourceID, intOnSubscription), "TITLE,ISSN"), "TITLE")
                intErrorCode = objDPeriodicalCollection.ErrorCode
                strErrorMsg = objDPeriodicalCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetGenExpriedItem method
        ' Purpose: Get information genarate of expried Item
        ' Output: datatable result
        Public Function GetGenExpriedItem() As DataTable
            Try
                GetGenExpriedItem = objBCDBS.ConvertTable(objDPeriodicalCollection.GetGenExpriedItem, "TITLE")
                intErrorCode = objDPeriodicalCollection.ErrorCode
                strErrorMsg = objDPeriodicalCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' CreateGeneralReport method
        ' Purpose: create general report
        ' Output: datatable result
        Public Function CreateGeneralReport() As DataTable
            Try
                intErrorCode = objDPeriodicalCollection.ErrorCode
                strErrorMsg = objDPeriodicalCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' CreateReportByAcqSource method
        ' Purpose: create report by Acquire Source
        ' Output: datatable result
        Public Function CreateReportByAcqSource() As DataTable
            Try
                intErrorCode = objDPeriodicalCollection.ErrorCode
                strErrorMsg = objDPeriodicalCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetAnnualSummaryHolding method
        ' Purpose: Get Annual SummaryHolding
        ' Output: datatable result
        Public Function GetAnnualSummaryHolding(ByVal strIDs As String, ByVal intyears As Integer) As DataTable
            Try
                GetAnnualSummaryHolding = objBCDBS.SortTable(objBCDBS.ConvertTable(objDPeriodicalCollection.GetAnnualSummaryHolding(strIDs, intyears), "Content"), "Content")
                intErrorCode = objDPeriodicalCollection.ErrorCode
                strErrorMsg = objDPeriodicalCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetClaimIssueList method
        ' In: VendorID, FromDate, ToDate
        ' Purpose: Get claim issues
        ' Output: datatable result
        Public Function GetClaimIssueList() As DataTable
            Dim intIndex As Integer
            Dim tblCIList As DataTable

            Try
                objDPeriodicalCollection.VendorID = intVendorID
                objDPeriodicalCollection.FromDate = objBCDBS.ConvertDateBack(strFromDate, False)
                objDPeriodicalCollection.ToDate = objBCDBS.ConvertDateBack(strToDate, False)
                tblCIList = objBCDBS.ConvertTable(objDPeriodicalCollection.GetClaimIssueList, "Content")
                If Not tblCIList Is Nothing Then
                    If tblCIList.Rows.Count > 0 Then
                        For intIndex = 0 To tblCIList.Rows.Count - 1
                            tblCIList.Rows(intIndex).Item("STT") = intIndex + 1
                        Next
                    End If
                    GetClaimIssueList = tblCIList
                End If
                intErrorCode = objDPeriodicalCollection.ErrorCode
                strErrorMsg = objDPeriodicalCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GenReportByRangeTime() As DataTable
            objDPeriodicalCollection.FromDate = objBCDBS.ConvertDateBack(strFromDate, False)
            objDPeriodicalCollection.ToDate = objBCDBS.ConvertDateBack(strToDate, False)
            GenReportByRangeTime = objBCDBS.SortTable(objBCDBS.ConvertTable(objDPeriodicalCollection.GenReportByRangeTime("CONTENTSTOSORT", 0), "Content"), "Content")
            intErrorCode = objDPeriodicalCollection.ErrorCode
            strErrorMsg = objDPeriodicalCollection.ErrorMsg
        End Function

        Public Function GenReportByRangeTime(ByVal strPrefix As String, ByVal strPickIt As String) As DataTable
            Dim tblItemID As New DataTable
            Dim tblData As New DataTable
            Dim tblItemSort As New DataTable
            Dim tblContents As New DataTable
            Dim tblVol As New DataTable
            Dim tblTemp As New DataTable
            Dim tblDataReturn As New DataTable
            Dim dtrows() As DataRow
            Dim dtrow As DataRow
            Dim dtrowAdd As DataRow
            'Dim objSort As New TVCOMLib.utf8
            Dim inti As Integer
            Dim intj As Integer
            Dim intk As Integer
            Dim intResetRegularity As Integer
            Dim strMaxDay As String
            Dim arrContents() As String
            Dim arrItemIDs() As String
            Dim ArrIndex()
            'Dim ArrSortedKey()
            Dim intNOR As Integer

            ' Init some default value
            ReDim arrContents(-1)
            ReDim arrItemIDs(-1)
            intResetRegularity = 0
            ' Get content and ItemID to sort
            objDPeriodicalCollection.FromDate = objBCDBS.ConvertDateBack(strFromDate, False)
            objDPeriodicalCollection.ToDate = objBCDBS.ConvertDateBack(strToDate, False)
            tblItemSort = objBCDBS.ConvertTable(objDPeriodicalCollection.GenReportByRangeTime("CONTENTSTOSORT", 0), "Content")

            strErrorMsg = objDPeriodicalCollection.ErrorMsg
            intErrorCode = objDPeriodicalCollection.ErrorCode
            If Not tblItemSort Is Nothing Then
                intNOR = tblItemSort.Rows.Count
                If intNOR > 0 Then
                    ReDim Preserve arrContents(intNOR)
                    ReDim Preserve arrItemIDs(intNOR)
                    For inti = 0 To intNOR - 1
                        arrContents(inti) = tblItemSort.Rows(inti).Item("Content")
                        arrItemIDs(inti) = tblItemSort.Rows(inti).Item("ItemID")
                    Next
                    ' Sort result
                    'ArrIndex = objSort.SortIndex(arrContents, 1)
                    'ArrSortedKey = objBCSP.SortByIndex(arrItemIDs, ArrIndex)
                    'ArrSortedKey = arrItemIDs
                End If
            End If

            tblTemp = Nothing
            If UBound(arrContents) > 0 Then
                ' Table return have 5 columns
                tblDataReturn.Columns.Add("Sequency", Type.GetType("System.String"))
                tblDataReturn.Columns.Add("Content", Type.GetType("System.String"))
                tblDataReturn.Columns.Add("IssueHave", Type.GetType("System.String"))
                tblDataReturn.Columns.Add("MaxDay", Type.GetType("System.String"))
                tblDataReturn.Columns.Add("PickIt", Type.GetType("System.String"))
                For inti = LBound(arrItemIDs) To UBound(arrItemIDs) - 1
                    Try
                        dtrowAdd = tblDataReturn.NewRow
                        ' Bind sequency
                        dtrowAdd(0) = CStr(inti + 1)
                        ' Bind content
                        'dtrowAdd(1) = "<A HREF=""javascript:LoadForm(" & arrItemIDs(inti) & ")"">" & arrContents(inti) & "</A>"
                        dtrowAdd(1) = arrContents(inti)

                        ' Get ResetRegularity ( Recount )
                        intResetRegularity = 0
                        tblTemp = objDPeriodicalCollection.GenReportByRangeTime("RESETREGULARITY", arrItemIDs(inti))
                        strErrorMsg = objDPeriodicalCollection.ErrorMsg
                        intErrorCode = objDPeriodicalCollection.ErrorCode
                        If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                            Select Case UCase(strDBServer)
                                Case "ORACLE"
                                    intResetRegularity = CInt(tblTemp.Rows(0).Item("RESETREGULARITY"))
                                Case Else
                                    intResetRegularity = CInt(tblTemp.Rows(0).Item("ResetRegularity"))
                            End Select
                        End If
                        ' Get data display
                        tblData = objBCDBS.ConvertTable(objDPeriodicalCollection.GenReportByRangeTime("DATA", arrItemIDs(inti)))
                        strErrorMsg = objDPeriodicalCollection.ErrorMsg
                        intErrorCode = objDPeriodicalCollection.ErrorCode

                        ' Get dictinct Vollume
                        tblVol = objBCDBS.ConvertTable(objDPeriodicalCollection.GenReportByRangeTime("VOLUME", arrItemIDs(inti)))
                        strErrorMsg = objDPeriodicalCollection.ErrorMsg
                        intErrorCode = objDPeriodicalCollection.ErrorCode

                        ' Get max recieved day
                        strMaxDay = objBCDBS.ConvertTable(objDPeriodicalCollection.GenReportByRangeTime("MAXDAY", arrItemIDs(inti))).Rows(0).Item("MAXDAY")
                        strErrorMsg = objDPeriodicalCollection.ErrorMsg
                        intErrorCode = objDPeriodicalCollection.ErrorCode

                        ' Bind issue have
                        dtrowAdd(2) = ""
                        ' Year recount or not recount
                        If intResetRegularity <> 1 Then
                            ' Issue have
                            For intj = 0 To tblVol.Rows.Count - 1
                                dtrowAdd(2) = dtrowAdd(2) & "<B>" & tblVol.Rows(intj).Item("VolumeByPublisher") & "</B>: "
                                ' Filter data
                                dtrows = Nothing
                                dtrows = tblData.Select("VolumeByPublisher='" & tblVol.Rows(intj).Item("VolumeByPublisher") & "'")
                                If Not dtrows Is Nothing Then
                                    If dtrows.Length > 0 Then
                                        For intk = 0 To dtrows.Length - 1
                                            If intk = dtrows.Length - 1 Then
                                                dtrowAdd(2) = dtrowAdd(2) & dtrows(intk).Item("IssueNo") & "."
                                            Else
                                                dtrowAdd(2) = dtrowAdd(2) & dtrows(intk).Item("IssueNo") & ", "
                                            End If
                                        Next
                                    End If
                                End If
                            Next
                        Else ' Month recount
                            For intj = 1 To 12
                                If Not tblData Is Nothing Then
                                    For intk = 0 To tblVol.Rows.Count - 1
                                        dtrowAdd(2) = dtrowAdd(2) & "<BR><B>" & strPrefix & intj & "</B>" & tblVol.Rows(intk).Item("VolumeByPublisher") & ": "
                                        dtrows = Nothing
                                        dtrows = tblData.Select("VolumeByPublisher='" & tblVol.Rows(intk).Item("VolumeByPublisher") & "' AND Month=" & intk)
                                        If Not dtrows Is Nothing Then
                                            For Each dtrow In dtrows
                                                dtrowAdd(2) = dtrowAdd(2) & dtrow.Item("IssueNo") & ", "
                                            Next
                                        End If
                                    Next
                                End If
                            Next
                        End If

                        ' Bind max day
                        dtrowAdd(3) = strMaxDay

                        ' Pick this item for current item
                        dtrowAdd(4) = "<A HREF=""javascript:LoadForm(" & arrItemIDs(inti) & ")""><B>" & strPickIt & "</B></A>"
                        ' Bind to datatable
                        tblDataReturn.Rows.Add(dtrowAdd)
                    Catch ex As Exception
                        strErrorMsg = ex.Message
                    End Try
                Next
            Else
                tblDataReturn = Nothing
            End If
            GenReportByRangeTime = tblDataReturn
            'objSort = Nothing
        End Function

        ' GetIssueForClaim method
        ' Purpose: Get Issue for claim
        ' Output: datatable result
        Public Function GetIssueForClaim() As DataTable
            Dim tblUnReceivedIssues As DataTable
            Dim tblItems As New DataTable
            Dim lngCurMag As Long
            Dim intIndex1 As Integer
            Dim intRow As Integer
            Dim dtrow As DataRow

            Try
                objDPeriodicalCollection.SelectMode = chrSelectMode
                objDPeriodicalCollection.ClaimCycleMode = chrClaimCycleMode
                objDPeriodicalCollection.IssueYear = strIssueYear
                objDPeriodicalCollection.IDs = ""
                objDPeriodicalCollection.LibID = intLibID
                tblUnReceivedIssues = objBCDBS.ConvertTable(objDPeriodicalCollection.GetIssueForClaim, "Content")

                If Not tblUnReceivedIssues Is Nothing Then
                    intIndex1 = 0
                    intRow = -1
                    tblItems.Columns.Add("ItemID", Type.GetType("System.String"))
                    tblItems.Columns.Add("IssueNo", Type.GetType("System.String"))
                    tblItems.Columns.Add("Content", Type.GetType("System.String"))
                    If tblUnReceivedIssues.Rows.Count > 0 Then
                        lngCurMag = 0
                        For intIndex1 = 0 To tblUnReceivedIssues.Rows.Count - 1
                            If Not lngCurMag = tblUnReceivedIssues.Rows(intIndex1).Item("ItemID") Then
                                dtrow = tblItems.NewRow
                                lngCurMag = CLng(tblUnReceivedIssues.Rows(intIndex1).Item("ItemID"))
                                dtrow(0) = CStr(tblUnReceivedIssues.Rows(intIndex1).Item("ItemID"))
                                dtrow(1) = CStr(tblUnReceivedIssues.Rows(intIndex1).Item("IssueNo")) & ","
                                dtrow(2) = CStr(tblUnReceivedIssues.Rows(intIndex1).Item("Content"))
                                tblItems.Rows.Add(dtrow)
                                intRow = intRow + 1
                            Else
                                tblItems.Rows(intRow).Item("IssueNo") = tblItems.Rows(intRow).Item("IssueNo") & tblUnReceivedIssues.Rows(intIndex1).Item("IssueNo") & ","
                            End If
                        Next
                    End If
                    Return (tblItems)
                Else
                    Return (Nothing)
                End If
                ErrorCode = objDPeriodicalCollection.ErrorCode
                ErrorMsg = objDPeriodicalCollection.ErrorMsg
            Catch ex As Exception
                strerrormsg = ex.Message
            Finally
                tblUnReceivedIssues = Nothing
                tblItems = Nothing
            End Try
        End Function

        Public Function GetLastReceivedDate(ByVal lngItemID As Long) As DataTable
            Try
                GetLastReceivedDate = objBCDBS.ConvertTable(objDPeriodicalCollection.GetLastReceivedDate(lngItemID))
                ErrorCode = objDPeriodicalCollection.ErrorCode
                ErrorMsg = objDPeriodicalCollection.ErrorMsg
            Catch ex As Exception
                strerrormsg = ex.Message
            End Try
        End Function

        ' Dispose method
        ' Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCSP Is Nothing Then
                    Call objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    Call objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objDPeriodicalCollection Is Nothing Then
                    objDPeriodicalCollection.Dispose(True)
                    objDPeriodicalCollection = Nothing
                End If
            Finally
                Call MyBase.Dispose(True)
                Call Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace