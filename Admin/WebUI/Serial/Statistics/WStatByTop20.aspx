<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WStatByTop20" CodeFile="WStatByTop20.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Thống kê theo top 20</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0" rightmargin="0" onload="if(document.forms[0].hidHave.value>0)GenURLImg1(9);">
    <form id="Form1" method="post" runat="server">
        <table id="Table1" cellspacing="1" cellpadding="2" width="100%" border="0">
            <tr class="lbPageTitle" id="divBody">
                <td>
                    <asp:Label ID="lblTitle" runat="server" CssClass="main-head-form" Width="100%">Thống kê TOP 20 nhóm ấn phẩm định kỳ theo một thuộc tính thư mục</asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblName" runat="server">Thuộc tính: </asp:Label>
                    &nbsp;
						<asp:DropDownList ID="lstName" runat="server"></asp:DropDownList>
                    <asp:Button ID="btnStatic" runat="server" Text="Thống kê(t)" Width="82px"></asp:Button>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Label CssClass="lbSubformTitle" Width="100%" ID="lblTitleChartBarItem1" runat="server">Biểu đồ hình cột</asp:Label></td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <img src="" border="0" name="Image1" runat="server" id="Img1"><asp:Label ID="lblNostatic" runat="server" Visible="False">Không có thông tin thống kê !</asp:Label></td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Label CssClass="lbSubformTitle" Width="100%" ID="lblTitleChartBarCopynumber1" runat="server">Biểu đồ hình tròn</asp:Label></td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <img src="" border="0" name="Image2" runat="server" id="anh2"><asp:Label ID="lblNostatic1" runat="server" Visible="False">Không có thông tin thống kê !</asp:Label></td>
            </tr>
        </table>
        <asp:DropDownList ID="ddlLabel" runat="server" Width="0px" Visible="False">
            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
            <asp:ListItem Value="3">Thuộc tính</asp:ListItem>
            <asp:ListItem Value="4">Số lượng ấn phẩm</asp:ListItem>
        </asp:DropDownList>
        <input id="hidHave" runat="server" type="hidden" value="0" name="hidHave">
    </form>
</body>
</html>
