<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WShowClaimLetter"
    EnableViewState="False" EnableViewStateMac="False" CodeFile="WShowClaimLetter.aspx.vb" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WShowClaimLetter</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <style>
        .lbButton {          
            margin-right: 17px;
        }
    </style>
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td width="100%">
                    <asp:Label ID="lblOutMsg" runat="server" Width="100%"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="100%">
                    <asp:Label ID="lblPublisher" runat="server" Visible="False">Tên nhà cung cấp</asp:Label>
                    <asp:Label ID="lblAddress" runat="server" Visible="False">Địa chỉ</asp:Label><asp:Label ID="lblPhone" runat="server" Visible="False">Số điện thoại</asp:Label>
                    <asp:Label ID="lblFax" runat="server" Visible="False">Số FAX</asp:Label><asp:Label ID="lblEmail" runat="server" Visible="False">Địa chỉ Email</asp:Label>
                    <asp:Label ID="lblContactperson" runat="server" Visible="False">Người liên hệ</asp:Label>
                    <asp:Label ID="lblProvince" runat="server" Visible="False">Tỉnh thành phố</asp:Label>
                    <asp:Label ID="lblPoCode" runat="server" Visible="False">Mã số hợp đồng</asp:Label>
                    <asp:Label ID="lblPoName" runat="server" Visible="False">Tên hợp đồng</asp:Label>
                    <asp:Label ID="lblValidDate" runat="server" Visible="False">Ngày có hiệu lực</asp:Label>
                    <asp:Label ID="lblExpiredDate" runat="server" Visible="False">Ngày hết hiệu lực</asp:Label>
                    <asp:Label ID="lblTotalMoney" runat="server" Visible="False">Tổng số tiền</asp:Label>
                    <asp:Label ID="lblCurrency" runat="server" Visible="False">Đơn vị tiền tệ</asp:Label>
                    <asp:Label ID="lblItemName" runat="server" Visible="False">Tên sách</asp:Label>
                    <asp:Label ID="lblNumber" runat="server" Visible="False">số</asp:Label>
                    <asp:Label ID="lblTotalNumber" runat="server" Visible="False">số toàn cục</asp:Label><asp:Label ID="lblIssueDate" runat="server" Visible="False">ngày phát hành</asp:Label>
                    <asp:Label ID="lblLessAmount" runat="server" Visible="False">số lượng thiếu</asp:Label>
                    <asp:Label ID="lblPrice" runat="server" Visible="False">đơn giá</asp:Label>
                    <asp:Label ID="lblSpecificTitle" runat="server" Visible="False">tên đặc biệt</asp:Label>
                    <asp:Label ID="lblSpecificIssue" runat="server" Visible="False">số đặc biệt</asp:Label>
                    <asp:Label ID="lblRepair" runat="server" Visible="False">Sửa(s)</asp:Label>
                    <asp:Label ID="lblClaimEmailTitle" runat="server" Visible="False">Thư kiếu nại ấn phẩm định kỳ</asp:Label>
                    <asp:Label ID="lblSendEmailSussessfullAlert" runat="server" Visible="false">Đã gửi thư tới nhà cung cấp</asp:Label>
                    <asp:Label ID="lblSendEmailUnSussessfullAlert" runat="server" Visible="False">Quá trình gửi thư bị lỗi</asp:Label>
                </td>
            </tr>
        </table>
        <asp:DropDownList ID="ddlColumnTitle" runat="server" Visible="False">
            <asp:ListItem Value="<$NUMBER$>">Số</asp:ListItem>
            <asp:ListItem Value="<$TOTALNUMBER$>">Số toàn cục</asp:ListItem>
            <asp:ListItem Value="<$ISSUEDATE$>">Ngày phát hành</asp:ListItem>
            <asp:ListItem Value="<$LESSAMOUNT$>">Số lượng thiếu</asp:ListItem>
            <asp:ListItem Value="<$PRICE$>">Đơn giá</asp:ListItem>
            <asp:ListItem Value="<$SPECIALTITLE$>">Tên số đặc biệt</asp:ListItem>
            <asp:ListItem Value="<$SPECIALISSUE$>">Kiểu số</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0" Height="0">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Bạn không có quyền thực hiện chức năng này</asp:ListItem>
            <asp:ListItem Value="3">Quá trình gửi thư có lỗi</asp:ListItem>
            <asp:ListItem Value="4">Đã gửi thư tới nhà cung cấp</asp:ListItem>
            <asp:ListItem Value="5">Gửi thư không thành công. Nhà cung cấp không có địa chỉ Email.</asp:ListItem>
            <asp:ListItem Value="6">Gửi thư(i)</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
