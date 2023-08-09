Imports System.IO
Imports System.IO.Path
Imports eMicLibOPAC.BusinessRules.OPAC
Imports eMicLibOPAC.BusinessRules.Common
Imports System.Linq

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class OBrowse
        Inherits clsWBaseJqueryUI

        Private objBOpacItem As New clsBOPACItem
        Private objBFilterBrowse As New clsBOPACFilterBrowse
        Private objBCommonStringProc As New clsBCommonStringProc
        Private fCutContentLength As Integer = 36 '<span class=""hightlight-text""></span>"
        Private strBeginBoldTag As String = "<b>"
        Private strEndBoldTag As String = ":&nbsp;</b>"

        Public strTitle As String = ""
        Public strTextHolder As String = ""

        Private Sub GenStringTitleAndTextHolderByDicID(ByVal strDicID As String)
            Select Case strDicID
                Case "13"
                    strTitle = "Tìm theo Nhan đề"
                    strTextHolder = "Nhập tên tài liệu"
                Case "1"
                    strTitle = "Tìm theo Tác giả"
                    strTextHolder = "Nhập tên tác giả"
                Case "9"
                    strTitle = "Tìm theo Năm xuất bản"
                    strTextHolder = "Nhập năm xuất bản"
                Case "2"
                    strTitle = "Tìm theo Nhà xuất bản"
                    strTextHolder = "Nhập nhà xuất bản"
                Case "3"
                    strTitle = "Tìm theo Từ khóa"
                    strTextHolder = "Nhập từ khóa"
                Case "10"
                    strTitle = "Tìm theo Dạng tài liệu"
                    strTextHolder = "Nhập dạng tài liệu"
                Case "11"
                    strTitle = "Tìm theo Tài liệu số"
                    strTextHolder = "Nhập tài liệu số"
                Case "12"
                    strTitle = "Tìm theo Danh mục"
                    strTextHolder = "Nhập tên danh mục"
                Case "14"
                    strTitle = "Tìm theo Bộ sưu tập"
                    strTextHolder = "Nhập tên bộ sưu tập"
                Case "0"
                    strTitle = "Tìm theo Nhan đề"
                    strTextHolder = "Nhập tên tài liệu"
                Case Else
                    strTitle = ""
                    strTextHolder = ""
            End Select
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call resetObject()
                Dim intDicID As Integer = 0
                Dim strWord As String = ""
                If Not IsNothing(Request("DicID")) Then
                    intDicID = Request("DicID")
                    hidTypeSearch.Value = Request("DicID") '13: Nhan De | 1: Tac gia | 9: Nam san xuat | 2: Nha xuat ban |3: Tu Khoa | 10: Dang Tai Lieu | 11 : Tai Lieu Dien Tu | 0 : Tai Lieu Moi Nhat
                    GenStringTitleAndTextHolderByDicID(Request("DicID"))
                End If
                Session("DicID") = intDicID
                If Not IsNothing(Request("Word")) Then
                    strWord = Request("Word")
                End If
                Session("Word") = strWord

                Call BindDictionary(Session("DicID"))
                Call BindData(intDicID, strWord)
            End If
        End Sub

        ' resetObject method
        ' Purpose: delete all Object
        Private Sub resetObject()
            Try
                clsSession.GlbBrowseIds = Nothing
            Catch ex As Exception
            End Try
        End Sub

        Private Sub BindDictionary(ByVal DicID As Integer)
            Dim strDic As String
            Dim arrDic() As String
            Dim strLable As String = ""
            strLable &= "<ul class='sort-text ClearFix'>"
            Dim i As Integer
            strDic = "0-9  A  B  C  D  E  F  G  H  I  J  K  L  M  N  O  P  Q  R  S  T  U  V  W  X  Y  Z ~"
            arrDic = strDic.Split("  ")
            For i = 0 To arrDic.Length - 1
                strLable &= "<li>"
                strLable &= "<a href=""OBrowse.aspx?DicID=" & Session("DicID") & "&Word=" & arrDic(i) & """>" & arrDic(i) & "</a>"
                strLable &= "</li>"
                'strLable = strLable & "<A style=""color: #1062B4;font-size:14px;font-weight:bold"" HREF=""OBrowse.aspx?DicID=" & Session("DicID") & "&Word=" & arrDic(i) & """>" & arrDic(i) & "</A>&nbsp;"
            Next
            strLable &= "</ul>"
            lrtDictionary.Text = strLable
            If DicID = 9 Or DicID = 12 Or DicID = 14 Or DicID = 10 Or DicID = 11 Then 'nam xuat ban, danh muc va bo suu tap, dang tai lieu, tai lieu dien tu
                lrtDictionary.Visible = False
            Else
                lrtDictionary.Visible = True
            End If
            If DicID = 12 Or DicID = 14 Or DicID = 0 Then
                divOrderBy.Visible = False
            Else
                divOrderBy.Visible = True
            End If
            If DicID = 14 Then 'bo suu tap
                divSearchBrowse.Visible = False
            Else
                divSearchBrowse.Visible = True
            End If
            'lblWordSelected.Text = Session("Word")
        End Sub

        Private Sub getSort(ByRef strFielSort As String, ByRef strMethodSort As String)
            Try
                If Not IsNothing(clsSession.GlbBrowseOrderBy) AndAlso clsSession.GlbBrowseOrderBy <> "" Then
                    Select Case clsSession.GlbBrowseOrderBy
                        Case "A-Z"
                            strFielSort = "DisplayEntry"
                            strMethodSort = "ASC"
                        Case "Z-A"
                            strFielSort = "DisplayEntry"
                            strMethodSort = "DESC"
                        Case "A-Z-RQ"
                            strFielSort = "NumberNo"
                            strMethodSort = "ASC"
                        Case "Z-A-RQ"
                            strFielSort = "NumberNo"
                            strMethodSort = "DESC"
                    End Select
                End If
            Catch ex As Exception
            End Try
        End Sub

        ' BindData method
        ' Purpose: set information for browse
        Private Sub BindData(ByVal DicID As Integer, Optional ByVal strSearch As String = "")
            Try
                Dim tblTemp As DataView = Nothing
                Dim strFielSort As String = ""
                Dim strMethodSort As String = ""
                Dim strResult As String = ""
                Dim strIconCss As String = ""
                Select Case DicID
                    Case 0 'Tai Lieu Moi
                        strIconCss = " class=""mif-spell-check"" "
                        strFielSort = "NumberNo"
                        strMethodSort = "DESC"
                        'Call getSort(strFielSort, strMethodSort)
                        objBFilterBrowse.DicID = DicID
                        objBFilterBrowse.Words = strSearch
                        tblTemp = objBFilterBrowse.GetAllBrowseByWord(strFielSort, strMethodSort, 0, clsSession.GlbSite)
                        strResult &= getDictionaryString(DicID, spTitle.InnerText, tblTemp, strIconCss)
                    Case 10 'Item type
                        strIconCss = " class=""mif-shareable"" "
                        strFielSort = "NumberNo"
                        strMethodSort = "DESC"
                        Call getSort(strFielSort, strMethodSort)
                        objBFilterBrowse.DicID = DicID
                        objBFilterBrowse.Words = strSearch
                        tblTemp = objBFilterBrowse.GetAllBrowseByWord(strFielSort, strMethodSort, 0, clsSession.GlbSite)
                        strResult &= getDictionaryString(DicID, spDocType.InnerText, tblTemp, strIconCss)
                    Case 11 'Electronic Data
                        strIconCss = " class=""mif-cogs"" "
                        strFielSort = "NumberNo"
                        strMethodSort = "DESC"
                        Call getSort(strFielSort, strMethodSort)
                        objBFilterBrowse.DicID = DicID
                        objBFilterBrowse.Words = strSearch
                        tblTemp = objBFilterBrowse.GetAllBrowseByWord(strFielSort, strMethodSort, 0, clsSession.GlbSite)
                        strResult &= getDictionaryString(DicID, spElectronicData.InnerText, tblTemp, strIconCss)
                    Case 1 'Author
                        strIconCss = " class=""mif-users"" "
                        strFielSort = "NumberNo"
                        strMethodSort = "DESC"
                        Call getSort(strFielSort, strMethodSort)
                        objBFilterBrowse.DicID = DicID
                        objBFilterBrowse.Words = strSearch
                        tblTemp = objBFilterBrowse.GetAllBrowseByWord(strFielSort, strMethodSort, 0, clsSession.GlbSite)
                        strResult &= getDictionaryString(DicID, spAuthor.InnerText, tblTemp, strIconCss)
                    Case 2 'publisher
                        strIconCss = " class=""mif-bookmark"" "
                        strFielSort = "NumberNo"
                        strMethodSort = "DESC"
                        Call getSort(strFielSort, strMethodSort)
                        objBFilterBrowse.DicID = DicID
                        objBFilterBrowse.Words = strSearch
                        tblTemp = objBFilterBrowse.GetAllBrowseByWord(strFielSort, strMethodSort, 0, clsSession.GlbSite)
                        strResult &= getDictionaryString(DicID, spPublisher.InnerText, tblTemp, strIconCss)
                    Case 3 'Keyword
                        strIconCss = " class=""mif-target"" "
                        strFielSort = "NumberNo"
                        strMethodSort = "DESC"
                        Call getSort(strFielSort, strMethodSort)
                        objBFilterBrowse.DicID = DicID
                        objBFilterBrowse.Words = strSearch
                        tblTemp = objBFilterBrowse.GetAllBrowseByWord(strFielSort, strMethodSort, 0, clsSession.GlbSite)
                        strResult &= getDictionaryString(DicID, spKeyWord.InnerText, tblTemp, strIconCss)
                    Case 4 'Series
                        strIconCss = " class=""mif-shareable"" "
                        strFielSort = "NumberNo"
                        strMethodSort = "DESC"
                        Call getSort(strFielSort, strMethodSort)
                        objBFilterBrowse.DicID = DicID
                        objBFilterBrowse.Words = strSearch
                        tblTemp = objBFilterBrowse.GetAllBrowseByWord(strFielSort, strMethodSort, 0, clsSession.GlbSite)
                        strResult &= getDictionaryString(DicID, spSeries.InnerText, tblTemp, strIconCss)
                    Case 5 'Subjectheading
                        strIconCss = " class=""mif-tag"" "
                        strFielSort = "NumberNo"
                        strMethodSort = "DESC"
                        Call getSort(strFielSort, strMethodSort)
                        objBFilterBrowse.DicID = DicID
                        objBFilterBrowse.Words = strSearch
                        tblTemp = objBFilterBrowse.GetAllBrowseByWord(strFielSort, strMethodSort, 0, clsSession.GlbSite)
                        strResult &= getDictionaryString(DicID, spSubjectheading.InnerText, tblTemp, strIconCss)
                    Case 9 'publisher year
                        strIconCss = " class=""mif-calendar"" "
                        strFielSort = "DisplayEntry"
                        strMethodSort = "DESC"
                        Call getSort(strFielSort, strMethodSort)
                        objBFilterBrowse.DicID = DicID
                        objBFilterBrowse.Words = strSearch
                        tblTemp = objBFilterBrowse.GetAllBrowseByWord(strFielSort, strMethodSort, 0, clsSession.GlbSite)
                        strResult &= getDictionaryString(DicID, spPublisherYear.InnerText, tblTemp, strIconCss)
                    Case 13 'Title
                        strIconCss = " class=""mif-spell-check"" "
                        strFielSort = "NumberNo"
                        strMethodSort = "DESC"
                        Call getSort(strFielSort, strMethodSort)
                        objBFilterBrowse.DicID = DicID
                        objBFilterBrowse.Words = strSearch
                        tblTemp = objBFilterBrowse.GetAllBrowseByWord(strFielSort, strMethodSort, 0, clsSession.GlbSite)
                        strResult &= getDictionaryString(DicID, spTitle.InnerText, tblTemp, strIconCss)
                    Case 12
                        Dim dt As New DataTable
                        objBFilterBrowse.Words = strSearch
                        strIconCss = " class=""mif-list"" "
                        dt = objBFilterBrowse.GetTBrowseTreeviewDDC(clsSession.GlbSite)
                        If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                            strResult &= getTriewviewDDC(dt, strIconCss) 'getDDC(dt)
                        Else
                            strResult = spMsgNotFound.InnerText
                        End If
                    Case 14
                        strIconCss = " class=""mif-cabinet"" "
                        strFielSort = "DisplayEntry"
                        strMethodSort = "ASC"
                        Call getSort(strFielSort, strMethodSort)
                        objBFilterBrowse.DicID = DicID
                        objBFilterBrowse.Words = strSearch
                        tblTemp = objBFilterBrowse.GetAllBrowseByWord(strFielSort, strMethodSort, 0, clsSession.GlbSite)
                        If Not tblTemp Is Nothing AndAlso tblTemp.Count > 0 Then
                            strResult = getCollections(tblTemp, strIconCss)
                        Else
                            strResult = spMsgNotFound.InnerText
                        End If
                End Select
                ltrList.Text = strResult
                clsSession.GlbBrowseIds = tblTemp
                If tblTemp Is Nothing Or tblTemp.Count = 0 Then
                    divOrderBy.Visible = False

                End If

            Catch ex As Exception
            End Try
        End Sub

        Private Sub getCollectionsChild(ByVal dv As DataView, ByVal intLevel As Integer, ByRef strResultOut As String, ByVal strSearch As String)
            Try
                dv.RowFilter = "ParentID = " & intLevel
                Dim rowView As DataRowView
                Dim dview As DataView
                Dim dviewLeaf As DataView
                Dim boldviewLeaf As Boolean = False
                Dim strTempImageCover As String = ""
                Dim strTempImageCoverTemp As String = ""
                Dim strImageCover As String = ""
                If dv.Count > 0 Then
                    dview = dv
                    dviewLeaf = dv
                    strResultOut &= "<ul>"
                    For Each rowView In dv
                        strImageCover = "Upload/ImageCover/collectionCover.jpg"
                        strTempImageCover = rowView.Item("Cover")
                        If File.Exists(strTempImageCover) Then
                            strTempImageCoverTemp = Server.MapPath("~") & "/Upload/ImageCover/" & rowView.Item("ID").ToString
                            strTempImageCoverTemp = Replace(strTempImageCoverTemp, "/", "\")
                            If Not Directory.Exists(strTempImageCoverTemp) Then
                                Directory.CreateDirectory(strTempImageCoverTemp)
                            End If
                            strTempImageCoverTemp &= "\" & GetFileName(strTempImageCover)
                            If Not File.Exists(strTempImageCoverTemp) Then
                                File.Copy(strTempImageCover, strTempImageCoverTemp)
                            End If
                            strImageCover = "Upload/ImageCover/" & rowView.Item("ID").ToString & "/" & GetFileName(strTempImageCover)
                        End If
                        dviewLeaf.RowFilter = "ParentID = " & rowView.Item("ID")
                        boldviewLeaf = False
                        If dviewLeaf.Count = 0 Then
                            boldviewLeaf = True
                        End If
                        dviewLeaf.RowFilter = ""
                        If boldviewLeaf Then
                            strResultOut &= "<li><span class='leaf' onclick=""gotoShowRecord(14," & rowView.Item("ID") & ")"">" & "<img src='" + strImageCover + "' class='icon' style='width:10%;heigth:10%;vertical-align:middle;'/>" & clsUICommon.HightLightText(rowView.Item("DisplayEntry"), strSearch) & " (" & FormatNumber(rowView.Item("NumberNo"), 0) & " <span class='mif-books fg-emerald'></span>)</span>"
                            strResultOut &= "</li>"
                        Else
                            strResultOut &= "<li  class='node collapsed'><span class='node-toggle'></span><span class='leaf' onclick=""gotoShowRecord(14," & rowView.Item("ID") & ")"">" & "<img src='" + strImageCover + "' class='icon' style='width:10%;heigth:10%;'>&nbsp;" & clsUICommon.HightLightText(rowView.Item("DisplayEntry"), strSearch) & " (" & FormatNumber(rowView.Item("NumberNo"), 0) & " <span class='mif-books fg-emerald'></span>)</span>"
                            Call getCollectionsChild(dview, rowView.Item("ID"), strResultOut, strSearch)
                            strResultOut &= "</li>"
                        End If
                    Next
                    strResultOut &= "</ul>"
                End If
                dv.RowFilter = ""
            Catch ex As Exception
            End Try
        End Sub


        Private Function getCollections(ByVal dv As DataView, Optional strIconCss As String = "") As String
            Dim strResult As String = ""
            Try
                strResult &= "<h3><span" & strIconCss & "></span>" & spCollection.InnerText & "</h3>"
                strResult &= "<div id='treeviewCollection' class='treeview' data-role='treeview'>"
                strResult &= "<ul>"
                Dim rowView As DataRowView
                Dim dview As DataView
                Dim boldviewLeaf As Boolean = False
                dv.RowFilter = "ParentID = 0"
                Dim strTempImageCover As String = ""
                Dim strTempImageCoverTemp As String = ""
                Dim strImageCover As String = ""
                Dim strSearch As String = ""
                If Not IsNothing(Session("Word")) AndAlso Session("Word") <> "" Then
                    strSearch = Session("Word")
                End If
                If dv.Count > 0 Then
                    dview = dv
                    For Each rowView In dv
                        strImageCover = "Upload/ImageCover/collectionCover.jpg"
                        strTempImageCover = rowView.Item("Cover")
                        If File.Exists(strTempImageCover) Then
                            strTempImageCoverTemp = Server.MapPath("~") & "/Upload/ImageCover/" & rowView.Item("ID").ToString
                            strTempImageCoverTemp = Replace(strTempImageCoverTemp, "/", "\")
                            If Not Directory.Exists(strTempImageCoverTemp) Then
                                Directory.CreateDirectory(strTempImageCoverTemp)
                            End If
                            strTempImageCoverTemp &= "\" & GetFileName(strTempImageCover)
                            If Not File.Exists(strTempImageCoverTemp) Then
                                File.Copy(strTempImageCover, strTempImageCoverTemp)
                            End If
                            strImageCover = "Upload/ImageCover/" & rowView.Item("ID").ToString & "/" & GetFileName(strTempImageCover)
                        End If

                        dview.RowFilter = "ParentID = " & rowView.Item("ID")
                        boldviewLeaf = False
                        If dview.Count = 0 Then
                            boldviewLeaf = True
                        End If
                        dview.RowFilter = ""
                        If boldviewLeaf Then
                            'strResult &= "<li><span class='leaf' onclick=""gotoShowRecord(14," & rowView.Item("ID") & ")"">" & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src='" + strImageCover + "' class='icon' style='width:10%;heigth:10%;'>&nbsp;" & clsUICommon.HightLightText(rowView.Item("DisplayEntry"), strSearch) & " (" & FormatNumber(rowView.Item("NumberNo"), 0) & " <span class='mif-books fg-emerald'></span>)</span>"
                            'strResult &= "</li>"
                            strResult &= "<li  class='node collapsed'><span class='leaf' onclick=""gotoShowRecord(14," & rowView.Item("ID") & ")"">" & "<img src='" + strImageCover + "' class='icon' style='width:10%;heigth:10%;'>&nbsp;" & clsUICommon.HightLightText(rowView.Item("DisplayEntry"), strSearch) & " (" & FormatNumber(rowView.Item("NumberNo"), 0) & " <span class='mif-books fg-emerald'></span>)</span>"

                            strResult &= "</li>"
                        Else
                            strResult &= "<li  class='node collapsed'><span class='node-toggle'></span><span class='leaf' onclick=""gotoShowRecord(14," & rowView.Item("ID") & ")"">" & "<img src='" + strImageCover + "' class='icon' style='width:10%;heigth:10%;'>&nbsp;" & clsUICommon.HightLightText(rowView.Item("DisplayEntry"), strSearch) & " (" & FormatNumber(rowView.Item("NumberNo"), 0) & " <span class='mif-books fg-emerald'></span>)</span>"
                            Call getCollectionsChild(dview, rowView.Item("ID"), strResult, strSearch)
                            strResult &= "</li>"
                        End If
                    Next
                End If
                strResult &= "</ul>" 'Close treeview
                strResult &= "</div>" 'Close div
            Catch ex As Exception
                strResult = ""
            End Try
            Return strResult
        End Function

        ' getDictionaryString method
        ' Purpose: get objects string to into browse
        Private Function getDDC(ByVal dt As DataTable) As String
            Dim strResult As String = ""
            Try
                Dim iCount As Integer = dt.Rows.Count - 1
                Dim intId As Integer = 0
                Dim intParentIdNextNode As Integer = 0
                Dim intParentIdPreviousNode As Integer = 0
                Dim intNodeId As Integer = 0
                Dim bolLeafNode As Boolean = False
                Dim intLevel As Integer = 1
                strResult &= "<h4>" & spCatalogy.InnerText & "</h4>"
                strResult &= "<div id='treeviewDDC'>"
                strResult &= "<ul class='treeview' data-role='treeview'>"
                For i As Integer = 0 To iCount

                    intNodeId = dt.Rows(i).Item("ID")
                    If i + 1 <= iCount Then
                        If Not IsDBNull(dt.Rows(i + 1).Item("ParentID")) Then
                            intParentIdNextNode = dt.Rows(i + 1).Item("ParentID")
                        Else
                            intParentIdNextNode = 0
                        End If
                    End If
                    bolLeafNode = False
                    If intParentIdNextNode <> intNodeId Then
                        bolLeafNode = True
                    End If

                    If IsDBNull(dt.Rows(i).Item("ParentID")) Then
                        If i <> 0 Then
                            For k As Integer = 1 To intLevel - 1
                                strResult &= "</ul>"
                                strResult &= "</li>" 'Close child tag
                                'strResult &= "</ul>"
                                'strResult &= "</li>" 'Close 1 level
                            Next
                        End If
                        If bolLeafNode Then
                            'Neu la nut la thi thay the code --> codeFull
                            strResult &= "<li><a href='#' onclick=""gotoShowRecord(12,'" & dt.Rows(i).Item("codeFull") & "')"">" & dt.Rows(i).Item("Caption") & " (" & dt.Rows(i).Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)" 'leaf tag
                            strResult &= "</a></li>"
                        Else
                            strResult &= "<li class='node expanded'>"
                            strResult &= "<a href='#' onclick=""gotoShowRecord(12,'" & dt.Rows(i).Item("Code") & "')""><span class='node-toggle'></span>" & dt.Rows(i).Item("Caption") & " (" & dt.Rows(i).Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)"
                            strResult &= "</a>"
                            strResult &= "<ul>"
                        End If
                    Else
                        If bolLeafNode Then
                            'Neu la nut la thi thay the code --> codeFull
                            strResult &= "<li><a href='#' onclick=""gotoShowRecord(12,'" & dt.Rows(i).Item("codeFull") & "')"">" & dt.Rows(i).Item("Caption") & " (" & dt.Rows(i).Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)" 'leaf tag
                            strResult &= "</a></li>"
                        Else
                            If intParentIdPreviousNode <> dt.Rows(i).Item("ParentID") AndAlso intParentIdPreviousNode <> 0 Then
                                strResult &= "</ul>"
                                strResult &= "</li>"
                            End If
                            strResult &= "<li class='node expanded'>" 'Child tag
                            strResult &= "<a href='#' onclick=""gotoShowRecord(12,'" & dt.Rows(i).Item("Code") & "')""><span class='node-toggle'></span>" & dt.Rows(i).Item("Caption") & " (" & dt.Rows(i).Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)"
                            strResult &= "</a>"
                            strResult &= "<ul>"
                        End If
                    End If

                    If Not IsDBNull(dt.Rows(i).Item("ParentID")) Then
                        intParentIdPreviousNode = dt.Rows(i).Item("ParentID")
                    Else
                        intParentIdPreviousNode = 0
                    End If
                    intLevel = dt.Rows(i).Item("alevel")
                Next

                'strResult &= "</ul>" 'Close 1 level for end node
                'strResult &= "</li>" 'Close 1 level for end node

                For k As Integer = 1 To intLevel - 1
                    strResult &= "</ul>"
                    strResult &= "</li>" 'Close child tag
                    'strResult &= "</ul>"
                    'strResult &= "</li>" 'Close 1 level
                Next
                strResult &= "</ul>" 'Close treeview
                strResult &= "</div>" 'Close div
            Catch ex As Exception
                strResult = ""
            End Try
            Return strResult
        End Function

        Private Function getTriewviewDDC(ByVal dt As DataTable, Optional ByVal strIconCss As String = "") As String
            Dim strResult As String = ""
            Try
                Dim iCount As Integer = dt.Rows.Count ' - 1
                If iCount > 0 Then
                    'strResult &= "<h4>" & spCatalogy.InnerText & "</h4>"
                    strResult &= "<h3><span" & strIconCss & "></span>" & spCatalogy.InnerText & "</h3>"
                    strResult &= "<div id='treeviewDDC'>"
                    'strResult &= "<ul class='treeview' data-role='treeview'>"
                    strResult &= "<div class='treeview' data-role='treeview'>"
                    strResult &= "<ul>"

                    Dim strSearch As String = ""
                    If Not IsNothing(Session("Word")) AndAlso Session("Word") <> "" Then
                        strSearch = Session("Word")
                    End If

                    Dim boldviewLeaf As Boolean = False
                    Dim rowView As DataRowView
                    Dim dview As DataView
                    dt.DefaultView.RowFilter = "ParentID IS NULL"
                    If dt.DefaultView.Count > 0 Then
                        dview = dt.DefaultView
                        For Each rowView In dt.DefaultView
                            'strResult &= "<ul>"
                            'strResult &= "<li class='node expanded'>"
                            'strResult &= "<a href='#' onclick=""gotoShowRecord(12," & rowView.Item("ID") & ")""><span class='node-toggle'></span>" & rowView.Item("Caption") & " (" & rowView.Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)"
                            'strResult &= "</a>"
                            dview.RowFilter = "ParentID = " & rowView.Item("ID")
                            boldviewLeaf = False
                            If dview.Count = 0 Then
                                boldviewLeaf = True
                            End If
                            dview.RowFilter = ""

                            If boldviewLeaf Then
                                strResult &= "<li  class='node'><span class='leaf' onclick=""gotoShowRecord(12,'" & rowView.Item("codeFull") & "')"">" & clsUICommon.HightLightText(rowView.Item("Caption"), strSearch) & " (" & rowView.Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)</span>" 'leaf tag
                                strResult &= "</li>"
                            Else
                                strResult &= "<li  class='node collapsed'><span class='node-toggle'></span><span class='leaf' onclick=""gotoShowRecord(12,'" & rowView.Item("Code") & "')"">" & clsUICommon.HightLightText(rowView.Item("Caption"), strSearch) & " (" & rowView.Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)</span>" 'leaf tag
                                Call getTriewviewDDCChild(dview, rowView.Item("ID"), strResult, strSearch)
                                strResult &= "</li>"
                            End If
                           
                            'strResult &= "</ul>"
                        Next
                    End If
                    dt.DefaultView.RowFilter = ""

                    'strResult &= "</ul>" 'Close treeview
                    strResult &= "</ul>"
                    strResult &= "</div>" 'Close div
                    strResult &= "</div>" 'Close div
                End If
            Catch ex As Exception
                strResult = ""
            End Try
            Return strResult
        End Function


        Private Sub getTriewviewDDCChild(ByVal dv As DataView, ByVal intLevel As Integer, ByRef strResultOut As String, Optional ByVal strSearch As String = "")
            Try
                dv.RowFilter = "ParentID = " & intLevel
                Dim rowView As DataRowView
                Dim dview As DataView
                Dim dviewLeaf As DataView
                Dim boldviewLeaf As Boolean = False
                If dv.Count > 0 Then
                    dview = dv
                    dviewLeaf = dv
                    strResultOut &= "<ul>"
                    For Each rowView In dv
                        dviewLeaf.RowFilter = "ParentID = " & rowView.Item("ID")
                        boldviewLeaf = False
                        If dviewLeaf.Count = 0 Then
                            boldviewLeaf = True
                        End If
                        dviewLeaf.RowFilter = ""
                        'strResultOut &= "<li>"
                        If boldviewLeaf Then
                            'strResultOut &= "<a href='#' onclick=""gotoShowRecord(12," & rowView.Item("ID") & ")"">" & rowView.Item("Caption") & " (" & rowView.Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)"
                            strResultOut &= "<li class='node'><span class='leaf' onclick=""gotoShowRecord(12,'" & rowView.Item("codeFull") & "')"">" & clsUICommon.HightLightText(rowView.Item("Caption"), strSearch) & " (" & rowView.Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)" 'leaf tag
                        Else
                            'strResultOut &= "<a href='#' onclick=""gotoShowRecord(12," & rowView.Item("ID") & ")""><span class='node-toggle'></span>" & rowView.Item("Caption") & " (" & rowView.Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)"
                            strResultOut &= "<li  class='node collapsed'><span class='node-toggle'></span><span class='leaf' onclick=""gotoShowRecord(12,'" & rowView.Item("Code") & "')"">" & clsUICommon.HightLightText(rowView.Item("Caption"), strSearch) & " (" & rowView.Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)" 'leaf tag
                        End If

                        strResultOut &= "</span>"
                        Call getTriewviewDDCChild(dview, rowView.Item("ID"), strResultOut, strSearch)
                        strResultOut &= "</li>"
                    Next
                    strResultOut &= "</ul>"
                End If
                dv.RowFilter = ""
            Catch ex As Exception
            End Try
        End Sub


        ' getTriewviewDDC method
        ' Purpose: get objects string to into browse
        Private Function getTriewviewDDC_v_0_9(ByVal dt As DataTable) As String
            Dim strResult As String = ""
            Try
                Dim iCount As Integer = dt.Rows.Count - 1
                If iCount > 0 Then
                    strResult &= "<h4>" & spCatalogy.InnerText & "</h4>"
                    strResult &= "<div id='treeviewDDC'>"
                    strResult &= "<ul class='treeview' data-role='treeview'>"

                    Dim rowView As DataRowView
                    Dim dview As DataView
                    dt.DefaultView.RowFilter = "ParentID IS NULL"
                    If dt.DefaultView.Count > 0 Then
                        Dim strSearch As String = ""
                        If Not IsNothing(Session("Word")) AndAlso Session("Word") <> "" Then
                            strSearch = Session("Word")
                        End If
                        dview = dt.DefaultView
                        For Each rowView In dt.DefaultView
                            strResult &= "<ul>"
                            strResult &= "<li class='node expanded'>"
                            strResult &= "<a href='#' onclick=""gotoShowRecord(12,'" & rowView.Item("Code") & "')""><span class='node-toggle'></span>" & clsUICommon.HightLightText(rowView.Item("Caption"), strSearch) & " (" & rowView.Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)"
                            strResult &= "</a>"
                            Call getTriewviewDDCChild(dview, rowView.Item("ID"), strResult)
                            strResult &= "</li>"
                            strResult &= "</ul>"
                        Next
                    End If
                    dt.DefaultView.RowFilter = ""

                    strResult &= "</ul>" 'Close treeview
                    strResult &= "</div>" 'Close div
                End If
            Catch ex As Exception
                strResult = ""
            End Try
            Return strResult
        End Function

        Private Sub getTriewviewDDCChild_v_0_9(ByVal dv As DataView, ByVal intLevel As Integer, ByRef strResultOut As String)
            Try
                dv.RowFilter = "ParentID = " & intLevel
                Dim rowView As DataRowView
                Dim dview As DataView
                Dim dviewLeaf As DataView
                Dim boldviewLeaf As Boolean = False
                If dv.Count > 0 Then
                    Dim strSearch As String = ""
                    If Not IsNothing(Session("Word")) AndAlso Session("Word") <> "" Then
                        strSearch = Session("Word")
                    End If
                    dview = dv
                    dviewLeaf = dv
                    strResultOut &= "<ul>"
                    For Each rowView In dv
                        dviewLeaf.RowFilter = "ParentID = " & rowView.Item("ID")
                        boldviewLeaf = False
                        If dviewLeaf.Count = 0 Then
                            boldviewLeaf = True
                        End If
                        dviewLeaf.RowFilter = ""
                        If boldviewLeaf Then
                            strResultOut &= "<li><a href='#' onclick=""gotoShowRecord(12,'" & rowView.Item("codeFull") & "')"">" & clsUICommon.HightLightText(rowView.Item("Caption"), strSearch) & " (" & rowView.Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)"
                        Else
                            strResultOut &= "<li class='node expanded'><a href='#' onclick=""gotoShowRecord(12,'" & rowView.Item("Code") & "')""><span class='node-toggle'></span>" & clsUICommon.HightLightText(rowView.Item("Caption"), strSearch) & " (" & rowView.Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)"
                        End If
                        strResultOut &= "</a>"
                        Call getTriewviewDDCChild(dview, rowView.Item("ID"), strResultOut)
                        strResultOut &= "</li>"
                    Next
                    strResultOut &= "</ul>"
                End If
                dv.RowFilter = ""
            Catch ex As Exception
            End Try
        End Sub

        ' getDictionaryString method
        ' Purpose: get objects string to into browse
        Private Function getDictionaryString(ByVal dicId As Integer, ByVal dicName As String, ByVal dv As DataView, Optional ByVal strIconCss As String = "") As String
            Dim strResult As String = ""
            Try
                If Not IsNothing(dv) AndAlso dv.Count > 0 Then
                    Dim iCount As Integer = 0
                    Dim intCurPage As Integer
                    Dim intCount As Integer = 0
                    Dim intSumPage As Integer
                    Dim intStart, intStop As Integer
                    Dim colSearch As New Collection
                    Dim intSumResult As Integer = 0
                    Dim strSelectTop As String = ""
                    Dim intTotal As Integer = dv.Count
                    Dim intPagezise As Integer = Application("ePageSize")
                    Dim intPageLength As Integer = Application("ePageLength")
                    Dim intPageSpace As Integer = Application("ePageSpace")
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
                    Call showPagingControl(intTotal, intPagezise, intCurPage, intPageSpace, intPageLength, intStop, intSumPage)

                    Call showOrderByControl(intCurPage)

                    'strResult &= "<div>"
                    'strResult &= "<h4>" & dicName & "</h4>"
                    'strResult &= "<div class='listview-outlook' data-role='listview'>"

                    strResult &= "<h3><span" & strIconCss & "></span>" & dicName & "</h3>"
                    strResult &= "<ul>"
                    Dim strSearch As String = ""
                    If Not IsNothing(Session("Word")) AndAlso Session("Word") <> "" Then
                        strSearch = Session("Word")
                    End If
                    For intCount = intStart To intStop
                        'strResult &= "<a class='list' onclick=""gotoShowRecord(" & dicId & "," & dv.Item(intCount).Row("ID") & ")"">"
                        'strResult &= "<div class='list-content'>" 'list-title
                        'strResult &= "<span class='list-title' title='" & dv.Item(intCount).Row("DisplayEntry") & " (" & FormatNumber(dv.Item(intCount).Row("NumberNo"), 0) & ")" & "'>"
                        'strResult &= clsUICommon.HightLightText(dv.Item(intCount).Row("DisplayEntry"), strSearch) & " (" & FormatNumber(dv.Item(intCount).Row("NumberNo"), 0) & " <span class='mif-books fg-emerald'></span>)"
                        'strResult &= "</span>"
                        'strResult &= "</div>"
                        'strResult &= "</a>"
                        If (dv.Item(intCount).Row("ID").ToString() = "32") Then
                            Dim tblOPACItem As DataTable
                            Dim intEbook As Integer = 0
                            tblOPACItem = objBOpacItem.GetItemFileCount(clsSession.GlbSite)
                            If Not tblOPACItem Is Nothing AndAlso tblOPACItem.Rows.Count > 0 Then
                                tblOPACItem.DefaultView.RowFilter = "ITYPE='EBOOK'"
                                If tblOPACItem.DefaultView.Count > 0 Then
                                    intEbook = tblOPACItem.DefaultView(0).Item("ICOUNT")
                                End If
                            End If
                            If dicId <> 0 Then
                                strResult &= "<li>"
                                strResult &= "<a onclick=""gotoShowRecord(" & dicId & "," & dv.Item(intCount).Row("ID") & ")"" style=""cursor:pointer;"">"
                                strResult &= clsUICommon.HightLightText(dv.Item(intCount).Row("DisplayEntry"), strSearch)
                                strResult &= "<span title='" & dv.Item(intCount).Row("DisplayEntry") & " (" & intEbook & ")" & "'>"
                                strResult &= " (" & intEbook & " <span class='mif-books fg-emerald'></span>)"
                                strResult &= "</span>"
                                strResult &= "</a>"
                                strResult &= "</li>"
                            Else
                                strResult &= "<li>"
                                strResult &= "<a onclick=""gotoShowRecord(" & dicId & "," & dv.Item(intCount).Row("ID") & ")"" style=""cursor:pointer;"">"
                                strResult &= clsUICommon.HightLightText(dv.Item(intCount).Row("DisplayEntry"), strSearch)
                                strResult &= "<span title='" & dv.Item(intCount).Row("DisplayEntry") & "'>"
                                strResult &= "</span>"
                                strResult &= "</a>"
                                strResult &= "</li>"
                            End If

                        Else
                            If dicId <> 0 Then
                                strResult &= "<li>"
                                strResult &= "<a onclick=""gotoShowRecord(13," & dv.Item(intCount).Row("ID") & ")"" style=""cursor:pointer;"">"
                                strResult &= clsUICommon.HightLightText(dv.Item(intCount).Row("DisplayEntry"), strSearch)
                                strResult &= "<span title='" & dv.Item(intCount).Row("DisplayEntry") & " (" & FormatNumber(dv.Item(intCount).Row("NumberNo"), 0) & ")" & "'>"
                                strResult &= " (" & FormatNumber(dv.Item(intCount).Row("NumberNo"), 0) & " <span class='mif-books fg-emerald'></span>)"
                                strResult &= "</span>"
                                strResult &= "</a>"
                                strResult &= "</li>"
                            Else
                                strResult &= "<li>"
                                strResult &= "<a onclick=""gotoShowRecord(13," & dv.Item(intCount).Row("ID") & ")"" style=""cursor:pointer;"">"
                                strResult &= clsUICommon.HightLightText(dv.Item(intCount).Row("DisplayEntry"), strSearch)
                                strResult &= "<span title='" & dv.Item(intCount).Row("DisplayEntry") & "'>"
                                strResult &= "</span>"
                                strResult &= "</a>"
                                strResult &= "</li>"
                            End If

                        End If

                    Next
                    'strResult &= "</div>" 'Close data-role='listview'
                    'strResult &= "</div>" 'Close div class='span4'
                    strResult &= "</ul>"
                Else
                    divOrderBy.Visible = False
                End If
            Catch ex As Exception
                strResult = ""
            End Try
            If strResult = "" Then
                strResult = spMsgNotFound.InnerText
                lrtPagination1.Visible = False
                lrtPagination2.Visible = False
                divOrderBy.Visible = False
            Else
                lrtPagination1.Visible = True
                lrtPagination2.Visible = True
                If dicId <> 0 Then

                    divOrderBy.Visible = True
                Else
                    divOrderBy.Visible = False
                End If
            End If
            Return strResult
        End Function

        Private Function getCutVietnameseAccent(ByVal strSearch As String) As String
            Dim strResult As String = ""
            Try
                strResult = objBCommonStringProc.CutVietnameseAccent(strSearch)
            Catch ex As Exception
            End Try
            Return strResult
        End Function
        Private Function getIcons(ByVal iTem As Integer) As String
            Dim strResult As String = ""
            Try
                Dim strId As String = iTem & ","
                If InStr(clsSession.GlbMyListIds, strId) > 0 Then
                    'strResult = "<a class='element place-right' onclick='#'><span class='icon-checkmark' id='icon" & iTem & "' data-hint='|" & spInMyList.InnerText & "' data-hint-position='top'></span></a>"
                    strResult = "<h3 class=""uncheck"" id=""h" & iTem & """><a onclick='parent.checkMyList(" & iTem.ToString & ")' style=""cursor:pointer;""><span class=""mif-heart-broken"" id=""icon" & iTem & """></span><span id=""spCart" & iTem & """>" & spCancelList.InnerText & "</span></a></h3>"
                Else
                    strResult = "<h3 id=""h" & iTem & """><a onclick='parent.checkMyList(" & iTem.ToString & ")' style=""cursor:pointer;""><span class=""mif-heart"" id=""icon" & iTem & """></span><span id=""spCart" & iTem & """>" & spSaveList.InnerText & "</span></a></h3>"
                    'strResult = "<a class='element place-right' onclick='addMyList(" & iTem.ToString & ")'><span class='icon-plus' id='icon" & iTem & "' style='cursor:pointer;' data-hint='|" & spAddToMyList.InnerText & "' data-hint-position='top'></span></a>"
                End If
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        Private Sub showBooks(ByVal tblData As DataTable, ByVal strIDs As String, ByVal intCurPage As Integer, ByVal intRecPerPage As Integer)
            Dim strTitle As String ' thong tin nhan de chinh
            Dim strDKCB As String ' thong tin mo ta vat ly
            Dim strSoDinhDanh As String 'thong tin so dinh danh
            Dim strPublish As String ' thong tin xuat ban
            Dim strCover As String ' thong tin bia tai lieu
            Dim strAuthor As String ' thong tin tac gia
            Dim strISSN As String ' thong tin ISSN
            Dim strURL As String ' thong tin URL
            Dim strEDATA As String ' thong tin du lieu dien tu
            Dim strEMAGAZINE As String ' thong tin du lieu dien tu
            Dim strRANKING As String ' thong tin xep hang
            Dim strType As String ' thong tin loai tai lieu
            Dim strLibrary As String = ""
            Dim intCount As Integer
            Dim strMXG As String = ""
            Dim strArrBrief() As String = Nothing
            Dim strBrief As String = ""
            Dim strSearchFulltext As String = ""
            Dim intPageLink As Integer = 1
            Dim arrIDs() As String
            Dim strArr() As String
            Dim intViews As Integer = 0
            Dim rowView As DataRowView
            Dim intViewRandom As Integer = 0
            If tblData Is Nothing Then
                Exit Sub
            End If
            arrIDs = Split(strIDs, ",")
            Dim strResult As String = ""
            If tblData.Rows.Count > 0 Then

                'Dim itemIdDataView As DataView = tblData.DefaultView
                'itemIdDataView.RowFilter = "Field='245'"
                'Dim count As Integer = itemIdDataView.Count

                'If (count > 0) Then
                '    For i As Integer = 0 To count - 1
                '        arrIDs(i) = itemIdDataView(i).Item("ItemID")
                '    Next
                'End If


                For intCount = 0 To UBound(arrIDs)

                    strTitle = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND Field='245'"
                    If tblData.DefaultView.Count > 0 Then
                        strTitle = tblData.DefaultView(0).Item("Content") & ""
                    End If
                    strTitle = FormatNumber((intRecPerPage * (intCurPage - 1)) + intCount + 1, 0) & ". " & strTitle

                    ' get description physical
                    strDKCB = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='082'"
                    If tblData.DefaultView.Count > 0 Then
                        strDKCB = tblData.DefaultView(0).Item("Content") & ""
                    End If
                    ' get so dinh danh
                    strSoDinhDanh = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='090'"
                    If tblData.DefaultView.Count > 0 Then
                        strSoDinhDanh = tblData.DefaultView(0).Item("Content") & ""
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
                                strURL &= "<a href='" & rowView.Item("Content") & "' target='_blank' style='cursor:pointer;'><div class='icon-link'></div>URL</a>; "
                            End If
                        End If
                    Next
                    strURL = strURL.Trim
                    If strURL <> "" Then
                        strURL = strURL.Substring(0, strURL.Length - 1)
                        'Bo span danh dau highlight cac truong 0xx --> 9xx
                        strURL = Replace(strURL, "<span style=""background-color:#60a917 !important;color:white;""></span>", "")
                        strURL = Replace(strURL, "<span class=""hightlight-text""></span>", "")
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

                    'Views
                    intViews = 0
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='VIEWS'"
                    If tblData.DefaultView.Count > 0 Then
                        intViews = tblData.DefaultView(0).Item("Content")
                    End If

                    'Loai tai lieu
                    strType = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='ETYPE'"
                    If tblData.DefaultView.Count > 0 Then
                        strType = tblData.DefaultView(0).Item("Content") & ""
                    End If

                    'Thu vien
                    strLibrary = ""

                    'Tom tat cho eBooks
                    strBrief = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='BRIEF'"
                    If tblData.DefaultView.Count > 0 Then
                        strArrBrief = Split(tblData.DefaultView(0).Item("Content") & "", "@PHUONGTT@")
                        Try
                            intPageLink = strArrBrief(0)
                            'strBrief = clsUICommon.sumaryContents(strArrBrief(1), "<span style=""background-color:#60a917 !important;color:white;""><I>", 10, 50, 10, 40, , fCutContentLength)
                            strBrief = clsUICommon.sumaryContents(strArrBrief(1), "<span class=""hightlight-text"">", 10, 50, 10, 40, , fCutContentLength)

                            Dim strSearch As String = hidSearchBrowse.Value
                            strSearch = getCutVietnameseAccent(strSearch)
                            'strSearchFulltext = clsUICommon.getWordHightLight(strArrBrief(1), "<span style=""background-color:#60a917 !important;color:white;""><I>", Len(strSearch))
                            'CutContents(strArrBrief(1), "<span style=""background-color:#60a917 !important;color:white;""><I>")
                            strSearchFulltext = clsUICommon.getWordHightLight(strArrBrief(1), "<span class=""hightlight-text"">", Len(strSearch))
                        Catch ex As Exception
                        End Try
                    End If

                    'Ma xep gia
                    strMXG = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='MXG'"
                    If tblData.DefaultView.Count > 0 Then
                        Dim intCountMXG As Integer = 0
                        For Each rowView In tblData.DefaultView
                            If intCountMXG < Application("callNumberLimit") Then
                                If Not IsDBNull(rowView.Item("Content")) Then
                                    'strMXG &= "<U>" & rowView.Item("Content") & "</U>" & " "
                                    '2016.05.11 B1
                                    If Not IsNothing(Request("txtSearch")) Then
                                        If Request("txtSearch").Trim.ToLower = rowView.Item("Content").ToString.Trim.ToLower Then
                                            strMXG &= "<U>" & "<span class=""hightlight-text"">" & rowView.Item("Content") & "</span>" & "</U>" & " "
                                        Else
                                            strMXG &= "<U>" & rowView.Item("Content") & "</U>" & " "
                                        End If
                                    Else
                                        strMXG &= "<U>" & rowView.Item("Content") & "</U>" & " "
                                    End If
                                    '2016.05.11 E1
                                End If
                            Else
                                strMXG &= "<a onclick='parent.showPopupDetail(" & arrIDs(intCount) & ")' style='cursor:pointer;'>" & "<span class=' icon-arrow-right-3'/>" & "</a> "
                                Exit For
                            End If
                            intCountMXG += 1
                        Next
                    End If

                    strCover = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='COVER'"
                    If tblData.DefaultView.Count > 0 Then
                        If Not IsDBNull(tblData.DefaultView(0).Item("Content")) AndAlso tblData.DefaultView(0).Item("Content") <> "" Then
                            strCover = Me.getEDataPATH & tblData.DefaultView(0).Item("Content")
                        Else
                            strCover = "Images/Imgviet/Books.png"
                        End If
                    End If

                    'Fill data
                    If intCount Mod 2 Then
                        strResult &= "<li class=""item-second"">"
                    Else
                        strResult &= "<li>" 'Li1
                    End If
                    strResult &= "<div class=""item-box box-raised"">" 'Open Div1
                    strResult &= "<h2 class=""clr-cyan""><a onclick=""parent.showPopupDetail(" & arrIDs(intCount) & ")"" style=""cursor:pointer;"">"
                    strResult &= strTitle
                    strResult &= "</a></h2>"
                    strResult &= "<div class=""item-info ClearFix"">" 'Open Div2
                    strResult &= "<div class=""item-img col-left-3"">"
                    'strResult &= "<img src=""dbimg/s1.jpg"" alt=""Book Name""/>"
                    'strResult &= getIcons(arrIDs(intCount))
                    strResult &= "<img src='" & strCover & "' id='" & arrIDs(intCount) & "' name='" & arrIDs(intCount) & "'>"
                    strResult &= "</div>"
                    strResult &= "<div class=""item-intro col-right-7"">" 'Open Div3
                    'Thong tin tac gia
                    If strAuthor <> "" Then
                        strAuthor = strAuthor.Trim
                        strResult &= "<p><span>" & strBeginBoldTag & spAuthor.InnerText & strEndBoldTag
                        strResult &= strAuthor
                        strResult &= "</span>"
                        strResult &= "</p>"
                    End If
                    'Thong tin mo ta vat ly
                    If strDKCB <> "" Then
                        strResult &= "<p><span>" & strBeginBoldTag & spDKCBInfo.InnerText & strEndBoldTag
                        strResult &= strDKCB
                        strResult &= "</span>"
                        strResult &= "</p>"
                    End If
                    'Thong tin so dinh danh
                    If strSoDinhDanh <> "" Then
                        strResult &= "<p><span>" & strBeginBoldTag & spSoDinhDanhInfo.InnerText & strEndBoldTag
                        strResult &= strSoDinhDanh
                        strResult &= "</span>"
                        strResult &= "</p>"
                    End If
                    'Thong tin xuat ban
                    If strPublish <> "" Then
                        strResult &= "<p><span>" & strBeginBoldTag & spPublisherInfo.InnerText & strEndBoldTag
                        strResult &= strPublish
                        strResult &= "</span>"
                        strResult &= "</p>"
                    End If
                    'Loai tai lieu
                    If strType <> "" Then
                        strResult &= "<p><span>" & strBeginBoldTag & spItemType.InnerText & strEndBoldTag
                        strResult &= strType
                        strResult &= "</span>"
                        strResult &= "</p>"
                    End If
                    'Thong tin xep gia
                    If strMXG <> "" Then
                        strResult &= "<p><span>" & strBeginBoldTag & spMXG.InnerText & strEndBoldTag
                        strResult &= strMXG
                        strResult &= "</span>"
                        strResult &= "</p>"
                    End If
                    strResult &= "</div>" 'Close Div3
                    strResult &= "</div>" 'Close Div2
                    ''Thong tin URL
                    'If strURL <> "" Then
                    '    strResult &= "<p><span>" & spURL.InnerText
                    '    strResult &= strURL
                    '    strResult &= "</span>"
                    '    strResult &= "</p>"
                    'End If

                    'Du lieu dien tu
                    If strEDATA <> "" Then
                        strArr = Split(strEDATA, ";")
                        If UBound(strArr) = 3 Then
                            'strResult &= "<br/>"
                            'strResult &= "<span class='line-height'>"
                            'strResult &= "<strong>" & spEDATA.InnerText & ":</strong><a href='OViewLoading.aspx?pageno=1&fileType=" & strArr(1) & "&fileId=" & strArr(2) & "&ItemId=" & strArr(3) & "'>" & strArr(0) & spEDATAContent.InnerText & "</a>"
                            'strResult &= "</span>"
                            ''strResult &= "<br/>"
                            'strResult &= "<p><span>" & spEDATA.InnerText
                            'strResult &= strURL
                            'strResult &= "</span>"
                            'strResult &= "</p>"
                            strResult &= "<span class=""item-img col-left"">"
                            strResult &= "<span class=""popup-modul"">"
                            strResult &= "<a class=""btn-read"" href=""OViewLoading.aspx?pageno=1&fileType=" & strArr(1) & "&fileId=" & strArr(2) & "&ItemId=" & strArr(3) & """>" & strArr(0) & spEDATAContent.InnerText & "</a>"
                            strResult &= "</span>"
                            strResult &= "</span>"
                        End If
                    End If

                    'Du lieu bao in/tap chi dien tu
                    If strEMAGAZINE <> "" Then
                        strResult &= "<span class=""item-img col-left"">"
                        strResult &= "<span class=""popup-modul"">"
                        strResult &= "<a class=""btn-read"" href=""OMagList.aspx?ItemId=" & arrIDs(intCount) & """>" & strEMAGAZINE & spEDATAContent.InnerText & "</a>"
                        strResult &= "</span>"
                        strResult &= "</span>"
                    End If

                    'strResult &= "<h3><a href=""#""><span class=""mif-heart""></span>" & spSaveList.InnerText & "</a></h3>"
                    strResult &= getIcons(arrIDs(intCount))

                    'Tom tat cho eBooks
                    If strBrief <> "" Then
                        strArr = Split(strEDATA, ";")
                        If UBound(strArr) = 3 Then
                            'strResult &= "<hr />"
                            'strResult &= "<div style='text-align:justify;font-style:italic;'>"
                            'strResult &= "<a href='OViewLoading.aspx?fileType=" & strArr(1) & "&fileId=" & strArr(2) & "&ItemId=" & strArr(3) & "&pageno=" & intPageLink & "&fulltext=" & strSearchFulltext & "'>" & spPageLink.InnerHtml & Space(1) & intPageLink & "</a>&nbsp;" & strBrief
                            'strResult &= "</div>"
                            strResult &= "<div class=""search-item""><p>"
                            strResult &= "<a href='OViewLoading.aspx?fileType=" & strArr(1) & "&fileId=" & strArr(2) & "&ItemId=" & strArr(3) & "&pageno=" & intPageLink & "&fulltext=" & strSearchFulltext & "'>" & spPageLink.InnerHtml & Space(1) & intPageLink & "</a>&nbsp;" & strBrief
                            strResult &= "</p></div>"
                        End If
                    End If

                    ''Thu vien muc luc lien hop
                    If strLibrary <> "" Then
                        strResult &= "<div style=""text-align:center;""><p>"
                        strResult &= "<span class='mif-layers mif-2x fg-emerald'></span>&nbsp;" & strLibrary
                        strResult &= "</p></div>"
                    End If

                    strResult &= "<div class=""more-detail ClearFix"">" 'Open Div4
                    strResult &= "<div class=""col-left-4 class"">" 'Open Div5

                    'strResult &= "<div class=""info-star"">" 'Open Div6
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
                    ''strResult &= "<span class=""icon-star-" & strRANKING & """></span><span class=""icon-star-" & strRANKING & """></span><span class=""icon-star-" & strRANKING & """></span>"
                    ''strResult &= "<span class=""icon-star""></span><span class=""icon-star""></span>"
                    'strResult &= "</div>" 'Close Div6

                    strResult &= "<div style=""vertical-align:top;text-align:center"" class=""rating"" data-size=""small"" data-role=""rating"" data-value=""" & strRANKING & """ data-static=""true"" data-show-score=""false"" data-size=""small""></div>"

                    strResult &= "</div>" 'Close Div5
                    'Randomize()
                    'intViewRandom = Int(10000 * Rnd(1) + 1)
                    'strResult &= "<div class=""col-right-6 view""><span class=""icon-eye-2""></span>" & FormatNumber(intViewRandom, 0) & "</div>"
                    strResult &= "<div class=""col-right-6 view""><span class=""icon-eye-2""></span>" & FormatNumber(intViews, 0) & "</div>"
                    strResult &= "</div>" 'Close Div4                    
                    strResult &= "</div>" 'Close Div1
                    strResult &= "</li>" 'Close Li1

                    'strResult &= "<div class='panel-header'>"
                    'strResult &= "<a onclick='parent.showPopupDetail(" & arrIDs(intCount) & ")' class='lblinkfunction' style='cursor:pointer;'>" & strTitle & "</a> "
                    'strResult &= getIcons(arrIDs(intCount))
                    'strResult &= "</div>"
                    'strResult &= "<div class='panel-content'>"

                    'strResult &= "<div class='grid no-margin'>"
                    'strResult &= "<div class='row'>"

                    'strResult &= "<div class='span2'>"
                    '' strResult &= "<div class='notice  marker-on-right'>"
                    ''Anh Bia
                    'strResult &= "<div>"
                    'strCover = ""
                    'tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='COVER'"
                    'If tblData.DefaultView.Count > 0 Then
                    '    If Not IsDBNull(tblData.DefaultView(0).Item("Content")) AndAlso tblData.DefaultView(0).Item("Content") <> "" Then
                    '        strCover = Me.getEDataPATH & tblData.DefaultView(0).Item("Content")
                    '    Else
                    '        strCover = "Images/Imgviet/Books.png"
                    '    End If
                    'End If
                    'strResult &= "<img src='" & strCover & "' class='rounded' id='" & arrIDs(intCount) & "' name='" & arrIDs(intCount) & "' style='z-index:1001;cursor:pointer;' onclick='parent.showPopupDetail(" & arrIDs(intCount) & ")'>"
                    'strResult &= "</div>"
                    ''strResult &= "</div>"
                    'strResult &= "</div>"

                    'strResult &= "<div class='span10'>"
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
                    ''Thong tin mo ta vat ly
                    'If strDKCB <> "" Then
                    '    strResult &= "<span class='line-height'>"
                    '    strResult &= "<strong>" & spPhysicalInfo.InnerText & ":</strong> " & strDKCB
                    '    strResult &= "</span>"
                    '    strResult &= "<br/>"
                    'End If
                    ''Thong tin xuat ban
                    'If strPublish <> "" Then
                    '    strResult &= "<span class='line-height'>"
                    '    strResult &= "<strong>" & spPublisherInfo.InnerText & ":</strong> " & strPublish
                    '    strResult &= "</span>"
                    '    strResult &= "<br/>"
                    'End If

                    ''Loai tai lieu
                    'If strType <> "" Then
                    '    strResult &= "<span class='line-height'>"
                    '    strResult &= "<strong>" & spItemType.InnerText & ":</strong> " & strType
                    '    strResult &= "</span>"
                    '    strResult &= "<br/>"
                    'End If

                    ''strMXG
                    'If strMXG <> "" Then
                    '    strResult &= "<span class='line-height'>"
                    '    strResult &= "<strong>" & spMXG.InnerText & ":</strong> " & strMXG
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
                    '    strArr = Split(strEDATA, ";")
                    '    If UBound(strArr) = 3 Then
                    '        strResult &= "<br/>"
                    '        strResult &= "<span class='line-height'>"
                    '        strResult &= "<strong>" & spEDATA.InnerText & ":</strong><a href='OViewLoading.aspx?pageno=1&fileType=" & strArr(1) & "&fileId=" & strArr(2) & "&ItemId=" & strArr(3) & "'>" & strArr(0) & spEDATAContent.InnerText & "</a>"
                    '        strResult &= "</span>"
                    '        'strResult &= "<br/>"
                    '    End If
                    'End If

                    ''Du lieu bao in/tap chi dien tu
                    'If strEMAGAZINE <> "" Then
                    '    strResult &= "<br/>"
                    '    strResult &= "<span class='line-height'>"
                    '    strResult &= "<strong>" & spEDATA.InnerText & ":</strong><a href='OMagList.aspx?ItemId=" & arrIDs(intCount) & "'>" & strEMAGAZINE & spEDATAContent.InnerText & "</a>"
                    '    strResult &= "</span>"
                    '    'strResult &= "<br/>"
                    'End If

                    ''Ranking
                    'If strRANKING <> "" Then
                    '    strResult &= "<br/>"
                    '    strResult &= "<div class='rating  fg-green small' data-role='rating' data-static='true' data-score='" & strRANKING & "'  data-stars='5' data-show-score='false' style='cursor:default;' >"
                    '    strResult &= "</div>"
                    'End If

                    ''Thu vien muc luc lien hop
                    'If strLibrary <> "" Then
                    '    strResult &= "<br/>"
                    '    strResult &= "<span class='line-height'>"
                    '    strResult &= "<i class='icon-layers'></i>&nbsp;<B><I>" & strLibrary & "</I></B>"
                    '    strResult &= "</span>"
                    'End If

                    ''Tom tat cho eBooks
                    'If strBrief <> "" Then
                    '    strArr = Split(strEDATA, ";")
                    '    If UBound(strArr) = 3 Then
                    '        strResult &= "<hr />"
                    '        strResult &= "<div style='text-align:justify;font-style:italic;'>"
                    '        strResult &= "<a href='OViewLoading.aspx?fileType=" & strArr(1) & "&fileId=" & strArr(2) & "&ItemId=" & strArr(3) & "&pageno=" & intPageLink & "&fulltext=" & strSearchFulltext & "'>" & spPageLink.InnerHtml & Space(1) & intPageLink & "</a>&nbsp;" & strBrief
                    '        strResult &= "</div>"
                    '    End If
                    'End If

                    'strResult &= "</div>" 'div span10
                    'strResult &= "</div>" 'div grid no-margin
                    'strResult &= "</div>" 'div row
                    'strResult &= "</div>" 'div panel-content
                Next
                ltrList.Text = strResult
            End If
        End Sub

        ' purpose :  show order by control
        ' Creator: phuongtt
        Private Sub showOrderByControl(ByVal intCurPage As Integer)
            Dim strResult As String = ""
            Try
                'strResult &= "<ul class=""split-content d-menu place-right"" data-role=""dropdown"">"
                Select Case UCase(clsSession.GlbBrowseOrderBy)
                    Case "A-Z"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'A-Z')""><span runat='server' class='icon-radio-checked'>&nbsp;&nbsp;" & spOrderAZ.InnerText & "</span></a></li>"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'Z-A')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spOrderZA.InnerText & "</span></a></li>"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'A-Z-RQ')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spOrderAZRQ.InnerText & "</span></a></li>"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'Z-A-RQ')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spOrderZARQ.InnerText & "</span></a></li>"
                        strResult &= "<select onChange=""showRecordOrderBy(" & intCurPage.ToString & ",this)"">"
                        strResult &= "<option value="""">" & spOrderBy.InnerText & "</option>"
                        strResult &= "<option selected value=""A-Z"">" & spOrderAZ.InnerText & "</option>"
                        strResult &= "<option value=""Z-A"">" & spOrderZA.InnerText & "</option>"
                        strResult &= "<option value=""A-Z-RQ"">" & spOrderAZRQ.InnerText & "</option>"
                        strResult &= "<option value=""Z-A-RQ"">" & spOrderZARQ.InnerText & "</option>"
                        strResult &= "</select>"
                    Case "Z-A"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'A-Z')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spOrderAZ.InnerText & "</span></a></li>"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'Z-A')""><span runat='server' class='icon-radio-checked'>&nbsp;&nbsp;" & spOrderZA.InnerText & "</span></a></li>"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'A-Z-RQ')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spOrderAZRQ.InnerText & "</span></a></li>"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'Z-A-RQ')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spOrderZARQ.InnerText & "</span></a></li>"
                        strResult &= "<select onChange=""showRecordOrderBy(" & intCurPage.ToString & ",this)"">"
                        strResult &= "<option value="""">" & spOrderBy.InnerText & "</option>"
                        strResult &= "<option value=""A-Z"">" & spOrderAZ.InnerText & "</option>"
                        strResult &= "<option selected value=""Z-A"">" & spOrderZA.InnerText & "</option>"
                        strResult &= "<option value=""A-Z-RQ"">" & spOrderAZRQ.InnerText & "</option>"
                        strResult &= "<option value=""Z-A-RQ"">" & spOrderZARQ.InnerText & "</option>"
                        strResult &= "</select>"
                    Case "A-Z-RQ"
                        '    'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'A-Z')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spOrderAZ.InnerText & "</span></a></li>"
                        '    'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'Z-A')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spOrderZA.InnerText & "</span></a></li>"
                        '    'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'A-Z-RQ')""><span runat='server' class='icon-radio-checked'>&nbsp;&nbsp;" & spOrderAZRQ.InnerText & "</span></a></li>"
                        '    'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'Z-A-RQ')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spOrderZARQ.InnerText & "</span></a></li>"
                        'Case "Z-A-RQ"
                        '    strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'A-Z')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spOrderAZ.InnerText & "</span></a></li>"
                        '    strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'Z-A')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spOrderZA.InnerText & "</span></a></li>"
                        '    strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'A-Z-RQ')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spOrderAZRQ.InnerText & "</span></a></li>"
                        '    strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'Z-A-RQ')""><span runat='server' class='icon-radio-checked'>&nbsp;&nbsp;" & spOrderZARQ.InnerText & "</span></a></li>"
                        strResult &= "<select onChange=""showRecordOrderBy(" & intCurPage.ToString & ",this)"">"
                        strResult &= "<option value="""">" & spOrderBy.InnerText & "</option>"
                        strResult &= "<option value=""A-Z"">" & spOrderAZ.InnerText & "</option>"
                        strResult &= "<option value=""Z-A"">" & spOrderZA.InnerText & "</option>"
                        strResult &= "<option selected value=""A-Z-RQ"">" & spOrderAZRQ.InnerText & "</option>"
                        strResult &= "<option value=""Z-A-RQ"">" & spOrderZARQ.InnerText & "</option>"
                        strResult &= "</select>"
                    Case "Z-A-RQ"
                        strResult &= "<select onChange=""showRecordOrderBy(" & intCurPage.ToString & ",this)"">"
                        strResult &= "<option value="""">" & spOrderBy.InnerText & "</option>"
                        strResult &= "<option value=""A-Z"">" & spOrderAZ.InnerText & "</option>"
                        strResult &= "<option value=""Z-A"">" & spOrderZA.InnerText & "</option>"
                        strResult &= "<option value=""A-Z-RQ"">" & spOrderAZRQ.InnerText & "</option>"
                        strResult &= "<option selected value=""Z-A-RQ"">" & spOrderZARQ.InnerText & "</option>"
                        strResult &= "</select>"
                    Case Else
                        strResult &= "<select onChange=""showRecordOrderBy(" & intCurPage.ToString & ",this)"">"
                        strResult &= "<option selected value="""">" & spOrderBy.InnerText & "</option>"
                        strResult &= "<option value=""A-Z"">" & spOrderAZ.InnerText & "</option>"
                        strResult &= "<option value=""Z-A"">" & spOrderZA.InnerText & "</option>"
                        strResult &= "<option value=""A-Z-RQ"">" & spOrderAZRQ.InnerText & "</option>"
                        strResult &= "<option value=""Z-A-RQ"">" & spOrderZARQ.InnerText & "</option>"
                        strResult &= "</select>"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'A-Z')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spOrderAZ.InnerText & "</span></a></li>"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'Z-A')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spOrderZA.InnerText & "</span></a></li>"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'A-Z-RQ')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spOrderAZRQ.InnerText & "</span></a></li>"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'Z-A-RQ')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spOrderZARQ.InnerText & "</span></a></li>"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'A-Z')"">" & spOrderAZ.InnerText & "</a></li>"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'Z-A')"">" & spOrderZA.InnerText & "</a></li>"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'A-Z-RQ')"">" & spOrderAZRQ.InnerText & "</a></li>"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'Z-A-RQ')"">" & spOrderZARQ.InnerText & "</a></li>"
                End Select
                'strResult &= "</ul>"
            Catch ex As Exception
            End Try
            ltrOrderBy.Text = strResult

            If strResult Is Nothing Or strResult = "" Then

                divOrderBy.Visible = False

            End If
        End Sub

        ' purpose :  show paging as google paging
        ' Creator: phuongtt
        Private Sub showPagingControl(ByVal intCount As Integer, ByVal intPagezise As Integer, ByVal intPage As Integer, ByVal intPageSpace As Integer, ByVal intPageLength As Integer, ByVal intStop As Integer, Optional ByVal intSumPage As Integer = 0)
            Try
                Dim iPage As Integer = CInt((intCount / intPagezise) + 0.4999)
                Dim strPagination As String = ""
                Dim PreviousPage As Integer = intPage - 1
                Dim NextPage As Integer = intPage + 1
                If PreviousPage >= 1 Then
                    'strPagination &= "<li><a onclick='showRecord(" & PreviousPage.ToString & ")' data-hint='|" & spPreviousPage.InnerText & "' data-hint-position='top' style='cursor:pointer;'><</a></li>"
                    strPagination &= "<li><a onclick='showRecord(" & 1 & ")' data-role='hint' data-hint-background='bg-blue' data-hint-color='fg-white'  data-hint='|" & spFirstPage.InnerText & "' data-hint-position='top' style='cursor:pointer;'>|<</a></li>"
                    strPagination &= "<li><a onclick='showRecord(" & PreviousPage.ToString & ")'  data-role='hint' data-hint-background='bg-blue' data-hint-color='fg-white'  data-hint='|" & spPreviousPage.InnerText & "' data-hint-position='top' style='cursor:pointer;'><</a></li>"
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
                    strPagination &= "<li><a onclick='showRecord(" & NextPage.ToString & ")'  data-role='hint' data-hint-background='bg-blue' data-hint-color='fg-white'  data-hint='|" & spNextPage.InnerText & "' data-hint-position='top'  style='cursor:pointer;'>></a></li>"
                End If
                If intSumPage > iPageCount Then
                    strPagination &= "<li><a onclick='showRecord(" & intSumPage.ToString & ")' data-role='hint' data-hint-background='bg-blue' data-hint-color='fg-white'  data-hint='|" & spLastPage.InnerText & "' data-hint-position='top' style='cursor:pointer;'>>|</a></li>"
                End If
                lrtPagination1.Text = strPagination
                lrtPagination2.Text = strPagination

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
                lrtPagination1.Text &= strItemInfo
                lrtPagination2.Text &= strItemInfo
            Catch ex As Exception
            End Try
        End Sub


        ' raiseShowRecord_Click method
        ' Purpose: show record by click of page
        Private Sub raiseShowRecord_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles raiseShowRecord.Click
            Try
                Dim intCurrenPage As Integer = hidCurrentPage.Value
                Dim dv As DataView = Nothing
                If Not IsNothing(clsSession.GlbBrowseIds) Then
                    dv = clsSession.GlbBrowseIds
                Else
                    dv = clsSession.GlbBrowseIds
                End If
                Dim intDicID As Integer = 0
                If Not IsNothing(Session("DicID")) Then
                    intDicID = Session("DicID")
                End If
                Dim strDicName As String = ""
                Dim strIconCss As String = ""
                Select Case intDicID
                    Case 1  'Author
                        strIconCss = " class=""mif-users"" "
                        strDicName = spAuthor.InnerText
                    Case 2 'publisher
                        strIconCss = " class=""mif-bookmark"" "
                        strDicName = spPublisher.InnerText
                    Case 3 'Keyword
                        strIconCss = " class=""mif-target"" "
                        strDicName = spKeyWord.InnerText
                    Case 4 'Series
                        strIconCss = " class=""mif-shareable"" "
                        strDicName = spKeyWord.InnerText
                    Case 5 'Subjectheading
                        strIconCss = " class=""mif-tag"" "
                        strDicName = spSubjectheading.InnerText
                    Case 9 'publisher year
                        strIconCss = " class=""mif-calendar"" "
                        strDicName = spPublisherYear.InnerText
                    Case 12 'DDC
                        'strDicName = spAuthor.InnerText
                End Select
                ltrList.Text = getDictionaryString(intDicID, strDicName, dv, strIconCss)
            Catch ex As Exception
            End Try
        End Sub

        ' raiseOrderBy_Click method
        ' Purpose: order by reocrd
        Private Sub raiseOrderBy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles raiseOrderBy.Click
            Try
                clsSession.GlbBrowseOrderBy = hidOrderBy.Value
                Call BindData(Session("DicID"), Session("Word"))
            Catch ex As Exception
            End Try
        End Sub

        ' btSubmitBrowse_Click method
        ' Purpose: filter browse
        Private Sub btSubmitBrowse_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btSubmitBrowse.Click
            Try
                If hidSearchBrowse.Value.Trim <> "" Then
                    'hidCurrentPage.Value = 1
                    'Session("Word") = hidSearchBrowse.Value
                    'Call BindData(Session("DicID"), Session("Word"))
                    Response.Redirect("Oshow.aspx?rdSearchOption=0&txtSearch=" & hidSearchBrowse.Value.Trim() & "&TypeSearch=" & hidTypeSearch.Value)
                End If
            Catch ex As Exception
            End Try
        End Sub

        ' Init method
        ' purpose initialize all components
        Private Sub Initialize()

            ' Init objBHoldingInfo object
            objBFilterBrowse.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBFilterBrowse.DBServer = Session("DBServer")
            objBFilterBrowse.ConnectionString = Session("ConnectionString")
            Call objBFilterBrowse.Initialize()

            '  Init objBCommonStringProc
            objBCommonStringProc.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBCommonStringProc.ConnectionString = Session("ConnectionString")
            objBCommonStringProc.DBServer = Session("DBServer")
            objBCommonStringProc.Initialize()

            ' init OPACItem object
            objBOpacItem.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBOpacItem.DBServer = Session("DBServer")
            objBOpacItem.ConnectionString = Session("ConnectionString")
            objBOpacItem.Initialize()
        End Sub
        ' BindScript method
        ' Purpose: Bind JAVASCRIPTS
        Private Sub BindScript()
            'Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'js/OBrowse.js'></script>")
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub
        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCommonStringProc Is Nothing Then
                    objBCommonStringProc.Dispose(True)
                    objBCommonStringProc = Nothing
                End If
                If Not objBFilterBrowse Is Nothing Then
                    objBFilterBrowse.Dispose(True)
                    objBFilterBrowse = Nothing
                End If
                If Not objBOpacItem Is Nothing Then
                    objBOpacItem.Dispose(True)
                    objBOpacItem = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace
