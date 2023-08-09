<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.WHelpHeader" CodeFile="WHelpHeader.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWHelpBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WHelpHeader</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td>
						<asp:HyperLink id="lnkContent" runat="server">Nội dung</asp:HyperLink>
						<asp:HyperLink id="lnkSearch" runat="server">Tìm kiếm</asp:HyperLink>
						<asp:label id="lblHeader" Runat="server" BackColor="White"></asp:label>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
