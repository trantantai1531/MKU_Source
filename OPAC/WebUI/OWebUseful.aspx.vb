Imports System.IO
Imports System.IO.Path
Imports eMicLibOPAC.BusinessRules.OPAC
Imports System.Web.Services

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class OWebUseful
        Inherits clsWBaseJqueryUI
        Private objBType As New clsBCAT_Type
        Private objBWebsite As New clsBCAT_WebsiteUseful

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call BindScript()
            Call Initialize()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        Private Sub Initialize()

            objBType.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBType.DBServer = Session("DBServer")
            objBType.ConnectionString = Session("ConnectionString")
            objBType.Initialize()

            objBWebsite.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBWebsite.DBServer = Session("DBServer")
            objBWebsite.ConnectionString = Session("ConnectionString")
            objBWebsite.Initialize()
        End Sub

        Private Sub BindScript()
            'Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = 'js/OIndex.js'></script>")
        End Sub

        Private Sub BindData()
            Dim strResult As String = ""
            Try

                Dim tbLoai As DataTable
                Dim tbDetail As DataTable
                objBType.NN = "vn"
                objBType.id_L = "1"
                tbLoai = objBType.CAT_Type_sl(clsSession.GlbSite)

                Dim strLoai As String = ""
                Dim strAuthor As String = ""
                Dim strFormat As String = ""
                Dim strLexile As String = ""
                Dim strLanguage As String = ""
                Dim strGrade As String = ""
                Dim strAnh As String = ""
                Dim strGioiThieu As String = ""
                Dim strLink As String = ""
                If Not IsNothing(tbLoai) AndAlso tbLoai.Rows.Count > 0 Then
                    Dim strTempImageCover As String = ""
                    Dim strTempImageCoverTemp As String = ""
                    For i As Integer = 0 To tbLoai.Rows.Count - 1
                        strResult &= "<div id=""CollapsiblePanel" & (i + 1).ToString & """ class=""CollapsiblePanel"">"
                        strResult &= "<div class=""CollapsiblePanelTab"" tabindex=""0"">" & tbLoai.Rows(i).Item("loai") & "</div>"
                        strResult &= "<div class=""CollapsiblePanelContent"">"
                        strResult &= "<div class=""list-news"">"
                        strResult &= "<div class=""row-group"">"
                        With objBWebsite
                            .NN = "vn"
                            .id_L = tbLoai.Rows(i).Item("id")
                            tbDetail = .CAT_WebsiteUseful_sl
                        End With
                        If Not IsNothing(tbDetail) AndAlso tbDetail.Rows.Count > 0 Then
                            For j As Integer = 0 To tbDetail.Rows.Count - 1
                                strLoai = ""
                                strAuthor = ""
                                strFormat = ""
                                strLexile = ""
                                strLanguage = ""
                                strGrade = ""
                                strGioiThieu = ""
                                strLink = ""
                                strAnh = "Images/News/Nopic1.jpg"
                                If Not IsDBNull(tbDetail.Rows(j).Item("Link")) Then
                                    strLink = tbDetail.Rows(j).Item("Link")
                                End If
                                If Not IsDBNull(tbDetail.Rows(j).Item("loai")) Then
                                    strLoai = tbDetail.Rows(j).Item("loai")
                                End If
                                If Not IsDBNull(tbDetail.Rows(j).Item("Author")) Then
                                    strAuthor = tbDetail.Rows(j).Item("Author")
                                End If
                                If Not IsDBNull(tbDetail.Rows(j).Item("Format")) Then
                                    strFormat = tbDetail.Rows(j).Item("Format")
                                End If
                                If Not IsDBNull(tbDetail.Rows(j).Item("Lexile")) Then
                                    strLexile = tbDetail.Rows(j).Item("Lexile")
                                End If
                                If Not IsDBNull(tbDetail.Rows(j).Item("Language")) Then
                                    strLanguage = tbDetail.Rows(j).Item("Language")
                                End If
                                If Not IsDBNull(tbDetail.Rows(j).Item("Grade")) Then
                                    strGrade = tbDetail.Rows(j).Item("Grade")
                                End If
                                If Not IsDBNull(tbDetail.Rows(j).Item("GioiThieu")) Then
                                    strGioiThieu = tbDetail.Rows(j).Item("GioiThieu")
                                    If strGioiThieu.Length >= 500 Then
                                        strGioiThieu = strGioiThieu.Substring(0, 497) & "..."
                                    End If
                                End If
                                strTempImageCover = ""
                                If Not IsDBNull(tbDetail.Rows(j).Item("Anh")) AndAlso tbDetail.Rows(j).Item("Anh").ToString.Trim <> "" Then
                                    strTempImageCover = tbDetail.Rows(j).Item("Anh").ToString
                                    strTempImageCover = getRootSiteAdmin() & "\upload\web\" & strTempImageCover
                                End If
                                If File.Exists(strTempImageCover) Then
                                    strTempImageCoverTemp = Server.MapPath("~") & "/upload/web/" & tbDetail.Rows(j).Item("id")
                                    strTempImageCoverTemp = Replace(strTempImageCoverTemp, "/", "\")
                                    If Not Directory.Exists(strTempImageCoverTemp) Then
                                        Directory.CreateDirectory(strTempImageCoverTemp)
                                    End If
                                    strTempImageCoverTemp &= "\" & GetFileName(strTempImageCover)
                                    If Not File.Exists(strTempImageCoverTemp) Then
                                        File.Copy(strTempImageCover, strTempImageCoverTemp)
                                    End If
                                    strAnh = "upload/web/" & tbDetail.Rows(j).Item("id") & "/" & GetFileName(strTempImageCover)
                                End If
                                'If Not IsDBNull(tbDetail.Rows(j).Item("Anh")) AndAlso tbDetail.Rows(j).Item("Anh").ToString.Trim <> "" Then
                                '    If System.IO.File.Exists(MapPath("upload/TT/" & tbDetail.Rows(j).Item("Anh"))) Then
                                '        strAnh = "upload/TT/" & tbDetail.Rows(j).Item("Anh")
                                '    End If
                                'End If
                                strResult &= "<article class=""list-item unit3"">"
                                strResult &= "<div class=""item-lesson box-raised"">"
                                strResult &= "<h2 class=""clr-cyan""><span>" & strLoai & "</span></h2>"
                                strResult &= "<ul>"
                                strResult &= "<li><span>" & spAuthor.InnerText & "</span>" & strAuthor & "</li>"
                                strResult &= "<li><span>" & spFormat.InnerText & "</span>" & strFormat & "</li>"
                                strResult &= "<li><span>" & spAuthor.InnerText & "</span>" & strAuthor & "</li>"
                                strResult &= "<li><span>" & spLexile.InnerText & "</span>" & strLexile & "</li>"
                                strResult &= "<li><span>" & spLanguage.InnerText & "</span>" & strLanguage & "</li>"
                                strResult &= "<li><span>" & spGrade.InnerText & "</span>" & strGrade & "</li>"
                                strResult &= "<li><span>" & spPicture.InnerText & "</span>" & "<div class=""img-box""><img src='" & strAnh & "'  alt='" & strAnh & "'/></div></li>"
                                strResult &= "<li><span>" & spDescription.InnerText & "</span>" & strGioiThieu & "</li>"
                                strResult &= "</ul>" 'box-raised
                                strResult &= "<div class=""more-detail ClearFix"">"
                                strResult &= "<a href=""" & strLink & """ target=""_blank"">" & spView.InnerText & "<span class=""mif-share""></span></a>"
                                strResult &= "</div>" 'more-detail
                                strResult &= "</div>" 'box-raised
                                strResult &= "</article>" 'article
                            Next
                        Else
                            'strResult &= spNoContent.InnerText
                        End If
                        strResult &= "</div>" 'row-group
                        strResult &= "</div>" 'list-news
                        strResult &= "</div>" 'CollapsiblePanelContent
                        strResult &= "</div>" 'CollapsiblePanel
                    Next
                End If

                'rptLoai.DataSource = tbLoai
                'rptLoai.DataBind()

                'DropDownList1.DataSource = tbLoai
                'DropDownList1.DataTextField = "Loai"
                'DropDownList1.DataValueField = "id"
                'DropDownList1.DataBind()

                'DropDownList1.Items.Insert(0, New ListItem("Chọn nhóm website", ""))

                'PhanLoai(DrFormat, "2")
                'DrFormat.Items.Insert(0, New ListItem("Chọn nhóm định dạng", ""))

                'PhanLoai(DrLexile, "3")
                'DrLexile.Items.Insert(0, New ListItem("Chọn nhóm trang", ""))

                'PhanLoai(DrLanguage, "4")
                'DrLanguage.Items.Insert(0, New ListItem("Chọn nhóm ngôn ngữ", ""))

                'PhanLoai(DrGrade, "5")
                'DrGrade.Items.Insert(0, New ListItem("Chọn nhóm trình độ", ""))

            Catch ex As Exception
            End Try
            ltrWeblink.Text = strResult
        End Sub

        Public Sub PhanLoai(ByVal dr As DropDownList, ByVal id As String)
            Try
                objBType.id_L = id
                objBType.NN = "vn"

                dr.DataSource = objBType.CAT_Type_sl
                dr.DataTextField = "Loai"
                dr.DataValueField = "id"
                dr.DataBind()

            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End Sub

        Private Property rptNews As Repeater
        'Protected Sub rptLoai_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptLoai.ItemDataBound
        '    'Dim item As RepeaterItem = e.Item

        '    'If (item.ItemType = ListItemType.Item) OrElse (item.ItemType = ListItemType.AlternatingItem) Then
        '    '    Dim lblID As Label = Nothing
        '    '    lblID = DirectCast(item.FindControl("lblID"), Label)
        '    '    Dim tbLoai As DataTable

        '    '    objBWebsite.NN = "vn"
        '    '    objBWebsite.id_L = lblID.Text
        '    '    objBWebsite.id_Format = DrFormat.SelectedValue
        '    '    objBWebsite.id_Lexile = DrLexile.SelectedValue
        '    '    objBWebsite.id_Language = DrLanguage.SelectedValue
        '    '    objBWebsite.id_Grade = DrGrade.SelectedValue


        '    '    If DropDownList1.SelectedValue = Nothing Then
        '    '        tbLoai = objBWebsite.CAT_WebsiteUseful_sl()
        '    '    Else
        '    '        tbLoai = objBWebsite.CAT_WebsiteUseful_Search_InRepeater()
        '    '    End If

        '    '    rptNews = DirectCast(item.FindControl("rptWebsite"), Repeater)
        '    '    rptNews.DataSource = tbLoai
        '    '    rptNews.DataBind()
        '    'End If
        'End Sub

        'Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        '    Try
        '        'Dim tbLoai As DataTable
        '        'objBWebsite.id_L = DropDownList1.SelectedValue
        '        'objBWebsite.id_Format = DrFormat.SelectedValue
        '        'objBWebsite.id_Lexile = DrLexile.SelectedValue
        '        'objBWebsite.id_Language = DrLanguage.SelectedValue
        '        'objBWebsite.id_Grade = DrGrade.SelectedValue

        '        'tbLoai = objBWebsite.CAT_WebsiteUseful_Search(clsSession.GlbSite)

        '        'Label1.Text = ""
        '        'If Not IsNothing(tbLoai) AndAlso tbLoai.Rows.Count > 0 Then
        '        '    rptLoai.DataSource = tbLoai
        '        '    rptLoai.DataBind()
        '        'Else
        '        '    Label1.Text = "Không có dữ liệu"
        '        'End If
        '    Catch ex As Exception
        '    End Try
        'End Sub

        ' Page_Unload event
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
                If Not objBWebsite Is Nothing Then
                    objBWebsite.Dispose(True)
                    objBWebsite = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
