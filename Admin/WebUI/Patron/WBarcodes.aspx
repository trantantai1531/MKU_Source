<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WBarcodes" CodeFile="WBarcodes.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WBarcodes</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0" bottommargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#ffffff"
				align="center">
				<tr>
					<td width="100%"><asp:Label ID="lblNotFound" Runat="server" Width="100%" CssClass="lbPageTitle" Visible="False">Không tìm thấy dữ liệu</asp:Label></td>
				</tr>
				<tr>
					<td width="100%" align="center">
						<asp:Table id="tblView" Runat="server"></asp:Table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
