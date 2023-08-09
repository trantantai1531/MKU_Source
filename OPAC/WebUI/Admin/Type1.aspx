<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Admin.Master" CodeBehind="Type1.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.Type1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script src="http://code.jquery.com/jquery-1.11.0.min.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $('.checkAll').change(function () {
            var checkboxes = $(this).closest('form').find(':checkbox');
            if ($(this).is(':checked')) {
                checkboxes.attr('checked', 'checked');
            } else {
                checkboxes.removeAttr('checked');
            }
        });
    });
</script>
<div id="page-wrapper">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Tin tức</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <!-- /.row -->
    <div class="row">
    <div class="col-lg-12" style="float:right;">
         <div class="form-group">
            <label>Loại</label>
            <asp:TextBox ID="txt_Loai" runat="server" CssClass="tipS form-control" Width="70%"  placeholder="(*) Đây là thông tin bắt buộc " ></asp:TextBox>
            <asp:Label ID="lbl_tam" runat="server" Visible="False"></asp:Label>
        </div>

        <div class="form-group">
            <label>Tùy chọn: <img src="images/question-button.png" alt="Chọn loại" class="icon_que tipS" title="Check vào những tùy chọn "> </label>
            <asp:CheckBox  ID="Ch_NoiBat" runat="server" Text="Nổi bật"/>
        </div>

        <div class="form-group">
            <asp:Button ID="btnLuu" runat="server" CssClass="blueB btn btn-primary" Text="Hoàn tất" OnClick="btnLuu_Click" />
        </div>
        <div class="nNote nSuccess hideit" style="margin:20px 0px 0px; clear:both; display:block"  id="divThanhCong" runat="server">
            <p><strong>Cập nhật thành công!</strong></p>
         </div>

          <asp:Button ID="Button1" runat="server" CssClass="blueB btn btn-primary" Text="Ẩn / hiện" OnClick="Button1_Click" />
               <asp:Button ID="Button2" runat="server" CssClass="blueB btn btn-primary" Text="Xóa" OnClick="Button2_Click" />
               <asp:Button ID="Button3" runat="server" CssClass="blueB btn btn-primary" Text="Hot / No Hot" OnClick="Button3_Click" />
         </div>

         <div class="col-lg-12 table-responsive">
            <asp:GridView ID="GridView1"  runat="server" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" CssClass="table table-striped table-bordered table-hover tinnguyen" Width="100%" AutoGenerateColumns="False">
               <Columns>
                  <asp:TemplateField HeaderText="Vị tr&#237;" >
                     <ItemTemplate>
                        <asp:TextBox ID="txt_vi_tri_" runat="server" Text='<%# Eval("Vi_tri") %>' Width="25px"  CssClass="tipS smallText" original-title="Nhập stt"></asp:TextBox>
                     </ItemTemplate>
                     <FooterStyle HorizontalAlign="Center" />
                     <HeaderStyle HorizontalAlign="Center" />
                     <ItemStyle HorizontalAlign="Center" Width="30px" />
                  </asp:TemplateField>
                  <asp:TemplateField >
                     <HeaderTemplate>
                        <div class="sortCol header">Loại<span></span></div>
                     </HeaderTemplate>
                     <ItemTemplate>
                        <asp:TextBox ID="txt_loai" runat="server" Text='<%# Eval("Loai") %>' Width="95%" CssClass="tipS smallText1 form-control" original-title="Nhập loại"></asp:TextBox>
                     </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Hot">
                     <ItemTemplate>
                        <%# Hot(Eval("Hot").ToString())%>
                     </ItemTemplate>
                     <HeaderStyle HorizontalAlign="Center" />
                     <ItemStyle HorizontalAlign="Center" Width="35px" />
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Thao tác">
                     <ItemTemplate>
                        <div class="smallButton tipS" style="padding:2px;float:left;"  title="Lưu">
                           <asp:ImageButton ID="ImageButton1111" runat="server" AlternateText='<%# "Cập nhật" %>'
                              CommandName="Update" ImageUrl="~/Admin/Images/save.gif" />
                        </div>
                        <div class="smallButton tipS"  title="Xóa">
                           <asp:ImageButton ID="ImageButton2"  runat="server" AlternateText='<%# "Xóa" %>' CommandName="Delete"
                              ImageUrl="~/Admin/Images/close.png" />
                        </div>
                        <asp:Label ID="lbl_id" runat="server" Text='<%# Eval("id") %>' Visible="False"></asp:Label>
                        <asp:Label ID="lbl_id_L" runat="server" Text='<%# Eval("id_L") %>' Visible="False"></asp:Label>
                     </ItemTemplate>
                     <FooterStyle HorizontalAlign="Center" />
                     <HeaderStyle HorizontalAlign="Center" />
                     <ItemStyle HorizontalAlign="Center" Width="70px" />
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Trạng th&#225;i">
                     <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Status1(Eval("Status")) %>'></asp:Label>
                     </ItemTemplate>
                     <HeaderStyle HorizontalAlign="Center" />
                     <ItemStyle HorizontalAlign="Center" Width="40px" />
                  </asp:TemplateField>
                  <asp:TemplateField>
                     <HeaderTemplate>
                        <span class=""> <input id="checkAll"  class="titleIcon checkAll" runat="server" name="checkAll"  type="checkbox" /></span> 
                     </HeaderTemplate>
                     <ItemTemplate>
                        <input id="contract" runat="server"  name="contract"  type="checkbox" />
                     </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="30px" />
                  </asp:TemplateField>
               </Columns>
            </asp:GridView>
         </div>
    </div>
    </div>
</asp:Content>
