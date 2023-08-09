<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WPatronLockInfo" CodeFile="WPatronLockInfo.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WPatronLockInfo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table cellpadding="3" cellspacing="0" width="100%">
				<tr>
					<td colspan="2" Class="lbPageTitle">
						<asp:label id="lblTitle" Runat="server" CssClass="lbPageTitle">Thông tin chi tiết bạn đọc đang bị khóa</asp:label>
					</td>
				</tr>
				<tr>
					<td width="30%" align="right">
						<asp:label id="lblName" Runat="server">Họ tên:</asp:label>
					</td>
					<td>
						<asp:Label id="lblFN" runat="server" Font-Bold="True"></asp:Label>
					</td>
				</tr>
				<tr>
					<td align="right">
						<asp:label id="lblPatronCode" Runat="server">Số thẻ:</asp:label>
					</td>
					<td>
						<asp:Label id="lblCD" runat="server" Font-Bold="True"></asp:Label>
					</td>
				</tr>
				<tr>
					<td align="right">
						<asp:label id="lblLockDate" Runat="server">Ngày bị khóa:</asp:label>
					</td>
					<td>
						<asp:Label id="lblLock" runat="server" Font-Bold="True"></asp:Label>
					</td>
				</tr>
				<tr>
					<td align="right">
						<asp:label id="lblUnlockDate" Runat="server">Đến hết ngày:</asp:label>
					</td>
					<td>
						<asp:Label id="lblUnlock" runat="server" Font-Bold="True"></asp:Label>
					</td>
				</tr>
				<TR>
					<TD align="right">
						<asp:label id="lblReason" Runat="server">Lí do bị khóa:</asp:label></TD>
					<TD>
						<asp:Label id="lblNote" runat="server" Font-Bold="True"></asp:Label></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
