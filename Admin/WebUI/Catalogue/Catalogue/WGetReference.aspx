<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WGetReference" CodeFile="WGetReference.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Từ điển tham chiếu</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="4" width="100%" border="0">
				<TR Class="lbPageTitle">
					<TD align="center">
						<asp:Label CssClass="main-group-form" id="lblMainTitle" runat="server">Tra cứu từ điển tham chiếu</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:ListBox id="lstEntries" runat="server" Width="300px" Height="200px" style="overflow-x:auto;"></asp:ListBox></TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:Button id="btnSelect" runat="server" Text="Chọn(c)"></asp:Button>
						<asp:Button id="btnClose" runat="server" Text="Đóng(o)"></asp:Button></TD>
				</TR>
			</TABLE>
		    <input id="hidTable" type="hidden" runat="server"/>
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0px" Visible="False">
				<asp:ListItem Value="0"></asp:ListItem>
				<asp:ListItem Value="1">Tra cứu từ điển tham chiếu</asp:ListItem>
				<asp:ListItem Value="2">Không có mục từ nào thỏa mãn điều kiện đặt ra</asp:ListItem>
				<asp:ListItem Value="3">Trường này không sử dụng từ điển tham chiếu nào.</asp:ListItem>
				<asp:ListItem Value="4">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="5">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
