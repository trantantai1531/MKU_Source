Imports System.Collections.Generic

Namespace eMicLibAdmin.BusinessRules.Circulation
    Public Class clsBDHVLStatistic
        Inherits clsBBase
        ''' <summary>
        ''' Hình thức mượn
        ''' 0 - Tất cả
        ''' 1 - Về nhà
        ''' 2 - Tại chỗ
        ''' </summary>
        ''' <returns></returns>
        Public Property LoanMode() As Integer

        ''' <summary>
        ''' Dạng tư liệu lưu thông
        ''' </summary>
        ''' <returns></returns>
        Public Property LoanType() As Integer

        Public Property Location() As Integer

        ''' <summary>
        ''' 0 - Theo đầu ấn phẩm
        ''' 1 - Theo bản ấn phẩm
        ''' 2 - Theo bạn đọc
        ''' </summary>
        ''' <returns></returns>
        Public Property StatOption() As Integer

        'Data Access
        Dim objDDHVLStatistic As New clsDDHVLStatistic

        'Constructor

        Public Sub Initialize()
            'Initialize objDDHVLStatistic
            objDDHVLStatistic.DBServer = DBServer
            objDDHVLStatistic.ConnectionString = ConnectionString
            Call objDDHVLStatistic.Initialize()
        End Sub

        'Utility

        ''' <summary>
        ''' Only get first content by symbol ignored remaining.
        ''' </summary>
        ''' <param name="content"></param>
        ''' <param name="symbol"></param>
        ''' <returns></returns>
        Public Shared Function GetLibFieldContent(ByVal content As String, ByVal symbol As String) As String
            If content.Contains("$" + symbol) Then
                Dim split() As String = content.Split(New Char() {"$"})
                For Each iSplit As String In split
                    If Not String.IsNullOrEmpty(iSplit) AndAlso iSplit(0) = symbol.ToString() Then
                        Return iSplit.Substring(1, iSplit.Length - 1).Trim()
                    End If
                Next
            End If
            Return ""
        End Function

        Public Function ConvertMinDateTime(ByVal str As String) As DateTime?
            Return ConvertDateTimeBySpecifiedTime(str, 0, 0, 0)
        End Function

        Public Function ConvertMaxDateTime(ByVal str As String) As DateTime?
            Return ConvertDateTimeBySpecifiedTime(str, 23, 59, 59)
        End Function

        Public Function ConvertDateTimeBySpecifiedTime(
                                                        ByVal str As String,
                                                        Optional hour As Integer = 0,
                                                        Optional minute As Integer = 0,
                                                        Optional second As Integer = 0
                                                        ) As DateTime?
            If str IsNot Nothing Then
                str = str.Trim()
                If Not str.Equals(String.Empty) Then
                    Dim dt As DateTime
                    dt = DateTime.Parse(str)
                    Return New DateTime(dt.Year, dt.Month, dt.Day, hour, minute, second)
                End If
            End If
            Return Nothing
        End Function

        Public Function ValidateStringOrNothing(ByVal str As String) As String
            If str IsNot Nothing Then
                str = str.Trim()
                If str = "" Then
                    Return Nothing
                End If
            End If
            Return str
        End Function

        ''' <summary>
        ''' Placeholder purpose!!!
        ''' </summary>
        ''' <param name="errorCode">0 if success -1 if unknow</param>
        ''' <param name="erroMsg"></param>
        Public Sub WriteLog(ByVal errorCode As Integer, Optional erroMsg As String = "")
        End Sub

        ''''''''''''''''''''''''' Mượn & Trả báo cáo [CheckOutIn]'''''''''''''''''''''''''''''''''''

        Public Function ConvertTableCheckOutIn(
                                              ByVal tblResult As DataTable,
                                              Optional isAddHeader As Boolean = False
                                              ) As DataTable
            If (Not IsNothing(tblResult)) AndAlso (tblResult.Rows.Count > 0) Then
                Dim tblConvert As New DataTable
                tblConvert.Columns.Add("STT")
                tblConvert.Columns.Add("Title")
                tblConvert.Columns.Add("CopyNumber")
                tblConvert.Columns.Add("MonLoai")
                tblConvert.Columns.Add("FullName")
                tblConvert.Columns.Add("PatronCode")
                tblConvert.Columns.Add("Mobile")
                tblConvert.Columns.Add("Email")
                tblConvert.Columns.Add("Facebook")
                tblConvert.Columns.Add("CheckOutDate")
                tblConvert.Columns.Add("CheckInDate")
                tblConvert.Columns.Add("CataloguerNameCheckOut")
                tblConvert.Columns.Add("CataloguerNameCheckIn")
                tblConvert.Columns.Add("LoanModeName")
                tblConvert.Columns.Add("Note")

                Dim intSTT As Integer = 1
                For Each row As DataRow In tblResult.Rows
                    Dim dtRow As DataRow = tblConvert.NewRow()
                    dtRow.Item("STT") = intSTT
                    dtRow.Item("Title") = GetLibFieldContent(row("Title").ToString(), "a")
                    dtRow.Item("CopyNumber") = row("CopyNumber")
                    dtRow.Item("MonLoai") = GetLibFieldContent(row("MonLoai").ToString(), "a")
                    dtRow.Item("FullName") = row("FullName")
                    dtRow.Item("PatronCode") = row("PatronCode")
                    dtRow.Item("Mobile") = row("Mobile")
                    dtRow.Item("Email") = row("Email")
                    dtRow.Item("Facebook") = row("Facebook")
                    dtRow.Item("CheckOutDate") = row("CheckOutDate")
                    dtRow.Item("CheckInDate") = row("CheckInDate")
                    dtRow.Item("CataloguerNameCheckOut") = row("CataloguerNameCheckOut")
                    dtRow.Item("CataloguerNameCheckIn") = row("CataloguerNameCheckIn")
                    dtRow.Item("LoanModeName") = row("LoanModeName")
                    dtRow.Item("Note") = row("Note")

                    tblConvert.Rows.Add(dtRow)
                    intSTT = intSTT + 1
                Next
                If isAddHeader Then
                    tblConvert.Rows.Add(
                            "STT",
                            "Nhan đề",
                            "Số ĐKCB",
                            "Môn loại",
                            "Họ và tên",
                            "Mã số thẻ",
                            "SĐT",
                            "Email",
                            "Facebook",
                            "Ngày mượn",
                            "Ngày trả",
                            "Nhân viên quét mượn",
                            "Nhân viên quét trả",
                            "Hình thức mượn",
                            "Ghi chú"
                        )
                End If
                tblResult = tblConvert
            End If
            Return tblResult
        End Function

        ''' <summary>
        ''' Lấy thông tin ấn phẩm đang mượn.
        ''' </summary>
        ''' <param name="locationID">0 for all or specified location id</param>
        ''' <param name="patronCode"></param>
        ''' <param name="copyNumber"></param>
        ''' <param name="itemCode"></param>
        ''' <param name="total"></param>
        ''' <param name="checkOutDateFrom"></param>
        ''' <param name="checkOutDateTo"></param>
        ''' <param name="checkInDateFrom"></param>
        ''' <param name="checkInDateTo"></param>
        ''' <param name="index">paging</param>
        ''' <param name="size">paging</param>
        ''' <param name="shouldConverted">Format text or Native Text($a,b,c ...)</param>
        ''' <param name="isAddHeader">When export</param>
        ''' <returns></returns>
        Public Function GetReportOnLoanCopy(
                                            ByVal locationID As Integer,
                                            ByVal patronCode As String,
                                            ByVal copyNumber As String,
                                            ByVal itemCode As String,
                                            ByRef total As Integer,
                                            Optional checkOutDateFrom As String = Nothing,
                                            Optional checkOutDateTo As String = Nothing,
                                            Optional checkInDateFrom As String = Nothing,
                                            Optional checkInDateTo As String = Nothing,
                                            Optional index As Integer? = Nothing,
                                            Optional size As Integer? = Nothing,
                                            Optional shouldConverted As Boolean = True,
                                            Optional isAddHeader As Boolean = False,
                                            Optional isOutputTotal As Boolean = False
                                            ) As DataTable
            Dim tblResult As DataTable = Nothing
            Try
                If index IsNot Nothing AndAlso size IsNot Nothing Then
                    index = index * size
                Else 'Make Data stable
                    index = Nothing
                    size = Nothing
                End If

                Dim dtCheckOutDateFrom As DateTime? = ConvertMinDateTime(checkOutDateFrom)
                Dim dtCheckOutDateTo As DateTime? = ConvertMaxDateTime(checkOutDateTo)
                Dim dtCheckInDateFrom As DateTime? = ConvertMinDateTime(checkInDateFrom)
                Dim dtCheckInDateTo As DateTime? = ConvertMaxDateTime(checkInDateTo)

                itemCode = ValidateStringOrNothing(itemCode)
                patronCode = ValidateStringOrNothing(patronCode)
                copyNumber = ValidateStringOrNothing(copyNumber)

                objDDHVLStatistic.LibID = LibID
                objDDHVLStatistic.UserID = UserID
                tblResult = objDDHVLStatistic.GetReportOnLoanCopy(
                                                    locationID,
                                                    patronCode,
                                                    copyNumber,
                                                    itemCode,
                                                    total,
                                                    dtCheckOutDateFrom,
                                                    dtCheckOutDateTo,
                                                    dtCheckInDateFrom,
                                                    dtCheckInDateTo,
                                                    index,
                                                    size,
                                                    isOutputTotal
                            )
                If shouldConverted Then
                    tblResult = ConvertTableCheckOutIn(tblResult, isAddHeader)
                End If

                If tblResult Is Nothing Then
                    WriteLog(objDDHVLStatistic.ErrorCode, objDDHVLStatistic.ErrorMsg)
                End If
            Catch ex As Exception
                WriteLog(ex.GetHashCode(), ex.Message)
            End Try
            Return tblResult
        End Function

        ''' <summary>
        ''' Lấy thông tin ấn phẩm từng mượn
        ''' </summary>
        ''' <param name="locationID">0 for all or specified location id</param>
        ''' <param name="patronCode"></param>
        ''' <param name="copyNumber"></param>
        ''' <param name="itemCode"></param>
        ''' <param name="total"></param>
        ''' <param name="checkOutDateFrom"></param>
        ''' <param name="checkOutDateTo"></param>
        ''' <param name="checkInDateFrom"></param>
        ''' <param name="checkInDateTo"></param>
        ''' <param name="index">paging</param>
        ''' <param name="size">paging</param>
        ''' <param name="shouldConverted">Format text or Native Text($a,b,c ...)</param>
        ''' <param name="isAddHeader">When export</param>
        ''' <returns></returns>
        Public Function GetReportLoanCopy(
                                            ByVal locationID As Integer,
                                            ByVal patronCode As String,
                                            ByVal copyNumber As String,
                                            ByVal itemCode As String,
                                            ByRef total As Integer,
                                            Optional checkOutDateFrom As String = Nothing,
                                            Optional checkOutDateTo As String = Nothing,
                                            Optional checkInDateFrom As String = Nothing,
                                            Optional checkInDateTo As String = Nothing,
                                            Optional index As Integer? = Nothing,
                                            Optional size As Integer? = Nothing,
                                            Optional shouldConverted As Boolean = True,
                                            Optional isAddHeader As Boolean = False,
                                            Optional isOutputTotal As Boolean = False
                                            ) As DataTable
            Dim tblResult As DataTable = Nothing
            Try
                If index IsNot Nothing AndAlso size IsNot Nothing Then
                    index = index * size
                Else 'Make Data stable
                    index = Nothing
                    size = Nothing
                End If

                Dim dtCheckOutDateFrom As DateTime? = ConvertMinDateTime(checkOutDateFrom)
                Dim dtCheckOutDateTo As DateTime? = ConvertMaxDateTime(checkOutDateTo)
                Dim dtCheckInDateFrom As DateTime? = ConvertMinDateTime(checkInDateFrom)
                Dim dtCheckInDateTo As DateTime? = ConvertMaxDateTime(checkInDateTo)
                itemCode = ValidateStringOrNothing(itemCode)
                patronCode = ValidateStringOrNothing(patronCode)
                copyNumber = ValidateStringOrNothing(copyNumber)

                objDDHVLStatistic.LibID = LibID
                objDDHVLStatistic.UserID = UserID
                tblResult = objDDHVLStatistic.GetReportLoanCopy(
                                                    locationID,
                                                    patronCode,
                                                    copyNumber,
                                                    itemCode,
                                                    total,
                                                    dtCheckOutDateFrom,
                                                    dtCheckOutDateTo,
                                                    dtCheckInDateFrom,
                                                    dtCheckInDateTo,
                                                    index,
                                                    size,
                                                    isOutputTotal
                            )
                If shouldConverted Then
                    tblResult = ConvertTableCheckOutIn(tblResult, isAddHeader)
                End If

                If tblResult Is Nothing Then
                    WriteLog(objDDHVLStatistic.ErrorCode, objDDHVLStatistic.ErrorMsg)
                End If
            Catch ex As Exception
                WriteLog(ex.GetHashCode(), ex.Message)
            End Try
            Return tblResult
        End Function

        '''''''''''''''''''''''''''''''''''''''''''''Thống kê theo thời gian''''''''''''''''''''''''''

        Public Function ConvertTableTime(
                                              ByVal tblResult As DataTable,
                                              Optional isAddHeader As Boolean = False
                                              ) As DataTable
            If (Not IsNothing(tblResult)) AndAlso (tblResult.Rows.Count > 0) Then
                Dim tblConvert As New DataTable
                tblConvert.Columns.Add("STT")
                tblConvert.Columns.Add("Title")
                tblConvert.Columns.Add("CopyNumber")
                tblConvert.Columns.Add("Author")
                tblConvert.Columns.Add("MonLoai")
                tblConvert.Columns.Add("FullName")
                tblConvert.Columns.Add("PatronCode")
                tblConvert.Columns.Add("Mobile")
                tblConvert.Columns.Add("Email")
                tblConvert.Columns.Add("Facebook")
                tblConvert.Columns.Add("CheckOutDate")
                tblConvert.Columns.Add("CataloguerNameCheckOut")
                tblConvert.Columns.Add("CheckInDate")
                tblConvert.Columns.Add("Location")
                tblConvert.Columns.Add("LoanModeName")
                tblConvert.Columns.Add("ItemType")
                tblConvert.Columns.Add("Note")

                Dim intSTT As Integer = 1
                For Each row As DataRow In tblResult.Rows
                    Dim dtRow As DataRow = tblConvert.NewRow()
                    dtRow.Item("STT") = intSTT
                    dtRow.Item("Title") = GetLibFieldContent(row("Title").ToString(), "a")
                    dtRow.Item("CopyNumber") = row("CopyNumber")
                    dtRow.Item("Author") = GetLibFieldContent(row("Author").ToString(), "a")
                    dtRow.Item("MonLoai") = GetLibFieldContent(row("MonLoai").ToString(), "a")
                    dtRow.Item("FullName") = row("FullName")
                    dtRow.Item("PatronCode") = row("PatronCode")
                    dtRow.Item("Mobile") = row("Mobile")
                    dtRow.Item("Email") = row("Email")
                    dtRow.Item("Facebook") = row("Facebook")
                    dtRow.Item("CheckOutDate") = row("CheckOutDate")
                    dtRow.Item("CataloguerNameCheckOut") = row("CataloguerNameCheckOut")
                    dtRow.Item("CheckInDate") = row("CheckInDate")
                    dtRow.Item("Location") = row("Location")
                    dtRow.Item("LoanModeName") = row("LoanModeName")
                    dtRow.Item("ItemType") = row("ItemType")
                    dtRow.Item("Note") = row("Note")

                    tblConvert.Rows.Add(dtRow)
                    intSTT = intSTT + 1
                Next
                If isAddHeader Then
                    tblConvert.Rows.Add(
                            "STT",
                            "Nhan đề",
                            "Số ĐKCB",
                            "Tác giả",
                            "Môn loại",
                            "Họ và tên",
                            "Mã số thẻ",
                            "SĐT",
                            "Email",
                            "Facebook",
                            "Ngày mượn",
                            "Nhân viên quét mượn",
                            "Ngày trả",
                            "Kho",
                            "Hình thức mượn",
                            "Kiểu tư liệu",
                            "Ghi chú"
                        )
                End If
                tblResult = tblConvert
            End If
            Return tblResult
        End Function

        ''' <summary>
        ''' Lấy thông tin thống kê số lượt ghi trả theo từng ngày của kho.
        ''' </summary>
        ''' <param name="locationID">0 for all or specified location id</param>
        ''' <param name="total">paging</param>
        ''' <param name="checkInDateFrom"></param>
        ''' <param name="checkInDateTo"></param>
        ''' <param name="index">paging</param>
        ''' <param name="size">paging</param>
        ''' <param name="isOutputTotal">Should get total entry or not (default is False which increase performance)</param>
        ''' <returns></returns>
        Public Function GetCheckInLocationStat(
                                            ByVal locationID As Integer,
                                            ByRef total As Integer,
                                            Optional checkInDateFrom As String = Nothing,
                                            Optional checkInDateTo As String = Nothing,
                                            Optional index As Integer? = Nothing,
                                            Optional size As Integer? = Nothing
                                            ) As KeyValuePair(Of String(), Integer())
            Dim tblResult As DataTable = Nothing
            Dim chartData As New KeyValuePair(Of String(), Integer())(Nothing, Nothing)
            Try
                If index IsNot Nothing AndAlso size IsNot Nothing Then
                    index = index * size
                Else 'Make Data stable
                    index = Nothing
                    size = Nothing
                End If

                Dim dtCheckInDateFrom As DateTime? = ConvertMinDateTime(checkInDateFrom)
                Dim dtCheckInDateTo As DateTime? = ConvertMaxDateTime(checkInDateTo)

                objDDHVLStatistic.LibID = LibID
                objDDHVLStatistic.UserID = UserID
                objDDHVLStatistic.StatOption = StatOption
                tblResult = objDDHVLStatistic.GetCheckInLocationStat(
                                                    locationID,
                                                    total,
                                                    dtCheckInDateFrom,
                                                    dtCheckInDateTo,
                                                    index,
                                                    size
                            )

                If tblResult Is Nothing Then
                    WriteLog(objDDHVLStatistic.ErrorCode, objDDHVLStatistic.ErrorMsg)
                Else
                    If tblResult.Rows.Count > 0 Then
                        Dim rowCount As Integer = tblResult.Rows.Count
                        Dim keys As String()
                        ReDim keys(rowCount - 1)
                        Dim values As Integer()
                        ReDim values(rowCount - 1)
                        For i As Integer = 0 To rowCount - 1
                            keys(i) = tblResult.Rows(i).Item("key")
                            values(i) = tblResult.Rows(i).Item("value")
                        Next
                        chartData = New KeyValuePair(Of String(), Integer())(keys, values)
                    End If
                End If
            Catch ex As Exception
                WriteLog(ex.GetHashCode(), ex.Message)
            End Try
            Return chartData
        End Function

        ''' <summary>
        ''' Lấy thông tin thống kê số lượt ghi mượn theo từng ngày của kho.
        ''' </summary>
        ''' <param name="locationID">0 for all or specified location id</param>
        ''' <param name="total">paging</param>
        ''' <param name="checkOutDateFrom"></param>
        ''' <param name="checkOutDateTo"></param>
        ''' <param name="index">paging</param>
        ''' <param name="size">paging</param>
        ''' <param name="isOutputTotal">Should get total entry or not (default is False which increase performance)</param>
        ''' <returns></returns>
        Public Function GetCheckOutLocationStat(
                                            ByVal locationID As Integer,
                                            ByRef total As Integer,
                                            Optional checkOutDateFrom As String = Nothing,
                                            Optional checkOutDateTo As String = Nothing,
                                            Optional index As Integer? = Nothing,
                                            Optional size As Integer? = Nothing
                                            ) As KeyValuePair(Of String(), Integer())
            Dim tblResult As DataTable = Nothing
            Dim chartData As New KeyValuePair(Of String(), Integer())(Nothing, Nothing)
            Try
                If index IsNot Nothing AndAlso size IsNot Nothing Then
                    index = index * size
                Else 'Make Data stable
                    index = Nothing
                    size = Nothing
                End If

                Dim dtCheckOutDateFrom As DateTime? = ConvertMinDateTime(checkOutDateFrom)
                Dim dtCheckOutDateTo As DateTime? = ConvertMaxDateTime(checkOutDateTo)

                objDDHVLStatistic.LibID = LibID
                objDDHVLStatistic.UserID = UserID
                objDDHVLStatistic.StatOption = StatOption
                objDDHVLStatistic.LoanMode = LoanMode
                tblResult = objDDHVLStatistic.GetCheckOutLocationStat(
                                                    locationID,
                                                    total,
                                                    dtCheckOutDateFrom,
                                                    dtCheckOutDateTo,
                                                    index,
                                                    size
                            )

                If tblResult Is Nothing Then
                    WriteLog(objDDHVLStatistic.ErrorCode, objDDHVLStatistic.ErrorMsg)
                Else
                    If tblResult.Rows.Count > 0 Then
                        Dim rowCount As Integer = tblResult.Rows.Count
                        Dim keys As String()
                        ReDim keys(rowCount - 1)
                        Dim values As Integer()
                        ReDim values(rowCount - 1)
                        For i As Integer = 0 To rowCount - 1
                            keys(i) = tblResult.Rows(i).Item("key")
                            values(i) = tblResult.Rows(i).Item("value")
                        Next
                        chartData = New KeyValuePair(Of String(), Integer())(keys, values)
                    End If
                End If
            Catch ex As Exception
                WriteLog(ex.GetHashCode(), ex.Message)
            End Try
            Return chartData
        End Function

        ''' <summary>
        ''' Lấy dữ liệu ghi trả theo từng ngày của kho.
        ''' </summary>
        ''' <param name="locationID">0 for all or specified location id</param>
        ''' <param name="total">paging</param>
        ''' <param name="checkInDateFrom"></param>
        ''' <param name="checkInDateTo"></param>
        ''' <param name="index">paging</param>
        ''' <param name="size">paging</param>
        ''' <returns></returns>
        Public Function GetCheckInLocation(
                                            ByVal locationID As Integer,
                                            ByRef total As Integer,
                                            Optional checkInDateFrom As String = Nothing,
                                            Optional checkInDateTo As String = Nothing,
                                            Optional index As Integer? = Nothing,
                                            Optional size As Integer? = Nothing,
                                            Optional shouldConverted As Boolean = True,
                                            Optional isAddHeader As Boolean = False
                                            ) As DataTable
            Dim tblResult As DataTable = Nothing
            Try
                If index IsNot Nothing AndAlso size IsNot Nothing Then
                    index = index * size
                End If

                Dim dtCheckInDateFrom As DateTime? = ConvertMinDateTime(checkInDateFrom)
                Dim dtCheckInDateTo As DateTime? = ConvertMaxDateTime(checkInDateTo)

                objDDHVLStatistic.LibID = LibID
                objDDHVLStatistic.UserID = UserID
                objDDHVLStatistic.StatOption = StatOption
                tblResult = objDDHVLStatistic.GetInformationAnnual(
                                                    True,
                                                    locationID,
                                                    total,
                                                    dtCheckInDateFrom,
                                                    dtCheckInDateTo,
                                                    index,
                                                    size
                            )

                If shouldConverted Then
                    tblResult = ConvertTableTime(tblResult, isAddHeader)
                End If

                If tblResult Is Nothing Then
                    WriteLog(objDDHVLStatistic.ErrorCode, objDDHVLStatistic.ErrorMsg)
                End If
            Catch ex As Exception
                WriteLog(ex.GetHashCode(), ex.Message)
            End Try
            Return tblResult
        End Function

        ''' <summary>
        ''' Lấy dữ liệu ghi mượn theo từng ngày của kho.
        ''' </summary>
        ''' <param name="locationID">0 for all or specified location id</param>
        ''' <param name="total">paging</param>
        ''' <param name="checkOutDateFrom"></param>
        ''' <param name="checkOutDateTo"></param>
        ''' <param name="index">paging</param>
        ''' <param name="size">paging</param>
        ''' <returns></returns>
        Public Function GetCheckOutLocation(
                                            ByVal locationID As Integer,
                                            ByRef total As Integer,
                                            Optional checkOutDateFrom As String = Nothing,
                                            Optional checkOutDateTo As String = Nothing,
                                            Optional index As Integer? = Nothing,
                                            Optional size As Integer? = Nothing,
                                            Optional shouldConverted As Boolean = True,
                                            Optional isAddHeader As Boolean = False
                                            ) As DataTable
            Dim tblResult As DataTable = Nothing
            Try
                If index IsNot Nothing AndAlso size IsNot Nothing Then
                    index = index * size
                End If

                Dim dtCheckOutDateFrom As DateTime? = ConvertMinDateTime(checkOutDateFrom)
                Dim dtCheckOutDateTo As DateTime? = ConvertMaxDateTime(checkOutDateTo)

                objDDHVLStatistic.LibID = LibID
                objDDHVLStatistic.UserID = UserID
                objDDHVLStatistic.StatOption = StatOption
                objDDHVLStatistic.LoanMode = LoanMode
                tblResult = objDDHVLStatistic.GetInformationAnnual(
                                                    True,
                                                    locationID,
                                                    total,
                                                    dtCheckOutDateFrom,
                                                    dtCheckOutDateTo,
                                                    index,
                                                    size
                            )

                If shouldConverted Then
                    tblResult = ConvertTableTime(tblResult, isAddHeader)
                End If

                If tblResult Is Nothing Then
                    WriteLog(objDDHVLStatistic.ErrorCode, objDDHVLStatistic.ErrorMsg)
                End If
            Catch ex As Exception
                WriteLog(ex.GetHashCode(), ex.Message)
            End Try
            Return tblResult
        End Function


        ''' <summary>
        ''' Thống kê ghi mượn hàng năm
        ''' </summary>
        ''' <param name="isHistory">
        ''' True if History (Loan History -> từng mượn)
        ''' False if not History ( Current Loan -> đang mượn)
        ''' </param>
        ''' <param name="locationID">0 for all or specified location id</param>
        ''' <param name="total"></param>
        ''' <param name="checkOutDateFrom"></param>
        ''' <param name="checkOutDateTo"></param>
        ''' <param name="index"></param>
        ''' <param name="size"></param>
        ''' <param name="isOutputTotal">Should get total entry or not (default is False which increase performance)</param>
        ''' <returns></returns>
        Public Function GetAnnualStat(
                                    ByVal isHistory As Boolean,
                                    ByVal locationID As Integer,
                                    ByRef total As Integer,
                                    Optional checkOutDateFrom As String = Nothing,
                                    Optional checkOutDateTo As String = Nothing,
                                    Optional index As Integer? = Nothing,
                                    Optional size As Integer? = Nothing,
                                    Optional isOutputTotal As Boolean = False
                                     ) As KeyValuePair(Of String(), Integer())
            Dim tblResult As DataTable = Nothing
            Dim chartData As New KeyValuePair(Of String(), Integer())(Nothing, Nothing)
            Try
                If index IsNot Nothing AndAlso size IsNot Nothing Then
                    index = index * size
                Else 'Make Data stable
                    index = Nothing
                    size = Nothing
                End If

                Dim dtCheckOutDateFrom As DateTime? = ConvertMinDateTime(checkOutDateFrom)
                Dim dtCheckOutDateTo As DateTime? = ConvertMaxDateTime(checkOutDateTo)

                objDDHVLStatistic.LibID = LibID
                objDDHVLStatistic.UserID = UserID
                objDDHVLStatistic.StatOption = StatOption
                objDDHVLStatistic.LoanMode = LoanMode
                tblResult = objDDHVLStatistic.GetAnnualStat(
                                                    isHistory,
                                                    locationID,
                                                    total,
                                                    dtCheckOutDateFrom,
                                                    dtCheckOutDateTo,
                                                    index,
                                                    size,
                                                    isOutputTotal
                            )

                If tblResult Is Nothing Then
                    WriteLog(objDDHVLStatistic.ErrorCode, objDDHVLStatistic.ErrorMsg)
                Else
                    If tblResult.Rows.Count > 0 Then
                        Dim rowCount As Integer = tblResult.Rows.Count
                        Dim keys As String()
                        ReDim keys(rowCount - 1)
                        Dim values As Integer()
                        ReDim values(rowCount - 1)
                        For i As Integer = 0 To rowCount - 1
                            keys(i) = tblResult.Rows(i).Item("key")
                            values(i) = tblResult.Rows(i).Item("value")
                        Next
                        chartData = New KeyValuePair(Of String(), Integer())(keys, values)
                    End If
                End If
            Catch ex As Exception
                WriteLog(ex.GetHashCode(), ex.Message)
            End Try
            Return chartData
        End Function

        ''' <summary>
        ''' Thống kê ghi mượn hàng tháng
        ''' </summary>
        ''' <param name="isHistory">
        ''' True if History (Loan History -> từng mượn)
        ''' False if not History ( Current Loan -> đang mượn)
        ''' </param>
        ''' <param name="locationID">0 for all or specified location id</param>
        ''' <param name="total"></param>
        ''' <param name="checkOutDateFrom"></param>
        ''' <param name="checkOutDateTo"></param>
        ''' <param name="index"></param>
        ''' <param name="size"></param>
        ''' <param name="isOutputTotal">Should get total entry or not (default is False which increase performance)</param>
        ''' <returns></returns>
        Public Function GetMonthStat(
                                    ByVal isHistory As Boolean,
                                    ByVal locationID As Integer,
                                    ByRef total As Integer,
                                    Optional checkOutDateFrom As String = Nothing,
                                    Optional checkOutDateTo As String = Nothing,
                                    Optional index As Integer? = Nothing,
                                    Optional size As Integer? = Nothing,
                                    Optional isOutputTotal As Boolean = False
                                     ) As KeyValuePair(Of String(), Integer())
            Dim tblResult As DataTable = Nothing
            Dim chartData As New KeyValuePair(Of String(), Integer())(Nothing, Nothing)
            Try
                If index IsNot Nothing AndAlso size IsNot Nothing Then
                    index = index * size
                Else 'Make Data stable
                    index = Nothing
                    size = Nothing
                End If

                Dim dtCheckOutDateFrom As DateTime? = ConvertMinDateTime(checkOutDateFrom)
                Dim dtCheckOutDateTo As DateTime? = ConvertMaxDateTime(checkOutDateTo)

                objDDHVLStatistic.LibID = LibID
                objDDHVLStatistic.UserID = UserID
                objDDHVLStatistic.StatOption = StatOption
                objDDHVLStatistic.LoanMode = LoanMode
                tblResult = objDDHVLStatistic.GetMonthStat(
                                                    isHistory,
                                                    locationID,
                                                    total,
                                                    dtCheckOutDateFrom,
                                                    dtCheckOutDateTo,
                                                    index,
                                                    size,
                                                    isOutputTotal
                            )

                If tblResult Is Nothing Then
                    WriteLog(objDDHVLStatistic.ErrorCode, objDDHVLStatistic.ErrorMsg)
                Else
                    If tblResult.Rows.Count > 0 Then
                        Dim rowCount As Integer = tblResult.Rows.Count
                        Dim keys As String()
                        ReDim keys(rowCount - 1)
                        Dim values As Integer()
                        ReDim values(rowCount - 1)
                        For i As Integer = 0 To rowCount - 1
                            keys(i) = tblResult.Rows(i).Item("key")
                            values(i) = tblResult.Rows(i).Item("value")
                        Next
                        chartData = New KeyValuePair(Of String(), Integer())(keys, values)
                    End If
                End If
            Catch ex As Exception
                WriteLog(ex.GetHashCode(), ex.Message)
            End Try
            Return chartData
        End Function

        ''' <summary>
        ''' Thống kê ghi mượn hàng ngày
        ''' </summary>
        ''' <param name="isHistory">
        ''' True if History (Loan History -> từng mượn)
        ''' False if not History ( Current Loan -> đang mượn)
        ''' </param>
        ''' <param name="locationID">0 for all or specified location id</param>
        ''' <param name="total"></param>
        ''' <param name="checkOutDateFrom"></param>
        ''' <param name="checkOutDateTo"></param>
        ''' <param name="index"></param>
        ''' <param name="size"></param>
        ''' <param name="isOutputTotal">Should get total entry or not (default is False which increase performance)</param>
        ''' <returns></returns>
        Public Function GetDayStat(
                                    ByVal isHistory As Boolean,
                                    ByVal locationID As Integer,
                                    ByRef total As Integer,
                                    Optional checkOutDateFrom As String = Nothing,
                                    Optional checkOutDateTo As String = Nothing,
                                    Optional index As Integer? = Nothing,
                                    Optional size As Integer? = Nothing,
                                    Optional isOutputTotal As Boolean = False
                                     ) As KeyValuePair(Of String(), Integer())
            Dim tblResult As DataTable = Nothing
            Dim chartData As New KeyValuePair(Of String(), Integer())(Nothing, Nothing)
            Try
                If index IsNot Nothing AndAlso size IsNot Nothing Then
                    index = index * size
                Else 'Make Data stable
                    index = Nothing
                    size = Nothing
                End If

                Dim dtCheckOutDateFrom As DateTime? = ConvertMinDateTime(checkOutDateFrom)
                Dim dtCheckOutDateTo As DateTime? = ConvertMaxDateTime(checkOutDateTo)

                objDDHVLStatistic.LibID = LibID
                objDDHVLStatistic.UserID = UserID
                objDDHVLStatistic.StatOption = StatOption
                objDDHVLStatistic.LoanMode = LoanMode
                tblResult = objDDHVLStatistic.GetDayStat(
                                                    isHistory,
                                                    locationID,
                                                    total,
                                                    dtCheckOutDateFrom,
                                                    dtCheckOutDateTo,
                                                    index,
                                                    size,
                                                    isOutputTotal
                            )

                If tblResult Is Nothing Then
                    WriteLog(objDDHVLStatistic.ErrorCode, objDDHVLStatistic.ErrorMsg)
                Else
                    If tblResult.Rows.Count > 0 Then
                        Dim rowCount As Integer = tblResult.Rows.Count
                        Dim keys As String()
                        ReDim keys(rowCount - 1)
                        Dim values As Integer()
                        ReDim values(rowCount - 1)
                        For i As Integer = 0 To rowCount - 1
                            keys(i) = tblResult.Rows(i).Item("key")
                            values(i) = tblResult.Rows(i).Item("value")
                        Next
                        chartData = New KeyValuePair(Of String(), Integer())(keys, values)
                    End If
                End If
            Catch ex As Exception
                WriteLog(ex.GetHashCode(), ex.Message)
            End Try
            Return chartData
        End Function

        ''' <summary>
        ''' Lấy dữ liệu ghi mượn
        ''' </summary>
        ''' <param name="isHistory">
        ''' True if History (Loan History -> từng mượn)
        ''' False if not History ( Current Loan -> đang mượn)
        ''' </param>
        ''' <param name="locationID">0 for all or specified location id</param>
        ''' <param name="total"></param>
        ''' <param name="checkOutDateFrom"></param>
        ''' <param name="checkOutDateTo"></param>
        ''' <param name="index"></param>
        ''' <param name="size"></param>
        ''' <param name="shouldConverted">Format text or Native Text($a,b,c ...)</param>
        ''' <param name="isAddHeader">When export</param>
        ''' <returns></returns>
        Public Function GetInformationAnnual(
                                ByVal isHistory As Boolean,
                                ByVal locationID As Integer,
                                ByRef total As Integer,
                                Optional checkOutDateFrom As String = Nothing,
                                Optional checkOutDateTo As String = Nothing,
                                Optional index As Integer? = Nothing,
                                Optional size As Integer? = Nothing,
                                Optional shouldConverted As Boolean = True,
                                Optional isAddHeader As Boolean = False
                                 ) As DataTable
            Dim tblResult As DataTable = Nothing
            Try
                If index IsNot Nothing AndAlso size IsNot Nothing Then
                    index = index * size
                Else 'Make Data stable
                    index = Nothing
                    size = Nothing
                End If

                Dim dtCheckOutDateFrom As DateTime? = ConvertMinDateTime(checkOutDateFrom)
                Dim dtCheckOutDateTo As DateTime? = ConvertMaxDateTime(checkOutDateTo)

                objDDHVLStatistic.LibID = LibID
                objDDHVLStatistic.UserID = UserID
                objDDHVLStatistic.StatOption = StatOption
                objDDHVLStatistic.LoanMode = LoanMode
                tblResult = objDDHVLStatistic.GetInformationAnnual(
                                                    isHistory,
                                                    locationID,
                                                    total,
                                                    dtCheckOutDateFrom,
                                                    dtCheckOutDateTo,
                                                    index,
                                                    size
                            )

                If shouldConverted Then
                    tblResult = ConvertTableTime(tblResult, isAddHeader)
                End If

                If tblResult Is Nothing Then
                    WriteLog(objDDHVLStatistic.ErrorCode, objDDHVLStatistic.ErrorMsg)
                End If
            Catch ex As Exception
                WriteLog(ex.GetHashCode(), ex.Message)
            End Try
            Return tblResult
        End Function

        ''' <summary>
        ''' Thống kê ghi mượn theo địa điểm
        ''' </summary>
        ''' <param name="isHistory">
        ''' True if History (Loan History -> từng mượn)
        ''' False if not History ( Current Loan -> đang mượn)
        ''' </param>
        ''' <param name="isLib">true if ids refer to LibID else LocID</param>
        ''' <param name="ids">IDs String</param>
        ''' <param name="total"></param>
        ''' <param name="checkOutDateFrom"></param>
        ''' <param name="checkOutDateTo"></param>
        ''' <param name="index"></param>
        ''' <param name="size"></param>
        ''' <param name="isOutputTotal">Should get total entry or not (default is False which increase performance)</param>
        ''' <returns></returns>
        Public Function GetHoldingPlaceStat(
                                    ByVal isHistory As Boolean,
                                    ByVal isLib As Boolean,
                                    ByVal locationID As Integer,
                                    ByVal ids As String,
                                    ByRef total As Integer,
                                    Optional checkOutDateFrom As String = Nothing,
                                    Optional checkOutDateTo As String = Nothing,
                                    Optional index As Integer? = Nothing,
                                    Optional size As Integer? = Nothing,
                                    Optional isOutputTotal As Boolean = False
                                     ) As KeyValuePair(Of String(), Integer())
            Dim tblResult As DataTable = Nothing
            Dim chartData As New KeyValuePair(Of String(), Integer())(Nothing, Nothing)
            Try
                If index IsNot Nothing AndAlso size IsNot Nothing Then
                    index = index * size
                Else 'Make Data stable
                    index = Nothing
                    size = Nothing
                End If

                Dim dtCheckOutDateFrom As DateTime? = ConvertMinDateTime(checkOutDateFrom)
                Dim dtCheckOutDateTo As DateTime? = ConvertMaxDateTime(checkOutDateTo)

                If ids IsNot Nothing Then
                    ids = ids.Trim()
                    If ids = "" Then
                        ids = Nothing
                    End If
                End If

                objDDHVLStatistic.LibID = LibID
                objDDHVLStatistic.UserID = UserID
                objDDHVLStatistic.StatOption = StatOption
                objDDHVLStatistic.LoanMode = LoanMode
                tblResult = objDDHVLStatistic.GetHoldingPlaceStat(
                                                    isHistory,
                                                    isLib,
                                                    ids,
                                                    locationID,
                                                    total,
                                                    dtCheckOutDateFrom,
                                                    dtCheckOutDateTo,
                                                    index,
                                                    size,
                                                    isOutputTotal
                            )

                If tblResult Is Nothing Then
                    WriteLog(objDDHVLStatistic.ErrorCode, objDDHVLStatistic.ErrorMsg)
                Else
                    If tblResult.Rows.Count > 0 Then
                        Dim rowCount As Integer = tblResult.Rows.Count
                        Dim keys As String()
                        ReDim keys(rowCount - 1)
                        Dim values As Integer()
                        ReDim values(rowCount - 1)
                        For i As Integer = 0 To rowCount - 1
                            keys(i) = tblResult.Rows(i).Item("key")
                            values(i) = tblResult.Rows(i).Item("value")
                        Next
                        chartData = New KeyValuePair(Of String(), Integer())(keys, values)
                    End If
                End If
            Catch ex As Exception
                WriteLog(ex.GetHashCode(), ex.Message)
            End Try
            Return chartData
        End Function

        ''' <summary>
        ''' Lấy dữ liệu ghi mượn theo địa điểm
        ''' </summary>
        ''' <param name="isHistory">
        ''' True if History (Loan History -> từng mượn)
        ''' False if not History ( Current Loan -> đang mượn)
        ''' </param>
        ''' <param name="isLib">true if ids refer to LibID else LocID</param>
        ''' <param name="ids">IDs String</param>
        ''' <param name="total"></param>
        ''' <param name="checkOutDateFrom"></param>
        ''' <param name="checkOutDateTo"></param>
        ''' <param name="index"></param>
        ''' <param name="size"></param>
        ''' <param name="shouldConverted">Format text or Native Text($a,b,c ...)</param>
        ''' <param name="isAddHeader">When export</param>
        ''' <returns></returns>
        Public Function GetHoldingPlace(
                                ByVal isHistory As Boolean,
                                ByVal isLib As Boolean,
                                ByVal locationID As Integer,
                                ByVal ids As String,
                                ByRef total As Integer,
                                Optional checkOutDateFrom As String = Nothing,
                                Optional checkOutDateTo As String = Nothing,
                                Optional index As Integer? = Nothing,
                                Optional size As Integer? = Nothing,
                                Optional shouldConverted As Boolean = True,
                                Optional isAddHeader As Boolean = False
                                 ) As DataTable
            Dim tblResult As DataTable = Nothing
            Try
                If index IsNot Nothing AndAlso size IsNot Nothing Then
                    index = index * size
                Else 'Make Data stable
                    index = Nothing
                    size = Nothing
                End If

                Dim dtCheckOutDateFrom As DateTime? = ConvertMinDateTime(checkOutDateFrom)
                Dim dtCheckOutDateTo As DateTime? = ConvertMaxDateTime(checkOutDateTo)

                objDDHVLStatistic.LibID = LibID
                objDDHVLStatistic.UserID = UserID
                objDDHVLStatistic.StatOption = StatOption
                objDDHVLStatistic.LoanMode = LoanMode
                tblResult = objDDHVLStatistic.GetHoldingPlace(
                                                    isHistory,
                                                    isLib,
                                                    ids,
                                                    locationID,
                                                    total,
                                                    dtCheckOutDateFrom,
                                                    dtCheckOutDateTo,
                                                    index,
                                                    size
)

                If shouldConverted Then
                    tblResult = ConvertTableTime(tblResult, isAddHeader)
                End If

                If tblResult Is Nothing Then
                    WriteLog(objDDHVLStatistic.ErrorCode, objDDHVLStatistic.ErrorMsg)
                End If
            Catch ex As Exception
                WriteLog(ex.GetHashCode(), ex.Message)
            End Try
            Return tblResult
        End Function

        ''' <summary>
        ''' Thống kê dạng tư liệu lưu thông theo thời gian.
        ''' </summary>
        ''' <param name="isHistory">
        ''' True if History (Loan History -> từng mượn)
        ''' False if not History ( Current Loan -> đang mượn)
        ''' </param>
        ''' <param name="locationID">0 for all or specified location id</param>
        ''' <param name="total"></param>
        ''' <param name="checkOutDateFrom"></param>
        ''' <param name="checkOutDateTo"></param>
        ''' <param name="index"></param>
        ''' <param name="size"></param>
        ''' <param name="isOutputTotal">Should get total entry or not (default is False which increase performance)</param>
        ''' <returns></returns>
        Public Function GetHoldingLoanTypeStat(
                                    ByVal isHistory As Boolean,
                                    ByRef total As Integer,
                                    Optional checkOutDateFrom As String = Nothing,
                                    Optional checkOutDateTo As String = Nothing,
                                    Optional index As Integer? = Nothing,
                                    Optional size As Integer? = Nothing,
                                    Optional isOutputTotal As Boolean = False
                                     ) As KeyValuePair(Of String(), Integer())
            Dim tblResult As DataTable = Nothing
            Dim chartData As New KeyValuePair(Of String(), Integer())(Nothing, Nothing)
            Try
                If index IsNot Nothing AndAlso size IsNot Nothing Then
                    index = index * size
                Else 'Make Data stable
                    index = Nothing
                    size = Nothing
                End If

                Dim dtCheckOutDateFrom As DateTime? = ConvertMinDateTime(checkOutDateFrom)
                Dim dtCheckOutDateTo As DateTime? = ConvertMaxDateTime(checkOutDateTo)

                objDDHVLStatistic.LibID = LibID
                objDDHVLStatistic.UserID = UserID
                objDDHVLStatistic.StatOption = StatOption
                objDDHVLStatistic.LoanType = LoanType
                tblResult = objDDHVLStatistic.GetHoldingLoanTypeStat(
                                                    isHistory,
                                                    total,
                                                    dtCheckOutDateFrom,
                                                    dtCheckOutDateTo,
                                                    index,
                                                    size,
                                                    isOutputTotal
                            )

                If tblResult Is Nothing Then
                    WriteLog(objDDHVLStatistic.ErrorCode, objDDHVLStatistic.ErrorMsg)
                Else
                    If tblResult.Rows.Count > 0 Then
                        Dim rowCount As Integer = tblResult.Rows.Count
                        Dim keys As String()
                        ReDim keys(rowCount - 1)
                        Dim values As Integer()
                        ReDim values(rowCount - 1)
                        For i As Integer = 0 To rowCount - 1
                            keys(i) = tblResult.Rows(i).Item("key")
                            values(i) = tblResult.Rows(i).Item("value")
                        Next
                        chartData = New KeyValuePair(Of String(), Integer())(keys, values)
                    End If
                End If
            Catch ex As Exception
                WriteLog(ex.GetHashCode(), ex.Message)
            End Try
            Return chartData
        End Function

        ''' <summary>
        ''' Lấy dữ liệu theo tài liệu lưu thông
        ''' </summary>
        ''' <param name="isHistory">
        ''' True if History (Loan History -> từng mượn)
        ''' False if not History ( Current Loan -> đang mượn)
        ''' </param>
        ''' <param name="total"></param>
        ''' <param name="checkOutDateFrom"></param>
        ''' <param name="checkOutDateTo"></param>
        ''' <param name="index"></param>
        ''' <param name="size"></param>
        ''' <param name="shouldConverted">Format text or Native Text($a,b,c ...)</param>
        ''' <param name="isAddHeader">When export</param>
        ''' <returns></returns>
        Public Function GetHoldingLoanType(
                                ByVal isHistory As Boolean,
                                ByRef total As Integer,
                                Optional checkOutDateFrom As String = Nothing,
                                Optional checkOutDateTo As String = Nothing,
                                Optional index As Integer? = Nothing,
                                Optional size As Integer? = Nothing,
                                Optional shouldConverted As Boolean = True,
                                Optional isAddHeader As Boolean = False
                                 ) As DataTable
            Dim tblResult As DataTable = Nothing
            Try
                If index IsNot Nothing AndAlso size IsNot Nothing Then
                    index = index * size
                Else 'Make Data stable
                    index = Nothing
                    size = Nothing
                End If

                Dim dtCheckOutDateFrom As DateTime? = ConvertMinDateTime(checkOutDateFrom)
                Dim dtCheckOutDateTo As DateTime? = ConvertMaxDateTime(checkOutDateTo)

                objDDHVLStatistic.LibID = LibID
                objDDHVLStatistic.UserID = UserID
                objDDHVLStatistic.StatOption = StatOption
                objDDHVLStatistic.LoanType = LoanType
                tblResult = objDDHVLStatistic.GetHoldingLoanType(
                                                    isHistory,
                                                    total,
                                                    dtCheckOutDateFrom,
                                                    dtCheckOutDateTo,
                                                    index,
                                                    size
                            )

                If shouldConverted Then
                    tblResult = ConvertTableTime(tblResult, isAddHeader)
                End If

                If tblResult Is Nothing Then
                    WriteLog(objDDHVLStatistic.ErrorCode, objDDHVLStatistic.ErrorMsg)
                End If
            Catch ex As Exception
                WriteLog(ex.GetHashCode(), ex.Message)
            End Try
            Return tblResult
        End Function

    End Class
End Namespace
