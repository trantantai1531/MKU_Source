<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WCatalogueItemList.aspx.vb" Inherits="eMicLibAdmin.WebUI.Catalogue.WCatalogueItemList" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title></title>
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
                <h2 class="main-head-form">Danh sách bản ghi dữ liệu biên mục</h2>
                <div class="row-detail">
                    <div class="table-form">
                        <asp:GridView ID="grdProperty" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="table-control" DataKeyNames="ID">
                            <HeaderStyle CssClass="lbGridHeader" Height="30px" />
                            <Columns>
                                <asp:BoundField DataField="STT" HeaderText="STT" ReadOnly="true">
                                    <HeaderStyle Width="5%" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Mã tài liệu">
                                    <HeaderStyle Width="10%" />
                                    <ItemTemplate>
                                        <asp:HyperLink ID="linkView" runat="server" Text='<%# Bind("Code")%>'></asp:HyperLink>
                                        <asp:HiddenField ID="CurrentID" runat="server" Value='<%# Bind("STT")%>' />
                                        <asp:HiddenField ID="FormID" runat="server" Value='<%# Bind("FormID")%>' />
                                        <asp:HiddenField ID="ItemID" runat="server" Value='<%# Bind("ID")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Title" HeaderText="Nhan đề" ReadOnly="true"/>
                                <asp:BoundField DataField="Author" HeaderText="Tác giả" ReadOnly="true">
                                    <HeaderStyle Width="20%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Cataloguer" HeaderText="Người biên mục" ReadOnly="true">
                                    <HeaderStyle Width="20%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderStyle-Width="10%" HeaderText="" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Button ID="btnDelete" CommandArgument='<%# CType(Container, GridViewRow).RowIndex%>' CommandName="Delete" runat="server" Text="Xóa" CssClass="form-btn" Height="34px" />
                                        <asp:LinkButton ID="btnEdit" runat="server" CssClass="form-btn">Sửa</asp:LinkButton>
                                        <asp:LinkButton ID="btnCopy" runat="server" CssClass="form-btn">Sao chép</asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle Width="15%"></HeaderStyle>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <%--<asp:CommandField ButtonType="Button" DeleteText="Xóa" ShowDeleteButton="True" HeaderStyle-Width="5%" ControlStyle-CssClass="form-btn" />--%>
                            </Columns>
                        </asp:GridView>
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
