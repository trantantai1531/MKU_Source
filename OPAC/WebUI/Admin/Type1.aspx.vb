Imports eMicLibOPAC.BusinessRules.OPAC

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class Type1
        Inherits System.Web.UI.Page
        Private objBType As New clsBCAT_Type

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call Initialize()
            divThanhCong.Visible = False
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        Public Sub BindData()
            Try
                Dim tblType As DataTable
                objBType.id_L = Request.QueryString.Get("id")
                objBType.NN = "vn"
                tblType = objBType.CAT_Type_sl

                GridView1.DataSource = tblType
                GridView1.DataBind()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End Sub

        Private Sub Initialize()
            ' init OPACItem object
            objBType.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBType.DBServer = Session("DBServer")
            objBType.ConnectionString = Session("ConnectionString")
            objBType.Initialize()
        End Sub



        Protected Sub btnLuu_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLuu.Click
            Try
                If txt_Loai.Text.Trim() = "" Then
                    Thong_bao("Vui lòng nhập nội dung")
                    txt_Loai.Focus()
                    Return
                End If
                Dim Hot As String = "0"
                If Ch_NoiBat.Checked = True Then
                    Hot = "1"
                End If
                If lbl_tam.Text.Trim().Length > 0 Then
                    objBType.id = lbl_tam.Text
                    objBType.id_L = Request.QueryString.Get("id")
                    objBType.NN = "vn"
                    objBType.Loai = txt_Loai.Text.Trim()
                    objBType.Anh = ""
                    objBType.Hot = Hot
                    objBType.GioiThieu = ""

                    Dim Kq As Integer = objBType.CAT_Type_up(0)
                    If Kq = 1 Then
                        divThanhCong.Visible = True
                        lbl_tam.Visible = False
                        lbl_tam.Text = ""
                        txt_Loai.Text = ""
                    Else
                        Thong_bao("Cập nhật thất bại")
                    End If
                Else
                    objBType.id_L = Request.QueryString.Get("id")
                    objBType.NN = "vn"
                    objBType.Loai = txt_Loai.Text.Trim()
                    objBType.Anh = ""
                    objBType.Hot = Hot
                    objBType.GioiThieu = ""
                    objBType.Link = ""


                    Dim id As Integer = objBType.Create(0)
                    If id <> 0 Then
                        divThanhCong.Visible = True
                        txt_Loai.Text = ""
                    Else
                        Thong_bao("Thêm thất bại")
                    End If
                End If

                Call BindData()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try

        End Sub

        Public Sub Thong_bao(ByVal TB As String)
            Page.RegisterStartupScript("", "<script> alert('" & TB & "');  </script>")
        End Sub


        Public Shared Function Hot(ByVal TinhTrang As String) As String
            If Boolean.Parse(TinhTrang.ToString()) = True Then
                Return "<span style=""color: red""><strong>Hot</strong></span>"
            Else
                Return ""
            End If
        End Function

        Public Shared Function Status1(ByVal TinhTrang As Integer) As String
            If TinhTrang = 1 Then
                Return "<div class='smallButton tipS' original-title='Items đã hiện'><img src='images/tick.png' /></div>"
            Else
                Return "<div class='smallButton tipS' original-title='Items đã ẩn'><img src='images/hide.png' alt=''></div>"
            End If
        End Function

        Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
            Try
                For Each row As GridViewRow In GridView1.Rows
                    If row.RowIndex = e.RowIndex Then
                        Dim id As String = DirectCast(row.FindControl("lbl_id"), Label).Text
                        objBType.CAT_Type_de(id.Trim())
                        Call BindData()
                    End If
                Next
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

                        Dim lbl_id_L As String = DirectCast(row.FindControl("lbl_id_L"), Label).Text
                        Dim txt_loai As String = DirectCast(row.FindControl("txt_loai"), TextBox).Text

                        objBType.Vi_tri = lbl_vi_tri__.ToString()
                        objBType.id = id
                        objBType.id_L = lbl_id_L
                        objBType.Loai = txt_loai

                        objBType.CAT_Type_up_vi_tri(1)
                        Call BindData()
                    End If
                Next
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
                        objBType.id = lbID
                        objBType.CAT_Typeupdate_Hot(0)
                    End If
                Next
                Call BindData()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try

        End Sub

        Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
            Try
                For Each row As GridViewRow In GridView1.Rows
                    Dim cb As HtmlInputCheckBox = DirectCast(row.FindControl("contract"), HtmlInputCheckBox)
                    If cb IsNot Nothing AndAlso cb.Checked Then
                        Dim lbID As String = DirectCast(row.FindControl("lbl_id"), Label).Text
                        objBType.CAT_Type_de(lbID.ToString())
                        Call BindData()
                    End If
                Next
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try

        End Sub

        Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
            Try
                For Each row As GridViewRow In GridView1.Rows
                    Dim cb As HtmlInputCheckBox = DirectCast(row.FindControl("contract"), HtmlInputCheckBox)
                    If cb IsNot Nothing AndAlso cb.Checked Then
                        Dim lbID As String = DirectCast(row.FindControl("lbl_id"), Label).Text
                        objBType.id = lbID
                        objBType.CAT_Type_update_Status(0)
                        Call BindData()
                    End If
                Next
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try

        End Sub

    End Class
End Namespace
