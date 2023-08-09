Imports System.IO
Imports System.IO.Path
Imports eMicLibOPAC.BusinessRules.OPAC
Imports System.Web.Services

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class ONewsDetails
        Inherits clsWBaseJqueryUI
        Private objBNews As New clsBCAT_News
        Private objBType As New clsBCAT_Type

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call BindScript()
            Call Initialize()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        Private Sub Initialize()
            ' init OPACItem object
            objBNews.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBNews.DBServer = Session("DBServer")
            objBNews.ConnectionString = Session("ConnectionString")
            objBNews.Initialize()

            objBType.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBType.DBServer = Session("DBServer")
            objBType.ConnectionString = Session("ConnectionString")
            objBType.Initialize()
        End Sub

        Private Sub BindData()
            Try
                Dim tbNews As DataTable
                If Request.QueryString.Get("id") IsNot Nothing Then
                    objBNews.id = Request.QueryString.Get("id")
                    tbNews = objBNews.CAT_News_sl_id(clsSession.GlbSite)

                    Dim strNewsInfo As String = ""
                    Dim strNewsOther As String = ""
                    Dim strTom_tat As String = ""
                    Dim strNoi_dung As String = ""
                    Dim strMeTaMoTa As String = ""
                    If Not IsNothing(tbNews) AndAlso tbNews.Rows.Count > 0 Then
                        If Not IsDBNull(tbNews.Rows(0)("Title")) AndAlso tbNews.Rows(0)("Title").ToString().Trim() <> "" Then
                            Title = tbNews.Rows(0)("Title").ToString().Trim()
                        Else
                            Title = tbNews.Rows(0)("Tieu_de").ToString().Trim()
                        End If
                        strNewsInfo = "<h2 class=""news-title"">" & Title & "</h2>"
                        If Not IsDBNull(tbNews.Rows(0)("Tom_tat")) AndAlso tbNews.Rows(0)("Tom_tat").ToString().Trim() <> "" Then
                            strTom_tat = tbNews.Rows(0)("Tom_tat").ToString().Trim()
                        End If
                        strNewsInfo &= "<h3 class=""news-intro"">" & strTom_tat & "</h3>"
                        If Not IsDBNull(tbNews.Rows(0)("Noi_dung")) AndAlso tbNews.Rows(0)("Noi_dung").ToString().Trim() <> "" Then
                            strNoi_dung = tbNews.Rows(0)("Noi_dung").ToString().Trim()
                        End If
                        strNewsInfo &= "<div class=""news-info"">" & strNoi_dung & "</div>"

                        If Not IsDBNull(tbNews.Rows(0)("MeTaMoTa")) AndAlso tbNews.Rows(0)("MeTaMoTa").ToString().Trim() <> "" Then
                            strMeTaMoTa = tbNews.Rows(0)("MeTaMoTa").ToString().Trim()
                        End If
                        If Not strMeTaMoTa <> "" Then
                            Page.MetaDescription = strMeTaMoTa
                        Else
                            Page.MetaDescription = strTom_tat
                        End If
                        If Not IsDBNull(tbNews.Rows(0)("Keyword")) AndAlso tbNews.Rows(0)("Keyword").ToString().Trim() <> "" Then
                            Page.MetaKeywords = tbNews.Rows(0)("Keyword").ToString().Trim()
                        End If
                    End If

                    ltrNewsInfo.Text = strNewsInfo

                    'DataList1.DataSource = tbNews
                    'DataList1.DataBind()

                    Dim strAnh As String = ""
                    Dim intViewRandom As Integer = 0
                    Dim tbLienquan As DataTable
                    objBNews.id_L = "," & tbNews.Rows(0)("id_L") & ","
                    objBNews.NN = "vn"
                    objBNews.PageNum = 1
                    objBNews.PageSize = Application("ePageSize") / 2
                    tbLienquan = objBNews.CAT_News_SelectId_L(clsSession.GlbSite)
                    If Not IsNothing(tbLienquan) AndAlso tbLienquan.Rows.Count > 0 Then
                        Dim strTempImageCover As String = ""
                        Dim strTempImageCoverTemp As String = ""
                        For i As Integer = 0 To tbLienquan.Rows.Count - 1
                            strNewsOther &= "<article class=""list-item"">"
                            strNewsOther &= "<div class=""item-lesson box-raised"">"
                            strNewsOther &= "<a href=""ONewsDetails.aspx?cat=" & GetFilename(tbLienquan.Rows(i)("Tieu_de").ToString) & "&id=" & tbLienquan.Rows(i)("id").ToString & """>"
                            strNewsOther &= "<h2 class=""clr-cyan""><span>" & tbLienquan.Rows(i)("Tieu_de").ToString & "</span></h2>"
                            strAnh = "Images/News/News-image.png"
                            strTempImageCover = ""
                            If Not IsDBNull(tbLienquan.Rows(i).Item("Anh")) AndAlso tbLienquan.Rows(i).Item("Anh").ToString.Trim <> "" Then
                                strTempImageCover = tbLienquan.Rows(i).Item("Anh").ToString
                                strTempImageCover = getRootSiteAdmin() & "\upload\TT\" & strTempImageCover
                            End If
                            If File.Exists(strTempImageCover) Then
                                strTempImageCoverTemp = Server.MapPath("~") & "/upload/TT/" & tbLienquan.Rows(i).Item("id")
                                strTempImageCoverTemp = Replace(strTempImageCoverTemp, "/", "\")
                                If Not Directory.Exists(strTempImageCoverTemp) Then
                                    Directory.CreateDirectory(strTempImageCoverTemp)
                                End If
                                strTempImageCoverTemp &= "\" & GetFilename(strTempImageCover)
                                If Not File.Exists(strTempImageCoverTemp) Then
                                    File.Copy(strTempImageCover, strTempImageCoverTemp)
                                End If
                                strAnh = "upload/TT/" & tbLienquan.Rows(i).Item("id") & "/" & GetFilename(strTempImageCover)
                            End If
                            strNewsOther &= "<div class=""img-box""><img src='" & strAnh & "'  alt='" & strAnh & "'/></div>"
                            strTom_tat = ""
                            If Not IsDBNull(tbLienquan.Rows(i).Item("Tom_tat")) AndAlso tbLienquan.Rows(i).Item("Tom_tat").ToString.Trim <> "" Then
                                strTom_tat = tbLienquan.Rows(i).Item("Tom_tat").ToString
                            End If
                            strNewsOther &= "<p  style='text-align:justify;'>" & clsCommon.Cat_Chuoi(200, strTom_tat) & "</p>"

                            intViewRandom = Int(10000 * Rnd(1) + 1)
                            strNewsOther &= "<div class=""more-detail ClearFix""><span class=""icon-eye-2""></span>" & intViewRandom & "</div>"
                            strNewsOther &= "</a>"
                            strNewsOther &= "</div>"
                            strNewsOther &= "</article>"
                        Next
                    End If
                    ltrNewsOther.Text = strNewsOther
                    'DataList2.DataSource = tbLienquan
                    'DataList2.DataBind()


                End If

            Catch ex As Exception
            End Try
        End Sub

        Private Sub BindScript()
            'Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = 'js/OIndex.js'></script>")
        End Sub

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
