<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WShowRec" CodeFile="WShowRec.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>Thông tin bản ghi tìm được</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
  </HEAD>
	<body topmargin="5" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table border="0" width="100%" cellpadding="2" cellspacing="0">
				<tr>
					<td class="lbPageTitle">
						<asp:Label ID="lblHeader" Runat="server" CssClass="lbPageTitle">Hiển thị các bản ghi</asp:Label>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Table id="tblResult" runat="server" Width="100%" CellPadding="0"></asp:Table>
					</td>
				</tr>
				<tr>
					<asp:dropdownlist id="ddlLabel" Runat="server" Width="0" Visible="False">
						<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
						<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
						<asp:ListItem Value="2">Dùng biểu ghi</asp:ListItem>
						<asp:ListItem Value="3">Dùng thông tin</asp:ListItem>
					</asp:dropdownlist>
				</tr>
			</table>
		</form>
	</body>
</HTML>
