﻿<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WStatLocation" CodeFile="WStatLocation.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatLocation</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0" onload="GenURL(7);">
		<form id="Form1" method="post" runat="server">
			<table id="tblLocation" border="0" align="center" width="100%" height="100%" bgcolor="white">
				<tr>
					<td width="100%" colspan="2"><asp:Label ID="lblNotFound" Runat="server" Visible="False" Width="100%" CssClass="lbPageTitle">Không tìm thấy dữ liệu</asp:Label></td>
				</tr>
				<tr>
					<td colspan="2">
						<asp:Label id="lblDAP" runat="server" Width="100%" CssClass="lbGroupTitle"></asp:Label></td>
				</tr>
				<tr>
					<td>
						<IMG src="" border="0" name="anh1" runat="server" id="anh1"></td>
					<td>
						<IMG src="" border="0" name="anh2" runat="server" id="anh2"></td>
				</tr>
				<tr>
					<td colspan="2">
						<asp:Label id="lblBAP" runat="server" Width="100%" CssClass="lbGroupTitle"></asp:Label></td>
				</tr>
				<tr>
					<td>
						<IMG src="" border="0" name="anh3"></td>
					<td>
						<IMG src="" border="0" name="anh4"></td>
				</tr>
			</table>
			<asp:Label ID="lblDapTotal" Runat="server" Visible="False">Tổng số đầu ấn phẩm: </asp:Label>
			<asp:Label ID="lblBapTotal" Runat="server" Visible="False">Tổng số bản ấn phẩm: </asp:Label>
			<asp:Label ID="lblDAPVTitle" Runat="server" Visible="False">Số đầu ấn phẩm</asp:Label>
			<asp:Label ID="lblDAPHTitle" Runat="server" Visible="False">Địa điểm lưu trữ</asp:Label>
			<asp:Label ID="lblDAPTitle" Runat="server" Visible="False">Tỉ lệ % đầu ấn phẩm theo địa điểm lưu trữ</asp:Label>
			<asp:Label ID="lblBAPVTitle" Runat="server" Visible="False">Số bản ấn phẩm</asp:Label>
			<asp:Label ID="lblBAPHTitle" Runat="server" Visible="False">Địa điểm lưu trữ</asp:Label>
			<asp:Label ID="lblBAPTitle" Runat="server" Visible="False">Tỉ lệ % bản ấn phẩm theo địa điểm lưu trữ</asp:Label>
			<asp:DropDownList ID="ddlLog" Runat="server" Visible="False">
				<asp:ListItem Value="0">Thống kê theo địa điểm lưu trữ</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi </asp:ListItem>
				<asp:ListItem Value="2">Mã lỗi </asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
