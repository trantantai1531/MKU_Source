' Purpose: process fiels
' Creator: Oanhtn
' Created Date: 26/04/2004
' Modification history:
'   - 07/05/2004 by Oanhtn: get all none marc fields
'       + Add new method: GetUserFields to get all none marc fields
'   - 11/05/2004 by Oanhtn: get all of linktypes
'       + Add new method: GetLinkTypes to get all of linktypes 
'   - 24/05/2004 by Oanhtn: check existing items by title
'       - Add new method: 
'           + GetExistTitles: to check existing item depending on title
'           + GetItemMainInfor: get all main information of item (Leader, ItemType, ItemMedia...)
'           + GetItemDetailInfor: get all detail information of item (field's values)
'   - 31/05/2004 by Khoana: 
'       - Modify GetRangeItemID method
'Latest Modified By HieuNT On 15/6/2004
'Additional Content : Format Document

Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Catalogue

Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsTempBItemCollection
        Inherits clsBItem

        ' *****************************************************************************************************
        ' Declare Private variables
        ' *****************************************************************************************************

        Private intTypeItem As Integer = 0
        Private intSelectOption As Integer = -1
        'Private objArr() As Object

        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objDItemCollection As New clsDItemCollection

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************
        'Chuyen Input Integer thanh Array
        'Public Property objArray() As Object
        '    Get
        '        Return objArr
        '    End Get
        '    Set(ByVal Value As Object)
        '        objArr = Value
        '    End Set
        'End Property
        ' TypeItem properties
        Public Property TypeItem() As Integer
            Get
                Return intTypeItem
            End Get
            Set(ByVal Value As Integer)
                intTypeItem = Value
            End Set
        End Property

        ' SelectOption properties
        Public Property SelectOption() As Integer
            Get
                Return intSelectOption
            End Get
            Set(ByVal Value As Integer)
                intSelectOption = Value
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

                ' Init base class (clsBItem)
                MyBase.DBServer = strDBServer
                MyBase.InterfaceLanguage = strInterfaceLanguage
                MyBase.ConnectionString = strConnectionString
                Call MyBase.Initialize()
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' GetRangeItemID method
        ' Purpose: Retrieve all items
        ' Output: Datatable
        Public Function GetRangeItemID() As DataTable
            Try
                objDItemCollection.TypeItem = intTypeItem
                GetRangeItemID = objDItemCollection.GetRangeItemID
                strErrorMsg = objDItemCollection.ErrorMsg
                intErrorCode = objDItemCollection.ErrorCode
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
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
                    objDItemCollection.Title = objSubFieldValues(0)
                Else
                    objDItemCollection.Title = "$$$"
                End If
                'objDItemCollection.Title = strTitle
                GetExistTitles = objBCDBS.ConvertTable(objDItemCollection.GetExistTitles)
                intErrorCode = objDItemCollection.ErrorCode
                strErrorMsg = objDItemCollection.ErrorMsg
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' GetItemMainInfor method
        ' Purpose: get all main information of item (Leader, ItemType, ItemMedia...)
        ' Input: string of ItemIDs
        ' Output: Datatable
        Public Function GetItemMainInfor() As DataTable
            Try
                'objDItemCollection.MaxItemID = lngMaxItemID
                'objDItemCollection.MinItemID = lngMinItemID
                'objDItemCollection.SelectOption = intSelectOption
                'objDItemCollection.ItemID = lngItemID
                objDItemCollection.ItemIDs = strItemIDs
                GetItemMainInfor = objBCDBS.ConvertTable(objDItemCollection.GetItemMainInfor)
                strErrorMsg = objDItemCollection.ErrorMsg
                intErrorCode = objDItemCollection.ErrorCode
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' GetItemDetailInfor method
        ' Purpose: get all main information of item (Leader, ItemType, ItemMedia...)
        ' Input: string of ItemIDs
        ' Output: Datatable
        Public Function GetItemDetailInfor() As DataTable
            Try
                objDItemCollection.ItemIDs = strItemIDs
                GetItemDetailInfor = objBCDBS.ConvertTable(objDItemCollection.GetItemDetailInfor)
                strErrorMsg = objDItemCollection.ErrorMsg
                intErrorCode = objDItemCollection.ErrorCode
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        Public Function RetrieveCode_Title() As DataTable
            If strItemIDs = "" Then
                strItemIDs = "0"
            End If
            objDItemCollection.ItemIDs = strItemIDs
            RetrieveCode_Title = objBCDBS.ConvertTable(objDItemCollection.RetrieveCodeTitle_Result(), "TITLE")
        End Function

        Public Function CreateISORec() As String
            Dim ft As Char = Chr(30) '#
            Dim rt As Char = Chr(29) '#
            Dim si As Char = Chr(31) '$
            Dim TotalLen As Long
            Dim BaseAdd As Long
            Dim Leader As String
            Dim Dir As String, RecVal As String, fVal As String, FLen As Long
            Dim Indicators As String, Recwbr As String, Record As String
            Dim i As Long, ISBDStr As String, rowMain, rowDetail As DataRow
            Dim tblMainInfor As New DataTable, tblDetailInfor As New DataTable
            tblMainInfor = GetItemMainInfor()
            tblDetailInfor = GetItemDetailInfor()

            If tblMainInfor.Rows.Count > 0 Then
                rowMain = tblMainInfor.Rows.Item(0)
                TotalLen = 28
                BaseAdd = 25

                If Not IsDBNull(rowMain.Item("Code")) And rowMain.Item("Code") <> "" Then ' Use Main
                    fVal = objBCSP.ConvertIt(rowMain.Item("Code"))
                    FLen = Len(fVal) + 1
                    Dir = Dir & "001" & Strings.StrDup(4 - Len(CStr(FLen)), "0") & FLen & "00000"
                    BaseAdd = BaseAdd + 12
                    RecVal = RecVal & rowMain.Item("Code") & ft 'Use Main
                End If

                For Each rowDetail In tblDetailInfor.Rows
                    If Not IsDBNull(rowDetail.Item("Indicators")) And Not IsDBNull(rowDetail.Item("VietIndicators")) Then
                        If Not rowDetail.Item("Indicators") = "" Or Not rowDetail.Item("VietIndicators") = "" Then
                            Select Case Len(rowDetail.Item("Indicators") & "")
                                Case 0
                                    Indicators = ""
                                Case 1
                                    Indicators = rowDetail.Item("Indicators") & " "
                                Case 2
                                    Indicators = rowDetail.Item("Indicators")
                                Case Else
                                    Indicators = Left(rowDetail.Item("Indicators"), 2)
                            End Select
                        End If
                    End If
                    If Not IsDBNull(rowDetail.Item("Content")) And Not IsDBNull(rowDetail.Item("FieldCode")) Then
                        fVal = Indicators & objBCSP.Symbolize(objBCSP.ConvertIt(rowDetail.Item("Content")), rowDetail.Item("FieldCode"))
                    End If

                    FLen = Len(fVal) + 1
                    Dir = Dir & rowDetail.Item("FieldCode") & Strings.StrDup(4 - Len(CStr(FLen)), "0") & FLen & Strings.StrDup(5 - Len(CStr(Len(RecVal))), "0") & Len(RecVal)
                    BaseAdd = BaseAdd + 12
                    RecVal = RecVal & fVal & ft
                Next
                If Not IsDBNull(rowMain.Item("NewRecord")) Then 'Use Main
                    fVal = objBCSP.ConvertIt(rowMain.Item("NewRecord"))
                    FLen = Len(fVal) + 1
                    Dir = Dir & "900" & Strings.StrDup(4 - Len(CStr(FLen)), "0") & FLen & Strings.StrDup(5 - Len(CStr(Len(RecVal))), "0") & Len(RecVal)
                    BaseAdd = BaseAdd + 12
                    RecVal = RecVal & rowMain.Item("NewRecord") & ft 'Use Main
                End If
                If Not IsDBNull(rowMain.Item("CoverPicture")) And Not rowMain.Item("CoverPicture") = "" Then 'Use Main
                    fVal = objBCSP.ConvertIt(rowMain.Item("CoverPicture"))
                    FLen = Len(fVal) + 1
                    Dir = Dir & "907" & Strings.StrDup(4 - Len(CStr(FLen)), "0") & FLen & Strings.StrDup(5 - Len(CStr(Len(RecVal))), "0") & Len(RecVal)
                    BaseAdd = BaseAdd + 12
                    RecVal = RecVal & rowMain.Item("CoverPicture") & ft 'Use Main
                End If
                If Not IsDBNull(rowMain.Item("Reviewer")) And Not rowMain.Item("Reviewer") = "" Then 'Use Main
                    fVal = objBCSP.ConvertIt(rowMain.Item("Reviewer"))
                    FLen = Len(fVal) + 1
                    Dir = Dir & "911" & Strings.StrDup(4 - Len(CStr(FLen)), "0") & FLen & Strings.StrDup(5 - Len(CStr(Len(RecVal))), "0") & Len(RecVal)
                    BaseAdd = BaseAdd + 12
                    RecVal = RecVal & fVal & ft 'Use Main
                End If
                If Not IsDBNull(rowMain.Item("Cataloguer")) And Not rowMain.Item("Cataloguer") = "" Then 'Use Main
                    fVal = objBCSP.ConvertIt(rowMain.Item("Cataloguer"))
                    FLen = Len(fVal) + 1
                    Dir = Dir & "912" & Strings.StrDup(4 - Len(CStr(FLen)), "0") & FLen & Strings.StrDup(5 - Len(CStr(Len(RecVal))), "0") & Len(RecVal)
                    BaseAdd = BaseAdd + 12
                    RecVal = RecVal & rowMain.Item("Cataloguer") & ft 'Use Main
                End If
                If Not IsDBNull(rowMain.Item("Code")) And Not rowMain.Item("Code") = "" Then 'Use Main
                    fVal = objBCSP.ConvertIt(rowMain.Item("Code"))
                    FLen = Len(fVal) + 1
                    Dir = Dir & "925" & Strings.StrDup(4 - Len(CStr(FLen)), "0") & FLen & Strings.StrDup(5 - Len(CStr(Len(RecVal))), "0") & Len(RecVal)
                    BaseAdd = BaseAdd + 12
                    RecVal = RecVal & fVal & ft 'Use Main
                End If
                If Not IsDBNull(rowMain.Item("AccessLevel")) Then 'Use Main
                    fVal = objBCSP.ConvertIt(rowMain.Item("AccessLevel"))
                    FLen = Len(fVal) + 1
                    Dir = Dir & "926" & Strings.StrDup(4 - Len(CStr(FLen)), "0") & FLen & Strings.StrDup(5 - Len(CStr(Len(RecVal))), "0") & Len(RecVal)
                    BaseAdd = BaseAdd + 12
                    RecVal = RecVal & fVal & ft 'Use Main
                End If
                If Not IsDBNull(rowMain.Item("TypeCode")) And Not rowMain.Item("TypeCode") = "" Then
                    fVal = objBCSP.ConvertIt(rowMain.Item("TypeCode"))
                    FLen = Len(fVal) + 1
                    Dir = Dir & "927" & Strings.StrDup(4 - Len(CStr(FLen)), "0") & FLen & Strings.StrDup(5 - Len(CStr(Len(RecVal))), "0") & Len(RecVal)
                    BaseAdd = BaseAdd + 12
                    RecVal = RecVal & fVal & ft
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
                Recwbr = "<PRE>" & Chr(13) & Recwbr & Chr(13) & "</PRE>"
            End If
            CreateISORec = Recwbr
        End Function

        Public Function CreateISOAuthorityRec() As String
            Dim ft As Char = Chr(30) '#
            Dim rt As Char = Chr(29) '#
            Dim si As Char = Chr(31) '$
            Dim TotalLen, BaseAdd, Flen As Long
            Dim Dir, RecVal, FVal, Indicators As String
            Dim Leader, Record, Recwbr As String
            Dim rowMain, rowDetail As DataRow
            Dim tblMainInfor As New DataTable, tblDetailInfor As New DataTable
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
                        Select Case Len(rowDetail.Item("Indicators"))
                            Case 0
                                Indicators = "  "
                            Case 1
                                Indicators = rowDetail.Item("Indicators") & " "
                            Case 2
                                Indicators = rowDetail.Item("Indicators")
                        End Select
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
                Next 'Loop

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
        End Function

        Public Function CreateISBDRec() As String

            Dim i As Long, j As Long, ISBDStr As String
            Dim rowMain, rowDetail As DataRow
            Dim rowView As DataRowView
            Dim tblMainInfor, tblDetailInfor As DataTable
            tblMainInfor = GetItemMainInfor()
            tblDetailInfor = GetItemDetailInfor()

            If tblMainInfor.Rows.Count > 0 Then

                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '100'"
                If tblDetailInfor.DefaultView.Count > 0 And Not IsDBNull(CType(tblDetailInfor.DefaultView.Item(0), DataRowView).Item("Content")) Then
                    ISBDStr = ISBDStr & "<B>" & objBCSP.TrimSubFieldCodes(CType(tblDetailInfor.DefaultView.Item(0), DataRowView).Item("Content")) & "</B>"
                Else
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '110'"
                    If tblDetailInfor.DefaultView.Count > 0 And Not IsDBNull(CType(tblDetailInfor.DefaultView.Item(0), DataRowView).Item("Content")) Then
                        ISBDStr = ISBDStr & "<B>" & objBCSP.TrimSubFieldCodes(CType(tblDetailInfor.DefaultView.Item(0), DataRowView).Item("Content")) & "</B>"
                    Else
                        tblDetailInfor.DefaultView.RowFilter = "FieldCode = '111'"
                        If tblDetailInfor.DefaultView.Count > 0 And Not IsDBNull(CType(tblDetailInfor.DefaultView.Item(0), DataRowView).Item("Content")) Then ISBDStr = ISBDStr & "<B>" & objBCSP.TrimSubFieldCodes(CType(tblDetailInfor.DefaultView.Item(0), DataRowView).Item("Content")) & "</B>"
                    End If
                End If

                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '245'"
                For Each rowView In tblDetailInfor.DefaultView
                    If Not IsDBNull(rowView.Item("Content")) Then ISBDStr = ISBDStr & ". - " & objBCSP.TrimSubFieldCodes(rowView.Item("Content"))
                Next

                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '250'"
                For Each rowView In tblDetailInfor.DefaultView
                    If Not IsDBNull(rowView.Item("Content")) Then ISBDStr = ISBDStr & ". - " & objBCSP.TrimSubFieldCodes(rowView.Item("Content"))
                Next

                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '260'"
                For Each rowView In tblDetailInfor.DefaultView
                    If Not IsDBNull(rowView.Item("Content")) Then ISBDStr = ISBDStr & ". - " & objBCSP.TrimSubFieldCodes(rowView.Item("Content"))
                Next

                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '300'"
                For Each rowView In tblDetailInfor.DefaultView
                    If Not IsDBNull(rowView.Item("Content")) Then ISBDStr = ISBDStr & ". - " & objBCSP.TrimSubFieldCodes(rowView.Item("Content"))
                Next

                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '400'"
                For Each rowView In tblDetailInfor.DefaultView
                    If Not IsDBNull(rowView.Item("Content")) Then ISBDStr = ISBDStr & ". - " & objBCSP.TrimSubFieldCodes(rowView.Item("Content"))
                Next

                tblDetailInfor.DefaultView.RowFilter = "FieldCode LIKE '5%'"
                If tblDetailInfor.DefaultView.Count > 0 Then ISBDStr = ISBDStr & "<BR>"
                For Each rowView In tblDetailInfor.DefaultView
                    If Not IsDBNull(rowView.Item("Content")) Then
                        ISBDStr = ISBDStr & "-" & objBCSP.TrimSubFieldCodes(rowView.Item("Content"))
                    End If
                Next

                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '020'"
                If tblDetailInfor.DefaultView.Count > 0 And Not IsDBNull(CType(tblDetailInfor.DefaultView.Item(0), DataRowView).Item("Content")) And Trim(CType(tblDetailInfor.DefaultView.Item(0), DataRowView).Item("Content")) <> "" Then
                    ISBDStr = ISBDStr & ". - " & objBCSP.TrimSubFieldCodes(CType(tblDetailInfor.DefaultView.Item(0), DataRowView).Item("Content"))
                End If

                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '022'"
                For Each rowView In tblDetailInfor.DefaultView
                    If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                        ISBDStr = ISBDStr & ". - " & objBCSP.TrimSubFieldCodes(rowView.Item("Content"))
                    End If
                Next
            End If
            CreateISBDRec = ISBDStr
        End Function
        Public Function CreateCatalogCard() As String
            Dim i, k, c As Long, ISBDStr As String, FoundKey, HasSum
            Dim rowMain, rowDetail As DataRow, rowView As DataRowView
            Dim tblMainInfor, tblDetailInfor As DataTable
            tblMainInfor = GetItemMainInfor()
            tblDetailInfor = GetItemDetailInfor()

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
                    Next 'Loop
                End If

                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '440' OR FieldCode = '490'"
                For Each rowView In tblDetailInfor.DefaultView
                    If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                        ISBDStr = ISBDStr & Chr(13) & Chr(13) & Chr(13) & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "</B>" & "-"
                    End If
                Next 'Loop

                If Not IsDBNull(ISBDStr) And Right(ISBDStr, 1) = "-" Then
                    ISBDStr = Left(ISBDStr, Len(ISBDStr) - 1)
                End If

                tblDetailInfor.DefaultView.RowFilter = "FieldCode LIKE '5%' AND FieldCode <> '520' AND FieldCode <> '505'"
                For Each rowView In tblDetailInfor.DefaultView
                    If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                        ISBDStr = ISBDStr & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "</B><BR>"
                    End If
                Next 'Loop

                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '520'"
                HasSum = 0
                For Each rowView In tblDetailInfor.DefaultView
                    HasSum = 1
                    If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                        ISBDStr = ISBDStr & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "</B><BR>"
                    End If
                Next 'Loop

                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '505'"

                For Each rowView In tblDetailInfor.DefaultView
                    HasSum = 1
                    If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                        ISBDStr = ISBDStr & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "</B><BR>"
                    End If
                Next 'Loop

                If HasSum = 1 Then
                    ISBDStr = ISBDStr & "<BR>"
                End If

                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '020'"
                For Each rowView In tblDetailInfor.DefaultView
                    HasSum = 1
                    If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                        ISBDStr = ISBDStr & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "</B><BR>"
                    End If
                Next 'Loop

                ISBDStr = ISBDStr & "<BR>"

                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '022'"
                For Each rowView In tblDetailInfor.DefaultView
                    HasSum = 1
                    If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                        ISBDStr = ISBDStr & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "</B><BR>"
                    End If
                Next 'Loop

                tblDetailInfor.DefaultView.RowFilter = "FieldCode LIKE '6%'"
                i = 1

                For Each rowView In tblDetailInfor.DefaultView 'If Not rs1.EOF Then
                    FoundKey = 1
                    If Not IsDBNull(rowView.Item("Content")) And rowView.Item("Content") <> "" Then
                        ISBDStr = ISBDStr & i & ". " & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ". "
                        i = i + 1
                    End If

                Next 'End If
                Dim RomanNum() As String = {"I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII", "XIII", "XIV", "XV", "XVI", "XVII", "XVIII", "XIX", "XX"}

                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '700'"
                k = 0
                For Each rowView In tblDetailInfor.DefaultView 'If Not rs1.EOF Then
                    If Not FoundKey = 1 Then
                        If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                            ISBDStr = ISBDStr & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & "<BR>"
                        End If
                        FoundKey = 1
                    End If
                    ISBDStr = ISBDStr & RomanNum(k) & ". " & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ". " & "<br>"
                    k = k + 1
                Next 'End If

                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '710'"
                For Each rowView In tblDetailInfor.DefaultView 'If Not rs1.EOF Then
                    If Not FoundKey = 1 Then
                        If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                            ISBDStr = ISBDStr & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & Chr(13) & "<BR>"
                            FoundKey = 1
                        End If
                    End If
                    ISBDStr = ISBDStr & RomanNum(k) & ". " & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ". " & "<br>"
                    k = k + 1
                Next 'End If

                tblDetailInfor.DefaultView.RowFilter = "FieldCode LIKE '2%' AND FieldCode < '250' AND FieldCode <> '245'"
                For Each rowView In tblDetailInfor.DefaultView 'If Not rs1.EOF Then
                    If Not FoundKey = 1 Then
                        If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                            ISBDStr = ISBDStr & "Chr(13);Chr(13);Chr(13);Chr(13);Chr(13);Chr(13);Chr(13);Chr(13);"
                            FoundKey = 1
                        End If
                    End If
                    ISBDStr = ISBDStr & RomanNum(k) & ". " & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ". " & "<br>"
                    k = k + 1
                Next 'End If

                If FoundKey = 1 Then
                    ISBDStr = ISBDStr & "<P>"
                End If
                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '082'"
                Dim SubVal()
                For Each rowView In tblDetailInfor.DefaultView 'If Not rs1.EOF Then
                    If Not IsDBNull(rowView.Item("Content")) Then
                        ISBDStr = ISBDStr & "Dewey Class no. : "
                        c = 0
                        ISBDStr = ISBDStr & RomanNum(k) & ". " & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ". " & "<br>"
                        k = k + 1

                        Call objBCSP.ParseField("$a,$2", CType(tblDetailInfor.DefaultView.Item(0), DataRowView).Item("Content"), "", SubVal)
                        If c = 0 Then
                            ISBDStr = ISBDStr & Replace(objBCSP.ConvertIt(SubVal(0)), "''", "'")
                            c = 1
                        Else
                            ISBDStr = ISBDStr & ", " & Replace(objBCSP.ConvertIt(SubVal(0)), "''", "'")
                        End If
                        If Not SubVal(1) = "" Then
                            ISBDStr = ISBDStr & " -- dc " & SubVal(1) & "<BR>"
                        End If
                    End If
                Next 'Loop

                tblDetailInfor.DefaultView.RowFilter = "FieldCode LIKE '090'"
                For Each rowView In tblDetailInfor.DefaultView
                    If Not IsDBNull(rowView.Item("Content")) Then
                        ISBDStr = ISBDStr & "Call no. : <B>" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "</B><BR>"
                    End If
                Next 'Loop
            End If 'Next i
            CreateCatalogCard = ISBDStr
        End Function

        Public Function CreateXMLTAG() As String
            Dim XMLStr As String = "", Ind As String, Ind1 As String, Ind2 As String, IndLen As Long
            Dim TagVal As String, subtag() As String, i, j As Long, FVal As String
            Dim rowMain, rowDetail As DataRow, rowView As DataRowView

            Dim tblMainInfor, tblDetailInfor As DataTable
            tblMainInfor = objDItemCollection.GetItemMainInfor
            tblDetailInfor = objDItemCollection.GetItemDetailInfor

            If tblMainInfor.Rows.Count > 0 Then 'If Not rs1.EOF Then
                If Me.InterfaceLanguage = "tcvn" Or Me.InterfaceLanguage = "vni" Then
                    XMLStr = "<?xml version=""1.0"" encoding='iso8859-1'?>"
                Else
                    XMLStr = "<?xml version=""1.0"" encoding=""UTF-8""?>"
                End If

                XMLStr = XMLStr & "<collection xmlns=""http://www.loc.gov/MARC21/slim"">"
                XMLStr = XMLStr & "<record>"
                XMLStr = XMLStr & "<leader>" & tblMainInfor.Rows.Item(0)("Leader") & "</leader>"

                If Not IsDBNull(tblMainInfor.Rows.Item(0)("Code")) Then
                    XMLStr = XMLStr & "<controlfield tag='001'>" & tblMainInfor.Rows.Item(0)("Code") & "</controlfield>"
                End If

                tblDetailInfor.DefaultView.RowFilter = "FieldCode ='003'"
                If tblDetailInfor.DefaultView.Count > 0 Then
                    For Each rowView In tblMainInfor.DefaultView 'If Not rs1.EOF Then
                        If Not IsDBNull(CType(tblDetailInfor.DefaultView.Item(0), DataRowView).Item("Content")) Then
                            XMLStr = XMLStr & "<controlfield tag='003'>" & CType(tblDetailInfor.DefaultView.Item(0), DataRowView).Item("Content") & "</controlfield>"
                        End If
                    Next
                End If

                For Each rowDetail In tblDetailInfor.Rows
                    If Left(tblDetailInfor.Rows.Item(0)("FieldCode"), 2) = "00" Then
                        If Not tblDetailInfor.Rows.Item(0)("FieldCode") = "005" Then
                            If Not IsDBNull(tblDetailInfor.Rows.Item(0)("FieldCode")) And Not IsDBNull(tblDetailInfor.Rows.Item(0)("Content")) Then
                                XMLStr = XMLStr & "<controlfield tag=" & tblDetailInfor.Rows.Item(0)("FieldCode") & tblDetailInfor.Rows.Item(0)("Content") & "</controlfield>"
                            End If
                        End If
                    Else
                        IndLen = Len(tblDetailInfor.Rows.Item(0)("Indicators"))
                        If IndLen = 0 Then
                            Ind = "  "
                        ElseIf IndLen = 1 Then
                            Ind = tblDetailInfor.Rows.Item(0)("Indicators") & " "
                        Else
                            Ind = tblDetailInfor.Rows.Item(0)("Indicators")
                        End If
                        Ind1 = Left(Ind, 1)
                        Ind2 = Right(Ind, 1)
                        TagVal = rowDetail("Content")

                        subtag = Split(TagVal, "$")
                        If Trim(Ind2) <> "" Then
                            If Trim(Ind1) <> "" Then
                                XMLStr = XMLStr & "<datafield tag='" & tblDetailInfor.Rows.Item(0)("FieldCode") & "' ind1='" & Ind1 & "' ind2='" & Ind2 & "'>"
                            Else
                                XMLStr = XMLStr & "<datafield tag='" & tblDetailInfor.Rows.Item(0)("FieldCode") & "' ind1=''" & " ind2='" & Ind2 & "'>"
                            End If
                        Else
                            XMLStr = XMLStr & "<datafield tag='" & tblDetailInfor.Rows.Item(0)("FieldCode") & " ' ind1= '" & Ind1 & "' ind2= '' >"
                        End If

                        For j = LBound(subtag) To UBound(subtag)
                            If Not subtag(j) = "" Then
                                XMLStr = XMLStr & "<subfield code='" & Right(subtag(j), Len(subtag(j)) - 1) & "'></subfield>"
                            End If
                        Next
                        XMLStr = XMLStr & "</datafield>"
                    End If
                Next
                XMLStr = XMLStr & "</record>"
                XMLStr = XMLStr & "</collection>"
            End If
            CreateXMLTAG = XMLStr
        End Function
        Function CreateXMLDCMI() As String
            Dim tblMainInfor As DataTable
            tblMainInfor = GetItemMainInfor()
            Dim tblDetailInfor As DataTable
            tblDetailInfor = GetItemDetailInfor()
            Dim SQL, XMLStream, txt As String
            Dim i As Long
            Dim rowDetail, rowMain As DataRow, rowView As DataRowView
            Dim rowMainView As DataRowView
            Dim DocIDStr As String, SubRecords() As String
            Dim objArr() As Object
            Call objBCSP.GLoadArray(ItemIDs, objArr, ",")

            If Not IsDBNull(objArr) Then
                For i = LBound(objArr) To UBound(objArr)
                    DocIDStr = DocIDStr & objArr(i) & ", "
                Next
            End If

            DocIDStr = Left(DocIDStr, Len(DocIDStr) - 2)
            If Me.InterfaceLanguage = "tcvn" Or Me.InterfaceLanguage = "vni" Then
                XMLStream = "<?xml version=""1.0"" encoding=""iso8859-1""?>" '& Chr(13)
            Else
                XMLStream = "<?xml version=""1.0"" encoding=""UTF-8""?>" '& Chr(13)
            End If

            'XMLStream = XMLStream & "<!DOCTYPE rdf:RDF SYSTEM  ""DTDFiles/LibolDC.dtd"">" '& Chr(13)
            XMLStream = XMLStream & "<rdf:RDF xmlns:dc=""xmlfiles/dcns.xml"" xmlns:rdf=""xmlfiles/rdfns.xml"">" '& Chr(13)
            For i = LBound(objArr) To UBound(objArr)
                XMLStream = XMLStream & "<rdf:Description>"
                'ItemID : before Tai_lieu_ID
                tblDetailInfor.DefaultView.RowFilter = "ItemID = " & objArr(i)
                tblMainInfor.DefaultView.RowFilter = "ItemID = " & objArr(i)

                For Each rowView In tblDetailInfor.DefaultView 'Do While Not RS.EOF
                    If Not IsDBNull(rowView.Item("FieldCode")) And CInt(rowView.Item("FieldCode")) = 245 Then
                        XMLStream = XMLStream & "<dc:title>"
                        XMLStream = XMLStream & Trim(objBCSP.TheDisplayOne(objBCSP.TrimSubFieldCodes(objBCSP.ConvertIt(rowView.Item("Content")))))
                        XMLStream = XMLStream & "</dc:title>"
                    End If
                Next 'Next 'Loop
                For Each rowView In tblDetailInfor.DefaultView  'Do While Not RS.EOF
                    If Not IsDBNull(rowView.Item("FieldCode")) And (CInt(rowView.Item("FieldCode")) = 100 Or CInt(rowView.Item("FieldCode")) = 110 Or CInt(rowView.Item("FieldCode")) = 111 Or CInt(rowView.Item("FieldCode")) = 700 Or CInt(rowView.Item("FieldCode")) = 710 Or CInt(rowView.Item("FieldCode")) = 711 Or CInt(rowView.Item("FieldCode")) = 1507) Then
                        '760$b
                        XMLStream = XMLStream & "<dc:creator>"
                        XMLStream = XMLStream & Trim(objBCSP.TrimSubFieldCodes(objBCSP.ConvertIt(rowView.Item("Content"))))
                        XMLStream = XMLStream & "</dc:creator>"
                    End If
                Next 'Next 'Loop
                For Each rowView In tblDetailInfor.DefaultView  'Do While Not RS.EOF
                    If Not IsDBNull(rowView.Item("FieldCode")) And (CInt(rowView.Item("FieldCode")) = 600 Or CInt(rowView.Item("FieldCode")) = 610 Or CInt(rowView.Item("FieldCode")) = 611 Or CInt(rowView.Item("FieldCode")) = 630 Or CInt(rowView.Item("FieldCode")) = 650 Or CInt(rowView.Item("FieldCode")) = 653) Then
                        XMLStream = XMLStream & "<dc:subject>"
                        XMLStream = XMLStream & Trim(objBCSP.TrimSubFieldCodes(objBCSP.ConvertIt(rowView.Item("Content"))))
                        XMLStream = XMLStream & "</dc:subject>"
                    End If
                Next 'Next 'Loop
                For Each rowView In tblDetailInfor.DefaultView  'Do While Not RS.EOF
                    If Not IsDBNull(rowView.Item("FieldCode")) And (CInt(rowView.Item("FieldCode")) = 500 Or CInt(rowView.Item("FieldCode")) = 501 Or CInt(rowView.Item("FieldCode")) = 502 Or CInt(rowView.Item("FieldCode")) = 503 Or CInt(rowView.Item("FieldCode")) = 504 Or CInt(rowView.Item("FieldCode")) = 505 Or CInt(rowView.Item("FieldCode")) = 507 Or CInt(rowView.Item("FieldCode")) = 508 Or CInt(rowView.Item("FieldCode")) = 510 Or CInt(rowView.Item("FieldCode")) = 511 Or CInt(rowView.Item("FieldCode")) = 512 Or CInt(rowView.Item("FieldCode")) = 513) Then
                        txt = Trim(objBCSP.TrimSubFieldCodes(objBCSP.ConvertIt(rowView.Item("Content"))))
                        XMLStream = XMLStream & "<dc:description>"
                        XMLStream = XMLStream & txt
                        XMLStream = XMLStream & "</dc:description>"
                    End If
                Next 'Loop
                For Each rowView In tblDetailInfor.DefaultView 'Do While Not RS.EOF
                    If Not IsDBNull(rowView.Item("FieldCode")) And CInt(rowView.Item("FieldCode")) = 260 Then

                        Call objBCSP.ParseField("$a,$b,$c", rowView.Item("Content"), "nc ", SubRecords)

                        If Not SubRecords(0) = "" Or SubRecords(1) = "" Then
                            XMLStream = XMLStream & "<dc:publisher>"
                            XMLStream = XMLStream & Trim(objBCSP.ConvertIt(SubRecords(0) & SubRecords(1)))
                            XMLStream = XMLStream & "</dc:publisher>"
                        End If
                        If Not SubRecords(2) = "" Then
                            XMLStream = XMLStream & "<dc:date>"
                            XMLStream = XMLStream & Trim(objBCSP.ConvertIt(SubRecords(2)))
                            XMLStream = XMLStream & "</dc:date>"
                        End If
                    End If
                Next 'Loop

                For Each rowMainView In tblMainInfor.DefaultView 'If Not RSLeader.EOF Then
                    Select Case Mid(rowMainView.Item("Leader"), 7, 1)
                        Case "a", "c", "d", "t"
                            txt = "text"
                        Case "e", "f", "g", "k"
                            txt = "image"
                        Case "m", "o", "p", "r"
                            txt = "no type provided"
                        Case Else
                            Select Case Mid(rowMainView.Item("Leader"), 8, 1)
                                Case "c", "s", "p"
                                    txt = "collection"
                            End Select
                    End Select
                    XMLStream = XMLStream & "<dc:type>"
                    XMLStream = XMLStream & txt
                    XMLStream = XMLStream & "</dc:type>"
                Next 'End If

                For Each rowView In tblDetailInfor.DefaultView  'Do While Not RS.EOF
                    If Not IsDBNull(rowView.Item("FieldCode")) And CInt(rowView.Item("FieldCode")) = 655 Then
                        XMLStream = XMLStream & "<dc:type>"
                        XMLStream = XMLStream & Trim(objBCSP.TrimSubFieldCodes(objBCSP.ConvertIt(rowView.Item("Content"))))
                        XMLStream = XMLStream & "</dc:type>"
                    End If
                Next 'Loop
                For Each rowView In tblDetailInfor.DefaultView 'Do While Not RS.EOF
                    If Not IsDBNull(rowView.Item("FieldCode")) And CInt(rowView.Item("FieldCode")) = 856 Then

                        Call objBCSP.ParseField("$q,$u", rowView.Item("Content"), "nc ", SubRecords)

                        If Not SubRecords(0) = "" Then
                            XMLStream = XMLStream & "<dc:format>"
                            XMLStream = XMLStream & objBCSP.ConvertIt(SubRecords(0))
                            XMLStream = XMLStream & "</dc:format>"
                        End If
                        If Not SubRecords(1) = "" Then
                            XMLStream = XMLStream & "<dc:identifier>"
                            XMLStream = XMLStream & objBCSP.ConvertIt(SubRecords(1))
                            XMLStream = XMLStream & "</dc:identifier>"
                        End If
                    End If
                Next 'Loop
                For Each rowView In tblDetailInfor.DefaultView 'Do While Not RS.EOF
                    If Not IsDBNull(rowView.Item("FieldCode")) And CInt(rowView.Item("FieldCode")) = 786 Then
                        Call objBCSP.ParseField("$o,$t", rowView.Item("Content"), "nc ", SubRecords)
                        If Not SubRecords(0) = "" Or Not SubRecords(1) = "" Then
                            XMLStream = XMLStream & "<dc:source>"
                            XMLStream = XMLStream & objBCSP.ConvertIt(SubRecords(0) & SubRecords(1))
                            XMLStream = XMLStream & "</dc:source>"
                        End If
                    End If
                Next 'Loop
                For Each rowView In tblDetailInfor.DefaultView 'Do While Not RS.EOF
                    If Not IsDBNull(rowView.Item("FieldCode")) And CInt(rowView.Item("FieldCode")) = 8 Then
                        XMLStream = XMLStream & "<dc:language>"
                        XMLStream = XMLStream & Mid(rowView.Item("Content"), 36, 3)
                        XMLStream = XMLStream & "</dc:language>"
                    End If
                    If Not IsDBNull(rowView.Item("FieldCode")) And CInt(rowView.Item("FieldCode")) = 546 Then
                        XMLStream = XMLStream & "<dc:language>"
                        XMLStream = XMLStream & objBCSP.TrimSubFieldCodes(objBCSP.ConvertIt(rowView.Item("Content")))
                        XMLStream = XMLStream & "</dc:language>"
                    End If
                Next 'Loop

                For Each rowView In tblDetailInfor.DefaultView 'Do While Not RS.EOF
                    If Not IsDBNull(rowView.Item("FieldCode")) And CInt(rowView.Item("FieldCode")) = 530 Then
                        XMLStream = XMLStream & "<dc:relation>"
                        XMLStream = XMLStream & objBCSP.TrimSubFieldCodes(objBCSP.ConvertIt(rowView.Item("Content")))
                        XMLStream = XMLStream & "</dc:relation>"
                    End If
                    If Not IsDBNull(rowView.Item("FieldCode")) And (CInt(rowView.Item("FieldCode")) >= 760 And CInt(rowView.Item("FieldCode")) <= 787) Then
                        Call objBCSP.ParseField("$o,$t", rowView.Item("Content"), "nc ", SubRecords)
                        If (Not IsDBNull(SubRecords(0)) And Not SubRecords(0) = "") Or (Not IsDBNull(SubRecords(1)) And Not SubRecords(1) = "") Then
                            XMLStream = XMLStream & "<dc:relation>"
                            XMLStream = XMLStream & objBCSP.ConvertIt(SubRecords(0) & SubRecords(1))
                            XMLStream = XMLStream & "</dc:relation>"
                        End If
                    End If
                    ' RS.MoveNext()()
                Next 'Loop
                For Each rowView In tblDetailInfor.DefaultView 'Do While Not RS.EOF
                    If CInt(rowView.Item("FieldCode")) = 651 Or CInt(rowView.Item("FieldCode")) = 752 Then
                        XMLStream = XMLStream & "<dc:coverage>"
                        XMLStream = XMLStream & objBCSP.TrimSubFieldCodes(objBCSP.ConvertIt(rowView.Item("Content")))
                        XMLStream = XMLStream & "</dc:coverage>"
                    End If
                Next 'Loop
                For Each rowView In tblDetailInfor.DefaultView 'Do While Not RS.EOF
                    If CInt(rowView.Item("FieldCode")) = 540 Or CInt(rowView.Item("FieldCode")) = 506 Then
                        XMLStream = XMLStream & "<dc:rights>"
                        XMLStream = XMLStream & objBCSP.TrimSubFieldCodes(objBCSP.ConvertIt(rowView.Item("Content")))
                        XMLStream = XMLStream & "</dc:rights>"
                    End If
                Next 'Loop
                XMLStream = XMLStream & "</rdf:Description>"
            Next
            XMLStream = XMLStream & "</rdf:RDF>"
            CreateXMLDCMI = XMLStream
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Function CreateXMLDCMI_BackUp() As String
            Dim tblMainInfor As DataTable
            tblMainInfor = GetItemMainInfor()
            Dim tblDetailInfor As DataTable
            tblDetailInfor = GetItemDetailInfor()
            Dim SQL, XMLStream, txt As String
            Dim i As Long
            Dim rowDetail, rowMain As DataRow, rowView As DataRowView
            Dim DocIDStr As String, SubRecords() As String
            Dim objArr() As Object
            Call objBCSP.GLoadArray(ItemIDs, objArr, ",")

            If Not IsDBNull(objArr) Then
                For i = LBound(objArr) To UBound(objArr)
                    DocIDStr = DocIDStr & objArr(i) & ", "
                Next
            End If

            DocIDStr = Left(DocIDStr, Len(DocIDStr) - 2)
            If Me.InterfaceLanguage = "tcvn" Or Me.InterfaceLanguage = "vni" Then
                XMLStream = "<?xml version=""1.0"" encoding=""iso8859-1""?>" '& Chr(13)
            Else
                XMLStream = "<?xml version=""1.0"" encoding=""UTF-8""?>" '& Chr(13)
            End If

            'XMLStream = XMLStream & "<!DOCTYPE rdf:RDF SYSTEM  ""DTDFiles/LibolDC.dtd"">" '& Chr(13)
            XMLStream = XMLStream & "<rdf:RDF xmlns:dc=""xmlfiles/dcns.xml"" xmlns:rdf=""xmlfiles/rdfns.xml"">" '& Chr(13)
            For i = LBound(objArr) To UBound(objArr)
                XMLStream = XMLStream & "<rdf:Description>" '& Chr(13)
                'ItemID : before Tai_lieu_ID
                tblDetailInfor.DefaultView.RowFilter = "ItemID = " & objArr(i)
                tblMainInfor.DefaultView.RowFilter = "ItemID = " & objArr(i)

                For Each rowView In tblDetailInfor.DefaultView 'Do While Not RS.EOF
                    If CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 245 Then
                        XMLStream = XMLStream & "<dc:title>"
                        XMLStream = XMLStream & Trim(objBCSP.TheDisplayOne(objBCSP.TrimSubFieldCodes(objBCSP.ConvertIt(tblDetailInfor.Rows.Item(0)("Content")))))
                        XMLStream = XMLStream & "</dc:title>" '& Chr(13)
                    End If
                Next 'Next 'Loop
                For Each rowView In tblDetailInfor.DefaultView  'Do While Not RS.EOF
                    If CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 100 Or CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 329 Or CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 346 Or CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 1398 Or CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 1442 Or CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 1467 Or CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 1507 Then
                        XMLStream = XMLStream & "<dc:creator>"
                        XMLStream = XMLStream & Trim(objBCSP.TrimSubFieldCodes(objBCSP.ConvertIt(tblDetailInfor.Rows.Item(0)("Content"))))
                        XMLStream = XMLStream & "</dc:creator>" '& Chr(13)
                    End If
                Next 'Next 'Loop
                For Each rowView In tblDetailInfor.DefaultView  'Do While Not RS.EOF
                    If CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 600 Or CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 1234 Or CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 1262 Or CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 1288 Or CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 1311 Or CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 1341 Then
                        XMLStream = XMLStream & "<dc:subject>"
                        XMLStream = XMLStream & Trim(objBCSP.TrimSubFieldCodes(objBCSP.ConvertIt(tblDetailInfor.Rows.Item(0)("Content"))))
                        XMLStream = XMLStream & "</dc:subject>" '& Chr(13)
                    End If
                Next 'Next 'Loop
                For Each rowView In tblDetailInfor.DefaultView  'Do While Not RS.EOF
                    If CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 500 Or CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 814 Or CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 819 Or CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 823 Or CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 826 Or CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 831 Or CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 848 Or CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 853 Or CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 857 Or CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 865 Or CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 869 Or CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 872 Then
                        txt = Trim(objBCSP.TrimSubFieldCodes(objBCSP.ConvertIt(tblDetailInfor.Rows.Item(0)("Content"))))
                        XMLStream = XMLStream & "<dc:description>"
                        XMLStream = XMLStream & txt
                        XMLStream = XMLStream & "</dc:description>" '& Chr(13)
                    End If
                Next 'Loop
                For Each rowView In tblDetailInfor.DefaultView 'Do While Not RS.EOF
                    If CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 260 Then

                        Call objBCSP.ParseField("$a,$b,$c", tblDetailInfor.Rows.Item(0)("Content"), "nc ", SubRecords)

                        If Not SubRecords(0) = "" Or SubRecords(1) = "" Then
                            XMLStream = XMLStream & "<dc:publisher>"
                            XMLStream = XMLStream & Trim(objBCSP.ConvertIt(SubRecords(0) & SubRecords(1)))
                            XMLStream = XMLStream & "</dc:publisher>" '& Chr(13)
                        End If
                        If Not SubRecords(2) = "" Then
                            XMLStream = XMLStream & "<dc:date>"
                            XMLStream = XMLStream & Trim(objBCSP.ConvertIt(SubRecords(2)))
                            XMLStream = XMLStream & "</dc:date>" ' & Chr(13)
                        End If
                    End If
                Next 'Loop

                For Each rowMain In tblMainInfor.Rows 'If Not RSLeader.EOF Then
                    Select Case Mid(tblMainInfor.Rows.Item(0)("Leader"), 7, 1)
                        Case "a", "c", "d", "t"
                            txt = "text"
                        Case "e", "f", "g", "k"
                            txt = "image"
                        Case "m", "o", "p", "r"
                            txt = "no type provided"
                        Case Else
                            Select Case Mid(tblMainInfor.Rows.Item(0)("Leader"), 8, 1)
                                Case "c", "s", "p"
                                    txt = "collection"
                            End Select
                    End Select
                    XMLStream = XMLStream & "<dc:type>"
                    XMLStream = XMLStream & txt
                    XMLStream = XMLStream & "</dc:type>" '& Chr(13)
                Next 'End If

                For Each rowView In tblDetailInfor.DefaultView  'Do While Not RS.EOF
                    If CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 655 Then
                        XMLStream = XMLStream & "<dc:type>"
                        XMLStream = XMLStream & Trim(objBCSP.TrimSubFieldCodes(objBCSP.ConvertIt(tblDetailInfor.Rows.Item(0)("Content"))))
                        XMLStream = XMLStream & "</dc:type>" '& Chr(13)
                    End If
                Next 'Loop
                For Each rowView In tblDetailInfor.DefaultView 'Do While Not RS.EOF
                    If CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 856 Then

                        Call objBCSP.ParseField("$q,$u", tblDetailInfor.Rows.Item(0)("Content"), "nc ", SubRecords)

                        If Not SubRecords(0) = "" Then
                            XMLStream = XMLStream & "<dc:format>"
                            XMLStream = XMLStream & objBCSP.ConvertIt(SubRecords(0))
                            XMLStream = XMLStream & "</dc:format>" '& Chr(13)
                        End If
                        If Not SubRecords(1) = "" Then
                            XMLStream = XMLStream & "<dc:identifier>"
                            XMLStream = XMLStream & objBCSP.ConvertIt(SubRecords(1))
                            XMLStream = XMLStream & "</dc:identifier>" '& Chr(13)
                        End If
                    End If
                Next 'Loop
                For Each rowView In tblDetailInfor.DefaultView 'Do While Not RS.EOF
                    If CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 786 Then
                        Call objBCSP.ParseField("$o,$t", tblDetailInfor.Rows.Item(0)("Content"), "nc ", SubRecords)
                        If Not SubRecords(0) = "" Or Not SubRecords(1) = "" Then
                            XMLStream = XMLStream & "<dc:source>"
                            XMLStream = XMLStream & objBCSP.ConvertIt(SubRecords(0) & SubRecords(1))
                            XMLStream = XMLStream & "</dc:source>" '& Chr(13)
                        End If
                    End If
                Next 'Loop
                For Each rowView In tblDetailInfor.DefaultView 'Do While Not RS.EOF
                    If CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 8 Or CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 27 Or CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 28 Or CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 29 Or CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 30 Or CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 31 Or CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 2167 Then
                        XMLStream = XMLStream & "<dc:language>"
                        XMLStream = XMLStream & Mid(tblDetailInfor.Rows.Item(0)("Content"), 36, 3)
                        XMLStream = XMLStream & "</dc:language>" '& Chr(13)
                    End If
                    If CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 546 Then
                        XMLStream = XMLStream & "<dc:language>"
                        XMLStream = XMLStream & objBCSP.TrimSubFieldCodes(objBCSP.ConvertIt(tblDetailInfor.Rows.Item(0)("Content")))
                        XMLStream = XMLStream & "</dc:language>" '& Chr(13)
                    End If
                Next 'Loop
                For Each rowView In tblDetailInfor.DefaultView 'Do While Not RS.EOF
                    If CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 530 Then
                        XMLStream = XMLStream & "<dc:relation>"
                        XMLStream = XMLStream & objBCSP.TrimSubFieldCodes(objBCSP.ConvertIt(tblDetailInfor.Rows.Item(0)("Content")))
                        XMLStream = XMLStream & "</dc:relation>" '& Chr(13)
                    End If
                    If (CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) >= 760 And CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) <= 1895) Then
                        Call objBCSP.ParseField("$o,$t", tblDetailInfor.Rows.Item(0)("Content"), "nc ", SubRecords)
                        If Not SubRecords(0) = "" Or Not SubRecords(1) = "" Then
                            XMLStream = XMLStream & "<dc:relation>"
                            XMLStream = XMLStream & objBCSP.ConvertIt(SubRecords(0) & SubRecords(1))
                            XMLStream = XMLStream & "</dc:relation>" '& Chr(13)
                        End If
                    End If
                    ' RS.MoveNext()()
                Next 'Loop
                For Each rowView In tblDetailInfor.DefaultView 'Do While Not RS.EOF
                    If CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 651 Or CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 1541 Then
                        XMLStream = XMLStream & "<dc:coverage>"
                        XMLStream = XMLStream & objBCSP.TrimSubFieldCodes(objBCSP.ConvertIt(tblDetailInfor.Rows.Item(0)("Content")))
                        XMLStream = XMLStream & "</dc:coverage>" '& Chr(13)
                    End If
                Next 'Loop
                For Each rowView In tblDetailInfor.DefaultView 'Do While Not RS.EOF
                    If CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 540 Or CInt(tblDetailInfor.Rows.Item(0)("FieldCode")) = 838 Then
                        XMLStream = XMLStream & "<dc:rights>"
                        XMLStream = XMLStream & objBCSP.TrimSubFieldCodes(objBCSP.ConvertIt(tblDetailInfor.Rows.Item(0)("Content")))
                        XMLStream = XMLStream & "</dc:rights>" '& Chr(13)
                    End If
                Next 'Loop
                XMLStream = XMLStream & "</rdf:Description>" '& Chr(13)
            Next
            XMLStream = XMLStream & "</rdf:RDF>" '& Chr(13)
            CreateXMLDCMI_BackUp = XMLStream
        End Function
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
            Finally
                Me.Dispose()
                MyBase.Dispose()
            End Try
        End Sub
        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class
End Namespace