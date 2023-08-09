<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WStatByCategory" CodeFile="WStatByCategory.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatByCategory</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="if(document.forms[0].hidHave.value>0)GenURLImg1(9)"
		rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" id="divBody">
				<TR class="lbPageTitle">
					<td><asp:label id="lblHeader" Width="100%" Runat="server" CssClass="main-head-form">Thống kê ấn phẩm định kỳ theo kiểu tài liệu</asp:label></td>
				</TR>
				<TR>
					<TD align="center" colSpan="2"><asp:label id="lblTitleChartBarItem1" Width="100%" Runat="server" CssClass="lbSubformTitle">Biểu đồ hình cột</asp:label></TD>
				</TR>
				<TR>
					<TD align="center" bgColor="#ffffff"><IMG id="anh1" src="" useMap="#map1" border="0" name="Image1" runat="server">
						<asp:label id="lblNostatic" Runat="server" Visible=False>Không có thông tin thống kê !</asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2"><asp:label id="lblTitleChartBarCopynumber1" Width="100%" Runat="server" CssClass="lbSubformTitle">Biểu đồ hình tròn</asp:label></TD>
				</TR>
				<TR>
					<TD align="center" bgColor="#ffffff"><IMG id="anh2" src="" border="0" name="Image2" runat="server">
						<asp:label id="lblNostatic1" Runat="server" Visible=False>Không có thông tin thống kê !</asp:label></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblHTitle" Runat="server" Visible="False">Kiểu tài liệu</asp:label><asp:label id="lblVTitle" Runat="server" Visible="False">Số lượng ấn phẩm</asp:label></TD>
				</TR>
			</table>
			<asp:dropdownlist id="ddlLabel" runat="server" Visible="False" Height="0" Width="0">
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
			</asp:dropdownlist>
			<input id="hidHave" runat="server" type="hidden" value="0">
		</form>
	</body>
</HTML>
