﻿<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WStatCreatedExpiredResult"
    CodeFile="WStatCreatedExpiredResult.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WStatCreated_ExpiredResult</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body bgcolor="#ffffff" onload="GenURL(7)" topmargin="0" leftmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
    <table id="Table1" cellspacing="1" cellpadding="1" width="100%" align="center" border="0" bgcolor="#ffffff">
        <tr align="center">
            <td align="center">
                <asp:Label ID="lblNotFound" runat="server" Width="100%" CssClass="lbPageTitle" Visible="False">Không tìm thấy dữ liệu</asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
				<asp:Button CssClass="lbButton" ID="btnClose" Runat="server" Text="Chọn lại(g)"></asp:Button>
                <asp:Button CssClass="lbButton" ID="btnExport" runat="server" Text="Xuất file"></asp:Button>
            </td>
        </tr>
        <tr>
            <td>
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr >
                        <td style="width:40%;display:none">
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr align="center">
                                    <td align="center">
                                        <img alt="" src="." border="0" name="anh1" id="anh1" runat="server">
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td align="center">
                                        <img alt="" src="." border="0" name="anh2" id="anh2" runat="server">
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width:60%;">
                             <div>
                                 <p><b>Tổng số: </b><asp:Label runat="server" ID="lblTotal"></asp:Label></p>
                             </div>
                            <div class="row-detail">
                                <asp:GridView ID="dtgResult" runat="server" Width="100%" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="lbGridItem" HeaderStyle-CssClass="lbGridHeader" AlternatingItemStyle-CssClass="lbGridAlterCell" AutoGenerateColumns="False" AllowPaging="True" PageSize="20">
                                    <Columns>
                                        <asp:BoundField HeaderText="STT" ItemStyle-HorizontalAlign="Center" DataField="STT" HeaderStyle-Width="5%"/>
                                        <asp:BoundField HeaderText="Họ và tên lót" ItemStyle-HorizontalAlign="Center" DataField="FirstName"/>
                                        <asp:BoundField HeaderText="Tên" ItemStyle-HorizontalAlign="Center" DataField="LastName"/>
                                        <asp:BoundField HeaderText="Mã số thẻ" ItemStyle-HorizontalAlign="Center" DataField="PatronCode"/>
                                        <asp:BoundField HeaderText="Ngày cấp thẻ" ItemStyle-HorizontalAlign="Center" DataField="LastIssuedDate" DataFormatString="{0:dd/MM/yyyy}"/>
                                        <asp:BoundField HeaderText="Ngày hết hạn" ItemStyle-HorizontalAlign="Center" DataField="ExpiredDate" DataFormatString="{0:dd/MM/yyyy}" Visible="false"/>
                                        <asp:BoundField HeaderText="Lớp" ItemStyle-HorizontalAlign="Center" DataField="Class" Visible="false"/>
                                        <asp:BoundField HeaderText="Khóa" ItemStyle-HorizontalAlign="Center" DataField="Grade" Visible="false"/>
                                        <asp:BoundField HeaderText="Đơn vị" ItemStyle-HorizontalAlign="Center" DataField="Faculty"/>
                                        <asp:BoundField HeaderText="Trường" ItemStyle-HorizontalAlign="Center" DataField="College"/>
                                        <asp:BoundField HeaderText="Nhóm bạn đọc" ItemStyle-HorizontalAlign="Center" DataField="GroupName"/>
                                        <asp:BoundField HeaderText="Số điện thoại" ItemStyle-HorizontalAlign="Center" DataField="Mobile"/>
                                        <asp:BoundField HeaderText="Email" ItemStyle-HorizontalAlign="Center" DataField="Email" />
                                        <asp:BoundField HeaderText="Địa chỉ" ItemStyle-HorizontalAlign="Center" DataField="Address" Visible="false"/>
                                        <asp:BoundField HeaderText="Tỉnh/Thành phố" ItemStyle-HorizontalAlign="Center" DataField="City" Visible="false"/>
                                        <asp:BoundField HeaderText="Ghi chú" ItemStyle-HorizontalAlign="Center" DataField="Note"/>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
    </table>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Chi tiết lỗi: </asp:ListItem>
            <asp:ListItem Value="1">Mã lổi: </asp:ListItem>
            <asp:ListItem Value="2">Bạn không có quyền thực hiện chức năng này</asp:ListItem>
            <asp:ListItem Value="3">Các năm cấp thẻ</asp:ListItem>
            <asp:ListItem Value="4">Các tháng trong năm</asp:ListItem>
            <asp:ListItem Value="5">Tỉ lệ % theo ngày cấp thẻ</asp:ListItem>
            <asp:ListItem Value="6">Số lượng thẻ</asp:ListItem>
            <asp:ListItem Value="7">Thống kê số lượng thể cấp trong năm, trong tháng</asp:ListItem>
        </asp:DropDownList>
            <asp:DropDownList runat="server" ID="ddlLabelHeaderTable" Visible="False" Height="0" Width="0">
                <asp:ListItem Value="0">STT</asp:ListItem>
                <asp:ListItem Value="1">Họ và tên lót</asp:ListItem>
                <asp:ListItem Value="2">Tên</asp:ListItem>
                <asp:ListItem Value="3">Mã số thẻ</asp:ListItem>
                <asp:ListItem Value="4">Ngày cấp thẻ</asp:ListItem>
                <asp:ListItem Value="5">Ngày hết hạn</asp:ListItem>
                <asp:ListItem Value="6">Lớp</asp:ListItem>
                <asp:ListItem Value="7">Khóa</asp:ListItem>
                <asp:ListItem Value="8">Đơn vị</asp:ListItem>
                <asp:ListItem Value="9">Trường</asp:ListItem>
                <asp:ListItem Value="10">Nhóm bạn đọc</asp:ListItem>
                <asp:ListItem Value="11">Số điện thoại</asp:ListItem>
                <asp:ListItem Value="12">Email</asp:ListItem>
                <asp:ListItem Value="13">Địa chỉ</asp:ListItem>
                <asp:ListItem Value="14">Tỉnh/Thành phố</asp:ListItem>
                <asp:ListItem Value="15">Ghi chú</asp:ListItem>
            </asp:DropDownList>
        <asp:Label ID="LabelStaticYear" runat="server" Text="Thống kê số lượng thể cấp từng năm" Visible="false"></asp:Label>
        <asp:Label ID="LabelStaticMonth" runat="server" Text="Thống kê số lượng thể cấp từng tháng trong năm" Visible="false"></asp:Label>
    </form>
</body>
</html>
