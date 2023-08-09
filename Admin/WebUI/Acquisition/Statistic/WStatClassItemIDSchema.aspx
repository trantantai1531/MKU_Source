<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WStatClassItemIDSchema" CodeFile="WStatClassItemIDSchema.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatClassItemIDSchema</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body bgcolor="white" topmargin="0" leftmargin="0" rightmargin="0"
		bottommargin="0" onload="GenAcqURL(7)">
		<form id="Form1" method="post" runat="server">
			<table id="StatClassItemIDSchema" border="0" align="center" width="100%" runat="server">
				<tr>
					<td colspan="2">
						<asp:Label ID="lblMainTitle" Runat="server" Width="100%" CssClass="lbPageTitle"></asp:Label></td>
				</tr>
				<tr>
					<td>
						<IMG src="" border="0" name="anh1" useMap="#map1"></td>
					<td>
						<IMG src="" border="0" name="anh2"></td>
				</tr>
			</table>
			
			<input type="hidden" runat="server" id="hidTimeFrom">
			<input type="hidden" runat="server" id="hidTimeTo">
			<input type="hidden" runat="server" id="hidItemType">
			
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Thống kê bản ấn phẩm theo chỉ số phân loại</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="3">Số lượng bản ấn phẩm</asp:ListItem>
				<asp:ListItem Value="4">Chỉ số</asp:ListItem>
				<asp:ListItem Value="5">Tỉ lệ % số lượng bản ấn phẩm theo chỉ số</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
