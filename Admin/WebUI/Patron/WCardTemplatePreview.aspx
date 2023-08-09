<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WCardTemplatePreview" EnableViewState="False" EnableViewStateMAC="False" CodeFile="WCardTemplatePreview.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Xem trước khuôn dạng thẻ đọc</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link id="Link1" runat="server" href="../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link id="Link2" runat="server" href="../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link id="Link3" runat="server" href="../Resources/StyleSheet/iconFont.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td align="center">
						<asp:Label ID="lblMainTitle" Runat="server" Width="100%" CssClass="lbPageTitle">Xem mẫu thẻ bạn đọc</asp:Label></td>
				</tr>
				<tr>
					<td><asp:Label ID="lblPreview" Runat="server" Width="100%"></asp:Label></td>
				</tr>
				<tr>
					<td align="center" bgcolor="#c0c0c0"><asp:Button ID="btnClose" Runat="server" Text="Đóng(o)" Width="73px"></asp:Button></td>
				</tr>
			</table>
			<asp:DropDownList ID="ddlContent" Runat="server"  Visible="False" Width="0">
				<asp:ListItem Value="NAME">Nguyễn Văn Hải</asp:ListItem>
				<asp:ListItem Value="CODE">1234D</asp:ListItem>
				<asp:ListItem Value="DOB">12/05/1985</asp:ListItem>
				<asp:ListItem Value="OCCUPATION">Sinh viên</asp:ListItem>
				<asp:ListItem Value="WORKPLACE">Đại học khoa học tự nhiên</asp:ListItem>
				<asp:ListItem Value="ADDRESS">344 Nguyễn Trãi- Thanh Xuân- Hà Nội</asp:ListItem>
				<asp:ListItem Value="TELEPHONE">2365478</asp:ListItem>
				<asp:ListItem Value="GRADE">Đại học</asp:ListItem>
				<asp:ListItem Value="CLASS">A2</asp:ListItem>
				<asp:ListItem Value="FACULTY">Sinh vật</asp:ListItem>
				<asp:ListItem Value="CARDVALIDDATE">21/8/2002</asp:ListItem>
				<asp:ListItem Value="CARDEXPIREDDATE">21/8/2007</asp:ListItem>
				<asp:ListItem Value="EMAIL">hainv@yahoo.com</asp:ListItem>
				<asp:ListItem Value="ETHINIC">Kinh</asp:ListItem>
				<asp:ListItem Value="BARCODE">1234D</asp:ListItem>
				<asp:ListItem Value="PICTURE">../Images/Card/163.gif</asp:ListItem>
			</asp:DropDownList>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
