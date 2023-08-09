Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Catalogue
Imports eMicLibAdmin.DataAccess.Common

Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBHolding
        Inherits clsBBase
        Private objDHolding As New clsDHolding
        Private objBCDBS As New clsBCommonDBSystem
        Private intItemID As Integer = 0
        Private objarrData() As Integer
        Private objarrLabel() As String
        Public Property ItemID() As Integer
            Get
                Return intItemID
            End Get
            Set(ByVal Value As Integer)
                intItemID = Value
            End Set
        End Property
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

        Public Function GetHoldingByStatus(ByVal statusCode As String) As DataTable
            Dim result As DataTable = Nothing
            Try
                objDHolding.LibID = LibID
                objDHolding.UserID = UserID
                result = objDHolding.GetHoldingByStatusCode(statusCode)
                strErrorMsg = objDHolding.ErrorMsg
                intErrorCode = objDHolding.ErrorCode
            Catch ex As Exception
                strErrorMsg = objDHolding.ErrorMsg
                intErrorCode = objDHolding.ErrorCode
            End Try
            Return result
        End Function

        Public Function ClearHoldingPrintLabel(ByVal copyNumber As String) As Integer
            Dim result As Integer = 0
            Try
                copyNumber = copyNumber.Trim()
                If copyNumber <> "" Then
                    result = objDHolding.ClearHoldingPrintLabel(copyNumber)
                    ErrorCode = objDHolding.ErrorCode
                    ErrorMsg = objDHolding.ErrorMsg
                Else
                    result = -1
                End If
            Catch ex As Exception
                ErrorCode = ex.GetHashCode()
                ErrorMsg = ex.Message
            End Try
            Return result
        End Function

        Public Function GetHoldingDate(Optional ByVal strDateFrom As String = "", Optional ByVal strDateTo As String = "") As DataTable
            Try
                If strDateFrom <> "" Then strDateFrom = objBCDBS.ConvertDateBack(strDateFrom, False)
                If strDateTo <> "" Then strDateTo = objBCDBS.ConvertDateBack(strDateTo, False)
                Dim result As DataTable = objBCDBS.ConvertTableKillChar(objBCDBS.ConvertTable(objDHolding.GetHoldingDate(strDateFrom, strDateTo)), "&", "-")
                strErrorMsg = objDHolding.ErrorMsg
                intErrorCode = objDHolding.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDHolding.ErrorMsg
                intErrorCode = objDHolding.ErrorCode
                Return New DataTable
            End Try
        End Function
        Public Function GetHoldingLocationNameAndTotalHoldingInDate(Optional ByVal strDateFrom As String = "", Optional ByVal strDateTo As String = "") As DataTable
            Try
                If strDateFrom <> "" Then strDateFrom = objBCDBS.ConvertDateBack(strDateFrom, False)
                If strDateTo <> "" Then strDateTo = objBCDBS.ConvertDateBack(strDateTo, False)
                Dim result As DataTable = objBCDBS.ConvertTableKillChar(objBCDBS.ConvertTable(objDHolding.GetHoldingLocationNameAndTotalHoldingInDate(strDateFrom, strDateTo)), "&", "-")
                strErrorMsg = objDHolding.ErrorMsg
                intErrorCode = objDHolding.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDHolding.ErrorMsg
                intErrorCode = objDHolding.ErrorCode
                Return New DataTable
            End Try
        End Function
        Public Function GetHoldingLocationName(Optional ByVal strDateFrom As String = "", Optional ByVal strDateTo As String = "") As DataTable
            Try
                If strDateFrom <> "" Then strDateFrom = objBCDBS.ConvertDateBack(strDateFrom, False)
                If strDateTo <> "" Then strDateTo = objBCDBS.ConvertDateBack(strDateTo, False)
                Dim result As DataTable = objBCDBS.ConvertTableKillChar(objBCDBS.ConvertTable(objDHolding.GetHoldingLocationName(strDateFrom, strDateTo)), "&", "-")
                strErrorMsg = objDHolding.ErrorMsg
                intErrorCode = objDHolding.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDHolding.ErrorMsg
                intErrorCode = objDHolding.ErrorCode
                Return New DataTable
            End Try
        End Function

        Public Function StatCopyNumberAcqSource(ByVal intAcquiredID As Integer, Optional ByVal strAcquiredDateFrom As String = "", Optional ByVal strAcquiredDateTo As String = "") As DataTable
            Dim intRowIndex As Integer = 0
            Dim intTotalRecords As Integer = 0
            Dim tblData As DataTable

            Try
                strAcquiredDateFrom = objBCDBS.ConvertDateBack(strAcquiredDateFrom, False)
                strAcquiredDateTo = objBCDBS.ConvertDateBack(strAcquiredDateTo, False)
                tblData = objDHolding.StatCopyNumberAcqSource(intAcquiredID, strAcquiredDateFrom, strAcquiredDateTo)

                If Not IsNothing(tblData) AndAlso tblData.Rows.Count Then
                    intTotalRecords = tblData.Rows.Count
                    ReDim arrData(intTotalRecords - 1)
                    ReDim arrLabel(intTotalRecords - 1)
                    For intRowIndex = 0 To intTotalRecords - 1
                        arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("Count")
                        arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("Source")
                    Next
                Else
                    ReDim arrData(0)
                    ReDim arrLabel(0)
                    arrData(0) = -1
                    arrLabel(0) = ""
                End If

                intErrorCode = objDHolding.ErrorCode
                strErrorMsg = objDHolding.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        Public Function StatCopyNumberAcqSourceDetail(ByVal intAcquiredID As Integer, Optional ByVal strAcquiredDateFrom As String = "", Optional ByVal strAcquiredDateTo As String = "") As DataTable
            Try
                strAcquiredDateFrom = objBCDBS.ConvertDateBack(strAcquiredDateFrom, False)
                strAcquiredDateTo = objBCDBS.ConvertDateBack(strAcquiredDateTo, False)
                Dim result As DataTable = objDHolding.StatCopyNumberAcqSourceDetail(intAcquiredID, strAcquiredDateFrom, strAcquiredDateTo)
                strErrorMsg = objDHolding.ErrorMsg
                intErrorCode = objDHolding.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDHolding.ErrorMsg
                intErrorCode = objDHolding.ErrorCode
                Return New DataTable
            End Try
        End Function

        Public Function StatCopyNumberCatalogerDetail(Optional ByVal strDateFrom As String = "", Optional ByVal strDateTo As String = "") As DataTable
            Dim tblResult As New DataTable("tblResult")
            Try
                objDHolding.LibID = intLibID
                If strDateFrom <> "" And strDateTo <> "" Then
                    tblResult = objDHolding.StatCopyNumberCatalogerDetail(strDateFrom, strDateTo)
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return tblResult
        End Function

        Public Function GetContentByCopyNumber(ByVal strCopyNumber As String) As DataTable
            Try
                Dim result As DataTable = objBCDBS.ConvertTable(objDHolding.GetContentByCopyNumber(strCopyNumber), "Content")
                strErrorMsg = objDHolding.ErrorMsg
                intErrorCode = objDHolding.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDHolding.ErrorMsg
                intErrorCode = objDHolding.ErrorCode
                Return New DataTable
            End Try
        End Function

        Public Sub Initialize()
            Try
                objBCDBS.ConnectionString = strConnectionString
                objBCDBS.DBServer = strDBServer
                objBCDBS.InterfaceLanguage = strInterfaceLanguage
                Call objBCDBS.Initialize()
                ' Init objDLoanTypeOther object
                objDHolding.ConnectionString = strConnectionString
                objDHolding.DBServer = strDBServer
                Call objDHolding.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            If isDisposing Then
                If Not objDHolding Is Nothing Then
                    objDHolding.Dispose(True)
                    objDHolding = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
            End If
            MyBase.Dispose()
            Me.Dispose()
        End Sub
    End Class
End Namespace

