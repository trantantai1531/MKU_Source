<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Admin.WStatMonth" CodeFile="WStatMonth.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WStatMonth</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0" onload="GenURLImg(7)">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="main-body">
                <div class="content-form">
                    <asp:Label ID="lblPageTitle" runat="server" CssClass="lbPageTitle main-head-form" Width="100%">Thống kê các ngày trong tháng&nbsp;</asp:Label>
                    <div class="ClearFix main-page">
                        <div class="col-right-3">
                            <div class="row-detail">
                                <div class="button-control">
                                    <div class="button-form">
                                        <asp:Button ID="btnPrevMonth" runat="server" Text="Tháng trước(p)" CssClass="lbButton form-btn" ></asp:Button>
                                    </div>
                                    <div class="button-form">
                                        <asp:Button ID="btnNextMonth" runat="server" Text="Tháng sau(n)" CssClass="lbButton form-btn" Width="100px"></asp:Button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-left-7">
                            <img id="Img1" src="" usemap="#map1" border="0" name="Image1" runat="server"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <input id="hidMonth" type="hidden" runat="server">
        <input id="hidYear" type="hidden" runat="server">
        <asp:DropDownList runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Thống kê các ngày trong tháng&nbsp;</asp:ListItem>
            <asp:ListItem Value="3">Không có dữ liệu thoả mãn</asp:ListItem>
            <asp:ListItem Value="4">Thời gian (ngày)</asp:ListItem>
            <asp:ListItem Value="5">Số lượng giao dịch</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
