<%@ Reference Page="~/Catalogue/Catalogue/WReference.aspx" %>
<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.WReference" CodeFile="WReference.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WReference</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" bottommargin="0" rightmargin="0 >
		<form id="Form1" method="post" runat="server">
			<asp:Table ID="tblRef" Runat="server"></asp:Table>
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0" Visible="False">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
