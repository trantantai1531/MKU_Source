Imports System.IO
Imports System.IO.Path
Imports eMicLibOPAC.BusinessRules.OPAC
Imports System.Web.Services
Imports Telerik.Web.UI
Imports System.Linq

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class OIndex
        Inherits clsWBaseJqueryUI

        Private objBOpacItem As New clsBOPACItem
        Private objBNews As New clsBCAT_News
        Private objBeMagazine As New clsBOPACeMagazine
        Private objBType As New clsBCAT_Type
        Private objBFilterBrowse As New clsBOPACFilterBrowse
        Private objBPeriodical As New clsBPeriodical
        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call Initialize()
            'Call BindScript()
            If Not Page.IsPostBack Then
                Call BindData()
                Call BindDataNews()
                Call showCollection()
                '    Call showMagazine()
                Call showDigitalDocument()
                '    Call checkSiteLink()
                Call loadSiteMap()

            End If

        End Sub

        ' Init method
        ' purpose initialize all components
        ' Creator : phuongtt
        Private Sub Initialize()
            objBType.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBType.DBServer = Session("DBServer")
            objBType.ConnectionString = Session("ConnectionString")
            objBType.Initialize()

            ' init OPACItem object
            objBOpacItem.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBOpacItem.DBServer = Session("DBServer")
            objBOpacItem.ConnectionString = Session("ConnectionString")
            objBOpacItem.Initialize()

            objBNews.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBNews.DBServer = Session("DBServer")
            objBNews.ConnectionString = Session("ConnectionString")
            objBNews.Initialize()

            ' Init objBHoldingInfo object
            objBeMagazine.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBeMagazine.DBServer = Session("DBServer")
            objBeMagazine.ConnectionString = Session("ConnectionString")
            Call objBeMagazine.Initialize()

            objBFilterBrowse.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBFilterBrowse.DBServer = Session("DBServer")
            objBFilterBrowse.ConnectionString = Session("ConnectionString")
            Call objBFilterBrowse.Initialize()

            objBPeriodical.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBPeriodical.DBServer = Session("DBServer")
            objBPeriodical.ConnectionString = Session("ConnectionString")
            Call objBPeriodical.Initialize()

        End Sub

        'Private Sub showMagazine()
        '    Try
        '        Dim strResult As String = ""
        '        Dim tblOPACMagazine As DataTable
        '        tblOPACMagazine = objBeMagazine.GetMagazineNumberHome(clsSession.GlbSite)
        '        If Not tblOPACMagazine Is Nothing AndAlso tblOPACMagazine.Rows.Count > 0 Then
        '            diveNewsManazine.Visible = True
        '            Dim strImageCover As String = ""
        '            Dim strDate As String = ""
        '            Dim strNum As String = ""
        '            Dim strTitle As String = ""
        '            For i As Integer = 0 To tblOPACMagazine.Rows.Count - 1
        '                strTitle = ""
        '                If Not IsDBNull(tblOPACMagazine.Rows(i).Item("Content")) Then
        '                    strTitle = tblOPACMagazine.Rows(i).Item("Content").ToString
        '                End If
        '                strImageCover = ""
        '                If Not IsDBNull(tblOPACMagazine.Rows(i).Item("Thumnail")) Then
        '                    strImageCover = Me.ChangeMapVirtualPath(tblOPACMagazine.Rows(i).Item("Thumnail").ToString)
        '                End If
        '                strNum = ""
        '                If Not IsDBNull(tblOPACMagazine.Rows(i).Item("eNum")) Then
        '                    strNum = tblOPACMagazine.Rows(i).Item("eNum")
        '                End If
        '                strDate = ""
        '                If Not IsDBNull(tblOPACMagazine.Rows(i).Item("eDay")) Then
        '                    strDate &= tblOPACMagazine.Rows(i).Item("eDay")
        '                End If
        '                If Not IsDBNull(tblOPACMagazine.Rows(i).Item("eMonth")) Then
        '                    strDate &= "/" & tblOPACMagazine.Rows(i).Item("eMonth")
        '                End If
        '                If Not IsDBNull(tblOPACMagazine.Rows(i).Item("eYear")) Then
        '                    strDate &= "/" & tblOPACMagazine.Rows(i).Item("eYear")
        '                End If
        '                If strDate <> "" Then
        '                    strDate = strNum & " (" & strDate & ")"
        '                End If

        '                strResult &= "<div class='tile-content image'>"
        '                strResult &= spMagazine.InnerHtml
        '                'strResult &= "<img src='" & strImageCover & "' onClick='showMagazineList(" & tblOPACMagazine.Rows(i).Item("ItemID").ToString & ")' />"
        '                strResult &= "<img src='OShowPic.aspx?FilePath=" & tblOPACMagazine.Rows(i).Item("XMLpath") & "' onClick='showMagazineList(" & tblOPACMagazine.Rows(i).Item("ItemID").ToString & ")' style='border:1px #eaeaea solid;' />"
        '                strResult &= "<div class='tile-status bg-dark opacity'>"
        '                strResult &= "<span class='label'>"
        '                strResult &= strTitle & " - " & strDate
        '                strResult &= "</span>"
        '                strResult &= "</div>"
        '                strResult &= "</div>"
        '            Next
        '            ltrMagazine.Text = strResult
        '        Else
        '            'strResult &= "<div class='tile-content image'>"
        '            'strResult &= "<img src='images/Library/Advertising1.jpg' />"
        '            'strResult &= "<div class='tile-status bg-dark opacity'>"
        '            'strResult &= "<span class='label'>"
        '            'strResult &= "Quảng cáo 1"
        '            'strResult &= "</span>"
        '            'strResult &= "</div>"
        '            'strResult &= "</div>"

        '            'strResult &= "<div class='tile-content image'>"
        '            'strResult &= "<img src='images/Library/Advertising5.jpg' />"
        '            'strResult &= "<div class='tile-status bg-dark opacity'>"
        '            'strResult &= "<span class='label'>"
        '            'strResult &= "Quảng cáo 2"
        '            'strResult &= "</span>"
        '            'strResult &= "</div>"
        '            'strResult &= "</div>"

        '            'strResult &= "<div class='tile-content image'>"
        '            'strResult &= "<img src='images/Library/Advertising6.jpg' />"
        '            'strResult &= "<div class='tile-status bg-dark opacity'>"
        '            'strResult &= "<span class='label'>"
        '            'strResult &= "Quảng cáo 3"
        '            'strResult &= "</span>"
        '            'strResult &= "</div>"
        '            'strResult &= "</div>"

        '            'strResult &= "<div class='tile-content image'>"
        '            'strResult &= "<img src='images/Library/Advertising7.jpg' />"
        '            'strResult &= "<div class='tile-status bg-dark opacity'>"
        '            'strResult &= "<span class='label'>"
        '            'strResult &= "Quảng cáo 4"
        '            'strResult &= "</span>"
        '            'strResult &= "</div>"
        '            'strResult &= "</div>"

        '            diveNewsManazine.Visible = False
        '            ltrMagazine.Text = strResult
        '        End If
        '    Catch ex As Exception
        '    End Try
        'End Sub

        Private Sub showCollection()
            Try
                Dim strResult As String = ""
                Dim tblOPACItem As DataTable
                tblOPACItem = objBOpacItem.GetCollectionForHome(clsSession.GlbSite)
                If Not tblOPACItem Is Nothing AndAlso tblOPACItem.Rows.Count > 0 Then

                    Dim rand As Random = New Random()
                    tblOPACItem = tblOPACItem.Select().AsEnumerable().OrderBy(Function(x) rand.Next()).CopyToDataTable()
                    'divCollection.Visible = True
                    Dim strTempImageCover As String = ""
                    Dim strTempImageCoverTemp As String = ""
                    Dim strImageCover As String = ""
                    For i As Integer = 0 To tblOPACItem.Rows.Count - 1
                        strImageCover = ""
                        strTempImageCover = tblOPACItem.Rows(i).Item("Cover").ToString
                        If File.Exists(strTempImageCover) Then
                            strTempImageCoverTemp = Server.MapPath("~") & "/Upload/ImageCover/" & tblOPACItem.Rows(i).Item("ID").ToString
                            strTempImageCoverTemp = Replace(strTempImageCoverTemp, "/", "\")
                            If Not Directory.Exists(strTempImageCoverTemp) Then
                                Directory.CreateDirectory(strTempImageCoverTemp)
                            End If
                            strTempImageCoverTemp &= "\" & GetFileName(strTempImageCover)
                            If Not File.Exists(strTempImageCoverTemp) Then
                                File.Copy(strTempImageCover, strTempImageCoverTemp)
                            End If
                            strImageCover = "Upload/ImageCover/" & tblOPACItem.Rows(i).Item("ID").ToString & "/" & GetFileName(strTempImageCover)
                        End If

                        'strResult &= "<div class='slide'  data-hint='" & tblOPACItem.Rows(i).Item("DisplayEntry").ToString & "'  data-hint-position='top'>'"
                        'strResult &= Replace(spDescriptionCollection.InnerHtml, "@PHUONGTT@", tblOPACItem.Rows(i).Item("DisplayEntry").ToString)
                        'strResult &= "<img src='" & strImageCover & "' onClick='gotoShowRecord(14," & tblOPACItem.Rows(i).Item("ID").ToString & ")' />"
                        'strResult &= "</div>"
                        'strResult &= "<br />"


                        strResult &= "<div>"
                        strResult &= "<div style='width:600px; height:332px'>"
                        strResult &= "<a href='javascript:parent.gotoShowRecord(14," & tblOPACItem.Rows(i).Item("ID").ToString & ")" & ";'>"
                        strResult &= "<img  u='image' src='" & strImageCover & "' style='margin-top:35px; width:600px; height:297px;'/>"
                        strResult &= "</a>"
                        strResult &= "<div u=caption t='*' class='captionOrange'  style='position:absolute; left:0px; top: 0px; width:600px; height:30px; margin-top:0px; margin-right:0px; margin-left:0px;'> "
                        strResult &= tblOPACItem.Rows(i).Item("DisplayEntry").ToString
                        strResult &= "</div>"
                        strResult &= "</div>"

                        strResult &= "</div>"
                    Next
                Else
                    'divCollection.Visible = False
                End If
                lrtCollection.Text = strResult
            Catch ex As Exception
            End Try
        End Sub


        Private Sub showDigitalDocument()
            Try
                Dim intMagazine As Integer = 0
                Dim intEbook As Integer = 0
                Dim intAudioBook As Integer = 0
                Dim intPictue As Integer = 0
                Dim intMedia As Integer = 0
                Dim tblOPACItem As DataTable

                tblOPACItem = objBOpacItem.GetItemFileCount(clsSession.GlbSite)
                If Not tblOPACItem Is Nothing AndAlso tblOPACItem.Rows.Count > 0 Then
                    tblOPACItem.DefaultView.RowFilter = "ITYPE='EBOOK'"
                    If tblOPACItem.DefaultView.Count > 0 Then
                        intEbook = tblOPACItem.DefaultView(0).Item("ICOUNT")
                    End If
                End If
                
                tblOPACItem = objBOpacItem.GetDigitalDocumentCount(clsSession.GlbSite)
                If Not tblOPACItem Is Nothing AndAlso tblOPACItem.Rows.Count > 0 Then
                    'tblOPACItem.DefaultView.RowFilter = "ITYPE='EBOOK'"
                    'If tblOPACItem.DefaultView.Count > 0 Then
                    '    intEbook = tblOPACItem.DefaultView(0).Item("ICOUNT")
                    'End If
                    tblOPACItem.DefaultView.RowFilter = "ITYPE='AUDIOBOOK'"
                    If tblOPACItem.DefaultView.Count > 0 Then
                        intAudioBook = tblOPACItem.DefaultView(0).Item("ICOUNT")
                    End If
                    tblOPACItem.DefaultView.RowFilter = "ITYPE='PICTURE'"
                    If tblOPACItem.DefaultView.Count > 0 Then
                        intPictue = tblOPACItem.DefaultView(0).Item("ICOUNT")
                    End If
                    tblOPACItem.DefaultView.RowFilter = "ITYPE='MEIDA'"
                    If tblOPACItem.DefaultView.Count > 0 Then
                        intMedia = tblOPACItem.DefaultView(0).Item("ICOUNT")
                    End If
                End If

                Dim countDissertation As Integer = objBOpacItem.GetCountItemByTypeID(3)

                spEbooks.InnerHtml = spEbooks.InnerHtml & " (" & intEbook & ")"
                spAudioEbooks.InnerHtml = spAudioEbooks.InnerHtml & " (" & intAudioBook & ")"
                spDissertation.InnerHtml = spDissertation.InnerHtml & " (" & countDissertation & ")"

                'Dim tblResultType As DataTable = objBOpacItem.GetItem(23) '23: ItemType : CdRom

                'If Not tblResultType Is Nothing AndAlso tblResultType.Rows.Count > 0 Then
                '    Dim countTypeCdRom As String = tblResultType.Rows(0).Item("CountType").ToString()
                '    spPicture.InnerHtml = spPicture.InnerHtml & " (" & countTypeCdRom & ")"
                'Else
                '    spPicture.InnerHtml = spPicture.InnerHtml & " (0)"
                'End If

                'tblResultType = objBOpacItem.GetItem(10) '10: ItemType : Film / Video
                'If Not tblResultType Is Nothing AndAlso tblResultType.Rows.Count > 0 Then
                '    Dim countTypeFilm As String = tblResultType.Rows(0).Item("CountType").ToString()
                '    spMedia.InnerHtml = spMedia.InnerHtml & " (" & countTypeFilm & ")"
                'Else
                '    spMedia.InnerHtml = spMedia.InnerHtml & " (0)"
                'End If

                Dim tblResultType As DataTable = objBOpacItem.GetItem(17) '23: ItemType : CdRom
                If Not tblResultType Is Nothing AndAlso tblResultType.Rows.Count > 0 Then
                    Dim countTypeCdRom As String = tblResultType.Rows(0).Item("CountType").ToString()
                    spGTCapTruong.InnerHtml = spGTCapTruong.InnerHtml & " (" & countTypeCdRom & ")"
                Else
                    spGTCapTruong.InnerHtml = spGTCapTruong.InnerHtml & " (0)"
                End If

                tblResultType = objBOpacItem.GetItem(16) '10: ItemType : Film / Video
                If Not tblResultType Is Nothing AndAlso tblResultType.Rows.Count > 0 Then
                    Dim countTypeFilm As String = tblResultType.Rows(0).Item("CountType").ToString()
                    spBGMonHoc.InnerHtml = spBGMonHoc.InnerHtml & " (" & countTypeFilm & ")"
                Else
                    spBGMonHoc.InnerHtml = spBGMonHoc.InnerHtml & " (0)"
                End If

                'Dim tblOPACMagazine As DataTable
                'tblOPACMagazine = objBeMagazine.GetMagazineNumberHome(clsSession.GlbSite)
                'If Not tblOPACMagazine Is Nothing AndAlso tblOPACMagazine.Rows.Count > 0 Then
                '    intMagazine = tblOPACMagazine.Rows.Count
                'End If

                'spMagazine.InnerHtml = spMagazine.InnerHtml & " (" & intMagazine & ")"

                Dim tblOPACSerial As DataTable = objBPeriodical.CreateReportByAcqSourceStatus()
                Dim intOpacSerial As Integer = 0
                If (Not (IsNothing(tblOPACSerial))) Then
                    intOpacSerial = tblOPACSerial.Rows.Count
                End If

                spMagazine.InnerHtml = spMagazine.InnerHtml & " (" & intOpacSerial & ")"

                Dim tblTemp As DataView
                objBFilterBrowse.Ids = "SELECT DISTINCT EMIL.ID FROM (SELECT distinct  b.ID	FROM Cat_tblDic_ItemType a JOIN Lib_tblItem b on a.ID = b.TypeID WHERE a.ID  = 1  And ( b.LibId = " + clsSession.GlbSite.ToString() + " or b.LibID = 9999)) EMIL"
                'tblTemp = objBFilterBrowse.GetFilterBrowseByMerge(clsSession.GlbTopTopics)
                tblTemp = objBFilterBrowse.RunQuerySql(objBFilterBrowse.Ids).DefaultView
                Dim bookCount = 0
                Dim indexCountBook As Integer = 0
                'If Not tblTemp Is Nothing Then
                '    For Each dtr As DataRow In tblTemp.Table.Rows
                '        If dtr.Item("Type") = 10 Then
                '            bookCount = tblTemp.Table.Rows(indexCountBook).Item("NumberNo")
                '        End If
                '        indexCountBook = indexCountBook + 1
                '    Next

                'End If
                If Not tblTemp Is Nothing Then
                    bookCount = tblTemp.Table.Rows.Count
                End If
                spBook.InnerHtml = spBook.InnerHtml & " (" & bookCount & ")"

            Catch ex As Exception
            End Try
        End Sub

        Private Sub BindDataNews()
            Try
                'In ra tin tức mới nhất có Status = 1 and Hot = 1
                Dim tblNews As DataTable
                objBNews.NN = "vn"
                tblNews = objBNews.CAT_News_SelectIndex(clsSession.GlbSite)

                If Not tblNews Is Nothing AndAlso tblNews.Rows.Count > 0 Then
                    Dim strNews As String = ""
                    Dim strTempImageCover As String = ""
                    Dim strTempImageCoverTemp As String = ""
                    Dim strImageCover As String = ""
                    Dim strTempImageCover1 As String = ""

                    Dim intTop As Integer = 4

                    If tblNews.Rows.Count < intTop Then
                        intTop = tblNews.Rows.Count
                    End If

                    For i As Integer = 0 To intTop - 1 'tblNews.Rows.Count - 1
                        Dim strAnh As String = ""
                        Dim strTom_tat As String = ""
                        Dim intView As String = ""
                        'If i = 0 Then
                        '    strImageCover = ""
                        '    strTempImageCover = ""
                        '    If Not IsDBNull(tblNews.Rows(i).Item("Anh")) AndAlso tblNews.Rows(i).Item("Anh").ToString.Trim <> "" Then
                        '        strTempImageCover = tblNews.Rows(i).Item("Anh").ToString
                        '        strTempImageCover = getRootSiteAdmin() & "\upload\TT\" & strTempImageCover
                        '    End If
                        '    If File.Exists(strTempImageCover) Then
                        '        strTempImageCoverTemp = Server.MapPath("~") & "/upload/TT/" & tblNews.Rows(i).Item("id")
                        '        strTempImageCoverTemp = Replace(strTempImageCoverTemp, "/", "\")
                        '        If Not Directory.Exists(strTempImageCoverTemp) Then
                        '            Directory.CreateDirectory(strTempImageCoverTemp)
                        '        End If
                        '        strTempImageCoverTemp &= "\" & GetFileName(strTempImageCover)
                        '        If Not File.Exists(strTempImageCoverTemp) Then
                        '            File.Copy(strTempImageCover, strTempImageCoverTemp)
                        '        End If
                        '        strImageCover = "upload/TT/" & tblNews.Rows(i).Item("id") & "/" & GetFileName(strTempImageCover)
                        '    End If

                        '    strNews &= "<li>"
                        '    strNews &= "<img src='" & strImageCover & "'  alt='" & tblNews.Rows(i).Item("Anh") & "'/>"
                        '    strNews &= "<h2><a href='ONewsDetails.aspx?cat=" & changeURL(tblNews.Rows(i).Item("Tieu_de")) & "&id=" & tblNews.Rows(i).Item("id") & "'>"
                        '    strNews &= "<span style='text-align: justify; display:block;'>" & tblNews.Rows(i).Item("Tieu_de") & "</span>"
                        '    strNews &= "</a></h2>"
                        '    strNews &= "</li>"
                        'Else
                        '    strNews &= "<li><h2><a href='ONewsDetails.aspx?cat=" & changeURL(tblNews.Rows(i).Item("Tieu_de")) & "&id=" & tblNews.Rows(i).Item("id") & "'>"
                        '    strNews &= "<span style='text-align: justify; display:block;'>" & tblNews.Rows(i).Item("Tieu_de") & "</span>"
                        '    strNews &= "</a></h2>"
                        '    strNews &= "</li>"
                        'End If

                        strNews &= "<article class=""list-item unit4"">"
                        strNews &= "<div class=""item-lesson box-raised"">"
                        strNews &= "<a href=""ONewsDetails.aspx?cat=" & GetFileName(tblNews.Rows(i)("Tieu_de").ToString) & "&id=" & tblNews.Rows(i)("id").ToString & """>"
                        strNews &= "<h2 class=""clr-cyan""><span>" & tblNews.Rows(i)("Tieu_de").ToString & "</span></h2>"
                        strAnh = "Images/News/News-image.png"
                        strTempImageCover = ""
                        If Not IsDBNull(tblNews.Rows(i).Item("Anh")) AndAlso tblNews.Rows(i).Item("Anh").ToString.Trim <> "" Then
                            strTempImageCover = tblNews.Rows(i).Item("Anh").ToString
                            strTempImageCover1 = tblNews.Rows(i).Item("Anh").ToString
                            strTempImageCover = getRootSiteAdmin() & "\upload\TT\" & strTempImageCover
                        End If
                        If File.Exists(strTempImageCover) Then
                            strTempImageCoverTemp = Server.MapPath("~") & "/upload/TT/" & tblNews.Rows(i).Item("id")
                            strTempImageCoverTemp = Replace(strTempImageCoverTemp, "/", "\")
                            If Not Directory.Exists(strTempImageCoverTemp) Then
                                Directory.CreateDirectory(strTempImageCoverTemp)
                            End If
                            strTempImageCoverTemp &= "\" & strTempImageCover1
                            If Not File.Exists(strTempImageCoverTemp) Then
                                File.Copy(strTempImageCover, strTempImageCoverTemp)
                            End If
                            strAnh = "upload/TT/" & tblNews.Rows(i).Item("id") & "/" & strTempImageCover1
                        End If
                        strNews &= "<div class=""img-box""><img src='" & strAnh & "'  alt='" & strAnh & "'/></div>"
                        strTom_tat = ""
                        If Not IsDBNull(tblNews.Rows(i).Item("Tom_tat")) AndAlso tblNews.Rows(i).Item("Tom_tat").ToString.Trim <> "" Then
                            strTom_tat = tblNews.Rows(i).Item("Tom_tat").ToString
                        End If
                        strNews &= "<p style='text-align:justify;'>" & clsCommon.Cat_Chuoi(200, strTom_tat) & "</p>"
                        'intViewRandom = Int(10000 * Rnd(1) + 1)
                        intView = tblNews.Rows(i).Item("ViewCount").ToString.Trim
                        strNews &= "<div class=""more-detail ClearFix""><span class=""icon-eye-2""></span>" & intView & "</div>"
                        strNews &= "</a>"
                        strNews &= "</div>"
                        strNews &= "</article>"

                    Next
                    ltrNews.Text = strNews
                    'divNews.Visible = True
                    'rptNews.DataSource = tblNews
                    'rptNews.DataBind()
                Else
                    'divNews.Visible = False
                    ltrNews.Text = ""
                End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub BindData()
            Try


                Dim tblOPACItem As DataTable
                'tblOPACItem = objBOpacItem.GetGeneralInfor(clsSession.GlbSite)
                'If Not tblOPACItem Is Nothing AndAlso tblOPACItem.Rows.Count > 0 Then
                '    tblOPACItem.DefaultView.RowFilter = "FieldName='Item'"
                '    spTotalItem.InnerHtml = "<strong>" & FormatNumber(CStr(tblOPACItem.DefaultView(0).Item("NOR")), 0) & "</strong>"
                '    tblOPACItem.DefaultView.RowFilter = "FieldName='Holding'"
                '    spTotalItemCopy.InnerHtml = "<strong>" & FormatNumber(CStr(tblOPACItem.DefaultView(0).Item("NOR")), 0) & "</strong>"
                '    tblOPACItem.DefaultView.RowFilter = "FieldName='Serials'"
                '    spTotalItemMagazine.InnerHtml = "<strong>" & FormatNumber(CStr(tblOPACItem.DefaultView(0).Item("NOR")), 0) & "</strong>"
                '    tblOPACItem.DefaultView.RowFilter = "FieldName='EDATA'"
                '    spTotalDigital.InnerHtml = "<strong>" & FormatNumber(CStr(tblOPACItem.DefaultView(0).Item("NOR")), 0) & "</strong>"
                'Else
                '    spTotalItem.InnerText = 0
                '    spTotalItem.InnerText = 0
                '    spTotalItem.InnerText = 0
                '    spTotalDigital.InnerText = 0
                'End If

                ' In ra nhung an pham moi nhat co den thoi diem nay
                tblOPACItem = objBOpacItem.GetNewItem(Session("Secured_OPAC"), CInt(Session("SecretLevel")), 0, 8, clsSession.GlbSite)
                If Not tblOPACItem Is Nothing AndAlso tblOPACItem.Rows.Count > 0 Then
                    Dim strTopNewItem As String = ""
                    For i As Integer = 0 To tblOPACItem.Rows.Count - 1
                        If Not IsDBNull(tblOPACItem.Rows(i).Item("Content")) Then
                            'strTopNewItem &= "<li style='width: 90%'>" & tblOPACItem.Rows(i).Item("Content") & "</li>"
                            strTopNewItem &= "<li><h2><span class='icon-book clr-cyan'></span>"
                            strTopNewItem &= tblOPACItem.Rows(i).Item("Content")
                            strTopNewItem &= "</h2></li>"
                        End If
                    Next
                    ltrTopNewItem.Text = strTopNewItem
                Else
                    ltrTopNewItem.Text = ""
                End If

                ' In ra nhung an pham muon nhieu nhat
                tblOPACItem = objBOpacItem.GetBestItems(Session("Secured_OPAC"), CInt(Session("SecretLevel")), 0, 5, clsSession.GlbSite)
                If Not tblOPACItem Is Nothing AndAlso tblOPACItem.Rows.Count > 0 Then
                    Dim strTopBestView As String = ""
                    For i As Integer = 0 To tblOPACItem.Rows.Count - 1
                        If Not IsDBNull(tblOPACItem.Rows(i).Item("Content")) Then
                            'strTopBestView &= "<li style='width: 90%'>" & tblOPACItem.Rows(i).Item("Content") & "</li>"
                            strTopBestView &= "<li><h2><span class='icon-book clr-cyan'></span>"
                            strTopBestView &= tblOPACItem.Rows(i).Item("Content")
                            strTopBestView &= "</h2></li>"
                        End If
                    Next
                    ltrTopBestView.Text = strTopBestView
                Else
                    ltrTopBestView.Text = ""
                End If

            Catch ex As Exception
            End Try
        End Sub

        'Private Sub checkSiteLink()
        '    Try
        '        Dim tbLoai As DataTable

        '        objBType.NN = "vn"
        '        objBType.id_L = "1"
        '        tbLoai = objBType.CAT_Type_sl(clsSession.GlbSite)
        '        If Not IsNothing(tbLoai) AndAlso tbLoai.Rows.Count > 0 Then
        '            divSiteLink.Visible = True
        '        Else
        '            divSiteLink.Visible = False
        '        End If
        '    Catch ex As Exception

        '    End Try
        'End Sub

        Public Function changeURL(ByVal Chuoi As String) As String
            If Chuoi.Trim().Length > 0 Then
                If Chuoi.Trim().Length > 80 Then
                    Chuoi = clsCommon.Cat_Chuoi(80, Chuoi.Trim())
                End If
                Chuoi = clsCommon.RejectMarks(Chuoi.Trim())

                Return Chuoi.Replace(" ", "-")
            End If
            Return ""
        End Function

        'Public Shared Function cutWords(ByVal Chuoi As String, ByVal intLen As Integer) As String
        '    If Chuoi.Trim().Length > 0 Then
        '        If Chuoi.Trim().Length > intLen Then
        '            Chuoi = clsCommon.Cat_Chuoi(intLen, Chuoi.Trim())
        '        End If
        '        Return Chuoi
        '    End If
        '    Return ""
        'End Function

        '' BindScript method
        '' Purpose: Bind JAVASCRIPTS
        'Private Sub BindScript()
        '    'Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = 'js/OIndex.js'></script>")
        'End Sub



        ' Page_Unload event


        Protected Sub SiteMap1_NodeDataBound(ByVal sender As Object, ByVal e As RadSiteMapNodeEventArgs) Handles SiteMap1.NodeDataBound
            Try
                'e.Node.NavigateUrl = "javascript:parent.gotoShowRecord(12,'" & e.Node.DataItem("code").ToString & "')"
                'e.Node.Text = e.Node.DataItem("Caption").ToString & " (" & e.Node.DataItem("NumberNo").ToString & ")"
            Catch ex As Exception
            End Try
        End Sub

        Sub loadSiteMap()
            Try
                'SiteMap1.DataSource = QueryDataSiteMap()
                'SiteMap1.DataBind()
            Catch ex As Exception
            End Try
        End Sub

        Private Function QueryDataSiteMap() As DataTable
            Dim dt As New DataTable
            Try
                objBFilterBrowse.Words = ""
                dt = objBFilterBrowse.GetTBrowseTreeviewDDC(clsSession.GlbSite)
            Catch ex As Exception
            End Try
            Return dt
        End Function



        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBType Is Nothing Then
                    objBType.Dispose(True)
                    objBType = Nothing
                End If
                If Not objBNews Is Nothing Then
                    objBNews.Dispose(True)
                    objBNews = Nothing
                End If
                If Not objBOpacItem Is Nothing Then
                    objBOpacItem.Dispose(True)
                    objBOpacItem = Nothing
                End If
                If Not objBeMagazine Is Nothing Then
                    objBeMagazine.Dispose(True)
                    objBeMagazine = Nothing
                End If
                If Not objBPeriodical Is Nothing Then
                    objBPeriodical.Dispose(True)
                    objBPeriodical = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
