' Purpose: process fiels
' Creator: Oanhtn
Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Catalogue

Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBItemCollection
        Inherits clsBItem

        ' *****************************************************************************************************
        ' Declare Private variables
        ' *****************************************************************************************************
        Private intTypeItem As Integer = 0
        Private intTopNum As Integer = 0
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objDItemCollection As New clsDItemCollection
        Private objBForming As New clsBFormingSQL

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************
        ' TypeItem properties
        Public Property TypeItem() As Integer
            Get
                Return intTypeItem
            End Get
            Set(ByVal Value As Integer)
                intTypeItem = Value
            End Set
        End Property

        ' TopID property
        Public Property TopNum() As Integer
            Get
                Return intTopNum
            End Get
            Set(ByVal Value As Integer)
                intTopNum = Value
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
                ' Init objDItemCollection object
                objDItemCollection.DBServer = strDBserver
                objDItemCollection.ConnectionString = strConnectionString
                Call objDItemCollection.Initialize()

                ' Init objBCDBS object
                objBCDBS.DBServer = strDBServer
                objBCDBS.InterfaceLanguage = strInterfaceLanguage
                objBCDBS.ConnectionString = strConnectionString
                Call objBCDBS.Initialize()

                ' Init objBCSP object
                objBCSP.DBServer = strDBServer
                objBCSP.InterfaceLanguage = strInterfaceLanguage
                objBCSP.ConnectionString = strConnectionString
                Call objBCSP.Initialize()

                objBForming.DBServer = strDBServer
                objBForming.InterfaceLanguage = strInterfaceLanguage
                objBForming.ConnectionString = strConnectionString
                Call objBForming.Initialize()

                ' Init base class (clsBItem)
                MyBase.DBServer = strDBServer
                MyBase.InterfaceLanguage = strInterfaceLanguage
                MyBase.ConnectionString = strConnectionString
                Call MyBase.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' GetRangeItemID method
        ' Purpose: Retrieve all items
        ' Output: Datatable
        Public Function GetRangeItemID() As DataTable
            Try
                objDItemCollection.IsAuthority = intIsAuthority
                objDItemCollection.TypeItem = intTypeItem
                objDItemCollection.LibID = intLibID
                GetRangeItemID = objDItemCollection.GetRangeItemID
                strErrorMsg = objDItemCollection.ErrorMsg
                intErrorCode = objDItemCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' GetTitles method
        ' Purpose: get title which like the title of existing items
        ' Input: string of title to cheking
        ' Output: datatable
        Public Function GetExistTitles() As DataTable
            Dim objSubFieldValues()

            Try
                Call objBCSP.ParseField("$a", objBCSP.ConvertItBack(strTitle), "", objSubFieldValues)
                If Len(Trim(objSubFieldValues(0))) > 0 Then
                    objDItemCollection.Title = Trim(objSubFieldValues(0))
                Else
                    objDItemCollection.Title = "$$$"
                End If
                GetExistTitles = objBCDBS.ConvertTable(objDItemCollection.GetExistTitles)
                intErrorCode = objDItemCollection.ErrorCode
                strErrorMsg = objDItemCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' GetItemMainInfor method
        ' Purpose: get all main information of item (Leader, ItemType, ItemMedia...)
        ' Input: strItemIDs, intIsAuthority
        ' Output: Datatable result
        Public Function GetItemMainInfor() As DataTable
            Try
                objDItemCollection.IsAuthority = intIsAuthority
                objDItemCollection.ItemIDs = strItemIDs
                GetItemMainInfor = objBCDBS.ConvertTable(objDItemCollection.GetItemMainInfor)
                strErrorMsg = objDItemCollection.ErrorMsg
                intErrorCode = objDItemCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' GetItemDetailInfor method
        ' Purpose: get all main information of item (Leader, ItemType, ItemMedia...)
        ' Input: lngItemID, intIsAuthority
        ' Output: Datatable result
        Public Function GetItemDetailInfor(Optional ByVal isCut As Boolean = False) As DataTable
            Try
                objDItemCollection.IsAuthority = intIsAuthority
                objDItemCollection.ItemIDs = strItemIDs
                If isCut Then
                    GetItemDetailInfor = objBCDBS.ConvertTable(objDItemCollection.GetItemDetailInfor, "Content")
                Else
                    GetItemDetailInfor = objBCDBS.ConvertTable(objDItemCollection.GetItemDetailInfor)
                End If
                strErrorMsg = objDItemCollection.ErrorMsg
                intErrorCode = objDItemCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        'ConvertTableAuthorDDC
        Public Function GetItemDetailInforAuthorDDC(Optional ByVal isCut As Boolean = False) As DataTable
            Try
                objDItemCollection.IsAuthority = intIsAuthority
                objDItemCollection.ItemIDs = strItemIDs
                If isCut Then
                    GetItemDetailInforAuthorDDC = objBCDBS.ConvertTableAuthorDDC(objDItemCollection.GetItemDetailInfor, "Content")
                Else
                    GetItemDetailInforAuthorDDC = objBCDBS.ConvertTable(objDItemCollection.GetItemDetailInfor)
                End If
                strErrorMsg = objDItemCollection.ErrorMsg
                intErrorCode = objDItemCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' RetrieveCode_Title method
        ' Purpose: 
        Public Function RetrieveCode_Title(Optional itemInfor As Integer = 0) As DataTable
            Try
                If strItemIDs = "" Then
                    strItemIDs = "0"
                End If
                objDItemCollection.ItemIDs = strItemIDs
                objDItemCollection.LibID = intLibID
                RetrieveCode_Title = objBCDBS.SortTable(objBCDBS.ConvertTable(objDItemCollection.RetrieveCodeTitle_Result(itemInfor), "Title"), "Title")
                strErrorMsg = objDItemCollection.ErrorMsg
                intErrorCode = objDItemCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' RetrieveCode_Title method
        ' Purpose: 
        Public Function GetHoldingDel() As DataTable
            Try
                objDItemCollection.ItemIDs = strItemIDs
                GetHoldingDel = objBCDBS.SortTable(objBCDBS.ConvertTable(objDItemCollection.GetHoldingDel(), "Title"), "Title")
                strErrorMsg = objDItemCollection.ErrorMsg
                intErrorCode = objDItemCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetHoldingDel(ByVal strSQL As String) As DataTable
            Try
                GetHoldingDel = objBCDBS.SortTable(objBCDBS.ConvertTable(objDItemCollection.GetHoldingDel(strSQL), "Title"), "Title")
                strErrorMsg = objDItemCollection.ErrorMsg
                intErrorCode = objDItemCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Initialize method
        ' Purpose: Init all necessary objects
        Public Function GetContents() As DataTable
            Dim tblResult As DataTable
            Dim inti As Integer
            Dim strValue As String
            Dim strFieldValue As String
            Try
                objDItemCollection.IsAuthority = intIsAuthority
                objDItemCollection.ItemIDs = strItemIDs
                tblResult = objBCDBS.ConvertTable(objDItemCollection.GetContents)
                'If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                '    For inti = 0 To tblResult.Rows.Count - 1
                '        If Left(CStr(tblResult.Rows(inti).Item("FieldCode")), 1) = "5" Then
                '            strFieldValue = ""
                '            strValue = ""
                '            strFieldValue = CStr(tblResult.Rows(inti).Item("Content"))
                '            While strFieldValue.Length > 200
                '                strValue = strValue & Left(strFieldValue, 200)
                '                strFieldValue = Right(strFieldValue, Len(strFieldValue) - 200)
                '                If strFieldValue.IndexOf("&nbsp;") > 0 AndAlso strFieldValue.IndexOf("&nbsp;") <= 10 Then
                '                    strValue = strValue & Left(strFieldValue, strFieldValue.IndexOf("&nbsp;"))
                '                    strFieldValue = Right(strFieldValue, Len(strFieldValue) - strFieldValue.IndexOf("&nbsp;"))
                '                End If
                '                strValue = strValue & "<br>"
                '            End While
                '            strValue = strValue & strFieldValue
                '            tblResult.Rows(inti).Item("Content") = strValue
                '        End If
                '    Next
                'End If

                'If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                '    Dim intexCopyNumber As Integer = 1
                '    For inti = 0 To tblResult.Rows.Count - 1
                '        If tblResult.Rows(inti).Item("FieldCode") & "" = "852" Then
                '            strValue = tblResult.Rows(inti).Item("Content") & ""
                '            strValue = strValue & "$tC." & intexCopyNumber
                '            tblResult.Rows(inti).Item("Content") = strValue
                '            intexCopyNumber = intexCopyNumber + 1
                '        End If
                '    Next
                'End If

                GetContents = tblResult
                strErrorMsg = objDItemCollection.ErrorMsg
                intErrorCode = objDItemCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' DeleteItem method
        ' Purpose: Delete Item table and the related tables
        Public Sub DeleteItem()
            Try
                objDItemCollection.IsAuthority = intIsAuthority
                objDItemCollection.ItemIDs = strItemIDs
                objDItemCollection.Delete()
                strErrorMsg = objDItemCollection.ErrorMsg
                intErrorCode = objDItemCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub


        'Delete Cat_tblBookCode by Code Lib_tblItem
        Public Sub DeleteBookCodeByCode(ByVal code As Integer)
            If (Not IsNothing(code)) Then
                Try
                    objDItemCollection.DeleteBookCodeByCode(code)
                    strErrorMsg = objDItemCollection.ErrorMsg
                    intErrorCode = objDItemCollection.ErrorCode
                Catch ex As Exception
                    strErrorMsg = objDItemCollection.ErrorMsg
                    intErrorCode = objDItemCollection.ErrorCode
                End Try
            End If
        End Sub

        Public Function GetItemByID(ByVal itemID As Integer) As DataTable
            Try
                GetItemByID = objDItemCollection.GetItemByID(itemID)
                strErrorMsg = objDItemCollection.ErrorMsg
                intErrorCode = objDItemCollection.ErrorCode
            Catch ex As Exception
                GetItemByID = New DataTable
                strErrorMsg = objDItemCollection.ErrorMsg
                intErrorCode = objDItemCollection.ErrorCode
            End Try
        End Function


        Public Function GenFirstCodeItem() As String
            Dim objPara() As String = {"LIBRARY_ABBREVIATION"}
            Dim objSysPara() As String
            Dim strAbbr As String ' string of library abbreviation
            Dim strYear As String ' string of the current year (2 last digits)
            objSysPara = objBCDBS.GetSystemParameters(objPara)
            strAbbr = objSysPara(0)
            ' Get current year to forming bookcode
            strYear = Right(CStr(Year(Now)), 2)
            Return strAbbr & strYear
        End Function

        ' GetIDByTopNum method
        ' Purpose: Get Max Item ID by a top number of Item
        Public Function GetIDByTopNum(Optional ByVal strSQLFilter As String = "") As DataTable
            Try
                objDItemCollection.IsAuthority = intIsAuthority
                objDItemCollection.TopNum = intTopNum
                objDItemCollection.LibID = intLibID
                GetIDByTopNum = objDItemCollection.GetIDByTopNum(strSQLFilter)
                strErrorMsg = objDItemCollection.ErrorMsg
                intErrorCode = objDItemCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        Public Function GetListOnTopNum(ByVal strSQLFilter As String, Optional ByVal intPage As Integer = 1) As DataTable
            Try
                objDItemCollection.IsAuthority = intIsAuthority
                objDItemCollection.TopNum = intTopNum
                objDItemCollection.LibID = intLibID
                GetListOnTopNum = objBCDBS.ConvertTable(objDItemCollection.GetListOnTopNum(strSQLFilter, intPage), "Title")
                strErrorMsg = objDItemCollection.ErrorMsg
                intErrorCode = objDItemCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        Public Function IsOver() As Boolean
            Dim strSQL As String
            Dim tblTemp As DataTable
            Dim intTotal As Integer
            Try
                If intIsAuthority = 0 Then
                    strSQL = "SELECT COUNT(*) AS TOTAL FROM Lib_tblItem"
                Else
                    strSQL = "SELECT COUNT(*) AS TOTAL FROM Cat_tblAuthority"
                End If
                objBCDBS.SQLStatement = strSQL
                tblTemp = objBCDBS.RetrieveItemInfor
                If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                    intTotal = tblTemp.Rows(0).Item("Total")
                    If intTotal < intTopNum Then
                        IsOver = True
                    Else
                        IsOver = False
                    End If
                Else
                    IsOver = False
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
                IsOver = True
            Finally
            End Try
        End Function

        'Author:HieuNT
        ' CreateISOREC function
        ' Purpose: View record with ISO type
        Public Function CreateISORec() As String

            Dim strFVal, strFGroupVal, strRecVal, strLeader As String
            ' Variables: PadLeft1, PadLeft2 
            Dim strPadLeft1, strPadLeft2 As String
            ' Variables: FieldLen
            Dim intFLen As Integer
            ' Variables:  TotalLen, BaseAdd be used by Leader
            Dim intTotalLen, intBaseAdd, i As Integer
            Dim strIndicators As String

            Dim intIndex As Integer, ISBDStr As String, rowMain, rowDetail As DataRow
            Dim tblMainInfor As New DataTable, tblDetailInfor As New DataTable

            Try
                tblMainInfor = GetItemMainInfor()
                tblDetailInfor = GetItemDetailInfor()

                tblMainInfor = GetItemMainInfor()
                tblDetailInfor = GetItemDetailInfor()

                If tblMainInfor.Rows.Count > 0 Then
                    intTotalLen = 26
                    intBaseAdd = 25
                    strRecVal = ""
                    strFGroupVal = ""
                    strPadLeft1 = ""
                    strPadLeft2 = ""

                    If Not IsDBNull(tblMainInfor.Rows(0).Item("Code")) And tblMainInfor.Rows(0).Item("Code") <> "" Then ' Use Main
                        strFVal = objBCSP.ToUTF8(tblMainInfor.Rows(0).Item("Code").ToString.Trim)
                        intFLen = Len(strFVal) + 1
                        strRecVal = strRecVal & "001" & strPadLeft1.PadLeft(4 - Len(CStr(intFLen)), "0") & intFLen & "00000"
                        intBaseAdd = intBaseAdd + 12
                        strFGroupVal = strFGroupVal & strFVal & CStr(Chr(30))
                        strPadLeft1 = ""
                    End If

                    For i = 0 To tblDetailInfor.Rows.Count - 1
                        If Not IsDBNull(tblDetailInfor.Rows(i).Item("Indicators")) AndAlso Not IsDBNull(tblDetailInfor.Rows(i).Item("VietIndicators")) Then
                            If tblDetailInfor.Rows(i).Item("Indicators") <> "" Or tblDetailInfor.Rows(i).Item("VietIndicators") <> "" Then
                                If Not IsDBNull(tblDetailInfor.Rows(i).Item("Ind1")) AndAlso Not tblDetailInfor.Rows(i).Item("Ind1") = "" Then
                                    strIndicators = tblDetailInfor.Rows(i).Item("Ind1")
                                Else
                                    strIndicators = " "
                                End If
                                If Not IsDBNull(tblDetailInfor.Rows(i).Item("Ind2")) AndAlso Not tblDetailInfor.Rows(i).Item("Ind2") = "" Then
                                    strIndicators = strIndicators & tblDetailInfor.Rows(i).Item("Ind2")
                                Else
                                    strIndicators = strIndicators & " "
                                End If
                            End If
                        End If
                        strFVal = strIndicators & Replace(objBCSP.ToUTF8(tblDetailInfor.Rows(i).Item("Content")), "$", CStr(Chr(31)))
                        intFLen = Len(strFVal) + 1
                        strRecVal = strRecVal & tblDetailInfor.Rows(i).Item("FieldCode") & strPadLeft1.PadLeft(4 - Len(CStr(intFLen)), "0") & intFLen & strPadLeft2.PadLeft(5 - Len(CStr(Len(strFGroupVal))), "0") & Len(strFGroupVal)
                        strPadLeft1 = ""
                        strPadLeft2 = ""
                        intBaseAdd = intBaseAdd + 12
                        strFGroupVal = strFGroupVal & strFVal & CStr(Chr(30))
                    Next

                    ' New record
                    If Not IsDBNull(tblMainInfor.Rows(0).Item("NewRecord")) Then
                        If tblMainInfor.Rows(0).Item("NewRecord") > 0 Then
                            strFVal = tblMainInfor.Rows(0).Item("NewRecord")
                            intFLen = Len(strFVal) + 1
                            strRecVal = strRecVal & "900" & strPadLeft1.PadLeft(4 - Len(CStr(intFLen)), "0") & intFLen & strPadLeft2.PadLeft(5 - Len(CStr(Len(strFGroupVal))), "0") & Len(strFGroupVal)
                            intBaseAdd = intBaseAdd + 12
                            strFGroupVal = strFGroupVal & strFVal & CStr(Chr(30))
                            strPadLeft1 = ""
                            strPadLeft2 = ""
                        End If
                    End If

                    ' CoverPicture
                    If Not IsDBNull(tblMainInfor.Rows(0).Item("CoverPicture")) Then
                        If Not tblMainInfor.Rows(0).Item("CoverPicture") = "" Then
                            strFVal = tblMainInfor.Rows(0).Item("CoverPicture")
                            intFLen = Len(strFVal) + 1
                            strRecVal = strRecVal & "907" & strPadLeft1.PadLeft(4 - Len(CStr(intFLen)), "0") & intFLen & strPadLeft2.PadLeft(5 - Len(CStr(Len(strFGroupVal))), "0") & Len(strFGroupVal)
                            intBaseAdd = intBaseAdd + 12
                            strFGroupVal = strFGroupVal & strFVal & CStr(Chr(30))
                            strPadLeft1 = ""
                            strPadLeft2 = ""
                        End If
                    End If

                    ' Cataloguer
                    If Not IsDBNull(tblMainInfor.Rows(0).Item("Cataloguer")) Then
                        If Not tblMainInfor.Rows(0).Item("Cataloguer") = "" Then
                            strFVal = objBCSP.ToUTF8(tblMainInfor.Rows(0).Item("Cataloguer"))
                            intFLen = Len(strFVal) + 1
                            strRecVal = strRecVal & "911" & strPadLeft1.PadLeft(4 - Len(CStr(intFLen)), "0") & intFLen & strPadLeft2.PadLeft(5 - Len(CStr(Len(strFGroupVal))), "0") & Len(strFGroupVal)
                            intBaseAdd = intBaseAdd + 12
                            strFGroupVal = strFGroupVal & strFVal & CStr(Chr(30))
                            strPadLeft1 = ""
                            strPadLeft2 = ""
                        End If
                    End If

                    ' Reviewer
                    If Not IsDBNull(tblMainInfor.Rows(0).Item("Reviewer")) Then
                        If Not tblMainInfor.Rows(0).Item("Reviewer") = "" Then
                            strFVal = objBCSP.ToUTF8(tblMainInfor.Rows(0).Item("Reviewer"))
                            intFLen = Len(strFVal) + 1
                            strRecVal = strRecVal & "912" & strPadLeft1.PadLeft(4 - Len(CStr(intFLen)), "0") & intFLen & strPadLeft2.PadLeft(5 - Len(CStr(Len(strFGroupVal))), "0") & Len(strFGroupVal)
                            intBaseAdd = intBaseAdd + 12
                            strFGroupVal = strFGroupVal & strFVal & CStr(Chr(30))
                            strPadLeft1 = ""
                            strPadLeft2 = ""
                        End If
                    End If

                    ' MediumCode
                    If Not IsDBNull(tblMainInfor.Rows(0).Item("MediumCode")) Then
                        If Not tblMainInfor.Rows(0).Item("MediumCode") = "" Then
                            strFVal = objBCSP.ToUTF8(tblMainInfor.Rows(0).Item("MediumCode"))
                            intFLen = Len(strFVal) + 1
                            strRecVal = strRecVal & "925" & strPadLeft1.PadLeft(4 - Len(CStr(intFLen)), "0") & intFLen & strPadLeft2.PadLeft(5 - Len(CStr(Len(strFGroupVal))), "0") & Len(strFGroupVal)
                            intBaseAdd = intBaseAdd + 12
                            strFGroupVal = strFGroupVal & strFVal & CStr(Chr(30))
                            strPadLeft1 = ""
                            strPadLeft2 = ""
                        End If
                    End If

                    ' AccessLevel
                    If Not IsDBNull(tblMainInfor.Rows(0).Item("AccessLevel")) Then
                        If tblMainInfor.Rows(0).Item("AccessLevel") > 0 Then
                            strFVal = tblMainInfor.Rows(0).Item("AccessLevel")
                            intFLen = Len(strFVal) + 1
                            strRecVal = strRecVal & "926" & strPadLeft1.PadLeft(4 - Len(CStr(intFLen)), "0") & intFLen & strPadLeft2.PadLeft(5 - Len(CStr(Len(strFGroupVal))), "0") & Len(strFGroupVal)
                            intBaseAdd = intBaseAdd + 12
                            strFGroupVal = strFGroupVal & strFVal & CStr(Chr(30))
                            strPadLeft1 = ""
                            strPadLeft2 = ""
                        End If
                    End If

                    ' TypeCode
                    If Not IsDBNull(tblMainInfor.Rows(0).Item("TypeCode")) Then
                        If Not tblMainInfor.Rows(0).Item("TypeCode") = "" Then
                            strFVal = objBCSP.ToUTF8(tblMainInfor.Rows(0).Item("TypeCode"))
                            intFLen = Len(strFVal) + 1
                            strRecVal = strRecVal & "927" & strPadLeft1.PadLeft(4 - Len(CStr(intFLen)), "0") & intFLen & strPadLeft2.PadLeft(5 - Len(CStr(Len(strFGroupVal))), "0") & Len(strFGroupVal)
                            intBaseAdd = intBaseAdd + 12
                            strFGroupVal = strFGroupVal & strFVal & CStr(Chr(30))
                            strPadLeft1 = ""
                            strPadLeft2 = ""
                        End If
                    End If

                    intTotalLen = intTotalLen + Len(strRecVal) + Len(strFGroupVal)
                    strLeader = strPadLeft1.PadLeft(5 - Len(CStr(intTotalLen)), "0") & intTotalLen & Mid(tblMainInfor.Rows(0).Item("Leader"), 6, 7) & strPadLeft1.PadLeft(5 - Len(CStr(intBaseAdd)), "0") & intBaseAdd & Right(tblMainInfor.Rows(0).Item("Leader"), 7)
                    strPadLeft1 = ""
                    strPadLeft2 = ""
                    strRecVal = objBCSP.ToUTF8Back(strLeader & strRecVal & CStr(Chr(31)) & strFGroupVal & CStr(Chr(29)))
                    CreateISORec = strRecVal
                End If
            Catch ex As Exception
                CreateISORec = ex.Message
            End Try
        End Function

        ' CreateISOREC function
        ' Purpose: View record with ISOAuthority type
        Public Function CreateISOAuthorityRec() As String
            Dim ft As Char = Chr(30) '#
            Dim rt As Char = Chr(29) '#
            Dim si As Char = Chr(31) '$
            Dim TotalLen, BaseAdd, Flen As Integer
            Dim Dir, RecVal, FVal, Indicators As String
            Dim Leader, Record, Recwbr As String
            Dim rowMain, rowDetail As DataRow
            Dim tblMainInfor As New DataTable, tblDetailInfor As New DataTable
            Try
                tblMainInfor = GetItemMainInfor()
                tblDetailInfor = GetItemDetailInfor()

                If tblMainInfor.Rows.Count > 0 Then
                    rowMain = tblMainInfor.Rows.Item(0)
                    TotalLen = 28 ' Recounter
                    BaseAdd = 25
                    Dir = ""
                    RecVal = ""
                    If Not IsDBNull(rowMain.Item("Code")) And Not rowMain.Item("Code") = "" Then
                        FVal = objBCSP.ConvertIt(rowMain.Item("Code"))
                        Flen = Len(FVal) + 1
                        Dir = Dir & "001" & Strings.StrDup(4 - Len(CStr(Flen)), "0") & Flen & "00000"
                        BaseAdd = BaseAdd + 12
                        RecVal = RecVal & FVal & ft
                    End If

                    For Each rowDetail In tblDetailInfor.Rows 'Do While Not rs2.EOF
                        If Not IsDBNull(rowDetail.Item("Indicators")) Or Not IsDBNull(rowDetail.Item("VietIndicators")) Then
                            If Not IsDBNull(rowDetail.Item("Ind1")) AndAlso Not rowDetail.Item("Ind1") = "" Then
                                Indicators = rowDetail.Item("Ind1")
                            Else
                                Indicators = " "
                            End If
                            If Not IsDBNull(rowDetail.Item("Ind2")) AndAlso Not rowDetail.Item("Ind2") = "" Then
                                Indicators = Indicators & rowDetail.Item("Ind2")
                            Else
                                Indicators = Indicators & " "
                            End If
                        End If

                        If Not IsDBNull(rowDetail) Then
                            If Not IsDBNull(rowDetail.Item("Content")) And Not IsDBNull(rowDetail.Item("FieldCode")) Then
                                FVal = Indicators & objBCSP.Symbolize(objBCSP.ConvertIt(rowDetail.Item("Content")), rowDetail.Item("FieldCode"))
                            End If
                        End If

                        Flen = Len(FVal) + 1
                        Dir = Dir & rowDetail.Item("FieldCode") & Strings.StrDup(4 - Len(CStr(Flen)), "0") & Flen & Strings.StrDup(5 - Len(CStr(Len(RecVal))), "0") & Len(RecVal)
                        BaseAdd = BaseAdd + 12
                        RecVal = RecVal & FVal & ft
                    Next

                    If Not IsDBNull(rowMain.Item("Cataloguer")) And Not rowMain.Item("Cataloguer") = "" Then
                        FVal = objBCSP.ConvertIt(rowMain.Item("Cataloguer"))
                        Flen = Len(FVal) + 1
                        Dir = Dir & "911" & Strings.StrDup(4 - Len(CStr(Flen)), "0") & Flen & Strings.StrDup(5 - Len(CStr(Len(RecVal))), "0") & Len(RecVal)
                        BaseAdd = BaseAdd + 12
                        RecVal = RecVal & FVal & ft
                    End If

                    If Not IsDBNull(rowMain.Item("Reviewer")) And Not rowMain.Item("Reviewer") = "" Then
                        FVal = objBCSP.ConvertIt(rowMain.Item("Reviewer"))
                        Flen = Len(FVal) + 1
                        Dir = Dir & "912" & Strings.StrDup(4 - Len(CStr(Flen)), "0") & Flen & Strings.StrDup(5 - Len(CStr(Len(RecVal))), "0") & Len(RecVal)
                        BaseAdd = BaseAdd + 12
                        RecVal = RecVal & FVal & ft
                    End If

                    TotalLen = TotalLen + Len(Dir) + Len(RecVal)
                    Leader = Strings.StrDup(5 - Len(CStr(TotalLen)), "0") & TotalLen & Mid(rowMain.Item("Leader"), 6, 7) & Strings.StrDup(5 - Len(CStr(BaseAdd)), "0") & BaseAdd & Right(rowMain.Item("Leader"), 7)
                    Record = Leader & Dir & ft & RecVal & rt
                    Record = Strings.StrDup(5 - Len(CStr(Len(Record))), "0") & CStr(Len(Record)) & Right(Record, Len(Record) - 5)

                    While Len(Record) > 0
                        If Len(Record) > 80 Then
                            Recwbr = Recwbr & Left(Record, 80) & Chr(13)
                            Record = Right(Record, Len(Record) - 80)
                        Else
                            Recwbr = Recwbr & Record
                            Record = ""
                        End If
                    End While
                End If
                Recwbr = "<PRE>" & Chr(13) & Recwbr & Chr(13) & "</PRE>"
                CreateISOAuthorityRec = Recwbr
            Catch ex As Exception
                strErrorMsg = ex.Message
                CreateISOAuthorityRec = strErrorMsg
            End Try
        End Function

        ' CreateISBDRec function
        ' Purpose: View record with ISBD type
        Public Function CreateISBDRec() As String
            Dim intIndex, intIndex1 As Integer, ISBDStr As String
            Dim rowMain, rowDetail As DataRow
            Dim rowView As DataRowView
            Dim tblMainInfor, tblDetailInfor As DataTable
            tblMainInfor = GetItemMainInfor()
            tblDetailInfor = GetItemDetailInfor(True)

            Try
                If tblMainInfor.Rows.Count > 0 Then
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '100'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        rowView = tblDetailInfor.DefaultView.Item(0)
                        ISBDStr = ISBDStr & "<B>" & rowView.Item("Content") & "</B>"
                    Else
                        tblDetailInfor.DefaultView.RowFilter = "FieldCode = '110'"
                        If tblDetailInfor.DefaultView.Count > 0 Then
                            rowView = tblDetailInfor.DefaultView.Item(0)
                            ISBDStr = ISBDStr & "<B>" & rowView.Item("Content") & "</B>"
                        Else
                            tblDetailInfor.DefaultView.RowFilter = "FieldCode = '111'"
                            If tblDetailInfor.DefaultView.Count > 0 Then
                                rowView = tblDetailInfor.DefaultView.Item(0)
                                ISBDStr = ISBDStr & "<B>" & rowView.Item("Content") & "</B>"
                            End If
                        End If
                    End If

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '245'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            If rowView.Item("Content").ToString() <> "" Then
                                ISBDStr = ISBDStr & ". - " & rowView.Item("Content")
                                If (ISBDStr.Substring(0, 4) = ". - ") Then
                                    ISBDStr = ISBDStr.Substring(4)
                                End If
                            End If
                        End If
                    Next

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '250'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then ISBDStr = ISBDStr & ". - " & rowView.Item("Content")
                    Next

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '260'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then ISBDStr = ISBDStr & ". - " & rowView.Item("Content")
                    Next

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '300'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then ISBDStr = ISBDStr & ". - " & rowView.Item("Content")
                    Next

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '400'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then ISBDStr = ISBDStr & ". - " & rowView.Item("Content")
                    Next

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode LIKE '5%'"
                    If tblDetailInfor.DefaultView.Count > 0 Then ISBDStr = ISBDStr & "<BR>"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            ISBDStr = ISBDStr & "-" & rowView.Item("Content")
                        End If
                    Next

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '020'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            ISBDStr = ISBDStr & ". - " & rowView.Item("Content")
                        End If
                    Next

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '022'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                            ISBDStr = ISBDStr & ". - " & rowView.Item("Content")
                        End If
                    Next
                End If
                CreateISBDRec = ISBDStr
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function CreateISBDAuthor() As String
            Dim intIndex, intIndex1 As Integer, ISBDStr As String
            Dim rowMain, rowDetail As DataRow
            Dim rowView As DataRowView
            Dim tblMainInfor, tblDetailInfor As DataTable
            tblMainInfor = GetItemMainInfor()
            'tblDetailInfor = GetItemDetailInfor(True)
            tblDetailInfor = GetItemDetailInforAuthorDDC(True)

            Try
                If tblMainInfor.Rows.Count > 0 Then
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '100'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        rowView = tblDetailInfor.DefaultView.Item(0)
                        ISBDStr = ISBDStr & "<span style='text-transform: uppercase;;'><B>" & rowView.Item("Content") & "</B></span>"
                    Else
                        tblDetailInfor.DefaultView.RowFilter = "FieldCode = '110'"
                        If tblDetailInfor.DefaultView.Count > 0 Then
                            rowView = tblDetailInfor.DefaultView.Item(0)
                            ISBDStr = ISBDStr & "<B>" & rowView.Item("Content") & "</B>"
                        Else
                            tblDetailInfor.DefaultView.RowFilter = "FieldCode = '111'"
                            If tblDetailInfor.DefaultView.Count > 0 Then
                                rowView = tblDetailInfor.DefaultView.Item(0)
                                ISBDStr = ISBDStr & "<B>" & rowView.Item("Content") & "</B>"
                            End If
                        End If
                    End If

                    Dim content245np As String = ""
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '245'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            If rowView.Item("Content").ToString() <> "" Then
                                Dim split245np() As String = rowView.Item("Content").ToString().Split("^")
                                Dim tempContent As String = split245np(0)
                                If (split245np.Length > 1) Then
                                    content245np = split245np(1)
                                End If
                                ISBDStr = ISBDStr & ". - " & tempContent
                                If (ISBDStr.Substring(0, 4) = ". - ") Then
                                    ISBDStr = ISBDStr.Substring(4)
                                End If
                            End If
                        End If
                    Next

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '250'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then ISBDStr = ISBDStr & ". - " & rowView.Item("Content")
                    Next

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '260'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then ISBDStr = ISBDStr & ". - " & rowView.Item("Content")
                    Next

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '300'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then ISBDStr = ISBDStr & ". - " & rowView.Item("Content")
                    Next

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '400'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then ISBDStr = ISBDStr & ". - " & rowView.Item("Content")
                    Next

                    If (Not (content245np = "")) Then
                        ISBDStr = ISBDStr & "<BR>"
                        Dim tempSplitContent245np() As String = content245np.Split(":")
                        If (Not IsNothing(tempSplitContent245np(1))) AndAlso ((tempSplitContent245np(1).Trim() <> "")) Then
                            ISBDStr = ISBDStr & "-" & content245np
                        Else
                            ISBDStr = ISBDStr & "-" & tempSplitContent245np(0)
                        End If
                    End If

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode LIKE '5%'"
                    If tblDetailInfor.DefaultView.Count > 0 Then ISBDStr = ISBDStr & "<BR>"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            ISBDStr = ISBDStr & "-" & rowView.Item("Content")
                        End If
                    Next

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '020'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            ISBDStr = ISBDStr & ". - " & rowView.Item("Content")
                        End If
                    Next

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '022'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                            ISBDStr = ISBDStr & ". - " & rowView.Item("Content")
                        End If
                    Next
                End If
                CreateISBDAuthor = ISBDStr
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' CreateCatalogCard function
        ' Purpose: View record with Catalog Card type
        Public Function CreateCatalogCard() As String
            Dim intIndex, intCount, intIndex1 As Integer, ISBDStr As String, FoundKey, HasSum
            Dim rowMain, rowDetail As DataRow, rowView As DataRowView
            Dim tblMainInfor, tblDetailInfor As DataTable
            tblMainInfor = GetItemMainInfor()
            tblDetailInfor = GetItemDetailInfor()

            Try
                If tblMainInfor.Rows.Count > 0 Then
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '100'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            ISBDStr = ISBDStr & "<B>" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "</B><BR>"
                        End If
                    Next


                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '110'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            ISBDStr = ISBDStr & "<B>" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "</B><BR>"
                        End If
                    Next

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '111'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            ISBDStr = ISBDStr & "<B>" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "</B><BR>"
                        End If
                    Next

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '245'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            ISBDStr = ISBDStr & "<B>" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "</B><BR>"
                        End If
                    Next

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '250'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            ISBDStr = ISBDStr & "<B>" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "</B><BR>"
                        End If
                    Next

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '260'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            ISBDStr = ISBDStr & "<B>" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "</B><BR>"
                        End If
                    Next

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '300'"

                    If tblDetailInfor.DefaultView.Count > 0 Then
                        ISBDStr = ISBDStr & "<P>"
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                                ISBDStr = ISBDStr & Chr(13) & Chr(13) & Chr(13) & Chr(13) & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "</B><BR>"
                            End If
                        Next
                    End If

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '440' OR FieldCode = '490'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                            ISBDStr = ISBDStr & Chr(13) & Chr(13) & Chr(13) & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "</B>" & "-"
                        End If
                    Next

                    If Not IsDBNull(ISBDStr) And Right(ISBDStr, 1) = "-" Then
                        ISBDStr = Left(ISBDStr, Len(ISBDStr) - 1)
                    End If

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode LIKE '5%' AND FieldCode <> '520' AND FieldCode <> '505'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                            ISBDStr = ISBDStr & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "</B><BR>"
                        End If
                    Next

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '520'"
                    HasSum = 0
                    For Each rowView In tblDetailInfor.DefaultView
                        HasSum = 1
                        If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                            ISBDStr = ISBDStr & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "</B><BR>"
                        End If
                    Next

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '505'"

                    For Each rowView In tblDetailInfor.DefaultView
                        HasSum = 1
                        If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                            ISBDStr = ISBDStr & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "</B><BR>"
                        End If
                    Next

                    If HasSum = 1 Then
                        ISBDStr = ISBDStr & "<BR>"
                    End If

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '020'"

                    For Each rowView In tblDetailInfor.DefaultView
                        HasSum = 1
                        If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                            ISBDStr = ISBDStr & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "</B><BR>"
                        End If
                    Next

                    ISBDStr = ISBDStr & "<BR>"

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '022'"

                    For Each rowView In tblDetailInfor.DefaultView
                        HasSum = 1
                        If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                            ISBDStr = ISBDStr & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "</B><BR>"
                        End If
                    Next

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode LIKE '6%'"
                    intIndex = 1

                    For Each rowView In tblDetailInfor.DefaultView 'If Not rs1.EOF Then
                        FoundKey = 1
                        If Not IsDBNull(rowView.Item("Content")) And rowView.Item("Content") <> "" Then
                            ISBDStr = ISBDStr & intIndex & ". " & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ". "
                            intIndex = intIndex + 1
                        End If

                    Next
                    Dim RomanNum() As String = {"I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII", "XIII", "XIV", "XV", "XVI", "XVII", "XVIII", "XIX", "XX"}

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '700'"
                    intCount = 0
                    For Each rowView In tblDetailInfor.DefaultView 'If Not rs1.EOF Then
                        If Not FoundKey = 1 Then
                            If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                                ISBDStr = ISBDStr & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & "<BR>"
                            End If
                            FoundKey = 1
                        End If
                        ISBDStr = ISBDStr & RomanNum(intCount) & ". " & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ". " & "<br>"
                        intCount = intCount + 1
                    Next

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '710'"

                    For Each rowView In tblDetailInfor.DefaultView 'If Not rs1.EOF Then
                        If Not FoundKey = 1 Then
                            If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                                ISBDStr = ISBDStr & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & "<BR>"
                                FoundKey = 1
                            End If
                        End If
                        ISBDStr = ISBDStr & RomanNum(intCount) & ". " & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ". " & "<br>"
                        intCount = intCount + 1
                    Next

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode LIKE '2%' AND FieldCode < '250' AND FieldCode <> '245'"

                    For Each rowView In tblDetailInfor.DefaultView 'If Not rs1.EOF Then
                        If Not FoundKey = 1 Then
                            If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                                ISBDStr = ISBDStr & "Chr(13);Chr(13);Chr(13);Chr(13);Chr(13);Chr(13);Chr(13);Chr(13);"
                                FoundKey = 1
                            End If
                        End If
                        ISBDStr = ISBDStr & RomanNum(intCount) & ". " & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ". " & "<br>"
                        intCount = intCount + 1
                    Next

                    If FoundKey = 1 Then
                        ISBDStr = ISBDStr & "<P>"
                    End If

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '082'"

                    Dim SubVal()
                    For Each rowView In tblDetailInfor.DefaultView 'If Not rs1.EOF Then
                        If Not IsDBNull(rowView.Item("Content")) Then
                            ISBDStr = ISBDStr & "Dewey Class no. : "
                            intIndex1 = 0
                            ISBDStr = ISBDStr & RomanNum(intCount) & ". " & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ". " & "<br>"
                            intCount = intCount + 1

                            Call objBCSP.ParseField("$a,$2", CType(tblDetailInfor.DefaultView.Item(0), DataRowView).Item("Content"), "", SubVal)
                            If intIndex1 = 0 Then
                                ISBDStr = ISBDStr & Replace(objBCSP.ConvertIt(SubVal(0)), "''", "'")
                                intIndex1 = 1
                            Else
                                ISBDStr = ISBDStr & ", " & Replace(objBCSP.ConvertIt(SubVal(0)), "''", "'")
                            End If
                            If Not SubVal(1) = "" Then
                                ISBDStr = ISBDStr & " -- dc " & SubVal(1) & "<BR>"
                            End If
                        End If
                    Next

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode LIKE '090'"

                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            ISBDStr = ISBDStr & "Call no. : <B>" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "</B><BR>"
                        End If
                    Next
                End If

                CreateCatalogCard = ISBDStr
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' CreateXMLTAG function
        ' Purpose: View record with XMLTAG type
        Public Function CreateXMLTAG() As String
            Dim strXML As String = "", strIndicators As String, strInd1 As String, strInd2 As String, intIndicatorsLen As Long
            Dim strFieldValue As String, subtag() As String, intIndex, intIndex1 As Integer, FVal As String
            Dim rowMain, rowDetail As DataRow, rowView As DataRowView

            Dim tblMainInfor, tblDetailInfor As DataTable

            tblMainInfor = GetItemMainInfor()
            tblDetailInfor = GetItemDetailInfor()

            Try
                If Not tblMainInfor Is Nothing AndAlso tblMainInfor.Rows.Count > 0 Then
                    If InterfaceLanguage = "tcvn" Or InterfaceLanguage = "vni" Then
                        strXML = "<?xml version=""1.0"" encoding='iso8859-1'?>"
                    Else
                        strXML = "<?xml version=""1.0"" encoding=""UTF-8""?>"
                    End If

                    strXML = strXML & "<collection xmlns=""http://www.loc.gov/MARC21/slim"">"
                    strXML = strXML & "<record>"
                    strXML = strXML & "<leader>" & tblMainInfor.Rows.Item(0)("Leader") & "</leader>"

                    If Not IsDBNull(tblMainInfor.Rows.Item(0)("Code")) Then
                        strXML = strXML & "<controlfield tag='001'>" & tblMainInfor.Rows.Item(0)("Code") & "</controlfield>"
                    End If

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode ='003'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        For Each rowView In tblMainInfor.DefaultView 'If Not rs1.EOF Then
                            If Not IsDBNull(CType(tblDetailInfor.DefaultView.Item(0), DataRowView).Item("Content")) Then
                                strXML = strXML & "<controlfield tag='003'>" & CType(tblDetailInfor.DefaultView.Item(0), DataRowView).Item("Content") & "</controlfield>"
                            End If
                        Next
                    End If

                    For Each rowDetail In tblDetailInfor.Rows
                        If Left(rowDetail.Item("FieldCode"), 2) = "00" Then
                            If Not rowDetail.Item("FieldCode") = "005" Then
                                If Not IsDBNull(rowDetail.Item("FieldCode")) And Not IsDBNull(rowDetail.Item("Content")) Then
                                    strXML = strXML & "<controlfield tag=" & rowDetail.Item("FieldCode") & rowDetail.Item("Content") & "</controlfield>"
                                End If
                            End If
                        Else
                            strInd1 = rowDetail.Item("Ind1").ToString.Trim
                            strInd2 = rowDetail.Item("Ind2").ToString.Trim
                            strFieldValue = rowDetail("Content").ToString.Trim
                            subtag = Split(strFieldValue, "$")

                            If Trim(strInd2) <> "" Then
                                If Trim(strInd1) <> "" Then
                                    strXML = strXML & "<datafield tag='" & rowDetail.Item("FieldCode") & "' ind1='" & strInd1 & "' ind2='" & strInd2 & "'>"
                                Else
                                    strXML = strXML & "<datafield tag='" & rowDetail.Item("FieldCode") & "' ind1=''" & " ind2='" & strInd2 & "'>"
                                End If
                            Else
                                strXML = strXML & "<datafield tag='" & rowDetail.Item("FieldCode") & " ' ind1= '" & strInd1 & "' ind2= '' >"
                            End If

                            For intIndex1 = LBound(subtag) To UBound(subtag)
                                If Not subtag(intIndex1) = "" Then
                                    strXML = strXML & "<subfield code='" & Left(subtag(intIndex1), 1) & "'>" & Right(subtag(intIndex1), Len(subtag(intIndex1)) - 1) & "</subfield>"
                                End If
                            Next
                            strXML = strXML & "</datafield>"
                        End If
                    Next
                    strXML = strXML & "</record>"
                    strXML = strXML & "</collection>"
                End If
                CreateXMLTAG = strXML
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' CreateXMLDCMI function
        ' Purpose: View record with XMLDCMI type
        Function CreateXMLDCMI() As String
            Dim tblMainInfor As DataTable
            Dim tblDetailInfor As DataTable
            Dim strXMLStream, strTemp As String
            Dim intIndex As Byte
            Dim rowDetail, rowMain As DataRow
            Dim rowView As DataRowView
            Dim rowMainView As DataRowView
            Dim strDocIDs As String
            Dim ArrSubRecords()
            Dim objArr() As Object

            Try
                tblMainInfor = GetItemMainInfor()
                tblDetailInfor = GetItemDetailInfor()

                Call objBCSP.GLoadArray(ItemIDs, objArr, ",")

                If Not IsDBNull(objArr) Then
                    For intIndex = LBound(objArr) To UBound(objArr)
                        strDocIDs = strDocIDs & objArr(intIndex) & ", "
                    Next
                End If

                strDocIDs = Left(strDocIDs, Len(strDocIDs) - 2)
                If InterfaceLanguage = "tcvn" Or InterfaceLanguage = "vni" Then
                    strXMLStream = "<?xml version=""1.0"" encoding=""iso8859-1""?>" '& Chr(13)
                Else
                    strXMLStream = "<?xml version=""1.0"" encoding=""UTF-8""?>" '& Chr(13)
                End If

                'strXMLStream = strXMLStream & "<!DOCTYPE rdf:RDF SYSTEM  ""DTDFiles/LibolDC.dtd"">" '& Chr(13)
                strXMLStream = strXMLStream & "<rdf:RDF xmlns:dc=""xmlfiles/dcns.xml"" xmlns:rdf=""xmlfiles/rdfns.xml"">" '& Chr(13)

                For intIndex = LBound(objArr) To UBound(objArr)
                    strXMLStream = strXMLStream & "<rdf:Description>"
                    'ItemID : before Tai_lieu_ID
                    tblDetailInfor.DefaultView.RowFilter = "ItemID = " & objArr(intIndex)
                    tblMainInfor.DefaultView.RowFilter = "ItemID = " & objArr(intIndex)

                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("FieldCode")) And CInt(rowView.Item("FieldCode")) = "245" Then
                            strXMLStream = strXMLStream & "<dc:title>"
                            strXMLStream = strXMLStream & Trim(objBCSP.TheDisplayOne(objBCSP.TrimSubFieldCodes(objBCSP.ConvertIt(rowView.Item("Content")))))
                            strXMLStream = strXMLStream & "</dc:title>"
                        End If
                    Next

                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("FieldCode")) And (CInt(rowView.Item("FieldCode")) = "100" Or CInt(rowView.Item("FieldCode")) = "110" Or CInt(rowView.Item("FieldCode")) = "111" Or CInt(rowView.Item("FieldCode")) = "700" Or CInt(rowView.Item("FieldCode")) = "710" Or CInt(rowView.Item("FieldCode")) = "711" Or CInt(rowView.Item("FieldCode")) = "720") Then
                            strXMLStream = strXMLStream & "<dc:creator>"
                            strXMLStream = strXMLStream & Trim(objBCSP.TrimSubFieldCodes(objBCSP.ConvertIt(rowView.Item("Content"))))
                            strXMLStream = strXMLStream & "</dc:creator>"
                        End If
                    Next

                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("FieldCode")) And (CInt(rowView.Item("FieldCode")) = "600" Or CInt(rowView.Item("FieldCode")) = "610" Or CInt(rowView.Item("FieldCode")) = "611" Or CInt(rowView.Item("FieldCode")) = "630" Or CInt(rowView.Item("FieldCode")) = "650" Or CInt(rowView.Item("FieldCode")) = "653") Then
                            strXMLStream = strXMLStream & "<dc:subject>"
                            strXMLStream = strXMLStream & Trim(objBCSP.TrimSubFieldCodes(objBCSP.ConvertIt(rowView.Item("Content"))))
                            strXMLStream = strXMLStream & "</dc:subject>"
                        End If
                    Next

                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("FieldCode")) And (CInt(rowView.Item("FieldCode")) = "500" Or CInt(rowView.Item("FieldCode")) = "501" Or CInt(rowView.Item("FieldCode")) = "502" Or CInt(rowView.Item("FieldCode")) = "503" Or CInt(rowView.Item("FieldCode")) = "504" Or CInt(rowView.Item("FieldCode")) = "505" Or CInt(rowView.Item("FieldCode")) = "507" Or CInt(rowView.Item("FieldCode")) = "508" Or CInt(rowView.Item("FieldCode")) = "510" Or CInt(rowView.Item("FieldCode")) = "511" Or CInt(rowView.Item("FieldCode")) = "512" Or CInt(rowView.Item("FieldCode")) = "513") Then
                            strTemp = Trim(objBCSP.TrimSubFieldCodes(objBCSP.ConvertIt(rowView.Item("Content"))))
                            strXMLStream = strXMLStream & "<dc:description>"
                            strXMLStream = strXMLStream & strTemp
                            strXMLStream = strXMLStream & "</dc:description>"
                        End If
                    Next

                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("FieldCode")) And CInt(rowView.Item("FieldCode")) = "260" Then

                            If Not IsDBNull(rowView.Item("Content")) Then
                                Call objBCSP.ParseField("$a,$b,$c", rowView.Item("Content"), "nc ", ArrSubRecords)
                            End If

                            If Not ArrSubRecords(0) = "" Or ArrSubRecords(1) = "" Then
                                strXMLStream = strXMLStream & "<dc:publisher>"
                                strXMLStream = strXMLStream & Trim(objBCSP.ConvertIt(ArrSubRecords(0) & ArrSubRecords(1)))
                                strXMLStream = strXMLStream & "</dc:publisher>"
                            End If
                            If Not ArrSubRecords(2) = "" Then
                                strXMLStream = strXMLStream & "<dc:date>"
                                strXMLStream = strXMLStream & Trim(objBCSP.ConvertIt(ArrSubRecords(2)))
                                strXMLStream = strXMLStream & "</dc:date>"
                            End If
                        End If
                    Next

                    For Each rowMainView In tblMainInfor.DefaultView 'If Not RSLeader.EOF Then
                        Select Case Mid(rowMainView.Item("Leader"), 7, 1)
                            Case "a", "c", "d", "t"
                                strTemp = "text"
                            Case "e", "f", "g", "intCount"
                                strTemp = "image"
                            Case "m", "o", "p", "r"
                                strTemp = "no type provided"
                            Case Else
                                Select Case Mid(rowMainView.Item("Leader"), 8, 1)
                                    Case "c", "s", "p"
                                        strTemp = "collection"
                                End Select
                        End Select
                        strXMLStream = strXMLStream & "<dc:type>"
                        strXMLStream = strXMLStream & strTemp
                        strXMLStream = strXMLStream & "</dc:type>"
                    Next

                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("FieldCode")) And CInt(rowView.Item("FieldCode")) = "655" Then
                            strXMLStream = strXMLStream & "<dc:type>"
                            strXMLStream = strXMLStream & Trim(objBCSP.TrimSubFieldCodes(objBCSP.ConvertIt(rowView.Item("Content"))))
                            strXMLStream = strXMLStream & "</dc:type>"
                        End If
                    Next

                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("FieldCode")) And CInt(rowView.Item("FieldCode")) = "856" Then
                            If Not IsDBNull(rowView.Item("Content")) Then
                                Call objBCSP.ParseField("$q,$u", rowView.Item("Content"), "nc ", ArrSubRecords)
                            End If

                            If Not ArrSubRecords(0) = "" Then
                                strXMLStream = strXMLStream & "<dc:format>"
                                strXMLStream = strXMLStream & objBCSP.ConvertIt(ArrSubRecords(0))
                                strXMLStream = strXMLStream & "</dc:format>"
                            End If
                            If Not ArrSubRecords(1) = "" Then
                                strXMLStream = strXMLStream & "<dc:identifier>"
                                strXMLStream = strXMLStream & objBCSP.ConvertIt(ArrSubRecords(1))
                                strXMLStream = strXMLStream & "</dc:identifier>"
                            End If
                        End If
                    Next

                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("FieldCode")) And CInt(rowView.Item("FieldCode")) = "786" Then
                            Call objBCSP.ParseField("$o,$t", rowView.Item("Content"), "nc ", ArrSubRecords)
                            If Not ArrSubRecords(0) = "" Or Not ArrSubRecords(1) = "" Then
                                strXMLStream = strXMLStream & "<dc:source>"
                                strXMLStream = strXMLStream & objBCSP.ConvertIt(ArrSubRecords(0) & ArrSubRecords(1))
                                strXMLStream = strXMLStream & "</dc:source>"
                            End If
                        End If
                    Next

                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("FieldCode")) And CInt(rowView.Item("FieldCode")) = 8 Then
                            strXMLStream = strXMLStream & "<dc:language>"
                            strXMLStream = strXMLStream & Mid(rowView.Item("Content"), 36, 3)
                            strXMLStream = strXMLStream & "</dc:language>"
                        End If
                        If Not IsDBNull(rowView.Item("FieldCode")) And CInt(rowView.Item("FieldCode")) = "546" Then
                            strXMLStream = strXMLStream & "<dc:language>"
                            strXMLStream = strXMLStream & objBCSP.TrimSubFieldCodes(objBCSP.ConvertIt(rowView.Item("Content")))
                            strXMLStream = strXMLStream & "</dc:language>"
                        End If
                    Next

                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("FieldCode")) And CInt(rowView.Item("FieldCode")) = "530" Then
                            strXMLStream = strXMLStream & "<dc:relation>"
                            strXMLStream = strXMLStream & objBCSP.TrimSubFieldCodes(objBCSP.ConvertIt(rowView.Item("Content")))
                            strXMLStream = strXMLStream & "</dc:relation>"
                        End If
                        If Not IsDBNull(rowView.Item("FieldCode")) And (CInt(rowView.Item("FieldCode")) >= "760" And CInt(rowView.Item("FieldCode")) <= "787") Then
                            Call objBCSP.ParseField("$o,$t", rowView.Item("Content"), "nc ", ArrSubRecords)
                            If (Not IsDBNull(ArrSubRecords(0)) And Not ArrSubRecords(0) = "") Or (Not IsDBNull(ArrSubRecords(1)) And Not ArrSubRecords(1) = "") Then
                                strXMLStream = strXMLStream & "<dc:relation>"
                                strXMLStream = strXMLStream & objBCSP.ConvertIt(ArrSubRecords(0) & ArrSubRecords(1))
                                strXMLStream = strXMLStream & "</dc:relation>"
                            End If
                        End If
                    Next

                    For Each rowView In tblDetailInfor.DefaultView
                        If CInt(rowView.Item("FieldCode")) = "651" Or CInt(rowView.Item("FieldCode")) = "752" Then
                            strXMLStream = strXMLStream & "<dc:coverage>"
                            strXMLStream = strXMLStream & objBCSP.TrimSubFieldCodes(objBCSP.ConvertIt(rowView.Item("Content")))
                            strXMLStream = strXMLStream & "</dc:coverage>"
                        End If
                    Next

                    For Each rowView In tblDetailInfor.DefaultView
                        If CInt(rowView.Item("FieldCode")) = "540" Or CInt(rowView.Item("FieldCode")) = "506" Then
                            strXMLStream = strXMLStream & "<dc:rights>"
                            strXMLStream = strXMLStream & objBCSP.TrimSubFieldCodes(objBCSP.ConvertIt(rowView.Item("Content")))
                            strXMLStream = strXMLStream & "</dc:rights>"
                        End If
                    Next
                    strXMLStream = strXMLStream & "</rdf:Description>"
                Next

                strXMLStream = strXMLStream & "</rdf:RDF>"
                CreateXMLDCMI = strXMLStream
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetAvailableItems method 
        ' Purpose: Get the Item is available at the moment
        ' Input: strItemIDs
        ' Output: DataTable
        Public Function GetAvailableItems() As DataTable
            Try
                objDItemCollection.ItemIDs = strItemIDs
                GetAvailableItems = objBCDBS.ConvertTable(objDItemCollection.GetAvailableItems)
                strErrorMsg = objDItemCollection.ErrorMsg
                intErrorCode = objDItemCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: Get the Holding copies of item
        ' GetItemCount method 
        ' Input: strItemIDs
        ' Output: DataTable
        Public Function GetItemCount() As DataTable
            Try
                objDItemCollection.ItemIDs = strItemIDs
                GetItemCount = objBCDBS.ConvertTable(objDItemCollection.GetItemCount)
                strErrorMsg = objDItemCollection.ErrorMsg
                intErrorCode = objDItemCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetLoanHistory method 
        ' Purpose: Get the Item is being loaned
        ' Input: strItemIDs
        ' Output: DataTable
        Public Function GetLoanHistory() As DataTable
            Try
                objDItemCollection.ItemIDs = strItemIDs
                GetLoanHistory = objBCDBS.ConvertTable(objDItemCollection.GetLoanHistory)
                strErrorMsg = objDItemCollection.ErrorMsg
                intErrorCode = objDItemCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetOrderedItems method
        ' Purpose: Get the Item ordered details
        ' Input: strTitle
        ' Output: DataTable
        Public Function GetOrderedItems() As DataTable
            Try
                objDItemCollection.Title = objBCSP.ConvertItBack(strTitle)
                objDItemCollection.LibID = intLibID
                GetOrderedItems = objBCDBS.ConvertTable(objDItemCollection.GetOrderedItems)
                strErrorMsg = objDItemCollection.ErrorMsg
                intErrorCode = objDItemCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: GetCatalogueStatOverView
        ' Purpose: 
        ' Input: 
        ' Output: DataTable result
        Public Function GetCatalogueStatOverView() As DataTable
            Try
                objDItemCollection.LibID = intLibID
                GetCatalogueStatOverView = objDItemCollection.GetCatalogueStatOverView()
                strErrorMsg = objDItemCollection.ErrorMsg
                intErrorCode = objDItemCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Sub UpdateLoanTypeOfCopies(ByVal strCopyNumberIDs As String, ByVal intLoanTypeID As Integer)
            Try
                objDItemCollection.UpdateLoanTypeOfCopies(strCopyNumberIDs, intLoanTypeID)
                strErrorMsg = objDItemCollection.ErrorMsg
                intErrorCode = objDItemCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Function SearchHolding(ByVal intLoanTypeID As Integer, ByVal strAuthor As String, ByVal strYear As String, ByVal strPub As String, ByVal strISBN As String, ByVal strCN As String, ByVal strTitles As String) As DataTable
            Dim arrFN() As String = Nothing
            Dim arrV() As String = Nothing
            Dim arrBool() As String = Nothing
            Dim strQr As String = ""
            Dim intIndex As Integer = 0
            If strAuthor <> "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrFN(intIndex)
                ReDim Preserve arrV(intIndex)
                arrBool(intIndex) = "AND"
                arrFN(intIndex) = "1"
                arrV(intIndex) = objBCSP.ConvertItBack(strAuthor)
                intIndex = intIndex + 1
            End If
            If strYear <> "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrFN(intIndex)
                ReDim Preserve arrV(intIndex)
                arrBool(intIndex) = "AND"
                arrFN(intIndex) = "YR"
                arrV(intIndex) = objBCSP.ConvertItBack(strYear)
                intIndex = intIndex + 1
            End If
            If strPub <> "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrFN(intIndex)
                ReDim Preserve arrV(intIndex)
                arrBool(intIndex) = "AND"
                arrFN(intIndex) = "2"
                arrV(intIndex) = objBCSP.ConvertItBack(strPub)
                intIndex = intIndex + 1
            End If
            If strISBN <> "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrFN(intIndex)
                ReDim Preserve arrV(intIndex)
                arrBool(intIndex) = "AND"
                arrFN(intIndex) = "IB"
                arrV(intIndex) = objBCSP.ConvertItBack(strISBN)
                intIndex = intIndex + 1
            End If
            If strTitles <> "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrFN(intIndex)
                ReDim Preserve arrV(intIndex)
                arrBool(intIndex) = "AND"
                arrFN(intIndex) = "TI"
                arrV(intIndex) = objBCSP.ConvertItBack(strTitles)
                intIndex = intIndex + 1
            End If
            If strCN <> "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrFN(intIndex)
                ReDim Preserve arrV(intIndex)
                arrBool(intIndex) = "AND"
                arrFN(intIndex) = "BN"
                arrV(intIndex) = objBCSP.ConvertItBack(strCN)
                intIndex = intIndex + 1
            End If

            If Not arrFN Is Nothing AndAlso Not arrV Is Nothing Then
                objBForming.BoolArr = arrBool
                objBForming.FieldArr = arrFN
                objBForming.ValArr = arrV
                strQr = objBForming.FormingASQL
            End If
            objDItemCollection.UserID = intUserID
            SearchHolding = objBCDBS.ConvertTable(objDItemCollection.SearchHolding(intLoanTypeID, strQr), "Content")
        End Function

        '**********************************************************************
        '**********************************************************************
        ' *************************** SERIAL **********************************

        ' GetTitlesPO method
        ' Purpose: get title which like the title of existing items
        ' Input: string of title to cheking
        ' Output: datatable
        Public Function GetExistTitlesPO(ByVal strItemType As String) As DataTable
            Try
                objDItemCollection.Title = strTitle
                GetExistTitlesPO = objBCDBS.ConvertTable(objDItemCollection.GetExistTitlesPO(strItemType))
                intErrorCode = objDItemCollection.ErrorCode
                strErrorMsg = objDItemCollection.ErrorMsg
            Finally
            End Try
        End Function

        Public Function GetSysUserViews(ByVal strUserName As String) As DataTable
            Try
                GetSysUserViews = objBCDBS.ConvertTable(objDItemCollection.GetSysUserViews(strUserName))
            Catch ex As Exception
                strErrorMsg = objDItemCollection.ErrorMsg
                intErrorCode = objDItemCollection.ErrorCode
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        Public Function SearchSerialItems(ByVal strUserName As String, ByVal strViewName As String, ByVal strSQL As String, ByVal strSelectStatement As String, ByVal lngViewID As Long, ByRef strOutPut As String, Optional ByVal intUpdate As Integer = 0) As DataTable
            Try
                objBCDBS.LibID = intLibID
                SearchSerialItems = objBCDBS.SortTable(objBCDBS.ConvertTable(objDItemCollection.SearchSerialItems(strUserName, strViewName, strSQL, strSelectStatement, lngViewID, strOutPut, intUpdate), "TITLE,ISSN"), "TITLE")
                strErrorMsg = objDItemCollection.ErrorMsg
                intErrorCode = objDItemCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        Public Function SearchSerialItemsNoSave(ByVal strSQL As String) As DataTable
            Try
                objBCDBS.LibID = intLibID
                SearchSerialItemsNoSave = objBCDBS.SortTable(objBCDBS.ConvertTable(objDItemCollection.SearchSerialItemsNoSave(strSQL), "TITLE,ISSN"), "TITLE")
                strErrorMsg = objDItemCollection.ErrorMsg
                intErrorCode = objDItemCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        Public Function CheckGroupName(ByVal strUserName As String, ByVal strViewName As String) As Integer
            Try
                CheckGroupName = objDItemCollection.CheckGroupName(strUserName, strViewName)
                strErrorMsg = objDItemCollection.ErrorMsg
                intErrorCode = objDItemCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Sub RemoveSysUserView(ByVal lngViewID As Long)
            Try
                objDItemCollection.RemoveSysUserView(lngViewID)
                strErrorMsg = objDItemCollection.ErrorMsg
                intErrorCode = objDItemCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' GetFreeItemNum
        ' Purpose: Get the Free Copies of item by Item ID
        ' Input: strTitle
        ' Output: DataTable
        Public Function GetFreeItemNum() As DataTable
            Try
                objDItemCollection.ItemID = lngItemID
                GetFreeItemNum = objDItemCollection.GetFreeItemNum
                strErrorMsg = objDItemCollection.ErrorMsg
                intErrorCode = objDItemCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: GetIssueList
        ' Purpose: Get list of issues
        ' Input: Search conditions
        ' Output: DataTable result
        Public Function GetIssueList(ByVal strTitle As String, ByVal strFromDate As String, ByVal strToDate As String, ByVal strIssueNo As String, ByVal strVolume As String) As DataTable
            Try
                GetIssueList = objBCDBS.ConvertTable(objDItemCollection.GetIssueList(objBCSP.ProcessVal(objBCSP.ConvertItBack(strTitle)), objBCDBS.ConvertDateBack(strFromDate), objBCDBS.ConvertDateBack(strToDate), strIssueNo, objBCSP.ConvertItBack(strVolume)))
                strErrorMsg = objDItemCollection.ErrorMsg
                intErrorCode = objDItemCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: GetPeriodicalList  
        ' Purpose: Get list of periodicals
        ' Input: Search conditions
        ' Output: DataTable result
        Public Function GetPeriodicalList(ByVal strTitle As String, ByVal strFromDate As String, ByVal strToDate As String, ByVal strIssueNo As String, ByVal strVolume As String) As DataTable
            Try
                GetPeriodicalList = objBCDBS.ConvertTable(objDItemCollection.GetPeriodicalList(objBCSP.ProcessVal(objBCSP.ConvertItBack(strTitle)), objBCDBS.ConvertDateBack(strFromDate), objBCDBS.ConvertDateBack(strToDate), strIssueNo, objBCSP.ConvertItBack(strVolume)), "Content")
                strErrorMsg = objDItemCollection.ErrorMsg
                intErrorCode = objDItemCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objDItemCollection Is Nothing Then
                    objDItemCollection.Dispose(True)
                    objDItemCollection = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBForming Is Nothing Then
                    objBForming.Dispose(True)
                    objBForming = Nothing
                End If
            Finally
                Me.Dispose()
                MyBase.Dispose()
            End Try
        End Sub

        ' Finalize method
        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class
End Namespace