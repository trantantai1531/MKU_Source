Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess
Imports eMicLibAdmin.DataAccess.Edeliv

Namespace eMicLibAdmin.BusinessRules.Edeliv
    Public Class clsBERequestCollection
        Inherits clsBERequest

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Private strCustomerName As String = ""
        Private strNameOfFile As String = ""
        Private dblPriceOfFile As Double = 0
        Private dblPriceOfFileFrom As Double = 0
        Private dblPriceOfFileTo As Double = 0
        Private intTimeMode As Integer = 0
        'Private intStatusID As Integer = 0
        Private strRequestIDs As String = ""
        Private strTimeFrom As String = ""
        Private strTimeTo As String = ""
        Private lngTopNum As Long = 0
        Private strSort As String = ""
        Private objarrData As Object
        Private objarrLabel As Object
        Private objarrDataPie As Object
        Private objarrLabelPie As Object

        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objDRequestCollection As New clsDRequestCollection

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************

        ' CustomerName property
        Public Property CustomerName() As String
            Get
                Return strCustomerName
            End Get
            Set(ByVal Value As String)
                strCustomerName = Value
            End Set
        End Property

        ' NameOfFile property
        Public Property NameOfFile() As String
            Get
                Return strNameOfFile
            End Get
            Set(ByVal Value As String)
                strNameOfFile = Value
            End Set
        End Property

        ' PriceOfFile property
        Public Property PriceOfFile() As Double
            Get
                Return dblPriceOfFile
            End Get
            Set(ByVal Value As Double)
                dblPriceOfFile = Value
            End Set
        End Property

        ' PriceOfFileFrom property
        Public Property PriceOfFileFrom() As Double
            Get
                Return dblPriceOfFileFrom
            End Get
            Set(ByVal Value As Double)
                dblPriceOfFileFrom = Value
            End Set
        End Property

        ' PriceOfFile property
        Public Property PriceOfFileTo() As Double
            Get
                Return dblPriceOfFileTo
            End Get
            Set(ByVal Value As Double)
                dblPriceOfFileTo = Value
            End Set
        End Property

        ' TimeMode property
        Public Property TimeMode() As Integer
            Get
                Return intTimeMode
            End Get
            Set(ByVal Value As Integer)
                intTimeMode = Value
            End Set
        End Property

        ' StatusID property
        'Public Property StatusID() As Integer
        '    Get
        '        Return intStatusID
        '    End Get
        '    Set(ByVal Value As Integer)
        '        intStatusID = Value
        '    End Set
        'End Property

        ' RequestIDs property
        Public Property RequestIDs() As String
            Get
                Return strRequestIDs
            End Get
            Set(ByVal Value As String)
                strRequestIDs = Value
            End Set
        End Property

        ' TimeFrom property
        Public Property TimeFrom() As String
            Get
                Return strTimeFrom
            End Get
            Set(ByVal Value As String)
                strTimeFrom = Value
            End Set
        End Property

        ' TimeTo property
        Public Property TimeTo() As String
            Get
                Return strTimeTo
            End Get
            Set(ByVal Value As String)
                strTimeTo = Value
            End Set
        End Property

        ' TopNum property
        Public Property TopNum() As Long
            Get
                Return lngTopNum
            End Get
            Set(ByVal Value As Long)
                lngTopNum = Value
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

        ' arrData pie  property 
        Public Property arrDataPie() As Object
            Get
                Return objarrDataPie
            End Get
            Set(ByVal Value As Object)
                objarrDataPie = Value
            End Set
        End Property

        ' arrLabel pie property
        Public Property arrLabelPie() As Object
            Get
                Return objarrLabelPie
            End Get
            Set(ByVal Value As Object)
                objarrLabelPie = Value
            End Set
        End Property

        ' Sort property 
        Public Property Sort() As String
            Get
                Sort = strSort
            End Get
            Set(ByVal Value As String)
                strSort = Value
            End Set
        End Property

        ' *************************************************************************************************
        ' End declare public properties
        ' Implement methods here
        ' *************************************************************************************************

        ' Initialize method
        Public Overloads Sub Initialize()
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

            ' Init objDRequestCollection object
            objDRequestCollection.DBServer = strDBServer
            objDRequestCollection.ConnectionString = strConnectionString
            Call objDRequestCollection.Initialize()

            ' Init base clase
            MyBase.DBServer = strDBServer
            MyBase.ConnectionString = strConnectionString
            MyBase.InterfaceLanguage = strInterfaceLanguage
            Call MyBase.Initialize()
        End Sub

        ' Filter method
        ' Purpose: Filter request list
        ' Input: some infor of request
        ' Output: datatable result
        Public Function Filter() As DataTable
            Try
                objDRequestCollection.CustomerName = Trim(objBCSP.ConvertItBack(strCustomerName))
                objDRequestCollection.NameOfFile = Trim(objBCSP.ConvertItBack(strNameOfFile))
                objDRequestCollection.PriceOfFileFrom = dblPriceOfFileFrom
                objDRequestCollection.PriceOfFileTo = dblPriceOfFileTo
                objDRequestCollection.SizeOfFileFrom = Trim(strSizeOfFileFrom)
                objDRequestCollection.SizeOfFileTo = Trim(strSizeOfFileTo)
                objDRequestCollection.TimeMode = intTimeMode
                objDRequestCollection.TimeFrom = objBCDBS.ConvertDateBack(Trim(strTimeFrom), False)
                objDRequestCollection.TimeTo = objBCDBS.ConvertDateBack(Trim(strTimeTo), False)

                Filter = objDRequestCollection.Filter
                intErrorCode = objDRequestCollection.ErrorCode
                strErrorMsg = objDRequestCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' CreateAnnualStat method
        ' Purpose: Create annual statistic
        ' Input: some infor
        ' Output: datatable result
        Public Function CreateAnnualStat(ByVal intType As Int16)
            Dim intRowIndex As Integer
            Dim intTotalRecords As Integer
            Dim tblData As DataTable
            Try
                arrData = Nothing
                arrLabel = Nothing
                tblData = objDRequestCollection.CreateAnnualStat(intType)
                intErrorCode = objDRequestCollection.ErrorCode
                strErrorMsg = objDRequestCollection.ErrorMsg
                Select Case intType
                    Case 0 ' Type 1
                        If Not tblData Is Nothing Then
                            If tblData.Rows.Count > 0 Then
                                intTotalRecords = tblData.Rows.Count
                                ReDim arrData(intTotalRecords - 1)
                                ReDim arrLabel(intTotalRecords - 1)
                                For intRowIndex = 0 To intTotalRecords - 1
                                    arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("TotalRequest")
                                    arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("Year")
                                Next
                            End If
                        End If
                    Case 1 ' Type 2
                        If Not tblData Is Nothing Then
                            If tblData.Rows.Count > 0 Then
                                intTotalRecords = tblData.Rows.Count
                                ReDim arrData(intTotalRecords - 1)
                                ReDim arrLabel(intTotalRecords - 1)
                                For intRowIndex = 0 To intTotalRecords - 1
                                    arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("TotalAmount")
                                    arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("Year")
                                Next
                            End If
                        End If
                    Case 2 ' Type 3
                        If Not tblData Is Nothing Then
                            If tblData.Rows.Count > 0 Then
                                intTotalRecords = tblData.Rows.Count
                                ReDim arrData(intTotalRecords - 1)
                                ReDim arrLabel(intTotalRecords - 1)
                                For intRowIndex = 0 To intTotalRecords - 1
                                    arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("TotalRequest")
                                    arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("Status")
                                Next
                            End If
                        End If
                End Select

            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetRequestedYears method
        ' Purpose: Get requested years
        ' Input: some infor
        ' Output: datatable result
        Public Function GetRequestedYears() As DataTable
            Try
                GetRequestedYears = objDRequestCollection.GetRequestedYears
                intErrorCode = objDRequestCollection.ErrorCode
                strErrorMsg = objDRequestCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetRequestedMonths method
        ' Purpose: Get requested month
        ' Input: some infor
        ' Output: datatable result
        Public Function GetRequestedMonths(Optional ByVal intYear As Integer = 0) As DataTable
            Try
                GetRequestedMonths = objDRequestCollection.GetRequestedMonths(intYear)
                intErrorCode = objDRequestCollection.ErrorCode
                strErrorMsg = objDRequestCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' CreateMonthlyStat method
        ' Purpose: Create monthly statistic
        ' Input: some infor
        ' Output: datatable result
        Public Function CreateMonthlyStat(ByVal intType As Int16, ByVal intYear As Integer, ByVal strTemp As String) As DataTable
            Dim intRowIndex As Integer
            Dim intTotalRecords As Integer
            Dim tblData As DataTable
            Try
                strTemp = objBCSP.ConvertItBack(strTemp)
                tblData = objDRequestCollection.CreateMonthlyStat(intType, intYear, strTemp)
                strErrorMsg = objDRequestCollection.ErrorMsg
                intErrorCode = objDRequestCollection.ErrorCode
                arrData = Nothing
                arrLabel = Nothing
                arrDataPie = Nothing
                arrLabelPie = Nothing
                Select Case intType
                    Case 0 ' Type 1
                        If Not tblData Is Nothing AndAlso tblData.Rows.Count > 0 Then
                            intTotalRecords = tblData.Rows.Count
                            ReDim arrData(intTotalRecords - 1)
                            ReDim arrLabel(intTotalRecords - 1)
                            ReDim arrDataPie(intTotalRecords - 1)
                            ReDim arrLabelPie(intTotalRecords - 1)
                            For intRowIndex = 0 To intTotalRecords - 1
                                arrDataPie(intRowIndex) = tblData.Rows(intRowIndex).Item("TotalRequest")
                                arrLabelPie(intRowIndex) = tblData.Rows(intRowIndex).Item("Month")
                                arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("TotalRequest")
                                arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("MonthDisplay")
                            Next
                        End If
                    Case 1 ' Type 2
                        If Not tblData Is Nothing AndAlso tblData.Rows.Count > 0 Then
                            intTotalRecords = tblData.Rows.Count
                            ReDim arrData(intTotalRecords - 1)
                            ReDim arrLabel(intTotalRecords - 1)
                            ReDim arrDataPie(intTotalRecords - 1)
                            ReDim arrLabelPie(intTotalRecords - 1)
                            For intRowIndex = 0 To intTotalRecords - 1
                                arrDataPie(intRowIndex) = tblData.Rows(intRowIndex).Item("TotalAmount")
                                arrLabelPie(intRowIndex) = tblData.Rows(intRowIndex).Item("Month")
                                arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("TotalAmount")
                                arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("MonthDisplay")
                            Next
                        End If
                    Case 2 ' Type 3
                        If Not tblData Is Nothing Then
                            If tblData.Rows.Count > 0 Then
                                intTotalRecords = tblData.Rows.Count
                                ReDim arrData(intTotalRecords - 1)
                                ReDim arrLabel(intTotalRecords - 1)
                                For intRowIndex = 0 To intTotalRecords - 1
                                    arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("TotalRequest")
                                    arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("Status")
                                Next
                            End If
                        End If
                End Select
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' CreateDailyStat method
        ' Purpose: Create daily statistic
        ' Input: some infor
        ' Output: datatable result
        Public Function CreateDailyStat(ByVal intType As Int16, ByVal intYear As Integer, ByVal intMonth As Integer, ByVal strTemp As String) As DataTable
            Dim intRowIndex As Integer
            Dim intTotalRecords As Integer
            Dim tblData As DataTable
            arrData = Nothing
            arrLabel = Nothing
            arrDataPie = Nothing
            arrLabelPie = Nothing
            Try
                strTemp = objBCSP.ConvertItBack(strTemp)
                tblData = objDRequestCollection.CreateDailyStat(intType, intYear, intMonth, strTemp)
                strErrorMsg = objDRequestCollection.ErrorMsg
                intErrorCode = objDRequestCollection.ErrorCode
                Select Case intType
                    Case 0 ' Type 1
                        If Not tblData Is Nothing AndAlso tblData.Rows.Count > 0 Then
                            intTotalRecords = tblData.Rows.Count
                            ReDim arrData(intTotalRecords - 1)
                            ReDim arrLabel(intTotalRecords - 1)
                            ReDim arrDataPie(intTotalRecords - 1)
                            ReDim arrLabelPie(intTotalRecords - 1)
                            For intRowIndex = 0 To intTotalRecords - 1
                                ' Pie chart
                                arrDataPie(intRowIndex) = tblData.Rows(intRowIndex).Item("TotalRequest")
                                arrLabelPie(intRowIndex) = tblData.Rows(intRowIndex).Item("Day")
                                ' Bar chart
                                arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("TotalRequest")
                                arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("DayDisplay")
                            Next
                        End If
                    Case 1 ' Type 2
                        If Not tblData Is Nothing AndAlso tblData.Rows.Count > 0 Then
                            intTotalRecords = tblData.Rows.Count
                            ReDim arrData(intTotalRecords - 1)
                            ReDim arrLabel(intTotalRecords - 1)
                            ReDim arrDataPie(intTotalRecords - 1)
                            ReDim arrLabelPie(intTotalRecords - 1)
                            For intRowIndex = 0 To intTotalRecords - 1
                                ' Pie chart
                                arrDataPie(intRowIndex) = tblData.Rows(intRowIndex).Item("TotalAmount")
                                arrLabelPie(intRowIndex) = tblData.Rows(intRowIndex).Item("Day")
                                ' Bar chart
                                arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("TotalAmount")
                                arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("DayDisplay")
                            Next
                        End If
                    Case 2 ' Type 3
                        If Not tblData Is Nothing AndAlso tblData.Rows.Count > 0 Then
                            intTotalRecords = tblData.Rows.Count
                            ReDim arrData(intTotalRecords - 1)
                            ReDim arrLabel(intTotalRecords - 1)
                            For intRowIndex = 0 To intTotalRecords - 1
                                ' Pie chart + Bar chart
                                arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("TotalRequest")
                                arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("Status")
                            Next
                        End If
                End Select
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' CreateTopCustomersStat method
        ' Purpose: Create top customer statistic
        ' Input: some infor
        ' Output: datatable result
        Public Function CreateTopCustomersStat(ByVal lngMinTurn As Long) As DataTable
            Dim intRowIndex As Integer
            Dim intTotalRecords As Integer
            Dim tblData As DataTable
            Try
                arrData = Nothing
                arrLabel = Nothing
                objDRequestCollection.TimeFrom = objBCDBS.ConvertDateBack(strTimeFrom, False)
                objDRequestCollection.TimeTo = objBCDBS.ConvertDateBack(strTimeTo, False)
                objDRequestCollection.TopNum = lngTopNum
                tblData = objDRequestCollection.CreateTopCustomersStat(lngMinTurn)

                If Not tblData Is Nothing Then
                    If tblData.Rows.Count > 0 Then
                        intTotalRecords = tblData.Rows.Count
                        ReDim arrData(intTotalRecords - 1)
                        ReDim arrLabel(intTotalRecords - 1)
                        For intRowIndex = 0 To intTotalRecords - 1
                            arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("Total")
                            arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("UserName")
                        Next
                    End If
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try

        End Function

        ' CreateTop20Stat method
        ' Purpose: Create top20 statistic
        ' Input: some infor
        ' Output: datatable result
        Public Function CreateTop20Stat(ByVal intPropertyID As Integer) As DataTable
            Dim intRowIndex As Integer
            Dim intTotalRecords As Integer
            Dim tblData As DataTable
            Try
                arrData = Nothing
                arrLabel = Nothing
                tblData = objDRequestCollection.CreateTop20Stat(intPropertyID)

                If Not tblData Is Nothing Then
                    If tblData.Rows.Count > 0 Then
                        intTotalRecords = tblData.Rows.Count
                        ReDim arrData(intTotalRecords - 1)
                        ReDim arrLabel(intTotalRecords - 1)
                        For intRowIndex = 0 To intTotalRecords - 1
                            arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("Total")
                            arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("Label")
                        Next
                    End If
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' CreateTopItemsStat method
        ' Purpose: Create top items statistic
        ' Input: some infor
        ' Output: datatable result
        Public Function CreateTopItemsStat(ByVal lngMinTurn As Long) As DataTable
            Dim intRowIndex As Integer
            Dim intTotalRecords As Integer
            Dim tblData As DataTable
            Try
                arrData = Nothing
                arrLabel = Nothing
                objDRequestCollection.TimeFrom = objBCDBS.ConvertDateBack(strTimeFrom, False)
                objDRequestCollection.TimeTo = objBCDBS.ConvertDateBack(strTimeTo, False)
                objDRequestCollection.TopNum = lngTopNum
                tblData = objDRequestCollection.CreateTopItemsStat(lngMinTurn)

                If Not tblData Is Nothing Then
                    If tblData.Rows.Count > 0 Then
                        intTotalRecords = tblData.Rows.Count
                        ReDim arrData(intTotalRecords - 1)
                        ReDim arrLabel(intTotalRecords - 1)
                        For intRowIndex = 0 To intTotalRecords - 1
                            arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("Total")
                            arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("ItemID")
                        Next
                    End If
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetERequestList method
        ' Purpose: Get request list
        ' Input: some infor of request
        ' Output: datatable result
        Public Function GetERequestList() As Object
            Dim TblRet As New DataView
            Dim tbl As New DataTable
            Try
                objDRequestCollection.StatusID = intStatusID
                objDRequestCollection.RequestIDs = Trim(strRequestIDs)
                tbl = objBCDBS.ConvertTable(objDRequestCollection.GetERequestList, "TITLE", True)

                If strSort.Length = 0 Then
                    GetERequestList = tbl
                ElseIf UCase(strSort) = "STATUS" Or UCase(strSort) = "EMODE" Then 'DataView de sort
                    Dim dv As New DataView(tbl)
                    dv.Sort = strSort
                    Return dv.Table
                ElseIf UCase(strSort) = "CREATEDDATE" Then
                    TblRet = objBCDBS.SortTable(tbl, "CREATEDDATE").DefaultView
                    Return TblRet.Table
                Else 'Sort bang Unicode                    
                    TblRet = objBCDBS.SortTable(tbl, "FILENAME").DefaultView
                    Return TblRet.Table
                End If

                intErrorCode = objDRequestCollection.ErrorCode
                strErrorMsg = objDRequestCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetERequestNum method
        ' Purpose: Get number of requests
        ' Input: topnumber 
        ' Output: datatable result
        Public Function GetERequestNum(ByRef lngTotalRec As Long, ByRef lngCurrentPos As Long) As DataTable
            Try
                objDRequestCollection.RequestID = lngRequestID
                objDRequestCollection.TopNum = lngTopNum
                GetERequestNum = objBCDBS.ConvertTable(objDRequestCollection.GetERequestNum(lngTotalRec, lngCurrentPos))
                intErrorCode = objDRequestCollection.ErrorCode
                strErrorMsg = objDRequestCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetERequestProcess
        ' Purpose: Get the request processing
        ' Output: datatable result
        Public Function GetERequestProcess(ByRef intNumOfReq As Integer) As DataTable
            Try
                GetERequestProcess = objDRequestCollection.GetERequestProcess(intNumOfReq)
                strErrorMsg = objDRequestCollection.ErrorMsg
                intErrorCode = objDRequestCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetCatDicList method
        ' Purpose: Get information of Catdiclist table
        ' Input: intID (optional default=0)
        ' Output: DataTable includes two field : Name, ID
        ' Creator: Lent
        Public Function GetCatDicList2Field(Optional ByVal intID As Integer = 0) As DataTable
            Try
                GetCatDicList2Field = objBCDBS.ConvertTable(objDRequestCollection.GetCatDicList2Field(intID))
                strErrorMsg = objDRequestCollection.ErrorMsg
                intErrorCode = objDRequestCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Dispose property
        ' Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objDRequestCollection Is Nothing Then
                    objDRequestCollection.Dispose(True)
                    objDRequestCollection = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace