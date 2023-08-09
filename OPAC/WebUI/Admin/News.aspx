<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Admin.Master" CodeBehind="News.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.News" %>
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

<!-- Codes by Quackit.com -->
<script type="text/javascript">
// Popup window code
function newPopup(url) {
    popupWindow = window.open(
        url, 'popUpWindow', 'height=650,width=1024,left=10,top=10,resizable=yes,scrollbars=yes,toolbar=yes,menubar=no,location=no,directories=no,status=yes')
}
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
        <label>Nhóm tin tức</label>
        <asp:DropDownList ID="DropDownList1" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="50%" runat="server" CssClass="selectortinnguyen form-control" >
        </asp:DropDownList>
    </div>

    <div class="form-group">
        <label>Nhập từ khóa</label>
        <asp:TextBox ID="txtTuKhoa" runat="server" CssClass="tipS form-control"  original-title="Nhập từ khóa tìm kiếm vào đây" Width="50%"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Button ID="cmdSearch" runat="server" CssClass="blueB btn btn-primary" Text="Tìm kiếm" OnClick="cmdSearch_Click" />
    </div>
        <asp:Button ID="Button1" runat="server" CssClass="blueB btn btn-primary" Text="Ẩn / hiện" OnClick="Button1_Click" />
        <asp:Button ID="Button3" runat="server" CssClass="blueB btn btn-primary" Text="Hot / No Hot" OnClick="Button3_Click" />
        <asp:Button ID="Button2" runat="server" CssClass="blueB btn btn-primary" Text="Xóa" OnClick="Button2_Click" />
    </div>
        <div class="col-lg-12 table-responsive">
            <asp:GridView ID="GridView1"  runat="server" CssClass="table table-striped table-bordered table-hover tinnguyen" Width="100%" AutoGenerateColumns="False" AllowPaging="True" >
               <Columns>
                  <asp:TemplateField HeaderText="Vị tr&#237;">
                     <ItemTemplate>
                        <asp:TextBox ID="txt_vi_tri_" runat="server" Text='<%# Eval("Vi_tri") %>' Width="25px"  CssClass="tipS smallText" original-title="Nhập stt"></asp:TextBox>
                        <asp:ImageButton ID="ImageButton1111" ToolTip="Cập nhật vị trí" runat="server" AlternateText='<%# "Cập nhật" %>'
                           CommandName="Update" ImageUrl="~/Admin/Images/save.gif" />
                     </ItemTemplate>
                     <FooterStyle HorizontalAlign="Center" />
                     <HeaderStyle HorizontalAlign="Center" />
                     <ItemStyle HorizontalAlign="Center" Width="55px" />
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Hot">
                     <ItemTemplate>
                        <%# Hot(Eval("Hot"))%>
                     </ItemTemplate>
                     <HeaderStyle HorizontalAlign="Center" />
                     <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>
                  <asp:TemplateField >
                     <HeaderTemplate>
                        <div class="sortCol header">Tiêu đề<span></span></div>
                     </HeaderTemplate>
                     <ItemTemplate>
                        <asp:HyperLink id="HyperLink1" runat="server" NavigateUrl='#' Text='<%# Eval("Tieu_de") %>' Target="_blank"></asp:HyperLink>
                     </ItemTemplate>
                     <HeaderStyle HorizontalAlign="Center" Width="20%" />
                  </asp:TemplateField>
                 
                  <asp:TemplateField >
                     <HeaderTemplate>
                        <div class="sortCol header">Tóm tắt<span></span></div>
                     </HeaderTemplate>
                     <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Cat_Chuoi(100,Eval("Tom_tat").ToString) %>'></asp:Label>
                     </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField >
                     <HeaderTemplate>
                        <div class="sortCol header">Hình<span></span></div>
                     </HeaderTemplate>
                     <ItemTemplate>
                     <asp:Label id="Label5" runat="server" Text='<%# Anh(Eval("Anh").ToString) %>'></asp:Label>
                        <asp:Label id="lbl_Anh" runat="server" Text='<%# Eval("Anh") %>' Visible="False"></asp:Label>
                     </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Thao t&#225;c">
                     <ItemTemplate>
                        <div class="smallButton tipS"  title="Sửa tin tức">
                           <a title="Sửa tin tức" href="JavaScript:newPopup('News_Add.aspx?S=<%#Eval("id") %>&id=<%=Request.QueryString.Get("id") %>');"><img src="images/pencil.png" alt=""></a>  
                        </div>
                        <div class="smallButton tipS"  title="Xóa">
                           <asp:ImageButton ID="ImageButton2" ToolTip="Xóa"  runat="server" AlternateText='<%# "Xóa" %>' CommandName="Delete"
                              ImageUrl="~/Admin/Images/close.png" />
                        </div>
                       
                        <asp:Label ID="lbl_id" runat="server" Text='<%# Eval("id") %>' Visible="False"></asp:Label>
                        <asp:Label ID="lbl_id_L" runat="server" Text='<%# Eval("id_L") %>' Visible="False"></asp:Label>
                     </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Hiện trạng">
                     <ItemTemplate>
                      <asp:Label ID="Label2" runat="server" Text='<%# Status1(Eval("Status")) %>'></asp:Label>
                     </ItemTemplate>
                     <HeaderStyle HorizontalAlign="Center" />
                     <ItemStyle HorizontalAlign="Center" Width="30px" />
                  </asp:TemplateField>
                  <asp:TemplateField>
                     <HeaderTemplate>
                        <span class=""> <input id="checkAll"  class="titleIcon checkAll" runat="server" name="checkAll"   type="checkbox" /></span> 
                     </HeaderTemplate>
                     <ItemTemplate>
                        <input id="contract" runat="server"  name="contract"  type="checkbox" />
                     </ItemTemplate>
                  </asp:TemplateField>
               </Columns>
               <PagerStyle CssClass="PagerStyle" />
            </asp:GridView>
        </div>
    </div>
</div>

</asp:Content>
