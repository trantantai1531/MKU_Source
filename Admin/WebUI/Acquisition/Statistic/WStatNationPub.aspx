<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WStatNationPub" CodeFile="WStatNationPub.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatNationPub</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body bgcolor="white" topmargin="0" leftmargin="0" rightmargin="0"
		bottommargin="0" onload="GenURL(7)">
		<form id="Form2" method="post" runat="server">
			<table id="StatisticItemType" border="0" align="center" width="100%" bgcolor="white">
				<tr>
					<td colspan="2">
						<asp:Label ID="lblMainTitle" Runat="server" Width="100%" CssClass="lbPageTitle main-head-form">Thống kê theo nước xuất bản</asp:Label></td>
				</tr>
				<tr>
					<td colspan="2">
						<asp:Label id="lblDAP" runat="server" Width="100%" CssClass="lbGroupTitle"></asp:Label></td>
				</tr>
				<tr>
					<td colspan="1">
						<IMG src="" border="0" name="anh1"></td>
					<td colspan="1">
						<IMG src="" border="0" name="anh2"></td>
				</tr>
				<tr>
					<td colspan="2">
						<asp:Label id="lblBAP" runat="server" Width="100%" CssClass="lbGroupTitle"></asp:Label></td>
				</tr>
				<tr>
					<td colspan="1">
						<IMG src="" border="0" name="anh3"></td>
					<td colspan="1">
						<IMG src="" border="0" name="anh4"></td>
				</tr>
				<tr>
					<td align="center" colspan="2" >
						<asp:Button id="btnClose" runat="server" Text="Trở lại(l)" Width="82px"></asp:Button>
                                    <asp:Button CssClass="lbButton" ID="btnExport" runat="server" Text="Xuất file"></asp:Button>
					</td>
				</tr>
			</table>
			<asp:Label ID="lblDAPTotal" Runat="server" Visible="False">Tổng số đầu ấn phẩm</asp:Label>
			<asp:Label ID="lblDAPHTitle" Runat="server" Visible="False">Nước xuất bản</asp:Label>
			<asp:Label ID="lblDAPVTitle" Runat="server" Visible="False">Số đầu ấn phẩm</asp:Label>
			<asp:Label ID="lblDAPTitle" Runat="server" Visible="False">Tỉ lệ % nước xuất bản theo đầu ấn phẩm</asp:Label>
			<asp:Label ID="lblBAPTotal" Runat="server" Visible="False">Tổng số bản ấn phẩm</asp:Label>
			<asp:Label ID="lblBAPHTitle" Runat="server" Visible="False">Nước xuất bản</asp:Label>
			<asp:Label ID="lblBAPVTitle" Runat="server" Visible="False">Số bản ấn phẩm</asp:Label>
			<asp:Label ID="lblBAPTitle" Runat="server" Visible="False">Tỉ lệ % nước xuất bản theo bản ấn phẩm</asp:Label>
			<asp:DropDownList ID="ddlLog" Runat="server" Visible="False">
				<asp:ListItem Value="0">Thống kê nước xuất bản</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi </asp:ListItem>
				<asp:ListItem Value="2">Mã lỗi </asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
