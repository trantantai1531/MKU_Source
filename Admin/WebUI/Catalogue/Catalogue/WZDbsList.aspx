<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WZDbsList" CodeFile="WZDbsList.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>Danh sách máy chủ Z39.50</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
  </HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0">
				<tr>
					<td align="center" class="lbPageTitle">
						<asp:Label id="lblHeader" runat="server" CssClass="lbPageTitle main-group-form">Danh sách Z39.50 Server</asp:Label>
					</td>
				</tr>
				<tr>
					<td align="center">
						<asp:DataGrid id="dtgZDbs" runat="server" AutoGenerateColumns="False" Width="100%">
							<Columns>
								<asp:BoundColumn DataField="Name" HeaderText="Tên thư viện">
									<HeaderStyle Wrap="False"></HeaderStyle>
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:HyperLinkColumn ItemStyle-Width="10%" HeaderText="Chọn" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" Text="<Img src='../../images/select.jpg' border='0'>" DataNavigateUrlField="LoadBack"></asp:HyperLinkColumn>
							</Columns>
						</asp:DataGrid>
					</td>
				</tr>
				<TR class="lbControlBar">
					<TD align="center">
						<asp:Button id="btnClose" runat="server" Text="Đóng(o)" CssClass="lbButton"></asp:Button></TD>
				</TR>
			</table>
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0px" Visible="False">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
