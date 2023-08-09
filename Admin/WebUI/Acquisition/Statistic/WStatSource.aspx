<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WStatSource" CodeFile="WStatSource.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatSource</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body bgcolor="white" topmargin="0" leftmargin="0" rightmargin="0"
		bottommargin="0" onload="GenURL(7)">
		<form id="Form1" method="post" runat="server">
			<table id="StatisticItemType" runat="server" border="0" align="center" width="100%" bgcolor="white">
				<tr>
					<td width="100%" colspan="2"><asp:Label ID="lblNotFound" Runat="server" Visible="False" Width="100%" CssClass="lbPageTitle">Không tìm thấy dữ liệu</asp:Label></td>
				</tr>
				<tr>
					<td colspan="2">
						<asp:Label ID="lblMainTitle" Runat="server" Width="100%" CssClass="lbPageTitle">Thống kê theo nguồn bổ sung</asp:Label></td>
				</tr>
				<tr>
					<td colspan="2">
						<asp:Label id="lblDAP" runat="server" Width="100%" CssClass="lbGroupTitle"></asp:Label></td>
				</tr>
				<tr>
					<td>
						<IMG src="" border="0" name="anh1" id="anh1" runat="server"></td>
					<td>
						<IMG src="" border="0" name="anh2" id="anh2" runat="server"></td>
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
				<tr>
					<td align="center" colspan="2">
						<asp:Button id="btnClose" runat="server" Text="Trở lại(b)" CssClass="lbButton" Width="82px"></asp:Button></td>
				</tr>
			</table>
			<asp:Label ID="lblDAPTotal" Runat="server" Visible="False">Tổng số đầu ấn phẩm</asp:Label>
			<asp:Label ID="lblDAPHTitle" Runat="server" Visible="False">Nguồn bổ sung</asp:Label>
			<asp:Label ID="lblDAPVTitle" Runat="server" Visible="False">Số đầu ấn phẩm</asp:Label>
			<asp:Label ID="lblDAPTitle" Runat="server" Visible="False">Tỉ lệ % nguồn bổ sung theo đầu ấn phẩm</asp:Label>
			<asp:Label ID="lblBAPTotal" Runat="server" Visible="False">Tổng số bản ấn phẩm</asp:Label>
			<asp:Label ID="lblBAPHTitle" Runat="server" Visible="False">Nguồn bổ sung</asp:Label>
			<asp:Label ID="lblBAPVTitle" Runat="server" Visible="False">Số bản ấn phẩm</asp:Label>
			<asp:Label ID="lblBAPTitle" Runat="server" Visible="False">Tỉ lệ % nguồn bổ sung theo bản ấn phẩm</asp:Label>
			<asp:DropDownList ID="ddlLog" Runat="server" Visible="False">
				<asp:ListItem Value="0">Thống kê theo nguồn bổ sung</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi </asp:ListItem>
				<asp:ListItem Value="2">Mã lỗi </asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
