<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WMarcFieldSend" CodeFile="WMarcFieldSend.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WMarcFieldSend</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
				<TR class="lbControlBar">
					<TD align="center">
						<asp:Button ID="btnProcess" Text="Cập nhật(u)" Runat="server" Width="98px"></asp:Button></TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Tạo mới(u)</asp:ListItem>
				<asp:ListItem Value="1">Cập nhật(u)</asp:ListItem>
				<asp:ListItem Value="2">Bạn chưa nhập nhãn trường!</asp:ListItem>
				<asp:ListItem Value="3">Bạn chưa nhập tên trường!</asp:ListItem>
				<asp:ListItem Value="4">Nhãn trường không hợp lệ!</asp:ListItem>
				<asp:ListItem Value="5">Dữ liệu không phải là số!</asp:ListItem>
				<asp:ListItem Value="6">Trường con</asp:ListItem>
				<asp:ListItem Value="7">Chỉ định dữ liệu</asp:ListItem>
				<asp:ListItem Value="8">Đường dẫn vật lý</asp:ListItem>
				<asp:ListItem Value="9">URL</asp:ListItem>
				<asp:ListItem Value="10">Cập nhật thông tin thành công!</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
