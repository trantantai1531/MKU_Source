<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WReferenceToFilter" CodeFile="WReferenceToFilter.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Tra cứu từ điển tham chiếu</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="4" width="100%" border="0">
				<TR Class="lbPageTitle">
					<TD align="center"><asp:label id="lblMainTitle" runat="server" CssClass="lbPageTitle main-group-form">Tra cứu từ điển tham chiếu</asp:label></TD>
				</TR>
				<TR>
					<TD align="center"><asp:listbox id="lstEntries" runat="server" Height="200px" Width="256px"></asp:listbox></TD>
				</TR>
				<TR>
					<TD align="center"><asp:button id="btnSelect" runat="server" CssClass="lbButton" Text="Chọn (s)"></asp:button>&nbsp;<asp:button id="btnClose" runat="server" CssClass="lbButton" Text="Ðóng (c)"></asp:button></TD>
				</TR>
			</TABLE>
			<asp:DropDownList Runat="server" ID="ddlLabel" Visible="False" Height="0" Width="0">
				<asp:ListItem Value="0">Tra cứu từ điển tham chiếu</asp:ListItem>
				<asp:ListItem Value="1">Không có mục từ nào thoả mãn điều kiện tìm kiếm</asp:ListItem>
				<asp:ListItem Value="2">Từ điển tham chiếu của mục từ trên không tồn tại</asp:ListItem>
				<asp:ListItem Value="3">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="4">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
