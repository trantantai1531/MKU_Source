Imports eMicLibOPAC.BusinessRules.OPAC

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class News
        Inherits System.Web.UI.Page
        Private objBNews As New clsBCAT_News
        Private objBType As New clsBCAT_Type
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblCheckCode As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call Initialize()
            If Not Page.IsPostBack Then
                Call PhanLoai()
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

        Public Sub PhanLoai()
            Try
                Dim tbType As DataTable
                objBType.NN = "vn"
                objBType.id_L = Request.QueryString.Get("id")
                tbType = objBType.CAT_Type_sl_all()

                DropDownList1.DataSource = tbType
                DropDownList1.DataTextField = "Loai"
                DropDownList1.DataValueField = "id"
                DropDownList1.DataBind()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End Sub


        Private Sub BindData()
            Dim tblNews As DataTable

            objBNews.NN = "vn"
            objBNews.id_L = DropDownList1.SelectedValue
            objBNews.id_C = Request.QueryString.Get("id")
            tblNews = objBNews.CAT_News_sl_admin_all

            If Not tblNews Is Nothing AndAlso tblNews.Rows.Count > 0 Then
                GridView1.DataSource = tblNews
                GridView1.DataBind()
            End If

        End Sub

        Public Sub Data()
            Try
                Dim tblNews As DataTable

                objBNews.NN = "vn"
                objBNews.id_L = DropDownList1.SelectedValue
                objBNews.id_C = Request.QueryString.Get("id")
                tblNews = objBNews.CAT_News_sl_admin


                GridView1.DataSource = tblNews
                GridView1.DataBind()
                If DropDownList1.SelectedIndex = 0 Then
                    GridView1.Columns(0).Visible = False
                Else
                    GridView1.Columns(0).Visible = True
                End If
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End Sub


        Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating
            Try
                For Each row As GridViewRow In GridView1.Rows
                    If row.RowIndex = e.RowIndex Then
                        Dim lbl_vi_tri__ As String = DirectCast(row.FindControl("txt_vi_tri_"), TextBox).Text
                        Dim id As String = DirectCast(row.FindControl("lbl_id"), Label).Text

                        objBNews.Vi_tri = lbl_vi_tri__.ToString()
                        objBNews.id = id
                        objBNews.CAT_News_up_vi_tri(0)

                        If objBNews.CAT_News_up_vi_tri(0) = 1 Then
                            Response.Redirect(Request.RawUrl)
                        End If

                    End If
                Next
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End Sub

        Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
            Try
                For Each row As GridViewRow In GridView1.Rows
                    If row.RowIndex = e.RowIndex Then

                        Dim id As String = DirectCast(row.FindControl("lbl_id"), Label).Text
                        objBNews.CAT_News_de_id(id)
                        BindData()

                        Dim Anh As Label = DirectCast(row.FindControl("lbl_Anh"), Label)
                        If Anh.Text.Trim().Length > 0 Then
                            System.IO.File.Delete(Server.MapPath("../Upload/TT/" & Anh.Text.Trim()))
                        End If
                    End If
                Next
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End Sub

        Public Function Anh(ByVal Hinh As String) As String
            If Hinh.Trim().Length = 0 Then
                Return ""
            Else
                Return "<img src='" + "../Upload/TT/" + Hinh + "' width='80' />"
            End If
        End Function

        Public Shared Function Status1(ByVal TinhTrang As Integer) As String
            If TinhTrang = 1 Then
                Return "<div class='smallButton tipS' original-title='Items đã hiện'><img src='images/tick.png' /></div>"
            Else
                Return "<div class='smallButton tipS' original-title='Items đã ẩn'><img src='images/hide.png' alt=''></div>"
            End If
        End Function


        Public Shared Function Hot(ByVal TinhTrang As Object) As String
            If Boolean.Parse(TinhTrang.ToString()) = True Then
                Return "<span style=""color: red""><strong>Hot</strong></span>"
            Else
                Return ""
            End If
        End Function

        Public Shared Function Cat_Chuoi(ByVal sl As Integer, ByVal Chuoi As String) As String
            If Chuoi.Trim().Length <= sl Then
                Return Chuoi
            Else
                For i As Integer = sl To Chuoi.Length - 1
                    If Chuoi(i).ToString() = " " Then
                        Return Chuoi.Substring(0, i) & "..."
                    End If
                Next
            End If
            Return Chuoi
        End Function


        Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
            Dim lbID As String = ""
            Try
                For Each row As GridViewRow In GridView1.Rows
                    Dim cb As HtmlInputCheckBox = DirectCast(row.FindControl("contract"), HtmlInputCheckBox)
                    If cb IsNot Nothing AndAlso cb.Checked Then
                        lbID = DirectCast(row.FindControl("lbl_id"), Label).Text
                        objBNews.id = lbID
                        objBNews.News_update_Status(0)
                    End If
                Next
                BindData()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End Sub

        Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
            Dim lbID As String = ""
            Try
                For Each row As GridViewRow In GridView1.Rows
                    Dim cb As HtmlInputCheckBox = DirectCast(row.FindControl("contract"), HtmlInputCheckBox)
                    If cb IsNot Nothing AndAlso cb.Checked Then
                        lbID = DirectCast(row.FindControl("lbl_id"), Label).Text
                        objBNews.id = lbID
                        objBNews.News_update_Hot(0)

                    End If
                Next
                BindData()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try

        End Sub

        Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
            Dim lbID As String = ""
            Try
                For Each row As GridViewRow In GridView1.Rows
                    Dim cb As HtmlInputCheckBox = DirectCast(row.FindControl("contract"), HtmlInputCheckBox)
                    If cb IsNot Nothing AndAlso cb.Checked Then
                        lbID = DirectCast(row.FindControl("lbl_id"), Label).Text
                        objBNews.CAT_News_de_id(lbID)
                        BindData()
                        Dim Anh As Label = DirectCast(row.FindControl("lbl_Anh"), Label)
                        If Anh.Text.Trim().Length > 0 Then
                            System.IO.File.Delete(Server.MapPath("../Upload/TT/" & Anh.Text.Trim()))
                        End If
                    End If
                Next
                BindData()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try

        End Sub

        Protected Sub cmdSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearch.Click
            Try
                Dim tblNews As DataTable

                objBNews.NN = "vn"
                objBNews.id_L = Request.QueryString.Get("id")
                objBNews.TK = txtTuKhoa.Text.ToString()

                tblNews = objBNews.CAT_News_sl_admin_search
                GridView1.DataSource = tblNews
                GridView1.DataBind()
                GridView1.Columns(0).Visible = False
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try

        End Sub

        Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DropDownList1.SelectedIndexChanged
            Call Data()
        End Sub
    End Class
End Namespace
