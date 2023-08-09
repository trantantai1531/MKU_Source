<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.WHelpItemLink" CodeFile="WHelpItemLink.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWHelpBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WHelpItemLink</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0">
				<tr>
					<td align="center"><asp:label id="Label3" runat="server" Visible="False">Các chức năng</asp:label></td>
					<td></td>
					<td align="center"><asp:label id="Label1" runat="server" Visible="False">Các chức năng đã chọn</asp:label></td>
				</tr>
				<tr>
					<td width="45%"><asp:listbox id="lstLink" runat="server" SelectionMode="Multiple" Height="400px" Width="100%"></asp:listbox>
					</TĐ>
					<td vAlign="middle" align="center"><asp:button id="bttAddAll" runat="server" Width="72px" Text=">>"></asp:button><br>
						<asp:button id="bttDeleteAll" runat="server" Width="72px" Text="<<"></asp:button><br>
						<asp:button id="bttAddOne" runat="server" Width="72px" Text=">|"></asp:button><br>
						<asp:button id="bttDeleteOne" runat="server" Width="72px" Text="|<"></asp:button><br>
					</td>
					<td width="45%"><asp:listbox id="lstLinkSelected" runat="server" SelectionMode="Multiple" Height="400px" Width="100%"></asp:listbox></td>
				</tr>
				<tr>
					<td align="right" colSpan="3"><asp:button id="bttSelect" runat="server" Height="24px" Width="104px" Text="Chọn"></asp:button><asp:button id="bttClose" runat="server" Height="24px" Width="104px" Text="Đóng"></asp:button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
