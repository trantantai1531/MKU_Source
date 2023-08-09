Imports System
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.DataAccess.OPAC
Imports System.Linq
Imports System.Collections.Generic

Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBOPACItem
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private intItemID As Integer
        Private strIssueNo As String
        Private intIssueID As Integer
        Private blnHaveCopy As Boolean
        Private blnAvail As Boolean
        Private blnLocked As Boolean
        Private lngTotalItems As Long
        Private lngAvailItems As Long
        Private lngHoldItems As Long
        Private strURLCoverPicture As String
        Private objDOPACItem As New clsDOPACItem
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objBItemDissertation As New clsBItemDissertation
        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
        ' URLCoverPicture property
        Public ReadOnly Property URLCoverPicture() As String
            Get
                Return strURLCoverPicture
            End Get
        End Property

        ' TotalItems property
        Public ReadOnly Property TotalItems() As Long
            Get
                Return lngTotalItems
            End Get
        End Property

        ' AvailItems property
        Public ReadOnly Property AvailItems() As Long
            Get
                Return lngAvailItems
            End Get
        End Property

        ' HoldItems property
        Public ReadOnly Property HoldItems() As Long
            Get
                Return lngHoldItems
            End Get
        End Property

        ' HaveCopy property
        Public ReadOnly Property HaveCopy() As Boolean
            Get
                Return blnHaveCopy
            End Get
        End Property

        ' Avail property
        Public ReadOnly Property Avail() As Boolean
            Get
                Return blnAvail
            End Get
        End Property

        ' Locked property
        Public ReadOnly Property Locked() As Boolean
            Get
                Return blnLocked
            End Get
        End Property

        ' ItemID property
        Public Property ItemID() As Integer
            Get
                Return intItemID
            End Get
            Set(ByVal Value As Integer)
                intItemID = Value
            End Set
        End Property
        'IssueNo property
        Public Property IssueNo() As String
            Get
                Return strIssueNo
            End Get
            Set(ByVal Value As String)
                strIssueNo = Value
            End Set
        End Property
        'IssueID property
        Public Property IssueID() As Integer
            Get
                Return intIssueID
            End Get
            Set(ByVal Value As Integer)
                intIssueID = Value
            End Set
        End Property
        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************
        ' Initialize method
        Public Sub Initialize()
            ' Init objDOPACItem object
            objDOPACItem.DBServer = strDBServer
            objDOPACItem.ConnectionString = strConnectionString
            objDOPACItem.Initialize()

            ' Init objBCSP object
            objBCSP.DBServer = strDBServer
            objBCSP.ConnectionString = strConnectionString
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            objBCSP.Initialize()

            ' Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()

            ' Init objBCDBS object
            objBItemDissertation.DBServer = strDBServer
            objBItemDissertation.ConnectionString = strConnectionString
            objBItemDissertation.InterfaceLanguage = strInterfaceLanguage
            objBItemDissertation.Initialize()
        End Sub

        ' Purpose: Read Comment of information of Patron
        ' Input: ItemID
        ' Output: DataTable
        ' Created by: dgsoft
        Public Function GetCommentsByPatron() As DataTable
            objDOPACItem.ItemID = intItemID
            GetCommentsByPatron = objBCDBS.ConvertTable(objDOPACItem.GetCommentsByPatron)
        End Function

        ' Purpose: Read Comment of information of Patron
        ' Input: ItemID
        ' Output: DataTable
        ' Created by: dgsoft
        Public Function getCommentsOfPatronByItem(Optional ByVal intPageNum As Integer = 1, Optional ByVal intPageSize As Integer = 10) As DataTable
            objDOPACItem.ItemID = intItemID
            getCommentsOfPatronByItem = objDOPACItem.getCommentsOfPatronByItem(intPageNum, intPageSize)
        End Function

        ' Purpose: GetInterestTitle
        ' Input: 
        ' Output: 
        ' Created by:
        Public Function GetInterestTitle() As DataTable

        End Function

        Public Function GetBestItems(ByVal intSecuredOPAC As Integer, ByVal intAccLevel As Integer, ByVal intNumberDay As Integer, ByVal intTop As Integer, Optional ByVal intLibID As Integer = 0) As DataTable
            Dim tblOPACItem As DataTable
            Dim tblItem As DataTable
            Dim strTmp As String
            Dim inti As Integer
            Try
                tblOPACItem = objDOPACItem.GetBestItems(intSecuredOPAC, intAccLevel, intNumberDay, intTop, intLibID)
                If Not tblOPACItem Is Nothing Then
                    tblOPACItem.Columns.Add("Content", System.Type.GetType("System.String"))
                    tblOPACItem.Columns.Add("STT", System.Type.GetType("System.Int32"))
                    For inti = 0 To tblOPACItem.Rows.Count - 1
                        objDOPACItem.ItemID = tblOPACItem.Rows(inti).Item("ItemID")
                        tblItem = objDOPACItem.GetItemDetailInfor
                        If Not tblItem Is Nothing Then
                            tblItem.DefaultView.RowFilter = "FieldCode='245'"
                            If tblItem.DefaultView.Count > 0 Then
                                strTmp = tblItem.DefaultView(0).Item("Content")
                            Else
                                strTmp = ""
                            End If
                        Else
                            strTmp = ""
                        End If
                        If strTmp <> "" Then
                            If Len(strTmp) > 70 Then
                                strTmp = Left(strTmp, 70) & "..."
                            End If
                            'strTmp = "<A Href=""WShowDetail.aspx?intItemID=" & tblOPACItem.Rows(inti).Item("ItemID") & """>" & strTmp & "</A> (<B><Font color=""CC0000"">" & tblOPACItem.Rows(inti).Item("NOR") & "</Font></B>)"
                            strTmp = "<a onclick='showPopupDetail(" & tblOPACItem.Rows(inti).Item("ItemID") & ")' style='cursor:pointer;'>" & strTmp.Trim & "</a> (<b>" & tblOPACItem.Rows(inti).Item("NOR") & "</b>)"
                        End If
                        tblOPACItem.Rows(inti).Item("STT") = inti + 1
                        tblOPACItem.Rows(inti).Item("Content") = strTmp
                    Next
                    GetBestItems = objBCDBS.ConvertTable(tblOPACItem, "Content")
                Else
                    GetBestItems = Nothing
                End If
                intErrorCode = objDOPACItem.ErrorCode
                strErrorMsg = objDOPACItem.ErrorMsg
            Catch ex As Exception

            End Try
        End Function

        ' Purpose: GetStatusHoldRequest
        ' Input: 
        ' Output: 
        ' Created by:
        Public Function GetStatusHoldRequest() As DataTable
            Try

            Catch ex As Exception

            End Try
        End Function

        Public Function GetGeneralInfor(Optional ByVal intLibID As Integer = 0) As DataTable
            Dim tblOPACItem As DataTable
            Dim inti As Integer
            Try
                tblOPACItem = objDOPACItem.GetGeneralInfor(intLibID)
                If Not tblOPACItem Is Nothing Then
                    For inti = 0 To tblOPACItem.Rows.Count - 1
                        tblOPACItem.Rows(inti).Item("STT") = inti + 1
                    Next
                    GetGeneralInfor = tblOPACItem
                Else
                    GetGeneralInfor = Nothing
                End If
                intErrorCode = objDOPACItem.ErrorCode
                strErrorMsg = objDOPACItem.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetNewItem(ByVal intSecuredOPAC As Integer, ByVal intAccLevel As Integer, ByVal intNumberDay As Integer, ByVal intTop As Integer, Optional ByVal intLibID As Integer = 0) As DataTable
            Dim tblOPACItem As DataTable
            Dim tblItem As DataTable
            Dim strTmp As String
            Dim inti As Integer
            Try
                tblOPACItem = objDOPACItem.GetNewItem(intSecuredOPAC, intAccLevel, intNumberDay, intTop, intLibID)
                If Not tblOPACItem Is Nothing Then
                    tblOPACItem.Columns.Add("STT", System.Type.GetType("System.Int32"))
                    For inti = 0 To tblOPACItem.Rows.Count - 1
                        objDOPACItem.ItemID = tblOPACItem.Rows(inti).Item("ItemID")
                        tblItem = objDOPACItem.GetItemDetailInfor
                        If Not tblItem Is Nothing Then
                            tblItem.DefaultView.RowFilter = "FieldCode='245'"
                            If tblItem.DefaultView.Count > 0 Then
                                strTmp = tblItem.DefaultView(0).Item("Content")
                            Else
                                strTmp = ""
                            End If
                        Else
                            strTmp = ""
                        End If
                        If strTmp <> "" Then
                            If Len(strTmp) > 70 Then
                                strTmp = Left(strTmp, 70) & "..."
                            End If
                            'strTmp = "<A Href=""WShowDetail.aspx?intItemID=" & tblOPACItem.Rows(inti).Item("ItemID") & """>" & strTmp & "</A>"
                            strTmp = "<a onclick='showPopupDetail(" & tblOPACItem.Rows(inti).Item("ItemID") & ")' style='cursor:pointer;'>" & strTmp.Trim & "</a>"
                        End If
                        tblOPACItem.Rows(inti).Item("STT") = inti + 1
                        tblOPACItem.Rows(inti).Item("Content") = strTmp
                    Next
                    GetNewItem = objBCDBS.ConvertTable(tblOPACItem, "Content")
                Else
                    GetNewItem = Nothing
                End If
                intErrorCode = objDOPACItem.ErrorCode
                strErrorMsg = objDOPACItem.ErrorMsg
            Catch ex As Exception

            End Try
        End Function

        ' Purpose: GetRecordByType
        ' Input: 
        ' Output: 
        ' Created by:
        Public Function GetRecordByType(ByVal strType As String, Optional ByVal ArrTitle() As String = Nothing) As String
            Dim tblMarc As New DataTable
            Dim intCount As Integer
            Dim strRet As String
            Select Case UCase(strType)
                Case "MARC"
                    objDOPACItem.ItemID = intItemID
                    tblMarc = objBCDBS.ConvertTable(objDOPACItem.GetMARC)
                    For intCount = 0 To tblMarc.Rows.Count - 1
                        strRet = strRet & tblMarc.Rows(intCount).Item(1) & "&nbsp;&nbsp;&nbsp;" & Chr(9)
                        strRet = strRet & tblMarc.Rows(intCount).Item(2)
                        If tblMarc.Rows(intCount).Item(2) & "" = "" Then
                            strRet = strRet & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" & Chr(9)
                        Else
                            strRet = strRet & "&nbsp;&nbsp;&nbsp;" & Chr(9)
                        End If
                        strRet = strRet & tblMarc.Rows(intCount).Item(3) & "<BR>"
                    Next
                Case "FULLRECORD"
                    strRet = CreateFullCard(ArrTitle)

                Case "ISBD"
                    strRet = CreateISDBcard(ArrTitle)

                Case Else
                    strRet = CreateBriefCard(ArrTitle)

            End Select
            GetRecordByType = Replace(strRet, "<BR><BR>", "<BR>")
        End Function

        ' Purpose: GetRecordByType
        ' Input: 
        ' Output: 
        ' Created by:PhuongTT
        Public Function GetRecordByTypeOPAC(ByVal strType As String, Optional ByVal ArrTitle() As String = Nothing, Optional ByVal strWord As String = "", Optional ByVal strCoverPATH As String = "") As String
            Dim strResult As String = ""
            Try
                Dim tblHolding As New DataTable
                tblHolding = Me.GetHolding
                lngTotalItems = tblHolding.Rows.Count
                tblHolding.DefaultView.RowFilter = "InUsed = 0 AND Acquired = 1 AND InCirculation = 1"
                lngAvailItems = tblHolding.DefaultView.Count

                Dim tblMarc As New DataTable
                Dim intCount As Integer
                Dim strRet As String = ""
                Select Case UCase(strType)
                    Case "MARC"
                        objDOPACItem.ItemID = intItemID
                        tblMarc = objBCDBS.ConvertTable(objDOPACItem.GetMARC)
                        strRet &= "<div class='panel-header'>"
                        strRet &= "<span class='icon-info-2'>&nbsp;</span>" & ArrTitle(0)
                        strRet &= ArrTitle(1)
                        strRet &= "</div>"
                        strRet &= "<div class='panel-content'>"
                        strRet &= "<div class='grid no-margin'>"
                        strRet &= "<div class='row'>"
                        strRet &= "<div class='span10'>"
                        strRet &= "<span class='line-height'>"
                        For intCount = 0 To tblMarc.Rows.Count - 1
                            strRet = strRet & tblMarc.Rows(intCount).Item(1) & "&nbsp;&nbsp;&nbsp;" & Chr(9)
                            strRet = strRet & tblMarc.Rows(intCount).Item(2)
                            If tblMarc.Rows(intCount).Item(2) & "" = "" Then
                                strRet = strRet & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" & Chr(9)
                            Else
                                strRet = strRet & "&nbsp;&nbsp;&nbsp;" & Chr(9)
                            End If
                            strRet = strRet & tblMarc.Rows(intCount).Item(3) & "<BR />"
                        Next
                        strRet &= "</span>" 'close  Description
                        strRet &= "</div>" 'div span12
                        strRet &= "</div>" 'div row
                        strRet &= "</div>" 'div grid no-margin
                        strRet &= "</div>" 'div panel-content
                    Case "FULLRECORD"
                        strRet = CreateFullCardOPAC(ArrTitle, strWord, strCoverPATH)

                    Case "ISBD"
                        objDOPACItem.ItemID = intItemID
                        tblMarc = objBCDBS.ConvertTable(objDOPACItem.GetMARC)
                        strRet = CreateISBDcardOPAC(ArrTitle, strWord, strCoverPATH)

                    Case Else
                        strRet = CreateBriefCardOPAC(ArrTitle, strWord, strCoverPATH)

                End Select
                strResult = Replace(strRet, "<br /><br />", "<br />")
            Catch ex As Exception
            End Try
            Return strResult
        End Function


        ' Purpose: GetRecordByType
        ' Input: 
        ' Output: 
        ' Created by:PhuongTT
        Public Function GetRecordByTypeOPAC_SSC(ByVal strType As String, Optional ByVal ArrTitle() As String = Nothing, Optional ByVal strWord As String = "", Optional ByVal strCoverPATH As String = "", Optional ByVal strUser As String = "") As String
            Dim strResult As String = ""
            Try
                Dim tblHolding As New DataTable
                tblHolding = Me.GetHolding
                lngTotalItems = tblHolding.Rows.Count
                tblHolding.DefaultView.RowFilter = "InUsed = 0 AND Acquired = 1 AND InCirculation = 1"
                lngAvailItems = tblHolding.DefaultView.Count

                Dim tblMarc As New DataTable
                Dim intCount As Integer
                Dim strRet As String = ""
                Select Case UCase(strType)
                    Case "MARC"
                        objDOPACItem.ItemID = intItemID
                        tblMarc = objBCDBS.ConvertTable(objDOPACItem.GetMARC)
                        strRet &= "<h3 class='HeadStyles'>"
                        strRet &= ArrTitle(0) & ArrTitle(1)
                        strRet &= "</h3>"
                        strRet &= "<div class='ClearFix'>"
                        For intCount = 0 To tblMarc.Rows.Count - 1
                            strRet = strRet & tblMarc.Rows(intCount).Item(1) & "&nbsp;&nbsp;&nbsp;" & Chr(9)
                            strRet = strRet & tblMarc.Rows(intCount).Item(2)
                            If tblMarc.Rows(intCount).Item(2) & "" = "" Then
                                strRet = strRet & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" & Chr(9)
                            Else
                                strRet = strRet & "&nbsp;&nbsp;&nbsp;" & Chr(9)
                            End If
                            strRet = strRet & tblMarc.Rows(intCount).Item(3) & "<BR />"
                        Next
                        strRet &= "</div>"

                    Case "FULLRECORD"
                        strRet = CreateFullCardOPAC_SSC(ArrTitle, strWord, strCoverPATH, strUser)

                    Case "ISBD"
                        objDOPACItem.ItemID = intItemID
                        'tblMarc = objBCDBS.ConvertTable(objDOPACItem.GetMARC)
                        strRet = CreateISBDcardOPAC_SSC(ArrTitle, strWord, strCoverPATH)

                    Case "CATALOGER"
                        objDOPACItem.ItemID = intItemID
                        tblMarc = objBCDBS.ConvertTable(objDOPACItem.GetFileCataloger(), "Content")
                        strRet &= "<h3 class='HeadStyles'>"
                        strRet &= ArrTitle(0) & ArrTitle(1)
                        strRet &= "</h3>"
                        strRet &= "<div class='ClearFix'>"
                        For intCount = 0 To tblMarc.Rows.Count - 1
                            'strRet = strRet & tblMarc.Rows(intCount).Item(1) & "&nbsp;&nbsp;&nbsp;" & Chr(9)
                            'strRet = strRet & tblMarc.Rows(intCount).Item(2)
                            'If tblMarc.Rows(intCount).Item(2) & "" = "" Then
                            '    strRet = strRet & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" & Chr(9)
                            'Else
                            '    strRet = strRet & "&nbsp;&nbsp;&nbsp;" & Chr(9)
                            'End If
                            strRet = strRet & "<iframe src='" & strCoverPATH & "/" & Trim(tblMarc.Rows(intCount).Item(3) & "") & "'></iframe>" & "<BR />"
                            'strRet = strRet & "<a href='" & strCoverPATH & "\" & Trim(tblMarc.Rows(intCount).Item(3) & "") & "' target='_blank'>" & Trim(tblMarc.Rows(intCount).Item(3) & "") & "</a>" & "<BR />"
                        Next
                        strRet &= "</div>"

                    Case Else
                        strRet = CreateBriefCardOPAC_SSC(ArrTitle, strWord, strCoverPATH)

                End Select
                strResult = Replace(strRet, "<br /><br />", "<br />")
            Catch ex As Exception
            End Try
            Return strResult
        End Function


        ' CreateISDBcard function
        ' Purpose: View record with Catalog Card type
        ' Copy from Catalogue Module
        Private Function CreateISDBcard(ByVal ArrTitle) As String
            Dim i, k, c As Integer, ISBDStr As String, FoundKey, HasSum
            Dim rowMain, rowDetail As DataRow, rowView As DataRowView
            Dim tblMainInfor, tblDetailInfor, tblHoldingInfo As DataTable

            objDOPACItem.ItemID = intItemID
            tblMainInfor = objBCDBS.ConvertTable(objDOPACItem.GetItemMainInfor())
            'CoverPicture
            If tblMainInfor.Rows(0).Item("CoverPicture") & "" <> "" Then
                strURLCoverPicture = tblMainInfor.Rows(0).Item("CoverPicture")
            Else
                strURLCoverPicture = ""
            End If

            tblDetailInfor = objBCDBS.ConvertTable(objDOPACItem.GetItemDetailInfor())

            If tblMainInfor.Rows.Count > 0 Then

                'Main Title
                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '100'"
                For Each rowView In tblDetailInfor.DefaultView
                    If Not IsDBNull(rowView.Item("Content")) Then
                        ISBDStr = ISBDStr & "<B>" & UCase(objBCSP.TrimSubFieldCodes(rowView.Item("Content"))) & "</B>"
                    End If
                Next
                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '110'"
                For Each rowView In tblDetailInfor.DefaultView
                    If Not IsDBNull(rowView.Item("Content")) Then
                        ISBDStr = ISBDStr & "<B>" & UCase(objBCSP.TrimSubFieldCodes(rowView.Item("Content"))) & "</B>"
                    End If
                Next
                ISBDStr = ISBDStr & "<ul>"
                'Area 1: Title and statement of responsibility area
                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '245'"
                For Each rowView In tblDetailInfor.DefaultView
                    If Not IsDBNull(rowView.Item("Content")) Then
                        ISBDStr = ISBDStr & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                    End If
                Next

                'Area 2: Edition area
                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '250'"
                For Each rowView In tblDetailInfor.DefaultView
                    If Not IsDBNull(rowView.Item("Content")) Then
                        ISBDStr = ISBDStr & ". -" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                    End If
                Next

                'Area 3: Material (or type of publication) specific area

                'Area 4: Publication, distribution, etc.,area
                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '260'"
                For Each rowView In tblDetailInfor.DefaultView
                    If Not IsDBNull(rowView.Item("Content")) Then
                        ISBDStr = ISBDStr & ". -" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                    End If
                Next

                'Area 5: Physical description area
                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '300'"
                If tblDetailInfor.DefaultView.Count > 0 Then
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                            ISBDStr = ISBDStr & ". -" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                        End If
                    Next 'Loop
                End If

                'Area 6: Tung thu
                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '490'"
                If tblDetailInfor.DefaultView.Count > 0 Then
                    ISBDStr = ISBDStr & "(. -"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                            ISBDStr = ISBDStr & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                        End If
                    Next 'Loop
                    ISBDStr = Left(ISBDStr, ISBDStr.Length - 1)
                    ISBDStr = ISBDStr & ")"
                End If

                'Area 7: Note area
                ISBDStr = ISBDStr & "<BR>" ' & ArrTitle(0) & " "
                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '500'"
                If tblDetailInfor.DefaultView.Count > 0 Then

                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                            ISBDStr = ISBDStr & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "<BR>"
                        End If
                    Next 'Loop
                End If
                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '520'"
                If tblDetailInfor.DefaultView.Count > 0 Then
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                            ISBDStr = ISBDStr & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "<BR>"
                        End If
                    Next 'Loop
                End If

                'Area 8: Standard number (or alternative) and terms of availability 
                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '020'"
                If tblDetailInfor.DefaultView.Count > 0 Then
                    ISBDStr = ISBDStr & "<BR>ISBN: "
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                            ISBDStr = ISBDStr & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                        End If
                    Next 'Loop
                    ISBDStr = Left(ISBDStr, ISBDStr.Length - 1)
                End If
                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '022'"
                If tblDetailInfor.DefaultView.Count > 0 Then
                    ISBDStr = ISBDStr & "<BR>ISSN: "
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                            ISBDStr = ISBDStr & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                        End If
                    Next 'Loop
                    ISBDStr = Left(ISBDStr, ISBDStr.Length - 1)
                End If

                'Additional area: Key word
                'tblDetailInfor.DefaultView.RowFilter = "FieldCode = '653' or FieldCode = '655' or  FieldCode = '656' or FieldCode = '657'"
                'If tblDetailInfor.DefaultView.Count > 0 Then
                '    Dim inti As Integer = 0
                '    ISBDStr = ISBDStr & "<BR>"
                '    For Each rowView In tblDetailInfor.DefaultView
                '        If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                '            inti = inti + 1
                '            ISBDStr = ISBDStr & inti & "." & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ". "
                '        End If
                '    Next 'Loop
                'End If


                ISBDStr = ISBDStr & "</ul>"


            End If

            CreateISDBcard = ISBDStr
        End Function

        Private Function CreateISBDcardOPAC(ByVal ArrTitle() As String, Optional ByVal strWord As String = "", Optional ByVal strCoverPATH As String = "") As String
            Dim strResult As String = ""
            Try
                Dim i, k, c As Integer, ISBDStr As String, FoundKey, HasSum
                Dim rowMain, rowDetail As DataRow, rowView As DataRowView
                Dim tblMainInfor, tblDetailInfor, tblHoldingInfo As DataTable

                objDOPACItem.ItemID = intItemID
                tblMainInfor = objBCDBS.ConvertTable(objDOPACItem.GetItemMainInfor())
                'CoverPicture
                If Not IsDBNull(tblMainInfor.Rows(0).Item("CoverPicture")) AndAlso tblMainInfor.Rows(0).Item("CoverPicture") & "" <> "" Then
                    strURLCoverPicture = strCoverPATH & tblMainInfor.Rows(0).Item("CoverPicture")
                Else
                    strURLCoverPicture = "Images/Imgviet/Books.png"
                End If

                tblDetailInfor = objBCDBS.ConvertTable(objDOPACItem.GetItemDetailInforHighlight(strWord))

                If tblMainInfor.Rows.Count > 0 Then

                    strResult &= "<div class='panel-header'>"
                    strResult &= "<span class='icon-info-2'>&nbsp;</span>" & ArrTitle(0)
                    strResult &= ArrTitle(1)

                    strResult &= "</div>"
                    strResult &= "<div class='panel-content'>"
                    strResult &= "<div class='grid no-margin'>"
                    strResult &= "<div class='row'>"

                    'Cover
                    strResult &= "<div class='span2'>"
                    strResult &= "<div>"
                    strResult &= "<img src='" & strURLCoverPicture & "' class='rounded'>"
                    strResult &= "</div>"
                    strResult &= "</div>" 'Close span2

                    strResult &= "<div class='span7'>"

                    'Main Title
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '100'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            strResult &= "<span class='line-height'>"
                            strResult &= "<strong>" & UCase(objBCSP.TrimSubFieldCodes(rowView.Item("Content"))) & "</strong> "
                            strResult &= "</span>"
                            strResult &= "<br />"
                        End If
                    Next
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '110'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            strResult &= "<span class='line-height'>"
                            strResult &= "<strong>" & UCase(objBCSP.TrimSubFieldCodes(rowView.Item("Content"))) & "</strong> "
                            strResult &= "</span>"
                            strResult &= "<br />"
                        End If
                    Next
                    'Area 1: Title and statement of responsibility area
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '245'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            strResult &= "<span class='line-height'>"
                            strResult = strResult & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                            strResult &= "</span>"
                        End If
                    Next

                    'Area 2: Edition area
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '250'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            strResult &= "<span class='line-height'>"
                            strResult = strResult & ". -" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                            strResult &= "</span>"
                        End If
                    Next

                    'Area 3: Material (or type of publication) specific area

                    'Area 4: Publication, distribution, etc.,area
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '260'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            strResult &= "<span class='line-height'>"
                            strResult = strResult & ". -" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                            strResult &= "</span>"
                        End If
                    Next

                    'Area 5: Physical description area
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '300'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                                strResult &= "<span class='line-height'>"
                                strResult = strResult & ". -" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                                strResult &= "</span>"
                            End If
                        Next 'Loop
                    End If

                    'Area 6: Tung thu
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '490'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strResult &= "<span class='line-height'>"
                        strResult = strResult & "(. -"
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                                strResult = strResult & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                            End If
                        Next 'Loop
                        strResult = Left(strResult, strResult.Length - 1)
                        strResult = strResult & ")"
                        strResult &= "</span>"
                        strResult = strResult & "<BR />"
                    End If

                    'Area 7: Note area
                    strResult = strResult & "<BR />" ' & ArrTitle(0) & " "
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '500'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strResult &= "<span class='line-height'>"
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                                strResult = strResult & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "<BR />"
                            End If
                        Next 'Loop
                        strResult &= "</span>"
                        strResult = strResult & "<BR />"
                    End If
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '520'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strResult &= "<span class='line-height'>"
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                                strResult = strResult & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "<BR />"
                            End If
                        Next 'Loop
                        strResult &= "</span>"
                        strResult = strResult & "<BR />"
                    End If

                    'Area 8: Standard number (or alternative) and terms of availability 
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '020'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strResult &= "<span class='line-height'>"
                        strResult = strResult & "<BR />ISBN: "
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                                strResult = strResult & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                            End If
                        Next 'Loop
                        strResult = Left(strResult, strResult.Length - 1)
                        strResult &= "</span>"
                        strResult = strResult & "<BR />"
                    End If
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '022'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strResult &= "<span class='line-height'>"
                        strResult = strResult & "<BR />ISSN: "
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                                strResult = strResult & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                            End If
                        Next 'Loop
                        strResult = Left(strResult, strResult.Length - 1)
                        strResult &= "</span>"
                        strResult = strResult & "<BR />"
                    End If

                    'get URL
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '856'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        Dim strUrl As String = ""
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                                If InStr(rowView.Item("Content"), "http://") > 0 Then
                                    strUrl &= "<a href='" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "' target='_blank' class='lblinkfunction' style='cursor:pointer;'><div class='icon-link'></div>URL</a>; "
                                End If
                            End If
                        Next 'Loop
                        strUrl = strUrl.Trim
                        If strUrl <> "" Then
                            strUrl = strUrl.Substring(0, strUrl.Length - 1)
                            strUrl = Replace(strUrl, "<span style=""background-color:#60a917 !important;color:white;""></span>", "")
                        End If
                        strResult &= "<br />"
                        strResult &= strUrl
                        strResult &= "<br />"
                    End If

                    'get EDATA
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode='EDATA'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        Dim strEDATA As String = ""
                        strEDATA = tblDetailInfor.DefaultView(0).Item("Content") & ""
                        Dim strArr() As String = Split(strEDATA, ";")
                        If UBound(strArr) = 3 Then
                            strResult &= "<br />"
                            strResult &= "<a href='OViewLoading.aspx?fileType=" & strArr(1) & "&fileId=" & strArr(2) & "&ItemId=" & strArr(3) & "' TARGET='_parent'>" & strArr(0) & ArrTitle(4) & "</a>"
                        End If
                    End If

                    'Du lieu bao in/tap chi dien tu
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode='EMAGAZINE'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        Dim strEMAGAZINE As String = ""
                        strEMAGAZINE = tblDetailInfor.DefaultView(0).Item("Content") & ""
                        strResult &= "<br/>"
                        strResult &= "<a href=""javascript:parent.gotoMagazineList('OMagList.aspx?ItemId=" & intItemID & "')"">" & strEMAGAZINE & ArrTitle(4) & "</a>"
                    End If

                    'get Ranking
                    Dim strRANKING As String = 2
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode='RANKING'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strRANKING = tblDetailInfor.DefaultView(0).Item("Content")
                    End If
                    strResult &= "<br />"
                    strResult &= "<div class='rating  fg-green small' data-role='rating' data-static='true' data-score='" & strRANKING & "'  data-stars='5' data-show-score='false'  style='cursor:default;'>"
                    strResult &= "</div>"
                    'End ranking

                    'Additional area: Key word
                    'tblDetailInfor.DefaultView.RowFilter = "FieldCode = '653' or FieldCode = '655' or  FieldCode = '656' or FieldCode = '657'"
                    'If tblDetailInfor.DefaultView.Count > 0 Then
                    '    Dim inti As Integer = 0
                    '    ISBDStr = ISBDStr & "<BR>"
                    '    For Each rowView In tblDetailInfor.DefaultView
                    '        If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                    '            inti = inti + 1
                    '            ISBDStr = ISBDStr & inti & "." & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ". "
                    '        End If
                    '    Next 'Loop
                    'End If

                    strResult &= "</div>" 'div span7
                    strResult &= "</div>" 'div grid no-margin
                    strResult &= "</div>" 'div row
                    strResult &= "</div>" 'div panel-content
                End If
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        Private Function CreateISBDcardOPAC_SSC(ByVal ArrTitle() As String, Optional ByVal strWord As String = "", Optional ByVal strCoverPATH As String = "") As String
            Dim strResult As String = ""
            Try
                Dim i, k, c As Integer, ISBDStr As String, FoundKey, HasSum
                Dim rowMain, rowDetail As DataRow, rowView As DataRowView
                Dim tblMainInfor, tblDetailInfor, tblHoldingInfo As DataTable

                objDOPACItem.ItemID = intItemID
                tblMainInfor = objBCDBS.ConvertTable(objDOPACItem.GetItemMainInfor())
                'CoverPicture
                If Not IsDBNull(tblMainInfor.Rows(0).Item("CoverPicture")) AndAlso tblMainInfor.Rows(0).Item("CoverPicture") & "" <> "" Then
                    strURLCoverPicture = strCoverPATH & tblMainInfor.Rows(0).Item("CoverPicture")
                Else
                    strURLCoverPicture = "Images/Imgviet/Books.png"
                End If

                tblDetailInfor = objBCDBS.ConvertTable(objDOPACItem.GetItemDetailInforHighlight(strWord))

                If tblMainInfor.Rows.Count > 0 Then

                    'strResult &= "<div class='panel-header'>"
                    'strResult &= "<span class='icon-info-2'>&nbsp;</span>" & ArrTitle(0)
                    'strResult &= ArrTitle(1)

                    'strResult &= "</div>"
                    'strResult &= "<div class='panel-content'>"
                    'strResult &= "<div class='grid no-margin'>"
                    'strResult &= "<div class='row'>"

                    ''Cover
                    'strResult &= "<div class='span2'>"
                    'strResult &= "<div>"
                    'strResult &= "<img src='" & strURLCoverPicture & "' class='rounded'>"
                    'strResult &= "</div>"
                    'strResult &= "</div>" 'Close span2

                    'strResult &= "<div class='span7'>"

                    strResult &= "<h3 class='HeadStyles'>" & ArrTitle(0) & ArrTitle(1) & "</h3>"
                    strResult &= "<div class='ClearFix'>"

                    strResult &= "<div class='col-left-2'>"
                    strResult &= "<div class='modul-img'>"
                    strResult &= "<img src='" & strURLCoverPicture & "'>"
                    strResult &= "</div>"

                    'get Ranking
                    Dim strRANKING As String = 2
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode='RANKING'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strRANKING = tblDetailInfor.DefaultView(0).Item("Content")
                    End If
                    'strResult &= "<div class=""info-star"">"
                    'Try
                    '    For kk As Integer = 1 To CInt(strRANKING)
                    '        If kk = 1 Then
                    '            strResult &= "<span class=""icon-star-4""></span>"
                    '        Else
                    '            strResult &= "<span class=""icon-star-3""></span>"
                    '        End If
                    '    Next
                    '    For kk As Integer = 5 To CInt(strRANKING) + 1 Step -1
                    '        strResult &= "<span class=""icon-star""></span>"
                    '    Next
                    'Catch ex As Exception
                    'End Try
                    'strResult &= "</div>"
                    strResult &= "<div style=""vertical-align:top;text-align:center"" class=""rating"" data-role=""rating"" data-value=""" & strRANKING & """ data-static=""true"" data-show-score=""false""></div>"

                    'get EDATA
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode='EDATA'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        Dim strEDATA As String = ""
                        strEDATA = tblDetailInfor.DefaultView(0).Item("Content") & ""
                        Dim strArr() As String = Split(strEDATA, ";")
                        If UBound(strArr) = 3 Then
                            'strResult &= "<strong>" & ArrTitle(24) & "</strong><a href='OViewLoading.aspx?fileType=" & strArr(1) & "&fileId=" & strArr(2) & "&ItemId=" & strArr(3) & "'  TARGET='_parent'>" & strArr(0) & ArrTitle(25) & "</a>"
                            strResult &= "<a class=""btn-read"" href='OViewLoading.aspx?fileType=" & strArr(1) & "&fileId=" & strArr(2) & "&ItemId=" & strArr(3) & "'  TARGET='_parent'>" & strArr(0) & ArrTitle(4) & "</a>"
                        End If
                    End If

                    'Du lieu bao in/tap chi dien tu
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode='EMAGAZINE'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        Dim strEMAGAZINE As String = ""
                        strEMAGAZINE = tblDetailInfor.DefaultView(0).Item("Content") & ""
                        'strResult &= "<br/>"
                        'strResult &= "<strong>" & ArrTitle(24) & "</strong><a href=""javascript:parent.gotoMagazineList('OMagList.aspx?ItemId=" & intItemID & "')"">" & strEMAGAZINE & ArrTitle(25) & "</a>"
                        'strResult &= "<a class=""btn-read"" href=""javascript:parent.gotoMagazineList('OMagList.aspx?ItemId=" & intItemID & "')"">" & strEMAGAZINE & ArrTitle(4) & "</a>"
                        strResult &= "<a class=""btn-read"" href='OMagList.aspx?ItemId=" & intItemID & "' TARGET='_parent'>" & strEMAGAZINE & ArrTitle(4) & "</a>"
                    End If

                    strResult &= "</div>" 'close col-left-2
                    strResult &= "<div class=""col-right-8"">"
                    strResult &= "<ul>"

                    'Main Title
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '100'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            'strResult &= "<span class='line-height'>"
                            'strResult &= "<strong>" & UCase(objBCSP.TrimSubFieldCodes(rowView.Item("Content"))) & "</strong> "
                            'strResult &= "</span>"
                            'strResult &= "<br />"
                            strResult &= "<li><span>"
                            strResult &= UCase(objBCSP.TrimSubFieldCodes(rowView.Item("Content")))
                            strResult &= "</span>"
                            strResult &= "</li>"
                        End If
                    Next
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '110'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            strResult &= "<li><span>"
                            strResult &= UCase(objBCSP.TrimSubFieldCodes(rowView.Item("Content")))
                            strResult &= "</span>"
                            strResult &= "</li>"
                        End If
                    Next
                    'Area 1: Title and statement of responsibility area
                    strResult &= "<li>"
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '245'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            'strResult &= "<span class='line-height'>"
                            'strResult = strResult & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                            'strResult &= "</span>"
                            strResult = strResult & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                        End If
                    Next

                    'Area 2: Edition area
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '250'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            'strResult &= "<span class='line-height'>"
                            'strResult = strResult & ". -" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                            'strResult &= "</span>"
                            strResult = strResult & ". -" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                        End If
                    Next

                    'Area 3: Material (or type of publication) specific area

                    'Area 4: Publication, distribution, etc.,area
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '260'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            'strResult &= "<span class='line-height'>"
                            'strResult = strResult & ". -" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                            'strResult &= "</span>"
                            strResult = strResult & ". -" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                        End If
                    Next

                    'Area 5: Physical description area
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '300'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                                'strResult &= "<span class='line-height'>"
                                'strResult = strResult & ". -" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                                'strResult &= "</span>"
                                strResult = strResult & ". -" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                            End If
                        Next 'Loop
                    End If
                    strResult &= "</li>"

                    'Area 6: Tung thu
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '490'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strResult &= "<li>"
                        strResult = strResult & "(. -"
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                                strResult = strResult & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                            End If
                        Next 'Loop
                        strResult = Left(strResult, strResult.Length - 1)
                        strResult = strResult & ")"
                        strResult &= "</li>"
                    End If

                    'Area 7: Note area
                    strResult = strResult & "<BR />" ' & ArrTitle(0) & " "
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '500'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strResult &= "<li>"
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                                strResult = strResult & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "<BR />"
                            End If
                        Next 'Loop
                        strResult &= "</li>"
                    End If
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '520'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strResult &= "<li>"
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                                strResult = strResult & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "<BR />"
                            End If
                        Next 'Loop
                        strResult &= "</li>"
                    End If

                    'Area 8: Standard number (or alternative) and terms of availability 
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '090'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strResult &= "<li>Số định danh: "
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                                strResult = strResult & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                            End If
                        Next 'Loop
                        strResult = Left(strResult, strResult.Length - 1)
                        strResult &= "</li>"
                    End If
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '022'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strResult &= "<li>ISSN: "
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                                strResult = strResult & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                            End If
                        Next 'Loop
                        strResult = Left(strResult, strResult.Length - 1)
                        strResult &= "</li>"
                    End If

                    'get URL
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '856'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        Dim strUrl As String = ""
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                                If InStr(rowView.Item("Content"), "http://") > 0 Then
                                    strUrl &= "<a href='" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "' target='_blank' class='lblinkfunction' style='cursor:pointer;'><div class='icon-link'></div>URL</a>; "
                                End If
                            End If
                        Next 'Loop
                        strUrl = strUrl.Trim
                        If strUrl <> "" Then
                            strUrl = strUrl.Substring(0, strUrl.Length - 1)
                            strUrl = Replace(strUrl, "<span class=""hightlight-text""></span>", "")
                            strUrl = Replace(strUrl, "<span class=""""hightlight-text""""></span>", "")
                        End If
                        strResult &= "<li>"
                        strResult &= strUrl
                        strResult &= "</li>"
                    End If

                    ''get EDATA
                    'tblDetailInfor.DefaultView.RowFilter = "FieldCode='EDATA'"
                    'If tblDetailInfor.DefaultView.Count > 0 Then
                    '    Dim strEDATA As String = ""
                    '    strEDATA = tblDetailInfor.DefaultView(0).Item("Content") & ""
                    '    Dim strArr() As String = Split(strEDATA, ";")
                    '    If UBound(strArr) = 3 Then
                    '        strResult &= "<br />"
                    '        strResult &= "<a href='OViewLoading.aspx?fileType=" & strArr(1) & "&fileId=" & strArr(2) & "&ItemId=" & strArr(3) & "' TARGET='_parent'>" & strArr(0) & ArrTitle(4) & "</a>"
                    '    End If
                    'End If

                    ''Du lieu bao in/tap chi dien tu
                    'tblDetailInfor.DefaultView.RowFilter = "FieldCode='EMAGAZINE'"
                    'If tblDetailInfor.DefaultView.Count > 0 Then
                    '    Dim strEMAGAZINE As String = ""
                    '    strEMAGAZINE = tblDetailInfor.DefaultView(0).Item("Content") & ""
                    '    strResult &= "<br/>"
                    '    strResult &= "<a href=""javascript:parent.gotoMagazineList('OMagList.aspx?ItemId=" & intItemID & "')"">" & strEMAGAZINE & ArrTitle(4) & "</a>"
                    'End If

                    ''get Ranking
                    'Dim strRANKING As String = 2
                    'tblDetailInfor.DefaultView.RowFilter = "FieldCode='RANKING'"
                    'If tblDetailInfor.DefaultView.Count > 0 Then
                    '    strRANKING = tblDetailInfor.DefaultView(0).Item("Content")
                    'End If
                    'strResult &= "<br />"
                    'strResult &= "<div class='rating  fg-green small' data-role='rating' data-static='true' data-score='" & strRANKING & "'  data-stars='5' data-show-score='false'  style='cursor:default;'>"
                    'strResult &= "</div>"
                    ''End ranking

                    'Additional area: Key word
                    'tblDetailInfor.DefaultView.RowFilter = "FieldCode = '653' or FieldCode = '655' or  FieldCode = '656' or FieldCode = '657'"
                    'If tblDetailInfor.DefaultView.Count > 0 Then
                    '    Dim inti As Integer = 0
                    '    ISBDStr = ISBDStr & "<BR>"
                    '    For Each rowView In tblDetailInfor.DefaultView
                    '        If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                    '            inti = inti + 1
                    '            ISBDStr = ISBDStr & inti & "." & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ". "
                    '        End If
                    '    Next 'Loop
                    'End If

                    strResult &= "<ul>"
                    strResult &= "</div>" 'col-right-8
                    strResult &= "</div>" 'ClearFix
                End If
            Catch ex As Exception
            End Try
            Return strResult
        End Function


        ' CreateBriefCard function
        ' Purpose: View record with Catalog Card type
        ' Copy from Catalogue Module
        Private Function CreateBriefCard(ByVal ArrTitle() As String) As String
            Dim i, k, c As Integer, ISBDStr As String, FoundKey, HasSum
            Dim rowMain, rowDetail As DataRow, rowView As DataRowView
            Dim tblMainInfor, tblDetailInfor, tblMarc, tblHoldingInfo As DataTable

            objDOPACItem.ItemID = intItemID
            tblMainInfor = objBCDBS.ConvertTable(objDOPACItem.GetItemMainInfor())
            'CoverPicture
            If tblMainInfor.Rows(0).Item("CoverPicture") & "" <> "" Then
                strURLCoverPicture = tblMainInfor.Rows(0).Item("CoverPicture")
            Else
                strURLCoverPicture = ""
            End If

            tblDetailInfor = objBCDBS.ConvertTable(objDOPACItem.GetItemDetailInfor())

            If tblMainInfor.Rows.Count > 0 Then

                ISBDStr = "<TABLE WIDTH=100% BORDER = 0 class='lbLabel'>"
                'ISBDStr = ISBDStr & "<FONT size=+2 Face=Arial>"
                'LC Control Number
                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '010'"
                For Each rowView In tblDetailInfor.DefaultView
                    If Not IsDBNull(rowView.Item("Content")) Then
                        ISBDStr = ISBDStr & "<TR VALIGN='Top'><TD WIDTH='150px'> <B>" & ArrTitle(0) & "</B></TD><TD>" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "</TD></TR>"
                    End If
                Next

                'Type of Material
                'ISBDStr = ISBDStr & "<TR VALIGN='Top'><TD WIDTH='150px'><B> " & ArrTitle(1) & "</B></TD><TD>" & tblMainInfor.Rows(0).Item("TypeName") & "</TD></TR>"
                tblMarc = objBCDBS.ConvertTable(objDOPACItem.GetMARC())
                tblMarc.DefaultView.RowFilter = "FieldCode = 'Ldr'"
                ISBDStr = ISBDStr & "<TR VALIGN='Top'><TD WIDTH='150px'><B> " & ArrTitle(1) & "</B></TD><TD>" & GetRecTypebyLdr(tblMarc.Rows(0).Item("Content"), ArrTitle(5), ArrTitle(6)) & "</TD></TR>"

                'Brief Description
                ISBDStr = ISBDStr & "<TR VALIGN='Top'><TD WIDTH='150px'><B>" & ArrTitle(2) & "</B></TD> <TD>"

                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '100'"
                For Each rowView In tblDetailInfor.DefaultView
                    If Not IsDBNull(rowView.Item("Content")) Then
                        ISBDStr = ISBDStr & "<B>" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "</B><BR>"
                    End If
                Next

                'Area 1: Title and statement of responsibility area
                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '245'"
                For Each rowView In tblDetailInfor.DefaultView
                    If Not IsDBNull(rowView.Item("Content")) Then
                        ISBDStr = ISBDStr & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "<BR>"
                    End If
                Next

                'Area 2: Edition area
                'tblDetailInfor.DefaultView.RowFilter = "FieldCode = '250'"
                'For Each rowView In tblDetailInfor.DefaultView
                '    If Not IsDBNull(rowView.Item("Content")) Then
                '        ISBDStr = ISBDStr & "." & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                '    End If
                'Next

                'Area 3: Material (or type of publication) specific area

                'Area 4: Publication, distribution, etc.,area
                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '260'"
                For Each rowView In tblDetailInfor.DefaultView
                    If Not IsDBNull(rowView.Item("Content")) Then
                        ISBDStr = ISBDStr & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "<BR>"
                    End If
                Next

                'Area 5: Physical description area
                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '300'"
                If tblDetailInfor.DefaultView.Count > 0 Then
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                            ISBDStr = ISBDStr & "<BR>" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "</B><BR>"
                        End If
                    Next 'Loop
                End If

                'Area 6: Series area
                'Area 7: Note area
                'tblDetailInfor.DefaultView.RowFilter = "FieldCode = '500'"
                'If tblDetailInfor.DefaultView.Count > 0 Then
                '    For Each rowView In tblDetailInfor.DefaultView
                '        If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                '            ISBDStr = ISBDStr & "<BR>" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "</B><BR>"
                '        End If
                '    Next 'Loop
                'End If

                'Area 8: Standard number (or alternative) and terms of availability 
                'tblDetailInfor.DefaultView.RowFilter = "FieldCode = '020'"
                'If tblDetailInfor.DefaultView.Count > 0 Then
                '    For Each rowView In tblDetailInfor.DefaultView
                '        If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                '            ISBDStr = ISBDStr & "<BR>" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "</B><BR>"
                '        End If
                '    Next 'Loop
                'End If
                'Call Number
                tblHoldingInfo = objBCDBS.ConvertTable(objDOPACItem.GetHoldingInfo())
                If (Not tblHoldingInfo Is Nothing) AndAlso tblHoldingInfo.Rows.Count > 0 Then
                    ISBDStr = ISBDStr & "<TR><TD>" & ArrTitle(3) & "</TD> <TD> " & tblHoldingInfo.Rows(0).Item("CallNumber") & " </TD></TR>"
                End If

                'ISBDStr = ISBDStr & "<TD></TR>"
                'ISBDStr = ISBDStr & "</FONT>"
                ISBDStr = ISBDStr & "</TABLE>"
            End If 'Next i

            CreateBriefCard = ISBDStr
        End Function


        ' CreateBriefCard function
        ' Purpose: View record with Catalog Card type
        ' Copy from Catalogue Module
        Private Function CreateBriefCardOPAC(ByVal ArrTitle() As String, Optional ByVal strWord As String = "", Optional ByVal strCoverPATH As String = "") As String
            Dim strResult As String = ""
            Try
                Dim i, k, c As Integer, ISBDStr As String, FoundKey, HasSum
                Dim rowMain, rowDetail As DataRow, rowView As DataRowView
                Dim tblMainInfor, tblDetailInfor, tblMarc, tblHoldingInfo As DataTable

                objDOPACItem.ItemID = intItemID
                tblMainInfor = objBCDBS.ConvertTable(objDOPACItem.GetItemMainInfor())
                'CoverPicture
                If Not IsDBNull(tblMainInfor.Rows(0).Item("CoverPicture")) AndAlso tblMainInfor.Rows(0).Item("CoverPicture") & "" <> "" Then
                    strURLCoverPicture = strCoverPATH & tblMainInfor.Rows(0).Item("CoverPicture")
                Else
                    strURLCoverPicture = "Images/Imgviet/Books.png"
                End If

                tblDetailInfor = objBCDBS.ConvertTable(objDOPACItem.GetItemDetailInforHighlight(strWord))

                If tblMainInfor.Rows.Count > 0 Then

                    strResult &= "<div class='panel-header'>"
                    strResult &= "<span class='icon-info-2'>&nbsp;</span>" & ArrTitle(7)
                    strResult &= ArrTitle(11)

                    strResult &= "</div>"
                    strResult &= "<div class='panel-content'>"
                    strResult &= "<div class='grid no-margin'>"
                    strResult &= "<div class='row'>"

                    'Cover
                    strResult &= "<div class='span2'>"
                    strResult &= "<div>"
                    strResult &= "<img src='" & strURLCoverPicture & "' class='rounded'>"
                    strResult &= "</div>"
                    strResult &= "</div>" 'Close span2

                    strResult &= "<div class='span7'>"

                    'LC Control Number
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '010'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            strResult &= "<span class='line-height'>"
                            strResult &= "<strong>" & ArrTitle(0) & "</strong> " & objBCSP.TrimSubFieldCodes(rowView.Item("Content"))
                            strResult &= "</span>"
                            strResult &= "<br />"
                        End If
                    Next

                    'Type of Material
                    tblMarc = objBCDBS.ConvertTable(objDOPACItem.GetMARC())
                    tblMarc.DefaultView.RowFilter = "FieldCode = 'Ldr'"
                    strResult &= "<span class='line-height'>"
                    strResult &= "<strong>" & ArrTitle(1) & "</strong> " & GetRecTypebyLdr(tblMarc.Rows(0).Item("Content"), ArrTitle(5), ArrTitle(6))
                    strResult &= "</span>"
                    strResult &= "<br />"

                    'Brief Description
                    strResult &= "<span class='line-height'>"
                    strResult &= "<strong>" & ArrTitle(2) & "</strong> "


                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '100'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            strResult &= "<strong>" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "</strong>"
                            strResult &= "<br />"
                        End If
                    Next

                    'Area 1: Title and statement of responsibility area
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '245'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            strResult &= objBCSP.TrimSubFieldCodes(rowView.Item("Content"))
                            strResult &= "<br />"
                        End If
                    Next

                    'Area 2: Edition area
                    'tblDetailInfor.DefaultView.RowFilter = "FieldCode = '250'"
                    'For Each rowView In tblDetailInfor.DefaultView
                    '    If Not IsDBNull(rowView.Item("Content")) Then
                    '        ISBDStr = ISBDStr & "." & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                    '    End If
                    'Next

                    'Area 3: Material (or type of publication) specific area

                    'Area 4: Publication, distribution, etc.,area
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '260'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            strResult &= objBCSP.TrimSubFieldCodes(rowView.Item("Content"))
                            strResult &= "<br />"
                        End If
                    Next

                    'Area 5: Physical description area
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '300'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                                strResult &= objBCSP.TrimSubFieldCodes(rowView.Item("Content"))
                                strResult &= "<br />"
                            End If
                        Next 'Loop
                    End If

                    'Call Number
                    tblHoldingInfo = objBCDBS.ConvertTable(objDOPACItem.GetHoldingInfo())
                    If (Not tblHoldingInfo Is Nothing) AndAlso tblHoldingInfo.Rows.Count > 0 Then
                        'ISBDStr = ISBDStr & "<TR><TD>" & ArrTitle(3) & "</TD> <TD> " & tblHoldingInfo.Rows(0).Item("CallNumber") & " </TD></TR>"
                        strResult &= "<strong>" & ArrTitle(3) & "</strong> " & tblHoldingInfo.Rows(0).Item("CallNumber")
                        strResult &= "<br />"
                    End If

                    'get URL
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '856'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        Dim strUrl As String = ""
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                                If InStr(rowView.Item("Content"), "http://") > 0 Then
                                    strUrl &= "<a href='" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "' target='_blank' class='lblinkfunction' style='cursor:pointer;'><div class='icon-link'></div>URL</a>; "
                                End If
                            End If
                        Next 'Loop
                        strUrl = strUrl.Trim
                        If strUrl <> "" Then
                            strUrl = strUrl.Substring(0, strUrl.Length - 1)
                            strUrl = Replace(strUrl, "<span style=""background-color:#60a917 !important;color:white;""></span>", "")
                            strUrl = "<strong>" & ArrTitle(8) & "</strong> " & strUrl
                        End If
                        strResult &= "<br />"
                        strResult &= strUrl
                    End If

                    'get EDATA
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode='EDATA'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        Dim strEDATA As String = ""
                        strEDATA = tblDetailInfor.DefaultView(0).Item("Content") & ""
                        Dim strArr() As String = Split(strEDATA, ";")
                        If UBound(strArr) = 3 Then
                            strResult &= "<br />"
                            strResult &= "<strong>" & ArrTitle(9) & "</strong><a href='OViewLoading.aspx?fileType=" & strArr(1) & "&fileId=" & strArr(2) & "&ItemId=" & strArr(3) & "'  TARGET='_parent'>" & strArr(0) & ArrTitle(10) & "</a>"
                        End If
                    End If

                    'Du lieu bao in/tap chi dien tu
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode='EMAGAZINE'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        Dim strEMAGAZINE As String = ""
                        strEMAGAZINE = tblDetailInfor.DefaultView(0).Item("Content") & ""
                        strResult &= "<br/>"
                        strResult &= "<strong>" & ArrTitle(9) & "</strong><a href=""javascript:parent.gotoMagazineList('OMagList.aspx?ItemId=" & intItemID & "')"">" & strEMAGAZINE & ArrTitle(10) & "</a>"
                    End If

                    'get Ranking
                    Dim strRANKING As String = 2
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode='RANKING'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strRANKING = tblDetailInfor.DefaultView(0).Item("Content")
                    End If
                    strResult &= "<br />"
                    strResult &= "<div class='rating  fg-green small' data-role='rating' data-static='true' data-score='" & strRANKING & "'  data-stars='5' data-show-score='false'   style='cursor:default;'>"
                    strResult &= "</div>"
                    'End ranking

                    strResult &= "</span>" 'close Brief Description

                    strResult &= "</div>" 'div span7
                    strResult &= "</div>" 'div grid no-margin
                    strResult &= "</div>" 'div row
                    strResult &= "</div>" 'div panel-content
                End If 'Next i
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        ' CreateBriefCard function
        ' Purpose: View record with Catalog Card type
        ' Copy from Catalogue Module
        Private Function CreateBriefCardOPAC_SSC(ByVal ArrTitle() As String, Optional ByVal strWord As String = "", Optional ByVal strCoverPATH As String = "") As String
            Dim strResult As String = ""
            Try
                Dim i, k, c As Integer, ISBDStr As String, FoundKey, HasSum
                Dim rowMain, rowDetail As DataRow, rowView As DataRowView
                Dim tblMainInfor, tblDetailInfor, tblMarc, tblHoldingInfo As DataTable

                objDOPACItem.ItemID = intItemID
                tblMainInfor = objBCDBS.ConvertTable(objDOPACItem.GetItemMainInfor())
                'CoverPicture
                If Not IsDBNull(tblMainInfor.Rows(0).Item("CoverPicture")) AndAlso tblMainInfor.Rows(0).Item("CoverPicture") & "" <> "" Then
                    strURLCoverPicture = strCoverPATH & tblMainInfor.Rows(0).Item("CoverPicture")
                Else
                    strURLCoverPicture = "Images/Imgviet/Books.png"
                End If

                tblDetailInfor = objBCDBS.ConvertTable(objDOPACItem.GetItemDetailInforHighlight(strWord))

                If tblMainInfor.Rows.Count > 0 Then

                    'strResult &= "<div class='panel-header'>"
                    'strResult &= "<span class='icon-info-2'>&nbsp;</span>" & ArrTitle(7)
                    'strResult &= ArrTitle(11)

                    'strResult &= "</div>"
                    'strResult &= "<div class='panel-content'>"
                    'strResult &= "<div class='grid no-margin'>"
                    'strResult &= "<div class='row'>"

                    ''Cover
                    'strResult &= "<div class='span2'>"
                    'strResult &= "<div>"
                    'strResult &= "<img src='" & strURLCoverPicture & "' class='rounded'>"
                    'strResult &= "</div>"
                    'strResult &= "</div>" 'Close span2

                    'strResult &= "<div class='span7'>"

                    strResult &= "<h3 class='HeadStyles'>" & ArrTitle(7) & ArrTitle(11) & "</h3>"
                    strResult &= "<div class='ClearFix'>"

                    strResult &= "<div class='col-left-2'>"
                    strResult &= "<div class='modul-img'>"
                    strResult &= "<img src='" & strURLCoverPicture & "'>"
                    strResult &= "</div>"

                    'get Ranking
                    Dim strRANKING As String = 2
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode='RANKING'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strRANKING = tblDetailInfor.DefaultView(0).Item("Content")
                    End If
                    'strResult &= "<div class=""info-star"">"
                    'Try
                    '    For kk As Integer = 1 To CInt(strRANKING)
                    '        If kk = 1 Then
                    '            strResult &= "<span class=""icon-star-4""></span>"
                    '        Else
                    '            strResult &= "<span class=""icon-star-3""></span>"
                    '        End If
                    '    Next
                    '    For kk As Integer = 5 To CInt(strRANKING) + 1 Step -1
                    '        strResult &= "<span class=""icon-star""></span>"
                    '    Next
                    'Catch ex As Exception
                    'End Try
                    'strResult &= "</div>"

                    strResult &= "<div style=""vertical-align:top;text-align:center"" class=""rating"" data-role=""rating"" data-value=""" & strRANKING & """ data-static=""true"" data-show-score=""false""></div>"

                    'get EDATA
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode='EDATA'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        Dim strEDATA As String = ""
                        strEDATA = tblDetailInfor.DefaultView(0).Item("Content") & ""
                        Dim strArr() As String = Split(strEDATA, ";")
                        If UBound(strArr) = 3 Then
                            'strResult &= "<strong>" & ArrTitle(24) & "</strong><a href='OViewLoading.aspx?fileType=" & strArr(1) & "&fileId=" & strArr(2) & "&ItemId=" & strArr(3) & "'  TARGET='_parent'>" & strArr(0) & ArrTitle(25) & "</a>"
                            strResult &= "<a class=""btn-read"" href='OViewLoading.aspx?fileType=" & strArr(1) & "&fileId=" & strArr(2) & "&ItemId=" & strArr(3) & "'  TARGET='_parent'>" & strArr(0) & ArrTitle(10) & "</a>"
                        End If
                    End If

                    'Du lieu bao in/tap chi dien tu
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode='EMAGAZINE'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        Dim strEMAGAZINE As String = ""
                        strEMAGAZINE = tblDetailInfor.DefaultView(0).Item("Content") & ""
                        'strResult &= "<br/>"
                        'strResult &= "<strong>" & ArrTitle(24) & "</strong><a href=""javascript:parent.gotoMagazineList('OMagList.aspx?ItemId=" & intItemID & "')"">" & strEMAGAZINE & ArrTitle(25) & "</a>"
                        strResult &= "<a class=""btn-read"" href='OMagList.aspx?ItemId=" & intItemID & "' TARGET='_parent'>" & strEMAGAZINE & ArrTitle(25) & "</a>"
                    End If

                    strResult &= "</div>" 'close col-left-2
                    strResult &= "<div class=""col-right-8"">"
                    strResult &= "<ul>"

                    'LC Control Number
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '010'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            'strResult &= "<span class='line-height'>"
                            'strResult &= "<strong>" & ArrTitle(0) & "</strong> " & objBCSP.TrimSubFieldCodes(rowView.Item("Content"))
                            'strResult &= "</span>"
                            'strResult &= "<br />"
                            strResult &= "<li><span>"
                            strResult &= ArrTitle(0)
                            strResult &= "</span>"
                            strResult &= objBCSP.TrimSubFieldCodes(rowView.Item("Content"))
                            strResult &= "</li>"
                        End If
                    Next

                    'Type of Material
                    tblMarc = objBCDBS.ConvertTable(objDOPACItem.GetMARC())
                    tblMarc.DefaultView.RowFilter = "FieldCode = 'Ldr'"
                    'strResult &= "<span class='line-height'>"
                    'strResult &= "<strong>" & ArrTitle(1) & "</strong> " & GetRecTypebyLdr(tblMarc.Rows(0).Item("Content"), ArrTitle(5), ArrTitle(6))
                    'strResult &= "</span>"
                    'strResult &= "<br />"
                    strResult &= "<li><span>"
                    strResult &= ArrTitle(1)
                    strResult &= "</span>"
                    strResult &= GetRecTypebyLdr(tblMarc.Rows(0).Item("Content"), ArrTitle(5), ArrTitle(6))
                    strResult &= "</li>"

                    'Brief Description
                    'strResult &= "<span class='line-height'>"
                    'strResult &= "<strong>" & ArrTitle(2) & "</strong> "
                    strResult &= "<li><span>"
                    strResult &= ArrTitle(2)
                    strResult &= "</span>"

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '100'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            strResult &= "<span>" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "</span>"
                            strResult &= "<br />"
                        End If
                    Next
                    strResult &= "</li>"

                    'Area 1: Title and statement of responsibility area
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '245'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            strResult &= "<li>"
                            strResult &= objBCSP.TrimSubFieldCodes(rowView.Item("Content"))
                            strResult &= "</li>"
                        End If
                    Next

                    'Area 2: Edition area
                    'tblDetailInfor.DefaultView.RowFilter = "FieldCode = '250'"
                    'For Each rowView In tblDetailInfor.DefaultView
                    '    If Not IsDBNull(rowView.Item("Content")) Then
                    '        ISBDStr = ISBDStr & "." & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                    '    End If
                    'Next

                    'Area 3: Material (or type of publication) specific area

                    'Area 4: Publication, distribution, etc.,area
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '260'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            strResult &= "<li>"
                            strResult &= objBCSP.TrimSubFieldCodes(rowView.Item("Content"))
                            strResult &= "</li>"
                        End If
                    Next

                    'Area 5: Physical description area
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '300'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                                strResult &= "<li>"
                                strResult &= objBCSP.TrimSubFieldCodes(rowView.Item("Content"))
                                strResult &= "</li>"
                            End If
                        Next 'Loop
                    End If



                    'Call Number
                    tblHoldingInfo = objBCDBS.ConvertTable(objDOPACItem.GetHoldingInfo())
                    If (Not tblHoldingInfo Is Nothing) AndAlso tblHoldingInfo.Rows.Count > 0 Then
                        'ISBDStr = ISBDStr & "<TR><TD>" & ArrTitle(3) & "</TD> <TD> " & tblHoldingInfo.Rows(0).Item("CallNumber") & " </TD></TR>"
                        strResult &= "<li>"
                        strResult &= "<span>" & ArrTitle(3) & "</span> " & tblHoldingInfo.Rows(0).Item("CallNumber")
                        strResult &= "</li>"
                    End If

                    'get URL
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '856'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        Dim strUrl As String = ""
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                                If InStr(rowView.Item("Content"), "http://") > 0 Then
                                    strUrl &= "<a href='" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "' target='_blank' class='lblinkfunction' style='cursor:pointer;'><div class='icon-link'></div>URL</a>; "
                                End If
                            End If
                        Next 'Loop
                        strUrl = strUrl.Trim
                        If strUrl <> "" Then
                            strUrl = strUrl.Substring(0, strUrl.Length - 1)
                            strUrl = Replace(strUrl, "<span style=""background-color:#60a917 !important;color:white;""></span>", "")
                            strUrl = "<span>" & ArrTitle(8) & "</span> " & strUrl
                        End If
                        strResult &= "<li>"
                        strResult &= strUrl
                        strResult &= "</li>"
                    End If

                    ''get EDATA
                    'tblDetailInfor.DefaultView.RowFilter = "FieldCode='EDATA'"
                    'If tblDetailInfor.DefaultView.Count > 0 Then
                    '    Dim strEDATA As String = ""
                    '    strEDATA = tblDetailInfor.DefaultView(0).Item("Content") & ""
                    '    Dim strArr() As String = Split(strEDATA, ";")
                    '    If UBound(strArr) = 3 Then
                    '        strResult &= "<br />"
                    '        strResult &= "<strong>" & ArrTitle(9) & "</strong><a href='OViewLoading.aspx?fileType=" & strArr(1) & "&fileId=" & strArr(2) & "&ItemId=" & strArr(3) & "'  TARGET='_parent'>" & strArr(0) & ArrTitle(10) & "</a>"
                    '    End If
                    'End If

                    ''Du lieu bao in/tap chi dien tu
                    'tblDetailInfor.DefaultView.RowFilter = "FieldCode='EMAGAZINE'"
                    'If tblDetailInfor.DefaultView.Count > 0 Then
                    '    Dim strEMAGAZINE As String = ""
                    '    strEMAGAZINE = tblDetailInfor.DefaultView(0).Item("Content") & ""
                    '    strResult &= "<br/>"
                    '    strResult &= "<strong>" & ArrTitle(9) & "</strong><a href=""javascript:parent.gotoMagazineList('OMagList.aspx?ItemId=" & intItemID & "')"">" & strEMAGAZINE & ArrTitle(10) & "</a>"
                    'End If

                    ''get Ranking
                    'Dim strRANKING As String = 2
                    'tblDetailInfor.DefaultView.RowFilter = "FieldCode='RANKING'"
                    'If tblDetailInfor.DefaultView.Count > 0 Then
                    '    strRANKING = tblDetailInfor.DefaultView(0).Item("Content")
                    'End If
                    'strResult &= "<br />"
                    'strResult &= "<div class='rating  fg-green small' data-role='rating' data-static='true' data-score='" & strRANKING & "'  data-stars='5' data-show-score='false'   style='cursor:default;'>"
                    'strResult &= "</div>"
                    ''End ranking

                    'strResult &= "</span>" 'close Brief Description

                    strResult &= "<ul>"
                    strResult &= "</div>" 'col-right-8
                    strResult &= "</div>" 'ClearFix
                End If 'Next i
            Catch ex As Exception
            End Try
            Return strResult
        End Function


        ' CreateFullCard function
        ' Purpose: View record with Catalog Card type
        ' Copy from Catalogue Module
        Private Function CreateFullCard(ByVal ArrTitle) As String
            Dim intCount As Integer
            Dim i, k, c As Integer, ISBDStr As String, FoundKey, HasSum
            Dim rowMain, rowDetail As DataRow, rowView As DataRowView
            Dim tblMainInfor, tblDetailInfor, tblMarc As DataTable

            objDOPACItem.ItemID = intItemID
            tblMainInfor = objBCDBS.ConvertTable(objDOPACItem.GetItemMainInfor())
            tblDetailInfor = objBCDBS.ConvertTable(objDOPACItem.GetItemDetailInfor())

            If tblMainInfor.Rows.Count > 0 Then

                ISBDStr = "<TABLE WIDTH='100%' BORDER = '0' id='tblRecDetail' class= 'lbLabel'>"

                'Loại tài liệu:			008
                'Chỉ số ISBN:			020$a
                'Chỉ số ISSN:			022$a		
                'Mã ngôn ngữ:		    041		
                'Chỉ số phân loại:		Phân loại thập phân bách khoa  	080
                '                       Phân loại thập phân Dewey        	082
                '                       Phân loại khác 			084	 
                'Tác giả                100$a, 110$a
                'Thông tin nhan đề:		245$a=245$b:245$b/245$c;700$a 700$e,700$a 700$e	
                'Tên liên quan          600,700
                'Xuẩt bản,phát hành:	250$a/250$b. - 260$a:260$b,260$c	
                'Mô tả vật lý:			300$a;300$b		
                'Thông tin tùng thư:	490 (chi tiết đến tất cả trường con)		
                'Tóm tẳt/chú giải: 		520$a

                'Ký hiệu kho:			852$a$b

                'Địa chỉ điện tử và truy cập:	856
                '/****------***/'

                'Type of Material
                'ISBDStr = ISBDStr & "<TR VALIGN='Top'><TD WIDTH='150px'><B> " & ArrTitle(0) & "</B></TD><TD>" & tblMainInfor.Rows(0).Item("TypeName") & "</TD></TR>"
                tblMarc = objBCDBS.ConvertTable(objDOPACItem.GetMARC())
                tblMarc.DefaultView.RowFilter = "FieldCode = 'Ldr'"
                ISBDStr = ISBDStr & "<TR VALIGN='Top'><TD WIDTH='150px'><B> " & ArrTitle(0) & "</B></TD><TD>" & GetRecTypebyLdr(tblMarc.Rows(0).Item("Content"), ArrTitle(18), ArrTitle(19)) & "</TD></TR>"


                'ISBN
                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '020'"
                If tblDetailInfor.DefaultView.Count > 0 Then
                    ISBDStr = ISBDStr & "<TR VALIGN='Top'><TD WIDTH='150px'><B> " & ArrTitle(1) & "  </B></TD> <TD>"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            ISBDStr = ISBDStr & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                        End If
                    Next
                    ISBDStr = Left(ISBDStr, ISBDStr.Length - 1)
                    ISBDStr = ISBDStr & "</TD></TR>"
                End If

                'ISSN
                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '022'"
                If tblDetailInfor.DefaultView.Count > 0 Then
                    ISBDStr = ISBDStr & "<TR VALIGN='Top'><TD WIDTH='150px'><B> " & ArrTitle(2) & "  </B></TD> <TD>"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            ISBDStr = ISBDStr & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                        End If
                    Next
                    ISBDStr = Left(ISBDStr, ISBDStr.Length - 1)
                    ISBDStr = ISBDStr & "</TD></TR>"
                End If

                'Language code
                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '041'"
                For Each rowView In tblDetailInfor.DefaultView
                    If Not IsDBNull(rowView.Item("Content")) Then
                        ISBDStr = ISBDStr & "<TR VALIGN='Top'><TD WIDTH='150px'><B> " & ArrTitle(3) & "</B></TD> <TD>"
                        ISBDStr = ISBDStr & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                        ISBDStr = ISBDStr & "</TD></TR>"
                    End If
                Next

                'Classification
                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '080'"
                If tblDetailInfor.DefaultView.Count > 0 Then
                    ISBDStr = ISBDStr & "<TR VALIGN='Top'><TD WIDTH='150px'><B> " & ArrTitle(4) & "  </B></TD> <TD>"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            ISBDStr = ISBDStr & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                        End If
                    Next
                    ISBDStr = ISBDStr & "</TD></TR>"
                End If
                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '082'"
                If tblDetailInfor.DefaultView.Count > 0 Then
                    ISBDStr = ISBDStr & "<TR VALIGN='Top'><TD WIDTH='150px'><B> " & ArrTitle(5) & "  </B></TD> <TD>"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            ISBDStr = ISBDStr & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                        End If
                    Next
                    ISBDStr = ISBDStr & "</TD></TR>"
                End If
                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '084'"
                If tblDetailInfor.DefaultView.Count > 0 Then
                    ISBDStr = ISBDStr & "<TR VALIGN='Top'><TD WIDTH='150px'><B> " & ArrTitle(6) & "  </B></TD> <TD>"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            ISBDStr = ISBDStr & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                        End If
                    Next
                    ISBDStr = ISBDStr & "</TD></TR>"
                End If

                'Author area
                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '100'"
                If tblDetailInfor.DefaultView.Count > 0 Then
                    ISBDStr = ISBDStr & "<TR VALIGN='Top'><TD WIDTH='150px'><B> " & ArrTitle(7) & "  </B></TD> <TD>"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            ISBDStr = ISBDStr & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                        End If
                    Next
                    ISBDStr = ISBDStr & "</TD></TR>"
                End If
                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '110'"
                If tblDetailInfor.DefaultView.Count > 0 Then
                    ISBDStr = ISBDStr & "<TR VALIGN='Top'><TD WIDTH='150px'><B> " & ArrTitle(8) & " </B></TD> <TD>"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            ISBDStr = ISBDStr & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                        End If
                    Next
                    ISBDStr = ISBDStr & "</TD></TR>"
                End If
                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '700' OR FieldCode = '600'" 'Lap
                If tblDetailInfor.DefaultView.Count > 0 Then
                    ISBDStr = ISBDStr & "<TR VALIGN='Top'><TD WIDTH='150px'><B> " & ArrTitle(9) & " </B></TD> <TD>"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            ISBDStr = ISBDStr & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                        End If
                    Next
                    ISBDStr = Left(ISBDStr, ISBDStr.Length - 1)
                    ISBDStr = ISBDStr & "</TD></TR>"
                End If

                'Title and responsibility area
                ISBDStr = ISBDStr & "<TR VALIGN='Top'><TD WIDTH='150px'><B> " & ArrTitle(10) & " </B></TD> <TD>"
                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '245'"
                For Each rowView In tblDetailInfor.DefaultView
                    If Not IsDBNull(rowView.Item("Content")) Then
                        ISBDStr = ISBDStr & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                    End If
                Next
                ISBDStr = ISBDStr & "</TD></TR>"

                'Edition and Publication area
                Dim strSeparate As String = ""
                ISBDStr = ISBDStr & "<TR VALIGN='Top'><TD WIDTH='150px'><B> " & ArrTitle(11) & "  </B></TD> <TD>"
                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '250'"
                For Each rowView In tblDetailInfor.DefaultView
                    If Not IsDBNull(rowView.Item("Content")) Then
                        ISBDStr = ISBDStr & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                        strSeparate = ". -"
                    End If
                Next
                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '260'"
                For Each rowView In tblDetailInfor.DefaultView
                    If Not IsDBNull(rowView.Item("Content")) Then
                        ISBDStr = ISBDStr & strSeparate & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                    End If
                Next
                ISBDStr = ISBDStr & "</TD></TR>"

                'Physical desrciption area
                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '300'" 'Lap
                If tblDetailInfor.DefaultView.Count > 0 Then
                    ISBDStr = ISBDStr & "<TR VALIGN='Top'><TD WIDTH='150px'><B> " & ArrTitle(12) & "  </B></TD> <TD>"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            ISBDStr = ISBDStr & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "<BR>"
                        End If
                    Next
                    ISBDStr = ISBDStr & "</TD></TR>"
                End If

                'Tung thu
                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '490'" 'Lap
                If tblDetailInfor.DefaultView.Count > 0 Then
                    ISBDStr = ISBDStr & "<TR VALIGN='Top'><TD WIDTH='150px'><B> " & ArrTitle(13) & "  </B></TD> <TD>"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            ISBDStr = ISBDStr & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "<br>"
                        End If
                    Next
                    ISBDStr = ISBDStr & "</TD></TR>"
                End If

                'Note area
                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '520'" 'Lap
                If tblDetailInfor.DefaultView.Count > 0 Then
                    ISBDStr = ISBDStr & "<TR VALIGN='Top'><TD WIDTH='150px'><B> " & ArrTitle(14) & "  </B></TD> <TD>"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            ISBDStr = ISBDStr & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "<BR>"
                        End If
                    Next
                    ISBDStr = ISBDStr & "</TD></TR>"
                End If

                'Additional area: Key word
                tblDetailInfor.DefaultView.RowFilter = "FieldCode = '653' or FieldCode = '655' or  FieldCode = '656' or FieldCode = '657'"
                If tblDetailInfor.DefaultView.Count > 0 Then
                    Dim inti As Integer = 0
                    ISBDStr = ISBDStr & "<TR VALIGN='Top'><TD WIDTH='150px'><B> " & ArrTitle(17) & "  </B></TD> <TD>"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                            inti = inti + 1
                            ISBDStr = ISBDStr & inti & "." & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ". "
                        End If
                    Next 'Loop
                    ISBDStr = ISBDStr & "</TD></TR>"
                End If

                ''Holding infomation
                'tblDetailInfor.DefaultView.RowFilter = "FieldCode = '852'"
                'For Each rowView In tblDetailInfor.DefaultView
                '    If Not IsDBNull(rowView.Item("Content")) Then
                '        ISBDStr = ISBDStr & "<TR VALIGN='Top'><TD WIDTH='150px'><B> " & ArrTitle(12) & "  </B></TD> <TD>"
                '        ISBDStr = ISBDStr & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                '        ISBDStr = ISBDStr & "</TD></TR>"
                '    End If
                'Next

                ''Electrical resource
                'tblDetailInfor.DefaultView.RowFilter = "FieldCode = '856'"
                'For Each rowView In tblDetailInfor.DefaultView
                '    If Not IsDBNull(rowView.Item("Content")) Then
                '        ISBDStr = ISBDStr & "<TR VALIGN='Top'><TD WIDTH='150px'><B> " & ArrTitle(13) & "  </B></TD> <TD>"
                '        ISBDStr = ISBDStr & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                '        ISBDStr = ISBDStr & "</TD></TR>"
                '    End If
                'Next
                ISBDStr = ISBDStr & "</TABLE>"
            End If

            CreateFullCard = ISBDStr
        End Function

        'Creator: PhuongTT
        Private Function CreateFullCardOPAC(ByVal ArrTitle() As String, Optional ByVal strWord As String = "", Optional ByVal strCoverPATH As String = "") As String
            Dim strResult As String = ""
            Try
                Dim intCount As Integer
                Dim i, k, c As Integer, ISBDStr As String, FoundKey, HasSum
                Dim rowMain, rowDetail As DataRow, rowView As DataRowView
                Dim tblMainInfor, tblDetailInfor, tblMarc As DataTable

                objDOPACItem.ItemID = intItemID
                tblMainInfor = objBCDBS.ConvertTable(objDOPACItem.GetItemMainInfor())
                'CoverPicture
                If Not IsDBNull(tblMainInfor.Rows(0).Item("CoverPicture")) AndAlso tblMainInfor.Rows(0).Item("CoverPicture") & "" <> "" Then
                    strURLCoverPicture = strCoverPATH & tblMainInfor.Rows(0).Item("CoverPicture")
                Else
                    strURLCoverPicture = "Images/Imgviet/Books.png"
                End If
                tblDetailInfor = objBCDBS.ConvertTable(objDOPACItem.GetItemDetailInforHighlight(strWord))

                If tblMainInfor.Rows.Count > 0 Then

                    'ISBDStr = "<TABLE WIDTH='100%' BORDER = '0' id='tblRecDetail' class= 'lbLabel'>"

                    'Loại tài liệu:			008
                    'Chỉ số ISBN:			020$a
                    'Chỉ số ISSN:			022$a		
                    'Mã ngôn ngữ:		    041		
                    'Chỉ số phân loại:		Phân loại thập phân bách khoa  	080
                    '                       Phân loại thập phân Dewey        	082
                    '                       Phân loại khác 			084	 
                    'Tác giả                100$a, 110$a
                    'Thông tin nhan đề:		245$a=245$b:245$b/245$c;700$a 700$e,700$a 700$e	
                    'Tên liên quan          600,700
                    'Xuẩt bản,phát hành:	250$a/250$b. - 260$a:260$b,260$c	
                    'Mô tả vật lý:			300$a;300$b		
                    'Thông tin tùng thư:	490 (chi tiết đến tất cả trường con)		
                    'Tóm tẳt/chú giải: 		520$a

                    'Ký hiệu kho:			852$a$b

                    'Địa chỉ điện tử và truy cập:	856
                    '/****------***/'

                    'Type of Material
                    'ISBDStr = ISBDStr & "<TR VALIGN='Top'><TD WIDTH='150px'><B> " & ArrTitle(0) & "</B></TD><TD>" & tblMainInfor.Rows(0).Item("TypeName") & "</TD></TR>"


                    strResult &= "<div class='panel-header'>"
                    strResult &= "<span class='icon-info-2'>&nbsp;</span>" & ArrTitle(22)
                    strResult &= ArrTitle(28)

                    strResult &= "</div>"
                    strResult &= "<div class='panel-content'>"
                    strResult &= "<div class='grid no-margin'>"
                    strResult &= "<div class='row'>"

                    'Cover
                    strResult &= "<div class='span2'>"
                    strResult &= "<div>"
                    strResult &= "<img src='" & strURLCoverPicture & "' class='rounded'>"
                    strResult &= "</div>"
                    strResult &= "</div>" 'Close span2

                    strResult &= "<div class='span7'>"

                    tblMarc = objBCDBS.ConvertTable(objDOPACItem.GetMARC())
                    tblMarc.DefaultView.RowFilter = "FieldCode = 'Ldr'"
                    'ISBDStr = ISBDStr & "<TR VALIGN='Top'><TD WIDTH='150px'><B> " & ArrTitle(0) & "</B></TD><TD>" & GetRecTypebyLdr(tblMarc.Rows(0).Item("Content"), ArrTitle(18), ArrTitle(19)) & "</TD></TR>"
                    strResult &= "<span class='line-height'>"
                    strResult &= "<strong>" & ArrTitle(0) & "</strong> " & GetRecTypebyLdr(tblMarc.Rows(0).Item("Content"), ArrTitle(18), ArrTitle(19))
                    strResult &= "</span>"
                    strResult &= "<br />"


                    'ISBN
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '020'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strResult &= "<span class='line-height'>"
                        strResult &= "<strong>" & ArrTitle(1) & "</strong> "
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) Then
                                strResult &= "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                            End If
                        Next
                        strResult = Left(strResult, strResult.Length - 1)
                        strResult &= "</span>"
                        strResult &= "<br />"
                    End If

                    'ISSN
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '022'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strResult &= "<span class='line-height'>"
                        strResult &= "<strong>" & ArrTitle(2) & "</strong> "
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) Then
                                strResult &= "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                            End If
                        Next
                        strResult = Left(strResult, strResult.Length - 1)
                        strResult &= "</span>"
                        strResult &= "<br />"
                    End If

                    'Language code
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '041'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) Then
                                strResult &= "<span class='line-height'>"
                                strResult &= "<strong>" & ArrTitle(3) & "</strong> "
                                strResult &= "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                                strResult &= "</span>"
                                strResult &= "<br />"
                            End If
                        Next
                    End If


                    'Classification
                    'UDC
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '080'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strResult &= "<span class='line-height'>"
                        strResult &= "<strong>" & ArrTitle(4) & "</strong> "
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) Then
                                strResult &= "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                            End If
                        Next
                        strResult = Left(strResult, strResult.Length - 1)
                        strResult &= "</span>"
                        strResult &= "<br />"
                    End If
                    'DDC
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '082'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strResult &= "<span class='line-height'>"
                        strResult &= "<strong>" & ArrTitle(5) & "</strong> "
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) Then
                                strResult &= "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                            End If
                        Next
                        strResult = Left(strResult, strResult.Length - 1)
                        strResult &= "</span>"
                        strResult &= "<br />"
                    End If
                    'BBK
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '084'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strResult &= "<span class='line-height'>"
                        strResult &= "<strong>" & ArrTitle(6) & "</strong> "
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) Then
                                strResult &= "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                            End If
                        Next
                        strResult = Left(strResult, strResult.Length - 1)
                        strResult &= "</span>"
                        strResult &= "<br />"
                    End If
                    'NLM
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '060'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strResult &= "<span class='line-height'>"
                        strResult &= "<strong>" & ArrTitle(21) & "</strong> "
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) Then
                                strResult &= "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                            End If
                        Next
                        strResult = Left(strResult, strResult.Length - 1)
                        strResult &= "</span>"
                        strResult &= "<br />"
                    End If

                    'Author area
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '100'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strResult &= "<span class='line-height'>"
                        strResult &= "<strong>" & ArrTitle(7) & "</strong> "
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) Then
                                strResult &= "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                            End If
                        Next
                        strResult = Left(strResult, strResult.Length - 1)
                        strResult &= "</span>"
                        strResult &= "<br />"
                    End If
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '110'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strResult &= "<span class='line-height'>"
                        strResult &= "<strong>" & ArrTitle(8) & "</strong> "
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) Then
                                strResult &= "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                            End If
                        Next
                        strResult = Left(strResult, strResult.Length - 1)
                        strResult &= "</span>"
                        strResult &= "<br />"
                    End If
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '700' OR FieldCode = '600'" 'Lap
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strResult &= "<span class='line-height'>"
                        strResult &= "<strong>" & ArrTitle(9) & "</strong> "
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) Then
                                strResult &= "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                            End If
                        Next
                        strResult = Left(strResult, strResult.Length - 1)
                        strResult &= "</span>"
                        strResult &= "<br />"
                    End If

                    'Title and responsibility area
                    strResult &= "<span class='line-height'>"
                    strResult &= "<strong>" & ArrTitle(10) & "</strong> "
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '245'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            strResult = strResult & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                        End If
                    Next
                    strResult &= "</span>"
                    strResult &= "<br />"

                    'Edition and Publication area
                    Dim strSeparate As String = ""
                    strResult &= "<span class='line-height'>"
                    strResult &= "<strong>" & ArrTitle(11) & "</strong> "
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '250'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            strResult = strResult & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                            strSeparate = ". -"
                        End If
                    Next
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '260'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            strResult = strResult & strSeparate & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                        End If
                    Next
                    strResult &= "</span>"
                    strResult &= "<br />"

                    'Physical desrciption area
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '300'" 'Lap
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strResult &= "<span class='line-height'>"
                        strResult &= "<strong>" & ArrTitle(12) & "</strong> "
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) Then
                                strResult &= "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "<BR />"
                            End If
                        Next
                        strResult &= "</span>"
                    End If

                    'Tung thu
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '490'" 'Lap
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strResult &= "<span class='line-height'>"
                        strResult &= "<strong>" & ArrTitle(13) & "</strong> "
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) Then
                                strResult &= "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "<BR />"
                            End If
                        Next
                        strResult &= "</span>"
                        strResult &= "<br />"
                    End If

                    'Note area
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '520'" 'Lap
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strResult &= "<span class='line-height'>"
                        strResult &= "<strong>" & ArrTitle(14) & "</strong> "
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) Then
                                strResult &= "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "<BR />"
                            End If
                        Next
                        strResult &= "</span>"
                        strResult &= "<br />"
                    End If

                    'Additional area: Key word
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '653' or FieldCode = '655' or  FieldCode = '656' or FieldCode = '657'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        Dim inti As Integer = 0
                        strResult &= "<span class='line-height'>"
                        strResult &= "<strong>" & ArrTitle(17) & "</strong> "
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                                inti = inti + 1
                                strResult = strResult & inti & "." & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ". "
                            End If
                        Next
                        strResult &= "</span>"
                        strResult &= "<br />"
                    End If

                    'Additional area: Subject heading
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '650'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        Dim inti As Integer = 0
                        strResult &= "<span class='line-height'>"
                        strResult &= "<strong>" & ArrTitle(20) & "</strong> "
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                                inti = inti + 1
                                strResult = strResult & inti & "." & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ". "
                            End If
                        Next
                        strResult &= "</span>"
                        strResult &= "<br />"
                    End If


                    'Phụ chú luận án -- DH Y DUOC
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '915'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strResult &= "<span class='line-height'>"
                        strResult &= "<strong>" & ArrTitle(27) & "</strong> "
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                                strResult = strResult & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ". "
                            End If
                        Next
                        strResult &= "</span>"
                        strResult &= "<br />"
                    End If


                    'get ETYPE
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode='ETYPE'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strResult &= "<br />"
                        strResult &= "<strong>" & ArrTitle(26) & "</strong> " & tblDetailInfor.DefaultView(0).Item("Content")
                    End If

                    'get URL
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '856'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        Dim strUrl As String = ""
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                                If InStr(rowView.Item("Content"), "http://") > 0 Then
                                    strUrl &= "<a href='" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "' target='_blank' class='lblinkfunction' style='cursor:pointer;'><div class='icon-link'></div>URL</a>; "
                                End If
                            End If
                        Next 'Loop
                        strUrl = strUrl.Trim
                        If strUrl <> "" Then
                            strUrl = strUrl.Substring(0, strUrl.Length - 1)
                            strUrl = Replace(strUrl, "<span style=""background-color:#60a917 !important;color:white;""></span>", "")
                            strUrl = "<strong>" & ArrTitle(23) & "</strong> " & strUrl
                        End If
                        strResult &= "<br />"
                        strResult &= strUrl
                    End If

                    'get EDATA
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode='EDATA'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        Dim strEDATA As String = ""
                        strEDATA = tblDetailInfor.DefaultView(0).Item("Content") & ""
                        Dim strArr() As String = Split(strEDATA, ";")
                        If UBound(strArr) = 3 Then
                            strResult &= "<br />"
                            strResult &= "<strong>" & ArrTitle(24) & "</strong><a href='OViewLoading.aspx?fileType=" & strArr(1) & "&fileId=" & strArr(2) & "&ItemId=" & strArr(3) & "'  TARGET='_parent'>" & strArr(0) & ArrTitle(25) & "</a>"
                        End If
                    End If

                    'Du lieu bao in/tap chi dien tu
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode='EMAGAZINE'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        Dim strEMAGAZINE As String = ""
                        strEMAGAZINE = tblDetailInfor.DefaultView(0).Item("Content") & ""
                        strResult &= "<br/>"
                        strResult &= "<strong>" & ArrTitle(24) & "</strong><a href=""javascript:parent.gotoMagazineList('OMagList.aspx?ItemId=" & intItemID & "')"">" & strEMAGAZINE & ArrTitle(25) & "</a>"
                    End If

                    'get Ranking
                    Dim strRANKING As String = 2
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode='RANKING'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strRANKING = tblDetailInfor.DefaultView(0).Item("Content")
                    End If
                    strResult &= "<br />"
                    strResult &= "<div class='rating  fg-green small' data-role='rating' data-static='true' data-score='" & strRANKING & "'  data-stars='5' data-show-score='false' style='cursor:default;'>"
                    strResult &= "</div>"
                    'End ranking

                    ''Holding infomation
                    'tblDetailInfor.DefaultView.RowFilter = "FieldCode = '852'"
                    'For Each rowView In tblDetailInfor.DefaultView
                    '    If Not IsDBNull(rowView.Item("Content")) Then
                    '        ISBDStr = ISBDStr & "<TR VALIGN='Top'><TD WIDTH='150px'><B> " & ArrTitle(12) & "  </B></TD> <TD>"
                    '        ISBDStr = ISBDStr & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                    '        ISBDStr = ISBDStr & "</TD></TR>"
                    '    End If
                    'Next

                    ''Electrical resource
                    'tblDetailInfor.DefaultView.RowFilter = "FieldCode = '856'"
                    'For Each rowView In tblDetailInfor.DefaultView
                    '    If Not IsDBNull(rowView.Item("Content")) Then
                    '        ISBDStr = ISBDStr & "<TR VALIGN='Top'><TD WIDTH='150px'><B> " & ArrTitle(13) & "  </B></TD> <TD>"
                    '        ISBDStr = ISBDStr & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                    '        ISBDStr = ISBDStr & "</TD></TR>"
                    '    End If
                    'Next

                    strResult &= "</div>" 'div span7
                    strResult &= "</div>" 'div grid no-margin
                    strResult &= "</div>" 'div row
                    strResult &= "</div>" 'div panel-content
                End If
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        'Creator: PhuongTT
        Private Function CreateFullCardOPAC_SSC(ByVal ArrTitle() As String, Optional ByVal strWord As String = "", Optional ByVal strCoverPATH As String = "", Optional ByVal strUser As String = "") As String
            Dim strResult As String = ""
            Try
                Dim intCount As Integer
                Dim i, k, c As Integer, ISBDStr As String, FoundKey, HasSum
                Dim rowMain, rowDetail As DataRow, rowView As DataRowView
                Dim tblMainInfor, tblDetailInfor, tblMarc As DataTable

                objDOPACItem.ItemID = intItemID
                tblMainInfor = objBCDBS.ConvertTable(objDOPACItem.GetItemMainInfor())
                'CoverPicture
                If Not IsDBNull(tblMainInfor.Rows(0).Item("CoverPicture")) AndAlso tblMainInfor.Rows(0).Item("CoverPicture") & "" <> "" Then
                    strURLCoverPicture = strCoverPATH & tblMainInfor.Rows(0).Item("CoverPicture")
                Else
                    strURLCoverPicture = "Images/Imgviet/Books.png"
                End If
                tblDetailInfor = objBCDBS.ConvertTable(objDOPACItem.GetItemDetailInforHighlight(strWord))

                If tblMainInfor.Rows.Count > 0 Then

                    'ISBDStr = "<TABLE WIDTH='100%' BORDER = '0' id='tblRecDetail' class= 'lbLabel'>"

                    'Loại tài liệu:			008
                    'Chỉ số ISBN:			020$a
                    'Chỉ số ISSN:			022$a		
                    'Mã ngôn ngữ:		    041		
                    'Chỉ số phân loại:		Phân loại thập phân bách khoa  	080
                    '                       Phân loại thập phân Dewey        	082
                    '                       Phân loại khác 			084	 
                    'Tác giả                100$a, 110$a
                    'Thông tin nhan đề:		245$a=245$b:245$b/245$c;700$a 700$e,700$a 700$e	
                    'Tên liên quan          600,700
                    'Xuẩt bản,phát hành:	250$a/250$b. - 260$a:260$b,260$c	
                    'Mô tả vật lý:			300$a;300$b		
                    'Thông tin tùng thư:	490 (chi tiết đến tất cả trường con)		
                    'Tóm tẳt/chú giải: 		520$a

                    'Ký hiệu kho:			852$a$b

                    'Địa chỉ điện tử và truy cập:	856
                    '/****------***/'

                    'Type of Material
                    'ISBDStr = ISBDStr & "<TR VALIGN='Top'><TD WIDTH='150px'><B> " & ArrTitle(0) & "</B></TD><TD>" & tblMainInfor.Rows(0).Item("TypeName") & "</TD></TR>"


                    'strResult &= "<div class='panel-header'>"
                    'strResult &= "<span class='icon-info-2'>&nbsp;</span>" & ArrTitle(22)
                    'strResult &= ArrTitle(28)

                    'strResult &= "</div>"
                    'strResult &= "<div class='panel-content'>"
                    'strResult &= "<div class='grid no-margin'>"
                    'strResult &= "<div class='row'>"

                    ''Cover
                    'strResult &= "<div class='span2'>"
                    'strResult &= "<div>"
                    'strResult &= "<img src='" & strURLCoverPicture & "' class='rounded'>"
                    'strResult &= "</div>"
                    'strResult &= "</div>" 'Close span2

                    'strResult &= "<div class='span7'>"

                    'tblMarc = objBCDBS.ConvertTable(objDOPACItem.GetMARC())
                    'tblMarc.DefaultView.RowFilter = "FieldCode = 'Ldr'"
                    ''ISBDStr = ISBDStr & "<TR VALIGN='Top'><TD WIDTH='150px'><B> " & ArrTitle(0) & "</B></TD><TD>" & GetRecTypebyLdr(tblMarc.Rows(0).Item("Content"), ArrTitle(18), ArrTitle(19)) & "</TD></TR>"
                    'strResult &= "<span class='line-height'>"
                    'strResult &= "<strong>" & ArrTitle(0) & "</strong> " & GetRecTypebyLdr(tblMarc.Rows(0).Item("Content"), ArrTitle(18), ArrTitle(19))
                    'strResult &= "</span>"
                    'strResult &= "<br />"

                    'strResult &= "<h3 class='HeadStyles'>" & ArrTitle(22) & ArrTitle(28) & "</h3>"
                    strResult &= "<h3 class='HeadStyles'>" & ArrTitle(22) & "</h3>"
                    strResult &= "<div class='ClearFix'>"

                    strResult &= "<div class='col-left-2'>"
                    strResult &= "<div class='modul-img'>"
                    strResult &= "<img src='" & strURLCoverPicture & "'>"
                    strResult &= "</div>"

                    'get Ranking
                    Dim strRANKING As String = 2
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode='RANKING'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strRANKING = tblDetailInfor.DefaultView(0).Item("Content")
                    End If
                    'strResult &= "<div class=""info-star"">"
                    'Try
                    '    For kk As Integer = 1 To CInt(strRANKING)
                    '        If kk = 1 Then
                    '            strResult &= "<span class=""icon-star-4""></span>"
                    '        Else
                    '            strResult &= "<span class=""icon-star-3""></span>"
                    '        End If
                    '    Next
                    '    For kk As Integer = 5 To CInt(strRANKING) + 1 Step -1
                    '        strResult &= "<span class=""icon-star""></span>"
                    '    Next
                    'Catch ex As Exception
                    'End Try
                    'strResult &= "</div>"
                    'strResult &= "<div style=""vertical-align:top;text-align:center"" class=""rating"" data-role=""rating"" data-value=""" & strRANKING & """ data-static=""true"" data-show-score=""false""></div>"

                    'get EDATA
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode='EDATA'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        Dim strEDATA As String = ""
                        strEDATA = tblDetailInfor.DefaultView(0).Item("Content") & ""
                        Dim strArr() As String = Split(strEDATA, ";")
                        If UBound(strArr) = 3 Then
                            'strResult &= "<strong>" & ArrTitle(24) & "</strong><a href='OViewLoading.aspx?fileType=" & strArr(1) & "&fileId=" & strArr(2) & "&ItemId=" & strArr(3) & "'  TARGET='_parent'>" & strArr(0) & ArrTitle(25) & "</a>"
                            strResult &= "<a class=""btn-read"" href='OViewLoading.aspx?fileType=" & strArr(1) & "&fileId=" & strArr(2) & "&ItemId=" & strArr(3) & "'  TARGET='_parent'>" & strArr(0) & ArrTitle(25) & "</a>"
                        End If
                    End If

                    'Du lieu bao in/tap chi dien tu
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode='EMAGAZINE'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        Dim strEMAGAZINE As String = ""
                        strEMAGAZINE = tblDetailInfor.DefaultView(0).Item("Content") & ""
                        'strResult &= "<br/>"
                        'strResult &= "<strong>" & ArrTitle(24) & "</strong><a href=""javascript:parent.gotoMagazineList('OMagList.aspx?ItemId=" & intItemID & "')"">" & strEMAGAZINE & ArrTitle(25) & "</a>"
                        'strResult &= "<a class=""btn-read"" href=""javascript:parent.gotoMagazineList('OMagList.aspx?ItemId=" & intItemID & "')"">" & strEMAGAZINE & ArrTitle(25) & "</a>"
                        strResult &= "<a class=""btn-read"" href='OMagList.aspx?ItemId=" & intItemID & "' TARGET='_parent'>" & strEMAGAZINE & ArrTitle(25) & "</a>"
                    End If

                    strResult &= "</div>" 'close col-left-2
                    strResult &= "<div class=""col-right-8"">"
                    strResult &= "<ul>"

                    'ISSN
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '022'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strResult &= "<li><span>"
                        strResult &= ArrTitle(2)
                        strResult &= "</span>"
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) Then
                                strResult &= "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                            End If
                        Next
                        strResult = Left(strResult, strResult.Length - 1)
                        strResult &= "</li>"
                    End If

                    'Classification
                    'UDC
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '080'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        'strResult &= "<span class='line-height'>"
                        'strResult &= "<strong>" & ArrTitle(4) & "</strong> "
                        strResult &= "<li><span>"
                        strResult &= ArrTitle(4)
                        strResult &= "</span>"
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) Then
                                strResult &= "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                            End If
                        Next
                        strResult = Left(strResult, strResult.Length - 1)
                        strResult &= "</li>"
                    End If

                    'BBK
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '084'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strResult &= "<li><span>"
                        strResult &= ArrTitle(6)
                        strResult &= "</span>"
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) Then
                                strResult &= "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                            End If
                        Next
                        strResult = Left(strResult, strResult.Length - 1)
                        strResult &= "</li>"
                    End If
                    'NLM
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '060'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strResult &= "<li><span>"
                        strResult &= ArrTitle(21)
                        strResult &= "</span>"
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) Then
                                strResult &= "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                            End If
                        Next
                        strResult = Left(strResult, strResult.Length - 1)
                        strResult &= "</li>"
                    End If

                    'tblDetailInfor.DefaultView.RowFilter = "FieldCode = '110'"
                    'If tblDetailInfor.DefaultView.Count > 0 Then
                    '    strResult &= "<li><span>"
                    '    strResult &= ArrTitle(8)
                    '    strResult &= "</span>"
                    '    For Each rowView In tblDetailInfor.DefaultView
                    '        If Not IsDBNull(rowView.Item("Content")) Then
                    '            strResult &= "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                    '        End If
                    '    Next
                    '    strResult = Left(strResult, strResult.Length - 1)
                    '    strResult &= "</li>"
                    'End If
                    'tblDetailInfor.DefaultView.RowFilter = "FieldCode = '700' OR FieldCode = '600'" 'Lap
                    'If tblDetailInfor.DefaultView.Count > 0 Then
                    '    strResult &= "<li><span>"
                    '    strResult &= ArrTitle(9)
                    '    strResult &= "</span>"
                    '    For Each rowView In tblDetailInfor.DefaultView
                    '        If Not IsDBNull(rowView.Item("Content")) Then
                    '            strResult &= "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                    '        End If
                    '    Next
                    '    strResult = Left(strResult, strResult.Length - 1)
                    '    strResult &= "</li>"
                    'End If

                    'Title and responsibility area
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '245'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strResult &= "<li><span>"
                        strResult &= ArrTitle(10)
                        strResult &= "</span>"
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) Then
                                Dim content245 As String = rowView.Item("Content")

                                Dim split() As String = content245.Split("$")
                                If (split.Length > 1) Then
                                    If (content245.Contains("$c")) Then
                                        Dim tmpResult As String = ""
                                        For j As Integer = 0 To split.Length - 1
                                            If (Not (String.IsNullOrEmpty(split(j)))) Then
                                                If Not (split(j)(0) = "c") Then
                                                    tmpResult = tmpResult & "$" & split(j)
                                                End If
                                            End If
                                        Next
                                        tmpResult = tmpResult.Trim()
                                        If (tmpResult(0) = "$" AndAlso tmpResult(1) = "<") Then
                                            strResult &= "" & objBCSP.GEntryTrim(objBCSP.TrimSubFieldCodes(tmpResult.Substring(1)))
                                        Else
                                            strResult &= "" & objBCSP.GEntryTrim(objBCSP.TrimSubFieldCodes(tmpResult))
                                        End If
                                    Else
                                        strResult &= "" & objBCSP.GEntryTrim(objBCSP.TrimSubFieldCodes(rowView.Item("Content")))
                                    End If
                                End If

                                'Dim split() As String = content245.Split("$")
                                'If (split.Length > 1) Then
                                '    If (content245.Contains("$a")) Then
                                '        Dim tmpResult As String = ""
                                '        If split.Length = 2 Then
                                '            tmpResult = tmpResult & split(0) & "$" & split(1)
                                '        Else
                                '            tmpResult = tmpResult & split(0) & "$" & split(1).Substring(0, split(1).Length - 2)
                                '        End If
                                '        tmpResult = tmpResult.Trim()
                                '        strResult &= "" & objBCSP.TrimSubFieldCodes(tmpResult) & ","
                                '    Else
                                '        strResult &= "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                                '    End If
                                'Else
                                '    strResult &= "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                                'End If
                            End If
                        Next
                        strResult = strResult.Trim()
                        strResult &= "</li>"
                    End If

                    'Author area
                    'tblDetailInfor.DefaultView.RowFilter = "FieldCode = '100'"
                    'If tblDetailInfor.DefaultView.Count > 0 Then
                    '    strResult &= "<li><span>"
                    '    strResult &= ArrTitle(7)
                    '    strResult &= "</span>"
                    '    For Each rowView In tblDetailInfor.DefaultView
                    '        If Not IsDBNull(rowView.Item("Content")) Then
                    '            strResult &= "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                    '        End If
                    '    Next
                    '    strResult = Left(strResult, strResult.Length - 1)
                    '    strResult &= "</li>"
                    'End If
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '245'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        Dim tmpResult As String = ""
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) Then
                                Dim content245 As String = rowView.Item("Content")

                                Dim split() As String = content245.Split("$")
                                If (split.Length > 1) Then
                                    If (content245.Contains("$c")) Then
                                        For j As Integer = 0 To split.Length - 1
                                            If (Not (String.IsNullOrEmpty(split(j)))) Then
                                                If (split(j)(0) = "c") Then
                                                    tmpResult = tmpResult & "$" & split(j)
                                                End If
                                            End If
                                        Next
                                        tmpResult = tmpResult.Trim()
                                    End If
                                End If
                            End If
                        Next

                        If Not tmpResult = "" Then
                            strResult &= "<li><span>"
                            strResult &= ArrTitle(7)
                            strResult &= "</span>"

                            strResult &= "" & objBCSP.GEntryTrim(objBCSP.TrimSubFieldCodes(tmpResult))

                            strResult = Left(strResult, strResult.Length)
                            strResult &= "</li>"
                        End If


                    End If

                    'DDC
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '082'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strResult &= "<li><span>"
                        strResult &= ArrTitle(5)
                        strResult &= "</span>"
                        For Each rowView In tblDetailInfor.DefaultView

                            If Not IsDBNull(rowView.Item("Content")) Then
                                Dim content082 As String = rowView.Item("Content")
                                Dim split() As String = content082.Split("$")
                                If (split.Length > 1) Then
                                    Dim tmpResult As String = ""
                                    For Each strItem As String In split
                                        If strItem(0) = "a" Then
                                            tmpResult = objBCSP.TrimSubFieldCodes(strItem.Substring(1).Trim())
                                        End If
                                        If strItem(0) = "b" Then
                                            If tmpResult <> "" Then
                                                tmpResult = tmpResult & "/" & objBCSP.TrimSubFieldCodes(strItem.Substring(1).Trim())
                                            Else
                                                tmpResult = objBCSP.TrimSubFieldCodes(strItem.Substring(1).Trim())
                                            End If
                                        End If
                                    Next
                                    strResult &= tmpResult & ","
                                    'If (content082.Contains("$b")) Then
                                    '    Dim tmpResult As String = ""
                                    '    For index As Integer = 0 To split.Length - 2
                                    '        If Not (String.IsNullOrEmpty(split(index))) AndAlso Not (split(index)(0) = "b") Then
                                    '            tmpResult = tmpResult & split(index) & "$"
                                    '        End If
                                    '    Next
                                    '    tmpResult = tmpResult.Substring(0, tmpResult.Length - 2).Trim()
                                    '    strResult &= "" & objBCSP.TrimSubFieldCodes(tmpResult) & ","
                                    'Else
                                    '    strResult &= "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                                    'End If
                                Else
                                    strResult &= "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ","
                                End If
                            End If
                        Next
                        strResult = Left(strResult, strResult.Length - 1)
                        strResult &= "</li>"
                    End If

                    'Edition and Publication area
                    Dim strSeparate As String = ""
                    strResult &= "<li><span>"
                    strResult &= ArrTitle(11)
                    strResult &= "</span>"
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '250'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            strResult = strResult & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                            strSeparate = ". -"
                        End If
                    Next
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '260'"
                    For Each rowView In tblDetailInfor.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            strResult = strResult & strSeparate & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                        End If
                    Next
                    strResult &= "</li>"

                    'Physical desrciption area
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '300'" 'Lap
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strResult &= "<li><span>"
                        strResult &= ArrTitle(12)
                        strResult &= "</span>"
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) Then
                                strResult &= "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & " " '<BR />
                            End If
                        Next
                        strResult &= "</li>"
                    End If

                    'Tung thu
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '490'" 'Lap
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strResult &= "<li><span>"
                        strResult &= ArrTitle(13)
                        strResult &= "</span>"
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) Then
                                strResult &= "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "<BR />"
                            End If
                        Next
                        strResult &= "</li>"
                    End If

                    'Note area
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '520'" 'Lap
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strResult &= "<li><span>"
                        strResult &= ArrTitle(14)
                        strResult &= "</span>"
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) Then
                                strResult &= "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "<BR />"
                            End If
                        Next
                        strResult &= "</li>"
                    End If

                    'Additional area: Key word
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '653' or FieldCode = '655' or  FieldCode = '656' or FieldCode = '657'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        Dim inti As Integer = 0
                        strResult &= "<li><span>"
                        strResult &= ArrTitle(17)
                        strResult &= "</span>"
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                                inti = inti + 1
                                strResult = strResult & inti & "." & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ". "
                            End If
                        Next
                        strResult &= "</li>"
                    End If

                    'Additional area: Subject heading
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '650'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        Dim inti As Integer = 0
                        strResult &= "<li><span>"
                        strResult &= ArrTitle(20)
                        strResult &= "</span>"
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                                inti = inti + 1
                                strResult = strResult & inti & "." & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ". "
                            End If
                        Next
                        strResult &= "</li>"
                    End If


                    'Phụ chú luận án -- DH Y DUOC
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '915'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strResult &= "<li><span>"
                        strResult &= ArrTitle(27)
                        strResult &= "</span>"
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                                strResult = strResult & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ". "
                            End If
                        Next
                        strResult &= "</li>"
                    End If


                    'get ETYPE
                    'tblDetailInfor.DefaultView.RowFilter = "FieldCode='ETYPE'"
                    'If tblDetailInfor.DefaultView.Count > 0 Then
                    '    'strResult &= "<br />"
                    '    'strResult &= "<strong>" & ArrTitle(26) & "</strong> " & tblDetailInfor.DefaultView(0).Item("Content")

                    '    strResult &= "<li><span>"
                    '    strResult &= ArrTitle(26)
                    '    strResult &= "</span>"
                    '    strResult &= tblDetailInfor.DefaultView(0).Item("Content")
                    '    strResult &= "</li>"
                    'End If

                    'ISBN
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '020'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        Dim tmpResult As String = ""
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) Then
                                Dim content020 As String = rowView.Item("Content")
                                Dim split() As String = content020.Split("$")
                                If (split.Length > 1) Then
                                    For index As Integer = 0 To split.Length - 1
                                        If (split(index)(0) = "a") Then
                                            'tmpResult = split(0) & split(index).Trim()
                                            tmpResult = split(0) & objBCSP.killCharsProcessVal(split(index).Substring(1).Trim())
                                            Exit For
                                        End If
                                    Next
                                End If
                            End If
                        Next
                        If (Not (String.IsNullOrEmpty(tmpResult))) Then
                            strResult &= "<li><span>"
                            strResult &= ArrTitle(1)
                            strResult &= "</span>"
                            strResult &= "" & objBCSP.TrimSubFieldCodes(tmpResult) & ","
                            strResult = Left(strResult, strResult.Length - 1)
                            strResult &= "</li>"
                        End If
                    End If

                    'Gia tien
                    'tblDetailInfor.DefaultView.RowFilter = "FieldCode = '020'"
                    'If tblDetailInfor.DefaultView.Count > 0 Then
                    '    Dim tmpResult As String = ""
                    '    For Each rowView In tblDetailInfor.DefaultView
                    '        If Not IsDBNull(rowView.Item("Content")) Then
                    '            Dim content020 As String = rowView.Item("Content")
                    '            Dim split() As String = content020.Split("$")
                    '            If (split.Length > 1) Then
                    '                For index As Integer = 0 To split.Length - 1
                    '                    If (split(index)(0) = "c") Then
                    '                        tmpResult = split(0) & split(index).Substring(1).Trim()
                    '                        Exit For
                    '                    End If
                    '                Next
                    '            End If
                    '        End If
                    '    Next
                    '    If (Not (String.IsNullOrEmpty(tmpResult))) Then
                    '        strResult &= "<li><span>"
                    '        strResult &= ArrTitle(28)
                    '        strResult &= "</span>"
                    '        strResult &= "" & objBCSP.TrimSubFieldCodes(tmpResult) & ","
                    '        strResult = Left(strResult, strResult.Length - 1)
                    '        strResult &= "</li>"
                    '    End If
                    'End If

                    'Language code
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '041'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        strResult &= "<li><span>"
                        strResult &= ArrTitle(3)
                        strResult &= "</span>"
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) Then
                                'strResult &= "<span class='line-height'>"
                                'strResult &= "<strong>" & ArrTitle(3) & "</strong> "

                                'strResult &= "</span>"
                                'strResult &= "<br />"
                                strResult &= "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                            End If
                        Next
                        strResult &= "</li>"
                    End If

                    'get URL
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '856'"
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        Dim strUrl As String = ""
                        For Each rowView In tblDetailInfor.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) And Trim(rowView.Item("Content")) <> "" Then
                                If InStr(rowView.Item("Content"), "http://") > 0 Then
                                    strUrl &= "<a href='" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & "' target='_blank' class='lblinkfunction' style='cursor:pointer;'><div class='icon-link'></div>URL</a>; "
                                End If
                            End If
                        Next 'Loop
                        strUrl = strUrl.Trim
                        If strUrl <> "" Then
                            strUrl = strUrl.Substring(0, strUrl.Length - 1)
                            strUrl = Replace(strUrl, "<span class=""hightlight-text""></span>", "")
                            strUrl = Replace(strUrl, "<span class=""""hightlight-text""""></span>", "")
                            'strUrl = "<strong>" & ArrTitle(23) & "</strong> " & strUrl

                            strResult &= "<li><span>"
                            strResult &= ArrTitle(23)
                            strResult &= "</span>"
                            strUrl = strUrl
                            strResult &= "</li>"
                        End If
                        strResult &= "<br />"
                        strResult &= strUrl
                    End If

                    Dim bIsDownLoad As Boolean = False

                    Me.ItemID = intItemID
                    Dim tblTmp As DataTable = Me.GetAccessLevel()

                    If (Not IsNothing(tblTmp)) Then
                        If tblTmp.Rows.Count = 1 Then
                            Dim strAccessLevel As String = tblTmp.Rows(0).Item(0).ToString()
                            If (strAccessLevel = "0") Then
                                bIsDownLoad = True
                            End If
                        End If
                    End If

                    If bIsDownLoad = True Then
                        objBItemDissertation.ItemID = intItemID
                        Dim tblYear As DataTable = objBItemDissertation.GetItemDissertationYear()
                        If (Not IsNothing(tblYear)) AndAlso (tblYear.Rows.Count > 0) Then
                            strResult &= "<li><span style='color:red'>"
                            strResult &= ArrTitle(25)
                            strResult &= "</span>"
                            strResult &= "<ul style='display: inline-grid;'>"
                            For Each rowYear As DataRow In tblYear.Rows
                                strResult &= "<li onclick=""OpenNumberByYear('" & rowYear.Item("Year").ToString() & "')"">"
                                strResult &= "<label>" & rowYear.Item("Year").ToString() & "</label>"
                                strResult &= "<div id='year-" & rowYear.Item("Year").ToString() & "' class='dissertation-close'>"
                                objBItemDissertation.Year = CInt(rowYear.Item("Year").ToString())
                                Dim tblNumber As DataTable = objBItemDissertation.GetItemDissertationNumber()
                                If (Not IsNothing(tblNumber)) AndAlso (tblNumber.Rows.Count > 0) Then
                                    strResult &= "<ul style='display: inline-grid;'>"
                                    'If Not String.IsNullOrEmpty(strUser) Then
                                    '    For Each rowNumber As DataRow In tblNumber.Rows
                                    '        strResult &= "<li>"
                                    '        strResult &= "<label>" & rowNumber.Item("Number").ToString() & "</label>"
                                    '        strResult &= "_____<a href='OViewImage.aspx?intItemId=" & rowNumber.Item("ItemId").ToString() & "&intYear=" & rowNumber.Item("Year").ToString() & "&strNumber=" & rowNumber.Item("Number").ToString() & "' target='_blank'>[xem ảnh bìa]</a>"
                                    '        strResult &= "_____<a href='ODownloadFile.aspx?intItemId=" & rowNumber.Item("ItemId").ToString() & "&intYear=" & rowNumber.Item("Year").ToString() & "&strNumber=" & rowNumber.Item("Number").ToString() & "' target='_blank'>[File nội dung]</a>"
                                    '        strResult &= "</li>"
                                    '    Next
                                    'Else
                                    '    For Each rowNumber As DataRow In tblNumber.Rows
                                    '        strResult &= "<li>"
                                    '        strResult &= "<label>" & rowNumber.Item("Number").ToString() & "</label>"
                                    '        strResult &= "_____<a href='OViewImage.aspx?intItemId=" & rowNumber.Item("ItemId").ToString() & "&intYear=" & rowNumber.Item("Year").ToString() & "&strNumber=" & rowNumber.Item("Number").ToString() & "' target='_blank'>[xem ảnh bìa]</a>"
                                    '        strResult &= "</li>"
                                    '    Next
                                    'End If
                                    For Each rowNumber As DataRow In tblNumber.Rows
                                        strResult &= "<li>"
                                        strResult &= "<label>" & rowNumber.Item("Number").ToString() & "</label>"
                                        strResult &= "_____<a href='OViewImage.aspx?intItemId=" & rowNumber.Item("ItemId").ToString() & "&intYear=" & rowNumber.Item("Year").ToString() & "&strNumber=" & rowNumber.Item("Number").ToString() & "' target='_blank'>[xem ảnh bìa]</a>"
                                        strResult &= "_____<a href='ODownloadFile.aspx?intItemId=" & rowNumber.Item("ItemId").ToString() & "&intYear=" & rowNumber.Item("Year").ToString() & "&strNumber=" & rowNumber.Item("Number").ToString() & "' target='_blank'>[File nội dung]</a>"
                                        strResult &= "</li>"
                                    Next
                                    strResult &= "</ul>"
                                End If
                                strResult &= "</div>"
                                strResult &= "</li>"
                            Next
                            strResult &= "</ul>"
                            strResult &= "</li>"
                        End If
                    End If



                    'End ranking

                    ''Holding infomation
                    'tblDetailInfor.DefaultView.RowFilter = "FieldCode = '852'"
                    'For Each rowView In tblDetailInfor.DefaultView
                    '    If Not IsDBNull(rowView.Item("Content")) Then
                    '        ISBDStr = ISBDStr & "<TR VALIGN='Top'><TD WIDTH='150px'><B> " & ArrTitle(12) & "  </B></TD> <TD>"
                    '        ISBDStr = ISBDStr & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                    '        ISBDStr = ISBDStr & "</TD></TR>"
                    '    End If
                    'Next

                    ''Electrical resource
                    'tblDetailInfor.DefaultView.RowFilter = "FieldCode = '856'"
                    'For Each rowView In tblDetailInfor.DefaultView
                    '    If Not IsDBNull(rowView.Item("Content")) Then
                    '        ISBDStr = ISBDStr & "<TR VALIGN='Top'><TD WIDTH='150px'><B> " & ArrTitle(13) & "  </B></TD> <TD>"
                    '        ISBDStr = ISBDStr & "" & objBCSP.TrimSubFieldCodes(rowView.Item("Content")) & ""
                    '        ISBDStr = ISBDStr & "</TD></TR>"
                    '    End If
                    'Next
                    strResult &= "</ul>"
                    strResult &= "</div>" 'col-right-8
                    strResult &= "</div>" 'ClearFix
                End If
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        Private Function GetRecTypebyLdr(ByVal strLdr As String, ByVal strBookText As String, ByVal strSerialText As String) As String
            Dim inti As Integer
            Dim strReturn As String
            Dim ItemCode As String
            Dim SubItemCode As String
            Dim dtrow As DataRow
            Dim tblRecordType As DataTable

            ItemCode = strLdr.Substring(6, 1)
            tblRecordType = objBCDBS.ConvertTable(objDOPACItem.GetRecordTypes())
            If ItemCode <> "" Then
                For Each dtrow In tblRecordType.Rows
                    If ItemCode = dtrow.Item("Code") Then
                        strReturn = dtrow.Item("Description")
                        If ItemCode = "a" Then
                            SubItemCode = strLdr.Substring(7, 1)
                            Select Case SubItemCode
                                Case "a", "c", "d", "m"
                                    strReturn = strReturn & " (" & strBookText & ")"
                                Case "b", "s"
                                    strReturn = strReturn & " (" & strSerialText & ")"
                            End Select
                        End If
                    End If
                Next
            End If
            GetRecTypebyLdr = strReturn

        End Function

        ' purpose : Get Prefix of string
        Private Function GetPrefix(ByVal strIn As String) As String
            Dim intLen As Integer
            intLen = Len(strIn)
            Do While intLen > 1
                If IsNumeric(Mid(strIn, intLen, 1)) Then
                    intLen = intLen - 1
                Else
                    Exit Do
                End If
            Loop
            GetPrefix = Left(strIn, intLen)
        End Function

        ' purpose : append string
        Private Function AppendHolds(ByVal intStart As String, ByVal intCur As String) As String
            Dim strRet As String = ""
            Dim intCount As Integer = 1
            If intCur > intStart Then
                Do While intCount <= Len(intStart)
                    If Mid(intStart, intCount, 1) = Mid(intCur, intCount, 1) Then
                        intCount = intCount + 1
                    Else
                        Exit Do
                    End If
                Loop
                strRet = "-" & Right(intCur, Len(intCur) - intCount + 1)
            End If
            AppendHolds = strRet
        End Function

        ' purpose : Get holding informaion
        ' OUT : string
        ' Creator : dgsoft
        Public Function GetHoldingInfor(ByVal strSerID As String, ByVal strFree As String, ByVal strBusy As String, ByVal strViewMap As String, Optional ByRef strMXGFee As String = "", Optional ByRef strItemCheckOut As String = "") As String
            Dim tblHolding As New DataTable
            Dim strCurLib As String = ""
            Dim strCurLoc As String = ""
            Dim strLoc As String = ""
            Dim strCopyNumber As String
            Dim strShelf As String
            Dim strLocID As String
            Dim rowView As DataRowView
            Dim intCount As Integer

            Dim strRet As String = ""

            strCurLib = ""
            strCurLoc = "@@"
            If IsNumeric(strSerID) Then
                tblHolding = Me.GetHolding(CInt(strSerID))
            Else
                tblHolding = Me.GetHolding
            End If
            If tblHolding.Rows.Count > 0 Then
                blnHaveCopy = True
            Else
                lngAvailItems = 0
            End If

            Dim groupSymbol As New List(Of String)
            Dim countItemInGroup As New List(Of Integer)
            Dim strResultAddList As List(Of String)

            Dim tmpTable As New DataTable("tmlTable")
            tmpTable.Columns.Add("symbol")
            tmpTable.Columns.Add("strResultCopyNumber")


            Dim tmpHolding As DataTable = tblHolding

            If (tmpHolding.Rows.Count > 0) Then
                groupSymbol = tmpHolding.Select().AsEnumerable().GroupBy(Function(x) x.Item("Symbol").ToString()).Select(Function(x) x.Key).ToList()
                For init As Integer = 0 To groupSymbol.Count - 1
                    Dim strResultAdd As String = ""
                    Dim dv As DataView = tblHolding.DefaultView
                    dv.RowFilter = "Symbol='" & groupSymbol(init) & "'"
                    countItemInGroup.Add(dv.Count)

                    Dim codeTemp As String = dv.Item(0).Item("Code")
                    Dim symbol As String = dv.Item(0).Item("Symbol")

                    strShelf = CStr(dv.Item(0).Item("Shelf") & "")

                    strResultAdd = strResultAdd & "<p><span>" & codeTemp & " : " & If(symbol <> "", "Kho " & symbol, "") & "</span> Hiện có: " & dv.Count & "</p>"
                    strResultAdd = strResultAdd & "<p>" & ConcatHolding(dv, strShelf) & "</p>"

                    Dim tmpRow As DataRow = tmpTable.NewRow()
                    tmpRow.Item("symbol") = symbol
                    tmpRow.Item("strResultCopyNumber") = strResultAdd
                    tmpTable.Rows.Add(tmpRow)
                Next
            End If


            'strShelf = CStr(tblHolding.DefaultView.Item(0).Item("Shelf") & "")
            'strCopyNumber = ConcatHolding(tblHolding.DefaultView, strShelf)

            lngTotalItems = tblHolding.Rows.Count
            tblHolding.DefaultView.RowFilter = "InUsed = 0 AND Acquired = 1 AND InCirculation = 1"
            lngAvailItems = tblHolding.DefaultView.Count
            lngHoldItems = Me.GetTotalHoldRequest

            For intCount = 0 To tblHolding.Rows.Count - 1
                If tblHolding.Rows(intCount).Item("Code") & "" <> strCurLib Then
                    strCurLib = tblHolding.Rows(intCount).Item("Code")
                    strCurLoc = "@@"
                End If
                If tblHolding.Rows(intCount).Item("Symbol") & "" <> strCurLoc Then
                    strCurLoc = tblHolding.Rows(intCount).Item("Symbol")

                    For Each rowTmp As DataRow In tmpTable.Rows
                        If (rowTmp.Item("symbol").ToString() = tblHolding.Rows(intCount).Item("Symbol").ToString()) Then
                            strRet = strRet & rowTmp.Item("strResultCopyNumber").ToString()
                            Exit For
                        End If
                    Next

                    strRet &= "<p>"
                    strRet &= "<span>" & strCurLib & ": " & If(strCurLoc <> "", "Kho " & strCurLoc, "") & "</span>"
                    If IsDBNull(tblHolding.Rows(intCount).Item("Symbol")) Then
                        strLoc = "NULL"
                    Else
                        strLoc = "'" & tblHolding.Rows(intCount).Item("Symbol") & "'"
                    End If
                    tblHolding.DefaultView.RowFilter = "Code='" & strCurLib & "' AND Symbol=" & strLoc & " AND InCirculation=1"
                    If tblHolding.DefaultView.Count > 0 Then
                        blnLocked = False
                        tblHolding.DefaultView.RowFilter = "Code='" & strCurLib & "' AND Symbol=" & strLoc & " AND InCirculation=1 AND InUsed = 0 AND Acquired=1"
                        If tblHolding.DefaultView.Count > 0 Then
                            blnAvail = True

                            strRet = strRet & " [ " & strFree & " ]: " & tblHolding.DefaultView.Count

                            For iFee As Integer = 0 To tblHolding.DefaultView.Count - 1
                                If strMXGFee = "" Then
                                    strMXGFee = tblHolding.DefaultView.Item(iFee).Item("CopyNumber")
                                Else
                                    strMXGFee = strMXGFee & "," & tblHolding.DefaultView.Item(iFee).Item("CopyNumber")
                                End If
                            Next

                            'strMXGFee = tblHolding.DefaultView.Item(0).Item("CopyNumber")
                        Else
                            strRet = strRet & " [ " & strBusy & " ] "
                            tblHolding.DefaultView.RowFilter = "Code='" & strCurLib & "' AND Symbol=" & strLoc & " AND InCirculation=1 AND InUsed = 1 AND Acquired=1"
                            If tblHolding.DefaultView.Count > 0 Then
                                If strItemCheckOut = "" Then
                                    strItemCheckOut = tblHolding.DefaultView.Item(0).Item("CopyNumber")
                                End If
                            End If
                        End If
                    Else
                        'strRet = strRet & "&nbsp;&nbsp;<IMG SRC = 'images/lock1.gif' align ='bottom'>"
                        strRet = strRet & "&nbsp;&nbsp;<span class='icon-locked'></span>"
                    End If
                    strRet &= "</p>"

                    If strMXGFee <> "" Then
                        strRet &= "<p>" & strMXGFee & "</p>"
                    End If

                    'tblHolding.DefaultView.RowFilter = "Code='" & strCurLib & "' AND Symbol=" & strLoc & " AND InUsed = 0"
                    'If tblHolding.DefaultView.Count > 0 Then
                    '    strLocID = CStr(tblHolding.DefaultView.Item(0).Item("ID") & "")
                    '    strShelf = CStr(tblHolding.DefaultView.Item(0).Item("Shelf") & "")
                    '    If strMXGFee = "" Then 'Get Copynumer if All copyunumber are busy
                    '        strMXGFee = tblHolding.DefaultView.Item(0).Item("CopyNumber")
                    '    End If
                    '    strCopyNumber = ConcatHolding(tblHolding.DefaultView, strShelf)
                    '    'strRet = strRet & "&nbsp; <A HREF='WLocationDiagram.aspx?intItemID=" & CStr(intItemID) & "&intLocID=" & strLocID & "&x=" & GenRandomNumber(10) & "&strShelf=" & strShelf & "' class='lbLinkFunction'>VIEWMAP</A>"
                    '    'strRet = strRet & "&nbsp;" & "<A HREF=Javascript:OpenWindow('WLocationDiagram.aspx?intItemID=" & CStr(intItemID) & "&intLocID=" & strLocID & "&x=" & GenRandomNumber(10) & "&strShelf=A,B,C','LocationDiagram',700,400,100,100,'yes') class='lbLinkFunction'>" & strViewMap & "</A>"
                    '    strRet &= "<p>" & strCopyNumber & "</p>"
                    'End If
                    ''strRet = strRet & "<BR>"
                End If

            Next
            GetHoldingInfor = strRet
        End Function


        Private Function ConcatHolding(ByVal dtvFilter As DataView, ByRef strShelf As String) As String
            Dim intCount As Integer
            Dim strCurShelf As String
            Dim strRet As String
            Dim strPrefix As String
            'Dim lngStartNumb As Long = 0
            'Dim lngCurNumb As Long = 0
            'Dim lngThisNumb As Long

            strRet = ""
            strCurShelf = ""
            For intCount = 0 To dtvFilter.Count - 1
                If strCurShelf <> dtvFilter.Item(intCount).Item("Shelf") & "" Then
                    strCurShelf = dtvFilter.Item(intCount).Item("Shelf")
                    strShelf = strShelf & ","
                    'If lngStartNumb < lngCurNumb Then
                    '    strRet = strRet & AppendHolds(lngStartNumb, lngCurNumb)
                    'End If
                    strRet = strRet & "<BR>" & dtvFilter.Item(intCount).Item("Shelf") & ":" & dtvFilter.Item(intCount).Item("CopyNumber")
                    strPrefix = Me.GetPrefix(dtvFilter.Item(intCount).Item("CopyNumber"))
                    'If Len(strPrefix) < Len(dtvFilter.Item(intCount).Item("CopyNumber")) Then
                    '    lngStartNumb = CLng(Right(dtvFilter.Item(intCount).Item("CopyNumber"), Len(dtvFilter.Item(intCount).Item("CopyNumber")) - Len(strPrefix)))
                    '    lngCurNumb = lngStartNumb
                    'End If
                Else
                    If InStr(dtvFilter.Item(intCount).Item("CopyNumber"), strPrefix) = 1 Then
                        If IsNumeric(Right(dtvFilter.Item(intCount).Item("CopyNumber"), Len(dtvFilter.Item(intCount).Item("CopyNumber")) - Len(strPrefix))) Then
                            'lngThisNumb = CLng(Right(dtvFilter.Item(intCount).Item("CopyNumber"), Len(dtvFilter.Item(intCount).Item("CopyNumber")) - Len(strPrefix)))
                            'If lngThisNumb - lngCurNumb = 1 Then
                            '    lngCurNumb = lngCurNumb + 1
                            'Else
                            '    strRet = strRet & AppendHolds(lngStartNumb, lngCurNumb) & ", " & dtvFilter.Item(intCount).Item("CopyNumber")
                            '    lngStartNumb = lngThisNumb
                            '    lngCurNumb = lngStartNumb
                            'End If
                            strRet = strRet & ", " & dtvFilter.Item(intCount).Item("CopyNumber")
                        Else
                            'strRet = strRet & AppendHolds(lngStartNumb, lngCurNumb) & ", " & dtvFilter.Item(intCount).Item("CopyNumber")
                            strRet = strRet & ", " & dtvFilter.Item(intCount).Item("CopyNumber")
                            strPrefix = GetPrefix(dtvFilter.Item(intCount).Item("CopyNumber"))
                            'If Len(strPrefix) < Len(dtvFilter.Item(intCount).Item("CopyNumber")) Then
                            '    lngStartNumb = CLng(Right(dtvFilter.Item(intCount).Item("CopyNumber"), Len(dtvFilter.Item(intCount).Item("CopyNumber")) - Len(strPrefix)))
                            '    lngCurNumb = lngStartNumb
                            'End If
                        End If
                    Else
                        'strRet = strRet & AppendHolds(lngStartNumb, lngCurNumb) & ", " & dtvFilter.Item(intCount).Item("CopyNumber")
                        strRet = strRet & ", " & dtvFilter.Item(intCount).Item("CopyNumber")
                        strPrefix = GetPrefix(dtvFilter.Item(intCount).Item("CopyNumber"))
                        'If Len(strPrefix) < Len(dtvFilter.Item(intCount).Item("CopyNumber")) Then
                        '    lngStartNumb = CDbl(Right(dtvFilter.Item(intCount).Item("CopyNumber"), Len(dtvFilter.Item(intCount).Item("CopyNumber")) - Len(strPrefix)))
                        '    lngCurNumb = lngStartNumb
                        'End If
                    End If
                End If
            Next
            'strRet = strRet & AppendHolds(lngStartNumb, lngCurNumb)
            If Left(strRet, 4) = "<BR>" Then
                strRet = Right(strRet, Len(strRet) - 4)
            End If
            If Left(strRet, 2) = ", " Then
                strRet = Right(strRet, Len(strRet) - 2)
            End If

            ConcatHolding = strRet
        End Function

        Private Function GenRandomNumber(ByVal intNum As Integer) As String
            Dim strRet As String = ""
            Dim intCount As Integer
            Randomize()
            For intCount = 1 To intNum
                strRet = strRet & Chr(Int(Rnd(1) * 10) + 48)
            Next
            GenRandomNumber = strRet
        End Function

        ' purpose : Get all informaion relation as : BBK, UDC, Author, ...
        ' IN: ItemID
        ' OUT : DataTable
        ' Creator : dgsoft
        Public Function GetRelatedTerms() As DataTable
            objDOPACItem.ItemID = intItemID
            GetRelatedTerms = objBCDBS.ConvertTable(objDOPACItem.GetRelatedTerms())
        End Function

        ' Purpose: Read Title of ItemID
        ' Input: ItemID
        ' Output: String 
        ' Created by: dgsoft
        Public Function GetItemTite() As String
            Dim tblTitle As New DataTable
            objDOPACItem.ItemID = intItemID
            tblTitle = objBCDBS.ConvertTable(objDOPACItem.GetItemTite(), "Content")
            If tblTitle.Rows.Count > 0 Then
                GetItemTite = tblTitle.Rows(0).Item("Content")
            Else
                GetItemTite = ""
            End If
        End Function

        Public Function GetCountItemByTypeID(ByVal intTypeID As Integer) As Integer
            Try
                Dim result As DataTable = objDOPACItem.GetCountItemByTypeID(intTypeID)
                intErrorCode = objDOPACItem.ErrorCode
                strErrorMsg = objDOPACItem.ErrorMsg
                If result.Rows.Count = 1 Then
                    Dim count As Integer = CType(result.Rows(0).Item("CountItem"), Integer)
                    Return count
                Else
                    Return 0
                End If
            Catch ex As Exception
                intErrorCode = objDOPACItem.ErrorCode
                strErrorMsg = objDOPACItem.ErrorMsg
                Return 0
            End Try
        End Function


        'GetItemById()

        Public Function GetItemById() As DataTable
            objDOPACItem.ItemID = intItemID
            Try
                GetItemById = objBCDBS.ConvertTable(objDOPACItem.GetItemById)
                intErrorCode = objDOPACItem.ErrorCode
                strErrorMsg = objDOPACItem.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try

        End Function
        ' GetArticleInfor method
        ' Purpose: get infor of the current Article
        ' Input: IssueID
        ' Output: datatable result
        Public Function GetArticleInfor(Optional ByVal strML As String = "") As DataTable
            Try
                objDOPACItem.IssueID = intIssueID
                strML = objBCSP.ConvertItBack(strML)
                GetArticleInfor = objBCDBS.ConvertTable(objDOPACItem.GetArticleInfor)
                intErrorCode = objDOPACItem.ErrorCode
                strErrorMsg = objDOPACItem.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        'Purpose: get IssueID
        'Input: ItemID,IssueNo
        'Output: integer
        'Created by: Tuannv
        Public Function GetIssueID() As Integer
            Dim tblTitle As New DataTable
            objDOPACItem.ItemID = intItemID
            objDOPACItem.IssueNo = strIssueNo
            tblTitle = objBCDBS.ConvertTable(objDOPACItem.GetIssueID(), "ID")
            If Not tblTitle Is Nothing AndAlso tblTitle.Rows.Count > 0 Then
                GetIssueID = tblTitle.Rows(0).Item("ID")
            Else
                GetIssueID = 0
            End If
        End Function

        ' purpose : Doc thong tin nhung an pham hay muon tai lieu (itemID) nay cung hay muon nhung tai lieu
        ' IN: intItemID, intTop (how many need)
        ' OUT : DataTable
        ' Creator : dgsoft
        Public Function GetRelationBooks(ByVal intTop As Integer) As DataTable
            objDOPACItem.ItemID = intItemID
            GetRelationBooks = objBCDBS.ConvertTable(objDOPACItem.GetRelationBooks(intTop), "Content")
        End Function

        ' purpose : Get E-Data of itemID
        ' IN: ItemID
        ' OUT : DataTable
        ' Creator : dgsoft
        Public Function GetEData() As DataTable
            objDOPACItem.ItemID = intItemID
            GetEData = objBCDBS.ConvertTable(objDOPACItem.GetEData)
        End Function

        Public Function GetReceivedYear() As DataTable
            Try
                objDOPACItem.ItemID = intItemID
                'objDOPACItem.LocationID = intLocationID
                GetReceivedYear = objDOPACItem.GetReceivedYear()
                intErrorCode = objDOPACItem.ErrorCode
                strErrorMsg = objDOPACItem.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        ' purpose : Get Relation Titles
        ' IN: ItemID
        ' OUT : DataTable
        ' Creator : dgsoft
        Public Function GetRelationTitles() As DataTable
            objDOPACItem.ItemID = intItemID
            GetRelationTitles = objBCDBS.ConvertTable(objDOPACItem.GetRelationTitles, "Content")
        End Function

        ' purpose : Get Related Analytics information
        ' IN: ItemID
        ' OUT : DataTable
        ' Creator : dgsoft
        Public Function GetRelatedAnalytics(Optional ByVal intSerID As Integer = 0) As DataTable
            objDOPACItem.ItemID = intItemID
            GetRelatedAnalytics = objBCDBS.ConvertTable(objDOPACItem.GetRelatedAnalytics(intSerID))
        End Function

        ' purpose : Get Holding information
        ' IN: ItemID,intSerID
        ' OUT : DataTable
        ' Creator : dgsoft
        Private Function GetHolding(Optional ByVal intSerID As Integer = 0) As DataTable
            objDOPACItem.ItemID = intItemID
            GetHolding = objBCDBS.ConvertTable(objDOPACItem.GetHolding(intSerID))
        End Function

        ' purpose : Get Serial Holdings information
        ' IN: ItemID
        ' OUT : String
        ' Creator : dgsoft
        Public Function GetSerHolding() As String
            Dim tblSerHold As New DataTable
            objDOPACItem.ItemID = intItemID
            tblSerHold = objBCDBS.ConvertTable(objDOPACItem.GetSerHolding)
            If tblSerHold.Rows.Count > 0 Then
                If (Not IsDBNull(tblSerHold.Rows(0).Item("SummaryHolding"))) AndAlso (tblSerHold.Rows(0).Item("SummaryHolding") <> "") Then
                    GetSerHolding = tblSerHold.Rows(0).Item("SummaryHolding").ToString
                Else
                    GetSerHolding = "NOINFOR"
                End If
            Else
                GetSerHolding = ""
            End If
        End Function

        ' purpose : Get Total Hold request
        ' IN: ItemID
        ' OUT : Long
        ' Creator : dgsoft
        Public Function GetSumHoldRequest(Optional ByVal bytInturn As Byte = 1) As Long
            Dim tblSumHold As New DataTable
            objDOPACItem.ItemID = intItemID
            tblSumHold = objBCDBS.ConvertTable(objDOPACItem.GetSumHoldRequest(bytInturn))
            If tblSumHold.Rows.Count > 0 Then
                GetSumHoldRequest = CLng(tblSumHold.Rows(0).Item(0))
            Else
                GetSumHoldRequest = 0
            End If
        End Function
        ' Purpose: Get Total Holding request
        ' In: ItemID
        ' Out: Long
        ' Created by: Tuannv
        Public Function GetTotalHoldRequest() As Long
            Dim tblSumHold As New DataTable
            objDOPACItem.ItemID = intItemID
            tblSumHold = objBCDBS.ConvertTable(objDOPACItem.GetTotalHoldRequest())
            If Not tblSumHold Is Nothing AndAlso tblSumHold.Rows.Count > 0 Then
                GetTotalHoldRequest = CLng(tblSumHold.Rows(0).Item(0))
            Else
                GetTotalHoldRequest = 0
            End If
        End Function

        ' purpose : Read DueDate on loan
        ' IN: ItemID
        ' OUT : format date time (string)
        ' Creator : dgsoft
        Public Function GetDueDate() As String
            Dim tblDueDate As New DataTable
            objDOPACItem.ItemID = intItemID
            tblDueDate = objBCDBS.ConvertTable(objDOPACItem.GetDueDate)
            If tblDueDate.Rows.Count > 0 Then
                If IsDBNull(tblDueDate.Rows(0).Item(0)) Then
                    GetDueDate = ""
                Else
                    GetDueDate = objBCDBS.ConvertDate(tblDueDate.Rows(0).Item(0))
                End If
            Else
                GetDueDate = ""
            End If
        End Function


        ' purpose : Read Author information by AccessEntry
        ' IN: AccessEntry
        ' OUT : DataTable
        ' Creator : dgsoft
        Public Function GetAcessEntryAuthor(ByVal strAccessEntry As String) As DataTable
            strAccessEntry = objBCSP.ConvertItBack(strAccessEntry)
            GetAcessEntryAuthor = objBCDBS.ConvertTable(objDOPACItem.GetAcessEntryAuthor(strAccessEntry))
        End Function

        Public Function GetDicItemType(Optional ByVal intLibID As Integer = 0) As DataTable
            Try
                GetDicItemType = objBCDBS.ConvertTable(objDOPACItem.GetDicItemType(intLibID))
                strErrorMsg = objDOPACItem.ErrorMsg
                intErrorCode = objDOPACItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetCollectionForHome method
        ' Purpose: get all information of collection by home page
        ' Input: 
        ' Output: Datatable
        ' Creator: PhuongTT 2014.11.10
        Public Function GetCollectionForHome(Optional ByVal intLibID As Integer = 0) As DataTable
            Try
                GetCollectionForHome = objBCDBS.ConvertTable(objDOPACItem.GetCollectionForHome(intLibID))
                strErrorMsg = objDOPACItem.ErrorMsg
                intErrorCode = objDOPACItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetDigitalDocumentCount method
        ' Purpose: get all information of digital document by home page
        ' Input: 
        ' Output: Datatable
        ' Creator: PhuongTT 2015.02.05
        Public Function GetDigitalDocumentCount(Optional ByVal intLibID As Integer = 0) As DataTable
            Try
                GetDigitalDocumentCount = objDOPACItem.GetDigitalDocumentCount(intLibID)
                strErrorMsg = objDOPACItem.ErrorMsg
                intErrorCode = objDOPACItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        Public Function GetItemFileCount(Optional ByVal intLibID As Integer = 0) As DataTable
            Try
                GetItemFileCount = objDOPACItem.GetItemFileCount(intLibID)
                strErrorMsg = objDOPACItem.ErrorMsg
                intErrorCode = objDOPACItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Function CreditItemDownLoadFile(Optional ByVal strPatronCode As String = "") As Integer
            Try
                objDOPACItem.ItemID = intItemID
                CreditItemDownLoadFile = objDOPACItem.CreditItemDownLoadFile(strPatronCode)
                strErrorMsg = objDOPACItem.ErrorMsg
                intErrorCode = objDOPACItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        Public Function GetCountDownLoad() As Integer
            Try
                objDOPACItem.ItemID = intItemID
                GetCountDownLoad = objDOPACItem.GetCountDownLoad()
                strErrorMsg = objDOPACItem.ErrorMsg
                intErrorCode = objDOPACItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function
        Public Function GetAccessLevel() As DataTable
            Try
                objDOPACItem.ItemID = intItemID
                GetAccessLevel = objDOPACItem.GetAccessLevel()
                strErrorMsg = objDOPACItem.ErrorMsg
                intErrorCode = objDOPACItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        Public Function GetItem(ByVal intType As Integer) As DataTable
            Try
                GetItem = objDOPACItem.GetItem(intType)
                strErrorMsg = objDOPACItem.ErrorMsg
                intErrorCode = objDOPACItem.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                End If
                If Not objDOPACItem Is Nothing Then
                    Call objDOPACItem.Dispose(True)
                    objDOPACItem = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    Call objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    Call objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace