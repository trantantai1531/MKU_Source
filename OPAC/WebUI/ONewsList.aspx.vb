Imports eMicLibOPAC.BusinessRules.OPAC
Imports System.Web.Services

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class ONewsList
        Inherits clsWBaseJqueryUI
        Private objBOpacItem As New clsBOPACItem
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

                If Not Request.QueryString.Get("id") Is Nothing Then
                    Dim tbType1 As DataTable
                    objBType.id = Request.QueryString.Get("id")
                    tbType1 = objBType.CAT_Type_sl_id()
                    rptType.DataSource = tbType1
                    rptType.DataBind()

                    'Page.Title = tbType1.Rows(0)("Loai").ToString()
                    Page.MetaDescription = tbType1.Rows(0)("Loai").ToString()
                    Page.MetaKeywords = tbType1.Rows(0)("Loai").ToString()

                    Dim tbNews As DataTable
                    objBNews.NN = "vn"
                    objBNews.id_L = Request.QueryString.Get("id")
                    tbNews = objBNews.CAT_News_SelectId_L

                    Dim pageds As New PagedDataSource()
                    pageds.DataSource = tbNews.DefaultView
                    pageds.AllowPaging = True
                    pageds.PageSize = 10

                    Dim curpage As Integer = 0

                    If Request.QueryString("page") IsNot Nothing Then
                        curpage = Convert.ToInt32(Request.QueryString("page"))
                    Else
                        curpage = 1
                    End If

                    pageds.CurrentPageIndex = curpage - 1

                    If curpage = 1 AndAlso pageds.DataSourceCount > pageds.PageSize Then
                        lblCurrpage.Text = "Trang: 1"
                    ElseIf pageds.DataSourceCount = 0 Then
                        lblCurrpage.Text = "Không tìm thấy dữ liệu."
                    ElseIf curpage > 1 AndAlso pageds.DataSourceCount > pageds.PageSize Then
                        lblCurrpage.Text = "Trang: <a href='ONewsList.aspx?cat=" + Request.QueryString.Get("cat") + "&id=" + Request.QueryString.Get("id") + "&page=1'>1</a>"
                    End If
                    For i As Integer = 2 To pageds.PageCount
                        If i = curpage Then
                            lblCurrpage.Text = lblCurrpage.Text & ", " & i.ToString()
                        Else
                            lblCurrpage.Text = lblCurrpage.Text & ", <a href='ONewsList.aspx?cat=" + Request.QueryString.Get("cat") + "&id=" + Request.QueryString.Get("id") + "&page=" & i.ToString() & "'>" & i.ToString() & "</a>"
                        End If
                    Next i

                    rptNews.DataSource = pageds
                    rptNews.DataBind()
                Else
                    Response.Redirect("OIndex.aspx")
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
    End Class
End Namespace
