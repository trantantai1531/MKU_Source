Imports eMicLibOPAC.BusinessRules.OPAC

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class TypeWebUsefulAdd
        Inherits System.Web.UI.Page
        Private objBType As New clsBCAT_Type
        Private objBwebsite As New clsBCAT_WebsiteUseful

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call Initialize()
            divThanhCong.Visible = False
            If Not Page.IsPostBack Then
                Call BindData()
                If Request.QueryString.Get("S") IsNot Nothing Then
                    News_sl_id()
                End If

            End If
        End Sub

        Private Sub Initialize()
            ' init OPACItem object
            objBwebsite.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBwebsite.DBServer = Session("DBServer")
            objBwebsite.ConnectionString = Session("ConnectionString")
            objBwebsite.Initialize()

            objBType.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBType.DBServer = Session("DBServer")
            objBType.ConnectionString = Session("ConnectionString")
            objBType.Initialize()
        End Sub

        Public Sub BindData()
            Try
                Dim tblType As DataTable
                objBType.id_L = Request.QueryString.Get("id")
                objBType.NN = "vn"
                tblType = objBType.CAT_Type_sl

                DropDownList1.DataSource = tblType
                DropDownList1.DataTextField = "Loai"
                DropDownList1.DataValueField = "id"
                DropDownList1.DataBind()

                PhanLoai(DrFormat, "2")
                PhanLoai(DrLexile, "3")
                PhanLoai(DrLanguage, "4")
                PhanLoai(DrGrade, "5")


            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
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


        Public Sub News_sl_id()
            Try
                objBwebsite.id = Request.QueryString.Get("S")
                Dim ds As DataTable = objBwebsite.CAT_WebsiteUseful_sl_id()
                txt_Loai.Text = ds.Rows(0)("Loai").ToString()
                txtAuthor.Text = ds.Rows(0)("Author").ToString()
                txtGioithieu.Text = ds.Rows(0)("GioiThieu").ToString()
                txtLink.Text = ds.Rows(0)("Link").ToString()
                DropDownList1.SelectedValue = ds.Rows(0)("id_L").ToString()
                lbl_tam.Text = ds.Rows(0)("id").ToString()

                DrFormat.SelectedValue = ds.Rows(0)("id_Format").ToString()
                DrLexile.SelectedValue = ds.Rows(0)("id_Lexile").ToString()
                DrLanguage.SelectedValue = ds.Rows(0)("id_Language").ToString()
                DrGrade.SelectedValue = ds.Rows(0)("id_Grade").ToString()

                If Boolean.Parse(ds.Rows(0)("Hot").ToString()) = True Then
                    Ch_NoiBat.Checked = True
                Else
                    Ch_NoiBat.Checked = False
                End If
                If ds.Rows(0)("Anh").ToString().Trim().Length > 0 Then
                    lbl_Anh.ImageUrl = "../Upload/Web/" & ds.Rows(0)("Anh").ToString().Trim()
                    lbl_Anh.Visible = True
                    lbl_luu_anh.Text = ds.Rows(0)("Anh").ToString()
                    CheckBox2.Visible = False
                Else
                    lbl_Anh.Visible = False
                    CheckBox2.Visible = False
                End If
                Dim i As Integer = 0
               
            Catch ex As Exception
            End Try
        End Sub

        Protected Sub bt_nhap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLuu.Click
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
                    Dim Tenfile As String = "", fn As String = "", ext As String
                    If CheckBox2.Checked = True Then
                        Tenfile = ""
                        System.IO.File.Delete(Server.MapPath("../Upload/Web/") + lbl_luu_anh.Text.Trim())
                    Else
                        fn = F_Anh.PostedFile.FileName + String.Empty
                        'Lấy tên File
                        'Nếu không nhập ảnh lấy ảnh cũ
                        If fn.Trim() = String.Empty Then
                            Tenfile = lbl_luu_anh.Text
                        Else
                            ext = clsCommon.GetExtFile(fn)
                            'Lấy đuôi file
                            Tenfile = clsCommon.Filename(txt_Loai.Text.Trim().ToString())
                            If lbl_luu_anh.Text.Trim() <> "" Then

                                If System.IO.File.Exists(Server.MapPath("../Upload/Web/") + lbl_luu_anh.Text.Trim()) = True Then
                                    System.IO.File.Delete(Server.MapPath("../Upload/Web/") + lbl_luu_anh.Text.Trim())
                                End If
                            End If
                            Tenfile = Tenfile + Request.QueryString.Get("S") + ext
                        End If
                    End If

                    objBwebsite.id = lbl_tam.Text
                    objBwebsite.id_L = DropDownList1.SelectedValue
                    objBwebsite.NN = "vn"
                    objBwebsite.Loai = txt_Loai.Text.Trim()
                    objBwebsite.Anh = Tenfile
                    objBwebsite.Hot = Hot
                    objBwebsite.GioiThieu = txtGioithieu.Text
                    objBwebsite.Link = txtLink.Text
                    objBwebsite.Author = txtAuthor.Text

                    objBwebsite.id_Format = DrFormat.SelectedValue
                    objBwebsite.id_Lexile = DrLexile.SelectedValue
                    objBwebsite.id_Language = DrLanguage.SelectedValue
                    objBwebsite.id_Grade = DrGrade.SelectedValue

                    Dim Kq As Integer = objBwebsite.CAT_WebsiteUseful_up(0)
                    If Kq = 1 Then
                        divThanhCong.Visible = True
                        lbl_tam.Visible = False
                        lbl_tam.Text = ""
                        txt_Loai.Text = ""
                        txtAuthor.Text = ""
                        txtGioithieu.Text = ""
                        txtLink.Text = ""

                        If fn.Trim() <> String.Empty Then
                            Dim dir As String = "../Upload/Web/"
                            F_Anh.PostedFile.SaveAs(Server.MapPath(dir) + Tenfile)
                            clsCommon.CreateThumbnail(dir, 100, 100)
                        End If
                    Else
                        Thong_bao("Cập nhật thất bại")
                    End If
                Else
                    'Insert
                    Dim Tenfile As String = ""
                    Dim ext As String = ""

                    Dim fn As String = F_Anh.PostedFile.FileName + String.Empty
                    'Nếu không nhập ảnh 
                    If fn.Trim = String.Empty Then
                        Tenfile = ""
                    Else
                        ext = clsCommon.GetExtFile(fn)
                        Tenfile = clsCommon.Filename(txt_Loai.Text.ToString())
                    End If

                    objBwebsite.id_L = DropDownList1.SelectedValue
                    objBwebsite.NN = "vn"
                    objBwebsite.Loai = txt_Loai.Text.Trim()
                    objBwebsite.Anh = Tenfile
                    objBwebsite.Hot = Hot
                    objBwebsite.GioiThieu = txtGioithieu.Text
                    objBwebsite.Link = txtLink.Text
                    objBwebsite.Author = txtAuthor.Text
                    objBwebsite.DuoiAnh = ext

                    objBwebsite.id_Format = DrFormat.SelectedValue
                    objBwebsite.id_Lexile = DrLexile.SelectedValue
                    objBwebsite.id_Language = DrLanguage.SelectedValue
                    objBwebsite.id_Grade = DrGrade.SelectedValue


                    Dim id As Integer = objBwebsite.Create(0)
                    If id <> 0 Then
                        divThanhCong.Visible = True
                        txt_Loai.Text = ""
                        txtAuthor.Text = ""
                        txtGioithieu.Text = ""
                        txtLink.Text = ""

                        Dim dir As String = "../Upload/Web/"
                        F_Anh.PostedFile.SaveAs(Server.MapPath(dir) + Tenfile + id.ToString() + ext)
                        clsCommon.CreateThumbnail(dir, 60, 60)
                    Else
                        Thong_bao("Thêm thất bại")
                    End If
                End If

            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End Sub

        Public Sub Thong_bao(ByVal TB As String)
            Page.RegisterStartupScript("", "<script> alert('" & TB & "');  </script>")
        End Sub

    End Class
End Namespace
