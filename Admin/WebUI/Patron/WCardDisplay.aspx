<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WCardDisplay" CodeFile="WCardDisplay.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WCardDisplay</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0" bgcolor="#ffffff">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#ffffff" height="100%">
				<TR>
					<TD width="100%" align="center"><asp:Label ID="lblNotFound" Runat="server" Width="100%" CssClass="lbPageTitle" Visible="false">Không tìm thấy dữ liệu</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" width="100%">
						<asp:table id="tblResult" runat="server" Width="100%"></asp:table></TD>
				</TR>
			</table>
			<asp:Label ID="lblNote" Runat="server" Visible="False">Bạn chọn số cột quá nhỏ</asp:Label>
		</form>
	</body>
</HTML>
