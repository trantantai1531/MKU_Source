<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WStatByRegularity" CodeFile="WStatByRegularity.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatByRegularity</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0" onload="if(document.forms[0].hidHave.value>0)GenURLImg1(9)">
		<form id="Form1" method="post" runat="server">
			<table width="100%" id="divBody">
				<TR Class="lbPageTitle">
					<td ><asp:Label ID="lblHeader" CssClass="main-head-form" Runat="server" Width="100%">Thống kê mức định kỳ</asp:Label></td>
				</TR>
				<TR>
					<TD colspan="2" align="center">
						<asp:Label CssClass="lbSubformTitle" Width="100%" id="lblTitleChartBarItem1" Runat="server">Biểu đồ hình cột</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" bgcolor="#ffffff"><IMG src="" border="0" usemap="#map1" name="Image1" runat="server" id="anh1"><asp:label id="lblNostatic" Runat="server" Visible=False>Không có thông tin thống kê !</asp:label>
					<TD></TD>
				<TR>
					<TD colspan="2" align="center">
						<asp:Label CssClass="lbSubformTitle" Width="100%" id="lblTitleChartBarCopynumber1" Runat="server">Biểu đồ hình tròn</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" bgcolor="#ffffff"><IMG src="" border="0" name="Image2" runat="server" id="anh2"><asp:label id="lblNostatic1" Runat="server" Visible=False>Không có thông tin thống kê !</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:Label ID="lblHTitle" Runat="server" Visible="False">Mức định kỳ</asp:Label>
						<asp:Label ID="lblVTitle" Runat="server" Visible="False">Số lượng ấn phẩm</asp:Label>
					</TD>
				</TR>
			</table>
			<asp:dropdownlist id="ddlLabel" runat="server" Visible="False" Height="0" Width="0">
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
				<asp:ListItem Value="3">Không xác định</asp:ListItem>
			</asp:dropdownlist>
			<input id="hidHave" runat="server" type="hidden" value="0" NAME="hidHave">
		</form>
	</body>
</HTML>
