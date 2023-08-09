<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WCataViewHidden" CodeFile="WCataViewHidden.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WCataViewHidden</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<asp:dropdownlist id="ddlLabel" Visible="False" Runat="server" Height="0" Width="0">
				<asp:ListItem value="0">Chỉ thị dữ liệu thứ nhất không hợp lệ</asp:ListItem>
				<asp:ListItem value="1">Chỉ thị dữ liệu thứ hai không hợp lệ</asp:ListItem>
				<asp:ListItem value="2">Cả hai chỉ thị dữ liệu không hợp lệ</asp:ListItem>
				<asp:ListItem value="3">Không tồn tại</asp:ListItem>
				<asp:ListItem Value="4">Giá trị mặc định</asp:ListItem>
			</asp:dropdownlist></form>
	</body>
</HTML>
