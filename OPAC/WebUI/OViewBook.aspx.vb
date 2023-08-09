Imports eMicLibOPAC.BusinessRules.OPAC
Imports eMicLibOPAC.BusinessRules.Common
Imports System.Text.RegularExpressions
Imports System.IO

Namespace eMicLibOPAC.WebUI
    Public Class OViewBook
        Inherits System.Web.UI.Page
        'Inherits clsWBaseJqueryUI
        Protected objSysPara() As String
        Private objPara() As String = {"OPAC_FORUM_URL", "LDAP_LOCATION", "LDAP_SERVER_TYPE", "LDAP_LOGON_USER", "LDAP_LOGON_PASSWORD", "SMTP_SERVER", "ADMIN_EMAIL_ADDRESS", "EDATA_LOCATIONS", "OPAC_URL", "DATE_FORMAT", "OPAC_SERVER_LOCAL", "OPAC_SERVER_PUBLIC", "OPAC_PHYSICAL_PATH", "OPAC_PICTURE_PATH", "ROOT_SITE"}

        Private objBOPACFile As New clsBOPACFile
        Private objBOpacItem As New clsBOPACItem
        Private objBSearchResult As New clsBOPACSearchResult
        Private objBCommonStringProc As New clsBCommonStringProc
        Private objBOPACDictionary As New clsBOPACDictionary
        Private objBOPACComment As New clsBOPACComment
        Private objBFilterBrowse As New clsBOPACFilterBrowse
        Private objBPatron As New clsBOPACPatronInfor

        Private intFileId As Integer = 0
        Private intSubjectId As Integer = 0
        Private intPageNo As Integer = 1
        Private intItemID As Integer = 0
        Dim fulltext As String = ""
        Dim strCoverPicture As String = ""
        Dim strMainTitle As String = ""
        Private strBeginBoldTag As String = "<b>"
        Private strEndBoldTag As String = ":&nbsp;</b>"

        Public strUrlImage As String = ""
        Public strTitle As String = ""
        Dim objBCDBS As New eMicLibOPAC.BusinessRules.Common.clsBCommonDBSystem


        Public Sub GetSysPara()
            Try
                objSysPara = objBCDBS.GetSystemParameters(objPara)
            Catch ex As Exception
            End Try
        End Sub

        Public Function getEDataPATH() As String
            Dim strResult As String = ""
            Try
                strResult = objSysPara(11)
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        Public Function ChangeMapVirtualPath(ByVal strPath As String) As String
            Dim strResult As String = ""
            Try
                Dim strVirtualPath As String = ""
                Dim strPhysicalPath As String = objSysPara(12)
                If objSysPara(10).IndexOf(HttpContext.Current.Request.Url.Host.ToString) > 0 Then 'OPAC_SERVER_LOCAL
                    strVirtualPath = objSysPara(10)
                ElseIf objSysPara(11).IndexOf(HttpContext.Current.Request.Url.Host.ToString) > 0 Then 'OPAC_SERVER_PUBLIC
                    strVirtualPath = objSysPara(11)
                End If
                strResult = Replace(strPath, strPhysicalPath, strVirtualPath)
                strResult = Replace(strResult, "\", "/")
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        Public Function getPictureCardVirtualPath() As String
            Dim strResult As String = ""
            Try
                strResult = objSysPara(13)
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        Private Sub GetInfoItemShareFacebook(ByVal itemId As Integer)
            Dim tblTmp As New DataTable
            objBOPACFile.ItemID = itemId
            tblTmp = objBOPACFile.GetFileDetail
            If Not IsNothing(tblTmp) AndAlso tblTmp.Rows.Count > 0 Then
                If Not IsDBNull(tblTmp.Rows(0).Item("CoverPicture")) AndAlso tblTmp.Rows(0).Item("CoverPicture") <> "" Then
                    strUrlImage = Me.getEDataPATH & tblTmp.Rows(0).Item("CoverPicture")
                Else
                    strUrlImage = "Images/Imgviet/Books.png"
                End If

                If Not IsDBNull(tblTmp.Rows(0).Item("Content")) Then
                    strTitle = tblTmp.Rows(0).Item("Content")
                End If
            End If
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call checkPermission()
            Call Initialize()

            Try
                Call GetSysPara()
                Call GetInfoItemShareFacebook(CType(Request.QueryString("ItemID"), Integer))
            Catch ex As Exception

            End Try

            If (Not IsNothing(Session("FileExist"))) Then
                If (Session("FileExist") = "0") Then
                    Session.Remove("FileExist")
                    Page.RegisterClientScriptBlock("AlertJs", "<script type='text/javascript'>alert('File không tồn tại');</script>")
                End If
            End If

            Call BindScript()
            Call getMyListItems()
            'If Not IsPostBack Then
            '    'If Not IsNothing(Request("subjectId")) AndAlso Request("subjectId") <> "" Then
            '    '    intSubjectId = Request("subjectId")
            '    'End If
            '    'If Not IsNothing(Request("fileId")) AndAlso Request("fileId") <> "" Then
            '    '    intFileId = Request("fileId")
            '    'End If
            '    'If Not IsNothing(Request("ItemID")) AndAlso Request("ItemID") <> "" Then
            '    '    intItemID = Request("ItemID")
            '    'End If
            '    'hidItemID.Value = intItemID
            '    'If intFileId Then
            '    '    Call showDetail(intFileId, intItemID)
            '    'End If
            'End If
            If Not IsNothing(Request("pageno")) AndAlso Request("pageno") <> "" AndAlso hidPageNo.Value = 1 Then
                intPageNo = Request("pageno")
                hidPageNo.Value = intPageNo
            Else
                intPageNo = hidPageNo.Value
            End If
            If Not IsNothing(Request("fileId")) AndAlso Request("fileId") <> "" Then
                intFileId = Request("fileId")
            End If
            If Not IsNothing(Request("ItemID")) AndAlso Request("ItemID") <> "" Then
                intItemID = Request("ItemID")
            End If
            If Not IsNothing(Request("fulltext")) AndAlso Request("fulltext") <> "" Then
                fulltext = Request("fulltext")
            End If
            PanelDownLoad.Visible = False
            hidSearchContent.Value = fulltext
            hidItemID.Value = intItemID
            If intFileId Then
                If Not IsPostBack Then
                    Call showDetail(intFileId, intItemID, fulltext)

                    'objBPatron.CardNo = clsSession.GlbUser
                    'Dim bIsDownLoad As Boolean = objBPatron.GetIsDownLoad_ByPatronCode()
                    Dim bIsDownLoad As Boolean = False
                    objBOpacItem.ItemID = intItemID
                    Dim tblTmp As DataTable = objBOpacItem.GetAccessLevel()

                    If (Not IsNothing(tblTmp)) Then
                        If tblTmp.Rows.Count = 1 Then
                            Dim strAccessLevel As String = tblTmp.Rows(0).Item(0).ToString()
                            If (strAccessLevel = "0") Then
                                bIsDownLoad = True
                            End If
                        End If
                    End If

                    If bIsDownLoad = True Then
                        PanelDownLoad.Visible = True
                    End If
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

            objBOpacItem.ConnectionString = Session("ConnectionString")
            objBOpacItem.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBOpacItem.DBServer = Session("DBServer")
            objBOpacItem.Initialize()

            ' init objBSearchQr object
            objBSearchResult.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBSearchResult.DBServer = Session("DBServer")
            objBSearchResult.ConnectionString = Session("ConnectionString")
            objBSearchResult.Initialize()

            '  Init objBCommonStringProc
            objBCommonStringProc.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBCommonStringProc.ConnectionString = Session("ConnectionString")
            objBCommonStringProc.DBServer = Session("DBServer")
            objBCommonStringProc.Initialize()


            objBCDBS.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.Initialize()

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

            ' Init objBPatron object
            objBPatron.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBPatron.DBServer = Session("DBServer")
            objBPatron.ConnectionString = Session("ConnectionString")
            Call objBPatron.Initialize()

        End Sub


        Private Sub showDetail(ByVal FileId As Integer, ByVal ItemId As Integer, ByVal fulltext As String, Optional ByVal intComment As Integer = 0, Optional ByVal bolPage As Boolean = False)
            Try
                Dim tblTmp As New DataTable
                objBOPACFile.ItemID = ItemId
                tblTmp = objBOPACFile.GetFileDetail
                If Not IsNothing(tblTmp) AndAlso tblTmp.Rows.Count > 0 Then
                    Dim intItemID As Integer = 0
                    intItemID = tblTmp.Rows(0).Item("ItemID")

                    'Dim strSearchText As String = ""
                    'Cap nhat tai lieu vao combobox neu tai lieu co nhieu hon 1
                    Call FillFiles2Combobox(tblTmp)
                    'Cap nhat luot truy cap tai lieu
                    Call updateViews(intItemID)
                    'Tao muc luc
                    Call tableOfContent(intItemID)
                    'Kiem tra co fulltext doi voi tai lieu nay hay khong? 
                    Call checkFulltext(intItemID)
                    'Lay tai lieu lien quan: 1:Author, 3:KeyWord, 5 'Subjectheading,2 'publisher,  7 'NLM,4 'Series,6 'Language,8 'DDC
                    Dim DicID As Integer = clsSession.GlbClassification '8'DDC
                    Dim strAccessEntry As String = tblTmp.Rows(0).Item("AccessEntry")
                    Call getRelation(DicID, strAccessEntry, intItemID)
                    If Not IsDBNull(tblTmp.Rows(0).Item("Author")) Then
                        'Lay tai lieu lien quan cung tac gia
                        DicID = 1
                        strAccessEntry = tblTmp.Rows(0).Item("Author")
                        Call getRelationByAuthor(DicID, strAccessEntry, intItemID)
                        divRelationAuthor.Visible = True
                        'CollapsiblePanel4.Visible = True
                    Else
                        divRelationAuthor.Visible = False
                        'CollapsiblePanel4.Visible = False
                    End If

                    'Hien thi comment
                    Call BindCommentBook(intItemID)

                    'Dim strBook As String = ""

                    If Not IsDBNull(tblTmp.Rows(0).Item("CoverPicture")) AndAlso tblTmp.Rows(0).Item("CoverPicture") <> "" Then
                        strCoverPicture = Me.getEDataPATH & tblTmp.Rows(0).Item("CoverPicture")
                        strUrlImage = strCoverPicture
                    Else
                        strCoverPicture = "Images/Imgviet/Books.png"
                        strUrlImage = strCoverPicture
                    End If
                    'strBook &= "<div  class='span3'>"
                    'strBook &= "<img src='" & strCover & "' class='rounded'/>"
                    'strBook &= "</div>"
                    'Dim strTitle As String = ""
                    If Not IsDBNull(tblTmp.Rows(0).Item("Content")) Then
                        strMainTitle = tblTmp.Rows(0).Item("Content")
                        strTitle = strMainTitle
                    End If
                    'strBook &= "<div  class='span9'>"
                    'strBook &= "<span class='line-height'>"
                    'strBook &= "<strong>" & strTitle & "</strong> "
                    'strBook &= "</span>"
                    'strBook &= "</div>"
                    ''ltrBook.Text = strBook


                    Dim strXMLPath As String = ""
                    tblTmp.DefaultView.RowFilter = "ID=" & FileId
                    If tblTmp.DefaultView.Count > 0 Then
                        If Not IsDBNull(tblTmp.DefaultView(0).Item("XMLpath")) Then
                            strXMLPath = tblTmp.DefaultView(0).Item("XMLpath")
                        End If
                    End If
                    'Hien thi ebook
                    Call writeViewer(FileId, strXMLPath, fulltext, intComment, bolPage)

                    'Thong tin muc tu truy cap
                    Call BindRelationWordInfor(ItemId)
                End If
            Catch ex As Exception
            End Try
        End Sub

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

        Private Sub tableOfContent(ByVal ItemID As Integer)
            Try
                Dim dt As DataTable
                objBOPACFile.ItemID = ItemID
                dt = objBOPACFile.GetTreeviewTableOfContent
                If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                    CollapsiblePanel2.Style.Add("display", "block")
                    ltrTableOfContent.Text = tableOfContentTreeview(dt)
                Else
                    CollapsiblePanel2.Style.Add("display", "none")
                    'ltrTableOfContent.Text = spNoFound.InnerText
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Sub checkFulltext(ByVal ItemID As Integer)
            Try
                Dim dt As DataTable
                objBOPACFile.ItemID = ItemID
                dt = objBOPACFile.GetCountFulltext
                If Not IsNothing(dt) AndAlso dt.Rows(0).Item("ACOUNT") > 0 Then
                    '  divSearchContent.Visible = True
                    divHeaderView.Visible = True
                Else
                    '   divSearchContent.Visible = False
                    divHeaderView.Visible = False
                End If
            Catch ex As Exception
            End Try
        End Sub


        ' getDictionaryString method
        ' Purpose: get objects string to into browse
        Private Function tableOfContentTreeview(ByVal dt As DataTable) As String
            Dim strResult As String = ""
            Try
                Dim iCount As Integer = dt.Rows.Count - 1
                Dim intId As Integer = 0
                Dim intParentIdNextNode As Integer = 0
                Dim intParentIdPreviousNode As Integer = 0
                Dim intNodeId As Integer = 0
                Dim bolLeafNode As Boolean = False
                Dim intLevel As Integer = 1
                strResult &= "<div id='treeviewTableOfContent'>"
                strResult &= "<ul class='treeview' data-role='treeview'>"
                For i As Integer = 0 To iCount

                    intNodeId = dt.Rows(i).Item("ID")
                    If i + 1 <= iCount Then
                        If Not IsDBNull(dt.Rows(i + 1).Item("ParentID")) AndAlso dt.Rows(i + 1).Item("ParentID") > 0 Then
                            intParentIdNextNode = dt.Rows(i + 1).Item("ParentID")
                        Else
                            intParentIdNextNode = 0
                        End If
                    End If
                    bolLeafNode = False
                    If intParentIdNextNode <> intNodeId Then
                        bolLeafNode = True
                    End If

                    If Not IsDBNull(dt.Rows(i).Item("ParentID")) AndAlso dt.Rows(i).Item("ParentID") = 0 Then
                        If i <> 0 Then
                            'If intLevel = 1 Then
                            '    intLevel += 1
                            'End If
                            For k As Integer = 1 To intLevel - 1
                                strResult &= "</ul>"
                                strResult &= "</li>" 'Close child tag
                                'strResult &= "</ul>"
                                'strResult &= "</li>" 'Close 1 level
                            Next
                        End If
                        If bolLeafNode Then
                            strResult &= "<li><a href='#' onclick=""gotoPage(" & dt.Rows(i).Item("FileId") & "," & dt.Rows(i).Item("NumOfPage") & ")"">" & dt.Rows(i).Item("Name")  'leaf tag

                            strResult &= "</a></li>"
                        Else
                            strResult &= "<li class='node collapsed'>"
                            strResult &= "<a href='#' onclick=""gotoPage(" & dt.Rows(i).Item("FileId") & "," & dt.Rows(i).Item("NumOfPage") & ")""><span class='node-toggle'></span>" & dt.Rows(i).Item("Name")

                            strResult &= "</a>"
                            strResult &= "<ul>"
                        End If
                    Else
                        If bolLeafNode Then
                            'Neu la nut la thi thay the code --> codeFull
                            strResult &= "<li><a href='#' onclick=""gotoPage(" & dt.Rows(i).Item("FileId") & "," & dt.Rows(i).Item("NumOfPage") & ")"">" & dt.Rows(i).Item("Name")  'leaf tag

                            strResult &= "</a></li>"
                        Else
                            If intParentIdPreviousNode <> dt.Rows(i).Item("ParentID") AndAlso intParentIdPreviousNode <> 0 Then
                                strResult &= "</ul>"
                                strResult &= "</li>"
                            End If
                            strResult &= "<li class='node collapsed'>" 'Child tag
                            strResult &= "<a href='#' onclick=""gotoPage(" & dt.Rows(i).Item("FileId") & "," & dt.Rows(i).Item("NumOfPage") & ")""><span class='node-toggle'></span>" & dt.Rows(i).Item("Name")

                            strResult &= "</a>"
                            strResult &= "<ul>"
                        End If
                    End If

                    If Not IsDBNull(dt.Rows(i).Item("ParentID")) AndAlso dt.Rows(i).Item("ParentID") > 0 Then
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

        Private Sub FillFiles2Combobox(ByVal dt As DataTable)
            Try
                If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1

                    Next
                End If
                'Dim procs As New BusinessLayer.Opac
                'Dim _ilist As IList = procs.select_cat_files(_docid)
                'procs = Nothing
                'If (Not IsNothing(_ilist) AndAlso _ilist.Count > 0) Then
                '    cboFiles.Items.Clear()
                '    Dim intSequence As Integer = 0
                '    Dim intTotal As Integer = _ilist.Count
                '    For Each _list In _ilist
                '        cboFiles.Items.Insert(intSequence, New Telerik.Web.UI.RadComboBoxItem(span_part_file.InnerText & Space(1) & (intSequence + 1).ToString & "/" & intTotal.ToString, _list.id.ToString))
                '        intSequence += 1
                '    Next
                '    If _fileId > 0 Then
                '        cboFiles.SelectedValue = _fileId
                '    End If
                'End If
                'If (Not IsNothing(_ilist) AndAlso _ilist.Count > 1) Then
                '    multiMode.Visible = True
                '    lbltitle.Visible = False
                'Else
                '    multiMode.Visible = False
                '    lbltitle.Visible = True
                'End If
            Catch ex As Exception
            End Try
        End Sub

        Private Sub writeViewer(ByVal _fileId As Integer, ByVal _FileXML As String, ByVal _searchText As String, Optional ByVal intComment As Integer = 0, Optional ByVal bolPage As Boolean = False)
            Try
                Dim strLangcodePath As String = ""
                If clsSession.GlbLanguage = "vie" Then
                    strLangcodePath = Request.Url.AbsoluteUri.ToString.Substring(0, InStrRev(Request.Url.AbsoluteUri.ToString, "/")) & "Viewer/language/lang_vie.txt"
                Else
                    strLangcodePath = Request.Url.AbsoluteUri.ToString.Substring(0, InStrRev(Request.Url.AbsoluteUri.ToString, "/")) & "Viewer/language/lang_eng.txt"
                End If

                intPageNo = hidPageNo.Value
                Dim _xmlFile As String = ""
                Dim _strInfo As String = ""
                'If _FileXML.ToLower.EndsWith(".pdf") Then
                Dim _tempDir As String = _FileXML
                _tempDir = Me.ChangeMapVirtualPath(_tempDir)
                _xmlFile = _tempDir
                '_strInfo &= " writeMLbook('" & _xmlFile & "'," & intPageNo & ",'" & _searchText & "','" & strLangcodePath & "');" & vbCrLf
                _strInfo &= " MLbook(" & intItemID & "," & intPageNo & "," & _fileId & ");" & vbCrLf
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
                'End If
                _strInfo &= " SetVar(" & _fileId & ");" & vbCrLf
                clsUICommon.MyMsgBoxInfor(_strInfo, Me.Page)
            Catch ex As Exception
            End Try
        End Sub

        Private Sub updateViews(ByVal ItemID As Integer)
            Try
                'Dim bolResult As Boolean = objBOPACFile.updateViews(ItemID, DatePart(DateInterval.WeekOfYear, Now.Date), Now.Date.Month, Now.Date.Year)
                If Not String.IsNullOrEmpty(clsSession.GlbUser) Then
                    Dim bolResult As Boolean = objBOPACFile.updateViews(ItemID, DatePart(DateInterval.WeekOfYear, Now.Date), Now.Date.Month, Now.Date.Year, clsSession.GlbUser)
                Else
                    Dim bolResult As Boolean = objBOPACFile.updateViews(ItemID, DatePart(DateInterval.WeekOfYear, Now.Date), Now.Date.Month, Now.Date.Year)
                End If
            Catch ex As Exception
            End Try
        End Sub


        ' BindScript method
        ' Purpose: Bind JAVASCRIPTS
        Private Sub BindScript()
            'Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'js/OShow.js'></script>")
            'Dim strResults As String = ""
            'strResults &= vbCrLf
            'strResults &= String.Format("<meta property=""{0}"" itemprop=""{1}"" content=""{2}""></meta>", "og:url", "url", HttpUtility.UrlEncode(Request.Url.ToString()))
            'strResults &= vbCrLf
            'strResults &= String.Format("<meta property=""{0}"" content=""{1}""></meta>", "og:type", "website")
            'strResults &= vbCrLf

            'If strUrlImage <> "" Then
            '    strResults &= String.Format("<meta property=""{0}"" itemprop=""{1}"" content=""{2}""></meta>", "og:image", "thumbnailUrl", strUrlImage)
            '    strResults &= vbCrLf
            'End If

            'If strTitle <> "" Then
            '    strResults &= String.Format("<meta property=""{0}"" content=""{1}""></meta>", "og:title", strTitle)
            '    strResults &= vbCrLf
            '    strResults &= String.Format("<meta property=""{0}"" content=""{1}""></meta>", "og:site_name", strTitle)
            '    strResults &= vbCrLf
            'End If

            'Response.Write(strResults)
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
                'dtIds.Clear()
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
                    divRelationDocument.Visible = True
                    'CollapsiblePanel3.Visible = True
                Else
                    divRelationDocument.Visible = False
                    'CollapsiblePanel3.Visible = False
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
                    CollapsiblePanel4.Visible = True
                    divRelationAuthor.Visible = True
                    'CollapsiblePanel4.Visible = True
                Else
                    CollapsiblePanel4.Visible = False
                    divRelationAuthor.Visible = False
                    'CollapsiblePanel4.Visible = False
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
                    'strResult &= "<h2 class=""clr-cyan""><a onclick=""parent.showPopupDetail(" & arrIDs(intCount) & ")"" style=""cursor:pointer;"">"
                    If (strType = "Tài liệu điện tử") Or (strType = "Tài liệu số (Toàn văn)") Then
                        strResult &= "<h2 class=""clr-cyan-2""><a onclick=""parent.showPopupDetail(" & arrIDs(intCount) & ")"" style=""cursor:pointer;"">"
                    Else
                        If strEDATA <> "" Then
                            strArr = Split(strEDATA, ";")
                            If UBound(strArr) = 3 Then
                                strResult &= "<h2 class=""clr-cyan-2""><a onclick=""parent.showPopupDetail(" & arrIDs(intCount) & ")"" style=""cursor:pointer;"">"
                            Else
                                strResult &= "<h2 class=""clr-cyan""><a onclick=""parent.showPopupDetail(" & arrIDs(intCount) & ")"" style=""cursor:pointer;"">"
                            End If
                        Else
                            strResult &= "<h2 class=""clr-cyan""><a onclick=""parent.showPopupDetail(" & arrIDs(intCount) & ")"" style=""cursor:pointer;"">"
                        End If
                    End If
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

                    'strResult &= getIcons(arrIDs(intCount))
                    Dim strId As String = arrIDs(intCount) & ","
                    If InStr(clsSession.GlbMyListIds, strId) > 0 Then
                        strResult = "<h3 class=""uncheck"" id=""h" & arrIDs(intCount) & """><a onclick='parent.checkMyList(" & arrIDs(intCount).ToString & ")' style=""cursor:pointer;""><span class=""mif-heart-broken"" id=""icon" & arrIDs(intCount) & """></span><span id=""spCart" & arrIDs(intCount) & """>" & spCancelList.InnerText & "</span></a></h3>"
                    Else
                        If (strType = "Tài liệu điện tử") Or (strType = "Tài liệu số (Toàn văn)") Then
                            strResult &= "<h3 class='clr-cyan-3' id=""h" & arrIDs(intCount) & """><a onclick='parent.checkMyList(" & arrIDs(intCount).ToString & ")' style=""cursor:pointer;""><span class=""mif-heart"" id=""icon" & arrIDs(intCount) & """></span><span id=""spCart" & arrIDs(intCount) & """>" & spSaveList.InnerText & "</span></a></h3>"
                        Else
                            If strEDATA <> "" Then
                                strArr = Split(strEDATA, ";")
                                If UBound(strArr) = 3 Then
                                    strResult &= "<h3 class='clr-cyan-3' id=""h" & arrIDs(intCount) & """><a onclick='parent.checkMyList(" & arrIDs(intCount).ToString & ")' style=""cursor:pointer;""><span class=""mif-heart"" id=""icon" & arrIDs(intCount) & """></span><span id=""spCart" & arrIDs(intCount) & """>" & spSaveList.InnerText & "</span></a></h3>"
                                Else
                                    strResult &= "<h3 class='clr-cyan-2' id=""h" & arrIDs(intCount) & """><a onclick='parent.checkMyList(" & arrIDs(intCount).ToString & ")' style=""cursor:pointer;""><span class=""mif-heart"" id=""icon" & arrIDs(intCount) & """></span><span id=""spCart" & arrIDs(intCount) & """>" & spSaveList.InnerText & "</span></a></h3>"
                                End If
                            Else
                                strResult &= "<h3 class='clr-cyan-2' id=""h" & arrIDs(intCount) & """><a onclick='parent.checkMyList(" & arrIDs(intCount).ToString & ")' style=""cursor:pointer;""><span class=""mif-heart"" id=""icon" & arrIDs(intCount) & """></span><span id=""spCart" & arrIDs(intCount) & """>" & spSaveList.InnerText & "</span></a></h3>"
                            End If
                        End If
                    End If

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

                    Dim intDownLoads As Integer = 0
                    objBOpacItem.ItemID = CInt(arrIDs(intCount))
                    intDownLoads = objBOpacItem.GetCountDownLoad()

                    'Randomize()
                    'intViewRandom = Int(10000 * Rnd(1) + 1)
                    'strResult &= "<div class=""col-right-6 view""><span class=""icon-eye-2""></span>" & FormatNumber(intViewRandom, 0) & "</div>"
                    strResult &= "<div class=""col-right-6 view""><span class=""icon-download""></span>" & FormatNumber(intDownLoads, 0) & " <span class=""icon-eye-2""></span>" & FormatNumber(intViews, 0) & "</div>"
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


        '' Purpose : Write Comment
        '' Creator : PhuongTT
        'Private Sub BindCommentBook()
        '    Dim tblComment As New DataTable
        '    If CStr(Session("OPAC_COMENT") & "") = "1" Then
        '        trComment.Visible = True
        '        tblComment = objBOpacItem.GetCommentsByPatron
        '        lnkComment.NavigateUrl = "WComment.aspx?intItemID=" & objBOpacItem.ItemID
        '        lnkComment.CssClass = "lbGroupTitle"
        '        If Not tblComment Is Nothing AndAlso tblComment.Rows.Count > 0 Then
        '            dtgComment.Visible = True
        '            dtgComment.DataSource = tblComment
        '            dtgComment.DataBind()
        '        Else
        '            dtgComment.Visible = False
        '        End If
        '    Else
        '        trComment.Visible = False
        '    End If
        'End Sub


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
                        'strComment = objBCommonStringProc.killCharsProcessVal(strComment)
                        'strComment = Regex.Replace(strComment, "[^A-Za-z0-9$]", "")
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
                If Not objBCommonStringProc Is Nothing Then
                    objBCommonStringProc.Dispose(True)
                    objBCommonStringProc = Nothing
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
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBPatron Is Nothing Then
                    objBPatron.Dispose(True)
                    objBPatron = Nothing
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
                Call showDetail(intFileId, intItemID, fulltext, intComment)
            Catch ex As Exception
            End Try
        End Sub

        Private Sub raiseShowComment_Click(sender As Object, e As EventArgs) Handles raiseShowComment.Click
            Try
                Dim intCurrenPage As Integer = hidCurrentPage.Value
                Call showDetail(intFileId, intItemID, fulltext, 0, True)
            Catch ex As Exception
            End Try
        End Sub

        Protected Sub btnDownLoad_Click(sender As Object, e As EventArgs) Handles btnDownLoad.Click
            Dim strItemId As String = ""
            Dim strFileId As String = ""
            If Not IsNothing(Request.QueryString("ItemID")) Then
                strItemId = Request.QueryString("ItemID")
            End If
            If Not IsNothing(Request.QueryString("fileId")) Then
                strFileId = Request.QueryString("fileId")
            End If

            If strItemId <> "" And strFileId <> "" Then
                objBOPACFile.FileID = CInt(strFileId)
                objBOPACFile.ItemID = CInt(strItemId)
                Dim tblResult As DataTable = objBOPACFile.GetItemFile()

                If Not (tblResult Is Nothing) Then
                    If tblResult.Rows.Count = 1 Then
                        Dim strFileName As String = tblResult.Rows(0).Item("FileName").ToString()
                        Dim strPathFile As String = tblResult.Rows(0).Item("Path").ToString()

                        objBOpacItem.ItemID = CInt(strItemId)
                        objBOpacItem.CreditItemDownLoadFile(clsSession.GlbUser)

                        If (File.Exists(strPathFile)) Then

                            Response.Clear()
                            Response.AddHeader("content-disposition", "attachment;filename=" & strFileName)
                            Response.ContentType = "application/pdf"
                            Response.WriteFile(strPathFile)
                            Response.Flush()
                            Response.End()
                        Else
                            Session("FileExist") = "0"
                            Response.Redirect(Request.Url.AbsoluteUri)

                        End If
                    End If
                End If

                
            End If

        End Sub
    End Class
End Namespace
