Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Catalogue
Imports eMicLibAdmin.DataAccess.Common

Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBItem
        Inherits clsBBase

        ' *****************************************************************************************************
        ' Declare Private variables
        ' *****************************************************************************************************

        Protected strItemIDs As String = ""
        Protected strTitle As String = ""
        Protected lngItemID As Long = 0
        Protected intIsAuthority As Integer = 0
        Private strCode As String = ""
        Private intIsUnion As Integer = 0 ' (no check in ITEM table)
        Private strSessionID As String = ""
        Private intField912Value As Integer = 0
        Private strControlName As String = ""
        Protected intLibID As Integer = 0
        Protected intIndexId As Integer = 0
        Private objDItem As New clsDItem
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objDCommon As New clsDCommon

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' ControlName property
        Public Property ControlName() As String
            Get
                Return (strControlName)
            End Get
            Set(ByVal Value As String)
                strControlName = Value
            End Set
        End Property

        ' ItemIDs property
        Public Property ItemIDs() As String
            Get
                Return strItemIDs
            End Get
            Set(ByVal Value As String)
                strItemIDs = Value
            End Set
        End Property

        ' Code property
        Public Property Code() As String
            Get
                Return strCode
            End Get
            Set(ByVal Value As String)
                strCode = objBCSP.ConvertItBack(Value)
            End Set
        End Property

        ' IsUnion property
        Public Property IsUnion() As Integer
            Get
                Return intIsUnion
            End Get
            Set(ByVal Value As Integer)
                intIsUnion = Value
            End Set
        End Property

        ' SessionID property
        Public Property SessionID() As String
            Get
                Return strSessionID
            End Get
            Set(ByVal Value As String)
                strSessionID = Value
            End Set
        End Property

        ' Title property
        Public Property Title() As String
            Get
                Return strTitle
            End Get
            Set(ByVal Value As String)
                strTitle = Value
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

        ' Tag912 property
        Public Property Field912Value() As Integer
            Get
                Return intField912Value
            End Get
            Set(ByVal Value As Integer)
                intField912Value = Value
            End Set
        End Property

        ' IsAuthority property
        Public Property IsAuthority() As Integer
            Get
                Return intIsAuthority
            End Get
            Set(ByVal Value As Integer)
                intIsAuthority = Value
            End Set
        End Property

        ' ItemIDs property
        Public Property LibID() As Integer
            Get
                Return intLibID
            End Get
            Set(ByVal Value As Integer)
                intLibID = Value
            End Set
        End Property

        ' ItemIDs property
        Public Property IndexId() As Integer
            Get
                Return intIndexId
            End Get
            Set(ByVal Value As Integer)
                intIndexId = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Initialize method
        ' Purpose: Init all necessary objects
        Public Sub Initialize()
            Try
                ' Init objDField object
                objDItem.DBServer = strDBServer
                objDItem.ConnectionString = strConnectionString
                objDItem.Initialize()

                ' Init objBCSP object
                objBCSP.DBServer = strDBServer
                objBCSP.InterfaceLanguage = strInterfaceLanguage
                objBCSP.ConnectionString = strConnectionString
                objBCSP.Initialize()

                ' Init objBCDBS object
                objBCDBS.DBServer = strDBServer
                objBCDBS.InterfaceLanguage = strInterfaceLanguage
                objBCDBS.ConnectionString = strConnectionString
                objBCDBS.Initialize()

            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' GetReserveItemCode method
        ' Purpose: Get content of the one or some items
        ' Input: IsUnion (check also ITEM table), Code, SessionID
        ' Output: Datatable
        Public Function GetReserveItemCode() As DataTable
            Try
                objDItem.IsUnion = intIsUnion
                objDItem.Code = strCode
                objDItem.SessionID = strSessionID
                GetReserveItemCode = objBCDBS.ConvertTable(objDItem.GetReserveItemCode)
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' CreateItemCodeRes method
        ' Purpose: create new reserve ItemCode 
        ' Input: two string value of reserve ItemCode and SessionID
        Public Sub CreateItemCodeRes()
            Try
                objDItem.Code = strCode
                objDItem.SessionID = strSessionID
                Call objDItem.CreateItemCodeRes()
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' DeleteItemCodeRes method
        ' Purpose: Delete some selected reserve ItemCode 
        ' Input: string value of reserve ItemCode 
        Public Sub DeleteItemCodeRes()
            Try
                objDItem.Code = strCode
                Call objDItem.DeleteItemCodeRes()
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' UpdateOpacItem methos 
        ' Purpose: update OPAC field in ITEM table
        Public Sub UpdateOpacItem(Optional ByVal intByte As Integer = 0)
            Try
                objDItem.ItemID = lngItemID
                objDItem.Field912Value = intField912Value
                objDItem.LibID = intLibID
                objDItem.UpdateOpacItem(intByte)
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Sub

        ' DeleteCatQueue method
        ' Purpose: Delete data in CAT_QUEUE table
        Public Sub DeleteCatQueue()
            Try
                objDItem.ItemIDs = strItemIDs
                objDItem.DeleteCatQueue()
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Sub

        Public Function GetItemReview() As DataTable
            Try
                objDItem.ItemIDs = strItemIDs
                GetItemReview = objDItem.GetItemReview()
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function


        'QuocDD
        ' get item by index and libid
        Public Function GetItemByIndexAndLibID() As DataTable
            Try
                objDItem.IndexID = intIndexId
                objDItem.LibID = intLibID
                GetItemByIndexAndLibID = objDItem.GetItemByIndexAndLibID()
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function

        'QuocDD
        ' get index by itemID and libid
        Public Function GetIndexOfItemByItemIdAndLibID() As DataTable
            Try
                objDItem.ItemID = lngItemID
                objDItem.LibID = intLibID
                GetIndexOfItemByItemIdAndLibID = objDItem.GetIndexOfItemByItemIdAndLibID()
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function

        ' DeleteCatQueue method
        ' Purpose: Delete data in CAT_QUEUE table
        Public Sub UpdateItemReview(ByVal strReviewer As String)
            Try
                objDItem.ItemIDs = strItemIDs
                objDItem.UpdateItemReview(strReviewer)
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Sub

        ' GetTopNumByID method
        ' Purpose: Get TopNumber by Item ID
        ' Output: Datatable
        Public Function GetTopNumByID() As DataTable
            Try
                objDItem.ItemID = lngItemID
                objDItem.IsAuthority = intIsAuthority
                objDItem.LibID = intLibID
                GetTopNumByID = objDItem.GetTopNumByID
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' GetCatDicList method
        ' Purpose: Get the cat dictionary list
        ' Output: Datatable
        Public Function GetCatDicList() As DataTable
            Try
                GetCatDicList = objBCDBS.ConvertTable(objDItem.GetCatDicList)
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' GetCatDicList method
        ' Purpose: Get the cat dictionary list
        ' Output: Datatable
        Public Function GetCatDicListBasic() As DataTable
            Try
                GetCatDicListBasic = objBCDBS.ConvertTable(objDItem.GetCatDicListBasic)
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' CheckExistItemByNumber method
        ' Purpose: Check exist item by ISBN or ISSN
        ' Input: FieldValue, FieldCode
        ' Output: long value
        Public Function CheckExistItemByNumber(ByVal strFieldValue As String, ByVal strFieldCode As String) As Long
            Try
                strFieldValue = objBCSP.GEntryTrim(strFieldValue.Replace("-", "").Replace(" ", "").Trim)
                CheckExistItemByNumber = objDItem.CheckExistItemByNumber(strFieldValue, strFieldCode & "$a")
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' GetCopyNumbers method
        ' Purpose: Get the holding information
        ' Output: Datatable
        Public Function GetCopyNumbers() As DataTable
            Try
                objDItem.ItemID = lngItemID
                GetCopyNumbers = objBCDBS.ConvertTable(objDItem.GetCopyNumbers)
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        Public Function GetItems() As DataTable
            Try
                objDItem.ItemID = lngItemID
                objDItem.Code = strCode
                GetItems = objBCDBS.ConvertTable(objDItem.GetItems)
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        Function GetCataTimeList(ByRef intCountRec As Integer, ByVal strMonth As String) As DataTable
            Dim tmpResult As DataTable
            Dim intRow As Integer
            intCountRec = 0

            Try
                objDItem.LibID = intLibID
                tmpResult = objBCDBS.ConvertTable(objDItem.GetCataTimeList)
                If Not tmpResult Is Nothing Then
                    For intRow = 0 To tmpResult.Rows.Count - 1
                        intCountRec = intCountRec + CInt(tmpResult.Rows(intRow).Item("NOR"))
                        tmpResult.Rows(intRow).Item("Content") = "    " & strMonth & " " & tmpResult.Rows(intRow).Item("InputDate") & " (" & tmpResult.Rows(intRow).Item("NOR") & ")"
                    Next
                End If
                GetCataTimeList = tmpResult
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        Function GetItemInQueueList(ByVal intOrderBy As Int16, ByVal strMonth As String) As DataTable
            Try
                objDItem.LibID = intLibID
                GetItemInQueueList = objBCDBS.ConvertTable(objDItem.GetItemInQueueList(intOrderBy, strMonth.Trim), "Content")
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        Public Function GetTitlesAndCode() As DataTable
            Try
                objDItem.ItemIDs = objBCSP.ConvertItBack(strItemIDs)
                GetTitlesAndCode = objBCDBS.ConvertTable(objDItem.GetTitlesAndCode, "TITLE")
                GetTitlesAndCode = objBCDBS.SortTable(GetTitlesAndCode, "TITLE")
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        ' Method: GetItemInfor
        ' Input: ItemID
        ' Output: datatable
        ' Purpose: Get the Item main infor
        ' Output: Datatable
        Public Function GetItemInfor() As DataTable
            Try
                objDItem.ItemID = lngItemID
                GetItemInfor = objBCDBS.ConvertTable(objDItem.GetItemInfor)
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' GetItemIDByItemCode method
        ' Purpose: Get the Item ID by ItemCode
        ' Output: Datatable
        Public Function GetItemIDByItemCode() As DataTable
            Try
                objDItem.Code = strCode
                GetItemIDByItemCode = objDItem.GetItemIDByItemCode
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        Public Sub CreateQueue()
            Try
                objDItem.ItemID = lngItemID
                Call objDItem.CreateQueue()
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        Public Function GetItemByKeyword(ByVal intKeywordId As Integer, Optional ByVal intTypeId As Integer = 0, Optional ByVal intLoanTypeId As Integer = 0, Optional ByVal intYearFrom As Integer = 0, Optional intYearTo As Integer = 0, Optional intAcqSource As Integer = 0, Optional intLocation As Integer = 0) As DataTable
            Dim result As New DataTable
            Try
                result = objDItem.GetItemByKeyword(intKeywordId, intTypeId, intLoanTypeId, intYearFrom, intYearTo, intAcqSource, intLocation)
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            End Try
            Return result
        End Function

        Public Function GetItemByKeyword(ByVal strKeyword As String, Optional ByVal intTypeId As Integer = 0, Optional ByVal intLoanTypeId As Integer = 0, Optional ByVal intYearFrom As Integer = 0, Optional intYearTo As Integer = 0, Optional intAcqSource As Integer = 0, Optional intLocation As Integer = 0) As DataTable
            Dim result As New DataTable
            Try
                result = objDItem.GetItemByKeyword(strKeyword, intTypeId, intLoanTypeId, intYearFrom, intYearTo, intAcqSource, intLocation)
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            End Try
            Return result
        End Function

        Public Function GetItemByKeywordCount(ByVal intKeywordId As Integer, Optional ByVal intTypeId As Integer = 0, Optional ByVal intLoanTypeId As Integer = 0, Optional ByVal intYearFrom As Integer = 0, Optional intYearTo As Integer = 0, Optional intAcqSource As Integer = 0, Optional intLocation As Integer = 0) As DataTable
            Dim result As New DataTable
            Try
                result = objDItem.GetItemByKeywordCount(intKeywordId, intTypeId, intLoanTypeId, intYearFrom, intYearTo, intAcqSource, intLocation)
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            End Try
            Return result
        End Function

        Public Function GetItemByKeywordCount(ByVal strKeyword As String, Optional ByVal intTypeId As Integer = 0, Optional ByVal intLoanTypeId As Integer = 0, Optional ByVal intYearFrom As Integer = 0, Optional intYearTo As Integer = 0, Optional intAcqSource As Integer = 0, Optional intLocation As Integer = 0) As DataTable
            Dim result As New DataTable
            Try
                result = objDItem.GetItemByKeywordCount(strKeyword, intTypeId, intLoanTypeId, intYearFrom, intYearTo, intAcqSource, intLocation)
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            End Try
            Return result
        End Function

        Public Function GetItemBySH(ByVal intSHId As Integer, Optional ByVal intTypeId As Integer = 0, Optional ByVal intLoanTypeId As Integer = 0, Optional ByVal intYearFrom As Integer = 0, Optional intYearTo As Integer = 0, Optional intAcqSource As Integer = 0, Optional intLocation As Integer = 0, Optional strAdditionalBy As String = "", Optional strDicFaculty As String = "", Optional strDateFrom As String = "", Optional strDateTo As String = "") As DataTable
            Dim result As New DataTable
            Try
                result = objDItem.GetItemBySH(intSHId, intTypeId, intLoanTypeId, intYearFrom, intYearTo, intAcqSource, intLocation, strAdditionalBy, strDicFaculty, strDateFrom, strDateTo)
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            End Try
            Return result
        End Function

        Public Function GetItemBySH(ByVal strSH As String, Optional ByVal intTypeId As Integer = 0, Optional ByVal intLoanTypeId As Integer = 0, Optional ByVal intYearFrom As Integer = 0, Optional intYearTo As Integer = 0, Optional intAcqSource As Integer = 0, Optional intLocation As Integer = 0, Optional strAdditionalBy As String = "", Optional strDicFaculty As String = "", Optional strDateFrom As String = "", Optional strDateTo As String = "") As DataTable
            Dim result As New DataTable
            Try
                result = objDItem.GetItemBySH(strSH, intTypeId, intLoanTypeId, intYearFrom, intYearTo, intAcqSource, intLocation, strAdditionalBy, strDicFaculty, strDateFrom, strDateTo)
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            End Try
            Return result
        End Function

        Public Function GetItemBySHCount(ByVal intSHId As Integer, Optional ByVal intTypeId As Integer = 0, Optional ByVal intLoanTypeId As Integer = 0, Optional ByVal intYearFrom As Integer = 0, Optional intYearTo As Integer = 0, Optional intAcqSource As Integer = 0, Optional intLocation As Integer = 0, Optional strAdditionalBy As String = "", Optional strDicFaculty As String = "", Optional strDateFrom As String = "", Optional strDateTo As String = "") As DataTable
            Dim result As New DataTable
            Try
                result = objDItem.GetItemBySHCount(intSHId, intTypeId, intLoanTypeId, intYearFrom, intYearTo, intAcqSource, intLocation, strAdditionalBy, strDicFaculty, strDateFrom, strDateTo)
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            End Try
            Return result
        End Function

        Public Function GetItemBySHCount(ByVal strSH As String, Optional ByVal intTypeId As Integer = 0, Optional ByVal intLoanTypeId As Integer = 0, Optional ByVal intYearFrom As Integer = 0, Optional intYearTo As Integer = 0, Optional intAcqSource As Integer = 0, Optional intLocation As Integer = 0, Optional strAdditionalBy As String = "", Optional strDicFaculty As String = "", Optional strDateFrom As String = "", Optional strDateTo As String = "") As DataTable
            Dim result As New DataTable
            Try
                result = objDItem.GetItemBySHCount(strSH, intTypeId, intLoanTypeId, intYearFrom, intYearTo, intAcqSource, intLocation, strAdditionalBy, strDicFaculty, strDateFrom, strDateTo)
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            End Try
            Return result
        End Function

        Function CreditItemDownLoadFile() As Integer
            Try
                objDItem.ItemID = lngItemID
                CreditItemDownLoadFile = objDItem.CreditItemDownLoadFile()
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        Public Function GetCountDownLoad() As Integer
            Try
                objDItem.ItemID = lngItemID
                GetCountDownLoad = objDItem.GetCountDownLoad()
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function
        'UpdateCountPage()
        Public Function UpdateCountPage(Optional ByVal intItemId As Integer = 0, Optional ByVal intCountPage As Integer = 0) As Integer
            Try
                UpdateCountPage = objDItem.UpdateCountPage(intItemId, intCountPage)
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function
        Public Function GetListCataloguer() As DataTable
            Dim result As New DataTable
            Try
                result = objDItem.GetListCataloguer()
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            End Try
            Return result
        End Function

        Public Function GetItemStatisticTotal(Optional ByVal strDateFrom As String = "", Optional ByVal strDateTo As String = "") As DataTable
            Dim result As New DataTable
            Try
                result = objDItem.GetItemStatisticTotal(strDateFrom, strDateTo)
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            End Try
            Return result
        End Function
        Public Function GetItemDissertationTotal(Optional ByVal strDateFrom As String = "", Optional ByVal strDateTo As String = "") As DataTable
            Dim result As New DataTable
            Try
                result = objDItem.GetItemDissertationTotal(strDateFrom, strDateTo)
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = objDItem.ErrorMsg
                intErrorCode = objDItem.ErrorCode
            End Try
            Return result
        End Function
        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objDItem Is Nothing Then
                    objDItem.Dispose(True)
                    objDItem = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
            Finally
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace