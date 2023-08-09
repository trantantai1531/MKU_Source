Imports System.IO
Imports System.IO.Path
Imports System.Xml
Imports eMicLibOPAC.BusinessRules.OPAC
Imports eMicLibOPAC.BusinessRules.Common

Namespace eMicLibOPAC.WebUI
    Public Class OView
        Inherits clsWBaseJqueryUI

        Private objBOPACFile As New clsBOPACFile
        Private objBOpacItem As New clsBOPACItem
        Private objBSearchResult As New clsBOPACSearchResult
        Private objBOPACDictionary As New clsBOPACDictionary
        Private objBOPACComment As New clsBOPACComment
        Private objBFilterBrowse As New clsBOPACFilterBrowse
        Private objBCommonStringProc As New clsBCommonStringProc

        Private intFileId As Integer = 0
        Private intSubjectId As Integer = 0
        Private intItemID As Integer = 0
        Dim intFileType As Integer = 0

        Dim strTitle As String = ""
        Dim strCoverPicture As String = ""
        Dim strMainTitle As String = ""
        Private strBeginBoldTag As String = "<b>"
        Private strEndBoldTag As String = ":&nbsp;</b>"

        Protected Shared fGlbUserViewOfDoc As Integer = 0
        Protected Shared fDownload As Integer = 0

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call checkPermission()
            Call Initialize()
            Call BindScript()
            Call getMyListItems()
            If Not IsNothing(Request("fileId")) AndAlso Request("fileId") <> "" Then
                intFileId = Request("fileId")
            End If
            If Not IsNothing(Request("ItemID")) AndAlso Request("ItemID") <> "" Then
                intItemID = Request("ItemID")
            End If
            If Not IsNothing(Request("fileType")) AndAlso Request("fileType") <> "" Then
                intFileType = Request("fileType")
            End If
            hidItemID.Value = intItemID
            If intFileId Then
                If Not IsPostBack Then
                    fGlbUserViewOfDoc = 100 'clsSession.GlbUserViewOfDoc
                    fDownload = 100 'clsSession.GlbUserDownloadOfDoc

                    Call showDetail(intFileId, intItemID, intFileType)
                End If
            End If
        End Sub

        Private Sub checkPermission()
            Try
                Dim fileId As Integer = 0
                Dim pageno As Integer = 0
                Dim ItemID As Integer = 0
                Dim fileType As Integer = 0
                Dim fulltext As String = ""
                Dim subjectId As Integer = 0
                Dim search As Integer = 0
                Dim collectionIds As String = "0"
                If Not IsNothing(Request("search")) AndAlso Request("search") <> "" Then
                    search = Request("search")
                End If
                If Not IsNothing(Request("fileId")) AndAlso Request("fileId") <> "" Then
                    fileId = Request("fileId")
                End If
                If Not IsNothing(Request("pageno")) AndAlso Request("pageno") <> "" Then
                    pageno = Request("pageno")
                End If
                If Not IsNothing(Request("ItemID")) AndAlso Request("ItemID") <> "" Then
                    ItemID = Request("ItemID")
                End If
                If Not IsNothing(Request("fileType")) AndAlso Request("fileType") <> "" Then
                    fileType = Request("fileType")
                End If
                If Not IsNothing(Request("fulltext")) AndAlso Request("fulltext") <> "" Then
                    fulltext = Request("fulltext")
                End If
                If Not IsNothing(Request("subjectId")) AndAlso Request("subjectId") <> "" Then
                    subjectId = Request("subjectId")
                End If
                If Not IsNothing(Request("collectionId")) AndAlso Request("collectionId") <> "" Then
                    collectionIds = Request("collectionId")
                End If
                If Not clsUICommon.checkPermission() Then
                    Dim collViewer As New Collection
                    With collViewer
                        .Add(search, "search")
                        .Add(fileId, "fileId")
                        .Add(pageno, "pageno")
                        .Add(ItemID, "ItemID")
                        .Add(fileType, "fileType")
                        .Add(fulltext, "fulltext")
                        .Add(subjectId, "subjectId")
                        .Add(collectionIds, "collectionId")
                    End With
                    clsSession.GlbViewerCollection = collViewer
                    Response.Redirect("OLoginRequest.aspx?viewer=1", False)
                End If
            Catch ex As Exception
            End Try
        End Sub

        ' Init method
        ' purpose initialize all components
        Private Sub Initialize()
            ' Init objBOPACItem object
            objBOPACFile.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBOPACFile.DBServer = Session("DBServer")
            objBOPACFile.ConnectionString = Session("ConnectionString")
            Call objBOPACFile.Initialize()

            '  Init objBCommonStringProc
            objBCommonStringProc.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBCommonStringProc.ConnectionString = Session("ConnectionString")
            objBCommonStringProc.DBServer = Session("DBServer")
            objBCommonStringProc.Initialize()

            objBOpacItem.ConnectionString = Session("ConnectionString")
            objBOpacItem.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBOpacItem.DBServer = Session("DBServer")
            objBOpacItem.Initialize()

            ' init objBSearchQr object
            objBSearchResult.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBSearchResult.DBServer = Session("DBServer")
            objBSearchResult.ConnectionString = Session("ConnectionString")
            objBSearchResult.Initialize()


            '  Init objBOPACDictionary
            objBOPACDictionary.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBOPACDictionary.ConnectionString = Session("ConnectionString")
            objBOPACDictionary.DBServer = Session("DBServer")
            objBOPACDictionary.Initialize()

            ' Init objBOPACRasterMap object
            objBOPACComment.DBServer = Session("DBServer")
            objBOPACComment.ConnectionString = Session("ConnectionString")
            objBOPACComment.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBOPACComment.Initialize()

            ' Init objBHoldingInfo object
            objBFilterBrowse.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBFilterBrowse.DBServer = Session("DBServer")
            objBFilterBrowse.ConnectionString = Session("ConnectionString")
            Call objBFilterBrowse.Initialize()
        End Sub


        Private Sub showDetail(ByVal FileId As Integer, ByVal ItemId As Integer, ByVal FileType As Integer, Optional ByVal intComment As Integer = 0, Optional ByVal bolPage As Boolean = False)
            Try
                Dim tblTmp As New DataTable
                objBOPACFile.ItemID = ItemId
                tblTmp = objBOPACFile.GetFileDetail
                If Not IsNothing(tblTmp) AndAlso tblTmp.Rows.Count > 0 Then
                    Dim intItemID As Integer = 0
                    intItemID = tblTmp.Rows(0).Item("ItemID")

                    Dim strSearchText As String = ""
                    'Cap nhat luot truy cap tai lieu
                    Call updateViews(intItemID)
                    'Lay tai lieu lien quan: 1:Author, 3:KeyWord, 5 'Subjectheading,2 'publisher,  7 'NLM,4 'Series,6 'Language,8 'DDC
                    Dim DicID As Integer = clsSession.GlbClassification
                    Dim strAccessEntry As String = tblTmp.Rows(0).Item("AccessEntry")
                    Call getRelation(DicID, strAccessEntry, intItemID)

                    If Not IsDBNull(tblTmp.Rows(0).Item("Author")) Then
                        'Lay tai lieu lien quan cung tac gia
                        DicID = 1
                        strAccessEntry = tblTmp.Rows(0).Item("Author")
                        Call getRelationByAuthor(DicID, strAccessEntry, intItemID)
                    End If

                    'Hien thi comment
                    Call BindCommentBook(intItemID)

                    'Dim strBook As String = ""
                    'Dim strCover As String = ""
                    'If Not IsDBNull(tblTmp.Rows(0).Item("CoverPicture")) AndAlso tblTmp.Rows(0).Item("CoverPicture") <> "" Then
                    '    strCover = Me.getEDataPATH & tblTmp.Rows(0).Item("CoverPicture")
                    'Else
                    '    strCover = "Images/Imgviet/Books.png"
                    'End If
                    'strBook &= "<div  class='span3'>"
                    'strBook &= "<img src='" & strCover & "' class='rounded'/>"
                    'strBook &= "</div>"

                    'If Not IsDBNull(tblTmp.Rows(0).Item("Content")) Then
                    '    strTitle = tblTmp.Rows(0).Item("Content")
                    'End If
                    'strBook &= "<div  class='span9'>"
                    'strBook &= "<span class='line-height'>"
                    'strBook &= "<strong>" & strTitle & "</strong> "
                    'strBook &= "</span>"
                    'strBook &= "</div>"
                    'ltrBook.Text = strBook
                    If Not IsDBNull(tblTmp.Rows(0).Item("CoverPicture")) AndAlso tblTmp.Rows(0).Item("CoverPicture") <> "" Then
                        strCoverPicture = Me.getEDataPATH & tblTmp.Rows(0).Item("CoverPicture")
                    Else
                        strCoverPicture = "Images/Imgviet/Books.png"
                    End If
                    If Not IsDBNull(tblTmp.Rows(0).Item("Content")) Then
                        strMainTitle = tblTmp.Rows(0).Item("Content")
                        strTitle = strMainTitle
                        lbltitle.Text = strTitle
                    End If

                    'Thong tin muc tu truy cap
                    Call BindRelationWordInfor(ItemId)


                    Dim strTitleType As String = "<a class='heading bg-lightBlue fg-white' href='#' style='cursor:default;'  data-action='none'>"
                    Select Case FileType
                        Case clsUICommon.gFileType.eSound
                            strTitleType &= "<div class='icon-volume-2'></div>"
                            strTitleType &= spAudiobook.InnerText

                            Dim _fileId() As Integer = Nothing
                            Dim _FileMp3() As String = Nothing
                            Dim _Description() As String = Nothing
                            For i As Integer = 0 To tblTmp.Rows.Count - 1
                                ReDim Preserve _fileId(i)
                                _fileId(i) = tblTmp.Rows(i).Item("ID")
                                ReDim Preserve _FileMp3(i)
                                _FileMp3(i) = ""
                                If Not IsDBNull(tblTmp.Rows(i).Item("XMLpath")) Then
                                    _FileMp3(i) = tblTmp.Rows(i).Item("XMLpath")
                                End If
                                ReDim Preserve _Description(i)
                                _Description(i) = ""
                                If Not IsNothing(tblTmp.Rows(i).Item("Description")) Then
                                    _Description(i) = tblTmp.Rows(i).Item("Description")
                                End If
                            Next
                            'Hien thi sach noi
                            Call writeViewerForAudioBook(_fileId, _FileMp3, _Description, intComment, bolPage)
                        Case clsUICommon.gFileType.ePicture
                            strTitleType &= "<div class='icon-pictures'></div>"
                            strTitleType &= spPicture.InnerText

                            Dim _fileId() As Integer = Nothing
                            Dim _FilePicture() As String = Nothing
                            Dim _ThumImage() As String = Nothing
                            Dim _Description() As String = Nothing
                            For i As Integer = 0 To tblTmp.Rows.Count - 1
                                ReDim Preserve _fileId(i)
                                _fileId(i) = tblTmp.Rows(i).Item("ID")

                                ReDim Preserve _FilePicture(i)
                                _FilePicture(i) = ""
                                If Not IsDBNull(tblTmp.Rows(i).Item("XMLpath")) Then
                                    _FilePicture(i) = tblTmp.Rows(i).Item("XMLpath")
                                End If
                                ReDim Preserve _ThumImage(i)
                                _ThumImage(i) = ""
                                If Not IsDBNull(tblTmp.Rows(i).Item("Thumnail")) Then
                                    _ThumImage(i) = tblTmp.Rows(i).Item("Thumnail")
                                End If
                                ReDim Preserve _Description(i)
                                _Description(i) = ""
                                If Not IsNothing(tblTmp.Rows(i).Item("Description")) Then
                                    _Description(i) = tblTmp.Rows(i).Item("Description")
                                End If
                            Next
                            'Hien thi hinh anh
                            Call writeViewerForPicture(_fileId, _FilePicture, _ThumImage, _Description, intComment, bolPage)
                        Case clsUICommon.gFileType.eMedia
                            strTitleType &= "<div class='icon-film'></div>"
                            strTitleType &= spMedia.InnerText

                            Dim _fileId() As Integer = Nothing
                            Dim _FileMedia() As String = Nothing
                            Dim _ThumImage() As String = Nothing
                            Dim _Description() As String = Nothing
                            For i As Integer = 0 To tblTmp.Rows.Count - 1
                                ReDim Preserve _fileId(i)
                                _fileId(i) = tblTmp.Rows(i).Item("ID")

                                ReDim Preserve _FileMedia(i)
                                _FileMedia(i) = ""
                                If Not IsDBNull(tblTmp.Rows(i).Item("XMLpath")) Then
                                    _FileMedia(i) = tblTmp.Rows(i).Item("XMLpath")
                                End If
                                ReDim Preserve _ThumImage(i)
                                _ThumImage(i) = ""
                                If Not IsDBNull(tblTmp.Rows(i).Item("Thumnail")) Then
                                    _ThumImage(i) = tblTmp.Rows(i).Item("Thumnail")
                                End If
                                ReDim Preserve _Description(i)
                                _Description(i) = ""
                                If Not IsNothing(tblTmp.Rows(i).Item("Description")) Then
                                    _Description(i) = tblTmp.Rows(i).Item("Description")
                                End If
                            Next
                            'Hien thi phim anh
                            Call writeViewerForMedia(_fileId, _FileMedia, _ThumImage, _Description, intComment, bolPage)


                        Case Else
                            Response.Redirect("OError.aspx")
                    End Select
                    strTitleType &= "</a>"
                    'ltrTitle.Text = strTitleType
                End If
            Catch ex As Exception
            End Try
        End Sub

        'Private Sub BindRelationWordInfor(ByVal ItemId As Integer)
        '    Try
        '        ltrRelationWord.Text = ""
        '        Dim tblAccEn As DataTable = Nothing
        '        Dim tblAuthor As New DataTable
        '        objBFilterBrowse.ItemID = ItemId
        '        tblAccEn = objBFilterBrowse.getRelatedWords
        '        Dim strResult As String = ""
        '        Dim strAuthor As String = ""
        '        Dim strNLM As String = ""
        '        Dim strDDC As String = ""
        '        Dim strseries As String = ""
        '        Dim strKeyWord As String = ""
        '        Dim strSH As String = ""
        '        If Not IsNothing(tblAccEn) AndAlso tblAccEn.Rows.Count > 0 Then
        '            strResult &= "<BR />"
        '            strResult &= "<div class='panel-header bg-lightBlue fg-white'>"
        '            strResult &= "<span class='icon-info-2'>&nbsp;</span>" & spRelatedWord.InnerText
        '            strResult &= "</div>"
        '            strResult &= "<div class='panel-content'>"
        '            strResult &= "<div class='grid no-margin'>"

        '            Dim intCount As Integer = 0
        '            tblAccEn.DefaultView.RowFilter = "DicType=1" 'Author
        '            If tblAccEn.DefaultView.Count > 0 Then
        '                For intCount = 0 To tblAccEn.DefaultView.Count - 1
        '                    strAuthor = strAuthor & "<a style='cursor:pointer;' onclick=""gotoShowRecord(" & tblAccEn.DefaultView(intCount).Item("DicType") & "," & tblAccEn.DefaultView(intCount).Item("ID") & ")"">" & tblAccEn.DefaultView(intCount).Item("DisplayEntry") & "</A>, "
        '                Next
        '                If strAuthor <> "" Then
        '                    strAuthor = Left(strAuthor, Len(strAuthor) - 2)
        '                End If

        '                tblAuthor = objBOpacItem.GetAcessEntryAuthor(tblAccEn.DefaultView(0).Item("AccessEntry"))
        '                If tblAuthor.Rows.Count > 0 Then
        '                    strAuthor = strAuthor & " (see also "
        '                    For intCount = 0 To tblAuthor.Rows.Count - 1
        '                        If intCount = 0 Then
        '                            strAuthor = strAuthor & "<a style='cursor:pointer;' onclick=""gotoShowRecord(" & tblAccEn.DefaultView(intCount).Item("DicType") & "," & tblAccEn.DefaultView(intCount).Item("ID") & ")"">" & tblAuthor.Rows(intCount).Item("DisplayEntry") & "</A>"
        '                        Else
        '                            strAuthor = strAuthor & "," & "<a style='cursor:pointer;' onclick=""gotoShowRecord(" & tblAccEn.DefaultView(intCount).Item("DicType") & "," & tblAccEn.DefaultView(intCount).Item("ID") & ")"">" & tblAuthor.Rows(intCount).Item("DisplayEntry") & "</A>"
        '                        End If
        '                    Next
        '                    strAuthor = strAuthor & " )"
        '                End If
        '                strResult &= "<div class='row'>"
        '                strResult &= "<div class='span3'>"
        '                strResult &= "<p>"
        '                strResult &= "<span class='item-title-secondary'>" & spAuthor.InnerText & "</span>"
        '                strResult &= "</p>"
        '                strResult &= "</div>"
        '                strResult &= "<div class='span7'>"
        '                strResult &= strAuthor
        '                strResult &= "</div>" 'div span7
        '                strResult &= "</div>" 'div row
        '            End If

        '            tblAccEn.DefaultView.RowFilter = "DicType=3" 'Keyword
        '            If tblAccEn.DefaultView.Count > 0 Then
        '                For intCount = 0 To tblAccEn.DefaultView.Count - 1
        '                    strKeyWord = strKeyWord & "<a style='cursor:pointer;' onclick=""gotoShowRecord(" & tblAccEn.DefaultView(intCount).Item("DicType") & "," & tblAccEn.DefaultView(intCount).Item("ID") & ")"">" & tblAccEn.DefaultView(intCount).Item("DisplayEntry") & "</A>, "
        '                Next
        '                If strKeyWord <> "" Then
        '                    strKeyWord = Left(strKeyWord, Len(strKeyWord) - 2)
        '                End If

        '                strResult &= "<div class='row'>"
        '                strResult &= "<div class='span3'>"
        '                strResult &= "<p>"
        '                strResult &= "<span class='item-title-secondary'>" & spKeyword.InnerText & "</span>"
        '                strResult &= "</p>"
        '                strResult &= "</div>"
        '                strResult &= "<div class='span7'>"
        '                strResult &= strKeyWord
        '                strResult &= "</div>" 'div span7
        '                strResult &= "</div>" 'div row
        '            End If
        '            tblAccEn.DefaultView.RowFilter = "DicType=4" 'Series
        '            If tblAccEn.DefaultView.Count > 0 Then
        '                For intCount = 0 To tblAccEn.DefaultView.Count - 1
        '                    strseries &= "<a style='cursor:pointer;' onclick=""gotoShowRecord(" & tblAccEn.DefaultView(intCount).Item("DicType") & "," & tblAccEn.DefaultView(intCount).Item("ID") & ")"">" & tblAccEn.DefaultView(intCount).Item("DisplayEntry") & "</A>, "
        '                Next
        '                If strseries <> "" Then
        '                    strseries = Left(strseries, Len(strseries) - 2)
        '                End If

        '                strResult &= "<div class='row'>"
        '                strResult &= "<div class='span3'>"
        '                strResult &= "<p>"
        '                strResult &= "<span class='item-title-secondary'>" & spSeries.InnerText & "</span>"
        '                strResult &= "</p>"
        '                strResult &= "</div>"
        '                strResult &= "<div class='span7'>"
        '                strResult &= strseries
        '                strResult &= "</div>" 'div span7
        '                strResult &= "</div>" 'div row
        '            End If

        '            tblAccEn.DefaultView.RowFilter = "DicType=5" 'Suject Heading
        '            If tblAccEn.DefaultView.Count > 0 Then
        '                For intCount = 0 To tblAccEn.DefaultView.Count - 1
        '                    strSH = strSH & "<a style='cursor:pointer;' onclick=""gotoShowRecord(" & tblAccEn.DefaultView(intCount).Item("DicType") & "," & tblAccEn.DefaultView(intCount).Item("ID") & ")"">" & tblAccEn.DefaultView(intCount).Item("DisplayEntry") & "</A>, "
        '                Next
        '                If strSH <> "" Then
        '                    strSH = Left(strSH, Len(strSH) - 2)
        '                End If
        '                strResult &= "<div class='row'>"
        '                strResult &= "<div class='span3'>"
        '                strResult &= "<p>"
        '                strResult &= "<span class='item-title-secondary'>" & spSubjectHeading.InnerText & "</span>"
        '                strResult &= "</p>"
        '                strResult &= "</div>"
        '                strResult &= "<div class='span7'>"
        '                strResult &= strSH
        '                strResult &= "</div>" 'div span7
        '                strResult &= "</div>" 'div row
        '            End If
        '            tblAccEn.DefaultView.RowFilter = "DicType=7" 'NLM
        '            If tblAccEn.DefaultView.Count > 0 Then
        '                For intCount = 0 To tblAccEn.DefaultView.Count - 1
        '                    strNLM = strNLM & "<a style='cursor:pointer;' onclick=""gotoShowRecord(" & tblAccEn.DefaultView(intCount).Item("DicType") & "," & tblAccEn.DefaultView(intCount).Item("ID") & ")"">" & tblAccEn.DefaultView(intCount).Item("DisplayEntry") & "</A>, "
        '                Next
        '                If strNLM <> "" Then
        '                    strNLM = Left(strNLM, Len(strNLM) - 2)
        '                End If
        '                strResult &= "<div class='row'>"
        '                strResult &= "<div class='span3'>"
        '                strResult &= "<p>"
        '                strResult &= "<span class='item-title-secondary'>" & spNLM.InnerText & "</span>"
        '                strResult &= "</p>"
        '                strResult &= "</div>"
        '                strResult &= "<div class='span7'>"
        '                strResult &= strNLM
        '                strResult &= "</div>" 'div span7
        '                strResult &= "</div>" 'div row
        '            End If

        '            tblAccEn.DefaultView.RowFilter = "DicType=8" 'DDC
        '            If tblAccEn.DefaultView.Count > 0 Then
        '                For intCount = 0 To tblAccEn.DefaultView.Count - 1
        '                    strDDC = strDDC & "<a style='cursor:pointer;' onclick=""gotoShowRecord(" & tblAccEn.DefaultView(intCount).Item("DicType") & "," & tblAccEn.DefaultView(intCount).Item("ID") & ")"">" & tblAccEn.DefaultView(intCount).Item("DisplayEntry") & "</A>, "
        '                Next
        '                If strDDC <> "" Then
        '                    strDDC = Left(strDDC, Len(strDDC) - 2)
        '                End If
        '                strResult &= "<div class='row'>"
        '                strResult &= "<div class='span3'>"
        '                strResult &= "<p>"
        '                strResult &= "<span class='item-title-secondary'>" & spDDC.InnerText & "</span>"
        '                strResult &= "</p>"
        '                strResult &= "</div>"
        '                strResult &= "<div class='span7'>"
        '                strResult &= strDDC
        '                strResult &= "</div>" 'div span7
        '                strResult &= "</div>" 'div row
        '            End If

        '            strResult &= "</div>" 'div grid no-margin
        '            strResult &= "</div>" 'div panel-content

        '            ltrRelationWord.Text = strResult
        '        End If
        '    Catch ex As Exception
        '    End Try
        'End Sub


        Private Sub BindRelationWordInfor(ByVal ItemId As Integer)
            Try
                ltrRelationWord.Text = ""
                Dim tblAccEn As DataTable = Nothing
                Dim tblAuthor As New DataTable
                objBFilterBrowse.ItemID = ItemId
                tblAccEn = objBFilterBrowse.getRelatedWords
                Dim strResult As String = ""
                Dim strAuthor As String = ""
                Dim strNLM As String = ""
                Dim strDDC As String = ""
                Dim strseries As String = ""
                Dim strKeyWord As String = ""
                Dim strSH As String = ""
                If Not IsNothing(tblAccEn) AndAlso tblAccEn.Rows.Count > 0 Then
                    'strResult &= "<BR />"
                    'strResult &= "<div class='panel-header bg-lightBlue fg-white'>"
                    'strResult &= "<span class='icon-info-2'>&nbsp;</span>" & spRelatedWord.InnerText
                    'strResult &= "</div>"
                    'strResult &= "<div class='panel-content'>"
                    'strResult &= "<div class='grid no-margin'>"
                    strResult &= "<div class=""detail-img col-left-2""><img src=""" & strCoverPicture & """ alt=""" & strCoverPicture & """/></div> "
                    strResult &= "<div class=""detail-intro col-right-8"">"
                    strResult &= "<h2>" & strMainTitle & "</h2>"

                    Dim intCount As Integer = 0
                    tblAccEn.DefaultView.RowFilter = "DicType=1" 'Author
                    If tblAccEn.DefaultView.Count > 0 Then
                        For intCount = 0 To tblAccEn.DefaultView.Count - 1
                            strAuthor = strAuthor & "<a style='cursor:pointer;' onclick=""gotoShowRecord(" & tblAccEn.DefaultView(intCount).Item("DicType") & "," & tblAccEn.DefaultView(intCount).Item("ID") & ")"">" & tblAccEn.DefaultView(intCount).Item("DisplayEntry") & "</a>, "
                        Next
                        If strAuthor <> "" Then
                            strAuthor = Left(strAuthor, Len(strAuthor) - 2)
                        End If

                        tblAuthor = objBOpacItem.GetAcessEntryAuthor(tblAccEn.DefaultView(0).Item("AccessEntry"))
                        If tblAuthor.Rows.Count > 0 Then
                            strAuthor = strAuthor & " (see also "
                            For intCount = 0 To tblAuthor.Rows.Count - 1
                                If intCount = 0 Then
                                    strAuthor = strAuthor & "<a style='cursor:pointer;' onclick=""gotoShowRecord(" & tblAccEn.DefaultView(intCount).Item("DicType") & "," & tblAccEn.DefaultView(intCount).Item("ID") & ")"">" & tblAuthor.Rows(intCount).Item("DisplayEntry") & "</a>"
                                Else
                                    strAuthor = strAuthor & "," & "<a style='cursor:pointer;' onclick=""gotoShowRecord(" & tblAccEn.DefaultView(intCount).Item("DicType") & "," & tblAccEn.DefaultView(intCount).Item("ID") & ")"">" & tblAuthor.Rows(intCount).Item("DisplayEntry") & "</a>"
                                End If
                            Next
                            strAuthor = strAuthor & " )"
                        End If
                        'strResult &= "<div class='row'>"
                        'strResult &= "<div class='span3'>"
                        'strResult &= "<p>"
                        'strResult &= "<span class='item-title-secondary'>" & spAuthor.InnerText & "</span>"
                        'strResult &= "</p>"
                        'strResult &= "</div>"
                        'strResult &= "<div class='span7'>"
                        'strResult &= strAuthor
                        'strResult &= "</div>" 'div span7
                        'strResult &= "</div>" 'div row
                        strResult &= "<p><span>" & spAuthor.InnerText & "</span>" & strAuthor & "</p>"
                    End If

                    tblAccEn.DefaultView.RowFilter = "DicType=3" 'Keyword
                    If tblAccEn.DefaultView.Count > 0 Then
                        For intCount = 0 To tblAccEn.DefaultView.Count - 1
                            strKeyWord = strKeyWord & "<a style='cursor:pointer;' onclick=""gotoShowRecord(" & tblAccEn.DefaultView(intCount).Item("DicType") & "," & tblAccEn.DefaultView(intCount).Item("ID") & ")"">" & tblAccEn.DefaultView(intCount).Item("DisplayEntry") & "</a>, "
                        Next
                        If strKeyWord <> "" Then
                            strKeyWord = Left(strKeyWord, Len(strKeyWord) - 2)
                        End If

                        'strResult &= "<div class='row'>"
                        'strResult &= "<div class='span3'>"
                        'strResult &= "<p>"
                        'strResult &= "<span class='item-title-secondary'>" & spKeyword.InnerText & "</span>"
                        'strResult &= "</p>"
                        'strResult &= "</div>"
                        'strResult &= "<div class='span7'>"
                        'strResult &= strKeyWord
                        'strResult &= "</div>" 'div span7
                        'strResult &= "</div>" 'div row
                        strResult &= "<p><span>" & spKeyword.InnerText & "</span>" & strKeyWord & "</p>"
                    End If
                    tblAccEn.DefaultView.RowFilter = "DicType=4" 'Series
                    If tblAccEn.DefaultView.Count > 0 Then
                        For intCount = 0 To tblAccEn.DefaultView.Count - 1
                            strseries &= "<a style='cursor:pointer;' onclick=""gotoShowRecord(" & tblAccEn.DefaultView(intCount).Item("DicType") & "," & tblAccEn.DefaultView(intCount).Item("ID") & ")"">" & tblAccEn.DefaultView(intCount).Item("DisplayEntry") & "</a>, "
                        Next
                        If strseries <> "" Then
                            strseries = Left(strseries, Len(strseries) - 2)
                        End If

                        'strResult &= "<div class='row'>"
                        'strResult &= "<div class='span3'>"
                        'strResult &= "<p>"
                        'strResult &= "<span class='item-title-secondary'>" & spSeries.InnerText & "</span>"
                        'strResult &= "</p>"
                        'strResult &= "</div>"
                        'strResult &= "<div class='span7'>"
                        'strResult &= strseries
                        'strResult &= "</div>" 'div span7
                        'strResult &= "</div>" 'div row
                        strResult &= "<p><span>" & spSeries.InnerText & "</span>" & strseries & "</p>"
                    End If

                    tblAccEn.DefaultView.RowFilter = "DicType=5" 'Suject Heading
                    If tblAccEn.DefaultView.Count > 0 Then
                        For intCount = 0 To tblAccEn.DefaultView.Count - 1
                            strSH = strSH & "<a style='cursor:pointer;' onclick=""gotoShowRecord(" & tblAccEn.DefaultView(intCount).Item("DicType") & "," & tblAccEn.DefaultView(intCount).Item("ID") & ")"">" & tblAccEn.DefaultView(intCount).Item("DisplayEntry") & "</a>, "
                        Next
                        If strSH <> "" Then
                            strSH = Left(strSH, Len(strSH) - 2)
                        End If
                        'strResult &= "<div class='row'>"
                        'strResult &= "<div class='span3'>"
                        'strResult &= "<p>"
                        'strResult &= "<span class='item-title-secondary'>" & spSubjectHeading.InnerText & "</span>"
                        'strResult &= "</p>"
                        'strResult &= "</div>"
                        'strResult &= "<div class='span7'>"
                        'strResult &= strSH
                        'strResult &= "</div>" 'div span7
                        'strResult &= "</div>" 'div row
                        strResult &= "<p><span>" & spSubjectHeading.InnerText & "</span>" & strSH & "</p>"
                    End If
                    tblAccEn.DefaultView.RowFilter = "DicType=7" 'NLM
                    If tblAccEn.DefaultView.Count > 0 Then
                        For intCount = 0 To tblAccEn.DefaultView.Count - 1
                            strNLM = strNLM & "<a style='cursor:pointer;' onclick=""gotoShowRecord(" & tblAccEn.DefaultView(intCount).Item("DicType") & "," & tblAccEn.DefaultView(intCount).Item("ID") & ")"">" & tblAccEn.DefaultView(intCount).Item("DisplayEntry") & "</a>, "
                        Next
                        If strNLM <> "" Then
                            strNLM = Left(strNLM, Len(strNLM) - 2)
                        End If
                        'strResult &= "<div class='row'>"
                        'strResult &= "<div class='span3'>"
                        'strResult &= "<p>"
                        'strResult &= "<span class='item-title-secondary'>" & spNLM.InnerText & "</span>"
                        'strResult &= "</p>"
                        'strResult &= "</div>"
                        'strResult &= "<div class='span7'>"
                        'strResult &= strNLM
                        'strResult &= "</div>" 'div span7
                        'strResult &= "</div>" 'div row
                        strResult &= "<p><span>" & spNLM.InnerText & "</span>" & strNLM & "</p>"
                    End If

                    tblAccEn.DefaultView.RowFilter = "DicType=8" 'DDC
                    If tblAccEn.DefaultView.Count > 0 Then
                        For intCount = 0 To tblAccEn.DefaultView.Count - 1
                            strDDC = strDDC & "<a style='cursor:pointer;' onclick=""gotoShowRecord(" & tblAccEn.DefaultView(intCount).Item("DicType") & "," & tblAccEn.DefaultView(intCount).Item("ID") & ")"">" & tblAccEn.DefaultView(intCount).Item("DisplayEntry") & "</a>, "
                        Next
                        If strDDC <> "" Then
                            strDDC = Left(strDDC, Len(strDDC) - 2)
                        End If
                        'strResult &= "<div class='row'>"
                        'strResult &= "<div class='span3'>"
                        'strResult &= "<p>"
                        'strResult &= "<span class='item-title-secondary'>" & spDDC.InnerText & "</span>"
                        'strResult &= "</p>"
                        'strResult &= "</div>"
                        'strResult &= "<div class='span7'>"
                        'strResult &= strDDC
                        'strResult &= "</div>" 'div span7
                        'strResult &= "</div>" 'div row
                        strResult &= "<p><span>" & spDDC.InnerText & "</span>" & strDDC & "</p>"
                    End If

                    'strResult &= "</div>" 'div grid no-margin

                    strResult &= "</div>"
                    ltrRelationWord.Text = strResult
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Sub writeViewerForMedia(ByVal _fileIdArr() As Integer, ByVal _FileMedia() As String, ByVal _thumimage() As String, ByVal _Description() As String, Optional ByVal intComment As Integer = 0, Optional ByVal bolPage As Boolean = False)
            Try
                Dim _strInfo As String = ""
                Dim strFileMedia() As String = Nothing
                Dim strThumImage() As String = Nothing
                Dim dblDuration() As String = Nothing
                Dim _FileXMLOrigin As String = Server.MapPath(Request.ApplicationPath) & "\Viewer\xml\MLVideo.xml"
                Dim _FileXMLDestination As String = Server.MapPath(Request.ApplicationPath) & "\Viewer\Media\"
                Dim iCount As Integer = UBound(_fileIdArr)
                Dim intMulti As Integer = 0
                Dim PathFFMPEG As String = Server.MapPath(Request.ApplicationPath) & "\LibMedia\ffmpeg.exe"
                For i As Integer = 0 To iCount
                    If _FileMedia(i).ToLower.EndsWith(".flv") Then
                        ReDim Preserve strFileMedia(i)
                        strFileMedia(i) = Me.ChangeMapVirtualPath(_FileMedia(i).ToString)
                        ReDim Preserve strThumImage(i)
                        strThumImage(i) = Me.ChangeMapVirtualPath(_thumimage(i).ToString)
                        ReDim Preserve dblDuration(i)
                        dblDuration(i) = clsMedia.Get_duration(_FileMedia(i).ToString, PathFFMPEG)
                        If i = 0 Then
                            Dim _tempDir As String = GetDirectoryName(_FileMedia(i))
                            _tempDir = _tempDir.Substring(_tempDir.LastIndexOf("\") + 1)
                            _FileXMLDestination &= _tempDir
                            If Not Directory.Exists(_FileXMLDestination) Then
                                Directory.CreateDirectory(_FileXMLDestination)
                            End If
                            If Not _FileXMLDestination.EndsWith("\") = True Then
                                _FileXMLDestination &= "\"
                            End If
                            _FileXMLDestination &= GetFileName(_FileXMLOrigin)
                            If Not File.Exists(_FileXMLDestination) Then
                                File.Copy(_FileXMLOrigin, _FileXMLDestination)
                            End If
                            Dim _xmlFile As String = ""
                            _xmlFile = _tempDir & "/" & GetFileName(_FileXMLDestination)
                            _xmlFile = "http://" & Request.ServerVariables("HTTP_HOST") & "/Viewer/Media/" & _xmlFile
                            If iCount > 0 Then
                                intMulti = 1
                            End If
                            _strInfo &= " writeMLmeida('" & _xmlFile & "'," & intMulti & ");" & vbCrLf
                        End If

                    End If
                Next
                If Not _strInfo = "" Then
                    Call ModifyXMLMultiForMedia(_FileXMLDestination, strFileMedia, strThumImage, dblDuration, _Description)
                    If intComment > 0 Then
                        Select Case intComment
                            Case 1
                                _strInfo &= " parent.showNotify('warning', '" & spCapchaInfo.InnerText & "');" & vbCrLf
                            Case 2
                                _strInfo &= " parent.showNotify('error', '" & spCommentFail.InnerText & "');" & vbCrLf
                            Case 3
                                _strInfo &= " parent.showNotify('success', '" & spCommentSuccess.InnerText & "');"
                        End Select
                        _strInfo &= " window.location.hash = '#toComment';" & vbCrLf
                    End If
                    If bolPage Then
                        _strInfo &= " window.location.hash = '#toPageComment';" & vbCrLf
                    End If
                    clsUICommon.MyMsgBoxInfor(_strInfo, Me.Page)
                End If
            Catch ex As Exception : End Try
        End Sub


        Private Sub ModifyXMLMultiForMedia(ByVal _xml As String, ByVal _fileName() As String, ByVal _thumimage() As String, ByVal dblDuration() As String, ByVal _Description() As String)
            Try
                Dim iCountFile As Integer = UBound(_fileName)
                Dim _doc As New XmlDocument
                _doc.Load(_xml)
                Dim nodeRoot As XmlNode = _doc.SelectSingleNode("/rss")
                nodeRoot.RemoveAll()
                Dim attr As XmlAttribute = Nothing
                attr = _doc.CreateAttribute("version")
                attr.Value = "2.0"
                nodeRoot.Attributes.Append(attr)
                attr = _doc.CreateAttribute("xmlns:media")
                attr.Value = "http://search.yahoo.com/mrss/"
                nodeRoot.Attributes.Append(attr)
                attr = _doc.CreateAttribute("xmlns:jwplayer")
                attr.Value = "http://developer.longtailvideo.com/trac/"
                nodeRoot.Attributes.Append(attr)

                Dim channel As XmlElement = _doc.CreateElement("channel")
                nodeRoot.AppendChild(channel)

                Dim title As XmlElement = _doc.CreateElement("title")
                title.InnerText = "MRSS Playlist"
                channel.AppendChild(title)

                For i As Integer = 0 To iCountFile
                    Dim item As XmlElement = _doc.CreateElement("item")
                    channel.AppendChild(item)

                    Dim id As XmlElement = _doc.CreateElement("id")
                    id.InnerText = (i + 1).ToString
                    item.AppendChild(id)

                    Dim creator As XmlElement = _doc.CreateElement("creator")
                    creator.InnerText = ""
                    item.AppendChild(creator)

                    Dim titleVideo As XmlElement = _doc.CreateElement("title")
                    titleVideo.InnerText = "PHẦN " & (i + 1).ToString & "/" & (iCountFile + 1).ToString
                    item.AppendChild(titleVideo)

                    Dim mediaContent As XmlElement = _doc.CreateElement("media", "content", "content") '<media:content/>
                    attr = _doc.CreateAttribute("url")
                    attr.Value = _fileName(i).ToString
                    mediaContent.Attributes.Append(attr)
                    attr = _doc.CreateAttribute("xmlns:media")
                    attr.Value = "schema"
                    mediaContent.Attributes.Append(attr)
                    item.AppendChild(mediaContent)


                    Dim description As XmlElement = _doc.CreateElement("description")
                    Dim strDescription As String = ""
                    If Not IsNothing(_Description(i)) AndAlso _Description(i) <> "" Then
                        strDescription = _Description(i)
                    Else
                        strDescription = strTitle
                    End If
                    description.InnerText = strDescription
                    item.AppendChild(description)

                    Dim jwplayerDuration As XmlElement = _doc.CreateElement("jwplayer", "duration", "duration") '<jwplayer:duration/>
                    jwplayerDuration.InnerText = dblDuration(i)
                    item.AppendChild(jwplayerDuration)
                Next
                _doc.Save(_xml)
                If Not _doc Is Nothing Then
                    _doc = Nothing
                End If
            Catch ex As Exception : End Try
        End Sub

        Private Sub writeViewerForPicture(ByVal _fileIdArr() As Integer, ByVal _FilePciture() As String, ByVal _thumimage() As String, Optional ByVal _description() As String = Nothing, Optional ByVal intComment As Integer = 0, Optional ByVal bolPage As Boolean = False)
            Try
                Dim _strInfo As String = ""
                Dim strFilePicture() As String = Nothing
                Dim strThumImage() As String = Nothing
                Dim _FileXMLOrigin As String = Server.MapPath(Request.ApplicationPath) & "\Viewer\xml\MLPicture.xml"
                Dim _FileXMLDestination As String = Server.MapPath(Request.ApplicationPath) & "\Viewer\Picture\"
                For i As Integer = 0 To UBound(_fileIdArr)
                    ReDim Preserve strFilePicture(i)
                    strFilePicture(i) = Me.ChangeMapVirtualPath(_FilePciture(i).ToString)
                    ReDim Preserve strThumImage(i)
                    strThumImage(i) = Me.ChangeMapVirtualPath(_thumimage(i).ToString)
                    If i = 0 Then
                        Dim _tempDir As String = GetDirectoryName(_FilePciture(i))
                        _tempDir = _tempDir.Substring(_tempDir.LastIndexOf("\") + 1)
                        _FileXMLDestination &= _tempDir
                        If Not Directory.Exists(_FileXMLDestination) Then
                            Directory.CreateDirectory(_FileXMLDestination)
                        End If
                        If Not _FileXMLDestination.EndsWith("\") = True Then
                            _FileXMLDestination &= "\"
                        End If
                        _FileXMLDestination &= GetFileName(_FileXMLOrigin)
                        If Not File.Exists(_FileXMLDestination) Then
                            File.Copy(_FileXMLOrigin, _FileXMLDestination)
                        End If
                        Dim _xmlFile As String = ""
                        _xmlFile = _tempDir & "/" & GetFileName(_FileXMLDestination)
                        _xmlFile = "http://" & Request.ServerVariables("HTTP_HOST") & "/Viewer/Picture/" & _xmlFile
                        _strInfo &= " writeMLpicture('" & _xmlFile & "');" & vbCrLf
                    End If
                Next
                If Not _strInfo = "" Then
                    Call ModifyXMLMultiForPicrure(_FileXMLDestination, strFilePicture, strThumImage, _description)
                    If intComment > 0 Then
                        Select Case intComment
                            Case 1
                                _strInfo &= " parent.showNotify('warning', '" & spCapchaInfo.InnerText & "');" & vbCrLf
                            Case 2
                                _strInfo &= " parent.showNotify('error', '" & spCommentFail.InnerText & "');" & vbCrLf
                            Case 3
                                _strInfo &= " parent.showNotify('success', '" & spCommentSuccess.InnerText & "');"
                        End Select
                        _strInfo &= " window.location.hash = '#toComment';" & vbCrLf
                    End If
                    If bolPage Then
                        _strInfo &= " window.location.hash = '#toPageComment';" & vbCrLf
                    End If
                    clsUICommon.MyMsgBoxInfor(_strInfo, Me.Page)
                End If
            Catch ex As Exception : End Try
        End Sub

        Private Sub ModifyXMLMultiForPicrure(ByVal _xml As String, ByVal _fileName() As String, ByVal _thumb() As String, Optional ByVal _description() As String = Nothing, Optional ByVal _title As String = "", Optional ByVal _slidePath As String = "", Optional ByVal _thumbPath As String = "")
            Try
                Dim iCountFile As Integer = UBound(_fileName)
                Dim _doc As New XmlDocument
                _doc.Load(_xml)

                Dim nodeRoot As XmlNode = _doc.SelectSingleNode("/slideshow/preferences")
                nodeRoot.RemoveAll()
                Dim attr As XmlAttribute = Nothing

                attr = _doc.CreateAttribute("thumbSize")
                attr.Value = "50"
                nodeRoot.Attributes.Append(attr)
                attr = _doc.CreateAttribute("slideEffect")
                attr.Value = "random"
                nodeRoot.Attributes.Append(attr)
                attr = _doc.CreateAttribute("soundPath")
                attr.Value = getMusic()
                nodeRoot.Attributes.Append(attr)


                nodeRoot = _doc.SelectSingleNode("/slideshow/albums")
                nodeRoot.RemoveAll()
                attr = Nothing

                Dim xmlAlbum As XmlElement = _doc.CreateElement("album")
                nodeRoot.AppendChild(xmlAlbum)
                Dim nodeAlbum As XmlNode = _doc.SelectSingleNode("/slideshow/albums/album")
                attr = _doc.CreateAttribute("slidePath")
                attr.Value = _slidePath
                nodeAlbum.Attributes.Append(attr)
                attr = _doc.CreateAttribute("thumbPath")
                attr.Value = _thumbPath
                nodeAlbum.Attributes.Append(attr)

                Dim xmlAlbumdescription As XmlElement = _doc.CreateElement("description")
                xmlAlbumdescription.InnerText = _title
                xmlAlbum.AppendChild(xmlAlbumdescription)

                Dim xmlslides As XmlElement = _doc.CreateElement("slides")
                xmlAlbum.AppendChild(xmlslides)

                For i As Integer = 0 To iCountFile
                    Dim xmlslide As XmlElement = _doc.CreateElement("slide")
                    If Not IsNothing(_description) Then
                        xmlslide.InnerText = IIf(Not IsNothing(_description(i)), _description(i), "")
                    End If
                    xmlslides.AppendChild(xmlslide)
                    Dim nodeSlide As XmlNode = _doc.SelectNodes("/slideshow/albums/album/slides/slide").Item(i)
                    attr = _doc.CreateAttribute("name")
                    attr.Value = _fileName(i).ToString
                    nodeSlide.Attributes.Append(attr)
                    attr = _doc.CreateAttribute("thumbName")
                    If Not IsNothing(_thumb(i)) Then
                        attr.Value = _thumb(i).ToString
                    Else
                        attr.Value = _fileName(i).ToString
                    End If
                    nodeSlide.Attributes.Append(attr)
                Next
                _doc.Save(_xml)
                If Not _doc Is Nothing Then
                    _doc = Nothing
                End If
            Catch ex As Exception : End Try
        End Sub


        Private Function getMusic() As String
            Dim sreResult As String = ""
            Try
                Const totalMusic As Integer = 17
                Dim strArrMusic() As String = {"Anniversary.mp3", "Aphrodite - S.E.N.S.mp3", "Bo cong anh - Beat.mp3", "Grief And Sorrow 2 - Toshiro Masuda.mp3", "Hokages Funeral - Naruto OST.mp3", "Kiss The Rain - Yurima.mp3", "Lotus Flower - Eric Chiryoku.mp3", "Loving you.mp3", "River flows in you - Yiruma.mp3", "Romeo and juliet - Francis Goya.mp3", "Ryuukou - Dang cap nhat.mp3", "Sad Angel - Igor Krutoi.mp3", "Silent Wind - Eric Chiryoku.mp3", "Song From Secret Garden - Secret Garden.mp3", "Sorry I love you - Beat.mp3", "Still thinking of you OST The Painter of the wind.mp3", "The Promise - Dang cap nhat.mp3", "Winter story - Eric Chiryoku.mp3"}
                Randomize()
                Dim index As Integer = CInt(totalMusic * Rnd(1))
                sreResult &= "http://" & Request.ServerVariables("HTTP_HOST") & "/Viewer/Music/" & strArrMusic(index)
            Catch ex As Exception
            End Try
            Return sreResult
        End Function


        Private Sub writeViewerForAudioBook(ByVal _fileIdArr() As Integer, ByVal _FileMp3() As String, ByVal _Description() As String, Optional ByVal intComment As Integer = 0, Optional ByVal bolPage As Boolean = False)
            Try
                Dim _strInfo As String = ""
                Dim arrFileMp3() As String = Nothing
                Dim _playlistXMLOrigin As String = Server.MapPath(Request.ApplicationPath) & "\Viewer\xml\MLAudio.xml"
                Dim _playlistXMLDestination As String = Server.MapPath(Request.ApplicationPath) & "\Viewer\Audio\"

                Dim _playlistXMLMapping As String = ""
                For i As Integer = 0 To UBound(_fileIdArr)

                    ReDim Preserve arrFileMp3(i)
                    arrFileMp3(i) = Me.ChangeMapVirtualPath(_FileMp3(i).ToString)

                    If i = 0 Then
                        Dim _tempDir As String = GetDirectoryName(_FileMp3(i))
                        _tempDir = _tempDir.Substring(_tempDir.LastIndexOf("\") + 1)
                        _playlistXMLDestination &= _tempDir
                        _playlistXMLMapping = _tempDir
                        If Not Directory.Exists(_playlistXMLDestination) Then
                            Directory.CreateDirectory(_playlistXMLDestination)
                        End If
                        If Not _playlistXMLDestination.EndsWith("\") = True Then
                            _playlistXMLDestination &= "\"
                        End If
                        If Not _playlistXMLMapping.EndsWith("\") = True Then
                            _playlistXMLMapping &= "\"
                        End If
                        _playlistXMLDestination &= GetFileName(_playlistXMLOrigin)
                        _playlistXMLMapping &= GetFileName(_playlistXMLOrigin)
                        If Not File.Exists(_playlistXMLDestination) Then
                            File.Copy(_playlistXMLOrigin, _playlistXMLDestination)
                        End If

                        _playlistXMLMapping = Replace(_playlistXMLMapping, "\", "/")

                        Dim _xmlFile As String = ""
                        _xmlFile = _tempDir & "/" & GetFileName(_playlistXMLDestination)
                        _xmlFile = "http://" & Request.ServerVariables("HTTP_HOST") & "/Viewer/Audio/" & _xmlFile
                        _strInfo &= " writeMLAudio('" & _xmlFile & "');" & vbCrLf
                    End If
                Next
                If Not _strInfo = "" Then
                    Call ModifyPlaylistXMLMultiForAudioBook(_playlistXMLDestination, arrFileMp3, _Description)
                    If intComment > 0 Then
                        Select Case intComment
                            Case 1
                                _strInfo &= " parent.showNotify('warning', '" & spCapchaInfo.InnerText & "');" & vbCrLf
                            Case 2
                                _strInfo &= " parent.showNotify('error', '" & spCommentFail.InnerText & "');" & vbCrLf
                            Case 3
                                _strInfo &= " parent.showNotify('success', '" & spCommentSuccess.InnerText & "');"
                        End Select
                        _strInfo &= " window.location.hash = '#toComment';" & vbCrLf
                    End If
                    If bolPage Then
                        _strInfo &= " window.location.hash = '#toPageComment';" & vbCrLf
                    End If
                    clsUICommon.MyMsgBoxInfor(_strInfo, Me.Page)
                End If
            Catch ex As Exception : End Try
        End Sub


        Private Sub ModifyPlaylistXMLMultiForAudioBook(ByVal _playlistXml As String, ByVal _fileName() As String, ByVal _Description() As String)
            Try
                Dim iCountFile As Integer = UBound(_fileName)
                Dim _doc As New XmlDocument
                _doc.Load(_playlistXml)
                Dim nodeRoot As XmlNode = _doc.SelectSingleNode("/rss")
                nodeRoot.RemoveAll()
                Dim attr As XmlAttribute = Nothing
                attr = _doc.CreateAttribute("version")
                attr.Value = "2.0"
                nodeRoot.Attributes.Append(attr)
                attr = _doc.CreateAttribute("xmlns:media")
                attr.Value = "http://search.yahoo.com/mrss/"
                nodeRoot.Attributes.Append(attr)
                attr = _doc.CreateAttribute("xmlns:jwplayer")
                attr.Value = "http://developer.longtailvideo.com/trac/"
                nodeRoot.Attributes.Append(attr)

                Dim channel As XmlElement = _doc.CreateElement("channel")
                nodeRoot.AppendChild(channel)

                Dim title As XmlElement = _doc.CreateElement("title")
                title.InnerText = "MRSS Playlist"
                channel.AppendChild(title)

                For i As Integer = 0 To iCountFile
                    Dim item As XmlElement = _doc.CreateElement("item")
                    channel.AppendChild(item)

                    Dim creator As XmlElement = _doc.CreateElement("id")
                    creator.InnerText = (i + 1).ToString
                    item.AppendChild(creator)

                    Dim titleMusic As XmlElement = _doc.CreateElement("title")
                    Dim strDescription As String = ""
                    If Not IsNothing(_Description(i)) AndAlso _Description(i) <> "" Then
                        strDescription = ": " & _Description(i)
                    End If
                    If iCountFile > 1 Then
                        titleMusic.InnerText &= "PHẦN " & (i + 1).ToString & "/" & (iCountFile + 1).ToString & strDescription
                    Else
                        If strDescription <> "" Then
                            titleMusic.InnerText &= strDescription
                        Else
                            titleMusic.InnerText &= strTitle
                        End If
                    End If

                    item.AppendChild(titleMusic)

                    Dim mediaContent As XmlElement = _doc.CreateElement("media", "content", "content") '<media:content/>
                    attr = _doc.CreateAttribute("url")
                    attr.Value = _fileName(i).ToString
                    mediaContent.Attributes.Append(attr)
                    attr = _doc.CreateAttribute("xmlns:media")
                    attr.Value = "schema"
                    mediaContent.Attributes.Append(attr)
                    item.AppendChild(mediaContent)


                    Dim order As XmlElement = _doc.CreateElement("order")
                    order.InnerText = (i + 1).ToString
                    item.AppendChild(order)
                Next
                _doc.Save(_playlistXml)
                If Not _doc Is Nothing Then
                    _doc = Nothing
                End If
            Catch ex As Exception : End Try
        End Sub

        Private Sub updateViews(ByVal ItemID As Integer)
            Try
                Dim bolResult As Boolean = objBOPACFile.updateViews(ItemID, DatePart(DateInterval.WeekOfYear, Now.Date), Now.Date.Month, Now.Date.Year)
            Catch ex As Exception
            End Try
        End Sub


        ' BindScript method
        ' Purpose: Bind JAVASCRIPTS
        Private Sub BindScript()
            'Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'js/OShow.js'></script>")
        End Sub


        ' filterInBrowse method
        ' Purpose: filter information for browse
        Private Sub getRelation(ByVal intDicType As Integer, ByVal strAccessEntry As String, ByVal intItemID As Integer)
            Try
                Dim dtIds As DataTable
                With objBOPACDictionary
                    .DicType = intDicType
                    .AccessEntry = strAccessEntry
                    dtIds = .getItemFromDictionaryAccessEntry(intItemID, clsSession.GlbSite)
                End With
                If Not IsNothing(dtIds) AndAlso dtIds.Rows.Count > 0 Then
                    Dim strIDs As String = ""
                    For i As Integer = 0 To dtIds.Rows.Count - 1
                        strIDs = strIDs & dtIds.Rows(i).Item("ItemID") & ","
                    Next
                    If strIDs <> "" Then
                        strIDs = Left(strIDs, Len(strIDs) - 1)
                    End If
                    objBSearchResult.ItemIDs = strIDs
                    Dim arrField() As String = {"022", "100", "110", "245", "250", "260", "300", "490", "700", "710", "773", "856"}
                    Dim tblTmp As New DataTable
                    tblTmp = objBSearchResult.GetItemResultsByFields(arrField)
                    Call showBooks(tblTmp, strIDs, 1, 10)
                    CollapsiblePanel1.Style.Add("display", "block")
                    divRelationDocument.Visible = True
                Else
                    CollapsiblePanel1.Style.Add("display", "none")
                    divRelationDocument.Visible = False
                    'ltrBookList.Text = spNoFound.InnerText
                End If
            Catch ex As Exception
            End Try
        End Sub

        ' filterInBrowse method
        ' Purpose: filter information for browse
        Private Sub getRelationByAuthor(ByVal intDicType As Integer, ByVal strAccessEntry As String, ByVal intItemID As Integer)
            Try
                Dim dtIds As DataTable
                With objBOPACDictionary
                    .DicType = intDicType
                    .AccessEntry = strAccessEntry
                    dtIds = .getItemFromDictionaryAccessEntry(intItemID, clsSession.GlbSite)
                End With
                If Not IsNothing(dtIds) AndAlso dtIds.Rows.Count > 0 Then
                    Dim strIDs As String = ""
                    For i As Integer = 0 To dtIds.Rows.Count - 1
                        strIDs = strIDs & dtIds.Rows(i).Item("ItemID") & ","
                    Next
                    If strIDs <> "" Then
                        strIDs = Left(strIDs, Len(strIDs) - 1)
                    End If
                    objBSearchResult.ItemIDs = strIDs
                    Dim arrField() As String = {"022", "100", "110", "245", "250", "260", "300", "490", "700", "710", "773", "856"}
                    Dim tblTmp As New DataTable
                    tblTmp = objBSearchResult.GetItemResultsByFields(arrField)
                    Call showBooks(tblTmp, strIDs, 1, 10, 1)
                    CollapsiblePanel2.Style.Add("display", "block")
                    divRelationAuthor.Visible = True
                Else
                    CollapsiblePanel2.Style.Add("display", "none")
                    divRelationAuthor.Visible = False
                    'ltrRelationAuthor.Text = spNoFound.InnerText
                End If
            Catch ex As Exception
            End Try
        End Sub

        '' purpose :  show books
        '' Creator: phuongtt
        'Private Sub showBooks(ByVal tblData As DataTable, ByVal strIDs As String, ByVal intCurPage As Integer, ByVal intRecPerPage As Integer, Optional ByVal intDic As Integer = 8)
        '    Dim strTitle As String ' thong tin nhan de chinh
        '    Dim strDesPhy As String ' thong tin mo ta vat ly
        '    Dim strPublish As String ' thong tin xuat ban
        '    Dim strCover As String ' thong tin bia tai lieu
        '    Dim strAuthor As String ' thong tin tac gia
        '    Dim strISSN As String ' thong tin ISSN
        '    Dim strURL As String ' thong tin URL
        '    Dim strEDATA As String ' thong tin du lieu dien tu
        '    Dim strRANKING As String ' thong tin xep hang
        '    Dim strType As String ' thong tin loai tai lieu
        '    Dim intCount As Integer
        '    Dim arrIDs() As String
        '    Dim rowView As DataRowView

        '    If tblData Is Nothing Then
        '        Exit Sub
        '    End If
        '    arrIDs = Split(strIDs, ",")
        '    Dim strResult As String = ""
        '    If tblData.Rows.Count > 0 Then


        '        For intCount = 0 To UBound(arrIDs)

        '            strTitle = ""
        '            tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND Field='245'"
        '            If tblData.DefaultView.Count > 0 Then
        '                strTitle = tblData.DefaultView(0).Item("Content") & ""
        '            End If
        '            strTitle = (intRecPerPage * (intCurPage - 1)) + intCount + 1 & ". " & strTitle

        '            ' get description physical
        '            strDesPhy = ""
        '            tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='300'"
        '            If tblData.DefaultView.Count > 0 Then
        '                strDesPhy = tblData.DefaultView(0).Item("Content") & ""
        '            End If
        '            ' get publish information
        '            strPublish = ""
        '            tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='260'"
        '            If tblData.DefaultView.Count > 0 Then
        '                strPublish = tblData.DefaultView(0).Item("Content") & ""
        '            End If

        '            ' get ISSN information
        '            strISSN = ""
        '            tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='022'"
        '            If tblData.DefaultView.Count > 0 Then
        '                strISSN = tblData.DefaultView(0).Item("Content") & ""
        '            End If

        '            'get author info
        '            strAuthor = ""
        '            tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='100'"
        '            For Each rowView In tblData.DefaultView
        '                If Not IsDBNull(rowView.Item("Content")) Then
        '                    strAuthor &= rowView.Item("Content") & "; "
        '                End If
        '            Next
        '            tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='110'"
        '            For Each rowView In tblData.DefaultView
        '                If Not IsDBNull(rowView.Item("Content")) Then
        '                    strAuthor &= rowView.Item("Content") & "; "
        '                End If
        '            Next
        '            tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='700'"
        '            For Each rowView In tblData.DefaultView
        '                If Not IsDBNull(rowView.Item("Content")) Then
        '                    strAuthor &= rowView.Item("Content") & "; "
        '                End If
        '            Next
        '            tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='710'"
        '            For Each rowView In tblData.DefaultView
        '                If Not IsDBNull(rowView.Item("Content")) Then
        '                    strAuthor &= rowView.Item("Content") & "; "
        '                End If
        '            Next
        '            strAuthor = strAuthor.Trim
        '            If Not strAuthor = "" Then
        '                strAuthor = strAuthor.Substring(0, strAuthor.Length - 1)
        '            End If

        '            strURL = ""
        '            tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='856'"
        '            For Each rowView In tblData.DefaultView
        '                If Not IsDBNull(rowView.Item("Content")) Then
        '                    If InStr(rowView.Item("Content"), "http://") > 0 Then
        '                        strURL &= "<a href='" & rowView.Item("Content") & "' target='_blank' class='lblinkfunction' style='cursor:pointer;'><div class='icon-link'></div>URL</a>; "
        '                    End If
        '                End If
        '            Next
        '            strURL = strURL.Trim
        '            If strURL <> "" Then
        '                strURL = strURL.Substring(0, strURL.Length - 1)
        '                'Bo span danh dau highlight cac truong 0xx --> 9xx
        '                strURL = Replace(strURL, "<span style=""background-color:#60a917 !important;color:white;""></span>", "")
        '            End If

        '            'Du lieu dien tu
        '            strEDATA = ""
        '            tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='EDATA'"
        '            If tblData.DefaultView.Count > 0 Then
        '                strEDATA = tblData.DefaultView(0).Item("Content") & ""
        '            End If

        '            'Ranking 
        '            strRANKING = "2"
        '            tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='RANKING'"
        '            If tblData.DefaultView.Count > 0 Then
        '                strRANKING = tblData.DefaultView(0).Item("Content") & ""
        '            End If

        '            'Loai tai lieu
        '            strType = ""
        '            tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='ETYPE'"
        '            If tblData.DefaultView.Count > 0 Then
        '                strType = tblData.DefaultView(0).Item("Content") & ""
        '            End If

        '            strResult &= "<div class='panel-header'>"
        '            strResult &= "<a onclick='showPopupDetail(" & arrIDs(intCount) & ")' class='lblinkfunction' style='cursor:pointer;'>" & strTitle & "</a> "
        '            strResult &= getIcons(arrIDs(intCount))
        '            strResult &= "</div>"
        '            strResult &= "<div class='panel-content'>"

        '            strResult &= "<div class='grid no-margin'>"
        '            strResult &= "<div class='row'>"

        '            strResult &= "<div class='span2'>"
        '            ' strResult &= "<div class='notice  marker-on-right'>"
        '            'Anh Bia
        '            strResult &= "<div>"
        '            strCover = ""
        '            tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='COVER'"
        '            If tblData.DefaultView.Count > 0 Then
        '                If Not IsDBNull(tblData.DefaultView(0).Item("Content")) AndAlso tblData.DefaultView(0).Item("Content") <> "" Then
        '                    strCover = Me.getEDataPATH & tblData.DefaultView(0).Item("Content")
        '                Else
        '                    strCover = "Images/Imgviet/Books.png"
        '                End If
        '            End If
        '            strResult &= "<img src='" & strCover & "' class='rounded' id='" & arrIDs(intCount) & "' name='" & arrIDs(intCount) & "' style='z-index:1001;cursor:pointer;' onclick='showPopupDetail(" & arrIDs(intCount) & ")'>"
        '            strResult &= "</div>"
        '            'strResult &= "</div>"
        '            strResult &= "</div>"

        '            strResult &= "<div class='span10'>"
        '            'Thong tin ISSN
        '            If strISSN <> "" Then
        '                strResult &= "<span class='line-height'>"
        '                strResult &= "<strong>" & spISSN.InnerText & ":</strong> " & strISSN
        '                strResult &= "</span>"
        '                strResult &= "<br/>"
        '            End If

        '            'Thong tin tac gia
        '            If strAuthor <> "" Then
        '                strResult &= "<span class='line-height'>"
        '                strResult &= "<strong>" & spAuthor.InnerText & ":</strong> " & strAuthor
        '                strResult &= "</span>"
        '                strResult &= "<br/>"
        '            End If
        '            'Thong tin mo ta vat ly
        '            If strDesPhy <> "" Then
        '                strResult &= "<span class='line-height'>"
        '                strResult &= "<strong>" & spPhysicalInfo.InnerText & ":</strong> " & strDesPhy
        '                strResult &= "</span>"
        '                strResult &= "<br/>"
        '            End If
        '            'Thong tin xuat ban
        '            If strPublish <> "" Then
        '                strResult &= "<span class='line-height'>"
        '                strResult &= "<strong>" & spPublisherInfo.InnerText & ":</strong> " & strPublish
        '                strResult &= "</span>"
        '                strResult &= "<br/>"
        '            End If

        '            'Loai tai lieu
        '            If strType <> "" Then
        '                strResult &= "<span class='line-height'>"
        '                strResult &= "<strong>" & spItemType.InnerText & ":</strong> " & strType
        '                strResult &= "</span>"
        '                strResult &= "<br/>"
        '            End If

        '            'Du lieu dien tu
        '            If strEDATA <> "" Then
        '                Dim strArr() As String = Split(strEDATA, ";")
        '                If UBound(strArr) = 3 Then
        '                    strResult &= "<br/>"
        '                    strResult &= "<span class='line-height'>"
        '                    strResult &= "<strong>" & spEDATA.InnerText & ":</strong><a href='OViewLoading.aspx?fileType=" & strArr(1) & "&fileId=" & strArr(2) & "&ItemId=" & strArr(3) & "'>" & strArr(0) & spEDATAContent.InnerText & "</a>"
        '                    strResult &= "</span>"
        '                    strResult &= "<br/>"
        '                End If
        '            End If

        '            'Ranking
        '            If strRANKING <> "" Then
        '                strResult &= "<br/>"
        '                strResult &= "<div class='rating  fg-green small' data-role='rating' data-static='true' data-score='" & strRANKING & "'  data-stars='5' data-show-score='false' style='cursor:default;' >"
        '                strResult &= "</div>"
        '            End If

        '            strResult &= "</div>" 'div span10
        '            strResult &= "</div>" 'div grid no-margin
        '            strResult &= "</div>" 'div row
        '            strResult &= "</div>" 'div panel-content
        '        Next
        '        If intDic = 8 Then
        '            ltrBookList.Text = strResult
        '        ElseIf intDic = 1 Then
        '            ltrRelationAuthor.Text = strResult
        '        End If
        '    End If
        'End Sub

        ' purpose :  show books
        ' Creator: phuongtt
        Private Sub showBooks(ByVal tblData As DataTable, ByVal strIDs As String, ByVal intCurPage As Integer, ByVal intRecPerPage As Integer, Optional ByVal intDic As Integer = 8)
            Dim strTitle As String ' thong tin nhan de chinh
            Dim strDesPhy As String ' thong tin mo ta vat ly
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
            Dim rowView As DataRowView
            Dim intViews As Integer = 0
            Dim intViewRandom As Integer = 0
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
                    strTitle = FormatNumber((intRecPerPage * (intCurPage - 1)) + intCount + 1, 0) & ". " & strTitle

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

                    ''Thu vien
                    'strLibrary = ""
                    'If hidMutiLibrary.Value = "1" Then 'Hien thi tim kiem tren nhieu thu vien
                    '    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='LIBRARY'"
                    '    If tblData.DefaultView.Count > 0 Then
                    '        strLibrary = tblData.DefaultView(0).Item("Content") & ""
                    '    End If
                    'End If

                    ''Tom tat cho eBooks
                    'strBrief = ""
                    'tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='BRIEF'"
                    'If tblData.DefaultView.Count > 0 Then
                    '    strArrBrief = Split(tblData.DefaultView(0).Item("Content") & "", "@PHUONGTT@")
                    '    Try
                    '        intPageLink = strArrBrief(0)
                    '        'strBrief = clsUICommon.sumaryContents(strArrBrief(1), "<span style=""background-color:#60a917 !important;color:white;""><I>", 10, 50, 10, 40, , fCutContentLength)
                    '        strBrief = clsUICommon.sumaryContents(strArrBrief(1), "<span class=""hightlight-text"">", 10, 50, 10, 40, , fCutContentLength)

                    '        Dim strSearch As String = hidSearch.Value
                    '        strSearch = getCutVietnameseAccent(strSearch)
                    '        'strSearchFulltext = clsUICommon.getWordHightLight(strArrBrief(1), "<span style=""background-color:#60a917 !important;color:white;""><I>", Len(strSearch))
                    '        'CutContents(strArrBrief(1), "<span style=""background-color:#60a917 !important;color:white;""><I>")
                    '        strSearchFulltext = clsUICommon.getWordHightLight(strArrBrief(1), "<span class=""hightlight-text"">", Len(strSearch))
                    '    Catch ex As Exception
                    '    End Try
                    'End If

                    'Ma xep gia
                    strMXG = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='MXG'"
                    If tblData.DefaultView.Count > 0 Then
                        Dim intCountMXG As Integer = 0
                        For Each rowView In tblData.DefaultView
                            If intCountMXG < Application("callNumberLimit") Then
                                If Not IsDBNull(rowView.Item("Content")) Then
                                    strMXG &= "<U>" & rowView.Item("Content") & "</U>" & " "
                                End If
                            Else
                                strMXG &= "<a onclick='parent.showPopupDetail(" & arrIDs(intCount) & ")' class='lblinkfunction' style='cursor:pointer;'>" & "<span class=' icon-arrow-right-3'/>" & "</a> "
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
                    If strDesPhy <> "" Then
                        strResult &= "<p><span>" & strBeginBoldTag & spPhysicalInfo.InnerText & strEndBoldTag
                        strResult &= strDesPhy
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

                    ''Tom tat cho eBooks
                    'If strBrief <> "" Then
                    '    strArr = Split(strEDATA, ";")
                    '    If UBound(strArr) = 3 Then
                    '        'strResult &= "<hr />"
                    '        'strResult &= "<div style='text-align:justify;font-style:italic;'>"
                    '        'strResult &= "<a href='OViewLoading.aspx?fileType=" & strArr(1) & "&fileId=" & strArr(2) & "&ItemId=" & strArr(3) & "&pageno=" & intPageLink & "&fulltext=" & strSearchFulltext & "'>" & spPageLink.InnerHtml & Space(1) & intPageLink & "</a>&nbsp;" & strBrief
                    '        'strResult &= "</div>"
                    '        strResult &= "<div class=""search-item""><p>"
                    '        strResult &= "<a href='OViewLoading.aspx?fileType=" & strArr(1) & "&fileId=" & strArr(2) & "&ItemId=" & strArr(3) & "&pageno=" & intPageLink & "&fulltext=" & strSearchFulltext & "'>" & spPageLink.InnerHtml & Space(1) & intPageLink & "</a>&nbsp;" & strBrief
                    '        strResult &= "</p></div>"
                    '    End If
                    'End If

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
                    strResult &= "<div class=""rating"" data-role=""rating"" data-value=""" & strRANKING & """ data-static=""true"" data-show-score=""false""></div>"
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
                    'If strDesPhy <> "" Then
                    '    strResult &= "<span class='line-height'>"
                    '    strResult &= "<strong>" & spPhysicalInfo.InnerText & ":</strong> " & strDesPhy
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
                'ltrBookList.Text = strResult
                If intDic = 8 Then
                    ltrBookList.Text = strResult
                ElseIf intDic = 1 Then
                    ltrRelationAuthor.Text = strResult
                End If
            End If
        End Sub

        '' Dispose method
        '' Purpose: get icon and set to header panel
        'Private Function getIcons(ByVal iTem As Integer) As String
        '    Dim strResult As String = ""
        '    Try
        '        Dim strId As String = iTem & ","
        '        If InStr(clsSession.GlbMyListIds, strId) > 0 Then
        '            strResult = "<a class='element place-right' onclick='#'><span class='icon-checkmark' id='icon" & iTem & "' data-hint='|" & spInMyList.InnerText & "' data-hint-position='top'></span></a>"
        '        Else
        '            strResult = "<a class='element place-right' onclick='addMyList(" & iTem.ToString & ")'><span class='icon-plus' id='icon" & iTem & "' style='cursor:pointer;' data-hint='|" & spAddToMyList.InnerText & "' data-hint-position='top'></span></a>"
        '        End If
        '    Catch ex As Exception
        '    End Try
        '    Return strResult
        'End Function

        ' Dispose method
        ' Purpose: get icon and set to header panel
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


        ' Purpose : Write Comment
        ' Creator : PhuongTT
        Private Sub BindCommentBook(ByVal ItemID As Integer)
            Try
                Dim tblComment As New DataTable
                If CStr(Session("OPAC_COMENT") & "") = "1" Then
                    Dim intPagezise As Integer = Application("ePageSize")
                    Dim intPageLength As Integer = Application("ePageLength")
                    Dim intPageSpace As Integer = Application("ePageSpace")
                    Dim intTotal As Integer = 0
                    Dim intCurPage As Integer = hidCurrentPage.Value

                    objBOpacItem.ItemID = ItemID
                    tblComment = objBOpacItem.getCommentsOfPatronByItem(intCurPage, intPagezise)
                    If Not tblComment Is Nothing AndAlso tblComment.Rows.Count > 0 Then
                        Dim strResult As String = ""
                        Dim strPictureCard As String = ""
                        Dim strCommentator As String = ""
                        Dim strComments As String = ""
                        Dim intRANKING As Integer = 1
                        Dim strDate As String = ""
                        intTotal = tblComment.Rows(0).Item("Total")
                        For i As Integer = 0 To tblComment.Rows.Count - 1
                            strPictureCard = ""
                            strCommentator = ""
                            strComments = ""
                            intRANKING = 1
                            strDate = ""

                            If Not IsDBNull(tblComment.Rows(i).Item("PictureCard")) AndAlso tblComment.Rows(i).Item("PictureCard") <> "" Then
                                strPictureCard = Me.getPictureCardVirtualPath & "/" & tblComment.Rows(i).Item("PictureCard")
                            Else
                                If Not IsDBNull(tblComment.Rows(i).Item("Sex")) AndAlso tblComment.Rows(i).Item("Sex") = "1" Then
                                    strPictureCard = "Images/Imgviet/male.png"
                                Else
                                    strPictureCard = "Images/Imgviet/female.png"
                                End If
                            End If
                            'strPictureCard = "Images/Imgviet/female.png"


                            If Not IsDBNull(tblComment.Rows(i).Item("Commentator")) AndAlso tblComment.Rows(i).Item("Commentator") <> "" Then
                                strCommentator = tblComment.Rows(i).Item("Commentator")
                            End If
                            If Not IsDBNull(tblComment.Rows(i).Item("Comments")) AndAlso tblComment.Rows(i).Item("Comments") <> "" Then
                                strComments = tblComment.Rows(i).Item("Comments")
                            End If
                            If Not IsDBNull(tblComment.Rows(i).Item("Ranking")) AndAlso IsNumeric(tblComment.Rows(i).Item("Ranking")) Then
                                intRANKING = tblComment.Rows(i).Item("Ranking")
                            End If
                            If Not IsDBNull(tblComment.Rows(i).Item("CreatedDate")) Then
                                strDate = tblComment.Rows(i).Item("CreatedDate")
                            End If

                            'If strDate <> "" Then
                            '    strResult &= "<div class='panel-header'>"
                            '    strResult &= "<span class='place-right  tertiary-text-secondary'>"
                            '    strResult &= "<span class='icon-clock'></span>&nbsp;"
                            '    'strResult &= "<strong>" & strDate & "</strong> "
                            '    strResult &= strDate
                            '    strResult &= "</span>"
                            '    strResult &= "</div>"
                            'End If

                            If i Mod 2 Then
                                strResult &= "<div class=""feed-item"">"
                            Else
                                strResult &= "<div class=""feed-item  row-second"">"
                            End If
                            strResult &= "<div class=""item-img"">" & "<img src='" & strPictureCard & "'/></div>"
                            strResult &= "<div class=""feed-info"">"
                            strResult &= "<h2>" & strCommentator & "<span class='icon-clock'>&nbsp;" & strDate & "</span></h2>"
                            strResult &= "<div class=""info-star"">" 'Open Div6
                            Try
                                For kk As Integer = 1 To CInt(intRANKING)
                                    If kk = 1 Then
                                        strResult &= "<span class=""icon-star-4""></span>"
                                    Else
                                        strResult &= "<span class=""icon-star-3""></span>"
                                    End If
                                Next
                                For kk As Integer = 5 To CInt(intRANKING) + 1 Step -1
                                    strResult &= "<span class=""icon-star""></span>"
                                Next
                            Catch ex As Exception
                            End Try
                            strResult &= "</div>"

                            strResult &= "<p>" & strComments & "</p>"
                            strResult &= "</div>"
                            strResult &= "</div>"


                            'strResult &= "<div class='panel-content'>"

                            'strResult &= "<div class='grid no-margin'>"
                            'strResult &= "<div class='row'>"

                            'strResult &= "<div class='span1'>"
                            '' strResult &= "<div class='notice  marker-on-right'>"
                            ''Anh Bia
                            'strResult &= "<div>"
                            'strResult &= "<img src='" & strPictureCard & "' class='cycle' style='width:50px;height:50px;vertical-align:text-top;'>"
                            'strResult &= "</div>"
                            ''strResult &= "</div>"
                            'strResult &= "</div>"

                            'strResult &= "<div class='span11'>"
                            ''Thong tin strCommentator
                            'If intRANKING <> 0 Then
                            '    strResult &= "<span class='line-height'>"
                            '    strResult &= "<strong>" & strCommentator & "</strong> "
                            '    strResult &= "</span>"
                            '    strResult &= "<br/>"
                            'End If

                            ''Thong tin strComments
                            'If strComments <> "" Then
                            '    strResult &= "<span class='line-height' style='text-align:justify'>"
                            '    strResult &= strComments
                            '    strResult &= "</span>"
                            '    strResult &= "<br/>"
                            'End If

                            ''Ranking
                            'If intRANKING <> 0 Then
                            '    strResult &= "<div class='rating  fg-green small' data-role='rating' data-static='true' data-score='" & intRANKING & "'  data-stars='5' data-show-score='false' style='cursor:default;' >"
                            '    strResult &= "</div>"
                            'End If

                            'If strDate <> "" Then
                            '    strResult &= "<span class='place-right  tertiary-text-secondary'>"
                            '    strResult &= "<span class='icon-clock'></span>&nbsp;"
                            '    strResult &= strDate
                            '    strResult &= "</span>"
                            'End If

                            'strResult &= "</div>" 'div span10
                            'strResult &= "</div>" 'div grid no-margin
                            'strResult &= "</div>" 'div row
                            'strResult &= "</div>" 'div panel-content
                            'strResult &= "<hr/>"
                        Next

                        ltrComment.Text = strResult



                        Dim intSumPage As Integer = 0
                        Dim intStart, intStop As Integer
                        ' intSumPage = UBound(arrIDs) \ intRecPerPage + 1
                        intSumPage = (intTotal - 1) \ intPagezise + 1

                        '' Read current page number
                        'If IsNumeric(Request.QueryString("pg") & "") Then
                        '    intCurPage = CInt(Request.QueryString("pg") & "")
                        'Else
                        '    intCurPage = 1
                        'End If


                        intStart = (intCurPage - 1) * intPagezise
                        intStop = (((intCurPage - 1) * intPagezise) + intPagezise) - 1
                        If intStart > intTotal - 1 Then
                            intStart = intTotal - 1
                        End If
                        If intStop > intTotal - 1 Then
                            intStop = intTotal - 1
                        End If

                        Call showPagingControl(intTotal, intPagezise, intCurPage, intPageSpace, intPageLength, intStop)
                    Else
                        ltrComment.Text = ""
                        'panelComment.Visible = False
                    End If
                End If
            Catch ex As Exception
            End Try
        End Sub

        ' purpose :  show paging as google paging
        ' Creator: phuongtt
        Private Sub showPagingControl(ByVal intCount As Integer, ByVal intPagezise As Integer, ByVal intPage As Integer, ByVal intPageSpace As Integer, ByVal intPageLength As Integer, ByVal intStop As Integer)
            Try
                Dim iPage As Integer = CInt((intCount / intPagezise) + 0.4999)
                Dim strPagination As String = ""
                Dim PreviousPage As Integer = intPage - 1
                Dim NextPage As Integer = intPage + 1
                If PreviousPage >= 1 Then
                    strPagination &= "<li><a onclick='showComment(" & PreviousPage.ToString & ")' data-hint='|" & spPreviousPage.InnerText & "' data-hint-position='top' style='cursor:pointer;'><</a></li>"
                End If
                Dim xy As Integer = CInt((intPage / intPageSpace) + 0.4999)
                Dim alpha As Integer = (xy - 1) * intPageSpace
                Dim iPageCount As Integer = IIf(intPageLength + alpha <= iPage, intPageLength + alpha, iPage)

                For j As Integer = 1 + alpha To iPageCount
                    strPagination &= "<li>"
                    If j = intPage Then
                        strPagination &= "<a onclick='showComment(" & j.ToString & ")' class='PageSeleted'  style='cursor:pointer;'>" & j.ToString & "</a>"
                    Else
                        strPagination &= "<a onclick='showComment(" & j.ToString & ")'  style='cursor:pointer;'>" & j.ToString & "</a>"
                    End If
                    strPagination &= "</li>"
                Next
                If NextPage <= iPage Then
                    strPagination &= "<li><a onclick='showComment(" & NextPage.ToString & ")' data-hint='|" & spNextPage.InnerText & "' data-hint-position='top'  style='cursor:pointer;'>></a></li>"
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

        ' Dispose method
        ' Purpose: get item lists from session
        Private Sub getMyListItems()
            Try
                hidMyListIds.Value = clsSession.GlbMyListIds
            Catch ex As Exception
            End Try
        End Sub


        'Create method
        'Purpose: Create 
        'Input: some main infor: , ... and if intSelect = 0 select PatronName, 1 select CardNo
        'Output: 0 if fail, else is Max(ID)
        'Creater: PhuongTT
        'Date: 2014.09.07
        Public Function CreateComment(ByVal ItemID As Integer) As Integer
            Dim intResult As Integer = 0
            Dim intRating As Integer = 0
            Dim strComment As String = ""
            Dim strInfo As String = ""
            Try
                If (hidRating.Value <> 0) AndAlso hidComment.Value.Trim <> "" Then
                    If s3capcha1.IsValid Then
                        Dim intCommnent As Integer = 0
                        strComment = hidComment.Value.Trim
                        strComment = objBCommonStringProc.killChars(strComment)
                        strComment = Replace(Replace(strComment, "<", "&lt;"), ">", "&gt;")
                        strComment = Replace(strComment, vbCrLf, "<br />")
                        intRating = hidRating.Value
                        With objBOPACComment
                            .Comment = strComment
                            .Ranking = intRating
                            .ItemID = ItemID
                            .Code = clsSession.GlbUser
                            .Subject = ""
                            intCommnent = .Create(0) '0 PatronName, 1 CardNo 
                        End With
                        If intCommnent > 0 Then
                            'lrtInfo.Text = "<p class='text-success'>" & spCommentSuccess.InnerText & "</p>"
                            intResult = 3
                        Else
                            'lrtInfo.Text = "<p class='text-warning'>" & spCommentFail.InnerText & "</p>"
                            intResult = 2
                        End If
                    Else
                        'lrtInfo.Text = "<p class='text-alert'>" & spCapchaInfo.InnerText & "</p>"
                        intResult = 1
                    End If
                End If
            Catch ex As Exception
            End Try
            Return intResult
        End Function

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
                If Not objBOPACFile Is Nothing Then
                    objBOPACFile.Dispose(True)
                    objBOPACFile = Nothing
                End If
                If Not objBOpacItem Is Nothing Then
                    objBOpacItem.Dispose(True)
                    objBOpacItem = Nothing
                End If
                If Not objBSearchResult Is Nothing Then
                    objBSearchResult.Dispose(True)
                    objBSearchResult = Nothing
                End If
                If Not objBOPACDictionary Is Nothing Then
                    objBOPACDictionary.Dispose(True)
                    objBOPACDictionary = Nothing
                End If
                If Not objBOPACComment Is Nothing Then
                    Call objBOPACComment.Dispose(True)
                    objBOPACComment = Nothing
                End If
                If Not objBFilterBrowse Is Nothing Then
                    objBFilterBrowse.Dispose(True)
                    objBFilterBrowse = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Private Sub CommentOnSubmit_ServerClick(sender As Object, e As EventArgs) Handles CommentOnSubmit.ServerClick
            Try
                'Tao comment
                Dim intComment As Integer = 0
                intComment = CreateComment(intItemID)
                Call showDetail(intFileId, intItemID, intFileType, intComment)
            Catch ex As Exception
            End Try
        End Sub

        Private Sub raiseShowComment_Click(sender As Object, e As EventArgs) Handles raiseShowComment.Click
            Try
                Dim intCurrenPage As Integer = hidCurrentPage.Value
                Call showDetail(intFileId, intItemID, intFileType, 0, True)
            Catch ex As Exception
            End Try
        End Sub
    End Class
End Namespace
