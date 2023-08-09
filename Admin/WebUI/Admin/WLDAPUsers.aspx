<%@ Reference Page="~/main.aspx" %>
<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Admin.WLDAPUsers" CodeFile="WLDAPUsers.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Danh sách người dùng trong LDAP</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr class="lbPageTitle">
					<td><asp:label id="lblPageTitle" CssClass="lbPageTitle" Runat="server">
							Danh sách người dùng trong LDAP
						</asp:label></td>
				</tr>
				<tr>
					<td><asp:datagrid id="dtgLDAP" runat="server" AutoGenerateColumns="False" Width="100%">
							<Columns>
								<asp:TemplateColumn HeaderText="Chọn">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink Runat="server" ID="lnkSelect"></asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="userName" HeaderText="Tên đăng nhập"></asp:BoundColumn>
								<asp:BoundColumn DataField="Name" HeaderText="Tên đầy đủ"></asp:BoundColumn>
								<asp:BoundColumn DataField="Mail" HeaderText="Địa chỉ email"></asp:BoundColumn>
								<asp:BoundColumn DataField="AdressPath" HeaderText="Đường dẫn"></asp:BoundColumn>
							</Columns>
						</asp:datagrid></td>
				</tr>
				<tr class="lbControlBar">
					<td align="center">
						<asp:Button ID="btnClose" Runat="server" Width="80px" Text="Đóng(o)">
						</asp:Button></td>
				</tr>
			</table>
			<asp:DropDownList Runat="server" ID="ddlLabel" Visible="False" Width="0" Height="0">
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
				<asp:ListItem Value="3">Chọn người dùng cần cấp quyền</asp:ListItem>
				<asp:ListItem Value="4">Bạn có muốn chọn nguời dùng LDAP này không?</asp:ListItem>
			</asp:DropDownList></form>
	</body>
</HTML>
