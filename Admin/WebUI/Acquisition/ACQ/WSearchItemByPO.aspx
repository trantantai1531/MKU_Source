<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WSearchItemByPO" CodeFile="WSearchItemByPO.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Tìm theo thông tin đơn đặt</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="5" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellpadding="2" cellspacing="0">
				<tr>
					<td colspan="2" align="center" class="lbPageTitle">
					    <h1 class="main-group-form"><asp:Label id="lblHeader" runat="server" CssClass="lbPageTitle">Xác định ấn phẩm theo đơn dặt</asp:Label></h1>
						
					</td>
				</tr>
				<tr>
					<td align="right">
						<asp:Label id="lblPO" runat="server"><U>M</U>ã đơn đặt</asp:Label>
					</td>
					<td>
						<asp:Label id="lblCode" runat="server">Mã <U>t</U>ài liệu</asp:Label>
					</td>
				</tr>
				<TR>
					<TD align="right">
						<asp:DropDownList id="ddlPO" runat="server" AutoPostBack="True"></asp:DropDownList></TD>
					<TD>
						<asp:DropDownList id="ddlCode" runat="server"></asp:DropDownList></TD>
				</TR>
				<TR>
					<TD colspan="2" align="center">
					<INPUT type="hidden" size="1" name="txtPOID" id="txtPOID" runat="server">
						<asp:Button id="btnSelect" runat="server" Text="Nhập(u)" Width="70px"></asp:Button>&nbsp;
						<asp:Button id="btnClose" runat="server" Text="Đóng(c)" Width="70px"></asp:Button></TD>
				</TR>
			</table>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
