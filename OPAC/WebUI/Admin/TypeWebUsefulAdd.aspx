<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Admin.Master" CodeBehind="TypeWebUsefulAdd.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.TypeWebUsefulAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div id="page-wrapper">
   <div class="row">
      <div class="col-lg-12">
         <h1 class="page-header">Tin tức</h1>
      </div>
      <!-- /.col-lg-12 -->
   </div>
   <!-- /.row -->
   <div class="row">
      <div class="col-lg-12">
         <div class="panel panel-primary">
            <div class="panel-heading">  Nhập dữ liệu </div>

            <div class="panel-body">
               <div class="row">
                  <div class="col-lg-12">
                    <div class="alert alert-success"  id="divThanhCong" runat="server"> Cập nhật thành công! </div>
                     <form role="form">
                     <div class="form-group">
                        <label>Nhóm website</label>
                        <asp:DropDownList ID="DropDownList1"  Width="50%" runat="server" CssClass="selectortinnguyen form-control" >
                        </asp:DropDownList>
                    </div>

                     <div class="form-group">
                        <label>Nhóm định dạng</label>
                        <asp:DropDownList ID="DrFormat"  Width="50%" runat="server" CssClass="selectortinnguyen form-control" >
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label>Nhóm số trang</label>
                        <asp:DropDownList ID="DrLexile"  Width="50%" runat="server" CssClass="selectortinnguyen form-control" >
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label>Nhóm ngôn ngữ</label>
                        <asp:DropDownList ID="DrLanguage"  Width="50%" runat="server" CssClass="selectortinnguyen form-control" >
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label>Nhóm trình độ</label>
                        <asp:DropDownList ID="DrGrade"  Width="50%" runat="server" CssClass="selectortinnguyen form-control" >
                        </asp:DropDownList>
                    </div>
                   

                     <div class="form-group">
                        <label>Tiêu đề</label>
                        <asp:TextBox ID="txt_Loai" runat="server" CssClass="tipS form-control" Width="70%"  placeholder="(*) Đây là thông tin bắt buộc " ></asp:TextBox>
                        <asp:Label ID="lbl_tam" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="lbl_luu_anh" runat="server" Visible="False"></asp:Label>
                        
                    </div>

                    <div class="form-group">
                        <label>Ảnh minh họa </label>
                        <asp:FileUpload ID="F_Anh" runat="server" Width="309px" /> 
                        <p style="color:Red;font-weight:bold;">Hình ảnh hiển thị đẹp với phân giải: 60px x 60px</p>
                        <asp:Image ID="lbl_Anh" CssClass="labelImg" runat="server" Height="70px" Visible="False" />
                        <asp:CheckBox ID="CheckBox2" runat="server" Text="Xóa hình" Visible="False" />
                    </div>

                    <div class="form-group">
                        <label>Link URL</label>
                        <asp:TextBox ID="txtLink" runat="server" CssClass="tipS form-control" Width="70%"  placeholder="Nhập thông tin Link URL" ></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label>Tác quyền</label>
                        <asp:TextBox ID="txtAuthor" runat="server" CssClass="tipS form-control" Width="70%"  placeholder="Nhập thông tin tác quyền " ></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label>Mô tả</label>
                        <asp:TextBox ID="txtGioithieu" runat="server" CssClass="tipS form-control" TextMode="MultiLine" Width="70%"  placeholder="Nhập thông tin mô tả " ></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label>Tùy chọn: <img src="images/question-button.png" alt="Chọn loại" class="icon_que tipS" title="Check vào những tùy chọn "> </label>
                        <asp:CheckBox  ID="Ch_NoiBat" runat="server" Text="Nổi bật"/>
                    </div>
                     </form>
                  </div>
               </div>
            </div>

            <div class="panel-footer">
                <asp:Button ID="btnLuu" runat="server" CssClass="blueB btn btn-primary" Text="Hoàn tất" OnClick="bt_nhap_Click"/>
            </div>
         </div>
      </div>
   </div>
</div>

</asp:Content>
