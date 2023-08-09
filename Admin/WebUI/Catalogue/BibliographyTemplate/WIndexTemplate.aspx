<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WIndexTemplate" CodeFile="WIndexTemplate.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WIndexTemplate</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="3" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="main-body">
                 <asp:Label ID="Label1" runat="server" CssClass="main-head-form">Mẫu biên mục(dữ liệu thư mục)</asp:Label>
                <div class="two-column ClearFix">
                <div class="group-menu two-column-form">
                   
                    <div class="row-detail">
                        <asp:Label ID="lblSubTitle1" runat="server" CssClass="lbGroupTitle">Mẫu biên mục</asp:Label>
                        <div class="input-control">
                            <div class="listbox-form">
                                <asp:ListBox ID="lstMarcForm" runat="server" Width="" Height="220px" Rows="7"></asp:ListBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <div class="button-control">
                            <div class="button-form">
                                <asp:Button ID="btnUpdate" CssClass="form-btn" runat="server" Width="" Text="Cập nhật(u)"></asp:Button>
                            </div>
                            <div class="input-control" style="  max-width: 25%;display: inline-block;">
                                    <div class="dropdown-form">
                                        <asp:dropdownlist id="ddlMarcForm" runat="server"></asp:dropdownlist>
                                    </div>
                                </div>
                            
                            <div class="button-form">
                                <asp:Button ID="btnMerger" CssClass="form-btn" runat="server" Width="" Text="Gộp(m)"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="group-menu two-column-form">
                    <div class="row-detail">
                        <asp:Label ID="lblSubTitle2" runat="server" CssClass="lbGroupTitle">Trường biên mục</asp:Label>
                        <div class="input-control">
                            <div class="listbox-form">
                                <asp:ListBox ID="lstMarcField" runat="server" Width="" Height="220px" Rows="7"></asp:ListBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <div class="button-control">
                            <div class="button-form">
                                <asp:Button ID="btnUpdateField" runat="server" Width="98px" Text="Cập nhật(p)"></asp:Button>
                            </div>
                        </div>
                        <div class="button-control">
                            <div class="button-form">
                                <asp:button id="btnDelete" runat="server" Width="64px" Text="Xoá(d)" Visible="False"></asp:button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
                </div>
        </div>
        <asp:DropDownList ID="ddlLabel" Width="0" Visible="False" runat="server">
            <asp:ListItem Value="0">Bạn chưa chọn mẫu biên mục nguồn!</asp:ListItem>
            <asp:ListItem Value="1">Tạo mới</asp:ListItem>
            <asp:ListItem Value="2">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="3">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="4">Gộp các mẫu biên mục</asp:ListItem>
            <asp:ListItem Value="5">Gộp mẫu biên mục thành công!</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
