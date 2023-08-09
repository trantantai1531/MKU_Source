<%@ Page Language="vb" AutoEventWireup="false" Inherits="WOverViewAdmin" CodeFile="WOverViewAdmin.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WOverViewAdmin</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" id="tbl1" runat="server">
				<tr>
					<td width="50%">
					</td>
					<td valign="top">
						<table width="100%" id="tbl2" runat="server" cellpadding="0" cellspacing="0">
							<tr>
								<td>
									<asp:LinkButton ID="lnkManUsers" Runat="server" CssClass="lbLinkfunction">Quản lý người dùng</asp:LinkButton><br>
									<asp:Label ID="lblBibliographic" Runat="server">Quản lý tài khoản và quyền sử dụng của người dùng.</asp:Label>
								</td>
							</tr>
							<tr>
								<td>
									<asp:LinkButton ID="lnkSyslog" Runat="server" CssClass="lbLinkfunction">Nhật ký hệ thống</asp:LinkButton><br>
									<asp:Label ID="lblSyslog" Runat="server">Lưu lại các hoạt động của người dùng trên hệ thống.</asp:Label>
								</td>
							</tr>
							<tr>
								<td>
									<asp:LinkButton ID="lnkParameterSys" Runat="server" CssClass="lbLinkfunction">Tham số hệ thống</asp:LinkButton><br>
									<asp:Label ID="lblParameterSys" Runat="server">Thiết đặt các tham số sẽ sử dụng trong hệ thống.</asp:Label>
								</td>
							</tr>
							<tr>
								<td>
									<asp:LinkButton ID="lnkLanguage" Runat="server" CssClass="lbLinkfunction">Quản lý ngôn ngữ</asp:LinkButton><br>
									<asp:Label ID="lblLanguage" Runat="server">Thay đổi thông tin của nhãn và các thông báo hiển thị cho một ngôn ngữ mới cho giao diện người dùng.</asp:Label>
								</td>
							</tr>
							<tr>
								<td>
									<asp:LinkButton ID="lnkDatabase" Runat="server" CssClass="lbLinkfunction">Quản lý kết nối tới cơ sở dữ liệu</asp:LinkButton><br>
									<asp:Label ID="lblDatabase" Runat="server">Sửa chữa thêm mới các kết nối tới cơ sở dữ liệu.</asp:Label>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
