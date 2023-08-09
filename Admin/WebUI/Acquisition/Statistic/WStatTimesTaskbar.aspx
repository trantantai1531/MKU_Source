<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WStatTimesTaskbar.aspx.vb" Inherits="eMicLibAdmin.WebUI.Acquisition.WStatTimesTaskbar" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatDayTaskbar</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="StatDay" width="100%" border="0">
				<TR>
					<TD><asp:label id="lblMainTitle" Runat="server" CssClass="lbPageTitle" Width="100%">Thống kê ấn phẩm bổ sung theo ngày tháng năm</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<table width="100%" border="0">
                            <tr>
                                <td style="width:200px">
                                    <p>Từ ngày :<asp:hyperlink id="lnkDateFrom" Runat="server">&nbsp;Lịch</asp:hyperlink></p>
                                    <div class="input-control">
                                        <div class="input-form ">
                                            <asp:textbox CssClass="text-input"  id="txtDateFrom" Width="" Runat="server"></asp:textbox>
                                        </div>
                                    </div>
                                </td>
                                <td style="width:200px">
                                    <p>Đến ngày :<asp:hyperlink id="lnkDateTo" Runat="server">&nbsp;Lịch</asp:hyperlink></p>
                                    <div class="input-control">
                                        <div class="input-form ">
                                            <asp:textbox CssClass="text-input"  id="txtDateTo" Width="" Runat="server"></asp:textbox>
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <p>&nbsp;</p>
						            <asp:button CssClass="lbButton" id="btnStatistic" Runat="server" Text="Thống kê(s)" Width="92px"></asp:button>
						            <asp:button CssClass="lbButton" id="btnClose" Runat="server" Text="Trở lại(b)" Width="88px"></asp:button>
                                    <asp:Button CssClass="lbButton" ID="btnExport" runat="server" Text="Xuất file"></asp:Button>
                                </td>
                            </tr>
                        </table>
					</TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
                <asp:ListItem Value="3">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>