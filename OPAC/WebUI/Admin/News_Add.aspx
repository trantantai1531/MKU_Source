<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Admin.Master" CodeBehind="News_Add.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.News_Add" %>
<%@ Register Assembly="CKFinder" Namespace="CKFinder" TagPrefix="CKFinder" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <script type="text/javascript" src="/ckfinder/ckfinder.js"></script>
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
                           <label>Nhóm tin tức</label>
                            <asp:DropDownList ID="DrLoai" CssClass="form-control" Width="70%" runat="server">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group">
                           <label>Tiêu đề</label>
                           <asp:TextBox ID="txt_tieu_de" runat="server" CssClass="tipS form-control" Width="70%"  placeholder="(*) Đây là thông tin bắt buộc " ></asp:TextBox>
                           <asp:Label ID="lbl_luu_anh" runat="server" Visible="False"></asp:Label>
                           <asp:Label ID="lbl_kq" runat="server" Font-Size="10pt" ForeColor="#FF0033"></asp:Label>
                        </div>
                        <div class="form-group">
                           <label>Ảnh minh họa</label>
                           <asp:FileUpload ID="F_Anh" runat="server" Width="309px" />
                           <asp:Image ID="lbl_Anh" CssClass="labelImg" runat="server" Height="70px" Visible="False" />
                           <asp:CheckBox ID="CheckBox2" runat="server" Text="Xóa hình" Visible="False" />
                        </div>
                        <div class="form-group">
                           <label>Tùy chọn: </label>
                           <asp:CheckBox  ID="CheckBox1" runat="server" Text="Tin nổi bật"/>
                           <asp:CheckBox ID="Ch_iconNew" runat="server" Visible="false"/>
                        </div>
                        <div class="form-group">
                           <label>Tóm tắt: </label>
                           <asp:TextBox ID="txt_tom_tât" runat="server" placeholder="(*) Đây là thông tin bắt buộc "  CssClass="form-control" Height="100px" TextMode="MultiLine" Width="70%"></asp:TextBox>
                        </div>
                        <div class="form-group">
                           <asp:CheckBoxList ID="Ch_HoTroSEO" Visible="false" runat="server" AutoPostBack="True" 
                              OnSelectedIndexChanged="Ch_HoTroSEO_SelectedIndexChanged" style="line-height:24px;">
                              <asp:ListItem>Hỗ trợ SEO</asp:ListItem>
                           </asp:CheckBoxList>
                           <input type="checkbox" class="classseo" style="display:none;" /> <span style="font-weight:bold;display:none;">Hỗ trợ SEO</span>
                           <label>Hỗ trợ SEO: </label>
                        </div>
                        <div class="form-group">
                           <label>Title</label>
                           <asp:TextBox ID="txtTitle" CssClass="form-control" Height="70%"  runat="server" ></asp:TextBox>
                        </div>
                        <div class="form-group">
                           <label>Mô tả</label> 
                           <asp:TextBox ID="txtMeTaMoTa" TextMode="MultiLine" CssClass="form-control" Height="70%" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                           <label>Keyword</label> 
                           <asp:TextBox ID="txtKeyword" TextMode="MultiLine" CssClass="form-control"  Height="70%" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                           <label>Nội dung</label> 
                           <CKEditor:CKEditorControl ID="txt_noi_dung" Width="100%" runat="server">
                           </CKEditor:CKEditorControl>
                        </div>
                        
                        <asp:Panel ID="P_HoTroSEO" runat="server" class='divseo' >
                        </asp:Panel>
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
