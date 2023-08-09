<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WStatClassCopyNumberSchema" CodeFile="WStatClassCopyNumberSchema.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatClassCopyNumberSchema</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body bgcolor="white" topmargin="0" leftmargin="0" rightmargin="0" bottommargin="0" onload="GenAcqURL(7)">
		<form id="Form1" method="post" runat="server">
			<table id="StatClassCopyNumberSchema" border="0" align="center" width="100%" height="100%" bgcolor="white">
				<tr>
					<td colspan="2"><asp:Label ID="lblMainTitle" Runat="server" Width="100%" CssClass="lbPageTitle"></asp:Label></td>
				</tr>
				<tr>
					<td>	
						<IMG src="" border="0" name="anh1" useMap="#map1"></td>
					<td>
						<IMG src="" border="0" name="anh2"></td>
				</tr>
			</table>
			<asp:Label ID="lblVTitle" Runat="server" Visible="False">Số lượng đầu ấn phẩm</asp:Label>
			<asp:Label ID="lblHTitle" Runat="server" Visible="False">Chỉ số </asp:Label>
			<asp:Label ID="lblTitle" Runat="server" Visible="False">Tỉ lệ % số lượng đầu ấn phẩm theo chỉ số </asp:Label>

			<asp:DropDownList ID="ddlLog" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Thống kê đầu ấn phẩm theo chỉ số phân loại </asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi </asp:ListItem>
				<asp:ListItem Value="2">Mã lỗi </asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
