Imports System
Imports System.Web
Imports System.Data
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.DataAccess.Circulation

Namespace eMicLibAdmin.BusinessRules.Circulation
    Public Class clsBLoanTransaction
        Inherits clsBBaseTransaction

        ' *****************************************************************************************************
        ' Declare member variables
        ' *****************************************************************************************************

        Private strCheckOutDate As String = ""
        Private strCheckInDate As String = ""
        Private strDueDate As String = ""
        Private strTimeOutDate As String = ""
        Private strRenewDate As String = ""
        Private strRecallDate As String = ""
        Private intLoanTypeID As Integer = 0
        Private intLoanMode As Int16 = 0


        Private objBCDBS As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc
        Private objBLoanType As New clsBLoanType
        Private objBSchedule As New clsBSchedule
        Private objDLoanTransaction As New clsDLoanTransaction
        Private objDHoldTransaction As New clsDHoldTransaction
        Private objBCommonChart As New clsBCommonChart
        Private intOptItemID As Int16
        Private objarrData() As Integer
        Private objarrLabel() As String
        Private intHistory As Integer
        Private intSimple As Integer


        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' History property
        Public Property History() As Integer
            Get
                Return intHistory
            End Get
            Set(ByVal Value As Integer)
                intHistory = Value
            End Set
        End Property

        ' arrData property 
        Public Property arrData() As Integer()
            Get
                Return objarrData
            End Get
            Set(ByVal Value As Integer())
                objarrData = Value
            End Set
        End Property

        ' arrLabel property
        Public Property arrLabel() As String()
            Get
                Return objarrLabel
            End Get
            Set(ByVal Value As String())
                objarrLabel = Value
            End Set
        End Property

        ' LoanTypeID property
        Public Property OptItemID() As Int16
            Get
                Return intOptItemID
            End Get
            Set(ByVal Value As Int16)
                intOptItemID = Value
            End Set
        End Property

        ' CheckOutDate property
        Public Property CheckOutDate() As String
            Get
                Return strCheckOutDate
            End Get
            Set(ByVal Value As String)
                strCheckOutDate = Value
            End Set
        End Property

        ' CheckInDate property
        Public Property CheckInDate() As String
            Get
                Return strCheckInDate
            End Get
            Set(ByVal Value As String)
                strCheckInDate = Value
            End Set
        End Property

        ' DueDate property
        Public Property DueDate() As String
            Get
                Return strDueDate
            End Get
            Set(ByVal Value As String)
                strDueDate = Value
            End Set
        End Property

        ' TimeOutDate property
        Public Property TimeOutDate() As String
            Get
                Return strTimeOutDate
            End Get
            Set(ByVal Value As String)
                strTimeOutDate = Value
            End Set
        End Property

        ' RenewDate property
        Public Property RenewDate() As String
            Get
                Return strRenewDate
            End Get
            Set(ByVal Value As String)
                strRenewDate = Value
            End Set
        End Property

        ' RecallDate property
        Public Property RecallDate() As String
            Get
                Return strRecallDate
            End Get
            Set(ByVal Value As String)
                strRecallDate = Value
            End Set
        End Property

        ' LoanTypeID property
        Public Property LoanTypeID() As Int16
            Get
                Return intLoanTypeID
            End Get
            Set(ByVal Value As Int16)
                intLoanTypeID = Value
            End Set
        End Property

        ' LoanMode property
        Public Property LoanMode() As Int16
            Get
                Return intLoanMode
            End Get
            Set(ByVal Value As Int16)
                intLoanMode = Value
            End Set
        End Property

        Public Property Simple() As Integer
            Get
                Return intSimple
            End Get
            Set(ByVal Value As Integer)
                intSimple = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Initialize method
        ' Purpose: Init all necessary objects
        Public Overloads Sub Initialize()
            Try
                ' Init objBCSP object
                objBCSP.ConnectionString = strConnectionString
                objBCSP.DBServer = strDBServer
                objBCSP.InterfaceLanguage = strInterfaceLanguage
                Call objBCSP.Initialize()

                ' Init objBCDBS object
                objBCDBS.ConnectionString = strConnectionString
                objBCDBS.DBServer = strDBServer
                objBCDBS.InterfaceLanguage = strInterfaceLanguage
                Call objBCDBS.Initialize()

                ' Init objBLoanType object
                objBLoanType.ConnectionString = strConnectionString
                objBLoanType.DBServer = strDBServer
                objBLoanType.InterfaceLanguage = strInterfaceLanguage
                Call objBLoanType.Initialize()

                ' Init objBSchedule object
                objBSchedule.ConnectionString = strConnectionString
                objBSchedule.DBServer = strDBServer
                objBSchedule.InterfaceLanguage = strInterfaceLanguage
                Call objBSchedule.Initialize()

                ' Init objDLoanTransaction object
                objDLoanTransaction.ConnectionString = strConnectionString
                objDLoanTransaction.DBServer = strDBServer
                Call objDLoanTransaction.Initialize()

                ' Init objDHoldTransaction object
                objDHoldTransaction.ConnectionString = strConnectionString
                objDHoldTransaction.DBServer = strDBServer
                objDHoldTransaction.Initialize()

                ' Init BaseClass
                MyBase.ConnectionString = strConnectionString
                MyBase.DBServer = strDBServer
                MyBase.InterfaceLanguage = strInterfaceLanguage
                Call MyBase.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' GetLoanInfor function 
        ' Purpose: Get loan infor of the selected Patron
        ' Input: strPatronCode
        ' Output: datatable result
        Public Function GetLoanInfor() As DataTable
            Try
                objDLoanTransaction.PatronCode = strPatronCode
                GetLoanInfor = objBCDBS.ConvertTable(objDLoanTransaction.GetLoanInfor)
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' GetLoanDetailInfor function
        ' Purpose: Get loan information in detail of the selected patron
        ' Input: PatronCode, LoanMode, Mode
        ' Output: datatable result
        Public Function GetLoanDetailInfor(ByVal intMode As Int16) As DataTable
            Try
                objDLoanTransaction.LoanMode = intLoanMode
                objDLoanTransaction.PatronCode = Trim(strPatronCode)
                GetLoanDetailInfor = objBCDBS.ConvertTable(objDLoanTransaction.GetLoanDetailInfor(intMode), "TITLE")
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
            Finally
            End Try
        End Function

        Public Function GetLoanDetailInforFull(ByVal intMode As Int16) As DataTable
            Try
                objDLoanTransaction.LoanMode = intLoanMode
                objDLoanTransaction.PatronCode = Trim(strPatronCode)
                GetLoanDetailInforFull = objBCDBS.ConvertTable(objDLoanTransaction.GetLoanDetailInforFull(intMode), "TITLE")
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
            Finally
            End Try
        End Function


        ' CheckIn method
        ' Purpose: CheckIn selected onloan copies
        ' Input: some informations for checkin
        ' Output: intvalue (0 if success)
        Public Function CheckIn(ByVal strCopyNumbers As String, ByVal intAutoPaidFees As Int16) As Int16
            Try
                objDLoanTransaction.UserID = IntUserID
                objDLoanTransaction.CheckInDate = objBCDBS.ConvertDateBack(strCheckInDate)
                CheckIn = objDLoanTransaction.CheckIn(strCopyNumbers, intAutoPaidFees)
                strPatronCode = objDLoanTransaction.PatronCode
                strTransactionIDs = objDLoanTransaction.TransactionIDs
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        Public Function CheckIn(ByVal strCopyNumbers As String, ByVal intAutoPaidFees As Int16, ByVal strCataloguerName As String) As Int16
            Try
                objDLoanTransaction.UserID = intUserID
                objDLoanTransaction.CheckInDate = objBCDBS.ConvertDateBack(strCheckInDate)
                CheckIn = objDLoanTransaction.CheckIn(strCopyNumbers, intAutoPaidFees, strCataloguerName)
                strPatronCode = objDLoanTransaction.PatronCode
                strTransactionIDs = objDLoanTransaction.TransactionIDs
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' RecallCopies method
        ' Purpose: If items are returned right after being checked out, they will be removed from the receipt. These cancelled checkouts are not recorded in loan history.
        ' Input: lngTransactionID
        Public Sub RecallCopies()
            Try
                objDLoanTransaction.TransactionID = lngTransactionID
                Call objDLoanTransaction.RecallCopies()
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub


        ' CheckOut method
        ' Purpose: Checkout CopyNumber
        ' Input: some main information for transaction
        Public Function CheckOut(ByVal intHoldIgnore As Int16) As Integer
            Try
                'objDLoanTransaction.LoanTypeID = intLoanTypeID
                'objDLoanTransaction.ItemID = lngItemID
                'objDLoanTransaction.LocationID = lngLocationID
                objDLoanTransaction.UserID = intUserID
                objDLoanTransaction.PatronCode = Trim(strPatronCode)
                objDLoanTransaction.LoanMode = intLoanMode
                objDLoanTransaction.CopyNumber = Trim(strCopyNumber)
                If Not strDueDate = "NULL" Then
                    objDLoanTransaction.DueDate = Trim(objBCDBS.ConvertDateBack(strDueDate))
                Else
                    objDLoanTransaction.DueDate = "NULL"
                End If
                If Not strCheckOutDate = "NULL" Then
                    objDLoanTransaction.CheckOutDate = Trim(objBCDBS.ConvertDateBack(strCheckOutDate))
                Else
                    objDLoanTransaction.CheckOutDate = strCheckOutDate
                End If
                CheckOut = objDLoanTransaction.CheckOut(intHoldIgnore)
                lngTransactionID = objDLoanTransaction.TransactionID
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        Public Function CheckOut(ByVal intHoldIgnore As Int16, ByVal intRadLoanType As Integer) As Integer
            Try
                'objDLoanTransaction.LoanTypeID = intLoanTypeID
                'objDLoanTransaction.ItemID = lngItemID
                'objDLoanTransaction.LocationID = lngLocationID
                objDLoanTransaction.UserID = intUserID
                objDLoanTransaction.PatronCode = Trim(strPatronCode)
                objDLoanTransaction.LoanMode = intLoanMode
                objDLoanTransaction.CopyNumber = Trim(strCopyNumber)
                If Not strDueDate = "NULL" Then
                    objDLoanTransaction.DueDate = Trim(objBCDBS.ConvertDateBack(strDueDate))
                Else
                    objDLoanTransaction.DueDate = "NULL"
                End If
                If Not strCheckOutDate = "NULL" Then
                    objDLoanTransaction.CheckOutDate = Trim(objBCDBS.ConvertDateBack(strCheckOutDate))
                Else
                    objDLoanTransaction.CheckOutDate = strCheckOutDate
                End If
                CheckOut = objDLoanTransaction.CheckOut(intHoldIgnore, intRadLoanType)
                lngTransactionID = objDLoanTransaction.TransactionID
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        Public Function CheckPermissionPatronGroupLoanType() As Integer
            Try
                objDLoanTransaction.CopyNumber = strCopyNumber
                objDLoanTransaction.PatronCode = strPatronCode
                CheckPermissionPatronGroupLoanType = objDLoanTransaction.CheckPermissionPatronGroupLoanType()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        Public Function CheckOut(ByVal intHoldIgnore As Int16, ByVal intRadLoanType As Integer, ByVal strCataloguerName As String) As Integer
            Try
                'objDLoanTransaction.LoanTypeID = intLoanTypeID
                'objDLoanTransaction.ItemID = lngItemID
                'objDLoanTransaction.LocationID = lngLocationID
                objDLoanTransaction.UserID = intUserID
                objDLoanTransaction.PatronCode = Trim(strPatronCode)
                objDLoanTransaction.LoanMode = intLoanMode
                objDLoanTransaction.CopyNumber = Trim(strCopyNumber)
                If Not strDueDate = "NULL" Then
                    objDLoanTransaction.DueDate = Trim(objBCDBS.ConvertDateBack(strDueDate))
                Else
                    objDLoanTransaction.DueDate = "NULL"
                End If
                If Not strCheckOutDate = "NULL" Then
                    objDLoanTransaction.CheckOutDate = Trim(objBCDBS.ConvertDateBack(strCheckOutDate))
                Else
                    objDLoanTransaction.CheckOutDate = strCheckOutDate
                End If
                CheckOut = objDLoanTransaction.CheckOut(intHoldIgnore, intRadLoanType, strCataloguerName)
                lngTransactionID = objDLoanTransaction.TransactionID
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function


        Public Function CheckOutOther(ByVal intHoldIgnore As Int16) As Integer
            Try
                'objDLoanTransaction.LoanTypeID = intLoanTypeID
                'objDLoanTransaction.ItemID = lngItemID
                'objDLoanTransaction.LocationID = lngLocationID
                objDLoanTransaction.UserID = intUserID
                objDLoanTransaction.PatronCode = Trim(strPatronCode)
                objDLoanTransaction.LoanMode = intLoanMode
                objDLoanTransaction.CopyNumber = Trim(strCopyNumber)
                If Not strDueDate = "NULL" Then
                    objDLoanTransaction.DueDate = Trim(objBCDBS.ConvertDateBack(strDueDate))
                Else
                    objDLoanTransaction.DueDate = "NULL"
                End If
                If Not strCheckOutDate = "NULL" Then
                    objDLoanTransaction.CheckOutDate = Trim(objBCDBS.ConvertDateBack(strCheckOutDate))
                Else
                    objDLoanTransaction.CheckOutDate = strCheckOutDate
                End If
                CheckOutOther = objDLoanTransaction.CheckOutOther(intHoldIgnore)
                lngTransactionID = objDLoanTransaction.TransactionID
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' GetDisList method
        ' Purpose: check hold request to send notice email
        ' Output: datatable result
        Public Function GetDisList() As DataTable
            Try
                objDLoanTransaction.Simple = intSimple
                GetDisList = objBCDBS.ConvertTable(objDLoanTransaction.GetDisList())
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetCheckInDate method
        ' Purpose:
        Public Function GetCheckInDate()
            Try

            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function


        ' CreateAnnualStatistic function
        ' Purpose: Static year
        Public Sub CreateAnnualStatistic()
            Dim intRowIndex As Integer
            Dim intTotalRecords As Integer
            Dim tblData As DataTable

            Try
                objDLoanTransaction.History = intHistory
                objDLoanTransaction.OptItemID = intOptItemID
                objDLoanTransaction.UserID = intUserID
                tblData = objDLoanTransaction.CreateAnnualStatistic()

                If Not tblData Is Nothing Then
                    If tblData.Rows.Count > 0 Then
                        intTotalRecords = tblData.Rows.Count
                        ReDim arrData(intTotalRecords - 1)
                        ReDim arrLabel(intTotalRecords - 1)
                        For intRowIndex = 0 To intTotalRecords - 1
                            arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("TotalLoan")
                            arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("Year")
                        Next
                    End If
                End If
                intErrorCode = objDLoanTransaction.ErrorCode
                strErrorMsg = objDLoanTransaction.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        Public Sub CreateAnnualStatisticEx(Optional fromCheckOutDate As DateTime? = Nothing,
                                                    Optional toCheckOutDate As DateTime? = Nothing,
                                                    Optional fromCheckInDate As DateTime? = Nothing,
                                                    Optional toCheckInDate As DateTime? = Nothing,
                                                    Optional offset As Integer? = Nothing,
                                                    Optional take As Integer? = Nothing)
            Dim intRowIndex As Integer
            Dim intTotalRecords As Integer
            Dim tblData As DataTable

            Try
                objDLoanTransaction.History = intHistory
                objDLoanTransaction.OptItemID = intOptItemID
                objDLoanTransaction.UserID = intUserID
                objDLoanTransaction.LocationID = LocationID
                objDLoanTransaction.LoanMode = LoanMode
                tblData = objDLoanTransaction.CreateAnnualStatisticEx(fromCheckOutDate, toCheckOutDate, fromCheckInDate, toCheckInDate, offset, take)

                If Not tblData Is Nothing Then
                    If tblData.Rows.Count > 0 Then
                        intTotalRecords = tblData.Rows.Count
                        ReDim arrData(intTotalRecords - 1)
                        ReDim arrLabel(intTotalRecords - 1)
                        For intRowIndex = 0 To intTotalRecords - 1
                            arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("TotalLoan")
                            arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("Year")
                        Next
                    End If
                End If
                intErrorCode = objDLoanTransaction.ErrorCode
                strErrorMsg = objDLoanTransaction.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        Public Function CreateAnnualStatisticDetail(ByRef total As Integer,
                                                    Optional fromCheckOutDate As DateTime? = Nothing,
                                                    Optional toCheckOutDate As DateTime? = Nothing,
                                                    Optional fromCheckInDate As DateTime? = Nothing,
                                                    Optional toCheckInDate As DateTime? = Nothing,
                                                    Optional offset As Integer? = Nothing,
                                                    Optional take As Integer? = Nothing) As DataTable
            Try
                objDLoanTransaction.History = intHistory
                objDLoanTransaction.OptItemID = intOptItemID
                objDLoanTransaction.UserID = intUserID
                objDLoanTransaction.LocationID = LocationID
                objDLoanTransaction.LoanMode = LoanMode
                CreateAnnualStatisticDetail = objDLoanTransaction.CreateAnnualStatisticDetail(total, fromCheckOutDate, toCheckOutDate, fromCheckInDate, toCheckInDate, offset, take)
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
                CreateAnnualStatisticDetail = Nothing
            Finally
            End Try
        End Function
        ' CreateMonthStatistic function
        ' Purpose: Static month
        Public Sub CreateMonthStatistic(ByVal intStatYear As Integer)
            Dim intRowIndex As Integer
            Dim intTotalRecords As Integer
            Dim tblData As DataTable

            Try
                objDLoanTransaction.History = intHistory
                objDLoanTransaction.OptItemID = intOptItemID
                objDLoanTransaction.UserID = intUserID
                tblData = objDLoanTransaction.CreateMonthStatistic(intStatYear)

                If Not tblData Is Nothing Then
                    If tblData.Rows.Count > 0 Then
                        intTotalRecords = tblData.Rows.Count
                        ReDim arrData(intTotalRecords - 1)
                        ReDim arrLabel(intTotalRecords - 1)
                        For intRowIndex = 0 To intTotalRecords - 1
                            arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("TotalLoan")
                            arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("Mon")
                        Next
                    End If
                End If
                intErrorCode = objDLoanTransaction.ErrorCode
                strErrorMsg = objDLoanTransaction.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        Public Sub CreateMonthStatisticOther(Optional fromCheckOutDate As DateTime? = Nothing,
                                                    Optional toCheckOutDate As DateTime? = Nothing,
                                                    Optional fromCheckInDate As DateTime? = Nothing,
                                                    Optional toCheckInDate As DateTime? = Nothing,
                                                    Optional offset As Integer? = Nothing,
                                                    Optional take As Integer? = Nothing)
            Dim intRowIndex As Integer
            Dim intTotalRecords As Integer
            Dim tblData As DataTable

            Try
                objDLoanTransaction.History = intHistory
                objDLoanTransaction.OptItemID = intOptItemID
                objDLoanTransaction.UserID = intUserID
                objDLoanTransaction.LocationID = LocationID
                objDLoanTransaction.LoanMode = LoanMode
                tblData = objDLoanTransaction.CreateMonthStatisticOther(fromCheckOutDate, toCheckOutDate, fromCheckInDate, toCheckInDate, offset, take)

                If Not tblData Is Nothing Then
                    If tblData.Rows.Count > 0 Then
                        intTotalRecords = tblData.Rows.Count
                        ReDim arrData(intTotalRecords - 1)
                        ReDim arrLabel(intTotalRecords - 1)
                        For intRowIndex = 0 To intTotalRecords - 1
                            arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("TotalLoan")
                            arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("Mon")
                        Next
                    End If
                End If
                intErrorCode = objDLoanTransaction.ErrorCode
                strErrorMsg = objDLoanTransaction.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        Public Function CreateMonthStatisticDetail(ByVal year As Integer, ByRef total As Integer,
                                                    Optional offset As Integer? = Nothing,
                                                    Optional take As Integer? = Nothing) As DataTable
            Try
                objDLoanTransaction.History = intHistory
                objDLoanTransaction.OptItemID = intOptItemID
                objDLoanTransaction.UserID = intUserID
                objDLoanTransaction.LocationID = LocationID
                objDLoanTransaction.LoanMode = LoanMode
                CreateMonthStatisticDetail = objDLoanTransaction.CreateMonthStatisticDetail(year, total, offset, take)
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
                CreateMonthStatisticDetail = Nothing
            Finally
            End Try
        End Function

        ' CreateDayStatistic function
        ' Purpose: Static day
        Public Sub CreateDayStatistic(ByVal intStatMon As Integer, ByVal intStatYear As Integer)
            Dim intRowIndex As Integer
            Dim intTotalRecords As Integer
            Dim tblData As DataTable

            Try
                objDLoanTransaction.History = intHistory
                objDLoanTransaction.OptItemID = intOptItemID
                objDLoanTransaction.UserID = intUserID
                objDLoanTransaction.LocationID = LocationID
                objDLoanTransaction.LoanMode = LoanMode
                tblData = objDLoanTransaction.CreateDayStatistic(intStatMon, intStatYear)

                If Not tblData Is Nothing Then
                    If tblData.Rows.Count > 0 Then
                        intTotalRecords = tblData.Rows.Count
                        ReDim arrData(intTotalRecords - 1)
                        ReDim arrLabel(intTotalRecords - 1)
                        For intRowIndex = 0 To intTotalRecords - 1
                            arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("TotalLoan")
                            arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("Days")
                        Next
                    End If
                End If
                intErrorCode = objDLoanTransaction.ErrorCode
                strErrorMsg = objDLoanTransaction.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        Public Sub CreateDayStatisticOther(Optional fromCheckOutDate As DateTime? = Nothing,
                                                    Optional toCheckOutDate As DateTime? = Nothing,
                                                    Optional fromCheckInDate As DateTime? = Nothing,
                                                    Optional toCheckInDate As DateTime? = Nothing,
                                                    Optional offset As Integer? = Nothing,
                                                    Optional take As Integer? = Nothing)
            Dim intRowIndex As Integer
            Dim intTotalRecords As Integer
            Dim tblData As DataTable

            Try
                objDLoanTransaction.History = intHistory
                objDLoanTransaction.OptItemID = intOptItemID
                objDLoanTransaction.UserID = intUserID
                objDLoanTransaction.LocationID = LocationID
                objDLoanTransaction.LoanMode = LoanMode
                tblData = objDLoanTransaction.CreateDayStatisticOther(fromCheckOutDate, toCheckOutDate, fromCheckInDate, toCheckInDate, offset, take)

                If Not tblData Is Nothing Then
                    If tblData.Rows.Count > 0 Then
                        intTotalRecords = tblData.Rows.Count
                        ReDim arrData(intTotalRecords - 1)
                        ReDim arrLabel(intTotalRecords - 1)
                        For intRowIndex = 0 To intTotalRecords - 1
                            arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("TotalLoan")
                            arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("Days")
                        Next
                    End If
                End If
                intErrorCode = objDLoanTransaction.ErrorCode
                strErrorMsg = objDLoanTransaction.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        Public Function CreateDayStatisticDetail(ByVal month As Integer,
                                                 ByVal year As Integer,
                                                 ByRef total As Integer,
                                                    Optional offset As Integer? = Nothing,
                                                    Optional take As Integer? = Nothing) As DataTable
            Try
                objDLoanTransaction.History = intHistory
                objDLoanTransaction.OptItemID = intOptItemID
                objDLoanTransaction.UserID = intUserID
                objDLoanTransaction.LocationID = LocationID
                objDLoanTransaction.LoanMode = LoanMode
                CreateDayStatisticDetail = objDLoanTransaction.CreateDayStatisticDetail(month, year, total, offset, take)
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
                CreateDayStatisticDetail = Nothing
            Finally
            End Try
        End Function

        Public Function CreateHoldingPlaceStatisticDetail(ByVal month As Integer,
                                                 ByVal year As Integer,
                                                 ByRef total As Integer,
                                                    Optional offset As Integer? = Nothing,
                                                    Optional take As Integer? = Nothing) As DataTable
            Try
                objDLoanTransaction.History = intHistory
                objDLoanTransaction.OptItemID = intOptItemID
                objDLoanTransaction.UserID = intUserID
                objDLoanTransaction.LocationID = LocationID
                objDLoanTransaction.LoanMode = LoanMode
                CreateHoldingPlaceStatisticDetail = objDLoanTransaction.CreateHoldingPlaceStatisticDetail(month, year, total, offset, take)
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
                CreateHoldingPlaceStatisticDetail = Nothing
            Finally
            End Try
        End Function

        ' CreatePolicyStatistic public
        ' Purpose: Static by policy
        Public Sub CreatePolicyStatistic(ByVal strCheckOutDateFrom As String, ByVal strCheckOutDateTo As String)
            Dim intRowIndex As Integer
            Dim intTotalRecords As Integer
            Dim tblData As DataTable
            Try
                objDLoanTransaction.History = intHistory
                objDLoanTransaction.OptItemID = intOptItemID
                objDLoanTransaction.UserID = intUserID
                objDLoanTransaction.LoanTypeID = LoanTypeID
                strCheckOutDateFrom = objBCDBS.ConvertDateBack(strCheckOutDateFrom)
                strCheckOutDateTo = objBCDBS.ConvertDateBack(strCheckOutDateTo)
                tblData = objDLoanTransaction.CreatePolicyStatistic(strCheckOutDateFrom, strCheckOutDateTo)

                If Not tblData Is Nothing Then
                    arrData = Nothing
                    If tblData.Rows.Count > 0 Then
                        intTotalRecords = tblData.Rows.Count
                        ReDim arrData(intTotalRecords - 1)
                        ReDim arrLabel(intTotalRecords - 1)
                        For intRowIndex = 0 To intTotalRecords - 1
                            arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("TotalLoan")
                            arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("Name")
                        Next
                    End If
                End If
                intErrorCode = objDLoanTransaction.ErrorCode
                strErrorMsg = objDLoanTransaction.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub


        ' CreatePatronGroupStatistic function 
        ' Purpose: Static by holiding place
        Public Sub CreateHoldingPlaceStatistic(ByVal intOptLib As Integer, ByVal strCheckOutDateFrom As String, ByVal strCheckOutDateTo As String, ByVal strLibIDs As String)
            Dim intRowIndex As Integer
            Dim intTotalRecords As Integer
            Dim tblData As DataTable

            Try
                objDLoanTransaction.History = intHistory
                objDLoanTransaction.OptItemID = intOptItemID
                objDLoanTransaction.UserID = intUserID
                strCheckOutDateFrom = objBCDBS.ConvertDateBack(strCheckOutDateFrom)
                strCheckOutDateTo = objBCDBS.ConvertDateBack(strCheckOutDateTo)
                tblData = objDLoanTransaction.CreateHoldingPlaceStatistic(intOptLib, strCheckOutDateFrom, strCheckOutDateTo, strLibIDs)

                If Not tblData Is Nothing Then
                    arrData = Nothing
                    If tblData.Rows.Count > 0 Then
                        intTotalRecords = tblData.Rows.Count
                        ReDim arrData(intTotalRecords - 1)
                        ReDim arrLabel(intTotalRecords - 1)
                        For intRowIndex = 0 To intTotalRecords - 1
                            arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("TotalLoan")
                            arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("Name")
                        Next
                    End If
                End If
                intErrorCode = objDLoanTransaction.ErrorCode
                strErrorMsg = objDLoanTransaction.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        Public Sub CreateHoldingPlaceStatisticOther(
                                                    Optional optLib As Integer = 0,
                                                    Optional ids As String = Nothing,
                                                    Optional fromCheckOutDate As DateTime? = Nothing,
                                                    Optional toCheckOutDate As DateTime? = Nothing,
                                                    Optional fromCheckInDate As DateTime? = Nothing,
                                                    Optional toCheckInDate As DateTime? = Nothing,
                                                    Optional offset As Integer? = Nothing,
                                                    Optional take As Integer? = Nothing)
            Dim intRowIndex As Integer
            Dim intTotalRecords As Integer
            Dim tblData As DataTable

            Try
                objDLoanTransaction.History = intHistory
                objDLoanTransaction.OptItemID = intOptItemID
                objDLoanTransaction.UserID = intUserID
                objDLoanTransaction.LocationID = LocationID
                objDLoanTransaction.LoanMode = LoanMode
                tblData = objDLoanTransaction.CreateHoldingPlaceStatisticOther(optLib, ids, fromCheckOutDate, toCheckOutDate, fromCheckInDate, toCheckInDate, offset, take)

                If Not tblData Is Nothing Then
                    If tblData.Rows.Count > 0 Then
                        intTotalRecords = tblData.Rows.Count
                        ReDim arrData(intTotalRecords - 1)
                        ReDim arrLabel(intTotalRecords - 1)
                        For intRowIndex = 0 To intTotalRecords - 1
                            arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("TotalLoan")
                            arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("Name")
                        Next
                    End If
                End If
                intErrorCode = objDLoanTransaction.ErrorCode
                strErrorMsg = objDLoanTransaction.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        Public Function CreateHoldingPlaceStatisticOther_Detail(
                                                    ByRef total As Integer,
                                                    Optional optLib As Integer = 0,
                                                    Optional ids As String = Nothing,
                                                    Optional fromCheckOutDate As DateTime? = Nothing,
                                                    Optional toCheckOutDate As DateTime? = Nothing,
                                                    Optional fromCheckInDate As DateTime? = Nothing,
                                                    Optional toCheckInDate As DateTime? = Nothing,
                                                    Optional offset As Integer? = Nothing,
                                                    Optional take As Integer? = Nothing) As DataTable
            Try
                objDLoanTransaction.History = intHistory
                objDLoanTransaction.OptItemID = intOptItemID
                objDLoanTransaction.UserID = intUserID
                objDLoanTransaction.LocationID = LocationID
                objDLoanTransaction.LoanMode = LoanMode
                CreateHoldingPlaceStatisticOther_Detail = objDLoanTransaction.CreateHoldingPlaceStatisticOther_Detail(total, optLib, ids, fromCheckOutDate, toCheckOutDate, fromCheckInDate, toCheckInDate, offset, take)
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
                CreateHoldingPlaceStatisticOther_Detail = Nothing
            Finally
            End Try
        End Function

        ' CreatePatronGroupStatistic function 
        ' Purpose: Static by PatronGroup
        Public Sub CreatePatronGroupStatistic(ByVal strCheckOutDateFrom As String, ByVal strCheckOutDateTo As String)
            Dim intRowIndex As Integer
            Dim intTotalRecords As Integer
            Dim tblData As DataTable

            Try
                objDLoanTransaction.History = intHistory
                objDLoanTransaction.OptItemID = intOptItemID
                objDLoanTransaction.UserID = intUserID
                strCheckOutDateFrom = objBCDBS.ConvertDateBack(strCheckOutDateFrom)
                strCheckOutDateTo = objBCDBS.ConvertDateBack(strCheckOutDateTo)
                tblData = objDLoanTransaction.CreatePatronGroupStatistic(strCheckOutDateFrom, strCheckOutDateTo)

                If Not tblData Is Nothing Then
                    arrData = Nothing
                    If tblData.Rows.Count > 0 Then
                        intTotalRecords = tblData.Rows.Count
                        ReDim arrData(intTotalRecords - 1)
                        ReDim arrLabel(intTotalRecords - 1)
                        For intRowIndex = 0 To intTotalRecords - 1
                            arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("TotalLoan")
                            arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("Name")
                        Next
                    End If
                End If
                intErrorCode = objDLoanTransaction.ErrorCode
                strErrorMsg = objDLoanTransaction.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub


        ' CreateTop20Statistic function
        ' Purpose:
        Public Sub CreateTop20Statistic(ByVal intID As Integer, ByVal intHistory As Integer)
            Dim intRowIndex As Integer
            Dim tblData As DataTable
            Dim intTotalRecords As Integer

            Try
                objDLoanTransaction.UserID = intUserID
                tblData = objDLoanTransaction.CreateTop20Statistic(intID, intHistory)
                intTotalRecords = tblData.Rows.Count

                ReDim arrData(intTotalRecords - 1)
                ReDim arrLabel(intTotalRecords - 1)
                For intRowIndex = 0 To intTotalRecords - 1
                    arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("Total")
                    arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("Name")
                Next
                intErrorCode = objDLoanTransaction.ErrorCode
                strErrorMsg = objDLoanTransaction.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' CreateTopCopyStatistic function 
        ' Purpose:Static Copy
        Public Sub CreateTopCopyStatistic(ByVal strCheckOutDateFrom As String, ByVal strCheckOutDateTo As String, ByVal intTopNum As Integer, ByVal intMinLoan As Integer)
            Dim intRowIndex As Integer
            Dim intTotalRecords As Integer
            Dim tblData As DataTable

            Try
                objDLoanTransaction.UserID = intUserID
                strCheckOutDateFrom = objBCDBS.ConvertDateBack(strCheckOutDateFrom)
                strCheckOutDateTo = objBCDBS.ConvertDateBack(strCheckOutDateTo)
                tblData = objDLoanTransaction.CreateTopCopyStatistic(strCheckOutDateFrom, strCheckOutDateTo, intTopNum, intMinLoan)

                intTotalRecords = tblData.Rows.Count
                ReDim arrData(intTotalRecords - 1)
                ReDim arrLabel(intTotalRecords - 1)
                For intRowIndex = 0 To intTotalRecords - 1
                    arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("TotalLoan")
                    arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("Name")
                Next
                intErrorCode = objDLoanTransaction.ErrorCode
                strErrorMsg = objDLoanTransaction.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        Public Sub CreateTopCopyStatisticOther(ByVal strCheckOutDateFrom As String, ByVal strCheckOutDateTo As String, ByVal intTopNum As Integer, ByVal intMinLoan As Integer)
            Dim intRowIndex As Integer
            Dim intTotalRecords As Integer
            Dim tblData As DataTable

            Try
                objDLoanTransaction.UserID = intUserID
                strCheckOutDateFrom = strCheckOutDateFrom
                strCheckOutDateTo = strCheckOutDateTo
                tblData = objDLoanTransaction.CreateTopCopyStatistic(strCheckOutDateFrom, strCheckOutDateTo, intTopNum, intMinLoan)

                intTotalRecords = tblData.Rows.Count
                ReDim arrData(intTotalRecords - 1)
                ReDim arrLabel(intTotalRecords - 1)
                For intRowIndex = 0 To intTotalRecords - 1
                    arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("TotalLoan")
                    arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("CopyNumber")
                Next
                intErrorCode = objDLoanTransaction.ErrorCode
                strErrorMsg = objDLoanTransaction.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub
        Public Function CreateTopCopyStatisticOtherDHVL(ByVal strCheckOutDateFrom As String, ByVal strCheckOutDateTo As String, ByVal intTopNum As Integer, ByVal intMinLoan As Integer) As DataTable
            Dim intRowIndex As Integer
            Dim intTotalRecords As Integer
            Dim tblData As DataTable

            Try
                objDLoanTransaction.UserID = intUserID
                strCheckOutDateFrom = strCheckOutDateFrom
                strCheckOutDateTo = strCheckOutDateTo
                CreateTopCopyStatisticOtherDHVL = objDLoanTransaction.CreateTopCopyStatistic(strCheckOutDateFrom, strCheckOutDateTo, intTopNum, intMinLoan)

                intTotalRecords = CreateTopCopyStatisticOtherDHVL.Rows.Count
                'ReDim arrData(intTotalRecords - 1)
                'ReDim arrLabel(intTotalRecords - 1)
                'For intRowIndex = 0 To intTotalRecords - 1
                '    arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("TotalLoan")
                '    arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("Code")
                'Next
                intErrorCode = objDLoanTransaction.ErrorCode
                strErrorMsg = objDLoanTransaction.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        Public Function CreateStatisticLoanHistoryCopyNumber(ByVal strCheckOutDateFrom As String, ByVal strCheckOutDateTo As String) As DataTable
            Dim intRowIndex As Integer = 0
            Dim intTotalRecords As Integer = 0
            Dim tblData As DataTable

            Try
                strCheckOutDateFrom = objBCDBS.ConvertDateBack(strCheckOutDateFrom, False)
                strCheckOutDateTo = objBCDBS.ConvertDateBack(strCheckOutDateTo, False)
                tblData = objDLoanTransaction.CreateStatisticLoanHistoryCopyNumber(strCheckOutDateFrom, strCheckOutDateTo)

                If Not IsNothing(tblData) AndAlso tblData.Rows.Count Then
                    intTotalRecords = tblData.Rows.Count
                    ReDim arrData(intTotalRecords - 1)
                    ReDim arrLabel(intTotalRecords - 1)
                    For intRowIndex = 0 To intTotalRecords - 1
                        arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("Count")
                        arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("CopyNumber")
                    Next
                Else
                    ReDim arrData(0)
                    ReDim arrLabel(0)
                    arrData(0) = -1
                    arrLabel(0) = ""
                End If

                intErrorCode = objDLoanTransaction.ErrorCode
                strErrorMsg = objDLoanTransaction.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        Public Function CreateStatisticLoanHistoryCopyNumberDetail(ByVal strCheckOutDateFrom As String, ByVal strCheckOutDateTo As String) As DataTable
            Try
                strCheckOutDateFrom = objBCDBS.ConvertDateBack(strCheckOutDateFrom, False)
                strCheckOutDateTo = objBCDBS.ConvertDateBack(strCheckOutDateTo, False)
                CreateStatisticLoanHistoryCopyNumberDetail = objDLoanTransaction.CreateStatisticLoanHistoryCopyNumberDetail(strCheckOutDateFrom, strCheckOutDateTo)
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        Public Function UpdateLoanModePatron(ByVal intPatronID As Integer) As Integer
            Try
                Dim result As Integer = objDLoanTransaction.UpdateLoanModePatron(intPatronID)
                intErrorCode = objDLoanTransaction.ErrorCode
                strErrorMsg = objDLoanTransaction.ErrorMsg
                Return result
            Catch ex As Exception
                intErrorCode = objDLoanTransaction.ErrorCode
                strErrorMsg = objDLoanTransaction.ErrorMsg
                Return 0
            End Try
        End Function

        ' CreateTopPatrolStatistic function 
        ' Purpose: Static top patrons
        Public Sub CreateTopPatrolStatistic(ByVal strCheckOutDateFrom As String, ByVal strCheckOutDateTo As String, ByVal intTopNum As Integer, ByVal intMinLoan As Integer)
            Dim intRowIndex As Integer
            Dim intTotalRecords As Integer
            Dim tblData As DataTable

            Try
                objDLoanTransaction.OptItemID = intOptItemID
                objDLoanTransaction.UserID = intUserID
                strCheckOutDateFrom = objBCDBS.ConvertDateBack(strCheckOutDateFrom)
                strCheckOutDateTo = objBCDBS.ConvertDateBack(strCheckOutDateTo)
                tblData = objDLoanTransaction.CreateTopPatrolStatistic(strCheckOutDateFrom, strCheckOutDateTo, intTopNum, intMinLoan)

                intTotalRecords = tblData.Rows.Count
                ReDim arrData(intTotalRecords - 1)
                ReDim arrLabel(intTotalRecords - 1)
                For intRowIndex = 0 To intTotalRecords - 1
                    arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("TotalLoan")
                    arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("Name")
                Next
                intErrorCode = objDLoanTransaction.ErrorCode
                strErrorMsg = objDLoanTransaction.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' Creat`eLoanReport function 
        ' Purpose: Create Loan Report
        Public Function CreateLoanReport(ByVal strPatronCode As String, ByVal strItemCode As String, ByVal strCopyNumber As String, ByVal intLocationID As Integer, ByVal strCheckOutDateFrom As String, ByVal strCheckOutDateTo As String, ByVal strInDateFrom As String, ByVal strInDateTo As String, ByVal intUserID As Integer) As DataTable
            Try
                If strCheckOutDateFrom <> "" Then strCheckOutDateFrom = objBCDBS.ConvertDateBack(strCheckOutDateFrom + " 00:00:00")
                If strCheckOutDateTo <> "" Then strCheckOutDateTo = objBCDBS.ConvertDateBack(strCheckOutDateTo + " 23:59:59")
                If strInDateFrom <> "" Then strInDateFrom = objBCDBS.ConvertDateBack(strInDateFrom + " 00:00:00")
                If strInDateTo <> "" Then strInDateTo = objBCDBS.ConvertDateBack(strInDateTo + " 23:59:59")
                CreateLoanReport = objBCDBS.ConvertTable(objDLoanTransaction.CreateloanReport(strPatronCode, strItemCode, strCopyNumber, intLocationID, strCheckOutDateFrom, strCheckOutDateTo, strInDateFrom, strInDateTo, intUserID), "Content")
                intErrorCode = objDLoanTransaction.ErrorCode
                strErrorMsg = objDLoanTransaction.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function
        Public Function CreateLoanReportCataloguerName(ByVal strItemCode As String,
                                                        ByRef total As Integer,
                                                        Optional fromCheckOutDate As DateTime? = Nothing,
                                                        Optional toCheckOutDate As DateTime? = Nothing,
                                                        Optional fromCheckInDate As DateTime? = Nothing,
                                                        Optional toCheckInDate As DateTime? = Nothing,
                                                        Optional offset As Integer? = Nothing,
                                                        Optional take As Integer? = Nothing) As DataTable
            CreateLoanReportCataloguerName = Nothing
            Try
                If strItemCode IsNot Nothing Then
                    strItemCode = strItemCode.Trim()
                    If strItemCode = "" Then
                        strItemCode = Nothing
                    End If
                End If

                Dim dt As DateTime
                If fromCheckOutDate IsNot Nothing Then
                    dt = fromCheckOutDate
                    fromCheckOutDate = New DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0)
                End If
                If toCheckOutDate IsNot Nothing Then
                    dt = toCheckOutDate
                    toCheckOutDate = New DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59)
                End If
                If fromCheckInDate IsNot Nothing Then
                    dt = fromCheckInDate
                    fromCheckInDate = New DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0)
                End If
                If toCheckInDate IsNot Nothing Then
                    dt = toCheckInDate
                    toCheckInDate = New DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59)
                End If

                objDLoanTransaction.LibID = LibID
                objDLoanTransaction.PatronCode = If(PatronCode = "", Nothing, PatronCode)
                objDLoanTransaction.CopyNumber = If(CopyNumber = "", Nothing, CopyNumber)
                objDLoanTransaction.LocationID = LocationID
                objDLoanTransaction.UserID = UserID
                CreateLoanReportCataloguerName = objDLoanTransaction.CreateloanReportCataloguerName(strItemCode, total, fromCheckOutDate, toCheckOutDate, fromCheckInDate, toCheckInDate, offset, take)
                intErrorCode = objDLoanTransaction.ErrorCode
                strErrorMsg = objDLoanTransaction.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' CreateOnloanReport function 
        ' Purpose: Create Onloan report
        Public Function CreateOnloanReport(ByVal strPatronCode As String, ByVal strItemCode As String, ByVal strCopyNumber As String, ByVal intLocationID As Integer, ByVal strCheckOutDateFrom As String, ByVal strCheckOutDateTo As String, ByVal strDueDateFrom As String, ByVal strDueDateTo As String, ByVal intUserID As Integer) As DataTable
            Try
                If strCheckOutDateFrom <> "" Then strCheckOutDateFrom = objBCDBS.ConvertDateBack(strCheckOutDateFrom + " 00:00:00")
                If strCheckOutDateTo <> "" Then strCheckOutDateTo = objBCDBS.ConvertDateBack(strCheckOutDateTo + " 23:59:59")
                If strDueDateFrom <> "" Then strDueDateFrom = objBCDBS.ConvertDateBack(strDueDateFrom + " 00:00:00")
                If strDueDateTo <> "" Then strDueDateTo = objBCDBS.ConvertDateBack(strDueDateTo + " 23:59:59")
                objDLoanTransaction.LibID = intLibID
                CreateOnloanReport = objBCDBS.ConvertTable(objDLoanTransaction.CreateOnloanReport(strPatronCode, strItemCode, strCopyNumber, intLocationID, strCheckOutDateFrom, strCheckOutDateTo, strDueDateFrom, strDueDateTo, intUserID), "Content")
                intErrorCode = objDLoanTransaction.ErrorCode
                strErrorMsg = objDLoanTransaction.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function
        Public Function CreateOnloanReportCataloguerName(
                                                        ByVal strItemCode As String,
                                                        ByRef total As Integer,
                                                        Optional fromCheckOutDate As DateTime? = Nothing,
                                                        Optional toCheckOutDate As DateTime? = Nothing,
                                                        Optional fromCheckInDate As DateTime? = Nothing,
                                                        Optional toCheckInDate As DateTime? = Nothing,
                                                        Optional offset As Integer? = Nothing,
                                                        Optional take As Integer? = Nothing) As DataTable
            CreateOnloanReportCataloguerName = Nothing
            Try
                If strItemCode IsNot Nothing Then
                    strItemCode = strItemCode.Trim()
                    If strItemCode = "" Then
                        strItemCode = Nothing
                    End If
                End If

                Dim dt As DateTime
                If fromCheckOutDate IsNot Nothing Then
                    dt = fromCheckOutDate
                    fromCheckOutDate = New DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0)
                End If
                If toCheckOutDate IsNot Nothing Then
                    dt = toCheckOutDate
                    toCheckOutDate = New DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59)
                End If
                If fromCheckInDate IsNot Nothing Then
                    dt = fromCheckInDate
                    fromCheckInDate = New DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0)
                End If
                If toCheckInDate IsNot Nothing Then
                    dt = toCheckInDate
                    toCheckInDate = New DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59)
                End If

                objDLoanTransaction.LibID = LibID
                objDLoanTransaction.PatronCode = If(PatronCode = "", Nothing, PatronCode)
                objDLoanTransaction.CopyNumber = If(CopyNumber = "", Nothing, CopyNumber)
                objDLoanTransaction.LocationID = LocationID
                objDLoanTransaction.UserID = UserID
                CreateOnloanReportCataloguerName = objDLoanTransaction.CreateOnloanReportCataloguerName(strItemCode, total, fromCheckOutDate, toCheckOutDate, fromCheckInDate, toCheckInDate, offset, take)
                intErrorCode = objDLoanTransaction.ErrorCode
                strErrorMsg = objDLoanTransaction.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' Purpose: Get quick view informations
        ' Input: intUserID
        ' Output: datatable result
        Public Function GetQuickView(ByVal intOption As Integer, ByVal intUserID As String) As DataTable
            Dim tblQuickView As New DataTable
            Dim inti As Integer
            ReDim objarrData(0)
            ReDim objarrLabel(0)
            objarrLabel(0) = "NOT FOUND"
            objarrData(0) = -1
            objDLoanTransaction.LibID = intLibID
            tblQuickView = objDLoanTransaction.GetQuickView(intOption, intUserID)
            intErrorCode = objDLoanTransaction.ErrorCode
            strErrorMsg = objDLoanTransaction.ErrorMsg
            If intOption = 0 Then
                If Not tblQuickView Is Nothing Then
                    If tblQuickView.Rows.Count > 0 Then
                        ReDim objarrData(tblQuickView.Rows.Count - 1)
                        ReDim objarrLabel(tblQuickView.Rows.Count - 1)
                        For inti = 0 To tblQuickView.Rows.Count - 1
                            objarrData(inti) = tblQuickView.Rows(inti).Item("Amount")
                            objarrLabel(inti) = tblQuickView.Rows(inti).Item("Symbol")
                        Next
                    End If
                End If
            End If
            GetQuickView = tblQuickView
        End Function
        ' CalculateCheckInDate method
        ' Purpose: Get checkin date
        ' Input: 
        '   - DateTime (after used convertdate method)
        '   - LoanTypeID
        '   - LocationID
        Public Function CalculateCheckInDate(ByVal intLoanTypeID As Int16, ByVal strDateTime As String, ByVal intLocationID As Integer) As String
            Dim tblLoanType As DataTable
            Dim tblSchedule As DataTable

            'Try
            ' Get LoanTypeID
            objBLoanType.LoanTypeID = intLoanTypeID
            tblLoanType = objBLoanType.GetLoanTypes()
            If tblLoanType.Rows.Count > 0 Then
                Dim intTimeUnit As Int16 = CInt(tblLoanType.Rows(0).Item("TimeUnit"))
                Dim intLoanPeriod As Integer = CInt(tblLoanType.Rows(0).Item("LoanPeriod"))
                Dim dtmCheckInDate As DateTime
                Dim dtmReturnDate As DateTime
                Dim dtmCloseDate As DateTime

                dtmCheckInDate = CDate(strDateTime)
                objBSchedule.LocationID = intLocationID

                ' Calculating
                Select Case intTimeUnit
                    Case 1 ' day
                        dtmReturnDate = DateAdd(DateInterval.Day, intLoanPeriod, dtmCheckInDate)
                        objBSchedule.OffDay = CStr(dtmReturnDate)
                        tblSchedule = objBSchedule.GetSchedule(False)
                        If Not tblSchedule Is Nothing Then
                            'Do While Not tblSchedule.Rows.Count <= 0
                            '    dtmReturnDate = DateAdd(DateInterval.Day, 1, dtmReturnDate)
                            '    objBSchedule.OffDay = CStr(dtmReturnDate)
                            '    tblSchedule = objBSchedule.GetSchedule(False)
                            'Loop
                            If tblSchedule.Rows.Count > 0 Then
                                dtmReturnDate = tblSchedule.Rows(0).Item("OffDay")
                            End If
                        End If
                        Return CStr(dtmReturnDate)
                    Case 2 ' hour
                        objBSchedule.WeekDay = Weekday(dtmCheckInDate)
                        tblSchedule = objBSchedule.GetWorkingTime
                        If Not tblSchedule Is Nothing Then
                            If tblSchedule.Rows.Count > 0 Then
                                If Not IsDBNull(tblSchedule.Rows(0).Item("Close2")) Then
                                    dtmCloseDate = CDate(Left(CStr(dtmCheckInDate), 10) & " " & Left(tblSchedule.Rows(0).Item("Close2"), 2) & ":" & Right(tblSchedule.Rows(0).Item("Close2"), 2) & ":00")
                                ElseIf Not IsDBNull(tblSchedule.Rows(0).Item("Close1")) Then
                                    dtmCloseDate = CDate(Left(CStr(dtmCheckInDate), 10) & " " & Left(tblSchedule.Rows(0).Item("Close1"), 2) & ":" & Right(tblSchedule.Rows(0).Item("Close1"), 2) & ":00")
                                Else
                                    dtmCloseDate = CDate(Left(CStr(dtmCheckInDate), 10) & " 23:59:00")
                                End If

                                If DateDiff("h", dtmCheckInDate, dtmCloseDate) > intLoanPeriod Then
                                    dtmReturnDate = DateAdd("h", intLoanPeriod, dtmCheckInDate)
                                    If Not IsDBNull(tblSchedule.Rows(0).Item("Open2")) Then
                                        If Not tblSchedule.Rows(0).Item("Open2") = "" And tblSchedule.Rows(0).Item("Open2") > CStr(Hour(dtmReturnDate)).PadLeft(2, "0") & CStr(Hour(dtmReturnDate)) & CStr(Minute(dtmReturnDate)).PadLeft(2, "0") & CStr(Minute(dtmReturnDate)) Then
                                            If Not tblSchedule.Rows(0).Item("Close1") = "" Then
                                                dtmReturnDate = CDate(Left(CStr(dtmCheckInDate), 10) & " " & Left(tblSchedule.Rows(0).Item("Close1"), 2) & ":" & Right(tblSchedule.Rows(0).Item("Close1"), 2) & ":00")
                                            Else
                                                dtmReturnDate = CDate(Left(CStr(dtmCheckInDate), 10) & " " & Left(tblSchedule.Rows(0).Item("Open2"), 2) & ":" & Right(tblSchedule.Rows(0).Item("Open2"), 2) & ":00")
                                            End If
                                        End If
                                    End If
                                Else
                                    dtmReturnDate = dtmCloseDate
                                End If
                            End If
                        End If
                End Select
                CalculateCheckInDate = CStr(dtmReturnDate)
            Else
                CalculateCheckInDate = "NULL"
            End If
            'Catch ex As Exception
            '    strErrorMsg = ex.Message
            'Finally
            'End Try
        End Function

        ' GetPatronHoldInfor method
        ' Purpose: get patron' holding information
        ' Input: lngItemID, lngTransactionID
        ' Output: datatable result
        Public Function GetPatronHoldInfor() As DataTable
            Try
                objDLoanTransaction.CopyNumber = Trim(strCopyNumber)
                objDLoanTransaction.ItemID = lngItemID
                objDLoanTransaction.TransactionID = lngTransactionID
                GetPatronHoldInfor = objBCDBS.ConvertTable(objDLoanTransaction.GetPatronHoldInfor)
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' GetLocationByCopyNumber method
        ' Purpose: Get LocationID of the input copynumber
        ' Input: lngItemID, strCopyNumber
        ' Output: int value
        Public Function GetLocationByCopyNumber() As Integer
            Try
                objDLoanTransaction.CopyNumber = Trim(strCopyNumber)
                objDLoanTransaction.ItemID = lngItemID
                GetLocationByCopyNumber = objDLoanTransaction.GetLocationByCopyNumber
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' UpdatePatronHoldInfor method
        ' Purpose: Update holding information
        ' Input: strCopyNumber, lngItemID, strTimeOutDate, lngTransactionID
        Public Sub UpdatePatronHoldInfor()
            Try
                objDLoanTransaction.CopyNumber = Trim(strCopyNumber)
                objDLoanTransaction.ItemID = lngItemID
                objDLoanTransaction.TransactionID = lngTransactionID
                objDLoanTransaction.TimeOutDate = strTimeOutDate
                Call objDLoanTransaction.UpdatePatronHoldInfor()
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' GetLoanningInfor mehthod
        ' Purpose: Get the loanning patron and copy number infor
        Public Function GetOnLoanCopies() As DataTable
            Try
                objDLoanTransaction.ItemID = lngItemID
                GetOnLoanCopies = objBCDBS.ConvertTable(objDLoanTransaction.GetOnLoanCopies())
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetOnLoanCopiesOfPatron method
        ' Purpose: Get Onloan copies of the selected patron
        ' Input: PatronID
        ' Output: Datatable
        Public Function GetOnLoanCopiesOfPatron() As DataTable
            Dim tblResult As DataTable
            Dim inti As Integer
            Try
                objDLoanTransaction.PatronID = lngPatronID
                tblResult = objBCDBS.ConvertTable(objDLoanTransaction.GetOnLoanCopiesOfPatron, "TITLE", True)
                'tblResult = objDLoanTransaction.GetOnLoanCopiesOfPatron
                'If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                '    For inti = 0 To tblResult.Rows.Count - 1
                '        If tblResult.Rows(inti).Item("LoanMode") <> 2 Then
                '            If Not IsDBNull(tblResult.Rows(inti).Item("CHECKOUTDATE")) Then
                '                tblResult.Rows(inti).Item("CHECKOUTDATE") = objBCDBS.ConvertDate(tblResult.Rows(inti).Item("CHECKOUTDATE"))
                '            End If
                '            If Not IsDBNull(tblResult.Rows(inti).Item("DUEDATE")) AndAlso tblResult.Rows(inti).Item("DUEDATE").ToString <> "" Then
                '                tblResult.Rows(inti).Item("DUEDATE") = objBCDBS.ConvertDate(tblResult.Rows(inti).Item("DUEDATE"))
                '            End If
                '        Else
                '            If Not IsDBNull(tblResult.Rows(inti).Item("CHECKOUTDATE")) Then
                '                tblResult.Rows(inti).Item("CHECKOUTDATE") = objBCDBS.ConvertDate(tblResult.Rows(inti).Item("CHECKOUTDATE"), True)
                '            End If
                '            If Not IsDBNull(tblResult.Rows(inti).Item("DUEDATE")) AndAlso tblResult.Rows(inti).Item("DUEDATE") <> "" Then
                '                tblResult.Rows(inti).Item("DUEDATE") = objBCDBS.ConvertDate(tblResult.Rows(inti).Item("DUEDATE"), True)
                '            End If
                '        End If
                '    Next
                'End If
                GetOnLoanCopiesOfPatron = tblResult
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' GetPatronLocations method
        ' Purpose: Get valid locations of the selected patron
        ' Input: strPatronCode
        ' Output: datatable result
        Public Function GetPatronLocations(ByVal strPatronCode As String) As DataTable
            Try
                GetPatronLocations = objBCDBS.ConvertTable(objDLoanTransaction.GetPatronLocations(strPatronCode))
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        Public Function GetCheckInDate(ByVal strDateInputFrom As String, ByVal strDateInputTo As String) As DataTable
            Try
                GetCheckInDate = objBCDBS.ConvertTableKillChar(objBCDBS.ConvertTable(objDLoanTransaction.GetCheckInDate(objBCDBS.ConvertDateBack(strDateInputFrom, False), objBCDBS.ConvertDateBack(strDateInputTo, False))), "&", "-")
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        Public Function GetCheckInLocationName(ByVal strDateInputFrom As String, ByVal strDateInputTo As String) As DataTable
            Try
                GetCheckInLocationName = objBCDBS.ConvertTableKillChar(objBCDBS.ConvertTable(objDLoanTransaction.GetCheckInLocationName(objBCDBS.ConvertDateBack(strDateInputFrom, False), objBCDBS.ConvertDateBack(strDateInputTo, False))), "&", "-")
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        Public Function GetHoldingHistoryCheckInDate(ByVal strDateInputFrom As String, ByVal strDateInputTo As String) As DataTable
            Try
                objDLoanTransaction.OptItemID = intOptItemID
                GetHoldingHistoryCheckInDate = objBCDBS.ConvertTableKillChar(objBCDBS.ConvertTable(objDLoanTransaction.GetHoldingHistoryCheckInDate(objBCDBS.ConvertDateBack(strDateInputFrom, False), objBCDBS.ConvertDateBack(strDateInputTo, False))), "&", "-")
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        Public Function GetCheckOutDate(ByVal strDateInputFrom As String, ByVal strDateInputTo As String) As DataTable
            Try
                GetCheckOutDate = objBCDBS.ConvertTableKillChar(objBCDBS.ConvertTable(objDLoanTransaction.GetCheckOutDate(objBCDBS.ConvertDateBack(strDateInputFrom, False), objBCDBS.ConvertDateBack(strDateInputTo, False))), "&", "-")
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        Public Function GetCheckOutLocationName(ByVal strDateInputFrom As String, ByVal strDateInputTo As String) As DataTable
            Try
                GetCheckOutLocationName = objBCDBS.ConvertTableKillChar(objBCDBS.ConvertTable(objDLoanTransaction.GetCheckOutLocationName(objBCDBS.ConvertDateBack(strDateInputFrom, False), objBCDBS.ConvertDateBack(strDateInputTo, False))), "&", "-")
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        Public Function GetHoldingHistoryCheckOutDate(ByVal strDateInputFrom As String, ByVal strDateInputTo As String) As DataTable
            Try
                objDLoanTransaction.OptItemID = intOptItemID
                GetHoldingHistoryCheckOutDate = objBCDBS.ConvertTableKillChar(objBCDBS.ConvertTable(objDLoanTransaction.GetHoldingHistoryCheckOutDate(objBCDBS.ConvertDateBack(strDateInputFrom, False), objBCDBS.ConvertDateBack(strDateInputTo, False))), "&", "-")
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetCurrentLoanInfor method
        ' Purpose: Get information of the current transactions
        ' Input: strTransactionIDs
        ' Output: datatable result
        Public Function GetCurrentLoanInfor(ByVal strTransactionIDs As String, Optional ByVal strType As String = "") As DataTable
            'Try
            'objBCDBS.IsConvertDate = False
            If objDLoanTransaction.LoanMode <> 2 Then
                GetCurrentLoanInfor = objBCDBS.ConvertTable(objDLoanTransaction.GetCurrentLoanInfor(strTransactionIDs, strType), "TITLE")
            Else
                GetCurrentLoanInfor = objBCDBS.ConvertTable(objDLoanTransaction.GetCurrentLoanInfor(strTransactionIDs, strType), "TITLE", True)
            End If
            strErrorMsg = objDLoanTransaction.ErrorMsg
            intErrorCode = objDLoanTransaction.ErrorCode
            'Catch ex As Exception
            '    strErrorMsg = ex.Message
            'End Try
        End Function
        Public Function GetCurrentLoanInforToPrintCheckOut(ByVal strTransactionIDs As String, Optional ByVal strType As String = "Patron") As DataTable
            Try
                GetCurrentLoanInforToPrintCheckOut = objDLoanTransaction.GetCurrentLoanInforToPrintCheckOut(strTransactionIDs, strType)
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' UpdateCurrentLoanRecord method
        ' Purpose: Update information of the current transactions
        ' Input: strTransactionIDs
        Public Sub UpdateCurrentLoanRecord(ByVal strNote As String)
            Try
                objDLoanTransaction.TransactionID = TransactionID
                objDLoanTransaction.DueDate = objBCDBS.ConvertDateBack(strDueDate)
                objDLoanTransaction.CheckOutDate = objBCDBS.ConvertDateBack(strCheckOutDate)
                Call objDLoanTransaction.UpdateCurrentLoanRecord(Trim(objBCSP.ConvertItBack(strNote)))
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Sub UpdateCurrentLoanRecord(ByVal strNote As String, ByVal dbDepositFee As Double)
            Try
                objDLoanTransaction.TransactionID = TransactionID
                objDLoanTransaction.DueDate = objBCDBS.ConvertDateBack(strDueDate)
                Call objDLoanTransaction.UpdateCurrentLoanRecord(Trim(objBCSP.ConvertItBack(strNote)), dbDepositFee)
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub
        ' GetCurrentCheckInInfor method
        ' Purpose: Get information of the current checkin transactions
        ' Input: TransactionIDs
        ' Output: datatable result
        Public Function GetCurrentCheckInInfor(Optional ByVal strType As String = "") As DataTable
            Try
                objDLoanTransaction.TransactionIDs = strTransactionIDs
                GetCurrentCheckInInfor = objBCDBS.ConvertTable(objDLoanTransaction.GetCurrentCheckInInfor(strType), "TITLE")
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetFineFees method
        ' Purpose: Get fine & fees
        ' Input: TransactionIDs
        ' Output: datatable result
        Public Function GetFineFees() As DataTable
            'Try
            objDLoanTransaction.TransactionIDs = strTransactionIDs
            GetFineFees = objBCDBS.ConvertTable(objDLoanTransaction.GetFineFees)
            strErrorMsg = objDLoanTransaction.ErrorMsg
            intErrorCode = objDLoanTransaction.ErrorCode
            'Catch ex As Exception
            '    strErrorMsg = ex.Message
            'End Try
        End Function

        ' LogFineFees method
        ' Purpose: Log fine & fees
        ' Input: TransactionIDs
        ' Output: datatable result
        Public Sub LogFineFees()
            Try
                objDLoanTransaction.TransactionIDs = strTransactionIDs
                Call objDLoanTransaction.LogFineFees()
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' GetHoldRequest method
        ' Purpose: check hold request to send notice email
        ' Input: TransactionIDs
        ' Output: datatable result
        Public Function GetHoldRequest() As DataTable
            Try
                objDLoanTransaction.TransactionID = lngTransactionID
                GetHoldRequest = objBCDBS.ConvertTable(objDLoanTransaction.GetHoldRequest, "TITLE")
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' CalculateHoldDate method
        ' Purpose: Calculate hold date
        ' Input: strInDate
        ' Output: new HoldDate
        Public Function CalculateHoldDate(ByVal strDateTime As String, ByVal intPeriod As Int16) As String
            Dim dtmReturnDate As DateTime
            Dim tblSchedule As DataTable

            Try
                dtmReturnDate = DateAdd(DateInterval.Day, intPeriod, CDate(strDateTime))
                objBSchedule.OffDay = CStr(dtmReturnDate)
                tblSchedule = objBSchedule.GetSchedule(False)
                If Not tblSchedule Is Nothing Then
                    Do While Not tblSchedule.Rows.Count <= 0
                        dtmReturnDate = DateAdd(DateInterval.Day, 1, dtmReturnDate)
                        objBSchedule.OffDay = CStr(dtmReturnDate)
                        tblSchedule = objBSchedule.GetSchedule(False)
                    Loop
                End If
                Return CStr(dtmReturnDate)
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function


        ' Method: GetRenewInfor
        ' Purpose: Get information from Renews
        ' Input: UserID, Type, TypeValue
        ' Output: datatable 
        Public Function GetRenewInfor(ByVal bytType As Byte, ByVal strTypeVal As String, ByVal arrLabel As Object) As DataTable
            Dim tblTmp As New DataTable
            Dim intCount As Integer
            Dim strNote As String = ""
            Dim strDateView As String = ""

            Try
                objDLoanTransaction.UserID = intUserID
                strTypeVal = objBCSP.ConvertItBack(strTypeVal)
                tblTmp = objDLoanTransaction.GetRenewInfor(bytType, strTypeVal)
                tblTmp.Columns.Add("CheckReNew", GetType(Boolean))
                If tblTmp.Rows.Count = 1 Then
                    If Not IsDBNull(tblTmp.Rows(intCount).Item("DueDate")) Then
                        strNote = Me.CheckRenewRequest(tblTmp.Rows(intCount).Item("RenewCount"), tblTmp.Rows(intCount).Item("Renewals"), tblTmp.Rows(intCount).Item("DueDate"), tblTmp.Rows(intCount).Item("ItemID"), tblTmp.Rows(intCount).Item("TimeUnit"), tblTmp.Rows(intCount).Item("RenewalPeriod"), arrLabel)
                        tblTmp.Rows(intCount).Item("CheckReNew") = True
                        If strNote = "" Then
                            ' Me.Renew(tblTmp.Rows(intCount).Item("ID"), tblTmp.Rows(intCount).Item("RenewalPeriod"), tblTmp.Rows(intCount).Item("TimeUnit"), "")
                        Else
                            tblTmp.Rows(intCount).Item("strNote") = "<font color='red'>" & strNote & "</font>"
                            If strNote = arrLabel(1) Then
                                tblTmp.Rows(intCount).Item("CheckReNew") = False
                            End If
                            strDateView = objBCDBS.ConvertDate(tblTmp.Rows(intCount).Item("CheckOutDate")) & " - "
                            'strDateView = strDateView & " " & CStr(Hour(tblTmp.Rows(intCount).Item("CheckOutDate"))).PadLeft(2, "0") & ":" & CStr(Minute(tblTmp.Rows(intCount).Item("CheckOutDate"))).PadLeft(2, "0") & " - "
                            strDateView = strDateView & objBCDBS.ConvertDate(tblTmp.Rows(intCount).Item("DueDate"))
                            'strDateView = strDateView & " " & CStr(Hour(tblTmp.Rows(intCount).Item("DueDate"))).PadLeft(2, "0") & ":" & CStr(Minute(tblTmp.Rows(intCount).Item("DueDate"))).PadLeft(2, "0")
                            tblTmp.Rows(intCount).Item("TimeHold") = strDateView
                        End If
                    End If
                Else
                    For intCount = 0 To tblTmp.Rows.Count - 1
                        If Not IsDBNull(tblTmp.Rows(intCount).Item("DueDate")) Then
                            tblTmp.Rows(intCount).Item("CheckReNew") = True
                            strNote = Me.CheckRenewRequest(tblTmp.Rows(intCount).Item("RenewCount"), tblTmp.Rows(intCount).Item("Renewals"), tblTmp.Rows(intCount).Item("DueDate"), tblTmp.Rows(intCount).Item("ItemID"), tblTmp.Rows(intCount).Item("TimeUnit"), tblTmp.Rows(intCount).Item("RenewalPeriod"), arrLabel)

                            If strNote = arrLabel(1) Then
                                tblTmp.Rows(intCount).Item("CheckReNew") = False
                            End If
                            tblTmp.Rows(intCount).Item("strNote") = "<font color='red'>" & strNote & "</font>"
                            strDateView = objBCDBS.ConvertDate(tblTmp.Rows(intCount).Item("CheckOutDate")) & " - "
                            'strDateView = strDateView & " " & CStr(Hour(tblTmp.Rows(intCount).Item("CheckOutDate"))).PadLeft(2, "0") & ":" & CStr(Minute(tblTmp.Rows(intCount).Item("CheckOutDate"))).PadLeft(2, "0") & " - "
                            strDateView = strDateView & objBCDBS.ConvertDate(tblTmp.Rows(intCount).Item("DueDate"))
                            'strDateView = strDateView & " " & CStr(Hour(tblTmp.Rows(intCount).Item("DueDate"))).PadLeft(2, "0") & ":" & CStr(Minute(tblTmp.Rows(intCount).Item("DueDate"))).PadLeft(2, "0")
                            tblTmp.Rows(intCount).Item("TimeHold") = strDateView

                        End If
                    Next intCount
                End If

               

                GetRenewInfor = objBCDBS.ConvertTable(tblTmp, "Content")
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        ' Purpose: RenewItems
        ' Input: intLoanID + bytAddTime + bytTimeUnit
        Public Sub Renew(ByVal intLoanID As Integer, ByVal bytAddTime As Byte, ByVal bytTimeUnit As Byte, ByVal strFixedDueDate As String)
            strFixedDueDate = objBCDBS.ConvertDateBack(strFixedDueDate)
            objDLoanTransaction.Renew(intLoanID, bytAddTime, bytTimeUnit, strFixedDueDate)
        End Sub

        ' Purpose: Check Renew Request 
        ' Input: 
        ' Out : String status of checked
        Public Function CheckRenewRequest(ByVal intNoTurn As Integer, ByVal intMaxTurn As Integer, ByVal dtmCIDate As DateTime, ByVal intItemID As Integer, ByVal bytTimeUnit As Byte, ByVal intRenewalPeriod As Integer, ByVal arrLabel As Object) As String
            Dim tblTmp As New DataTable
            Dim strRet As String = ""
            If bytTimeUnit = 1 Then
                If intNoTurn >= intMaxTurn And intMaxTurn >= 0 Then
                    strRet = arrLabel(5)
                ElseIf DateDiff("d", Now, dtmCIDate) < 0 Then
                    strRet = arrLabel(4)
                ElseIf DateDiff("d", Now, dtmCIDate) >= intRenewalPeriod Then
                    strRet = arrLabel(1)
                End If
            Else
                If intNoTurn >= intMaxTurn And intMaxTurn >= 0 Then
                    strRet = arrLabel(5)
                ElseIf DateDiff("h", Now, dtmCIDate) < 0 Then
                    strRet = arrLabel(4)
                ElseIf DateDiff("h", Now, dtmCIDate) >= 1 Then
                    strRet = arrLabel(1)
                End If
            End If
            objDHoldTransaction.ItemID = intItemID
            tblTmp = objDHoldTransaction.GetHoldingByItemID
            If tblTmp.Rows.Count > 0 Then
                strRet = strRet & "<BR>" & arrLabel(2)
            End If
            CheckRenewRequest = strRet
        End Function

        Public Sub CreateLocationCheckOutStatistic(Optional fromCheckOutDate As DateTime? = Nothing,
                                                    Optional toCheckOutDate As DateTime? = Nothing,
                                                    Optional offset As Integer? = Nothing,
                                                    Optional take As Integer? = Nothing)
            Try
                Dim intRowIndex As Integer
                Dim intTotalRecords As Integer
                Dim tblData As DataTable

                Try
                    Dim dt As DateTime
                    If fromCheckOutDate IsNot Nothing Then
                        dt = fromCheckOutDate
                        fromCheckOutDate = New DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0)
                    End If
                    If toCheckOutDate IsNot Nothing Then
                        dt = toCheckOutDate
                        toCheckOutDate = New DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59)
                    End If
                    objDLoanTransaction.LocationID = LocationID
                    objDLoanTransaction.LoanMode = LoanMode
                    objDLoanTransaction.OptItemID = intOptItemID
                    tblData = objDLoanTransaction.CreateLocationCheckOutStatistic(fromCheckOutDate, toCheckOutDate, offset, take)

                    If Not tblData Is Nothing Then
                        arrData = Nothing
                        If tblData.Rows.Count > 0 Then
                            intTotalRecords = tblData.Rows.Count
                            ReDim arrData(intTotalRecords - 1)
                            ReDim arrLabel(intTotalRecords - 1)
                            For intRowIndex = 0 To intTotalRecords - 1
                                arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("CountTotal")
                                arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("LocationName")
                            Next
                        End If
                    End If
                    strErrorMsg = objDLoanTransaction.ErrorMsg
                    intErrorCode = objDLoanTransaction.ErrorCode
                Catch ex As Exception
                    strErrorMsg = ex.Message
                Finally
                End Try
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Function CreateLocationCheckOutStatisticDetail(ByRef total As Integer,
                                                    Optional fromCheckOutDate As DateTime? = Nothing,
                                                    Optional toCheckOutDate As DateTime? = Nothing,
                                                    Optional offset As Integer? = Nothing,
                                                    Optional take As Integer? = Nothing) As DataTable
            Try
                objDLoanTransaction.OptItemID = intOptItemID
                objDLoanTransaction.LocationID = LocationID
                objDLoanTransaction.LoanMode = LoanMode
                CreateLocationCheckOutStatisticDetail = objDLoanTransaction.CreateLocationCheckOutStatisticDetail(total, fromCheckOutDate, toCheckOutDate, offset, take)
                strErrorMsg = objDLoanTransaction.ErrorMsg
                intErrorCode = objDLoanTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
                CreateLocationCheckOutStatisticDetail = Nothing
            Finally
            End Try
        End Function

        Public Sub CreateLocationCheckIn(ByVal strDateInputFrom As String, ByVal strDateInputTo As String)
            Try
                Dim intRowIndex As Integer
                Dim intTotalRecords As Integer
                Dim tblData As DataTable

                Try
                    objDLoanTransaction.LocationID = LocationID
                    objDLoanTransaction.OptItemID = intOptItemID

                    If strDateInputFrom <> "" Then strDateInputFrom = objBCDBS.ConvertDateBack(strDateInputFrom + " 00:00:00")
                    If strDateInputTo <> "" Then strDateInputTo = objBCDBS.ConvertDateBack(strDateInputTo + " 23:59:59")

                    tblData = objDLoanTransaction.CreateLocationCheckIn(strDateInputFrom, strDateInputTo)

                    If Not tblData Is Nothing Then
                        arrData = Nothing
                        If tblData.Rows.Count > 0 Then
                            intTotalRecords = tblData.Rows.Count
                            ReDim arrData(intTotalRecords - 1)
                            ReDim arrLabel(intTotalRecords - 1)
                            For intRowIndex = 0 To intTotalRecords - 1
                                arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("CountTotal")
                                arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("LocationName")
                            Next
                        End If
                    End If
                    strErrorMsg = objDLoanTransaction.ErrorMsg
                    intErrorCode = objDLoanTransaction.ErrorCode
                Catch ex As Exception
                    strErrorMsg = ex.Message
                Finally
                End Try
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub


        Public Function GetItemView(ByVal strDateFrom As String, ByVal strDateTo As String) As DataTable
            Try
                Dim intRowIndex As Integer
                Dim intTotalRecords As Integer
                Dim tblData As DataTable

                Try
                    If strDateFrom <> "" Then strDateFrom = objBCDBS.ConvertDateBack(strDateFrom + " 00:00:00")
                    If strDateTo <> "" Then strDateTo = objBCDBS.ConvertDateBack(strDateTo + " 23:59:59")
                    tblData = objDLoanTransaction.GetItemView(strDateFrom, strDateTo)

                    If Not tblData Is Nothing Then
                        arrData = Nothing
                        If tblData.Rows.Count > 0 Then
                            intTotalRecords = tblData.Rows.Count
                            ReDim arrData(intTotalRecords - 1)
                            ReDim arrLabel(intTotalRecords - 1)
                            For intRowIndex = 0 To intTotalRecords - 1
                                arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("CountView")
                                arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("Label")
                            Next
                        End If
                    End If
                    strErrorMsg = objDLoanTransaction.ErrorMsg
                    intErrorCode = objDLoanTransaction.ErrorCode
                Catch ex As Exception
                    strErrorMsg = ex.Message
                Finally
                End Try
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        Public Function GetItemViewByMonth(Optional ByVal intYear As Integer = 0) As DataTable
            Try
                Dim intRowIndex As Integer
                Dim intTotalRecords As Integer
                Dim tblData As DataTable

                Try
                    tblData = objDLoanTransaction.GetItemViewByMonth(intYear)

                    If Not tblData Is Nothing Then
                        arrData = Nothing
                        If tblData.Rows.Count > 0 Then
                            intTotalRecords = tblData.Rows.Count
                            ReDim arrData(intTotalRecords - 1)
                            ReDim arrLabel(intTotalRecords - 1)
                            For intRowIndex = 0 To intTotalRecords - 1
                                arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("CountView")
                                arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("Label")
                            Next
                        End If
                    End If
                    strErrorMsg = objDLoanTransaction.ErrorMsg
                    intErrorCode = objDLoanTransaction.ErrorCode
                Catch ex As Exception
                    strErrorMsg = ex.Message
                Finally
                End Try
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        Public Function GetItemViewByYear(Optional ByVal intYearFrom As Integer = 0, Optional ByVal intYearTo As Integer = 0) As DataTable
            Try
                Dim intRowIndex As Integer
                Dim intTotalRecords As Integer
                Dim tblData As DataTable

                Try
                    tblData = objDLoanTransaction.GetItemViewByYear(intYearFrom, intYearTo)

                    If Not tblData Is Nothing Then
                        arrData = Nothing
                        If tblData.Rows.Count > 0 Then
                            intTotalRecords = tblData.Rows.Count
                            ReDim arrData(intTotalRecords - 1)
                            ReDim arrLabel(intTotalRecords - 1)
                            For intRowIndex = 0 To intTotalRecords - 1
                                arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("CountView")
                                arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("Label")
                            Next
                        End If
                    End If
                    strErrorMsg = objDLoanTransaction.ErrorMsg
                    intErrorCode = objDLoanTransaction.ErrorCode
                Catch ex As Exception
                    strErrorMsg = ex.Message
                Finally
                End Try
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        Public Function GetItemViewByDay(Optional ByVal intMonth As Integer = 0, Optional ByVal intYear As Integer = 0) As DataTable
            Try
                Dim intRowIndex As Integer
                Dim intTotalRecords As Integer
                Dim tblData As DataTable

                Try
                    tblData = objDLoanTransaction.GetItemViewByDay(intMonth, intYear)

                    If Not tblData Is Nothing Then
                        arrData = Nothing
                        If tblData.Rows.Count > 0 Then
                            intTotalRecords = tblData.Rows.Count
                            ReDim arrData(intTotalRecords - 1)
                            ReDim arrLabel(intTotalRecords - 1)
                            For intRowIndex = 0 To intTotalRecords - 1
                                arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("CountView")
                                arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("Label")
                            Next
                        End If
                    End If
                    strErrorMsg = objDLoanTransaction.ErrorMsg
                    intErrorCode = objDLoanTransaction.ErrorCode
                Catch ex As Exception
                    strErrorMsg = ex.Message
                Finally
                End Try
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        Public Function GetItemViewByWeek(Optional ByVal intWeekFrom As Integer = 0, Optional ByVal intWeekTo As Integer = 0, Optional ByVal intYear As Integer = 0) As DataTable
            Try
                Dim intRowIndex As Integer
                Dim intTotalRecords As Integer
                Dim tblData As DataTable

                Try
                    tblData = objDLoanTransaction.GetItemViewByWeek(intWeekFrom, intWeekTo, intYear)

                    If Not tblData Is Nothing Then
                        arrData = Nothing
                        If tblData.Rows.Count > 0 Then
                            intTotalRecords = tblData.Rows.Count
                            ReDim arrData(intTotalRecords - 1)
                            ReDim arrLabel(intTotalRecords - 1)
                            For intRowIndex = 0 To intTotalRecords - 1
                                arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("CountView")
                                arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("Label")
                            Next
                        End If
                    End If
                    strErrorMsg = objDLoanTransaction.ErrorMsg
                    intErrorCode = objDLoanTransaction.ErrorCode
                Catch ex As Exception
                    strErrorMsg = ex.Message
                Finally
                End Try
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetItemDownLoad(ByVal strDateFrom As String, ByVal strDateTo As String, Optional ByVal intTypeStatic As Integer = 0) As DataTable
            Try
                Dim intRowIndex As Integer
                Dim intTotalRecords As Integer
                Dim tblData As DataTable

                Try
                    If strDateFrom <> "" Then strDateFrom = objBCDBS.ConvertDateBack(strDateFrom + " 00:00:00")
                    If strDateTo <> "" Then strDateTo = objBCDBS.ConvertDateBack(strDateTo + " 23:59:59")
                    tblData = objDLoanTransaction.GetItemDownLoad(strDateFrom, strDateTo, intTypeStatic)

                    If Not tblData Is Nothing Then
                        arrData = Nothing
                        If tblData.Rows.Count > 0 Then
                            intTotalRecords = tblData.Rows.Count
                            ReDim arrData(intTotalRecords - 1)
                            ReDim arrLabel(intTotalRecords - 1)
                            For intRowIndex = 0 To intTotalRecords - 1
                                arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("CountDownLoad")
                                arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("Label")
                            Next
                        End If
                    End If
                    strErrorMsg = objDLoanTransaction.ErrorMsg
                    intErrorCode = objDLoanTransaction.ErrorCode
                Catch ex As Exception
                    strErrorMsg = ex.Message
                Finally
                End Try
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        Public Function GetItemDownLoadByMonth(Optional ByVal intYear As Integer = 0, Optional ByVal intTypeStatic As Integer = 0) As DataTable
            Try
                Dim intRowIndex As Integer
                Dim intTotalRecords As Integer
                Dim tblData As DataTable

                Try
                    tblData = objDLoanTransaction.GetItemDownLoadByMonth(intYear, intTypeStatic)

                    If Not tblData Is Nothing Then
                        arrData = Nothing
                        If tblData.Rows.Count > 0 Then
                            intTotalRecords = tblData.Rows.Count
                            ReDim arrData(intTotalRecords - 1)
                            ReDim arrLabel(intTotalRecords - 1)
                            For intRowIndex = 0 To intTotalRecords - 1
                                arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("CountDownLoad")
                                arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("Label")
                            Next
                        End If
                    End If
                    strErrorMsg = objDLoanTransaction.ErrorMsg
                    intErrorCode = objDLoanTransaction.ErrorCode
                Catch ex As Exception
                    strErrorMsg = ex.Message
                Finally
                End Try
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        Public Function GetItemDownLoadByYear(Optional ByVal intYearFrom As Integer = 0, Optional ByVal intYearTo As Integer = 0, Optional ByVal intTypeStatic As Integer = 0) As DataTable
            Try
                Dim intRowIndex As Integer
                Dim intTotalRecords As Integer
                Dim tblData As DataTable

                Try
                    tblData = objDLoanTransaction.GetItemDownLoadByYear(intYearFrom, intYearTo, intTypeStatic)

                    If Not tblData Is Nothing Then
                        arrData = Nothing
                        If tblData.Rows.Count > 0 Then
                            intTotalRecords = tblData.Rows.Count
                            ReDim arrData(intTotalRecords - 1)
                            ReDim arrLabel(intTotalRecords - 1)
                            For intRowIndex = 0 To intTotalRecords - 1
                                arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("CountDownLoad")
                                arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("Label")
                            Next
                        End If
                    End If
                    strErrorMsg = objDLoanTransaction.ErrorMsg
                    intErrorCode = objDLoanTransaction.ErrorCode
                Catch ex As Exception
                    strErrorMsg = ex.Message
                Finally
                End Try
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        Public Function GetItemDownLoadByDay(Optional ByVal intMonth As Integer = 0, Optional ByVal intYear As Integer = 0, Optional ByVal intTypeStatic As Integer = 0) As DataTable
            Try
                Dim intRowIndex As Integer
                Dim intTotalRecords As Integer
                Dim tblData As DataTable

                Try
                    tblData = objDLoanTransaction.GetItemDownLoadByDay(intMonth, intYear, intTypeStatic)

                    If Not tblData Is Nothing Then
                        arrData = Nothing
                        If tblData.Rows.Count > 0 Then
                            intTotalRecords = tblData.Rows.Count
                            ReDim arrData(intTotalRecords - 1)
                            ReDim arrLabel(intTotalRecords - 1)
                            For intRowIndex = 0 To intTotalRecords - 1
                                arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("CountDownLoad")
                                arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("Label")
                            Next
                        End If
                    End If
                    strErrorMsg = objDLoanTransaction.ErrorMsg
                    intErrorCode = objDLoanTransaction.ErrorCode
                Catch ex As Exception
                    strErrorMsg = ex.Message
                Finally
                End Try
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        Public Function GetItemDownLoadByWeek(Optional ByVal intWeekFrom As Integer = 0, Optional ByVal intWeekTo As Integer = 0, Optional ByVal intYear As Integer = 0, Optional ByVal intTypeStatic As Integer = 0) As DataTable
            Try
                Dim intRowIndex As Integer
                Dim intTotalRecords As Integer
                Dim tblData As DataTable

                Try
                    tblData = objDLoanTransaction.GetItemDownLoadByWeek(intWeekFrom, intWeekTo, intYear, intTypeStatic)

                    If Not tblData Is Nothing Then
                        arrData = Nothing
                        If tblData.Rows.Count > 0 Then
                            intTotalRecords = tblData.Rows.Count
                            ReDim arrData(intTotalRecords - 1)
                            ReDim arrLabel(intTotalRecords - 1)
                            For intRowIndex = 0 To intTotalRecords - 1
                                arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("CountDownLoad")
                                arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("Label")
                            Next
                        End If
                    End If
                    strErrorMsg = objDLoanTransaction.ErrorMsg
                    intErrorCode = objDLoanTransaction.ErrorCode
                Catch ex As Exception
                    strErrorMsg = ex.Message
                Finally
                End Try
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            If isDisposing Then
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBSchedule Is Nothing Then
                    objBSchedule.Dispose(True)
                    objBSchedule = Nothing
                End If
                If Not objBLoanType Is Nothing Then
                    objBLoanType.Dispose(True)
                    objBLoanType = Nothing
                End If
                If Not objDLoanTransaction Is Nothing Then
                    objDLoanTransaction.Dispose(True)
                    objDLoanTransaction = Nothing
                End If
                If Not objBCommonChart Is Nothing Then
                    objBCommonChart.Dispose(True)
                    objBCommonChart = Nothing
                End If
                If Not objDHoldTransaction Is Nothing Then
                    objDHoldTransaction.Dispose(True)
                    objDHoldTransaction = Nothing
                End If
            End If
            MyBase.Dispose(True)
            Me.Dispose()
        End Sub
    End Class
End Namespace