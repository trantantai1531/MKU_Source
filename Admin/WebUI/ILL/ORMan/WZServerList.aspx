<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WZServerList" CodeFile="WZServerList.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WZServerList</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0">
				<tr>
					<td align="center" class="lbPageTitle">
						<asp:Label id="lblHeader" runat="server" CssClass="lbPageTitle">Danh sách Z39.50 Server</asp:Label>
					</td>
				</tr>
				<tr>
					<td align="center">
						<asp:DataGrid id="dtgZDbs" runat="server" AutoGenerateColumns="False" Width="100%">
							<Columns>
								<asp:BoundColumn DataField="Name" HeaderText="T&#234;n thư viện">
									<HeaderStyle Wrap="False"></HeaderStyle>
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:HyperLinkColumn Text="&lt;Img src=&quot;../../images/select.jpg&quot; border=&quot;0&quot;&gt;"
									DataNavigateUrlField="LoadBack"></asp:HyperLinkColumn>
							</Columns>
						</asp:DataGrid>
					</td>
				</tr>
				<TR>
					<TD align="center">
						<asp:Button id="btnClose" runat="server" Text="Ðóng(d)" CssClass="lbButton"></asp:Button></TD>
				</TR>
			</table>
			<asp:dropdownlist id="ddlLabelNote" runat="server" Visible="False" Height="0" Width="0">
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
			</asp:dropdownlist>
		</form>
	</body>
</HTML>
