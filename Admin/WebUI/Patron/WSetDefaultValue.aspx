<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WSetDefaultValue" EnableViewState="False" EnableViewStateMAC="False" CodeFile="WSetDefaultValue.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Đặt giá trị ngầm định</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellpadding="2" cellspacing="1">
				<tr>
					<td width="100%" colspan="2"><asp:Label ID="lblMainTitle" Runat="server" Width="100%" CssClass="main-group-form">Thiết đặt giá trị ngầm định cho việc nhập khẩu dữ liệu</asp:Label></td>
				</tr>
				<tr>
					<td width="30%" align="right"><asp:Label ID="lblValidDate" Runat="server">Ngày <u>c</u>ấp thẻ: </asp:Label></td>
					<td width="70%"><asp:TextBox ID="txtValidDate" Runat="server" Width="120px"></asp:TextBox>&nbsp;<asp:HyperLink ID="hrfValidDate" Runat="server">Lịch</asp:HyperLink></td>
				</tr>
				<tr>
					<td align="right"><asp:Label ID="lblExpiredDate" Runat="server">Ngày hết <u>h</u>ạn thẻ: </asp:Label></td>
					<td><asp:TextBox ID="txtExpiredDate" Runat="server" Width="120px"></asp:TextBox>&nbsp;<asp:HyperLink ID="hrfExpiredDate" Runat="server">Lịch</asp:HyperLink></td>
				</tr>
				<tr>
					<td align="right"><asp:Label ID="lblPatronGroupID" Runat="server">Nhóm <u>b</u>ạn đọc: </asp:Label></td>
					<td><asp:DropDownList ID="ddlPatronGroupID" Runat="server"></asp:DropDownList></td>
				</tr>
				<tr>
					<td align="right"><asp:Label ID="lblLastModifiedDate" Runat="server">Ngà<u>y</u> cập nhật cuối: </asp:Label></td>
					<td><asp:TextBox ID="txtLastModifiedDate" Runat="server" Width="120px"></asp:TextBox>&nbsp;<asp:HyperLink ID="hrfLastModifiedDate" Runat="server">Lịch</asp:HyperLink></td>
				</tr>
				<tr class="lbControlBar">
					<td align="right"><asp:Button ID="btnSetUp" Runat="server" Text="Thiết lập(u)" Width="98px"></asp:Button>&nbsp;</td>
					<td><asp:Button ID="btnReset" Runat="server" Text="Đặt lại(r)" Width="88px"></asp:Button>&nbsp;<asp:Button ID="btnClose" Runat="server" Text="Đóng(o)" Width="70px"></asp:Button></td>
				</tr>
			</table>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn không có quyền thực hiện chức năng này</asp:ListItem>
				<asp:ListItem Value="3">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
				<asp:ListItem Value="4">----------- Chọn -----------</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
