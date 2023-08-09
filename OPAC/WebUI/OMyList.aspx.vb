Imports eMicLibOPAC.BusinessRules.OPAC

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class OMyList
        Inherits clsWBaseJqueryUI 'clsWBase

        Private objBOPACItem As New clsBOPACItem
        Private objBSearchResult As New clsBOPACSearchResult

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call processBooks(clsSession.GlbMyListIds)
            End If
            If Not IsNothing(Request("removeAll")) Then
                clsSession.GlbMyListIds = ""
                Call processBooks(clsSession.GlbMyListIds)
            End If
        End Sub
        ' Init method
        ' purpose initialize all components
        Private Sub Initialize()
            ' Init objBOPACItem object
            objBOPACItem.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBOPACItem.DBServer = Session("DBServer")
            objBOPACItem.ConnectionString = Session("ConnectionString")
            Call objBOPACItem.Initialize()

            ' init objBSearchResult object
            objBSearchResult.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBSearchResult.DBServer = Session("DBServer")
            objBSearchResult.ConnectionString = Session("ConnectionString")
            objBSearchResult.Initialize()

        End Sub

        ' BindScript method
        ' Purpose: Bind JAVASCRIPTS
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'js/OMyList.js'></script>")
            'Page.RegisterClientScriptBlock("ActionHidden", "<script language = 'javascript'>parent.HiddenSaveIDs.document.forms[0].submit()</script>")
        End Sub



        ' raiseShowRecord_Click method
        ' Purpose: show record by click of page
        Private Sub raiseShowRecord_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles raiseShowRecord.Click
            Try
                Call processBooks(clsSession.GlbMyListIds)
            Catch ex As Exception
            End Try
        End Sub


        ' purpose :  show books by list of ids document
        ' Creator: phuongtt
        Private Sub processBooks(ByVal strIds As String)
            Try
                If strIds.Trim <> "" Then
                    Dim intCurPage As Integer
                    Dim intSumPage As Integer
                    Dim intStart, intStop As Integer
                    Dim colSearch As New Collection
                    Dim intSumResult As Integer = 0
                    Dim strSelectTop As String = ""
                    Dim strArrayIds() As String = Split(strIds, ",")

                    Dim intTotal As Integer = UBound(strArrayIds)
                    Dim intPagezise As Integer = 3 'Application("ePageSize")
                    Dim intPageLength As Integer = Application("ePageLength")
                    Dim intPageSpace As Integer = 3 'Application("ePageSpace")

                    intSumPage = (intTotal - 1) \ intPagezise + 1

                    intCurPage = hidCurrentPage.Value

                    intStart = (intCurPage - 1) * intPagezise
                    intStop = (((intCurPage - 1) * intPagezise) + intPagezise) - 1
                    If intStart > intTotal - 1 Then
                        intStart = intTotal - 1
                    End If
                    If intStop > intTotal - 1 Then
                        intStop = intTotal - 1
                    End If

                    Call showPaging(intTotal, intPagezise, intCurPage, intPageSpace, intPageLength, intStop)

                    ' Read IDs of current page
                    Dim idsList As String = ""
                    For intCount As Integer = intStart To intStop
                        idsList = idsList & strArrayIds(intCount) & ","
                    Next
                    If idsList <> "" Then
                        idsList = Left(idsList, Len(idsList) - 1)
                    End If
                    objBSearchResult.ItemIDs = idsList
                    Dim arrField() As String = {"022", "100", "110", "245", "250", "260", "300", "490", "700", "710", "773", "856"}
                    Dim tblTmp As New DataTable
                    tblTmp = objBSearchResult.GetItemResultsByFields(arrField, True)
                    Call showBooks(tblTmp, idsList, intCurPage, intPagezise)
                Else
                    lrtPagination.Text = spNotFoundItem.InnerText
                    ltrBookList.Text = ""
                End If
            Catch ex As Exception
            End Try
        End Sub

        ' purpose :  show paging as google paging
        ' Creator: phuongtt
        Private Sub showPaging(ByVal intCount As Integer, ByVal intPagezise As Integer, ByVal intPage As Integer, ByVal intPageSpace As Integer, ByVal intPageLength As Integer, ByVal intStop As Integer)
            Try
                'Dim iPage As Integer = CInt((intCount / intPagezise) + 0.4999)
                'Dim strPagination As String = ""
                'Dim PreviousPage As Integer = intPage - 1
                'Dim NextPage As Integer = intPage + 1
                'If PreviousPage >= 1 Then
                '    strPagination &= "<li class='prev'><a onclick='showRecord(" & PreviousPage.ToString & ")' data-hint='|" & spPreviousPage.InnerText & "' data-hint-position='top'><i class='icon-previous' style='padding:1px;'></i></a></li>"
                'End If
                'Dim xy As Integer = CInt((intPage / intPageSpace) + 0.4999)
                'Dim alpha As Integer = (xy - 1) * intPageSpace
                'Dim iPageCount As Integer = IIf(intPageLength + alpha <= iPage, intPageLength + alpha, iPage)

                'For j As Integer = 1 + alpha To iPageCount
                '    If j = intPage Then
                '        strPagination &= "<li class='active'>"
                '    Else
                '        strPagination &= "<li>"
                '    End If
                '    strPagination &= "<a onclick='showRecord(" & j.ToString & ")'>" & j.ToString & "</a><li>"
                'Next
                'If NextPage <= iPage Then
                '    strPagination &= "<li class='next'><a onclick='showRecord(" & NextPage.ToString & ")' data-hint='|" & spNextPage.InnerText & "' data-hint-position='top'><i class='icon-next' style='padding:1px;'></i></a></li>"
                'End If
                'lrtPagination.Text = strPagination

                'Dim strItemInfo As String = ""
                'strItemInfo &= "<div style='vertical-align:middle;'><span class='tertiary-text-secondary'>"
                'strItemInfo &= "&nbsp;"
                'strItemInfo &= spRecordItem.InnerText
                'strItemInfo &= "&nbsp;"
                'strItemInfo &= intPagezise * (intPage - 1) + 1
                'strItemInfo &= "&nbsp;"
                'strItemInfo &= spRecordTo.InnerText
                'strItemInfo &= "&nbsp;"
                'strItemInfo &= intStop + 1
                'strItemInfo &= "&nbsp;"
                'strItemInfo &= spRecordOf.InnerText
                'strItemInfo &= "&nbsp;"
                'strItemInfo &= intCount
                ''strItemInfo &= "</strong> "
                'strItemInfo &= "</span>"
                'strItemInfo &= "</div>"
                'lrtPagination.Text &= strItemInfo

                Dim iPage As Integer = CInt((intCount / intPagezise) + 0.4999)
                Dim strPagination As String = ""
                Dim PreviousPage As Integer = intPage - 1
                Dim NextPage As Integer = intPage + 1
                If PreviousPage >= 1 Then
                    strPagination &= "<li><a onclick='showRecord(" & PreviousPage.ToString & ")' data-hint='|" & spPreviousPage.InnerText & "' data-hint-position='top' style='cursor:pointer;'><</a></li>"
                End If
                Dim xy As Integer = CInt((intPage / intPageSpace) + 0.4999)
                Dim alpha As Integer = (xy - 1) * intPageSpace
                Dim iPageCount As Integer = IIf(intPageLength + alpha <= iPage, intPageLength + alpha, iPage)

                For j As Integer = 1 + alpha To iPageCount
                    strPagination &= "<li>"
                    If j = intPage Then
                        strPagination &= "<a onclick='showRecord(" & j.ToString & ")' class='PageSeleted'  style='cursor:pointer;'>" & j.ToString & "</a>"
                    Else
                        strPagination &= "<a onclick='showRecord(" & j.ToString & ")'  style='cursor:pointer;'>" & j.ToString & "</a>"
                    End If
                    strPagination &= "</li>"
                Next
                If NextPage <= iPage Then
                    strPagination &= "<li><a onclick='showRecord(" & NextPage.ToString & ")' data-hint='|" & spNextPage.InnerText & "' data-hint-position='top'  style='cursor:pointer;'>></a></li>"
                End If
                lrtPagination.Text = strPagination

                Dim strItemInfo As String = ""
                strItemInfo &= "<div style='vertical-align:middle;'><span class='tertiary-text-secondary'>"
                strItemInfo &= "&nbsp;"
                strItemInfo &= spRecordItem.InnerText
                strItemInfo &= "&nbsp;"
                strItemInfo &= FormatNumber(intPagezise * (intPage - 1) + 1, 0)
                strItemInfo &= "&nbsp;"
                strItemInfo &= spRecordTo.InnerText
                strItemInfo &= "&nbsp;"
                strItemInfo &= FormatNumber(intStop + 1, 0)
                strItemInfo &= "&nbsp;"
                strItemInfo &= spRecordOf.InnerText
                strItemInfo &= "&nbsp;"
                strItemInfo &= FormatNumber(intCount, 0)
                'strItemInfo &= "</strong> "
                strItemInfo &= "</span>"
                strItemInfo &= "</div>"
                lrtPagination.Text &= strItemInfo
            Catch ex As Exception
            End Try
        End Sub

        ' purpose :  show books
        ' Creator: phuongtt
        Private Sub showBooks(ByVal tblData As DataTable, ByVal strIDs As String, ByVal intCurPage As Integer, ByVal intRecPerPage As Integer)
            Dim strTitle As String ' thong tin nhan de chinh
            Dim strDesPhy As String ' thong tin mo ta vat ly
            Dim strPublish As String ' thong tin xuat ban
            Dim strAuthor As String ' thong tin tac gia
            Dim strISSN As String ' thong tin ISSN
            Dim strURL As String ' thong tin URL
            Dim strEDATA As String ' thong tin du lieu dien tu
            Dim strEMAGAZINE As String ' thong tin du lieu dien tu bao/tap chi
            Dim strRANKING As String ' thong tin xep hang
            Dim strType As String = "" ' thong tin loai tai lieu
            Dim intCount As Integer
            Dim arrIDs() As String
            Dim strCover As String = ""
            Dim str250 As String = ""
            Dim str490 As String = ""
            Dim ISBDStr As String = ""
            Dim strMXG As String = ""
            Dim rowView As DataRowView
            If tblData Is Nothing Then
                Exit Sub
            End If
            arrIDs = Split(strIDs, ",")
            Dim strResult As String = ""
            If tblData.Rows.Count > 0 Then


                For intCount = 0 To UBound(arrIDs)
                    strTitle = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND Field='245'"
                    If tblData.DefaultView.Count > 0 Then
                        strTitle = tblData.DefaultView(0).Item("Content") & ""
                    End If
                    'strTitle = (intRecPerPage * (intCurPage - 1)) + intCount + 1 & ". " & strTitle

                    ' get description physical
                    strDesPhy = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='300'"
                    If tblData.DefaultView.Count > 0 Then
                        strDesPhy = tblData.DefaultView(0).Item("Content") & ""
                    End If
                    ' get publish information
                    strPublish = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='260'"
                    If tblData.DefaultView.Count > 0 Then
                        strPublish = tblData.DefaultView(0).Item("Content") & ""
                    End If
                    'get 250
                    str250 = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='250'"
                    If tblData.DefaultView.Count > 0 Then
                        str250 = tblData.DefaultView(0).Item("Content") & ""
                    End If
                    'get 250
                    str490 = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='490'"
                    If tblData.DefaultView.Count > 0 Then
                        str490 = tblData.DefaultView(0).Item("Content") & ""
                    End If
                    ' get ISSN information
                    strISSN = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='022'"
                    If tblData.DefaultView.Count > 0 Then
                        strISSN = tblData.DefaultView(0).Item("Content") & ""
                    End If
                    'get author info
                    strAuthor = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='100'"
                    For Each rowView In tblData.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            strAuthor &= rowView.Item("Content") & "; "
                        End If
                    Next
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='110'"
                    For Each rowView In tblData.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            strAuthor &= rowView.Item("Content") & "; "
                        End If
                    Next
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='700'"
                    For Each rowView In tblData.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            strAuthor &= rowView.Item("Content") & "; "
                        End If
                    Next
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='710'"
                    For Each rowView In tblData.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            strAuthor &= rowView.Item("Content") & "; "
                        End If
                    Next
                    strAuthor = strAuthor.Trim
                    If Not strAuthor = "" Then
                        strAuthor = strAuthor.Substring(0, strAuthor.Length - 1)
                    End If

                    strURL = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='856'"
                    For Each rowView In tblData.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            If InStr(rowView.Item("Content"), "http://") > 0 Then
                                strURL &= "<a href='" & rowView.Item("Content") & "' target='_blank' class='lblinkfunction' style='cursor:pointer;'><div class='icon-link'></div>URL</a>; "
                            End If
                        End If
                    Next
                    strURL = strURL.Trim
                    If strURL <> "" Then
                        strURL = strURL.Substring(0, strURL.Length - 1)
                        'Bo span danh dau highlight cac truong 0xx --> 9xx
                        strURL = Replace(strURL, "<span style=""background-color:#60a917 !important;color:white;""></span>", "")
                    End If

                    'Du lieu dien tu
                    strEDATA = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='EDATA'"
                    If tblData.DefaultView.Count > 0 Then
                        strEDATA = tblData.DefaultView(0).Item("Content") & ""
                    End If

                    'Du lieu bao in/tap chi dien tu
                    strEMAGAZINE = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='EMAGAZINE'"
                    If tblData.DefaultView.Count > 0 Then
                        strEMAGAZINE = tblData.DefaultView(0).Item("Content") & ""
                    End If

                    'Ranking 
                    strRANKING = "2"
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='RANKING'"
                    If tblData.DefaultView.Count > 0 Then
                        strRANKING = tblData.DefaultView(0).Item("Content") & ""
                    End If

                    ''Loai tai lieu
                    'strType = ""
                    'tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='ETYPE'"
                    'If tblData.DefaultView.Count > 0 Then
                    '    strType = tblData.DefaultView(0).Item("Content") & ""
                    'End If

                    'Ma xep gia
                    strMXG = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='MXG'"
                    If tblData.DefaultView.Count > 0 Then
                        strMXG &= tblData.DefaultView(0).Item("Content")
                        'Dim intCountMXG As Integer = 0
                        'For Each rowView In tblData.DefaultView
                        '    If intCountMXG <= Application("callNumberLimit") Then
                        '        If Not IsDBNull(rowView.Item("Content")) Then
                        '            strMXG &= "<U>" & rowView.Item("Content") & "</U>" & " "
                        '        End If
                        '    Else
                        '        strMXG &= "<a onclick='showPopupDetail(" & arrIDs(intCount) & ")' class='lblinkfunction' style='cursor:pointer;'>" & "<span class=' icon-arrow-right-3'/>" & "</a> "
                        '        Exit For
                        '    End If
                        '    intCountMXG += 1
                        'Next
                    End If

                    ISBDStr = ""

                    'ISBDStr &= "<div class=""col-left-2"">"
                    'ISBDStr &= "<img src='" & strCover & "' id='" & arrIDs(intCount) & "' name='" & arrIDs(intCount) & "' style='z-index:1001;cursor:pointer;width:30%;height:50%;'  onclick='showPopupDetail(" & arrIDs(intCount) & ")'>"
                    'ISBDStr &= "</div>"

                    'ISBDStr &= "<div class=""col-left"">"

                    'Display ISBN
                    ISBDStr &= "<h2>"
                    If strAuthor <> "" Then
                        ISBDStr = ISBDStr & "<a onclick=""parent.showPopupDetail(" & arrIDs(intCount) & ")"" style=""cursor:pointer;"">"
                        ISBDStr = ISBDStr & UCase(strAuthor) '"<B>" &  & "</B>"
                        ISBDStr = ISBDStr & "</a> "
                    End If
                    ISBDStr = ISBDStr & "<a class='element place-right' onclick='removeMyList(" & arrIDs(intCount) & ")'><span class='mif-cancel mif-lg fg-red' id='icon" & arrIDs(intCount) & "' style='cursor:pointer;'  data-hint='|" & spRemoveMyList.InnerText & "' data-hint-position='left'></span></a>"
                    ISBDStr &= "</h2>"
                    'ISBDStr = ISBDStr & "<li>"

                    strCover = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='COVER'"
                    If tblData.DefaultView.Count > 0 Then
                        If Not IsDBNull(tblData.DefaultView(0).Item("Content")) AndAlso tblData.DefaultView(0).Item("Content") <> "" Then
                            strCover = Me.getEDataPATH & tblData.DefaultView(0).Item("Content")
                        Else
                            strCover = "Images/Imgviet/Books.png"
                        End If
                    End If

                    If strTitle <> "" Then
                        ISBDStr = ISBDStr & "" & strTitle & ""
                    End If
                    If str250 <> "" Then
                        ISBDStr = ISBDStr & ". -" & str250 & ""
                    End If
                    If strPublish <> "" Then
                        ISBDStr = ISBDStr & ". -" & strPublish & ""
                    End If
                    If strDesPhy <> "" Then
                        ISBDStr = ISBDStr & ". -" & strDesPhy & ""
                    End If
                    If str490 <> "" Then
                        ISBDStr = ISBDStr & str490 & ""
                    End If
                    If strISSN <> "" Then
                        ISBDStr = ISBDStr & strISSN & ""
                    End If
                    'If strType <> "" Then
                    '    ISBDStr &= "<br/>"
                    '    ISBDStr &= strType
                    'End If

                    'MXG
                    If strMXG <> "" Then
                        ISBDStr &= "<br/>"
                        ISBDStr &= "<span class='mif-barcode mif-lg fg-emerald'>&nbsp;" & strMXG & "</span>"
                    End If

                    'Thong tin URL
                    If strURL <> "" Then
                        'ISBDStr &= "<br/>"
                        'ISBDStr &= strURL
                        'strResult &= "<span class='line-height'>"
                        'strResult &= "<strong>" & spURL.InnerText & ":</strong> " & strURL
                        'strResult &= "</span>"
                        'strResult &= "<br/>"
                    End If
                    'Du lieu dien tu
                    If strEDATA <> "" Then
                        Dim strArr() As String = Split(strEDATA, ";")
                        If UBound(strArr) = 3 Then
                            ISBDStr &= "<br/>"
                            ISBDStr &= "<a href='OViewLoading.aspx?pageno=1&fileType=" & strArr(1) & "&fileId=" & strArr(2) & "&ItemId=" & strArr(3) & "'  TARGET='_parent'>" & strArr(0) & spEDATAContent.InnerText & "</a>"
                            'strResult &= "<span class='line-height'>"
                            'strResult &= "<strong>" & spEDATA.InnerText & ":</strong><a href='OViewLoading.aspx?fileType=" & strArr(1) & "&fileId=" & strArr(2) & "&ItemId=" & strArr(3) & "'  TARGET='_parent'>" & strArr(0) & spEDATAContent.InnerText & "</a>"
                            'strResult &= "</span>"
                            'strResult &= "<br/>"
                        End If
                    End If
                    'Du lieu bao in/tap chi dien tu
                    If strEMAGAZINE <> "" Then
                        ISBDStr &= "<br/>"
                        ISBDStr &= "<a href='OMagList.aspx?ItemId=" & arrIDs(intCount) & "'  TARGET='_parent'>" & strEMAGAZINE & spEDATAContent.InnerText & "</a>"
                    End If
                    'ISBDStr = ISBDStr & "</li>"
                    'ISBDStr &= "</div>"

                    strResult &= "<div>"
                    strResult &= ISBDStr
                    strResult &= "</div>"

                    strResult &= "<div class=""div-blank""></div>"
                    'strResult &= "<div class='span11'>"
                    'strResult &= "<div class='panel'>"

                    'strResult &= "<div class='panel-header'>"
                    'strResult &= "<a onclick='showPopupDetail(" & arrIDs(intCount) & ")'  href='#'  class='lblinkfunction'  style='cursor:pointer;'>" & (intRecPerPage * (intCurPage - 1)) + intCount + 1 & ". " & spDetail.InnerText & "</a> "
                    'strResult &= "<a class='element place-right' onclick='removeMyList(" & arrIDs(intCount) & ")'><span class='icon-cancel' id='icon" & arrIDs(intCount) & "' style='cursor:pointer;'  data-hint='|" & spRemoveMyList.InnerText & "' data-hint-position='left'></span></a>"
                    'strResult &= "</div>"
                    'strResult &= "<div class='panel-content'>"

                    'strResult &= "<div class='grid no-margin'>"
                    'strResult &= "<div class='row'>"

                    'strResult &= "<div class='grid no-margin'>"
                    'strResult &= "<div class='row'>"
                    'strResult &= "<div class='span12'>"
                    '' strResult &= "<div class='notice  marker-on-right'>"
                    ''Anh Bia
                    'strCover = ""
                    'tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='COVER'"
                    'If tblData.DefaultView.Count > 0 Then
                    '    If Not IsDBNull(tblData.DefaultView(0).Item("Content")) AndAlso tblData.DefaultView(0).Item("Content") <> "" Then
                    '        strCover = Me.getEDataPATH & tblData.DefaultView(0).Item("Content")
                    '    Else
                    '        strCover = "Images/Imgviet/Books.png"
                    '    End If
                    'End If
                    'strResult &= "<div  class='span1'>"
                    'strResult &= "<img src='" & strCover & "' class='rounded' id='" & arrIDs(intCount) & "' name='" & arrIDs(intCount) & "' style='z-index:1001;cursor:pointer;'  onclick='showPopupDetail(" & arrIDs(intCount) & ")'>"
                    'strResult &= "</div>"

                    'strResult &= "<div  class='span11'>"
                    'strResult &= ISBDStr
                    'strResult &= "</div>"

                    'strResult &= "</div>"
                    'strResult &= "</div>"
                    'strResult &= "</div>"





                    'strResult &= "</div>"

                    ''strResult &= "<div class='span10'>"
                    ''Thong tin mo ta vat ly
                    ''Thong tin ISSN
                    'If strISSN <> "" Then
                    '    strResult &= "<span class='line-height'>"
                    '    strResult &= "<strong>" & spISSN.InnerText & ":</strong> " & strISSN
                    '    strResult &= "</span>"
                    '    strResult &= "<br/>"
                    'End If
                    ''Thong tin tac gia
                    'If strAuthor <> "" Then
                    '    strResult &= "<span class='line-height'>"
                    '    strResult &= "<strong>" & spAuthor.InnerText & ":</strong> " & strAuthor
                    '    strResult &= "</span>"
                    '    strResult &= "<br/>"
                    'End If

                    'If strDesPhy <> "" Then
                    '    strResult &= "<span class='list-subtitle'>"
                    '    strResult &= "<strong>" & spPhysicalInfo.InnerText & ":</strong> " & strDesPhy
                    '    strResult &= "</span>"
                    '    strResult &= "<br/>"
                    'End If
                    ''Thong tin xuat ban
                    'If strDesPhy <> "" Then
                    '    strResult &= "<span class='list-subtitle'>"
                    '    strResult &= "<strong>" & spPublisherInfo.InnerText & ":</strong> " & strPublish
                    '    strResult &= "</span>"
                    '    strResult &= "<br/>"
                    'End If
                    'Loai tai lieu
                    'If strType <> "" Then
                    '    strResult &= "<span class='line-height'>"
                    '    strResult &= "<strong>" & spItemType.InnerText & ":</strong> " & strType
                    '    strResult &= "</span>"
                    '    strResult &= "<br/>"
                    'End If
                    ''Thong tin URL
                    'If strURL <> "" Then
                    '    strResult &= "<span class='line-height'>"
                    '    strResult &= "<strong>" & spURL.InnerText & ":</strong> " & strURL
                    '    strResult &= "</span>"
                    '    strResult &= "<br/>"
                    'End If
                    ''Du lieu dien tu
                    'If strEDATA <> "" Then
                    '    Dim strArr() As String = Split(strEDATA, ";")
                    '    If UBound(strArr) = 3 Then
                    '        strResult &= "<br/>"
                    '        strResult &= "<span class='line-height'>"
                    '        strResult &= "<strong>" & spEDATA.InnerText & ":</strong><a href='OViewLoading.aspx?fileType=" & strArr(1) & "&fileId=" & strArr(2) & "&ItemId=" & strArr(3) & "'  TARGET='_parent'>" & strArr(0) & spEDATAContent.InnerText & "</a>"
                    '        strResult &= "</span>"
                    '        strResult &= "<br/>"
                    '    End If
                    'End If

                    ''Ranking
                    'If strRANKING <> "" Then
                    '    strResult &= "<br/>"
                    '    strResult &= "<div class='rating  fg-green small' data-role='rating' data-static='true' data-score='" & strRANKING & "'  data-stars='5' data-show-score='false' style='cursor:default;' >"
                    '    strResult &= "</div>"
                    '    strResult &= "<br/>"
                    'End If

                    ''strResult &= "</div>" 'div span10
                    'strResult &= "</div>" 'div span12

                    'strResult &= "</div>" 'div grid no-margin
                    'strResult &= "</div>" 'div row


                    'strResult &= "</div>" 'div panel-content
                    'strResult &= "</div>" 'div panel
                    'strResult &= "</div>" 'div span4
                Next
                ltrBookList.Text = strResult
            End If
        End Sub


        ' purpose :  show books
        ' Creator: phuongtt
        Private Sub showBooks_old(ByVal tblData As DataTable, ByVal strIDs As String, ByVal intCurPage As Integer, ByVal intRecPerPage As Integer)
            Dim strTitle As String ' thong tin nhan de chinh
            Dim strDesPhy As String ' thong tin mo ta vat ly
            Dim strPublish As String ' thong tin xuat ban
            Dim strAuthor As String ' thong tin tac gia
            Dim strISSN As String ' thong tin ISSN
            Dim strURL As String ' thong tin URL
            Dim strEDATA As String ' thong tin du lieu dien tu
            Dim strRANKING As String ' thong tin xep hang
            Dim strType As String ' thong tin loai tai lieu
            Dim intCount As Integer
            Dim arrIDs() As String
            Dim strCover As String = ""
            Dim rowView As DataRowView
            If tblData Is Nothing Then
                Exit Sub
            End If
            arrIDs = Split(strIDs, ",")
            Dim strResult As String = ""
            If tblData.Rows.Count > 0 Then


                For intCount = 0 To UBound(arrIDs)
                    strTitle = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND Field='245'"
                    If tblData.DefaultView.Count > 0 Then
                        strTitle = tblData.DefaultView(0).Item("Content") & ""
                    End If
                    strTitle = (intRecPerPage * (intCurPage - 1)) + intCount + 1 & ". " & strTitle

                    ' get description physical
                    strDesPhy = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='300'"
                    If tblData.DefaultView.Count > 0 Then
                        strDesPhy = tblData.DefaultView(0).Item("Content") & ""
                    End If
                    ' get publish information
                    strPublish = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='260'"
                    If tblData.DefaultView.Count > 0 Then
                        strPublish = tblData.DefaultView(0).Item("Content") & ""
                    End If
                    ' get ISSN information
                    strISSN = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='022'"
                    If tblData.DefaultView.Count > 0 Then
                        strISSN = tblData.DefaultView(0).Item("Content") & ""
                    End If
                    'get author info
                    strAuthor = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='100'"
                    For Each rowView In tblData.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            strAuthor &= rowView.Item("Content") & "; "
                        End If
                    Next
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='110'"
                    For Each rowView In tblData.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            strAuthor &= rowView.Item("Content") & "; "
                        End If
                    Next
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='700'"
                    For Each rowView In tblData.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            strAuthor &= rowView.Item("Content") & "; "
                        End If
                    Next
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='710'"
                    For Each rowView In tblData.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            strAuthor &= rowView.Item("Content") & "; "
                        End If
                    Next
                    strAuthor = strAuthor.Trim
                    If Not strAuthor = "" Then
                        strAuthor = strAuthor.Substring(0, strAuthor.Length - 1)
                    End If

                    strURL = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='856'"
                    For Each rowView In tblData.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            If InStr(rowView.Item("Content"), "http://") > 0 Then
                                strURL &= "<a href='" & rowView.Item("Content") & "' target='_blank' class='lblinkfunction' style='cursor:pointer;'><div class='icon-link'></div>URL</a>; "
                            End If
                        End If
                    Next
                    strURL = strURL.Trim
                    If strURL <> "" Then
                        strURL = strURL.Substring(0, strURL.Length - 1)
                        'Bo span danh dau highlight cac truong 0xx --> 9xx
                        strURL = Replace(strURL, "<span style=""background-color:#60a917 !important;color:white;""></span>", "")
                    End If

                    'Du lieu dien tu
                    strEDATA = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='EDATA'"
                    If tblData.DefaultView.Count > 0 Then
                        strEDATA = tblData.DefaultView(0).Item("Content") & ""
                    End If

                    'Ranking 
                    strRANKING = "2"
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='RANKING'"
                    If tblData.DefaultView.Count > 0 Then
                        strRANKING = tblData.DefaultView(0).Item("Content") & ""
                    End If

                    'Loai tai lieu
                    strType = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='ETYPE'"
                    If tblData.DefaultView.Count > 0 Then
                        strType = tblData.DefaultView(0).Item("Content") & ""
                    End If

                    strResult &= "<div class='span11'>"
                    strResult &= "<div class='panel'>"

                    strResult &= "<div class='panel-header'>"
                    strResult &= "<a onclick='showPopupDetail(" & arrIDs(intCount) & ")'  href='#'  class='lblinkfunction'  style='cursor:pointer;'>" & strTitle & "</a> "
                    strResult &= "<a class='element place-right' onclick='removeMyList(" & arrIDs(intCount) & ")'><span class='icon-cancel' id='icon" & arrIDs(intCount) & "' style='cursor:pointer;'  data-hint='|" & spRemoveMyList.InnerText & "' data-hint-position='left'></span></a>"
                    strResult &= "</div>"
                    strResult &= "<div class='panel-content'>"

                    strResult &= "<div class='grid no-margin'>"
                    strResult &= "<div class='row'>"

                    strResult &= "<div class='span11'>"
                    ' strResult &= "<div class='notice  marker-on-right'>"
                    'Anh Bia
                    strCover = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='COVER'"
                    If tblData.DefaultView.Count > 0 Then
                        If Not IsDBNull(tblData.DefaultView(0).Item("Content")) AndAlso tblData.DefaultView(0).Item("Content") <> "" Then
                            strCover = Me.getEDataPATH & tblData.DefaultView(0).Item("Content")
                        Else
                            strCover = "Images/Imgviet/Books.png"
                        End If
                    End If
                    strResult &= "<div  class='span1'>"
                    strResult &= "<img src='" & strCover & "' class='rounded' id='" & arrIDs(intCount) & "' name='" & arrIDs(intCount) & "' style='z-index:1001;cursor:pointer;'  onclick='showPopupDetail(" & arrIDs(intCount) & ")'>"
                    strResult &= "</div>"
                    'strResult &= "</div>"

                    'strResult &= "<div class='span10'>"
                    'Thong tin mo ta vat ly
                    'Thong tin ISSN
                    If strISSN <> "" Then
                        strResult &= "<span class='line-height'>"
                        strResult &= "<strong>" & spISSN.InnerText & ":</strong> " & strISSN
                        strResult &= "</span>"
                        strResult &= "<br/>"
                    End If
                    'Thong tin tac gia
                    If strAuthor <> "" Then
                        strResult &= "<span class='line-height'>"
                        strResult &= "<strong>" & spAuthor.InnerText & ":</strong> " & strAuthor
                        strResult &= "</span>"
                        strResult &= "<br/>"
                    End If

                    If strDesPhy <> "" Then
                        strResult &= "<span class='list-subtitle'>"
                        strResult &= "<strong>" & spPhysicalInfo.InnerText & ":</strong> " & strDesPhy
                        strResult &= "</span>"
                        strResult &= "<br/>"
                    End If
                    'Thong tin xuat ban
                    If strDesPhy <> "" Then
                        strResult &= "<span class='list-subtitle'>"
                        strResult &= "<strong>" & spPublisherInfo.InnerText & ":</strong> " & strPublish
                        strResult &= "</span>"
                        strResult &= "<br/>"
                    End If
                    'Loai tai lieu
                    If strType <> "" Then
                        strResult &= "<span class='line-height'>"
                        strResult &= "<strong>" & spItemType.InnerText & ":</strong> " & strType
                        strResult &= "</span>"
                        strResult &= "<br/>"
                    End If
                    'Thong tin URL
                    If strURL <> "" Then
                        strResult &= "<span class='line-height'>"
                        strResult &= "<strong>" & spURL.InnerText & ":</strong> " & strURL
                        strResult &= "</span>"
                        strResult &= "<br/>"
                    End If
                    'Du lieu dien tu
                    If strEDATA <> "" Then
                        Dim strArr() As String = Split(strEDATA, ";")
                        If UBound(strArr) = 3 Then
                            strResult &= "<br/>"
                            strResult &= "<span class='line-height'>"
                            strResult &= "<strong>" & spEDATA.InnerText & ":</strong><a href='OViewLoading.aspx?fileType=" & strArr(1) & "&fileId=" & strArr(2) & "&ItemId=" & strArr(3) & "'  TARGET='_parent'>" & strArr(0) & spEDATAContent.InnerText & "</a>"
                            strResult &= "</span>"
                            strResult &= "<br/>"
                        End If
                    End If

                    'Ranking
                    If strRANKING <> "" Then
                        strResult &= "<br/>"
                        strResult &= "<div class='rating  fg-green small' data-role='rating' data-static='true' data-score='" & strRANKING & "'  data-stars='5' data-show-score='false' style='cursor:default;' >"
                        strResult &= "</div>"
                        strResult &= "<br/>"
                    End If

                    'strResult &= "</div>" 'div span10
                    strResult &= "</div>" 'div span12

                    strResult &= "</div>" 'div grid no-margin
                    strResult &= "</div>" 'div row


                    strResult &= "</div>" 'div panel-content
                    strResult &= "</div>" 'div panel
                    strResult &= "</div>" 'div span4
                Next
                ltrBookList.Text = strResult
            End If
        End Sub


        Private Sub raiseRemoveItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles raiseRemoveItem.Click
            Try
                Dim strItem As String = hidItem.Value
                clsSession.GlbMyListIds = Replace(clsSession.GlbMyListIds, strItem & ",", "")
                Call processBooks(clsSession.GlbMyListIds)
            Catch ex As Exception
            End Try
        End Sub


        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBOPACItem Is Nothing Then
                    objBOPACItem.Dispose(True)
                    objBOPACItem = Nothing
                End If
                If Not objBSearchResult Is Nothing Then
                    objBSearchResult.Dispose(True)
                    objBSearchResult = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
