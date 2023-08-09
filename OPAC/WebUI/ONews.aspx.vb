Imports System.IO
Imports System.IO.Path
Imports eMicLibOPAC.BusinessRules.OPAC
Imports System.Web.Services

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class ONews
        Inherits clsWBaseJqueryUI
        Private objBNews As New clsBCAT_News
        Private objBType As New clsBCAT_Type
        Private Property rptNews As Repeater

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call BindScript()
            Call Initialize()
            If Not Page.IsPostBack Then
                Call BindSubjectMenu()
                Call BindData()
            End If
        End Sub

        Private Sub Initialize()
            objBNews.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBNews.DBServer = Session("DBServer")
            objBNews.ConnectionString = Session("ConnectionString")
            objBNews.Initialize()

            objBType.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBType.DBServer = Session("DBServer")
            objBType.ConnectionString = Session("ConnectionString")
            objBType.Initialize()
        End Sub
        Private Sub BindSubjectMenu()
            Dim strSubjectType As String = ""
            Try
                Dim tbSubjectType As DataTable
                objBType.id_L = "0"
                objBType.NN = "vn"
                tbSubjectType = objBType.CAT_Type_sl(clsSession.GlbSite)
                If Not IsNothing(tbSubjectType) AndAlso tbSubjectType.Rows.Count > 0 Then
                    For j As Integer = 0 To tbSubjectType.Rows.Count - 1
                        strSubjectType &= "<li class='liMenu'><a class='aMenu' href='ONews.aspx?ID=" & tbSubjectType.Rows(j)("id").ToString & "'>" & tbSubjectType.Rows(j)("Loai").ToString & "</a></li>"
                    Next
                End If
            Catch ex As Exception

            End Try
            LiteralListSubject.Text = strSubjectType
        End Sub
        Private Sub BindData(Optional ByVal strIds As String = "")
            Dim strNews As String = ""

            'Dim strIds As String = hidIds.Value
            Try
                If strIds = "" Then
                    Dim tbType As DataTable
                    If Request.QueryString.Get("id") IsNot Nothing Then
                        objBType.id = Request.QueryString.Get("id")
                        tbType = objBType.CAT_Type_sl_id(clsSession.GlbSite)
                        'Page.Title = tbType.Rows(0)("Loai").ToString()
                    Else
                        objBType.id_L = "0"
                        objBType.NN = "vn"
                        tbType = objBType.CAT_Type_sl(clsSession.GlbSite)
                        'Page.Title = "Tin tức"
                    End If
                    If Not IsNothing(tbType) AndAlso tbType.Rows.Count > 0 Then
                        strIds = ","
                        For j As Integer = 0 To tbType.Rows.Count - 1
                            strIds &= tbType.Rows(j)("id").ToString & ","
                        Next
                    End If
                End If
                Dim tbNews As DataTable
                With objBNews
                    .NN = "vn"
                    .id_L = strIds
                    '.PageSize = Application("ePageSize")
                    .PageSize = 12
                    .PageNum = hidCurrentPage.Value
                    tbNews = .CAT_News_SelectId_L(clsSession.GlbSite)
                End With
                If Not IsNothing(tbNews) AndAlso tbNews.Rows.Count > 0 Then
                    strNews = processBooks(tbNews, strIds)
                End If
            Catch ex As Exception
            End Try
            ltrNews.Text = strNews
        End Sub

        ' Creator: phuongtt
        Private Function processBooks(ByVal tbNews As DataTable, ByVal strIDs As String) As String
            Dim strNews As String = ""
            Try
                Dim intCurPage As Integer
                Dim intCount As Integer
                Dim intSumPage As Integer
                Dim intStart, intStop As Integer
                Dim colSearch As New Collection
                Dim intSumResult As Integer = 0
                Dim strSelectTop As String = ""

                Dim intTotal As Integer = tbNews.Rows(0).Item("total")
                'Dim intPagezise As Integer = Application("ePageSize")
                Dim intPagezise As Integer = 12
                Dim intPageLength As Integer = Application("ePageLength")
                Dim intPageSpace As Integer = Application("ePageSpace")

                ' intSumPage = UBound(arrIDs) \ intRecPerPage + 1
                intSumPage = (intTotal - 1) \ intPagezise + 1

                '' Read current page number
                'If IsNumeric(Request.QueryString("pg") & "") Then
                '    intCurPage = CInt(Request.QueryString("pg") & "")
                'Else
                '    intCurPage = 1
                'End If
                intCurPage = hidCurrentPage.Value

                intStart = (intCurPage - 1) * intPagezise
                intStop = (((intCurPage - 1) * intPagezise) + intPagezise) - 1
                If intStart > intTotal - 1 Then
                    intStart = intTotal - 1
                End If
                If intStop > intTotal - 1 Then
                    intStop = intTotal - 1
                End If

                Call showPagingControl(intTotal, intPagezise, intCurPage, intPageSpace, intPageLength, intStop, strIDs)

                Dim strAnh As String = ""
                Dim strTom_tat As String = ""
                Dim intView As String = ""
                If Not IsNothing(tbNews) AndAlso tbNews.Rows.Count > 0 Then
                    Dim strTempImageCover As String = ""
                    Dim strTempImageCover1 As String = ""
                    Dim strTempImageCoverTemp As String = ""
                    For i As Integer = 0 To tbNews.Rows.Count - 1
                        strNews &= "<article class=""list-item unit4"">"
                        strNews &= "<div class=""item-lesson box-raised"">"
                        strNews &= "<a href=""ONewsDetails.aspx?cat=" & GetFilename(tbNews.Rows(i)("Tieu_de").ToString) & "&id=" & tbNews.Rows(i)("id").ToString & """>"
                        strNews &= "<h2 class=""clr-cyan""><span>" & tbNews.Rows(i)("Tieu_de").ToString & "</span></h2>"
                        strAnh = "Images/News/News-image.png"
                        strTempImageCover = ""
                        If Not IsDBNull(tbNews.Rows(i).Item("Anh")) AndAlso tbNews.Rows(i).Item("Anh").ToString.Trim <> "" Then
                            strTempImageCover = tbNews.Rows(i).Item("Anh").ToString
                            strTempImageCover1 = tbNews.Rows(i).Item("Anh").ToString
                            strTempImageCover = getRootSiteAdmin() & "\upload\TT\" & strTempImageCover
                        End If
                        If File.Exists(strTempImageCover) Then
                            strTempImageCoverTemp = Server.MapPath("~") & "/upload/TT/" & tbNews.Rows(i).Item("id")
                            strTempImageCoverTemp = Replace(strTempImageCoverTemp, "/", "\")
                            If Not Directory.Exists(strTempImageCoverTemp) Then
                                Directory.CreateDirectory(strTempImageCoverTemp)
                            End If
                            strTempImageCoverTemp &= "\" & strTempImageCover1
                            If Not File.Exists(strTempImageCoverTemp) Then
                                File.Copy(strTempImageCover, strTempImageCoverTemp)
                            End If
                            strAnh = "upload/TT/" & tbNews.Rows(i).Item("id") & "/" & strTempImageCover1
                        End If
                        strNews &= "<div class=""img-box""><img src='" & strAnh & "'  alt='" & strAnh & "'/></div>"
                        strTom_tat = ""
                        If Not IsDBNull(tbNews.Rows(i).Item("Tom_tat")) AndAlso tbNews.Rows(i).Item("Tom_tat").ToString.Trim <> "" Then
                            strTom_tat = tbNews.Rows(i).Item("Tom_tat").ToString
                        End If
                        strNews &= "<p style='text-align:justify;'>" & clsCommon.Cat_Chuoi(200, strTom_tat) & "</p>"
                        'intViewRandom = Int(10000 * Rnd(1) + 1)
                        intView = tbNews.Rows(i).Item("ViewCount").ToString.Trim
                        strNews &= "<div class=""more-detail ClearFix""><span class=""icon-eye-2""></span>" & intView & "</div>"
                        strNews &= "</a>"
                        strNews &= "</div>"
                        strNews &= "</article>"
                    Next
                End If

            Catch ex As Exception
                Dim n = ex.Message
            End Try
            Return strNews
        End Function

        ' raiseShowRecord_Click method
        ' Purpose: show record by click of page
        Private Sub raiseShowRecord_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles raiseShowRecord.Click
            Try
                Dim strIds As String = hidIds.Value
                Call BindData(strIds)
            Catch ex As Exception
            End Try
        End Sub

        ' purpose :  show paging as google paging
        ' Creator: phuongtt
        Private Sub showPagingControl(ByVal intCount As Integer, ByVal intPagezise As Integer, ByVal intPage As Integer, ByVal intPageSpace As Integer, ByVal intPageLength As Integer, ByVal intStop As Integer, ByVal strIDs As String)
            Try
                Dim iPage As Integer = CInt((intCount / intPagezise) + 0.4999)
                Dim strPagination As String = ""
                Dim PreviousPage As Integer = intPage - 1
                Dim NextPage As Integer = intPage + 1
                If PreviousPage >= 1 Then
                    strPagination &= "<li><a onclick=""showRecord(" & PreviousPage.ToString & ",'" & strIDs & "')"" data-hint='|" & spPreviousPage.InnerText & "' data-hint-position='top' style='cursor:pointer;'><</a></li>"
                End If
                Dim xy As Integer = CInt((intPage / intPageSpace) + 0.4999)
                Dim alpha As Integer = (xy - 1) * intPageSpace
                Dim iPageCount As Integer = IIf(intPageLength + alpha <= iPage, intPageLength + alpha, iPage)

                For j As Integer = 1 + alpha To iPageCount
                    strPagination &= "<li>"
                    If j = intPage Then
                        strPagination &= "<a onclick=""showRecord(" & j.ToString & ",'" & strIDs & "')"" class='PageSeleted'  style='cursor:pointer;'>" & j.ToString & "</a>"
                    Else
                        strPagination &= "<a onclick=""showRecord(" & j.ToString & ",'" & strIDs & "')""  style='cursor:pointer;'>" & j.ToString & "</a>"
                    End If
                    strPagination &= "</li>"
                Next
                If NextPage <= iPage Then
                    strPagination &= "<li><a onclick=""showRecord(" & NextPage.ToString & ",'" & strIDs & "')"" data-hint='|" & spNextPage.InnerText & "' data-hint-position='top'  style='cursor:pointer;'>></a></li>"
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

        Private Sub BindScript()
            'Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = 'js/OIndex.js'></script>")
        End Sub

        'Protected Sub rptType_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptType.ItemDataBound
        '    Dim item As RepeaterItem = e.Item
        '    If (item.ItemType = ListItemType.Item) OrElse (item.ItemType = ListItemType.AlternatingItem) Then
        '        Dim lblID As Label = Nothing
        '        lblID = DirectCast(item.FindControl("lblID"), Label)
        '        Dim tbNews As DataTable
        '        objBNews.NN = "vn"
        '        objBNews.id_L = lblID.Text.ToString()
        '        tbNews = objBNews.CAT_News_SelectId_L(clsSession.GlbSite)

        '        rptNews = DirectCast(item.FindControl("rptNews"), Repeater)
        '        rptNews.DataSource = tbNews
        '        rptNews.DataBind()
        '    End If
        'End Sub

        Public Shared Function GetFilename(ByVal Chuoi As String) As String
            If Chuoi.Trim().Length > 0 Then
                If Chuoi.Trim().Length > 80 Then
                    Chuoi = clsCommon.Cat_Chuoi(80, Chuoi.Trim())
                End If
                Chuoi = clsCommon.RejectMarks(Chuoi.Trim())

                Return Chuoi.Replace(" ", "-")
            End If
            Return ""
        End Function

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub
        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBNews Is Nothing Then
                    objBNews.Dispose(True)
                    objBNews = Nothing
                End If
                If Not objBType Is Nothing Then
                    objBType.Dispose(True)
                    objBType = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace