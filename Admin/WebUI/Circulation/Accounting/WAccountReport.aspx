<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WAccountReport" CodeFile="WAccountReport.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Báo cáo tổng hợp</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <style>
        .lbGridHeader {
            font-weight: bold;
            text-align: center;
        }
    </style>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="0" leftmargin="0">
    <form id="Form1" method="post" runat="server">
        <div class="">


            <table width="100%" class="table-print" border="0" cellpadding="0" cellspacing="0">
                <tr align="center" class="">
                    <td align="center" class="lbSubTitle">
                        <asp:Label ID="lblReportTitle" runat="server">BÁO CÁO CÂN ĐỐI CÁC KHOẢN THU VÀ PHẢI THU</asp:Label>
                    </td>
                </tr>
                <tr align="center" class="">
                    <td align="center" class="lbSubTitle">
                        <asp:Label ID="lblSubTitle" runat="server" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Table ID="tblReport" runat="server" CellSpacing="1" CellPadding="1"></asp:Table>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="lbSubTitle">
                        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Height="0" Width="0">
                            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
                            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
                            <asp:ListItem Value="2">Số thẻ</asp:ListItem>
                            <asp:ListItem Value="3">Tháng</asp:ListItem>
                            <asp:ListItem Value="4">tháng</asp:ListItem>
                            <asp:ListItem Value="5">Năm</asp:ListItem>
                            <asp:ListItem Value="6">năm</asp:ListItem>
                            <asp:ListItem Value="7">Số dư</asp:ListItem>
                            <asp:ListItem Value="8">Tổng</asp:ListItem>
                            <asp:ListItem Value="9">Ngày</asp:ListItem>
                            <asp:ListItem Value="10">Diễn giải</asp:ListItem>
                            <asp:ListItem Value="11">Thu</asp:ListItem>
                            <asp:ListItem Value="12">Phải thu</asp:ListItem>
                            <asp:ListItem Value="13">Tỉ giá hạch toán</asp:ListItem>
                            <asp:ListItem Value="14">Số tiền</asp:ListItem>
                            <asp:ListItem Value="15">Đơn vị TT</asp:ListItem>
                            <asp:ListItem Value="16">Tỉ giá thực tế</asp:ListItem>
                            <asp:ListItem Value="17">Số tiền chênh lệch với tỉ giá (VND)</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>

        </div>
    </form>
    <script language="JavaScript">
			<!--
    self.focus();
    setTimeout('self.print()', 1);
    //-->
    </script>
</body>
</html>
