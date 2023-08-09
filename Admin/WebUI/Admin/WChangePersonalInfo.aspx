<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Admin.WChangePersonalInfo" CodeFile="WChangePersonalInfo.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Các quyền trong phân hệ</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

</head>
<body class="backgroundbody" style="margin-top: 0px; margin-left: 0px; margin-right: 0px; margin-bottom: 0px;">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">

                <div class="center-form">
                    <h1 class="main-head-form">XEM THÔNG TIN TÀI KHOẢN</h1>
                        <div class="content-form">
                            <div class="main-form">
                                    <div class="two-column ClearFix">
                                        <div class="two-column-form">
                                            <div class="row-detail">
                                                <asp:Label ID="lblUserName" runat="server">Tên đăng nhập</asp:Label>
                                                <div class="input-control control-disabled">
                                                    <div class="input-form ">
                                                        <asp:TextBox ID="txtUserName" CssClass="text-input" runat="server" Enabled="False"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row-detail">
                                                <asp:Label ID="lblFullName" runat="server">Họ và tên</asp:Label>
                                                <div class="input-control">
                                                    <div class="input-form ">
                                                        <asp:TextBox ID="txtFullName" CssClass="text-input" runat="server" Enabled="False"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div style="display:none" class="two-column-form">
                                            <div class="row-detail">
                                                <asp:Label ID="lblOldPassWord" runat="server">Mật khẩu cũ</asp:Label>
                                                <div class="input-control">
                                                    <div class="input-form ">
                                                        <asp:TextBox ID="txtOldPassword" CssClass="text-input" runat="server" TextMode="Password"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row-detail">
                                                <asp:Label ID="lblNewPassWord" runat="server">Mật khẩu mới</asp:Label>
                                                <div class="input-control">
                                                    <div class="input-form ">
                                                        <asp:TextBox ID="txtNewPassword" CssClass="text-input" runat="server" TextMode="Password"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row-detail">
                                                <asp:Label ID="lblReTypePass" runat="server">Gõ lại mật khẩu</asp:Label>
                                                <div class="input-control">
                                                    <div class="input-form ">
                                                        <asp:TextBox ID="txtRetypePassword" CssClass="text-input" runat="server" TextMode="Password"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row-detail">
                                                <div class="button-control">
                                                    <div class="button-form">
                                                        <asp:Button ID="btnUpdate" CssClass="form-btn" runat="server" Text="Cập nhật"></asp:Button>
                                                    </div>
                                                    <div class="button-form">
                                                        <asp:Button ID="btnClose" CssClass="form-btn" runat="server" Text="Đóng(c)"></asp:Button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                            </div>
                        </div>
                </div>

        </div>
        <asp:DropDownList ID="ddlLabel" Height="0" Width="0" Visible="False" runat="server">
            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Nhập lại mật khẩu không chính xác</asp:ListItem>
            <asp:ListItem Value="3">Họ tên không được để trống</asp:ListItem>
            <asp:ListItem Value="4">Mật khẩu cũ không chính xác</asp:ListItem>
            <asp:ListItem Value="5">Mật khẩu mới không được để trống</asp:ListItem>
            <asp:ListItem Value="6">Cập nhật thành công</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
