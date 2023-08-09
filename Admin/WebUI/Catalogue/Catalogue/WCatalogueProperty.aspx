<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WCatalogueProperty" CodeFile="WCatalogueProperty.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WCatalogueProperty</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
   
</head>
<body leftmargin="0" topmargin="0">
    <form id="frm" method="post" runat="server">
        <div id="divBody">
            <div class="main-body">
                <div id="tblTaggedContent" class="content-form" runat="server">
                    <asp:Label ID="lblMainTitle" runat="server" CssClass="main-head-form"></asp:Label>
                
                    <div class="input-control row-detail">
                        <div class="table-form">
                            <asp:DataGrid ID="grdProperty" CssClass="table-control" runat="server" AutoGenerateColumns="False" Width="100%">
                                <AlternatingItemStyle CssClass="lbGridAlterCell"></AlternatingItemStyle>
                                <ItemStyle CssClass="lbGridCell"></ItemStyle>
                                <HeaderStyle CssClass="lbGridHeader"></HeaderStyle>
                                <Columns>
                                    <asp:TemplateColumn HeaderText="Nh&#227;n">
                                        <HeaderStyle Width="5%"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="lnkFieldCode" runat="server" CssClass="lbLinkFunction">
											        <%#DataBinder.Eval(Container.dataItem,"FieldCode")%>
                                            </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:BoundColumn DataField="Ind" HeaderText="Chỉ thị">
                                        <HeaderStyle Width="15%"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Content" HeaderText="Nội dung trường">
                                        <HeaderStyle HorizontalAlign="Center" Width="90%"></HeaderStyle>
                                    </asp:BoundColumn>
                                </Columns>
                            </asp:DataGrid>
                        </div>
                    </div>
                    <div class="row-detail">
                        <div class="button-control inline-box">
                            <asp:Label ID="lblConfirmDelete" runat="server" Visible="False">Bạn đang chuẩn bị xóa bản ghi biên mục của ấn phẩm này ra khỏi cơ sở dữ liệu. Để khẳng định, bấm nút "Xóa".</asp:Label>
                            <div class="button-form">
                                <asp:Button ID="btnStatus"  runat="server" CssClass="form-btn" Text="Button"></asp:Button>
                            </div>
                            <div class="button-form">
                                <asp:Button ID="btnCancel" runat="server" CssClass="form-btn" Visible="False" Text="Button"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
  
        <asp:DropDownList ID="ddlLabel" Width="0px" Visible="False" runat="server">
            <asp:ListItem Value="0">Xoá bản ghi biên mục</asp:ListItem>
            <asp:ListItem Value="1">Xoá bản ghi dữ liệu căn cứ</asp:ListItem>
            <asp:ListItem Value="2">Hiển thị bản ghi</asp:ListItem>
            <asp:ListItem Value="3">Xem bản ghi dữ liệu biên mục</asp:ListItem>
            <asp:ListItem Value="4">Xem bản ghi dữ liệu căn cứ</asp:ListItem>
            <asp:ListItem Value="5">Không thể xoá bản ghi dữ liệu biên mục vì vẫn tồn tại mã xếp giá</asp:ListItem>
            <asp:ListItem Value="6">Đóng</asp:ListItem>
            <asp:ListItem Value="7">Xoá</asp:ListItem>
            <asp:ListItem Value="8">Sửa</asp:ListItem>
            <asp:ListItem Value="9">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="10">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="11">Xoá bản ghi dữ liệu biên mục (1 bản ghi)</asp:ListItem>
            <asp:ListItem Value="12">Xoá bản ghi dữ liệu căn cứ (1 bản ghi)</asp:ListItem>
            <asp:ListItem Value="13">Xoá bản ghi thành công!</asp:ListItem>
            <asp:ListItem Value="14">Bạn có muốn xóa bản ghi biên mục này không?</asp:ListItem>
            <asp:ListItem Value="15">Hủy</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
