<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WEdataCollectionView" CodeFile="WEdataCollectionView.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Chọn bộ sưu tập</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="tblMainForm" width="100%" cellpadding="2" cellspacing="1">
				<tr Class="lbPageTitle">
					<td width="100%">
						<asp:Label ID="lblTitleForm" CssClass="lbPageTitle" Runat="server">Chọn bộ sưu tập điện tử</asp:Label>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="lblCollectionName" Runat="server"><u>T</u>ên bộ sưu tập:</asp:Label>&nbsp;
						<asp:DropDownList ID="ddlCollection" Runat="server"></asp:DropDownList>&nbsp;
						<asp:Button ID="btnSelect" Runat="server" Text=" Chọn(c)"></asp:Button>&nbsp;
						<asp:Button ID="btnClose" Runat="server" Text=" Đóng(d)"></asp:Button>
					</td>
				</tr>
			</table>
			<asp:dropdownlist ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Chi tiết lỗi</asp:ListItem>
			</asp:dropdownlist>
			<input id="hidFileIDsSelect" runat="server" type="hidden" name="hidFileIDsSelect">
		</form>
	</body>
</HTML>
