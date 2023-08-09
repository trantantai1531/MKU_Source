﻿<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WstatCountry" CodeFile="WStatCountry.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Thống kê theo nước xuất bản</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0" rightmargin="0" onload="if(document.forms[0].hidHave.value>0)GenURLImg1(9)">
    <form id="Form1" method="post" runat="server">
        <table width="100%" id="divBody">
            <tr class="lbPageTitle">
                <td >
                    <asp:Label ID="lblHeader" runat="server" CssClass="main-head-form" Width="100%">Thống kê ấn phẩm định kỳ theo nước xuất bản</asp:Label></td>
            </tr>
            <tr>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Label CssClass="lbSubformTitle" Width="100%" ID="lblTitleChartBarItem1" runat="server">Biểu đồ hình cột</asp:Label></td>
            </tr>
            <tr>
                <td align="center" bgcolor="#ffffff">
                    <img src="" border="0" usemap="#map1" name="Image1" runat="server" id="anh1"><asp:Label ID="lblNostatic" runat="server" Visible="False">Không có thông tin thống kê !</asp:Label></td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Label CssClass="lbSubformTitle" Width="100%" ID="lblTitleChartBarCopynumber1" runat="server">Biểu đồ hình tròn</asp:Label></td>
            </tr>
            <tr>
                <td align="center" bgcolor="#ffffff">
                    <img src="" border="0" name="Image2" runat="server" id="anh2"><asp:Label ID="lblNostatic1" runat="server" Visible="False">Không có thông tin thống kê !</asp:Label></td>
            </tr>
        </table>
        <asp:DropDownList ID="ddlLabel" runat="server" Width="0px" Visible="False">
            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
            <asp:ListItem Value="3">Nước xuất bản</asp:ListItem>
            <asp:ListItem Value="4">Số lượng ấn phẩm</asp:ListItem>
            <asp:ListItem Value="5">Không xác định</asp:ListItem>
        </asp:DropDownList>
        <input id="hidHave" runat="server" type="hidden" value="0" name="hidHave">
    </form>
</body>
</html>
