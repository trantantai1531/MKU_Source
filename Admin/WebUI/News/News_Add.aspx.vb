Imports eMicLibAdmin.BusinessRules.News
Imports eMicLibAdmin.WebUI.Common

Namespace eMicLibAdmin.WebUI.News
    Partial Class News_News_Add
        Inherits System.Web.UI.Page
        Private objBNews As New clsBCAT_News
        Private objBType As New clsBCAT_Type
        Protected strErrorMsg As String
        Protected intErrorCode As Integer

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
            divThanhCong.Visible = False
            Dim q As New CKFinder.FileBrowser
            q.BasePath = "/ckfinder/"
            q.SetupCKEditor(txt_noi_dung)
            If Not Page.IsPostBack Then
                Call BindData()
                If Not Request.QueryString.Get("S") Is Nothing Then
                    News_sl_id()
                End If

            End If
        End Sub

        Public Sub BindData()
            Try
                Dim tblType As DataTable
                objBType.id_L = Request.QueryString.Get("id")
                objBType.NN = "vn"
                objBType.LibID = clsSession.GlbSite
                tblType = objBType.CAT_Type_sl

                DrLoai.DataSource = tblType
                DrLoai.DataTextField = "Loai"
                DrLoai.DataValueField = "id"
                DrLoai.DataBind()
            Catch ex As Exception
                ' Response.Write(ex.Message)
            End Try
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

        Protected Sub bt_nhap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLuu.Click
            If Kiem_tra() Then
                If Request.QueryString.Get("S") IsNot Nothing Then
                    Update_News()
                    Return
                Else
                    Create_News()
                    Return
                End If
            End If

        End Sub

        Protected Sub Ch_HoTroSEO_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Ch_HoTroSEO.SelectedIndexChanged

        End Sub

        Public Function Create_News() As Integer
            Try
                Dim Hot As String = "0"
                Dim Tenfile As String = ""
                Dim iconNews As String = "0"
                Dim ext As String = ""
                If Ch_iconNew.Checked = True Then
                    iconNews = "1"
                End If

                If CheckBox1.Checked = True Then
                    Hot = "1"
                End If

                Dim fn As String = F_Anh.PostedFile.FileName + String.Empty
                'Nếu không nhập ảnh 
                If fn.Trim = String.Empty Then
                    Tenfile = ""
                Else
                    ext = clsWCommon.GetExtFile(fn)
                    Tenfile = clsWCommon.Filename(txt_tieu_de.Text.ToString())
                End If

                objBNews.id_L = DrLoai.SelectedValue
                objBNews.Hot = Hot
                objBNews.Tieu_de = txt_tieu_de.Text
                objBNews.Anh = Tenfile
                objBNews.Tom_tat = txt_tom_tât.Text
                objBNews.Noi_dung = txt_noi_dung.Text
                objBNews.NN = "vn"
                objBNews.iconNew = iconNews
                objBNews.Title = txtTitle.Text
                objBNews.MetaMoTa = txtMeTaMoTa.Text
                objBNews.DuoiAnh = ext
                objBNews.Keyword = txtKeyword.Text
                objBNews.LibID = clsSession.GlbSite
                Dim intSelect As Integer = 1
                Create_News = objBNews.Create(intSelect)

                If Create_News > 0 Then
                    Clear()
                    divThanhCong.Visible = True
                    Dim dir As String = "../Upload/TT/"
                    F_Anh.PostedFile.SaveAs(Server.MapPath(dir) + Tenfile + Create_News.ToString() + ext)
                    clsWCommon.CreateThumbnail(dir, 100, 100)
                End If
            Catch ex As Exception
                'Return error if sub create not succeed
                strErrorMsg = objBNews.ErrorMsg
                intErrorCode = objBNews.id
            End Try
        End Function

        Public Sub News_sl_id()
            Try
                objBNews.id = Request.QueryString.Get("S")
                Dim ds As DataTable = objBNews.CAT_News_sl_id()
                txt_tieu_de.Text = ds.Rows(0)("Tieu_de").ToString()
                txt_tom_tât.Text = ds.Rows(0)("Tom_tat").ToString()
                txt_noi_dung.Text = ds.Rows(0)("Noi_dung").ToString()
                txtTitle.Text = ds.Rows(0)("Title").ToString()
                txtMeTaMoTa.Text = ds.Rows(0)("MeTaMoTa").ToString()
                txtKeyword.Text = ds.Rows(0)("Keyword").ToString()
                DrLoai.SelectedValue = ds.Rows(0)("id_L").ToString()

                If Boolean.Parse(ds.Rows(0)("iconNew").ToString()) = True Then
                    Ch_iconNew.Checked = True
                Else
                    Ch_iconNew.Checked = False
                End If
                If ds.Rows(0)("Anh").ToString().Trim().Length > 0 Then
                    lbl_Anh.ImageUrl = "../Upload/TT/" & ds.Rows(0)("Anh").ToString().Trim()
                    lbl_Anh.Visible = True
                    lbl_luu_anh.Text = ds.Rows(0)("Anh").ToString()
                    CheckBox2.Visible = False
                Else
                    lbl_Anh.Visible = False
                    CheckBox2.Visible = False
                End If
                Dim i As Integer = 0
                If Boolean.Parse(ds.Rows(0)("Hot").ToString().Trim()) = True Then
                    CheckBox1.Checked = True
                Else
                    CheckBox1.Checked = False
                End If
            Catch ex As Exception
                strErrorMsg = objBNews.ErrorMsg
                intErrorCode = objBNews.id
            End Try
        End Sub

        Public Function Update_News() As Integer
            Try
                Dim id As String = Request.QueryString.Get("S")
                Dim Hot As String = "0", Tenfile As String = "", fn As String = "", iconNew As String = "0", ext As String
                If Ch_iconNew.Checked = True Then
                    iconNew = "1"
                End If
                If CheckBox1.Checked = True Then
                    Hot = "1"
                Else
                    Hot = "0"
                End If
                If CheckBox2.Checked = True Then
                    Tenfile = ""
                    System.IO.File.Delete(Server.MapPath("../Upload/TT/") + lbl_luu_anh.Text.Trim())
                Else
                    fn = F_Anh.PostedFile.FileName + String.Empty
                    'Lấy tên File
                    'Nếu không nhập ảnh lấy ảnh cũ
                    If fn.Trim() = String.Empty Then
                        Tenfile = lbl_luu_anh.Text
                    Else
                        ext = clsWCommon.GetExtFile(fn)
                        'Lấy đuôi file
                        Tenfile = clsWCommon.Filename(txt_tieu_de.Text.Trim().ToString())
                        If lbl_luu_anh.Text.Trim() <> "" Then

                            If System.IO.File.Exists(Server.MapPath("../Upload/TT/") + lbl_luu_anh.Text.Trim()) = True Then
                                System.IO.File.Delete(Server.MapPath("../Upload/TT/") + lbl_luu_anh.Text.Trim())
                            End If
                        End If
                        Tenfile = Tenfile + Request.QueryString.Get("S") + ext
                    End If
                End If
                'Update Dữ liệu

                objBNews.id = Request.QueryString.Get("S")
                objBNews.id_L = DrLoai.SelectedValue
                objBNews.Hot = Hot
                objBNews.Tieu_de = txt_tieu_de.Text
                objBNews.Anh = Tenfile
                objBNews.Tom_tat = txt_tom_tât.Text
                objBNews.Noi_dung = txt_noi_dung.Text
                objBNews.NN = "vn"
                objBNews.iconNew = iconNew
                objBNews.Title = txtTitle.Text
                objBNews.MetaMoTa = txtMeTaMoTa.Text
                objBNews.DuoiAnh = ext
                objBNews.Keyword = txtKeyword.Text
                Dim intSelect As Integer
                Update_News = objBNews.Update(intSelect)

                If Update_News = 1 Then
                    'Clear()
                    divThanhCong.Visible = True
                    'Xử lý ảnh
                    If fn.Trim() <> String.Empty Then
                        Dim dir As String = "../Upload/TT/"
                        F_Anh.PostedFile.SaveAs(Server.MapPath(dir) + Tenfile)
                        clsWCommon.CreateThumbnail(dir, 100, 100)
                    End If
                End If
            Catch ex As Exception
                strErrorMsg = objBNews.ErrorMsg
                intErrorCode = objBNews.id
            End Try
        End Function

        Public Sub Clear()
            txt_noi_dung.Text = ""
            lbl_luu_anh.Text = ""
            txt_tieu_de.Text = ""
            txt_tom_tât.Text = ""
            txtMeTaMoTa.Text = ""
            txtTitle.Text = ""
            CheckBox2.Checked = False
            txtKeyword.Text = ""
        End Sub

        Public Function Kiem_tra() As Boolean
            If txt_tieu_de.Text = "" Then
                lbl_kq.Text = "Vui lòng nhập tiêu đề."
                Return False
            End If
            If txt_tom_tât.Text = "" Then
                lbl_kq.Text = "Vui lòng nhập tóm tắt."
                Return False
            End If
            If txt_noi_dung.Text = "" Then
                lbl_kq.Text = "Vui lòng nhập nội dung."
                Return False
            End If
            Return True
        End Function

    End Class
End Namespace

