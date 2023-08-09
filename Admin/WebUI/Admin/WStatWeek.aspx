<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Admin.WStatWeek" CodeFile="WStatWeek.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WStatWeek</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

</head>
<body leftmargin="0" topmargin="0" onload="GenURLImg(9)">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="main-body">
                <div class="content-form">
                    <h1 class="main-head-form">Thống kê Log các ngày trong tuần theo phân hệ</h1>
                    <div class="ClearFix main-page">
                        <div class="col-right-3">
                            <div class="row-detail">
                                 <asp:Label ID="lblTypeMap" runat="server"><u>K</u>iểu đồ thị:</asp:Label>
                                <div class="input-control">
                                    <div class="dropdown-form">
                                        <asp:DropDownList ID="ddlTypeMap" runat="server" AutoPostBack="True">
                                            <asp:ListItem Value="0">Đồ thị cột chồng</asp:ListItem>
                                            <asp:ListItem Value="1">Đồ thị nhiều cột</asp:ListItem>
                                            <asp:ListItem Value="2">Đồ thị cột</asp:ListItem>
                                            </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <div class="button-control">
                                    <div class="button-form">
                                        <asp:Button ID="btnPrevWeek" CssClass="form-btn" runat="server" Text="Tuần trước(p)" ></asp:Button>
                                    </div>
                                    <div class="button-form">
                                        <asp:Button ID="btnWeekNext" CssClass="form-btn" runat="server" Text="Tuần sau(n)"></asp:Button>
                                    </div>
                                    <asp:DropDownList ID="ddlDay" runat="server" Visible="False">
                            <asp:ListItem Value="1">Thứ Hai</asp:ListItem>
                            <asp:ListItem Value="2">Thứ Ba</asp:ListItem>
                            <asp:ListItem Value="3">Thứ Tư</asp:ListItem>
                            <asp:ListItem Value="4">Thứ Năm</asp:ListItem>
                            <asp:ListItem Value="5">Thứ Sáu</asp:ListItem>
                            <asp:ListItem Value="6">Thứ Bẩy</asp:ListItem>
                            <asp:ListItem Value="7">Chủ Nhật</asp:ListItem>
                        </asp:DropDownList><asp:DropDownList ID="ddlSort" runat="server" Visible="False">
                            <asp:ListItem Value="1">Biên mục</asp:ListItem>
                            <asp:ListItem Value="2">Bạn đọc</asp:ListItem>
                            <asp:ListItem Value="3">Ấn phẩm định kỳ</asp:ListItem>
                            <asp:ListItem Value="4">Bổ xung</asp:ListItem>
                            <asp:ListItem Value="5">Mượn trả</asp:ListItem>
                            <asp:ListItem Value="6">OPAC</asp:ListItem>
                            <asp:ListItem Value="7">ILL</asp:ListItem>
                            <asp:ListItem Value="8">Phát hành</asp:ListItem>
                        </asp:DropDownList>
                                    <asp:DropDownList runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
                        <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
                        <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
                        <asp:ListItem Value="2">Tuần từ ngày </asp:ListItem>
                        <asp:ListItem Value="3"> đến ngày </asp:ListItem>
                        <asp:ListItem Value="4">Số lượng giao dịch</asp:ListItem>
                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-left-7">
                            <img src="" usemap="#map1" border="0" name="Image1" style="width:100%">
                        </div>
                    </div>

                </div>
            </div>
        </div>
        
        <input id="hidDate" type="hidden" runat="server">
    </form>
</body>
</html>
